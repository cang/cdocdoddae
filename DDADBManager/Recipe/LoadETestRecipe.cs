//#define SAVE_ALLFILE

using System;
using System.Collections;
using System.Drawing;
using System.IO;

//using SiGlaz.DDA.Engine;



namespace DDADBManager.Process
{
	/// <summary>
	/// Summary description for LoadETestProcess.
	/// </summary>
	public class LoadETestProcess : ProcessBase
	{
		private Modal.DataSource		_DataSource = null;
		private Modal.PreProcess		_PreProcess = null;
		private Modal.PostProcess		_PostProcess = null;
		private SiGlaz.Common.DDA.Fab	_Fab = null;
		private string					_CurrentFilePath = string.Empty;
		private FolderController		fc = null;

		//private int						_MaxLayerOfLot = 25;
		//private int						_NextLayerOnLotTimeOuts = 1;//one minutes
		//private System.Timers.Timer		_Timer = null;
		//private Hashtable				_LotTimeOuts = null;
		//private const int				 TIMER_SECOND = 1000;//One second

		#region Properties

		public Modal.DataSource	DataSource
		{
			get
			{
				return _DataSource;
			}
			set
			{
				_DataSource = value;
			}
		}


		public Modal.PreProcess	PreProcess
		{
			get
			{
				return _PreProcess;
			}
			set
			{
				_PreProcess = value;
			}
		}

		public Modal.PostProcess	PostProcess
		{
			get
			{
				return _PostProcess;
			}
			set
			{
				_PostProcess = value;
			}
		}

		public SiGlaz.Common.DDA.Fab	Fab
		{
			get
			{
				return _Fab;
			}
			set
			{
				_Fab = value;
			}
		}

//		public int MaxLayerOfLot
//		{
//			get
//			{
//				return _MaxLayerOfLot;
//			}
//			set
//			{
//				_MaxLayerOfLot = value;
//			}
//		}

		
//		public int NextLayerOnLotTimeOuts
//		{
//			get
//			{
//				return _NextLayerOnLotTimeOuts;
//			}
//			set
//			{
//				_NextLayerOnLotTimeOuts = value;
//			}
//		}

		#endregion Properties



		public LoadETestProcess() : base()
		{
			this.Name = "Load ETest";
		}

		public override void InitProcess()
		{
			base.InitProcess();

			if( fc!=null) return;
			fc = new FolderController(this.ID);

			fc.deleteValid = true;//this._DataSource.DeleteAfterProcess;
			fc.deleteInvalid = true;//this._DataSource.DeleteInvalidFile;

			fc.OnCheckFormat+=new EventHandlerCheckFormat(fc_OnCheckFormat);
			fc.OnError+=new EventHandlerProcessError(fc_OnError);
			fc.OnProcess+=new EventHandlerProcess(fc_OnProcess);
			fc.OnProcessInvalid+=new EventHandlerProcess(fc_OnProcessInvalid);
			fc.OnProcessInfo+=new EventHandlerProcessInfor(fc_OnProcessInfo);
			fc.OnAbort+=new EventHandler(fc_OnAbort);
			fc.OnStateChange+=new EventHandler(fc_OnStateChange);
		}
		
		public override void Execute()
		{
			if(ValidateString!=string.Empty)
			{
				this.OutputHistory.AddNewLine(this.ID,ValidateString + ", please setup PreProcess");
				return;
			}

			//this.IsRunning = true;
			base.Execute ();

			string IncomTempFolder = "TmpImComeFiles\\Task" + this.ID + "_" + DateTime.Now.Ticks.ToString();
			IncomTempFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,IncomTempFolder);
			fc.TempFolder = IncomTempFolder;

			FolderController.DELAY = SiGlaz.Common.DDA.AppData.Data.ListenWaitingSecondFolder*1000;//new

			if( this._DataSource is Modal.SourceFolder)
			{
				fc.IsLocal = true;
				fc.FolderPath = (this._DataSource as Modal.SourceFolder).FolderPath;
			}
			else
			{
				fc.IsLocal = false;
				fc.Server = (this._DataSource as Modal.SourceFTP).Server;
				fc.Port = (this._DataSource as Modal.SourceFTP).Port;
				fc.UserName = (this._DataSource as Modal.SourceFTP).Username;
				fc.Password = (this._DataSource as Modal.SourceFTP).Password;
				fc.ftpDir = (this._DataSource as Modal.SourceFTP).Directory;
			}

