using System;

namespace SiGlaz.Common.DDA.Result
{
	/// <summary>
	/// Summary description for StringResult.
	/// </summary>
	/// 
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class StringResult : Error
	{
		public string Result;
		public StringResult():base()
		{
		}
		public StringResult(ErrorCode code, string description):base(code,description)
		{
		}
	}
}
