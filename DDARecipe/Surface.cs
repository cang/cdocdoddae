using System;
using System.Collections;

//using SiGlaz.DDA.Engine;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Result;

using SiGlaz.Recipes;

using System.Data;


namespace DDARecipe
{
	/// <summary>
	/// Summary description for SingleSource.
	/// </summary>
	/// 
	public class Surface : SiGlaz.Recipes.NodeSource
	{
		public Surface(): base()
		{
		}

		public override void Execute(SiGlaz.Recipes.WorkingSpace workingspace)
		{
			//base.Execute (workingspace);
			//Load Single map from database
			DDAWorkingSpace working = workingspace as DDAWorkingSpace;

			//Re-Load data
			bool loadfromdatabase = working.SourceMap==null;
			if(!loadfromdatabase)
			{
				working.ProcessMap  = working.SourceMap.Copy();
				return;
			}

			if(working.NoConnectToDatabase)
			{
				return;
			}

			//Load new Data
			DDARecipe recipe = this.Parent as DDARecipe;
			working.IsMulti = false;

			int recipekey = recipe.ID;
			int prevrecipe = recipe.PrevRecipeID;

			ResultBase result = null;
			DataSet ds = null;
			long surfacekey;

			#region Try to load new waferkey
			while(true)
			{
				surfacekey = ProcessedSurfaceKey(working);
				if(surfacekey>0)
				{
					working.SurfaceKey = surfacekey;

					//multi process event 
					if(recipe.ListenEvent!=null)
						recipe.ListenEvent.ResetEvent();

					break;
				}

				if(workingspace.Stop) return;

				#region multi process event 
				//SiGlaz.Utility.DebugLog.LogFolderPath = "D:\\log";
				//SiGlaz.Utility.DebugLog.Write(DateTime.Now.ToString("HH:mm:ss.ffffff")  +":RaiseWaitingForData " + recipe.ID);
				recipe.RaiseWaitingForData(this,working.CreateEventArgs(string.Empty) );
				if(recipe.ListenEvent!=null)
				{
					//SiGlaz.Utility.DebugLog.Write(DateTime.Now.ToString("HH:mm:ss.ffffff")  +":Before WaitForSingleObject " + recipe.ID);
					recipe.ListenEvent.WaitForSingleObject(SiGlaz.Common.DDA.AppData.Data.ListenWaitingSecond*1000);//DDAConst.LISTENING_WAITING_MILISECOND);
					//SiGlaz.Utility.DebugLog.Write(DateTime.Now.ToString("HH:mm:ss.ffffff")  +":After WaitForSingleObject " + recipe.ID);
					recipe.ListenEvent.ResetEvent();
				}
				else
				{
					System.Threading.Thread.Sleep(SiGlaz.Common.DDA.AppData.Data.ListenWaitingSecond*1000);//DDAConst.LISTENING_WAITING_MILISECOND);//wait 1 minutes
				}
				#endregion multi process event 

				if(workingspace.Stop) return;

			}
			#endregion Try to load new waferkey

			working.dtBeginProcess = DateTime.Now;

			//Update process state
			if(working.SurfaceKey>0)
			{
				try
				{
					WebServiceProxy.SurfaceCmd  cmd = new WebServiceProxy.SurfaceCmd();
					result = cmd.Processed_Insert(this.Parent.ID,working.SurfaceKey,false,false);//result = cmd.Processed_Insert(this.Parent.ID,working.SurfaceKey,(this.Parent as DDARecipe).BreakWhenFound,false);
					if(!result.IsSuccess)
					{
						working.SkipRun = true;
						return;
					}
				}
				catch
				{
					throw;
				}
			}

			#region Load data into working.SourceMap
			if(AppData.Data.UseWebService)
			{
				WebServiceProxy.SourceProxy.Source proxy = WebServiceProxy.WebProxyFactory.CreateSource();
				ds = proxy.GetSourceRawData(working.SurfaceKey);
			}
			else
			{
				SiGlaz.DDA.Business.Source proxy = new SiGlaz.DDA.Business.Source();
				ds = proxy.GetSourceRawData(working.SurfaceKey);
			}

			working.SourceMap = SiGlaz.DDA.Business.BDConvert.ConvertToKlarf(ds);

			//Get Header
			working.Header = new DDADataFlowHeader();
			working.Header.BinNum  = working.SourceMap.DiskInformation.IRISBinNo;
			working.Header.TestGrade  = working.SourceMap.DiskInformation.TestGrade;
			working.Header.CassetteID  = working.SourceMap.DiskInformation.Cassette;
			working.Header.DiskID = working.SourceMap.sSerialNumber;
			working.Header.DiskType = working.SourceMap.DiskInformation.DiskType;
			working.Header.InnerDiameter = working.SourceMap.DiskInformation.InnerDiameter;
			working.Header.OuterDiameter = working.SourceMap.DiskInformation.OuterDiameter;
			working.Header.LotIDCode = working.SourceMap.DiskInformation.LotIDCode;
			working.Header.LotID = working.SourceMap.DiskInformation.LotID;
			//working.Header.NumberOfDefect = working.SourceMap.DiskInformation.NumberDefect;
			working.Header.NumberOfDefect = working.SourceMap.defectcount;
			working.Header.SlotNum = (short)working.SourceMap.DiskInformation.SlotNumber;
			working.Header.StationID = working.SourceMap.DiskInformation.Tester;
			working.Header.Surface = (eSurface)working.SourceMap.DiskInformation.Surface;
			working.Header.WordCellID = working.SourceMap.DiskInformation.TestCell;
			working.Header.TestDate = working.SourceMap.DiskInformation.DateTime;

			//Get Data

			#endregion Load data

			if(working.SourceMap!=null && working.SourceMap.defectcount<=0)//OriginalNumberOfDefect = defectcount
			{
				working.GotoEnd = true;
				return;
			}

			if(working.SourceMap!=null)
			{
				string msg = string.Format(working.SourceMap.DiskInformation.TestDiskID + "-" + working.SourceMap.DiskInformation.Surface.ToString());
				recipe.RaiseMessage(this,working.CreateEventArgs(msg));
			}

			#region Get and filter-out Processed Data 

			byte[] lpprocessed = null;

			if(AppData.Data.UseWebService)
			{
				WebServiceProxy.SurfaceProxy.Surface proxy = WebServiceProxy.WebProxyFactory.CreateSurface();
				lpprocessed = proxy.GetProcessedResultDetail(recipekey,working.SurfaceKey);
			}
			else
			{
				SiGlaz.DDA.Business.Surface proxy = new SiGlaz.DDA.Business.Surface();
				lpprocessed = proxy.GetProcessedResultDetail(recipekey,working.SurfaceKey);
			}

			if(lpprocessed!=null)
			{
				lpprocessed = SiGlaz.Utility.Compression.Compressor.DeCompress(lpprocessed);
				SiGlaz.Common.DDA.ResultDefectList deflist = SiGlaz.Common.DDA.ResultDefectList.Deserialize(lpprocessed);

				if(deflist.alDefectListID!=null && working.SourceMap.defectcount>0 && deflist.alDefectListID.Count>=working.SourceMap.defectcount)//for TesterNoise performance
					working.SourceMap.EmptyData();
				else
					working.SourceMap.Subtract(deflist.alDefectListID);
			}

			#endregion Get and filter-out Processed Data 

			working.ProcessMap = working.SourceMap.Copy();
		}