			//StartTimeout();
			fc.Launch();
		}


		private void Try2Copy(string source, string des)
		{
			int timetrying = 0;
			while(true && !fc.Abort)
			{
				try
				{
					SiGlaz.Utility.FileUtils.CopyFile(source,des);
					break;
				}
				catch(Exception ex)
				{
					timetrying++;

					if(timetrying >= _PostProcess.MaxTimesRetry)
					{
						this.OutputHistory.AddNewLine(this.ID,string.Format("Cannot copy file to {1} after {0} retry times",_PostProcess.MaxTimesRetry, Path.GetDirectoryName(des) ));
						break;
					}

					this.OutputHistory.AddNewLine(this.ID, string.Format("Cannot copy file to {1} , retry after {0} seconds",SiGlaz.Common.DDA.AppData.Data.WaitingToRetryError,Path.GetDirectoryName(des)));
					WriteTrace("ERROR Copy FIle : " + ex.ToString());

					System.Threading.Thread.Sleep(SiGlaz.Common.DDA.AppData.Data.WaitingToRetryError*1000);
				}
			}
		}


		private void CannotProcess(string filepath)
		{
			try
			{
				if(_PostProcess.CopyProcessFailedFile)
				{
					string path = _PostProcess.CopyProcessFailedFilePath;

					path = Path.Combine(path,Path.GetFileName(filepath));

					Try2Copy(filepath,path);
				}
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
		}

		private void MissProduct(string filepath)
		{
			try
			{
				if(_PreProcess.CopyUnknownProductFile)
				{
					string path = _PreProcess.CopyUnknownProductFilePath;

					path = Path.Combine(path,Path.GetFileName(filepath));

					Try2Copy(filepath,path);
				}
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
		}

		private void TruncateProcess(string filepath,System.Text.StringBuilder sbData)
		{
			try
			{
				if(_PreProcess.CopyUnknownProductFile && sbData!=null)
				{
					string path = _PreProcess.CopyUnknownProductFilePath;

					path = Path.Combine(path,Path.GetFileName(filepath));

					SiGlaz.Common.StringBuilderSerialize.Serialize(path,sbData);			
				}
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
		}

		private void MissDiskSize(string filepath,string product,string productClass)
		{
			try
			{
				if(_PreProcess.CopyMissDiskSizeFile)
				{
					string path = _PreProcess.CopyMissDiskSizeFilePath;

					if(productClass.Trim()!=string.Empty)
						path = Path.Combine(path,productClass.Trim());

					if(product.Trim()!=string.Empty)
						path = Path.Combine(path,product.Trim());

					path = Path.Combine(path,Path.GetFileName(filepath));

					Try2Copy(filepath,path);
				}
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
		}

		private void MissProductClass(string filepath,string product)
		{
			try
			{
				if(_PreProcess.CopyMissClassFile)
				{
					string path = _PreProcess.CopyMissClassFilePath;

					if(product.Trim()!=string.Empty)
						path = Path.Combine(path,product.Trim());

					path = Path.Combine(path,Path.GetFileName(filepath));

					Try2Copy(filepath,path);
				}
			}
			catch(Exception ex)
			{
				SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
			}
		}


		public override void Property()
		{
			if(this.IsRunning)
				return;
		}

		private void fc_OnCheckFormat(int id,string filepath, CheckFormatEventArgs e)
		{
			SiGlaz.Utility.GlobalLock lockObj = new SiGlaz.Utility.GlobalLock(filepath);
			try
			{
				if(!lockObj.WaitOne(60*5))
					e.IsValid = false;
				else
					e.IsValid =  SSA.SystemFrameworks.FrameworksDCDM.IsValidFormat(filepath);
			}
			catch
			{
				e.IsValid = false;
			}
			finally
			{
				lockObj.Release();
			}
		}

		private void fc_OnError(int id,string msg, FileControllerErrorEventArgs e)
		{
			HandlerProcessError(msg,e);

			string tracelog = string.Format("ERROR LISTERING :{0}",msg);
			
			if(e.obj!=null)
			{
				tracelog += string.Format("\n\t- StackTrace {0}",(e.obj as Exception).StackTrace);
			}
				
			WriteTrace(tracelog);
		}

		private bool CheckProduct(string filepath,string productname)
		{
			try
			{
				if(SiGlaz.Common.DDA.AppData.Data.UseWebService)
				{
					WebServiceProxy.CategoryProxy.Category proxy = WebServiceProxy.WebProxyFactory.CreateCategory();
					return proxy.ProductDiskSizeExist(productname);
				}
				else
				{
					SiGlaz.DDA.Business.Category proxy = new SiGlaz.DDA.Business.Category();
					return proxy.ProductDiskSizeExist(productname);
				}
			}
			catch
			{
				return false;
			}
		}

		private bool AddProduct(string filepath,string productname)
		{
			SiGlaz.Common.DDA.ProductDiskSize productitem = null;
			int timetrying = 0;

			while(true && !fc.Abort)
			{
				try
				{
					if(SiGlaz.Common.DDA.AppData.Data.UseWebService)
					{
						WebServiceProxy.CategoryProxy.Category proxy = WebServiceProxy.WebProxyFactory.CreateCategory();
						WebServiceProxy.CategoryProxy.ProductDiskSize result = proxy.GetProductDiskSize(productname);
						productitem = WebServiceProxy.ConvertProxy.Convert(result,typeof(SiGlaz.Common.DDA.ProductDiskSize)) as SiGlaz.Common.DDA.ProductDiskSize;
						break;
					}
					else
					{
						SiGlaz.DDA.Business.Category proxy = new SiGlaz.DDA.Business.Category();
						productitem = proxy.GetProductDiskSize(productname);
						break;
					}
				}
				catch(Exception ex)
				{
					timetrying++;

					if(timetrying >= _PostProcess.MaxTimesRetry)
					{
						CannotProcess(filepath);
						this.OutputHistory.AddNewLine(this.ID,string.Format("Cannot connect to database server after {0} retry times",_PostProcess.MaxTimesRetry));
						break;
					}

					this.OutputHistory.AddNewLine(this.ID, string.Format("Cannot connect to database server, retry after {0} seconds",SiGlaz.Common.DDA.AppData.Data.WaitingToRetryError));
					WriteTrace("ERROR AddProduct : " + ex.ToString());

					System.Threading.Thread.Sleep(SiGlaz.Common.DDA.AppData.Data.WaitingToRetryError*1000);
				}
			}

			if(productitem==null)
				return false;
			else
			{
				DDARecipe.DDAExternalData.ProductConfiguration.Data.Add(new FPPCommon.ProductItem(productitem.ProductCode,(float)productitem.InnerDiameter,(float)productitem.OuterDiameter));
				return true;
			}
				
		}


		bool reloadfile = false;
		private ArrayList LoadFile(string filepath,out System.Text.StringBuilder sbTruncatePart)
		{
			sbTruncatePart = null;
			if( fc.Abort) return null;

			SiGlaz.Utility.GlobalLock lockObj = new SiGlaz.Utility.GlobalLock(filepath);
			try
			{
				if(lockObj.WaitOne(60*5))
				{
					//DDARecipe.DDAExternalData.RefreshDiskType();//Refresh DiskType from database
					return SSA.SystemFrameworks.FrameworksDCDM.OpenFiles(filepath,out sbTruncatePart);
				}
				return null;
			}
			catch(SSA.SystemFrameworks.MissProductException)
			{
				MissProduct(filepath);
				this.OutputHistory.AddNewLine(this.ID,string.Format("Unknown PRODUCT in file {0}", Path.GetFileName(filepath) ));
				return null;
			}
			catch(SSA.SystemFrameworks.MissDiskSizeException ex)
			{
				if(lockObj!=null)
				{
					lockObj.Release();
					lockObj = null;
				}

				if(reloadfile)
					return null;

				//Cannot found product , check in database
				//retry forever
				int retrycount=0;
				bool hasproduct = false;
				while(true && !fc.Abort)
				{
					if(fc.Abort)
						return null;

					hasproduct = CheckProduct(filepath,ex.Product);
					if(hasproduct)
						break;

					this.OutputHistory.AddNewLine(this.ID, string.Format("Cannot found Product Class of Product Code {0}, retry after {1} seconds",ex.Product,SiGlaz.Common.DDA.AppData.Data.WaitingToMoreInformation));
					System.Threading.Thread.Sleep(SiGlaz.Common.DDA.AppData.Data.WaitingToMoreInformation*1000);
					retrycount++;

					if(PreProcess.CopyMissClassFile && PreProcess.MissClassMaxTime<=retrycount)
					{
						MissProductClass(filepath,ex.Product);
						break;
					}
				}

				if(hasproduct)
				{
					if(AddProduct(filepath,ex.Product))
					{
						reloadfile = true;
						return LoadFile(filepath,out sbTruncatePart);
					}
					else
					{
						string productClass = string.Empty;
						try
						{
							WebServiceProxy.CategoryCmd cmd = new WebServiceProxy.CategoryCmd();
							productClass = cmd.ProductGetProductClass(ex.Product);
						}
						catch
						{
						}

						MissDiskSize(filepath,ex.Product,productClass);
						this.OutputHistory.AddNewLine(this.ID,string.Format("Unknown Disk Size of Product Class '{0}' of Product Code '{1}' in file '{2}', please setup them first",productClass,ex.Product ,Path.GetFileName(filepath) ));
					}
				}

				return null;
			}
			catch
			{
				throw;
			}
			finally
			{
				reloadfile = false;
				if(lockObj!=null)
				{
					lockObj.Release();
					lockObj = null;
				}
			}
		}

		private int timetrying =0;
        private void fc_OnProcess(int id,string filepath, ProcessEventArgs e)
		{
			HandlerBeginProcess(filepath,e);

			if(this.OutputHistory!=null)
			{
				this.OutputHistory.AddNewLine(this.ID, string.Format("Begin process file {0}", Path.GetFileName(filepath) ));
			}

			_CurrentFilePath = filepath;

			try
			{
				this.DoPreProcess();
			}
			catch(Exception ex)
			{
				this.OutputHistory.AddNewLine(this.ID,"ERROR PreProcess file :" + Path.GetFileName(filepath) );


				string tracelog = "ERROR Process file : " + Path.GetFileName(filepath) + " \n\t+MESSAGE "
					+ ex.Message + " \n\t+StackTrace "
					+ ex.StackTrace;

				WriteTrace(tracelog);

				//this.Stop();
			}

			#region Processing Here

			HandlerProcess(filepath,e);

			//Process
			this.OutputHistory.AddNewLine(this.ID,"Load file");
			try
			{
				
				System.Text.StringBuilder sbTruncatePart=null;
				ArrayList alKlarf = LoadFile(filepath,out sbTruncatePart);

				//Process truncated part
				TruncateProcess(filepath,sbTruncatePart);
				sbTruncatePart = null;

				if(fc.Abort) return;
				if(alKlarf!=null)
				{
					//AddLot(dat.LotNum,dat.Wafers.Count);
					foreach(SSA.SystemFrameworks.KlarfParserFile klarf in alKlarf)
					{
						if(fc.Abort) return;

						this.OutputHistory.AddNewLine(this.ID,"Process Surface :" + klarf.DiskInformation.Surface.ToString() + " of Disk " + klarf.sSerialNumber);

						SiGlaz.DAL.SURFFormat.SUDRFParser surf = klarf.KlarfToSUBF();

						SiGlaz.Common.DDA.Disk disk = new SiGlaz.Common.DDA.Disk();
						SiGlaz.Common.DDA.Surface  surface = new SiGlaz.Common.DDA.Surface();
						SiGlaz.DDA.Business.BDConvert.ConvertSURFToCommonStruct(surf,disk,surface);
						disk.FileName = Path.GetFileName(filepath);


#if(SAVE_ALLFILE)

						byte[] lpbyte = surf.Write();
						//lpbyte = null;
						surface.RawData = SiGlaz.Utility.Compression.Compressor.Compress(lpbyte);
#endif

						klarf.TranPolarFromOrigin();
						SSA.SystemFrameworks.KlarfFileView view=new SSA.SystemFrameworks.KlarfFileView(klarf);
						view.ViewMode = SSA.SystemFrameworks.MRSProcessingType.DiscMode;
						Bitmap bmp=view.Export2Image(new Size(100,100));
						surface.SourceThumbnail = SiGlaz.Utility.DBConvert.Bitmap2Byte(bmp);
						bmp.Dispose();

						klarf.TranCartesianFromOrigin(SSA.SystemFrameworks.InMemmoryData.mrsShiftAngle,1f);//InMemmoryData.mrsShiftAngle allway is zero
						view=new SSA.SystemFrameworks.KlarfFileView(klarf);
						view.ViewMode = SSA.SystemFrameworks.MRSProcessingType.FlatMode;
						Bitmap bmpflat=view.Export2Image(new Size(100,100));
						surface.SourceThumbnailFlat = SiGlaz.Utility.DBConvert.Bitmap2Byte(bmpflat);
						bmpflat.Dispose();

						this.OutputHistory.AddNewLine(this.ID,"Insert into database");

						#region Loop and Retry N times for exception case
						timetrying = 0;
						while(true && !fc.Abort)
						{
							try
							{
//								int signatureKey = 2;//"Empty";

								if(SiGlaz.Common.DDA.AppData.Data.UseWebService)
								{
									WebServiceProxy.SourceProxy.Source proxy = WebServiceProxy.WebProxyFactory.CreateSource();

									WebServiceProxy.SourceProxy.Disk diskproxy = WebServiceProxy.ConvertProxy.Convert(disk,typeof(WebServiceProxy.SourceProxy.Disk)) as WebServiceProxy.SourceProxy.Disk;
									WebServiceProxy.SourceProxy.Surface surfaceproxy = WebServiceProxy.ConvertProxy.Convert(surface,typeof(WebServiceProxy.SourceProxy.Surface)) as WebServiceProxy.SourceProxy.Surface;
									WebServiceProxy.SourceProxy.Fab fabproxy = WebServiceProxy.ConvertProxy.Convert(this.Fab,typeof(WebServiceProxy.SourceProxy.Fab)) as WebServiceProxy.SourceProxy.Fab;
									proxy.SurfaceInsertAll(fabproxy,diskproxy,surfaceproxy);

//									long surfacekey = proxy.SurfaceInsertAll(fabproxy,diskproxy,surfaceproxy);
//									//Insert Empty surface
//									if (surfacekey>0 && surface.NumberOfDefect == 0)
//									{
//										#region Insert Empty Result
//										SiGlaz.Common.DDA.SurfaceResult result = new SiGlaz.Common.DDA.SurfaceResult();
//										result.AnalyzeTime = DateTime.Now;
//										result.NumberOfDefect = 0;
//										result.PercentOfDefect = 0;
//										result.RecipeKey = -1;
//										result.SignatureKey = signatureKey;
//										result.SurfaceKey = surfacekey;
//
//										WebServiceProxy.SurfaceProxy.SurfaceResult result1 = (WebServiceProxy.SurfaceProxy.SurfaceResult)WebServiceProxy.ConvertProxy.Convert(result, typeof(WebServiceProxy.SurfaceProxy.SurfaceResult));
//										WebServiceProxy.SurfaceProxy.Surface surfaceProxy = WebServiceProxy.WebProxyFactory.CreateSurface();
//										surfaceProxy.Results_Insert(result1);
//										#endregion
//									}
								}
								else
								{
									SiGlaz.DDA.Business.Source proxy = new SiGlaz.DDA.Business.Source();
									proxy.SurfaceInsertAll(this.Fab,disk,surface);

//									long surfacekey = proxy.SurfaceInsertAll(this.Fab,disk,surface);
//									//Insert Empty surface
//									if (surfacekey>0 && surface.NumberOfDefect == 0)
//									{
//										#region Insert Empty Result
//										SiGlaz.Common.DDA.SurfaceResult result = new SiGlaz.Common.DDA.SurfaceResult();
//										result.AnalyzeTime = DateTime.Now;
//										result.NumberOfDefect = 0;
//										result.PercentOfDefect = 0;
//										result.RecipeKey = -1;
//										result.SignatureKey = signatureKey;
//										result.SurfaceKey = surfacekey;
//
//										SiGlaz.DDA.Business.Surface surfaceProxy = new SiGlaz.DDA.Business.Surface();
//										surfaceProxy.Results_Insert(result);
//										#endregion
//									}
								}

								break;//process ok break here
							}
							catch(Exception ex)
							{
								timetrying++;

								if(timetrying >= _PostProcess.MaxTimesRetry)
								{
									CannotProcess(filepath);
									this.OutputHistory.AddNewLine(this.ID,string.Format("Cannot process file {0} after {1} retry times", Path.GetFileName(filepath) , _PostProcess.MaxTimesRetry));
									break;
								}

								this.OutputHistory.AddNewLine(this.ID, string.Format("Cannot insert into database server, retry after {0} seconds",SiGlaz.Common.DDA.AppData.Data.WaitingToRetryError));
								WriteTrace("ERROR Insert database : " + ex.ToString());

								System.Threading.Thread.Sleep(SiGlaz.Common.DDA.AppData.Data.WaitingToRetryError*1000);
							}
						}

						#endregion 

						this.OutputHistory.AddNewLine(this.ID,"Process Surface :" + klarf.DiskInformation.Surface.ToString() + " of Disk " + klarf.sSerialNumber + " successful");

						if(fc.Abort) return;
					}

					//CheckLot(dat.LotNum);
					this.OutputHistory.AddNewLine(this.ID,string.Format("Process file {0} is success", Path.GetFileName(filepath) ));
				}

				if(fc.Abort) return;
			}
			catch(System.Threading.ThreadInterruptedException ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
				return;
			}
			catch(Exception ex)
			{
				this.OutputHistory.AddNewLine(this.ID,"ERROR Process file :" + Path.GetFileName(filepath) );


				string tracelog = "ERROR Process file : " + Path.GetFileName(filepath) + " \n\t+MESSAGE "
					+ ex.Message + " \n\t+StackTrace "
					+ ex.StackTrace;

				WriteTrace(tracelog);

				fc_OnProcessInvalid(this.ID,filepath,e);//Copy to invalid file
			}

			#endregion Processing Here
			
			try
			{
				this.DoPostProcess();
			}
			catch(Exception ex)
			{
				this.OutputHistory.AddNewLine(this.ID,"ERROR PostProcess file :" + Path.GetFileName(filepath) );


				string tracelog = "ERROR Process file : " + Path.GetFileName(filepath) + " \n\t+MESSAGE "
					+ ex.Message + " \n\t+StackTrace "
					+ ex.StackTrace;

				WriteTrace(tracelog);

				//this.Stop();
			}

			HandlerEndProcess(filepath,e);

			if(this.OutputHistory!=null)
			{
				this.OutputHistory.AddNewLine(this.ID, string.Format("End process file {0}", Path.GetFileName(filepath) ));
			}

		}

		private void fc_OnProcessInfo(int id,string description, EventArgs e)
		{
			this.OutputHistory.AddNewLine(this.ID,description);
			HandlerProcessInfor(description,e);
		}

		public override void DoPreProcess()
		{
			if( this._PreProcess!=null)
			{
				if(this._PreProcess.CopyFile)
				{
					string despathfile  = Path.Combine(this._PreProcess.CopyFilePath,Path.GetFileName(_CurrentFilePath));

					SiGlaz.Utility.GlobalLock lockObj = new SiGlaz.Utility.GlobalLock(despathfile);
					try
					{
						if(lockObj.WaitOne(60*5))
							Try2Copy(_CurrentFilePath,despathfile);
					}
					finally
					{
						lockObj.Release();
					}
				}
			}
		}

		private void fc_OnProcessInvalid(int id,string filepath, ProcessEventArgs e)
		{
			this.OutputHistory.AddNewLine(this.ID,"File :" + filepath + " is invalid");

			if( this._PreProcess!=null)
			{
				if(this._PreProcess.CopyInvalidFile)
				{
					string filename = Path.GetFileName(filepath);
					string despathfile  = Path.Combine(this._PreProcess.CopyInvalidFilePath,filename);

					SiGlaz.Utility.GlobalLock lockObj = new SiGlaz.Utility.GlobalLock(despathfile);
					try
					{
						if(lockObj.WaitOne(60*5))
							Try2Copy(filepath,despathfile);
					}
					catch
					{
					}
					finally
					{
						lockObj.Release();
					}
				}
			}
		}


		public override void Stop()
		{
			base.Stop ();
			fc.Abort = true;
			fc.ForceAbort();
		}

		private void fc_OnAbort(object sender, EventArgs e)
		{
			this.IsRunning = false;
		}

		private void fc_OnStateChange(object sender, EventArgs e)
		{
			this.IsWaiting = fc.Waiting;
			this.RaiseChangeStatus();
		}

		#region process finished layers
//		private void AddLot(string lot,int layernumber)
//		{
//			if(_LotTimeOuts==null) return;
//			lock(_LotTimeOuts)
//			
//			{
//				if(_LotTimeOuts.Contains(lot))
//				{
//					LotInfor  lotobj =  _LotTimeOuts[lot] as LotInfor;
//					lotobj.NumberOfLayer+=layernumber;
//					lotobj.IncomeDate = DateTime.Now;//update lastest layer time
//				}
//				else
//				{
//					LotInfor  lotobj = new LotInfor();
//					lotobj.IncomeDate = DateTime.Now;//update first layer time
//					lotobj.LotID = lot;
//					lotobj.NumberOfLayer = layernumber;
//					_LotTimeOuts.Add(lot,lotobj);
//				}
//			}
//		}

//		private void CheckLot(string lot)
//		{
//			if(_LotTimeOuts==null) return;
//			lock(_LotTimeOuts)
//			{
//				if(_LotTimeOuts.Contains(lot)) 
//				{
//					if( (_LotTimeOuts[lot] as LotInfor).NumberOfLayer >= this.MaxLayerOfLot)
//					{
//						_LotTimeOuts.Remove(lot);
//						ProcessLotFinish(lot);
//					}
//				}
//			}
//		}

//		private void ProcessLotFinish(string lot)
//		{
//			if(SiGlaz.Common.DDA.AppData.Data.UseWebService)
//			{
//				WebServiceProxy.DynamicProxy.DataSource cmd = WebServiceProxy.WebProxyFactory.CreateDataSource();
//				if(cmd==null) return;
//				cmd.Lot_LoadFinish(lot);
//			}
//			else
//			{
//				SiGlaz.DDA.Business.DataSourceCmd cmd = new SiGlaz.DDA.Business.DataSourceCmd();
//				if(cmd==null) return;
//				cmd.Lot_LoadFinish(lot);
//			}
//		}

//		private void CheckLotQueue(bool removeall)
//		{
//			if(_LotTimeOuts==null) return;
//			lock(_LotTimeOuts)
//			{
//				ArrayList alRemovedKey = null;
//				foreach(string lot in _LotTimeOuts.Keys)
//				{
//					LotInfor lotobj = _LotTimeOuts[lot] as LotInfor;
//
//					TimeSpan  timespan =DateTime.Now.Subtract(lotobj.IncomeDate);
//					if(removeall ||  timespan.TotalMilliseconds >= _NextLayerOnLotTimeOuts*1000*60)
//					{
//						ProcessLotFinish(lot);
//						if(alRemovedKey==null)
//							alRemovedKey = new ArrayList();
//						alRemovedKey.Add(lot);
//					}
//				}
//
//				if( alRemovedKey!=null)
//				{
//					foreach(string lot in alRemovedKey)
//					{
//						_LotTimeOuts.Remove(lot);
//					}
//				}
//			}
//		}

//		private void _Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
//		{
//			CheckLotQueue(false);
//		}

//		private void StartTimeout()
//		{
//			_LotTimeOuts = new Hashtable();
//			_Timer = new System.Timers.Timer(TIMER_SECOND);
//			_Timer.Elapsed+=new System.Timers.ElapsedEventHandler(_Timer_Elapsed);
//			_Timer.Start();
//		}

//		private void StopTimeout()
//		{
//			if(_Timer!=null)
//			{
//				CheckLotQueue(true);
//				_Timer.Stop();
//				_Timer.Elapsed-=new System.Timers.ElapsedEventHandler(_Timer_Elapsed);
//				_Timer.Dispose();
//				_Timer = null;
//			}
//		}

		#endregion process finished layers

		public override string ValidateString
		{
			get
			{
				if(PreProcess.ValidateString!=string.Empty)
					return PreProcess.ValidateString;

				if( PostProcess==null)
				{
					return "Please re-define tasks";
				}
				if(PostProcess.ValidateString!=string.Empty)
					return PostProcess.ValidateString;

				return string.Empty;

			}
		}

	}

	public class LotInfor
	{
		public string		LotID = string.Empty;
		public int			NumberOfLayer = 0;
		public DateTime		IncomeDate = DateTime.Now;
	}

}
