using System;
using System.Collections;
using System.Xml.Serialization;

namespace SiGlaz.Common.DDA.Result
{
	public class ChartResult
	{
		#region Members
		private string _chartTitle = string.Empty;
		private string _categoryTitle = string.Empty;
		private string _dataTitle = string.Empty;
		private string _dataTitle2 = string.Empty;
		private ArrayList _categoryValues = new ArrayList();
		private ArrayList _labelValues = new ArrayList();
		private ArrayList _dataValues = new ArrayList();
		private ArrayList _dataValues2 = new ArrayList();
		private ArrayList _paretoValues = new ArrayList();
		private int _maxDisk = 0;
		private double _maxYield = 0;
		private ArrayList _individualChartResults = new ArrayList();
		#endregion

		#region Constructor
		public ChartResult()
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

		[XmlElement("CategoryTitle", typeof(string))]			
		public string CategoryTitle
		{
			get { return _categoryTitle; }
			set { _categoryTitle = value; }
		}

		[XmlElement("DataTitle", typeof(string))]			
		public string DataTitle
		{
			get { return _dataTitle; }
			set { _dataTitle = value; }
		}

		[XmlElement("DataTitle2", typeof(string))]			
		public string DataTitle2
		{
			get { return _dataTitle2; }
			set { _dataTitle2 = value; }
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

		[XmlElement("LabelValues", typeof(string))]			
		public string[] LabelValues
		{
			get
			{
				return (string[])_labelValues.ToArray(typeof(string));
			}
			set
			{
				_labelValues.Clear();
				if (value != null)
					_labelValues.AddRange(value);
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

		[XmlElement("DataValues2", typeof(double))]			
		public double[] DataValues2
		{
			get
			{
				return (double[])_dataValues2.ToArray(typeof(double));
			}
			set
			{
				_dataValues2.Clear();
				if (value != null)
					_dataValues2.AddRange(value);
			}
		}

		[XmlElement("ParetoValues", typeof(double))]			
		public double[] ParetoValues
		{
			get
			{
				return (double[])_paretoValues.ToArray(typeof(double));
			}
			set
			{
				_paretoValues.Clear();
				if (value != null)
					_paretoValues.AddRange(value);
			}
		}

		[XmlElement("MaxDisk", typeof(int))]			
		public int MaxDisk
		{
			get { return _maxDisk; }
			set { _maxDisk = value; }
		}

		[XmlElement("MaxYield", typeof(double))]			
		public double MaxYield
		{
			get { return _maxYield; }
			set { _maxYield = value; }
		}

		[XmlElement("IndividualChartResults", typeof(IndividualChartResult))]			
		public IndividualChartResult[] IndividualChartResults
		{
			get
			{
				return (IndividualChartResult[])_individualChartResults.ToArray(typeof(IndividualChartResult));
			}
			set
			{
				_individualChartResults.Clear();
				if (value != null)
					_individualChartResults.AddRange(value);
			}
		}
		#endregion

		#region Private Methods

		#endregion

		#region Public Methods
		public void AddCategoryValue(object value)
		{
			if (_categoryValues == null) _categoryValues = new ArrayList();
			_categoryValues.Add(value);
		}

		public void AddLabelValue(object value)
		{
			if (_labelValues == null) _labelValues = new ArrayList();
			_labelValues.Add(value);
		}

		public void AddDataValue(object value)
		{
			if (_dataValues == null) _dataValues = new ArrayList();
			_dataValues.Add(value);
		}

		public void AddDataValue2(object value)
		{
			if (_dataValues2 == null) _dataValues2 = new ArrayList();
			_dataValues2.Add(value);
		}

		public void AddParetoValues(object value)
		{
			if (_paretoValues == null) _paretoValues = new ArrayList();
			_paretoValues.Add(value);
		}

		public void AddIndividualChartResult(object value)
		{
			if (_individualChartResults == null) _individualChartResults = new ArrayList();
			_individualChartResults.Add(value);
		}

		public bool GroupByNameContains(string groupByName)
		{
			if (_individualChartResults == null || _individualChartResults.Count <= 0) return false;

			foreach (IndividualChartResult result in _individualChartResults)
			{
				if (groupByName.ToUpper() == result.GroupByName.ToUpper()) return true;
			}

			return false;
		}
		#endregion
	}

	public class IndividualChartResult
	{
		#region	Members
		private string _groupByName = string.Empty;
		private ChartResult _result = new ChartResult();
		#endregion

		#region	Constructor
		public IndividualChartResult()
		{

		}
		#endregion

		#region Properties
		[XmlElement("GroupByName", typeof(string))]			
		public string GroupByName
		{
			get { return _groupByName; }
			set { _groupByName = value; }
		}

		[XmlElement("Result", typeof(ChartResult))]			
		public ChartResult Result
		{
			get { return _result; }
			set { _result = value; }
		}
		#endregion
	}
}
