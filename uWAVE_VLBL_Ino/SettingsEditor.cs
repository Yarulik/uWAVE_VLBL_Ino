using System;
using System.IO.Ports;
using System.Windows.Forms;
using UCNLDrivers;

namespace uWAVE_VLBL_Ino
{
    public partial class SettingsEditor : Form
    {
        #region Properties

        public SettingsContainer Value
        {
            get
            {
                SettingsContainer result = new SettingsContainer();

                result.InPortName = InPortName;
                result.InPortBaudrate = InPortBaudrate;
                result.IsUseOutPort = IsUseOutPort;
                result.OutPortName = OutPortName;
                result.OutPortBaudrate = OutPortBaudrate;
                result.MeasurementsFIFOSize = MeasurementsFIFOSize;
                result.BaseSize = BaseSize;
                result.RadialErrorThreshold = RadialErrorThreshold;
                result.TargetLocationFIFOSize = TargetLocationFIFOSize;
                result.SalinityPSU = Salinity;
                result.SimplexSize = SimplexSize;

                return result;
            }
            set
            {
                InPortName = value.InPortName;
                InPortBaudrate = value.InPortBaudrate;
                IsUseOutPort = value.IsUseOutPort;
                OutPortName = value.OutPortName;
                OutPortBaudrate = value.OutPortBaudrate;
                MeasurementsFIFOSize = value.MeasurementsFIFOSize;
                BaseSize = value.BaseSize;
                RadialErrorThreshold = value.RadialErrorThreshold;
                TargetLocationFIFOSize = value.TargetLocationFIFOSize;
                Salinity = value.SalinityPSU;
                SimplexSize = value.SimplexSize;
            }
        }

        string InPortName
        {
            get { return TryGetCbxItem(inPortNameCbx); }
            set { TrySetCbxItem(inPortNameCbx, value); }
        }

        UCNLDrivers.BaudRate InPortBaudrate
        {
            get { return (UCNLDrivers.BaudRate)Enum.Parse(typeof(UCNLDrivers.BaudRate), TryGetCbxItem(inPortBaudrateCbx)); }
            set { TrySetCbxItem(inPortBaudrateCbx, value.ToString()); }
        }

        bool IsUseOutPort
        {
            get { return isUseOutPortChb.Checked; }
            set { isUseOutPortChb.Checked = value; }
        }

        string OutPortName
        {
            get { return TryGetCbxItem(outPortNameCbx); }
            set { TrySetCbxItem(outPortNameCbx, value); }
        }

        UCNLDrivers.BaudRate OutPortBaudrate
        {
            get { return (UCNLDrivers.BaudRate)Enum.Parse(typeof(UCNLDrivers.BaudRate), TryGetCbxItem(outPortBaudrateCbx)); }
            set { TrySetCbxItem(outPortBaudrateCbx, value.ToString()); }
        }

        int MeasurementsFIFOSize
        {
            get { return Convert.ToInt32(measurementsFIFOSizeEdit.Value); }
            set { TrySetNEditValue(measurementsFIFOSizeEdit, value); }
        }

        int BaseSize
        {
            get { return Convert.ToInt32(baseSizeEdit.Value); }
            set { TrySetNEditValue(baseSizeEdit, value); }
        }

        int TargetLocationFIFOSize
        {
            get { return Convert.ToInt32(targetLocationFIFOSizeEdit.Value); }
            set { TrySetNEditValue(targetLocationFIFOSizeEdit, value); }
        }

        double RadialErrorThreshold
        {
            get { return Convert.ToDouble(radialErrorThresholdEdit.Value); }
            set { TrySetNEditValue(radialErrorThresholdEdit, value); }
        }

        double SimplexSize
        {
            get { return Convert.ToDouble(simplexSizeEdit.Value); }
            set { TrySetNEditValue(simplexSizeEdit, value); }
        }

        double Salinity
        {
            get { return Convert.ToDouble(salinityEdit.Value); }
            set { TrySetNEditValue(salinityEdit, value); }
        }


        #endregion

        #region Constructor

        public SettingsEditor()
        {
            InitializeComponent();

            var baudrates = Enum.GetNames(typeof(BaudRate));

            inPortBaudrateCbx.Items.AddRange(baudrates);
            inPortBaudrateCbx.SelectedIndex = 0;

            outPortBaudrateCbx.Items.AddRange(baudrates);
            outPortBaudrateCbx.SelectedIndex = 0;

            var portNames = SerialPort.GetPortNames();

            inPortNameCbx.Items.AddRange(portNames);
            if (inPortNameCbx.Items.Count > 0)
            {
                inPortNameCbx.SelectedIndex = 0;               
            }

            outPortNameCbx.Items.AddRange(portNames);
            if (outPortNameCbx.Items.Count > 0)
            {
                outPortNameCbx.SelectedIndex = 0;
            }

            CheckValidity();
        }

        #endregion

        #region Handlers

        private void isUseOutPortChb_CheckedChanged(object sender, EventArgs e)
        {
            outPortNameCbx.Enabled = isUseOutPortChb.Checked;
            outPortBaudrateCbx.Enabled = isUseOutPortChb.Checked;

            CheckValidity();
        }

        private void inPortNameCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckValidity();
        }

        private void outPortNameCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckValidity();
        }

        #endregion

        #region Methods

        public static void TrySetCbxItem(ComboBox cbx, string item)
        {
            int idx = cbx.Items.IndexOf(item);
            if (idx >= 0)
                cbx.SelectedIndex = idx;
        }

        public static string TryGetCbxItem(ComboBox cbx)
        {
            if (cbx.SelectedItem == null)
                return string.Empty;
            else
                return cbx.SelectedItem.ToString();
        }

        public static void TrySetNEditValue(NumericUpDown nedit, double value)
        {
            decimal vl = Convert.ToDecimal(value);
            if (vl > nedit.Maximum) vl = nedit.Maximum;
            if (vl < nedit.Minimum) vl = nedit.Minimum;

            nedit.Value = vl;
        }

        private void CheckValidity()
        {
            okBtn.Enabled = (!string.IsNullOrEmpty(InPortName) && ( (InPortName != OutPortName) || (!IsUseOutPort)));
        }

        #endregion        
    }
}
