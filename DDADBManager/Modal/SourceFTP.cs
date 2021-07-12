using System;

namespace DDADBManager.Modal
{
	/// <summary>
	/// Summary description for SourceFTP.
	/// </summary>
	public class SourceFTP : DataSource
	{
		private		string		_Server = string.Empty;
		private		int			_Port = 21;
		private		string		_Directory = string.Empty;
		private		string		_Username = string.Empty;
		private		string		_Password = string.Empty;

		public SourceFTP() : base()
		{
		}

		public string Server
		{
			get
			{
				return _Server;
			}
			set
			{
				_Server = value;
			}
		}

		public int Port
		{
			get
			{
				return _Port;
			}
			set
			{
				_Port = value;
			}
		}
		public string Directory
		{
			get
			{
				return _Directory;
			}
			set
			{
				_Directory = value;
			}
		}

		public string Username
		{
			get
			{
				return _Username;
			}
			set
			{
				_Username = value;
			}
		}
		public string Password
		{
			get
			{
				return _Password;
			}
			set
			{
				_Password = value;
			}
		}

	}
}
