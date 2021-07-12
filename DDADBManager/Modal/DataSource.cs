using System;
using System.Xml;
using System.Xml.Serialization;

namespace DDADBManager.Modal
{
	/// <summary>
	/// Summary description for DataSource.
	/// </summary>
	/// 
	[XmlInclude(typeof(SourceFolder))]
	[XmlInclude(typeof(SourceFTP))]
	public class DataSource
	{
		private		bool		_DeleteAfterProcess = true;
		private		bool		_DeleteInvalidFile = true;

		public DataSource()
		{
		}

		public bool	DeleteAfterProcess
		{
			get
			{
				return _DeleteAfterProcess;
			}
			set
			{
				_DeleteAfterProcess = value;
			}
		}

		public bool	DeleteInvalidFile
		{
			get
			{
				return _DeleteInvalidFile;
			}
			set
			{
				_DeleteInvalidFile = value;
			}
		}


	}
}
