using System;

namespace DDADBManager.Modal
{
	/// <summary>
	/// Summary description for PostProcess.
	/// </summary>
	public class PostProcess
	{
		private		bool		_CopyProcessFailedFile = true;
		private		string		_CopyProcessFailedFilePath;
		private		int			_MaxTimesRetry = 60;//60 minutes

		public PostProcess()
		{
		}

		public bool		CopyProcessFailedFile
		{
			get
			{
				return _CopyProcessFailedFile;
			}
			set
			{
				_CopyProcessFailedFile = value;
			}
		}

		public string		CopyProcessFailedFilePath
		{
			get
			{
				return _CopyProcessFailedFilePath;
			}
			set
			{
				_CopyProcessFailedFilePath = value;
			}
		}

		public int		MaxTimesRetry
		{
			get
			{
				return _MaxTimesRetry;
			}
			set
			{
				_MaxTimesRetry = value;
			}
		}

		public string ValidateString
		{
			get
			{
				if( CopyProcessFailedFile && !System.IO.Directory.Exists(CopyProcessFailedFilePath))
					return "Invalid Destination Unhandle Folder Path";
				return string.Empty;
			}
		}

	}
}
