using System;

namespace SiGlaz.Common.DDA.Result
{
	/// <summary>
	/// Summary description for ResultBase.
	/// </summary>
	/// 
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class ResultBase : Error
	{
		public	long			id64;
		public	int				id32;
		public	short			id16;
		public  string			idstring = string.Empty;

		public ResultBase()
		{
		}

		public ResultBase(ErrorCode code, string description):base(code,description)
		{
		}
	}
}
