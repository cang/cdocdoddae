using System;
using System.Collections;
using System.Xml.Serialization;

namespace SiGlaz.Common.DDA.Basic
{
	[XmlRootAttribute("WECORuleResult")]
    public class WECORuleResult
    {
        #region Private members
        private WECORuleType _wecoRuleType;
        private int[] _oocPointIndices;
		private double _threshold;
		private long[] _oocWaferKeys;
		private long[] _oocResultKeys;
        #endregion

        #region Properties
        public WECORuleType WecoRuleType
        {
            get { return _wecoRuleType; }
            set { _wecoRuleType = value; }
        }
        public int[] OOCPointIndices
        {
            get { return _oocPointIndices; }
            set { _oocPointIndices = value; }
        }
		public long[] OOCWaferKeys
		{
			get { return _oocWaferKeys; }
			set { _oocWaferKeys = value; }
		}
		public long[] OOCResultKeys
		{
			get { return _oocResultKeys; }
			set { _oocResultKeys = value; }
		}
		public double Threshold
		{
			get { return _threshold; }
			set { _threshold = value; }
		}
        #endregion

		public override string ToString()
		{
			switch (_wecoRuleType)
			{
				case WECORuleType.AnyPointAbove3Sigma:
					return string.Format("Any Point Above Mean + 3 Sigma ( Threshold: {0} )", Math.Round(_threshold, 2));
				case WECORuleType.TwoOutOfThreeConsecutivePointsAbove2Sigma:
					return string.Format("Two of Three Consecutive Points Above Mean + 2 Sigma ( Threshold: {0} )", Math.Round(_threshold, 2));
				case WECORuleType.FourOutOfFiveConsecutivePointsAboveSigma:
					return string.Format("Four of Five Consecutive Points Above Mean + Sigma ( Threshold: {0} )", Math.Round(_threshold, 2));
				case WECORuleType.EightConsecutivePointsAboveMean:
					return string.Format("Eight Consecutive Points Above Mean ( Threshold: {0} )", Math.Round(_threshold, 2));
				default:
					return string.Empty;
			}
		}

    };
}
