using System;
using System.IO;
using System.Data;
using System.Collections;
using FlowControl;

//using FlowControl;
//using SiglazFTPClient;

namespace DDADBManager
{
	/// <summary>
	/// Summary description for FolderController.
	/// </summary>
	public class FolderController : IDisposable
	{
		public static int DELAY = 5000;

		//key = filepath, value = ListFile
		public static Hashtable	htListFileOfPath = new Hashtable();

		#region inner struct
		public class ListFile
		{
			public string[]		lsFile;
			public int			pos =0;
			public ArrayList	alRunningTaks  = new ArrayList();
			public ArrayList	alFinishTaks  = new ArrayList();

			public int Count
			{
				get
				{
					if(lsFile==null) return 0;
					return lsFile.Length;
				}
			}

			public void	MakeRun(int taksid)
			{
				if(!alRunningTaks.Contains(taksid))
					alRunningTaks.Add(taksid);
			}

			public void	MakeFinished(int taksid)
			{
				if(!alFinishTaks.Contains(taksid))
					alFinishTaks.Add(taksid);
			}

			public void CleanTaks()
			{
				alRunningTaks.Clear();
				alFinishTaks.Clear();
			}

			public bool	IsFinished()
			{
				return alRunningTaks.Count<=alFinishTaks.Count;
			}

		}
		#endregion inner struct

		#region Field
		public  int								TaskID = -1;
		private bool							_IsLocal = true;
		private string							_FolderPath = string.Empty;

		private IncomingFileController			_incomingFileController = null;
		private IncomingFileHistoryController	_incomingFileHistoryController = null;
		private FolderScan						 _FolderScan = null;

		private	string							_TempFolder = string.Empty;
		private bool							_deleteValid  = true;
		private bool							_deleteInvalid = true;

		private string							_server;
		private int								_port;
		private string							_userName;
		private string							_password;
		private string							_ftpDir;

		private bool							_SubFolder = false;

		private bool							_Abort;
		private bool							_RunOneTime;
		private bool							_Waiting;


		#endregion Field

		#region Event

		public event EventHandlerProcess OnProcessInvalid;
		public event EventHandlerProcess OnProcess;

		public event EventHandlerProcessInfor	OnProcessInfo;

		public event EventHandlerProcessError	OnError;

		public event EventHandlerCheckFormat	OnCheckFormat;
		public event EventHandler				OnAbort;
		public event EventHandler				OnStateChange;

		#endregion Event

		#region Constructor

		public FolderController(int taksid)
		{
			this.TaskID = taksid;
		}

		#endregion Constructor

		#region Private Method

