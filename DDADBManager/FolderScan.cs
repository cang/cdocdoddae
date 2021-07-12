using System;
using System.Collections;
using System.IO;

namespace DDADBManager
{
	/// <summary>
	/// Summary description for FolderScan.
	/// </summary>
	public class FolderScan : SiglazFTPClient.SiglazFTPClient
	{
		private bool							_IsLocal = true;

		private object							_LastErrorObject;
		private string							_LastErrorString;

		public FolderScan(): base()
		{
			this.IsLocal = true;
		}
		public FolderScan(string server,int port,string username,string password)
			: base(server,port,username,password)
		{
			this.IsLocal = false;
		}

		public new bool DeleteFile(string filepath)
		{
			if(IsLocal)
			{
				try
				{
					SiGlaz.Utility.FileUtils.DeleteFile(filepath);
					return true;
				}
				catch(Exception ex)
				{
					this._LastErrorObject = ex;
					this._LastErrorString = ex.Message;
					return false;
				}
			}
			else
				return base.DeleteFile(filepath);
		}

		public new void GetLastError(ref object lastErrorObject, ref string lastErrorString)
		{
			if(IsLocal)
			{
				lastErrorObject = this._LastErrorObject;
				lastErrorString = this._LastErrorString;
			}
			else
				base.GetLastError(ref lastErrorObject,ref lastErrorString);
		}

		
		public new ArrayList GetListFiles(string remotedir, bool subFolder)
		{
			if(IsLocal)
			{
				try
				{
					if( !Directory.Exists(remotedir) )
						return new ArrayList(1);

					ArrayList alResult  = new ArrayList();
					if(subFolder)
					{
						string []lsfolder = Directory.GetDirectories(remotedir);
						foreach(string dirpath in lsfolder)
						{
							alResult.AddRange(GetListFiles(dirpath,subFolder));
						}
					}
					string []lsfile = Directory.GetFiles(remotedir);
					alResult.AddRange(lsfile);
					return alResult;
				}
				catch(Exception ex)
				{
					this._LastErrorObject = ex;
					this._LastErrorString = ex.Message;
					return null;
				}
			}
			else
				return base.GetListFiles(remotedir,subFolder);
		}

		public new bool DownloadFile(string fileName, string temporaryFilename)
		{
			if(IsLocal)
			{
				try
				{
					if(!File.Exists(fileName))
					{
						this._LastErrorObject = null;
						this._LastErrorString = "File not exists or cannot access to file path";
						return false;
					}
					else
						SiGlaz.Utility.FileUtils.CopyFile(fileName,temporaryFilename);

					return true;
				}
				catch(Exception ex)
				{
					this._LastErrorObject = ex;
					this._LastErrorString = ex.Message;
					return false;
				}
			}
			else
				return base.DownloadFile(fileName,temporaryFilename);
			
		}



		#region Properties
		
		public bool								IsLocal
		{
			get
			{
				return _IsLocal;
			}
			set
			{
				_IsLocal = value;
			}
		}

		#endregion Properties
	}
}
