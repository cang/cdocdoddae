using System;
using System.IO;
using System.Collections;
using System.Xml.Serialization;
using SiGlaz.Common.DDA.Basic;
using SiGlaz.Common.DDA.Const;

namespace SiGlaz.Common.DDA.Recipe
{
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class DataSourceRecipe
	{
		#region Members
		private TimeFilter _timeFilter = new TimeFilter();
		private QueryCondition _queryCondition = new QueryCondition();
		private TableLayout _tableLayout = new TableLayout();
		private ViewSurface _viewSurface = ViewSurface.All;
		private ViewType _viewType = ViewType.All;
		private bool _excludeDuplicateDisk = false; 
		private string _groupBy = string.Empty;
		#endregion

		#region Constructor
		public DataSourceRecipe()
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

		[XmlElement("TableLayout", typeof(TableLayout))]
		public TableLayout TableLayout
		{
			get { return _tableLayout; }
			set { _tableLayout = value; }
		}

		[XmlElement("ViewSurface", typeof(ViewSurface))]
		public ViewSurface ViewSurface
		{
			get { return _viewSurface; }
			set { _viewSurface = value; }
		}

		[XmlElement("ViewType", typeof(ViewType))]
		public ViewType ViewType
		{
			get { return _viewType; }
			set { _viewType = value; }
		}

		[XmlElement("ExcludeDuplicateDisk", typeof(bool))]
		public bool ExcludeDuplicateDisk
		{
			get { return _excludeDuplicateDisk; }
			set { _excludeDuplicateDisk = value; }
		}

		[XmlElement("GroupBy", typeof(string))]
		public string GroupBy
		{
			get { return _groupBy; }
			set { _groupBy = value; }
		}
		#endregion

		#region Public Methods
		public string GetSqlWhere()
		{
			string sqlWhere = string.Empty;

			if (_viewSurface == ViewSurface.All)
			{
				switch (_viewType)
				{
					case ViewType.All:
						sqlWhere = string.Format("{0} AND {1}", _timeFilter.GetSqlWhere(), _queryCondition.GetConditionString());
						break;
		
					case ViewType.SourceWithSignature:
						sqlWhere = string.Format("{0} AND {1} AND HasSignature = {2}", _timeFilter.GetSqlWhere(), _queryCondition.GetConditionString(), 1);
						break;

					case ViewType.SourceWithoutSignature:
						sqlWhere = string.Format("{0} AND {1} AND (HasSignature = {2} OR HasSignature IS NULL)", _timeFilter.GetSqlWhere(), _queryCondition.GetConditionString(), 0);
						break;

				}
			}
			else
			{
				switch (_viewType)
				{
					case ViewType.All:
						sqlWhere = string.Format("{0} AND {1} AND Surface = {2}", _timeFilter.GetSqlWhere(), _queryCondition.GetConditionString(), (int)_viewSurface - 1);
						break;

					case ViewType.SourceWithSignature:
						sqlWhere = string.Format("{0} AND {1} AND Surface = {2} AND HasSignature = {3}", _timeFilter.GetSqlWhere(), _queryCondition.GetConditionString(), (int)_viewSurface - 1, 1);
						break;

					case ViewType.SourceWithoutSignature:
						sqlWhere = string.Format("{0} AND {1} AND Surface = {2} AND (HasSignature = {3} OR HasSignature IS NULL)", _timeFilter.GetSqlWhere(), _queryCondition.GetConditionString(), (int)_viewSurface - 1, 0);
						break;
				}
			}

			if (_excludeDuplicateDisk)
				sqlWhere += " AND HasMeaning = 1";

			return sqlWhere;
		}

		public string GetFieldSelected()
		{
			string fieldList = string.Empty;

			foreach (string columnName in _tableLayout.DisplayColumns)
			{
				if (columnName.ToUpper() == WaferConst.SlotNoType.ToUpper())
					fieldList += "SlotNum,";
				else if (columnName.ToUpper() == WaferConst.TesterGrade.ToUpper())
					fieldList += "TestGrade,";
				else if (columnName.ToUpper() == WaferConst.IRISBinNo.ToUpper())
					fieldList += "BinNo,";
				else if (columnName.ToUpper() == WaferConst.DDAGrade.ToUpper())
					fieldList += "Grade,";
				else if (columnName.ToUpper() == WaferConst.Surface.ToUpper())
					fieldList += "CASE Surface WHEN 0 THEN 'Top' WHEN 1 THEN 'Bottom' END AS Surface,";
				else
					fieldList += string.Format("{0},",columnName);
			}

			fieldList = fieldList.Substring(0, fieldList.Length - 1);
			return fieldList;
		}
		#endregion

		#region Serialize & Deserialize
		public virtual bool Serialize(string fileName)
		{
			FileStream  fs = null;
			try
			{
				fs = new FileStream( fileName, FileMode.Create,FileAccess.Write, FileShare.ReadWrite );
				XmlSerializer s = new XmlSerializer(this.GetType());

				s.Serialize( fs, this );	
                
				return true;
			}
			catch
			{
				return false;
			}
			finally
			{
				if(fs != null)
					fs.Close();
			}
		}

		public virtual object Deserialze(string fileName)
		{
			FileStream      fs      = null;
			XmlSerializer   s       = null;

			try
			{
				fs  = new FileStream( fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite );
				s   = new XmlSerializer(this.GetType());
				object recipe = s.Deserialize( fs );
				return recipe;
			}
			catch
			{
				return null;
			}
			finally
			{
				if(s != null)
					s = null;

				if(fs != null)
					fs.Close();
			}
		}
		#endregion
	}
}