		private void HandlerAbort()
		{
			if(OnAbort!=null)
				OnAbort("Stop Task",EventArgs.Empty);

			try
			{
				SiGlaz.Utility.FileUtils.DeleteDirectory(this.TempFolder);
			}
			catch
			{
			}
		}

			
		private void LaunchInternal()
		{
			this.Abort = false;
			this.Waiting = false;

			_incomingFileController = new IncomingFileController();
			_incomingFileHistoryController = new IncomingFileHistoryController(30);//30 min
			HandleProcessInfo("Init Folder Listening.");

			if(this.IsLocal)
				_FolderScan  = new FolderScan();
			else
				_FolderScan  =  new FolderScan(_server,_port,_userName,_password);

			bool delayIfNoProcessedFile=false;

			try
			{
				while(true)
				{
					if(this.Abort)
					{
						HandleProcessInfo("Stop Task");
						HandlerAbort();
						return;//Abort
					}


					HandleProcessInfo("Get List from Folder...");
					string listendir = this.CurrentPath.Trim();

					//Hard Code
					if(!this.IsLocal && listendir!=string.Empty && listendir[listendir.Length-1]!='/' )
						listendir = listendir + "/";

					ListFile lsfile = htListFileOfPath[this.CurrentPath] as ListFile;
					if(lsfile==null)
					{
						lsfile = new ListFile();
						htListFileOfPath[this.CurrentPath] = lsfile;
					}

					//Get list file
					lock(lsfile)
					{
						//load new list file
						if( (lsfile.Count<=0 || lsfile.pos >= lsfile.Count) && lsfile.IsFinished() ) 
						{
							lsfile.CleanTaks();
							lsfile.pos = 0;
							lsfile.lsFile = null;

							ArrayList filesonFTP = _FolderScan.GetListFiles(listendir,this.SubFolder);
							if(filesonFTP==null )
							{
								HandleProcessInfo(string.Format("Cannot get list files, the cause is cannot access to share path, retry later, sleep {0} seconds ...",DELAY/1000));
								System.Threading.Thread.Sleep(DELAY);

								//truong hop get list error
								object ex=null;
								string errorString="";
								_FolderScan.GetLastError(ref ex,ref errorString);
								if(ex!=null)// co error
									HandleError(ex,"[GetListFiles]"+errorString);
								continue;
							}


							HandleProcessInfo("Get List from Folder, total: " + filesonFTP.Count.ToString() + " files.");
							lsfile.lsFile = _incomingFileController.GetNonExistFileList((string[])filesonFTP.ToArray(typeof(string)));
							if(lsfile.lsFile!=null)
							{
								HandleProcessInfo("Get List from Folder, new: " + lsfile.Count.ToString() + " files.");
							}
							else
							{
								HandleProcessInfo("Get List from Folder, new: 0 file.");
							}

							if(lsfile.lsFile!=null && lsfile.Count>0)
							{
								if(this.Waiting)
									this.Waiting = false;
							}
							else
							{
								if(!this.Waiting)
									this.Waiting = true;

								delayIfNoProcessedFile=Processing(_TempFolder);
								PostProcessing();
								if(delayIfNoProcessedFile)
								{
									HandleProcessInfo(string.Format("No processed file, sleep {0} seconds ...",DELAY/1000));
									System.Threading.Thread.Sleep(DELAY);
								}
							}
						}
					}

					//scan file
					bool endfile = false;
					while(true)
					{
						string nextfile = string.Empty;

						lock(lsfile)
						{
							endfile = lsfile.pos >= lsfile.Count -1;

							if(lsfile.pos >= lsfile.Count)
							{
								if(!lsfile.IsFinished())
								{
									lsfile.MakeFinished(this.TaskID);
									if(lsfile.IsFinished())
										break;
									if(!this.Waiting)
										this.Waiting = true;

									HandleProcessInfo(string.Format("Waiting other taks process file, sleep {0} seconds ...",DELAY/1000));
									System.Threading.Thread.Sleep(DELAY);
								}
								break;
							}

							nextfile = lsfile.lsFile[lsfile.pos++];
							lsfile.MakeRun(this.TaskID);
						}

						if(this.Abort)
						{
							HandleProcessInfo("Stop Task");
							HandlerAbort();
							return;//Abort
						}

						string localFileName=Path.Combine(_TempFolder,Path.GetFileName(nextfile));
						string ftpFileName=nextfile;

						HandleProcessInfo("Downloading file " + ftpFileName + ".");

						bool result=false;
						SiGlaz.Utility.GlobalLock lockObj = new SiGlaz.Utility.GlobalLock(localFileName);
						try
						{
							if(lockObj.WaitOne(60*5))
								result= _FolderScan.DownloadFile(nextfile,localFileName);
						}
						finally
						{
							lockObj.Release();
						}

						if(result==true)
						{
							HandleProcessInfo("Download file " + ftpFileName + " sucessfully.");

							IncomingFile incomingFile=new IncomingFile();

							incomingFile.filename=ftpFileName;

							incomingFile.m_KLARFHeader=new KLARFHeaderData();													

							incomingFile.m_ProcessingInfo=new ProcessingInfo();

							FileSystemAttributes fileSystemAttributes=new FileSystemAttributes();

							FileInfo fileInfo=new FileInfo(localFileName);

							fileSystemAttributes.incomingTime=DateTime.Now;
							fileSystemAttributes.createdTime=fileInfo.CreationTime;

							incomingFile.m_FileSystemAttributes=fileSystemAttributes;

							HandleProcessInfo("Checking format file " + ftpFileName + ".");

							if(HandleCheckFormat(localFileName)==true)
							{
								HandleProcessInfo(ftpFileName + " is valid format.");
								_incomingFileController.AddIncomingFile(incomingFile);
								_incomingFileHistoryController.Remove(ftpFileName);
							}
							else
							{
								if( _incomingFileHistoryController.IsStable(ftpFileName,DateTime.Now,fileInfo.Length)==true)
								{
									HandleProcessInfo(ftpFileName + " is in invalid format.");
									incomingFile.m_ProcessingInfo.isDelete=_deleteInvalid;
									incomingFile.m_ProcessingInfo.isProcessed=true;
									_incomingFileController.AddIncomingFile(incomingFile);//mark skip de lan sau kg down nua
									HandleProcessInvalidFile(localFileName);
								}
								else
								{
									HandleProcessInfo(ftpFileName + " is in incomplete format.");
								}

								lockObj = new SiGlaz.Utility.GlobalLock(localFileName);
								try
								{
									if(lockObj.WaitOne(60*5))
										SiGlaz.Utility.FileUtils.DeleteFile(localFileName);
								}
								catch(Exception ex)
								{
									HandleError(ex, "[DELETE]" + ex.Message);
								} 
								finally
								{
									lockObj.Release();
								}
							}
						}
						else// truong hop download error
						{
							object ex=null;
							string errorString="";
							_FolderScan.GetLastError(ref ex,ref errorString);

							if(ex==null)//file not exists , break and return get list files
							{
								HandleProcessInfo("[NOFILE] " + string.Format("{0} : {1}",nextfile,errorString));
								HandleError(ex,string.Format("[NOFILE] : {0}",nextfile));
								break;
							}
							else
							{
								HandleProcessInfo(string.Format("Cannot download file, the cause is this file was written by other system or cannot access to share path, retry later, sleep {0} seconds ...",DELAY/1000));
								System.Threading.Thread.Sleep(DELAY);
								HandleError(ex,"[DOWNLOADERROR]" + errorString);
							}
						}

						delayIfNoProcessedFile=Processing(_TempFolder);

						if(this.Abort)
						{
							HandleProcessInfo("Stop Task");
							HandlerAbort();
							return;//Abort
						}

						PostProcessing();

						if(delayIfNoProcessedFile && endfile)//Neu thang cuoi cung la invalid thi cho nghi 5 s
						{
							HandleProcessInfo(string.Format("No processed file, sleep {0} seconds ...",DELAY/1000));
							System.Threading.Thread.Sleep(DELAY);
						}

						if(this.Abort)
						{
							HandleProcessInfo("Stop Task");
							HandlerAbort();
							return;//Abort
						}
					}
	
					if(this.RunOneTime)
					{
						HandleProcessInfo("Finihed - Run One Time");
						return;
					}
				}//end loop forever
			}
			catch(System.Threading.ThreadInterruptedException)
			{
			}
			catch
			{
				throw;
			}
		}


