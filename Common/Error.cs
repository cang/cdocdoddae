using System;

namespace SiGlaz.Common.DDA
{
	/// <summary>
	/// Summary description for Error.
	/// </summary>
	/// 
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class Error
	{
		private ErrorCode _code;
		public ErrorCode Code
		{
			get { return _code; }
			set { _code = value; }
		}

		private string _description;
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		public Error() : this(ErrorCode.OK, string.Empty)
		{
		}

		public Error(ErrorCode code, string description)
		{
			this._code = code;
			this._description = description;
		}

		public bool IsSuccess
		{
			get
			{
				return _code== ErrorCode.OK;
			}
		}

	}
}
