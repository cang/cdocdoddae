using System;
using System.Collections;
using System.Xml.Serialization;
using SiGlaz.Common.DDA.Basic;
using SiGlaz.Common.DDA;

namespace SiGlaz.Common.DDA.Recipe
{
	[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://siglaz.com")]
	public class YieldTrendPlotRecipe
	{
		#region Members
		private TimeFilter _timeFilter = new TimeFilter();
		private QueryCondition _queryCondition = new QueryCondition();
		private CubeInfo _cubeInfo = new CubeInfo();
		private int _grade = 0;
		private double _controlLimit = 0;
		private CategoryAxis _categoryAxis = new CategoryAxis();
		private ValueAxis _valueAxis = new ValueAxis();
		private bool _isShowNullDataPoint = false;
		#endregion

		#region Constructor
		public YieldTrendPlotRecipe()
		{

		}
		#endregion

		#region Properties
		[XmlElement("TimeFilter", typeof(TimeFilter))]
		public TimeFilter TimeFilter
		{
			get { return _timeFilter; }
			set { _timeFilter = value; }
		}

		[XmlElement("QueryCondition", typeof(QueryCondition))]
		public QueryCondition QueryCondition
		{
			get { return _queryCondition; }
			set { _queryCondition = value; }
		}

		[XmlElement("Grade", typeof(int))]
		public int Grade
		{
			get { return _grade; }
			set { _grade = value; }
		}

		[XmlElement("ControlLimit", typeof(double))]
		public double ControlLimit
		{
			get { return _controlLimit; }
			set { _controlLimit = value; }
		}

		[XmlElement("CategoryAxis", typeof(CategoryAxis))]
		public CategoryAxis CategoryAxis
		{
			get { return _categoryAxis; }
			set { _categoryAxis = value; }
		}

		[XmlElement("ValueAxis", typeof(ValueAxis))]
		public ValueAxis ValueAxis
		{
			get { return _valueAxis; }
			set { _valueAxis = value; }
		}

		[XmlElement("CubeInfo", typeof(CubeInfo))]
		public CubeInfo CubeInfo
		{
			get { return _cubeInfo; }
			set { _cubeInfo = value; }
		}

		[XmlElement("IsShowNullDataPoint", typeof(bool))]
		public bool IsShowNullDataPoint
		{
			get { return _isShowNullDataPoint; }
			set { _isShowNullDataPoint = value; }
		}
		#endregion

		#region Public Methods
		public string GetSqlWhere()
		{
			return string.Format("{0} AND [Grade] = {1} AND {2} AND {3}", _timeFilter.GetSqlWhere_DataMart(), _grade, _queryCondition.GetConditionString(), _cubeInfo.GetSqlWhere());
		}
		#endregion
	}
}