		private void HandleProcessInfo(string infoString)
		{
			if(OnProcessInfo!=null)
			{
				OnProcessInfo(0,infoString,EventArgs.Empty);
			}
		}

		private void HandleError(object ex,string errorString)
		{
			if(OnError!=null)
			{
				FileControllerErrorEventArgs e = new FileControllerErrorEventArgs(ex,errorString);
				OnError(0,errorString,e);
			}
		}

		private void HandleProcessInvalidFile(string fileName)
		{
			if(OnProcessInvalid!=null)
			{
				ProcessEventArgs e = new ProcessEventArgs(fileName);
				OnProcessInvalid(0,fileName,e);
				if(e.Abort)
					this.Abort = true;
			}
		}

		private void HandleProcessFile(string fileName)
		{
			if(OnProcess!=null)
			{
				ProcessEventArgs e = new ProcessEventArgs(fileName);
				OnProcess(0,fileName,e);
				if(e.Abort)
					this.Abort = true;
			}
			else
				throw new Exception("Please implement HandleProcessFile event");
		}

		private bool HandleCheckFormat(string filepath)
		{
			CheckFormatEventArgs  arg = new CheckFormatEventArgs(filepath);
			if(OnCheckFormat!=null)
			{
				OnCheckFormat(0,filepath,arg);
				if( arg.IsValid)
					return true;
				else
					return false;
			}
			else
				throw new Exception("Please handle OnCheckFormat event");
		}

