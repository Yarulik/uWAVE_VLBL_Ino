using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using UCNLDrivers;
using UCNLKML;
using UCNLNav;
using UCNLNav.VLBL;
using UCNLNMEA;
using UCNLUI.Dialogs;
using uWAVELib;

namespace uWAVE_VLBL_Ino
{
    public partial class MainForm : Form
    {
        #region Properties

        NMEASerialPort inPort;
        SerialPort outPort;

        SimpeSettingsProviderXML<SettingsContainer> settingsProvider;
        TSLogProvider logger;

        VLBLCore<VLBLTOAMeasurement> vlblCore;

        string settingsFileName;
        string loggerFileName;
        string snapshotsPath;

        double soundSpeedMps = UCNLPhysics.PHX.PHX_FWTR_SOUND_SPEED_MPS;

        delegate T NullChecker<T>(object parameter);
        NullChecker<int> intNullChecker = (x => x == null ? -1 : (int)x);
        NullChecker<double> doubleNullChecker = (x => x == null ? double.NaN : (double)x);
        NullChecker<string> stringNullChecker = (x => x == null ? string.Empty : (string)x);

        AgingValue<double> targetLatitude;
        AgingValue<double> targetLongitude;
        AgingValue<double> targetRadialError;
        AgingValue<double> targetTemperature;
        AgingValue<double> targetDepth;
        AgingValue<double> targetBatVoltage;
        AgingValue<double> targetMSR;
        AgingValue<double> targetPTime;

        AgingValue<double> ownLatitude;
        AgingValue<double> ownLongitude;
        AgingValue<double> ownDepth;
        AgingValue<double> ownBatteryVoltage;

        bool is_g_updated = false;
        double g = UCNLPhysics.PHX.PHX_GRAVITY_ACC_MPS2;

        PrecisionTimer timer;
        DateTime geoPlotUpdateTimeStamp;

        bool isRestart = false;
        bool isAutosnapshot = false;

        bool isTracksEmpty;
        bool IsTracksEmpty
        {
            get { return isTracksEmpty; }
            set
            {
                if (value != isTracksEmpty)
                {
                    isTracksEmpty = value;

                    if (mainToolStrip.InvokeRequired)
                    {
                        mainToolStrip.Invoke((MethodInvoker)delegate
                        {
                            tracksSaveToolStripMenuItem.Enabled = !isTracksEmpty;
                            tracksClearToolStripMenuItem.Enabled = !isTracksEmpty;
                        });
                    }
                    else
                    {
                        tracksSaveToolStripMenuItem.Enabled = !isTracksEmpty;
                        tracksClearToolStripMenuItem.Enabled = !isTracksEmpty;
                    }                    
                }
            }
        }

        Dictionary<string, List<GeoPoint3D>> tracks;

        #endregion

        #region Constructor
              
