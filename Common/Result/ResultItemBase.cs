using System;
using System.Data;
using SiGlaz.Common.DDA.Const;

namespace SiGlaz.Common.DDA.Result
{
	/// <summary>
	/// Summary description for ResultItemBase.
	/// </summary>
	/// 
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class ResultItemBase
	{
		public	DataRow	row;

		public virtual string this[string fieldname]
		{
			get
			{
				if( fieldname == null || fieldname == string.Empty) 
					return string.Empty;

				if (fieldname.ToUpper() == WaferConst.SlotNoType.ToUpper())
					fieldname = "SlotNum";
				else if (fieldname.ToUpper() == WaferConst.TesterGrade.ToUpper())
					fieldname = "TestGrade";
				else if (fieldname.ToUpper() == WaferConst.IRISBinNo.ToUpper())
					fieldname = "BinNo";
				else if (fieldname.ToUpper() == WaferConst.DDAGrade.ToUpper())
					fieldname = "Grade";

				if(row[fieldname]!= DBNull.Value)
					return row[fieldname].ToString();
				else
					return string.Empty;
			}
		}

		public ResultItemBase()
		{
		}

		public ResultItemBase(DataRow	row)
		{
			this.row = row;
		}
	}
}