		private long ProcessedSurfaceKey(DDAWorkingSpace working)
		{
			if(SiGlaz.Common.DDA.AppData.Data.ProcessSurfaceMore==null)
				return GetProcessedSurfaceKey(working);

			long surfacekey = -1;

			working.processedTickCount++;

			if(working.processedTickCount> 100 - SiGlaz.Common.DDA.AppData.Data.ProcessSurfaceMore.ProcessPercent)
			{
				surfacekey = GetProcessedSurfaceMoreKey(working);
				if(surfacekey==-1)//retry with other
					surfacekey = GetProcessedSurfaceKey(working);
			}
			else
			{
				surfacekey = GetProcessedSurfaceKey(working);
				if(surfacekey==-1)//retry with other
					surfacekey = GetProcessedSurfaceMoreKey(working);
			}

			if(working.processedTickCount>=100)	working.processedTickCount = 0;

			if(surfacekey==-1)
				working.LoadDuration=working.CheckDuration=0;

			return surfacekey;
		}

		private long GetProcessedSurfaceKey(DDAWorkingSpace working)
		{
			DateTime dtBegin;
			do
			{
				if(working.quereSurfaceKey.Count<=0)
				{
					//the times query queue
					dtBegin = DateTime.Now;

					GetProcessedSurfaceKeyList(working);
					if(working.quereSurfaceKey.Count<=0)
						break;

					TimeSpan ts = DateTime.Now.Subtract(dtBegin);
					working.LoadDuration+= ts.TotalMilliseconds;
				}

				working.CheckDuration = working.LoadDuration/(working.quereSurfaceKey.Count + working.quereSurfaceMoreKey.Count);

				WebServiceProxy.SurfaceCmd cmd = new WebServiceProxy.SurfaceCmd();
				dtBegin = DateTime.Now;
				while(working.quereSurfaceKey.Count>0)
				{
					long surfacekey = (long)working.quereSurfaceKey.Dequeue();
					working.LoadDuration-= working.CheckDuration;

					//share processing on other server
					if( AppData.Data.AllowMultiApplicationServer)
					{
						if( !cmd.CheckProcessed( (this.Parent as DDARecipe).ID , surfacekey ) )
						{
							TimeSpan ts = DateTime.Now.Subtract(dtBegin);
							working.CheckDuration+= ts.TotalMilliseconds;
							return surfacekey;
						}
					}
					else
					{
						return surfacekey;
					}

				}
			}
			while(working.quereSurfaceKey.Count<=0);

            working.CheckDuration = 0;
			return -1;
		}

