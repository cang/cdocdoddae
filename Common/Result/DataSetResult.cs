using System;
using System.Data;

namespace SiGlaz.Common.DDA.Result
{
	/// <summary>
	/// Summary description for DataSetResult.
	/// </summary>
	/// 
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class DataSetResult : Error
	{
		public DataSet	Result;
		public int		TotalRow;
		public DataSetResult():base()
		{
		}
		public DataSetResult(ErrorCode code, string description):base(code,description)
		{
		}
	}
}
