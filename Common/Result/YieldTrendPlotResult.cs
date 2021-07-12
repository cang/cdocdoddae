using System;
using System.Collections;
using System.Xml.Serialization;
using SiGlaz.Common.DDA.Basic;
using SiGlaz.Common.DDA;

namespace SiGlaz.Common.DDA.Result
{
	[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://siglaz.com")]
	public class YieldTrendPlotResult : Error
	{
		#region Members
		private string _chartTitle = string.Empty;
		private string _categoryLabel = string.Empty;
		private ArrayList _categoryValues = new ArrayList();
		private string _dataLabel = string.Empty;
		private string _secondaryDataLabel = string.Empty;
		private ArrayList _dataValues = new ArrayList();
		private ArrayList _secondaryDataValues = new ArrayList();
		private double _contrilLimit = 0;
		private ArrayList _dateTimes = new ArrayList();
		#endregion

		#region Constructor
		public YieldTrendPlotResult() : base()
		{
            
		}

		public YieldTrendPlotResult(ErrorCode code, string description) : base(code, description)
		{

		}
		#endregion

		#region Properties
		[XmlElement("ChartTitle", typeof(string))]
		public string ChartTitle
		{
			get { return _chartTitle; }
			set { _chartTitle = value; }
		}

		[XmlElement("CategoryLabel", typeof(string))]
		public string CategoryLabel
		{
			get { return _categoryLabel; }
			set { _categoryLabel = value; }
		}

		[XmlElement("DataLabel", typeof(string))]
		public string DataLabel
		{
			get { return _dataLabel; }
			set { _dataLabel = value; }
		}

		[XmlElement("SecondaryDataLabel", typeof(string))]
		public string SecondaryDataLabel
		{
			get { return _secondaryDataLabel; }
			set { _secondaryDataLabel = value; }
		}

		[XmlElement("CategoryValues", typeof(string))]
		public string[] CategoryValues
		{
			get
			{
				return (string[])_categoryValues.ToArray(typeof(string));
			}
			set
			{
				_categoryValues.Clear();
				if (value != null)
					_categoryValues.AddRange(value);
			}
		}

		[XmlElement("DataValues", typeof(double))]
		public double[] DataValues
		{
			get
			{
				return (double[])_dataValues.ToArray(typeof(double));
			}
			set
			{
				_dataValues.Clear();
				if (value != null)
					_dataValues.AddRange(value);
			}
		}

		[XmlElement("SecondaryDataValues", typeof(double))]
		public double[] SecondaryDataValues
		{
			get
			{
				return (double[])_secondaryDataValues.ToArray(typeof(double));
			}
			set
			{
				_secondaryDataValues.Clear();
				if (value != null)
					_secondaryDataValues.AddRange(value);
			}
		}

		[XmlElement("ControlLimit", typeof(double))]
		public double ControlLimit
		{
			get { return _contrilLimit; }
			set { _contrilLimit = value; }
		}

		[XmlElement("DateTimes", typeof(DateTime))]
		public DateTime[] DateTimes
		{
			get
			{
				return (DateTime[])_dateTimes.ToArray(typeof(DateTime));
			}
			set
			{
				_dateTimes.Clear();
				if (value != null)
					_dateTimes.AddRange(value);
			}
		}
		#endregion
	}
}
