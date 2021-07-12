using System;

namespace SiGlaz.Common.DDA.Result
{
	/// <summary>
	/// Summary description for BinaryResult.
	/// </summary>
	/// 
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class BinaryResult : Error
	{
		public byte	[]Result;
		public BinaryResult():base()
		{
		}
		public BinaryResult(ErrorCode code, string description):base(code,description)
		{
		}
	}
}
