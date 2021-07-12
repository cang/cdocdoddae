using System;
using System.Xml.Serialization;

namespace SiGlaz.Common.DDA.Basic
{
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
    public class NoiseFilter
    {
        #region Private members 
		private bool _isNSigma = false;
		private double _value = 0;
		private bool _isFilter = false;
        #endregion

		#region Properties
		[XmlElement("IsNSigma", typeof(bool))]
		public bool IsNSigma
		{
			get { return _isNSigma; }
			set { _isNSigma = value; }
		}
		[XmlElement("IsFilter", typeof(bool))]
		public bool IsFilter
		{
			get { return _isFilter; }
			set { _isFilter = value; }
		}

		[XmlElement("Value", typeof(double))]
		public double Value
		{
			get { return _value; }
			set { _value = value; }
		}
        #endregion
    }
}
