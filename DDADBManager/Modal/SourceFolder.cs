using System;
using System.Xml;
using System.Xml.Serialization;

namespace DDADBManager.Modal
{
	/// <summary>
	/// Summary description for SourceFolder.
	/// </summary>
	/// 
	public class SourceFolder : DataSource
	{
		private	string	_FolderPath = string.Empty;

		public SourceFolder():base()
		{
		}

		public string FolderPath
		{
			get
			{
				return _FolderPath;
			}
			set
			{
				_FolderPath = value;
			}
		}
	}
}