		private void PostProcessing()
		{
			#region PostProcessing
			if(_deleteInvalid || _deleteValid)
			{
				IncomingFile[] deleteIncomingFiles = _incomingFileController.GetDeletedFileList();
				if(deleteIncomingFiles!=null && deleteIncomingFiles.Length>0)
				{
					foreach(IncomingFile deleteIncomingFile in deleteIncomingFiles)
					{
						HandleProcessInfo("Delete file " + deleteIncomingFile.filename + ".");
						if(_FolderScan.DeleteFile(deleteIncomingFile.filename)==true)
						{
							_incomingFileController.RemoveIncomingFile(deleteIncomingFile);
						}
						else
						{// truong hop delete error
							object ex=null;
							string errorString="";
							_FolderScan.GetLastError(ref ex,ref errorString);
							HandleError(ex,"[PostProcessing]" + errorString);
							break;// neu delete 1 file nao do bi fail thi ngung lai de lan sau delete tiep
						}
					}
				}
			}
			#endregion
		}

		private bool Processing(string _TempFolder)
		{
			#region ProcessFile				
			IncomingFile availableIncomingFile= _incomingFileController.GetNextFileForSingleProcessing();   //((IncomingFile)availableIncomingFiles[0]);
			if(availableIncomingFile!=null)
			{
				string availableFile=Path.Combine(_TempFolder,Path.GetFileName(availableIncomingFile.filename));
				HandleProcessInfo("Process file " + availableIncomingFile.filename +".");
				HandleProcessFile(availableFile);

				if(this.Abort)
					return false;

				//System.Diagnostics.Debug.WriteLine("After Process : " + availableFile );
				_incomingFileController.UpdateFileStatus(availableIncomingFile,true,_deleteValid);

				SiGlaz.Utility.GlobalLock lockObj = new SiGlaz.Utility.GlobalLock(availableFile);
				try
				{
					if( lockObj.WaitOne(60*5))
						SiGlaz.Utility.FileUtils.DeleteFile(availableFile);
				}
				catch(Exception ex)
				{
					HandleError(ex,"[AfterProcessing]"+ex.Message);
				}
				finally
				{
					lockObj.Release();
				}

				return false;
			}
			else
			{
				return true;// khong lam gi => delay thoi gian thao tac voi FTP
			}
			#endregion
		}


		#endregion Private Method

		#region Properties

		public bool								Waiting
		{
			get
			{
				return _Waiting;
			}
			set
			{
				bool old = _Waiting;
				_Waiting = value;
				if( _Waiting != old )
				{
					if( OnStateChange!=null)
						OnStateChange(null,EventArgs.Empty);
				}
			}
		}

		public bool								RunOneTime
		{
			get
			{
				return _RunOneTime;
			}
			set
			{
				_RunOneTime = value;
			}
		}

		public bool								Abort
		{
			get
			{
				return _Abort;
			}
			set
			{
				if(value)
					HandleProcessInfo("wait to stop process");
				_Abort = value;
			}
		}

