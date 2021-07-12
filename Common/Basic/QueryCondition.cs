using System;
using System.Collections;
using System.Xml.Serialization;
using SiGlaz.Common.DDA.Const;

namespace SiGlaz.Common.DDA.Basic
{
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
    public class QueryCondition
    {
        #region Private members 
        private string _fabId;
		private ArrayList		_conditionList;
		private ConditionType	_conditiontype;
		private bool _isOrAnd = true;
		private bool _isFilter = true;
        #endregion

        #region Properties
        public string FabId
        {
            get 
			{ 
				return _fabId; 
			}
            set { _fabId = value; }
        }

		public ConditionType ConditionType
		{
			get 
			{ 
				return _conditiontype; 
			}
			set { _conditiontype = value; }
		}

		[XmlElement("ConditionList", typeof(string))]
        public string[] ConditionList
		{
			get 
            { 
                return (string[])_conditionList.ToArray(typeof(string));
            }
			set 
            {
                _conditionList.Clear();
                if (value != null)
                    _conditionList.AddRange(value);
            }
		}


		public bool IsOrAnd
		{
			get { return _isOrAnd; }
			set { _isOrAnd = value; }
		}

		public bool IsFilter
		{
			get { return _isFilter; }
			set { _isFilter = value; }
		}
        #endregion

        #region Contructor
        public QueryCondition()
        {
            _conditionList = new ArrayList();
        }
        #endregion

        #region Public Methods
		public ArrayList GetConditionArrayList()
		{
			return _conditionList;
		}

		public string GetConditionString()
		{
            if (!_isFilter) return string.Format("FabID = '{0}'", _fabId);

            string strCondition = string.Format("FabID = '{0}' AND (", _fabId);
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

            return strCondition.Replace("*", "%").Replace(WaferConst.SlotNoType, "SlotNum").Replace(WaferConst.TesterGrade, "TestGrade").Replace(WaferConst.IRISBinNo, "BinNo").Replace(WaferConst.DDAGrade, "Grade").ToUpper().Replace("SLOTNUM = EVEN", "SLOTNUM % 2 = 0").Replace("SLOTNUM = ODD", "SLOTNUM % 2 = 1");
		}

        public string GetConditionStringWithoutFabId()
        {
            if (!_isFilter) return string.Empty;

            string strCondition = string.Empty;
            string strOrAnd = " OR ";

            ArrayList alCondition = (ArrayList)_conditionList.Clone();
            string SubCondition = String.Empty;

            if (alCondition.Count > 0)
            {
                if (!_isOrAnd)
                    strOrAnd = " AND ";

                for (int i = 0; i < alCondition.Count; i++)
                {
                    if (i == alCondition.Count - 1)
                        strCondition = strCondition + "(" + alCondition[i].ToString() + ")";
                    else
                        strCondition = strCondition + "(" + alCondition[i].ToString() + ")" + strOrAnd;
                }
            }

            return strCondition = strCondition.Replace("*", "%").Replace(WaferConst.SlotNoType, "SlotNum").Replace(WaferConst.TesterGrade, "TestGrade").Replace(WaferConst.IRISBinNo, "BinNo").Replace(WaferConst.DDAGrade, "Grade").ToUpper().Replace("SLOTNUM = EVEN", "SLOTNUM % 2 = 0").Replace("SLOTNUM = ODD", "SLOTNUM % 2 = 1");
        }
		#endregion

    }
}
