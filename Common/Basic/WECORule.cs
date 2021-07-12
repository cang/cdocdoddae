using System;
using System.Collections;
using System.Text;
using System.Xml.Serialization;

namespace SiGlaz.Common.DDA.Basic
{
    [XmlRootAttribute("WECORule")]
    public class WECORule
    {
        #region Private members 
        private WECORuleType _type;
        private bool _isAuto;
        private double _threshold;
        private WECORuleThresholdType _thresholdType;
        #endregion

        #region Properties
        public WECORuleType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public bool IsAuto
        {
            get { return _isAuto; }
            set { _isAuto = value; }
        }

        public double CustomThreshold
        {
            get { return _threshold; }
            set { _threshold = value; }
        }

        public WECORuleThresholdType ThresholdType
        {
            get { return _thresholdType; }
            set { _thresholdType = value; }
        }
        #endregion
    }
}
