using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNLDrivers;

namespace uWAVE_VLBL_Ino
{
    [Serializable]
    public class SettingsContainer : SimpleSettingsContainer
    {
        #region Properties

        public string InPortName;
        public BaudRate InPortBaudrate;

        public bool IsUseOutPort;
        public string OutPortName;
        public BaudRate OutPortBaudrate;

        public int MeasurementsFIFOSize;
        public int BaseSize;
        public int TargetLocationFIFOSize;

        public double RadialErrorThreshold;
        public double SimplexSize;

        public double SalinityPSU;

        #endregion

        #region Methods

        public override void SetDefaults()
        {
            InPortName = "COM1";
            InPortBaudrate = BaudRate.baudRate9600;

            IsUseOutPort = false;
            OutPortName = "COM1";
            OutPortBaudrate = BaudRate.baudRate9600;

            MeasurementsFIFOSize = 512;
            BaseSize = 4;
            TargetLocationFIFOSize = 64;

            RadialErrorThreshold = 2.5;
            SimplexSize = 3;

            SalinityPSU = 0;
        }

        #endregion
    }
}