		private long GetProcessedSurfaceMoreKey(DDAWorkingSpace working)
		{
			DateTime dtBegin;
			do
			{
				if(working.quereSurfaceMoreKey.Count<=0)
				{
					//the times query queue
					dtBegin = DateTime.Now;

					GetProcessedSurfaceMoreKeyList(working);
					if(working.quereSurfaceMoreKey.Count<=0)
						break;

					TimeSpan ts = DateTime.Now.Subtract(dtBegin);
					working.LoadDuration+= ts.TotalMilliseconds;
				}

				working.CheckDuration = working.LoadDuration/(working.quereSurfaceKey.Count + working.quereSurfaceMoreKey.Count);
				
				dtBegin = DateTime.Now;
				WebServiceProxy.SurfaceCmd cmd = new WebServiceProxy.SurfaceCmd();
				while(working.quereSurfaceMoreKey.Count>0)
				{
					long surfacekey = (long)working.quereSurfaceMoreKey.Dequeue();
					working.LoadDuration-= working.CheckDuration;

					//share processing on other server
					if( AppData.Data.AllowMultiApplicationServer)
					{
						if( !cmd.CheckProcessed( (this.Parent as DDARecipe).ID , surfacekey ) )
						{
							TimeSpan ts = DateTime.Now.Subtract(dtBegin);
							working.CheckDuration+= ts.TotalMilliseconds;
							return surfacekey;
						}
					}
					else
					{
						return surfacekey;
					}

				}
			}
			while(working.quereSurfaceMoreKey.Count<=0);

			working.CheckDuration = 0;
			return -1;
		}

		private bool GetProcessedSurfaceKeyList(DDAWorkingSpace working)
		{
			DDARecipe recipe = this.Parent as DDARecipe;
			int recipekey = recipe.ID;
			int prevrecipe = recipe.PrevRecipeID;

			if(AppData.Data.UseWebService)
			{
				WebServiceProxy.SurfaceProxy.Surface proxy = WebServiceProxy.WebProxyFactory.CreateSurface();
				object[] results = proxy.GetNewSurfaceKey(recipekey,prevrecipe,SiGlaz.Common.DDA.AppData.Data.FabKey,working.dtProcessedSurfaces,null,DDAConst.MAX_SURFACE_QUEUE);
				if( results!=null )
				{
					foreach(long key in results)
					{
						working.quereSurfaceKey.Enqueue(key);
					}
					results = null;
					return true;
				}
			}
			else
			{
				SiGlaz.DDA.Business.Surface proxy = new SiGlaz.DDA.Business.Surface();
				ArrayList results = proxy.GetNewSurfaceKey(recipekey,prevrecipe,SiGlaz.Common.DDA.AppData.Data.FabKey,working.dtProcessedSurfaces,null,DDAConst.MAX_SURFACE_QUEUE);
				if( results!=null )
				{
					foreach(long key in results)
					{
						working.quereSurfaceKey.Enqueue(key);
					}
					results.Clear();
					results = null;
					return true;
				}
			}

			return false;
		}

		private bool GetProcessedSurfaceMoreKeyList(DDAWorkingSpace working)
		{
			if(SiGlaz.Common.DDA.AppData.Data.ProcessSurfaceMore==null) return true;

			DDARecipe recipe = this.Parent as DDARecipe;
			int recipekey = recipe.ID;
			int prevrecipe = recipe.PrevRecipeID;

			DateTime processdate = DateTime.MinValue;

			if(SiGlaz.Common.DDA.AppData.Data.ProcessSurfaceMore.fromDateTime!=null)
			{
				if( SiGlaz.Common.DDA.AppData.Data.ProcessSurfaceMore.fromDateTime.Type == TimeRangeType.LastNHours 
					&& SiGlaz.Common.DDA.AppData.Data.ProcessSurfaceMore.fromDateTime.N == -1 )
				{
					processdate = processdate.AddYears(1);//by recipe time
				}
				else
					processdate = SiGlaz.Common.DDA.AppData.Data.ProcessSurfaceMore.fromDateTime.From;
			}

			string gradelist = SiGlaz.Common.DDA.AppData.Data.ProcessSurfaceMore.ListGradeString;

			if(AppData.Data.UseWebService)
			{
				WebServiceProxy.SurfaceProxy.Surface proxy = WebServiceProxy.WebProxyFactory.CreateSurface();
				object[] results = proxy.GetNewSurfaceKey(recipekey,prevrecipe,SiGlaz.Common.DDA.AppData.Data.FabKey,processdate,gradelist,DDAConst.MAX_SURFACE_QUEUE);
				if( results!=null )
				{
					foreach(long key in results)
					{
						working.quereSurfaceMoreKey.Enqueue(key);
					}
					results = null;
					return true;
				}
			}
			else
			{
				SiGlaz.DDA.Business.Surface proxy = new SiGlaz.DDA.Business.Surface();
				ArrayList results = proxy.GetNewSurfaceKey(recipekey,prevrecipe,SiGlaz.Common.DDA.AppData.Data.FabKey,processdate,gradelist,DDAConst.MAX_SURFACE_QUEUE);
				if( results!=null )
				{
					foreach(long key in results)
					{
						working.quereSurfaceMoreKey.Enqueue(key);
					}
					results.Clear();
					results = null;
					return true;
				}
			}
			return false;
		}

	}
}