        public MainForm()
        {            
            InitializeComponent();

            #region filenames

            DateTime startTime = DateTime.Now;
            settingsFileName = Path.ChangeExtension(Application.ExecutablePath, "settings");
            loggerFileName = StrUtils.GetTimeDirTreeFileName(startTime, Application.ExecutablePath, "LOG", "log", true);
            snapshotsPath = StrUtils.GetTimeDirTree(startTime, Application.ExecutablePath, "SNAPSHOTS", false);

            #endregion            

            #region logger

            logger = new TSLogProvider(loggerFileName);
            logger.WriteStart();
            logger.TextAddedEvent += (o, e) =>
            {
                if (geoPlotCartesian.InvokeRequired)
                    geoPlotCartesian.Invoke((MethodInvoker)delegate
                    {
                        geoPlotCartesian.AppendHistoryLine(e.Text);
                        geoPlotCartesian.Invalidate();
                    });
                else
                {
                    geoPlotCartesian.AppendHistoryLine(e.Text);
                    geoPlotCartesian.Invalidate();
                }
            };
            
            #endregion

            #region settingsProvider

            settingsProvider = new SimpeSettingsProviderXML<SettingsContainer>();
            settingsProvider.isSwallowExceptions = false;

            try
            {
                settingsProvider.Load(settingsFileName);
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }

            settingsProvider.isSwallowExceptions = true;

            logger.Write(settingsProvider.Data.ToString());

            #endregion

            #region NMEA

            NMEAParser.AddManufacturerToProprietarySentencesBase(ManufacturerCodes.VLB);
            NMEAParser.AddProprietarySentenceDescription(ManufacturerCodes.VLB, "L", "x.x,x.x,x.x,x.x,x,x.x,x.x,x.x");

            #endregion

            #region agingValues

            targetLatitude = new AgingValue<double>(3, 20, (x) => string.Format(CultureInfo.InvariantCulture, "LAT: {0:F06}°", x));
            targetLongitude = new AgingValue<double>(3, 20, (x) => string.Format(CultureInfo.InvariantCulture, "LON: {0:F06}°", x));
            targetRadialError = new AgingValue<double>(3, 300, (x) => string.Format(CultureInfo.InvariantCulture, "RER: {0:F03} m", x));
            targetTemperature = new AgingValue<double>(3, 600, (x) => string.Format(CultureInfo.InvariantCulture, "TMP: {0:F01} °C", x));
            targetDepth = new AgingValue<double>(3, 60, (x) => string.Format(CultureInfo.InvariantCulture, "DPT: {0:F03} m", x));
            targetBatVoltage = new AgingValue<double>(3, 300, (x) => string.Format(CultureInfo.InvariantCulture, "BAT: {0:F01} V", x));
            targetMSR = new AgingValue<double>(3, 20, (x) => string.Format(CultureInfo.InvariantCulture, "MSR: {0:F01} dB", x));
            targetPTime = new AgingValue<double>(3, 20, (x) => string.Format(CultureInfo.InvariantCulture, "TIM: {0:F04} sec", x));

            ownLatitude = new AgingValue<double>(3, 20, (x) => string.Format(CultureInfo.InvariantCulture, "LAT: {0:F06}°", x));
            ownLongitude = new AgingValue<double>(3, 20, (x) => string.Format(CultureInfo.InvariantCulture, "LON: {0:F06}°", x));
            ownDepth = new AgingValue<double>(3, 20, (x) => string.Format(CultureInfo.InvariantCulture, "DPT: {0:F03} m", x));
            ownBatteryVoltage = new AgingValue<double>(3, 20, (x) => string.Format(CultureInfo.InvariantCulture, "BAT: {0:F01} V", x));

            #endregion

            #region geoPlotCartesian

            geoPlotCartesian.AddTrack("Rover", Color.Gray, 2, 2, settingsProvider.Data.MeasurementsFIFOSize, true);
            geoPlotCartesian.AddTrack("Measurements", Color.Blue, 2, 2, settingsProvider.Data.MeasurementsFIFOSize, true);
            geoPlotCartesian.AddTrack("Reference point", Color.Magenta, 4, 4, 1, false);
            geoPlotCartesian.AddTrack("Base", Color.Green, 4, 4, settingsProvider.Data.BaseSize, false);
            geoPlotCartesian.AddTrack("Target", Color.Red, 6, 6, settingsProvider.Data.TargetLocationFIFOSize, true);

            #endregion

            #region vlblCore

            vlblCore = new VLBLCore<VLBLTOAMeasurement>(settingsProvider.Data.MeasurementsFIFOSize,
                settingsProvider.Data.BaseSize, 
                settingsProvider.Data.RadialErrorThreshold, 
                settingsProvider.Data.SimplexSize,
                UCNLNav.Algorithms.WGS84Ellipsoid);

            vlblCore.BaseUpdatedEventHandler += (o, e) => { UpdateTrack("Base", e.BasePoints); };
            vlblCore.ReferencePointUpdatedEventHandler += (o, e) => { UpdateTrack("Reference point", vlblCore.ReferencePoint); };

            vlblCore.TargetPositionUpdatedEventHandler += (o, e) =>
                {
                    UpdateTrack("Target", e.TargetPosition);

                    if (InvokeRequired)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            targetLatitude.Value = e.TargetPosition.Latitude;
                            targetLongitude.Value = e.TargetPosition.Longitude;
                            targetRadialError.Value = e.RadialError;
                        });
                    }
                    else
                    {
                        targetLatitude.Value = e.TargetPosition.Latitude;
                        targetLongitude.Value = e.TargetPosition.Longitude;
                        targetRadialError.Value = e.RadialError;
                    }
                };            

            #endregion

            #region tracks

            tracks = new Dictionary<string, List<GeoPoint3D>>();

            #endregion

            #region InPort

            inPort = new NMEASerialPort(new SerialPortSettings(settingsProvider.Data.InPortName, settingsProvider.Data.InPortBaudrate,
                 System.IO.Ports.Parity.None, 
                 DataBits.dataBits8, 
                 System.IO.Ports.StopBits.One, 
                 System.IO.Ports.Handshake.None));

            inPort.NewNMEAMessage += new EventHandler<NewNMEAMessageEventArgs>(inPort_NewNMEAMessage);

            #endregion

            #region OutPort

            if (settingsProvider.Data.IsUseOutPort)
            {
                outPort = new SerialPort(settingsProvider.Data.OutPortName, (int)settingsProvider.Data.OutPortBaudrate);
            }

            #endregion

            #region timer

            timer = new PrecisionTimer();
            timer.Period = 1000;
            timer.Mode = Mode.Periodic;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            #endregion
        }

        #endregion

        #region Methods

        private void ProcessException(Exception ex, bool isShowMessageBox)
        {
            logger.Write(ex);
            if (isShowMessageBox)
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }        

        double PressureByDepth(double dpt, double rho, double g, double p0)
        {            
            return dpt * rho * g / 100.0 + p0;
        }

        private void TryUpdateSoundSpeed()
        {
            if (ownDepth.IsInitializedAndNotObsolete &&
                targetDepth.IsInitializedAndNotObsolete &&
                targetTemperature.IsInitializedAndNotObsolete)
            {
                double meanDepth = (ownDepth.Value + targetDepth.Value) / 2.0;
                double mean_pressure_mBar = PressureByDepth(meanDepth, UCNLPhysics.PHX.PHX_FWTR_DENSITY_KGM3, g, UCNLPhysics.PHX.PHX_ATM_PRESSURE_MBAR);
                soundSpeedMps = UCNLPhysics.PHX.PHX_SpeedOfSound_Calc(targetTemperature.Value, mean_pressure_mBar, settingsProvider.Data.SalinityPSU);
                logger.Write(string.Format(CultureInfo.InvariantCulture, "Speed of sound updated: {0:F01} m/s", soundSpeedMps));
            }
        }

        private string GetAgingValuesOutline()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ROVER DATA");
            if (ownLatitude.IsInitialized)
                sb.AppendLine(ownLatitude.ToString());
            if (ownLongitude.IsInitialized)
                sb.AppendLine(ownLongitude.ToString());
            if (ownDepth.IsInitialized)
                sb.AppendLine(ownDepth.ToString());
            if (ownBatteryVoltage.IsInitialized)
                sb.AppendLine(ownBatteryVoltage.ToString());
            sb.AppendLine();
            sb.AppendLine("TARGET DATA");

            if (targetLatitude.IsInitialized)
                sb.AppendLine(targetLatitude.ToString());
            if (targetLongitude.IsInitialized)
                sb.AppendLine(targetLongitude.ToString());
            if (targetRadialError.IsInitialized)
                sb.AppendLine(targetRadialError.ToString());
            if (targetTemperature.IsInitialized)
                sb.AppendLine(targetTemperature.ToString());
            if (targetDepth.IsInitialized)
                sb.AppendLine(targetDepth.ToString());
            if (targetBatVoltage.IsInitialized)
                sb.AppendLine(targetBatVoltage.ToString());
            if (targetMSR.IsInitialized)
                sb.AppendLine(targetMSR.ToString());
            if (targetPTime.IsInitialized)
                sb.AppendLine(targetPTime.ToString());                

            return sb.ToString();
        }

        private void UpdateTrack(string key, GeoPoint point)
        {
            if (geoPlotCartesian.InvokeRequired)
            {
                geoPlotCartesian.Invoke((MethodInvoker)delegate
                {
                    geoPlotCartesian.UpdateTrack(key, point.Latitude, point.Longitude);
                    geoPlotCartesian.Invalidate();
                });
            }
            else
            {
                geoPlotCartesian.UpdateTrack(key, point.Latitude, point.Longitude);
                geoPlotCartesian.Invalidate();
            }

            geoPlotUpdateTimeStamp = DateTime.Now;

            TracksWritePoint(key, new GeoPoint3D(point.Latitude, point.Longitude, 0));

            if (isAutosnapshot)
                InvokeSaveFullSnapshot();
        }

        private void UpdateTrack(string key, GeoPoint3D point)
        {
            if (geoPlotCartesian.InvokeRequired)
            {
                geoPlotCartesian.Invoke((MethodInvoker)delegate
                {
                    geoPlotCartesian.UpdateTrack(key, point.Latitude, point.Longitude);
                    geoPlotCartesian.Invalidate();
                });
            }
            else
            {
                geoPlotCartesian.UpdateTrack(key, point.Latitude, point.Longitude);
                geoPlotCartesian.Invalidate();
            }

            geoPlotUpdateTimeStamp = DateTime.Now;

            TracksWritePoint(key, point);

            if (isAutosnapshot)
                InvokeSaveFullSnapshot();
        }

        private void UpdateTrack(string key, IEnumerable<IVLBLMeasurement> points)
        {
            List<PointF> basePoints = new List<PointF>();
            if (geoPlotCartesian.InvokeRequired)
            {
                geoPlotCartesian.Invoke((MethodInvoker)delegate
                {
                    foreach (var basePoint in points)
                    {
                        var geoPoint = (GeoPoint3D)basePoint;
                        basePoints.Add(new PointF(Convert.ToSingle(geoPoint.Longitude), Convert.ToSingle(geoPoint.Latitude)));
                    }

                    geoPlotCartesian.UpdateTrack(key, basePoints.ToArray());
                    geoPlotCartesian.Invalidate();
                });
            }
            else
            {
                foreach (var basePoint in points)
                {
                    var geoPoint = (GeoPoint3D)basePoint;
                    basePoints.Add(new PointF(Convert.ToSingle(geoPoint.Longitude), Convert.ToSingle(geoPoint.Latitude)));
                }

                geoPlotCartesian.UpdateTrack(key, basePoints.ToArray());
                geoPlotCartesian.Invalidate();
            }

            geoPlotUpdateTimeStamp = DateTime.Now;

            if (isAutosnapshot)
                InvokeSaveFullSnapshot();
        }

        private void TracksWritePoint(string key, GeoPoint3D point)
        {
            if (!tracks.ContainsKey(key))
                tracks.Add(key, new List<GeoPoint3D>());

            tracks[key].Add(point);

            if (isTracksEmpty)
                IsTracksEmpty = false;
        }

        private void TracksClear()
        {
            tracks.Clear();
            IsTracksEmpty = true;
        }

        private void InvokeSaveFullSnapshot()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { SaveFullSnapshot(); });
            }
            else
            {
                SaveFullSnapshot();
            }
        }

        private void SaveFullSnapshot()
        {
            Bitmap target = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(target, this.DisplayRectangle);

            try
            {
                if (!Directory.Exists(snapshotsPath))
                    Directory.CreateDirectory(snapshotsPath);

                target.Save(Path.Combine(snapshotsPath, string.Format("{0}.{1}", StrUtils.GetHMSString(), ImageFormat.Png)));
            }
            catch
            {
                //
            }
        }

        private bool SaveTracksAsKML(string fileName)
        {
            KMLData data = new KMLData(fileName, "Generated by uWAVE VLBL Ino application");
            List<KMLLocation> kmlTrack;

            foreach (var item in tracks)
            {
                kmlTrack = new List<KMLLocation>();
                foreach (var point in item.Value)
                    kmlTrack.Add(new KMLLocation(point.Longitude, point.Latitude, -point.Depth));

                data.Add(new KMLPlacemark(string.Format("{0} track", item.Key), "", kmlTrack.ToArray()));
            }

            bool isOk = false;
            try
            {
                TinyKML.Write(data, fileName);
                isOk = true;
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }

            return isOk;
        }

        private bool SaveTracksAsCSV(string fileName)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var track in tracks)
            {
                sb.AppendFormat("\r\nTrack name: {0}\r\n", track.Key);
                sb.Append("LAT;LON;DPT;\r\n");

                foreach (var point in track.Value)
                {
                    sb.AppendFormat(CultureInfo.InvariantCulture,
                        "{0:F06};{1:F06};{2:F03}\r\n",                        
                        point.Latitude,
                        point.Longitude,
                        point.Depth);
                }
            }

            bool isOk = false;
            try
            {
                File.WriteAllText(fileName, sb.ToString());
                isOk = true;
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }

            return isOk;
        }

        private void AnalyzeLog(string fileName)
        {
            string[] lines = null;
            bool isOk = false;

            try
            {
                lines = File.ReadAllLines(fileName);
                isOk = true;
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }

            if (isOk)
            {
                // Disable controls
                mainToolStrip.Enabled = false;

                foreach (var line in lines)
                {
                    int stIdx = line.IndexOf('$');
                    if (stIdx >= 0)
                    {
                        var str = line.Substring(stIdx) + "\r\n";
                        inPort_NewNMEAMessage(inPort, new NewNMEAMessageEventArgs(str));
                        Application.DoEvents();
                    }
                }

                MessageBox.Show(string.Format("Analysis of '{0}' is complete.",
                    Path.GetFileNameWithoutExtension(fileName)),
                    "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                mainToolStrip.Enabled = true;
                // enable controls
            }
        }
                
        #endregion

        #region Handlers

        #region UI

        #region mainToolStrip

        private void connectionBtn_Click(object sender, System.EventArgs e)
        {
            if (inPort.IsOpen)
            {
                try
                {
                    inPort.Close();
                }
                catch (Exception ex)
                {
                    ProcessException(ex, true);
                }

                if (settingsProvider.Data.IsUseOutPort)
                {
                    try
                    {
                        outPort.Close();
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }
                }

                connectionBtn.Checked = false;
                connectionBtn.Text = "CONNECT";
                settingsBtn.Enabled = true;
            }
            else
            {
                try
                {
                    inPort.Open();

                    connectionBtn.Text = "DISCONNECT";
                    connectionBtn.Checked = true;
                    settingsBtn.Enabled = false;
                }
                catch (Exception ex)
                {
                    ProcessException(ex, true);
                }

                if (settingsProvider.Data.IsUseOutPort)
                {
                    try
                    {
                        outPort.Open();
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }
                }
            }
        }

        private void settingsBtn_Click(object sender, System.EventArgs e)
        {
            bool isSaved = false;

            using (SettingsEditor sEditor = new SettingsEditor())
            {
                sEditor.Value = settingsProvider.Data;

                if (sEditor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    settingsProvider.Data = sEditor.Value;

                    try
                    {
                        settingsProvider.Save(settingsFileName);
                        isSaved = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if ((isSaved) && (MessageBox.Show("Settings saved. Restart application to apply new settings?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes))
            {
                isRestart = true;
                Application.Restart();
            }

        }

        private void logViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(loggerFileName);
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }
        }

        private void logClearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete all the log items?",
                                "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                string logRootPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "LOG");
                var dirs = Directory.GetDirectories(logRootPath);
                int dirNum = 0;
                foreach (var item in dirs)
                {
                    try
                    {
                        Directory.Delete(item, true);
                        dirNum++;
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }
                }

                MessageBox.Show(string.Format("{0} entries were deleted.", dirNum),
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }

        private void logAnalyzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog oDoialog = new OpenFileDialog())
            {
                oDoialog.Title = "Select a log file to analyze...";
                oDoialog.Filter = string.Format("Log files (*.log)|*.log");

                if (oDoialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    AnalyzeLog(oDoialog.FileName);
                }
            }
        }

        private void tracksSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isSaved = false;

            using (SaveFileDialog sDilog = new SaveFileDialog())
            {
                sDilog.Title = "Save tracks as...";
                sDilog.Filter = "Google KML (*.kml)|*.kml|CSV (*.csv)|*.csv";
                sDilog.FileName = string.Format("uWAVE_VLBL_Ino_Tracks_{0}", StrUtils.GetHMSString());

                if (sDilog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (sDilog.FilterIndex == 1)
                        isSaved = SaveTracksAsKML(sDilog.FileName);
                    else if (sDilog.FilterIndex == 2)
                        isSaved = SaveTracksAsCSV(sDilog.FileName);
                }
            }

            if (isSaved &&
                MessageBox.Show("Tracks saved, do you want to clear all tracks data?", 
                "Question",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                TracksClear();

        }

        private void tracksClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear all the tracks?",
                                "Question", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                tracks.Clear();

        }

        private void isAutoSnapshotBtn_Click(object sender, EventArgs e)
        {
            isAutosnapshot = !isAutosnapshot;
            isAutoSnapshotBtn.Checked = isAutosnapshot;
        }

        private void infoBtn_Click(object sender, System.EventArgs e)
        {
            using (AboutBox aDialog = new AboutBox())
            {
                aDialog.Weblink = "www.unavlab.com";
                aDialog.ApplyAssembly(Assembly.GetExecutingAssembly());
                aDialog.ShowDialog();
            }
        }

        #endregion

        #region mainForm

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           e.Cancel = (!isRestart) && (MessageBox.Show("Close application?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No);
           
            if (!e.Cancel)
                logger.FinishLog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = false;
            if (timer.IsRunning) timer.Stop();

            if (inPort.IsOpen)
            {
                try
                {
                    inPort.Close();
                }
                catch (Exception ex)
                {
                }
            }

            if (settingsProvider.Data.IsUseOutPort)
            {
                if ((outPort != null) && (outPort.IsOpen))
                {
                    try
                    {
                        outPort.Close();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }


        #endregion
        
        #endregion

        #region inPort

        private void inPort_NewNMEAMessage(object sender, NewNMEAMessageEventArgs e)
        {
            NMEASentence parsedSentence = null;
            bool isParsed = false;

            logger.Write(string.Format("{0} >> {1}", inPort.PortName, e.Message));

            try
            {
                parsedSentence = NMEAParser.Parse(e.Message);
                isParsed = true;
            }
            catch (Exception ex)
            {
                ProcessException(ex, false);
            }

            if (isParsed && (parsedSentence is NMEAProprietarySentence))
            {
                NMEAProprietarySentence pResult = (parsedSentence as NMEAProprietarySentence);
                if ((pResult.Manufacturer == ManufacturerCodes.VLB) &&
                    (pResult.SentenceIDString == "L"))
                {
                    // $PVLBL,ownLat,ownLon,ownDepth,ownBatV,targetDataID,targetDataValue,propagationTime,MSR
                    double ownLat = doubleNullChecker(pResult.parameters[0]);
                    double ownLon = doubleNullChecker(pResult.parameters[1]);
                    double ownDpt = doubleNullChecker(pResult.parameters[2]);
                    double ownBatV = doubleNullChecker(pResult.parameters[3]);
                    RC_CODES_Enum dataID = (RC_CODES_Enum)Enum.ToObject(typeof(RC_CODES_Enum), intNullChecker(pResult.parameters[4]));
                    double dataVal = doubleNullChecker(pResult.parameters[5]);
                    double pTime = doubleNullChecker(pResult.parameters[6]);
                    double msr = doubleNullChecker(pResult.parameters[7]);

                    if ((!double.IsNaN(ownLat)) && (!double.IsNaN(ownLon)))
                    {
                        ownLatitude.Value = ownLat;
                        ownLongitude.Value = ownLon;

                        if (!is_g_updated)
                        {                            
                            g = UCNLPhysics.PHX.PHX_GravityConstant_Calc(ownLat);
                            is_g_updated = true;
                            logger.Write(string.Format(CultureInfo.InvariantCulture, "Gravity constant updated: {0:F04} m/s^2", g));
                        }
                    }

                    if (!double.IsNaN(ownDpt))
                        ownDepth.Value = ownDpt;

                    if (!double.IsNaN(ownBatV))
                        ownBatteryVoltage.Value = ownBatV;

                    if (!double.IsNaN(pTime))
                        targetPTime.Value = pTime;

                    if (!double.IsNaN(msr))
                        targetMSR.Value = msr;

                    if (!double.IsNaN(dataVal))
                    {
                        if (dataID == RC_CODES_Enum.RC_DPT_GET)
                        {
                            targetDepth.Value = dataVal;                            
                        }
                        else if (dataID == RC_CODES_Enum.RC_TMP_GET)
                        {
                            targetTemperature.Value = dataVal;
                            TryUpdateSoundSpeed();
                        }
                        else if (dataID == RC_CODES_Enum.RC_BAT_V_GET)
                            targetBatVoltage.Value = dataVal;
                    }

                    if (!double.IsNaN(ownLat) && !double.IsNaN(ownLon) && !double.IsNaN(ownDpt))
                    {
                        if (!double.IsNaN(pTime) &&
                            targetDepth.IsInitializedAndNotObsolete)
                        {
                            vlblCore.TargetDepth = targetDepth.Value;
                            vlblCore.AddMeasurement(new VLBLTOAMeasurement(ownLat, ownLon, ownDpt, pTime * soundSpeedMps));

                            UpdateTrack("Measurements", new GeoPoint3D(ownLat, ownLon, ownDpt));
                        }
                        else
                        {
                            UpdateTrack("Rover", new GeoPoint3D(ownLat, ownLon, ownDpt));
                        }
                    }
                }
            }
        }

        #endregion

        #region timer

        private void timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Subtract(geoPlotUpdateTimeStamp).TotalSeconds >= 1)
            {
                if (geoPlotCartesian.InvokeRequired)
                    geoPlotCartesian.Invoke((MethodInvoker)delegate
                    {
                        geoPlotCartesian.LeftUpperCornerText = GetAgingValuesOutline();
                        geoPlotCartesian.Invalidate();
                    });
                else
                {
                    geoPlotCartesian.LeftUpperCornerText = GetAgingValuesOutline();
                    geoPlotCartesian.Invalidate();
                }

                geoPlotUpdateTimeStamp = DateTime.Now;
            }
        }

        #endregion                        
               
        #endregion        
    }
}