		public bool								SubFolder
		{
			get
			{
				return _SubFolder;
			}
//			set// chua hoat dong duoc
//			{
//				_SubFolder = value;
//			}
		}
		
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

		public string							FolderPath
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


		public bool								deleteValid
		{
			get
			{
				return _deleteValid;
			}
			set
			{
				_deleteValid = value;
			}
		}

		public bool								deleteInvalid
		{
			get
			{
				return _deleteInvalid;
			}
			set
			{
				_deleteInvalid = value;
			}
		}

		public string							TempFolder
		{
			get
			{
				return _TempFolder;
			}
			set
			{
				_TempFolder = value;
			}
		}

		public string							Server
		{
			get
			{
				return _server;
			}
			set
			{
				_server = value;
			}
		}
		public int							Port
		{
			get
			{
				return _port;
			}
			set
			{
				_port = value;
			}
		}
		public string							UserName
		{
			get
			{
				return _userName;
			}
			set
			{
				_userName = value;
			}
		}
		public string							Password
		{
			get
			{
				return _password;
			}
			set
			{
				_password = value;
			}
		}
		public string							ftpDir
		{
			get
			{
				return _ftpDir;
			}
			set
			{
				_ftpDir = value;
			}
		}

		private string CurrentPath
		{
			get
			{
				if(this.IsLocal)
					return this.FolderPath;
				else
					return this.ftpDir;
			}
		}

		#endregion Properties
		
		System.Threading.Thread th = null;
		public void Launch()
		{
//			//Clear 
//			string []lskey = new string[htTaksOfFile.Keys.Count];
//			htTaksOfFile.Keys.CopyTo(lskey,0);
//			foreach(string key in lskey)
//			{
//				if((int)htTaksOfFile[key]==TaskID)
//					htTaksOfFile.Remove(key);
//			}

			//Start
			th = new System.Threading.Thread( new System.Threading.ThreadStart(LaunchInternal));
			//th.IsBackground = true;//make sure when foreground exit then it exit too
			th.Start();
		}

		public void ForceAbort()
		{
			//th.Join(100);
			if( th!=null && th.ThreadState ==  System.Threading.ThreadState.WaitSleepJoin)
			{
				th.Interrupt();
				th = null;

				HandleProcessInfo("Stop Task");
				HandlerAbort();
			}
			
		}

		#region IDisposable Members

		~FolderController()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
			Dispose(true);
		}

		private void Dispose( bool disposing )
		{
			// Only clean up managed resources if being called from IDisposable.Dispose
			//if( disposing )

			// always clean up unmanaged resources
			try
			{
				SiGlaz.Utility.FileUtils.DeleteDirectory(this.TempFolder);
			}
			catch//skip error hehe
			{
			}
		}

		#endregion
	}

	#region Inner struct

	public class ProcessEventArgs : EventArgs
	{
		public	bool	Abort;
		public	string	Filepath;
		public ProcessEventArgs(string filepath)
		{
			this.Filepath = filepath;
		}
	}


	public class CheckFormatEventArgs : EventArgs
	{
		public	bool IsValid;
		public	string Filepath;
		public CheckFormatEventArgs(string filepath)
		{
			this.Filepath = filepath;
		}
	}

	public class FileControllerErrorEventArgs : EventArgs
	{
		public	object obj;
		public	string msg;
		public  FileControllerErrorEventArgs(object obj,string msg)
		{
			this.obj = obj;
			this.msg = msg;
		}
	}

	public delegate void EventHandlerProcess(int id,string filepath,ProcessEventArgs e);
	public delegate void EventHandlerProcessInfor(int id,string description,EventArgs e);
	public delegate void EventHandlerProcessError(int id,string msg,FileControllerErrorEventArgs e);
	public delegate void EventHandlerCheckFormat(int id,string filepath,CheckFormatEventArgs e);


	#endregion Inner struct

}
