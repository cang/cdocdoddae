using System;

namespace SiGlaz.Common.DDA
{
	/// <summary>
	/// Summary description for Fab.
	/// </summary>
	/// 
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class Fab
	{
		private		string		_FabID;
		//private		string		_FabUUID;
		private		string		_Description;

		public string		FabID
		{
			get
			{
				return _FabID;
			}
			set
			{
				_FabID = value;
			}
		}

		public string		Description
		{
			get
			{
				return _Description;
			}
			set
			{
				_Description = value;
			}
		}

		public Fab()
		{
		}

		public Fab(string fabid,string fabdescription):this()
		{
			this.FabID = fabid;
			this.Description = fabdescription;
		}

	}
}
