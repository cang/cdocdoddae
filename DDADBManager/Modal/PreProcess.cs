using System;

namespace DDADBManager.Modal
{
	/// <summary>
	/// Summary description for PreProcess.
	/// </summary>
	public class PreProcess
	{
		private		bool		_CopyInvalidFile = true;
		private		string		_CopyInvalidFilePath;

		private		bool		_CopyFile = true;
		private		string		_CopyFilePath;


		private		bool		_CopyUnknownProductFile = true;
		private		string		_CopyUnknownProductFilePath;

		private		bool		_CopyMissDiskSizeFile = true;
		private		string		_CopyMissDiskSizeFilePath;

		private		int			_MissClassMaxTime = 60;
		private		bool		_CopyMissClassFile = false;
		private		string		_CopyMissClassFilePath;


		public PreProcess()
		{
		}


		public bool		CopyInvalidFile
		{
			get
			{
				return _CopyInvalidFile;
			}
			set
			{
				_CopyInvalidFile = value;
			}
		}

		
		public string		CopyInvalidFilePath
		{
			get
			{
				return _CopyInvalidFilePath;
			}
			set
			{
				_CopyInvalidFilePath = value;
			}
		}

		public bool		CopyFile
		{
			get
			{
				return _CopyFile;
			}
			set
			{
				_CopyFile = value;
			}
		}

		public string		CopyFilePath
		{
			get
			{
				return _CopyFilePath;
			}
			set
			{
				_CopyFilePath = value;
			}
		}


		public bool		CopyUnknownProductFile
		{
			get
			{
				return _CopyUnknownProductFile;
			}
			set
			{
				_CopyUnknownProductFile = value;
			}
		}

		public string		CopyUnknownProductFilePath
		{
			get
			{
				return _CopyUnknownProductFilePath;
			}
			set
			{
				_CopyUnknownProductFilePath = value;
			}
		}

		public bool		CopyMissDiskSizeFile
		{
			get
			{
				return _CopyMissDiskSizeFile;
			}
			set
			{
				_CopyMissDiskSizeFile = value;
			}
		}

		public string		CopyMissDiskSizeFilePath
		{
			get
			{
				return _CopyMissDiskSizeFilePath;
			}
			set
			{
				_CopyMissDiskSizeFilePath = value;
			}
		}

		public int		MissClassMaxTime
		{
			get
			{
				return _MissClassMaxTime;
			}
			set
			{
				_MissClassMaxTime = value;
			}
		}

		public bool		CopyMissClassFile
		{
			get
			{
				return _CopyMissClassFile;
			}
			set
			{
				_CopyMissClassFile = value;
			}
		}

		public string		CopyMissClassFilePath
		{
			get
			{
				return _CopyMissClassFilePath;
			}
			set
			{
				_CopyMissClassFilePath = value;
			}
		}


		
		public string ValidateString
		{
			get
			{
				if( CopyFile  && !System.IO.Directory.Exists(CopyFilePath))
					return "Invalid Destination Folder Path";
				if( CopyInvalidFile  && !System.IO.Directory.Exists(CopyInvalidFilePath))
					return "Invalid Destination Invalid Folder Path";
				if( CopyUnknownProductFile  && !System.IO.Directory.Exists(CopyUnknownProductFilePath))
					return "Invalid Destination Truncated Folder Path";
				if( CopyMissDiskSizeFile  && !System.IO.Directory.Exists(CopyMissDiskSizeFilePath))
					return "Invalid Destination Unknown DiskSize Folder Path";
				if( CopyMissClassFile  && !System.IO.Directory.Exists(CopyMissClassFilePath))
					return "Invalid Destination Unknown Product Class Folder Path";

				return string.Empty;
			}
		}

	}
}
