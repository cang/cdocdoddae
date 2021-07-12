using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;

namespace SiGlaz.Common.DDA
{
	public class ConditionField
	{ 
		#region Members	
		private string _name = string.Empty;
		private ConditionFieldType _fieldType = ConditionFieldType.String ; 
		#endregion

		#region Properties
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public ConditionFieldType FieldType 
		{
			get { return _fieldType; }
			set { _fieldType = value; }
		}
		#endregion
		
		#region Constructor
		public ConditionField( string name, ConditionFieldType fileType )
		{
			_name = name;
			_fieldType = fileType;			
		}
		#endregion
	};

	public class AdvancedCondition
	{
		#region Members
		private ArrayList _conditionList = new ArrayList();
		private bool _isOrAnd = true;
		private bool _isCondition = true;
		#endregion
		
		#region Properties
		[XmlElement(typeof(string))]
		public ArrayList ConditionList
		{
			get { return _conditionList; }
			set { _conditionList = value; }
		}

		[XmlElement(typeof(bool))]
		public bool IsOrAnd
		{
			get { return _isOrAnd; }
			set { _isOrAnd = value; }
		}

		[XmlElement(typeof(bool))]
		public bool IsCondition
		{
			get { return _isCondition; }
			set { _isCondition = value; }
		}
		#endregion

		#region Constructor
		public AdvancedCondition()
		{

		}
		#endregion

		#region Public Methods
		public string GetConditionString()
		{
			string strCondition = "(";
			string strOrAnd = " OR ";

			ArrayList alCondition = (ArrayList)_conditionList.Clone();
			string SubCondition = String.Empty;

			if(alCondition.Count > 0)
			{
				if(!_isOrAnd)
					strOrAnd = " AND ";

				for(int i = 0; i < alCondition.Count; i++)
				{					
					if(i == alCondition.Count - 1)
						strCondition = strCondition + "(" + alCondition[i].ToString() + "))";
					else
						strCondition = strCondition + "(" + alCondition[i].ToString() + ")" + strOrAnd;
				}
			}
			else
				strCondition = "";

			return strCondition;
		}
		public string GetConditionString(string fabID)
		{
			string strCondition = string.Format("FabID = '{0}' AND (", fabID);
			string strOrAnd = " OR ";

			ArrayList alCondition = (ArrayList)_conditionList.Clone();
			string SubCondition = String.Empty;

			if(alCondition.Count > 0)
			{
				if(!_isOrAnd)
					strOrAnd = " AND ";

				for(int i = 0; i < alCondition.Count; i++)
				{					
					if(i == alCondition.Count - 1)
						strCondition = strCondition + "(" + alCondition[i].ToString() + "))";
					else
						strCondition = strCondition + "(" + alCondition[i].ToString() + ")" + strOrAnd;
				}
			}
			else
				strCondition = string.Format("FabID = '{0}'", fabID);

			return strCondition.Replace("NUMOFDEFECT", "DEFECTCOUNT").Replace("SIGNATURETYPE", "SignatureDescription");
		}

		public bool IsFilterBySignature()
		{	
			bool result = false;

			foreach (string strCondition in _conditionList)
			{
				if (strCondition.IndexOf("SIGNATURENAME") >= 0)
				{
					result = true;
					break;
				}
			}

			return result;
		}
		#endregion
	};
	
	public class MultiLayerCondition
	{
		#region Members
		private string _fabID = string.Empty;
		private DateTime _fromDate = DateTime.Now;
		private DateTime _toDate = DateTime.Now;
		private string _type = "Layer Repeater";
		#endregion

		#region Constructor
		public MultiLayerCondition()
		{

		}
		#endregion

		#region Properties
		public string FabID
		{
			get { return _fabID; }
			set { _fabID = value; }
		}

		public DateTime FromDate
		{
			get { return _fromDate; }
			set { _fromDate = value; }
		}

		public DateTime ToDate
		{
			get { return _toDate; }
			set { _toDate = value; }
		}

		public string Type
		{
			get { return _type; }
			set { _type = value; }
		}
		#endregion
	};

}
