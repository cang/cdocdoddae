using System;
using System.Threading;
using System.Collections;
using System.Drawing;
using System.IO;

//using SiGlaz.DDA.Engine;
using DDADBManager.Modal;

using SiGlaz.DAL;
using System.Data;


namespace DDADBManager.Process
{
	/// <summary>
	/// Summary description for TransferProcess.
	/// </summary>
	public class TransferProcess : ProcessBase
	{
		public SiGlaz.Common.DDA.DDADBType	transferType = SiGlaz.Common.DDA.DDADBType.DDADB;
		public SiGlaz.DAL.ConnectionParam	source = new SiGlaz.DAL.ConnectionParam();
		public SiGlaz.DAL.ConnectionParam	destination = new SiGlaz.DAL.ConnectionParam();

		public SchedularItem				schedular = new SchedularItem();
		public TransferTime					transfertime = new TransferTime();

		public TransferProcess() : base()
		{
			this.Name = "Transfer Data";
		}

		public override void InitProcess()
		{
			base.InitProcess ();
		}

		public override void Property()
		{
			if(this.IsRunning)
				return;
		}

		public override void Stop()
		{
			base.Stop ();
			stopflag = true;

			if( thread!=null && thread.ThreadState ==  System.Threading.ThreadState.WaitSleepJoin)
			{
				thread.Interrupt();
				thread = null;

				HandlerProcessInfor("Stop Task",EventArgs.Empty);
			}
		}

		public override string ValidateString
		{
			get
			{
				try
				{
					//Test Connection
					SiGlaz.DAL.SingleTableCmd cmd = new SingleTableCmd(source);
					if(!cmd.TestConnection())
						return "Source Connection is invalid";

					object obj = cmd.GetValueSQL("SELECT [Value] FROM DDA_ApplicationData WHERE [Key]='DBTYPE'");
					if(obj!=null)
					{
						if(transferType == SiGlaz.Common.DDA.DDADBType.DDADB)
						{
							if(obj.ToString()!="DDADB")
								return "Source Connection must be a DDADB";
						}
						else
						{
							if(obj.ToString()!="DDAStagingArea")
								return "Source Connection must be a DDAStagingArea";
						}
					}

					cmd = new SingleTableCmd(destination);
					if(!cmd.TestConnection())
						return "Destination Connection is invalid";

					obj = cmd.GetValueSQL("SELECT [Value] FROM DDA_ApplicationData WHERE [Key]='DBTYPE'");
					if(obj!=null)
					{
						if(transferType == SiGlaz.Common.DDA.DDADBType.DDADB)
						{
							if(obj.ToString()!="DDAStagingArea")
								return "Destination Connection must be a DDAStagingArea";
						}
						else
						{
							if(obj.ToString()!="DDAArchives")
								return "Destination Connection must be a DDAArchives";
						}
					}

//					if(source.Server.Trim().ToUpper() != destination.Server.Trim().ToUpper())
//					{
//						return "In this release, Source and Destination must same server.";
//					}

					return base.ValidateString;
				}
				catch(Exception ex)
				{
					return ex.Message;
				}
			}
		}

		Thread thread = null;
		bool stopflag = false;
		public override void Execute()
		{
			if(ValidateString!=string.Empty)
			{
				this.OutputHistory.AddNewLine(this.ID,ValidateString + ", please check again");
				return;
			}

			//validate return;
			//this.IsRunning = true;
			stopflag = false;

			base.Execute ();

			thread = new Thread(new ThreadStart(ExecuteThread));
			thread.Start();
		}

		long timeinterval = 0;
		private void ExecuteThread()
		{
			try
			{
				timeinterval = 0;

				while(!stopflag)
				{
					if(schedular.RunByDay)
					{
						DateTime dtNow = DateTime.Now;
						if(schedular.atTime.Hour == dtNow.Hour 
							&& schedular.atTime.Minute == dtNow.Minute
							&& schedular.atTime.Second == dtNow.Second)
						{
							if(schedular.dayMode == RunningModeByDay.EveryDay)
							{
								Process();
							}
							else if(schedular.dayMode == RunningModeByDay.EveryMonday && dtNow.DayOfWeek == DayOfWeek.Monday)
							{
								Process();
							}
							else if(schedular.dayMode == RunningModeByDay.EveryTuesday && dtNow.DayOfWeek == DayOfWeek.Tuesday)
							{
								Process();
							}
							else if(schedular.dayMode == RunningModeByDay.EveryWednesday && dtNow.DayOfWeek == DayOfWeek.Wednesday)
							{
								Process();	
							}
							else if(schedular.dayMode == RunningModeByDay.EveryThursday && dtNow.DayOfWeek == DayOfWeek.Thursday)
							{
								Process();
							}
							else if(schedular.dayMode == RunningModeByDay.EveryFriday && dtNow.DayOfWeek == DayOfWeek.Friday)
							{
								Process();
							}
							else if(schedular.dayMode == RunningModeByDay.EverySatuday && dtNow.DayOfWeek == DayOfWeek.Saturday)
							{
								Process();
							}
							else if(schedular.dayMode == RunningModeByDay.EverySunday && dtNow.DayOfWeek == DayOfWeek.Sunday)
							{
								Process();
							}
						}
					}
					else
					{
						if(schedular.delayMode == RunningModeByDelay.Hour && timeinterval%360==0)
						{
							Process();
							timeinterval=0;
						}
						else if(schedular.delayMode == RunningModeByDelay.Minute && timeinterval%60==0)
						{
							Process();
							timeinterval=0;
						}
					}

					Thread.Sleep(1000);//wait 1 second
					timeinterval++;
				}

				HandlerProcessInfor("Stop Task",EventArgs.Empty);
			}
			catch(ThreadInterruptedException)
			{
			}
			catch(Exception)
			{
			}
			finally
			{
				this.IsRunning = false;
			}
		}

		private void Process()
		{
			this.IsWaiting = false;
			this.RaiseChangeStatus();

			HandlerProcessInfor("process...",EventArgs.Empty);

			this.OutputHistory.AddNewLine(this.ID,"process...");

			MoveData();
			DeleteOperation();

			this.IsWaiting = true;
			this.RaiseChangeStatus();
		}

		private void DeleteOperation()
		{
			if(stopflag)
				return;

			SingleTableCmd cmddes = new SingleTableCmd(source);
			cmddes.ExecuteScalarProc("spDeleteOperation",SiGlaz.Common.DDA.AppData.Data.OperationHours,0);
		}

		private void TranferCategory()
		{
			TranferTable("DDA_Fabs","FabKey");
			TranferTable("DDA_Channels","ChannelID");
			TranferTable("DDA_ClassLookups","ClassID");
			TranferTable("DDA_DiskSizes","DiskSizeKey");

			//delete 
			DeleteData("DDA_GradeMapping");
			DeleteData("DDA_Grades");

			//update 
			TranferTable("DDA_Grades","GradeKey");
			TranferTable("DDA_GradeMapping","GradeKey","SignatureKey");//update for bug


			TranferTable("DDA_Signatures","SignatureKey");
			TranferTable("DDA_Products","ProductKey");
			TranferTable("DDA_Stations","StationKey");
			TranferTable("DDA_TesterTypes","TesterTypeID");
			TranferTable("DDA_WordCells","WordCellKey");

			TranferTable("DDA_Recipes","RecipeKey");
			TranferTable("DDA_RecipeData","RecipeKey");

			//...
			TranferTable("DDA_EIS_Resources","LotNum");
			TranferTable("DDA_KOI_Headers","Lot_Id","Lot_Slot");

		}

		private void DeleteData(string tablename)
		{
			try
			{
				SingleTableCmd cmddes = new SingleTableCmd(tablename,destination);
				string SQL = string.Format("DELETE FROM [{0}]",tablename);
				cmddes.ExecuteNonQuery(SQL);
			}
			catch(Exception ex)
			{
				SkipError(ex);
			}
		}

		public override string StopImage
		{
			get
			{
				return "Images.database_move_database.png";
			}
		}

		public override string RunningImage
		{
			get
			{
				return "Images.data-data.gif";
			}
		}

		public override string WaitingImage
		{
			get
			{
				return "Images.data_data_empty.gif";
			}
		}

		private bool CheckExistsOnDestination(string tablename,string key,long keyvalue)
		{
			try
			{
				SingleTableCmd cmddes = new SingleTableCmd(tablename,destination);
				//Get source
				string SQL = string.Format("SELECT TOP 1 1 FROM {0} WITH(NOLOCK) WHERE {1}={2}",tablename,key,keyvalue);
				return cmddes.CheckExistSQL(SQL);
			}
			catch(Exception ex)
			{
				SkipError(ex);
				return false;
			}
		}

		private bool TranferTable(string tablename,string key,long keyvalue)
		{
			try
			{
				SingleTableCmd cmddes = new SingleTableCmd(tablename,destination);

				//Get source
				string SQL = string.Format("SELECT * FROM {0} WITH(NOLOCK) WHERE {1}={2}",tablename,key,keyvalue);
				SingleTableCmd cmdsource = new SingleTableCmd(tablename,source);
				DataSet ds = cmdsource.ExecuteDataset(SQL);

				//Insert into destination
				if(ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
				{
					foreach(DataRow dr in ds.Tables[0].Rows)
					{
						cmddes.Insert(dr);
					}

					//this.OutputHistory.AddNewLine(this.ID,string.Format("Copy {0} rows of table {1} key = {2}",ds.Tables[0].Rows.Count,tablename,keyvalue));
					ds.Dispose();
				}
				
				return true;
			}
			catch(Exception ex)
			{
				SkipError(ex);
				return false;
			}
		}

		private void TranferTable(string tablename,string key)
		{
			if(source.Server.Trim().ToUpper() == destination.Server.Trim().ToUpper())
			{
				TranferTableBatchMode(tablename,key);
				return;
			}
		
			try
			{
				//Get all data into memory
				string SQL = string.Format("SELECT {0} FROM {1} WITH(NOLOCK)",key,tablename);

				//Get source
				SingleTableCmd cmddes = new SingleTableCmd(tablename,destination);
				SingleTableCmd cmdsource = new SingleTableCmd(tablename,source);
				DataSet ds = cmdsource.ExecuteDataset(SQL);

				//Insert into destination
				if(ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
				{
					bool isstring = ds.Tables[0].Columns[key].DataType == typeof(string);

					int irow = 0;
					foreach(DataRow dr in ds.Tables[0].Rows)
					{
						if(stopflag)
							break;

						//Check exists
						SQL = string.Format("SELECT TOP 1 1 FROM {0} WITH(NOLOCK) WHERE {1}={2}",tablename,key,isstring?string.Concat("'",dr[key],"'"):dr[key]);
						if(!cmddes.CheckExistSQL(SQL))
						{
							if(stopflag)
								break;

							cmddes.Insert(dr);
						}

						if(stopflag)
							break;

						irow++;
					}

					this.OutputHistory.AddNewLine(this.ID,string.Format("Copy {0} rows of table {1}",irow,tablename));
					ds.Dispose();
				}
			}
			catch(Exception ex)
			{
				SkipError(ex);
			}

		}

		private void TranferTable(string tablename,string key1,string key2)
		{
			if(source.Server.Trim().ToUpper() == destination.Server.Trim().ToUpper())
			{
				TranferTableBatchMode(tablename,key1,key2);
				return;
			}

			try
			{
				//Get all data into memory
				string SQL = string.Format("SELECT {0},{1} FROM {2} WITH(NOLOCK)",key1,key2,tablename);

				//Get source
				SingleTableCmd cmddes = new SingleTableCmd(tablename,destination);
				SingleTableCmd cmdsource = new SingleTableCmd(tablename,source);
				DataSet ds = cmdsource.ExecuteDataset(SQL);

				//Insert into destination
				if(ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
				{
					bool isstring1 = ds.Tables[0].Columns[key1].DataType == typeof(string);
					bool isstring2 = ds.Tables[0].Columns[key2].DataType == typeof(string);

					int irow = 0;
					foreach(DataRow dr in ds.Tables[0].Rows)
					{
						if(stopflag)
							break;

						//Check exists
						SQL = string.Format("SELECT TOP 1 1 FROM {0} WITH(NOLOCK) WHERE {1}={2} AND {3}={4}",tablename,key1,isstring1?string.Concat("'",dr[key1],"'"):dr[key1],key2,isstring2?string.Concat("'",dr[key2],"'"):dr[key2]);
						if(!cmddes.CheckExistSQL(SQL))
						{
							if(stopflag)
								break;

							cmddes.Insert(dr);
						}

						if(stopflag)
							break;

						irow++;
					}

					this.OutputHistory.AddNewLine(this.ID,string.Format("Copy {0} rows of table {1}",irow,tablename));
					ds.Dispose();
				}
			}
			catch(Exception ex)
			{
				SkipError(ex);
			}
		}

		private void TranferTableBatchMode(string tablename,params string []keys)
		{
			string SQL = string.Empty;
			try
			{
				
				//string SQL = string.Format("INSERT INTO {0}({1},{2}) SELECT e.{1},e.{2} FROM DDADB.dbo.{0} e WHERE NOT EXISTS (SELECT i.{1},i.{2} FROM {0} i WHERE e.{1}=i.{1} AND e.{2}=i.{2})");
				if(source.Server.Trim().ToUpper() == destination.Server.Trim().ToUpper())
				{
					this.OutputHistory.AddNewLine(this.ID,string.Format("begin copy data of table {0}...",tablename));

					SQL = "INSERT INTO " + tablename + " SELECT e.* FROM DDADB.dbo." + tablename + " e WHERE NOT EXISTS (SELECT ";
					for(int i=0;i<keys.Length;i++)
					{
						SQL+="i." + keys[i]+",";
					}
					SQL = SQL.TrimEnd(',') + " FROM " + tablename + " i WHERE ";

					for(int i=0;i<keys.Length;i++)
					{
						SQL+=" e." + keys[i] + "=i." + keys[i] + " AND";
					}
					SQL = SQL.Substring(0,SQL.Length-3) + ")";
					SingleTableCmd cmddes = new SingleTableCmd(tablename,destination);
					cmddes.ExecuteNonQuery(SQL);

					this.OutputHistory.AddNewLine(this.ID,string.Format("copy all rows of table {0} finished",tablename));
				}
			}
			catch(Exception ex)
			{
				WriteTrace(SQL);
				SkipError(ex);
			}
		}

		private void MoveData()
		{
			DateTime dtBefore = DateTime.Now;
			#region time
			if(transfertime.transferBeforeTime)
				dtBefore = transfertime.datetime;
			else
			{
				switch(transfertime.delaymode)
				{
					case TransferDelayMode.Day:
						dtBefore = dtBefore.AddDays(-transfertime.delay);
						break;

					case TransferDelayMode.Hour:
						dtBefore = dtBefore.AddHours(-transfertime.delay);
						break;

					case TransferDelayMode.Minute:
						dtBefore = dtBefore.AddMinutes(-transfertime.delay);
						break;

					case TransferDelayMode.Month:
						dtBefore = dtBefore.AddMonths(-transfertime.delay);
						break;

					case TransferDelayMode.Week:
						dtBefore = dtBefore.AddDays(-(double)transfertime.delay*7);
						break;
				}
			}
			#endregion time

			while(true)
			{
				try
				{
					if(stopflag)
						break;

					SingleTableCmd cmddes = new SingleTableCmd(destination);
					//Get processed surfaces
					//string SQL = "SELECT TOP 1000 * FROM DDA_Surfaces WITH(NOLOCK) WHERE Processed=1 AND (Deleted IS NULL OR Deleted=0)";
					string SQL = "SELECT TOP 1000 * FROM DDA_Surfaces WITH(NOLOCK) WHERE (Deleted IS NULL OR Deleted=0)";
					if(!transfertime.moveAllDAta)
						SQL = string.Format("{0} AND TestDate<='{1}'",SQL,dtBefore.ToString("yyyy-MM-dd HH:mm:ss"));

					SingleTableCmd cmdsource = new SingleTableCmd(source);
					DataSet ds = cmdsource.ExecuteDataset(SQL);

					//move to destination
					if(ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
					{

						if(stopflag)
							break;

						this.OutputHistory.AddNewLine(this.ID,"\r\nCopy category tables...");
						TranferCategory();//update category

						this.OutputHistory.AddNewLine(this.ID,"Move data ...");
						int irow = 0;
						foreach(DataRow dr in ds.Tables[0].Rows)
						{
							if(stopflag)
								break;

							try
							{
								long surfacekey = (long)dr["SurfaceKey"];
								long diskkey = (long)dr["DiskKey"];

								DateTime dt0 = DateTime.Now;

								//copy disk 
								SQL = string.Format("SELECT * FROM DDA_Disks WITH(NOLOCK) WHERE DiskKey={0}",diskkey);
								DataSet dsdisk = cmdsource.ExecuteDataset(SQL);//only one line

								DateTime dt1 = DateTime.Now;
								System.Diagnostics.Debug.WriteLine("SELECT * FROM DDA_Disks :" +  dt1.Subtract(dt0).TotalMilliseconds.ToString());

								#region DDA_DiskHeaders
//								string lotnum = (string)dsdisk.Tables[0].Rows[0]["LotNo"];
//
//								if(lotnum!=string.Empty)
//									lotnum = lotnum.Replace("'","''");//fix bug
//
//								short slotnum = (short)dsdisk.Tables[0].Rows[0]["SlotNum"];
//								int  WordCellKey = (int)dsdisk.Tables[0].Rows[0]["WordCellKey"];
//								SQL = string.Format("SELECT TOP 1 1 FROM DDA_DiskHeaders WITH(NOLOCK) WHERE LotNum='{0}' AND SlotNum={1} AND WordCellKey={2}",lotnum,slotnum,WordCellKey);
//								if(!cmddes.CheckExistSQL(SQL))
//								{
//									SQL = string.Format("SELECT * FROM DDA_DiskHeaders WITH(NOLOCK) WHERE LotNum='{0}' AND SlotNum={1} AND WordCellKey={2}",lotnum,slotnum,WordCellKey);
//									DataSet dsdh = cmdsource.ExecuteDataset(SQL);
//									if(dsdh.Tables[0].Rows.Count>0)
//									{
//										cmddes.TableName = "DDA_DiskHeaders";
//										try
//										{
//											cmddes.Insert(dsdh.Tables[0].Rows[0]);
//										}
//										catch(Exception ex)
//										{
//											SkipError(ex);
//											dsdh.Dispose();
//											continue;//try later
//										}
//									}	
//									dsdh.Dispose();
//								}
								#endregion DDA_DiskHeaders

								DateTime dt2 = DateTime.Now;
								System.Diagnostics.Debug.WriteLine("DDA_DiskHeaders :" + dt2.Subtract(dt1).TotalMilliseconds.ToString());

								#region DDA_Disks
								if(dsdisk!=null && dsdisk.Tables.Count>0 && dsdisk.Tables[0].Rows.Count>0)
								{
									if(!CheckExistsOnDestination("DDA_Disks","DiskKey",diskkey))
									{
										cmddes.TableName = "DDA_Disks";
										try
										{
											cmddes.Insert(dsdisk.Tables[0].Rows[0]);
										}
										catch(Exception ex)
										{
											SkipError(ex);
											dsdisk.Dispose();
											continue;//try later
										}
									}
									dsdisk.Dispose();
								}
								#endregion DDA_Disks

								DateTime dt3 = DateTime.Now;
								System.Diagnostics.Debug.WriteLine("DDA_Disk :" + dt3.Subtract(dt2).TotalMilliseconds.ToString());

								#region copy surface
								cmddes.TableName = "DDA_Surfaces";
								try
								{
									cmddes.Insert(dr);
								}
								catch(Exception ex)
								{
									SkipError(ex);
									if( !this.CheckExistsOnDestination("DDA_Surfaces","SurfaceKey",surfacekey) )
										continue;//try later
								}
								TranferTable("DDA_SurfaceData","SurfaceKey",surfacekey);//copy data of surface
								#endregion copy surface

								DateTime dt4 = DateTime.Now;
								System.Diagnostics.Debug.WriteLine("DDA_Surfaces :" +  dt4.Subtract(dt3).TotalMilliseconds.ToString());
								
								#region copy result
								SQL = string.Format("SELECT * FROM DDA_ResultDetail WITH(NOLOCK) WHERE SurfaceKey={0}",surfacekey);
								DataSet dsrd = cmdsource.ExecuteDataset(SQL);
								if(dsrd!=null && dsrd.Tables.Count>0 && dsrd.Tables[0].Rows.Count>0)
								{
									bool iscontinue=false;
									foreach(DataRow drrd in dsrd.Tables[0].Rows)
									{
										long ResultKey = (long)drrd["ResultKey"];
										long resultdetailkey = (long)drrd["ResultDetailKey"];

										TranferTable("DDA_Results","ResultKey",ResultKey);
										TranferTable("DDA_ResultData","ResultKey",ResultKey);

										cmddes.TableName = "DDA_ResultDetail";
										try
										{
											cmddes.Insert(drrd);
										}
										catch(Exception ex)
										{
											SkipError(ex);
											if(!this.CheckExistsOnDestination("DDA_ResultDetail","ResultDetailKey",resultdetailkey))
												iscontinue = true;
										}

										if(iscontinue)
											break;
										else
											TranferTable("DDA_ResultDetailData","ResultDetailKey",resultdetailkey);
									}
									dsrd.Dispose();
									if(iscontinue)
										continue;//try later
								}

								#endregion copy result

								DateTime dt5 = DateTime.Now;
								System.Diagnostics.Debug.WriteLine("copy result :" + dt5.Subtract(dt4).TotalMilliseconds.ToString());

								#region copy processed 
//								SQL = string.Format("SELECT * FROM DDA_Processed WITH(NOLOCK) WHERE SurfaceKey={0}",surfacekey);
//								DataSet dspr = cmdsource.ExecuteDataset(SQL);
//								if(dspr!=null && dspr.Tables.Count>0 && dspr.Tables[0].Rows.Count>0)
//								{
//									cmddes.TableName = "DDA_Processed";
//									foreach(DataRow drpr in dspr.Tables[0].Rows)
//									{
//										try
//										{
//											cmddes.Insert(drpr);
//										}
//										catch(Exception ex)
//										{
//											SkipError(ex);
//										}
//									}
//									dspr.Dispose();
//								}
								#endregion copy processed 

								DateTime dt6 = DateTime.Now;
								System.Diagnostics.Debug.WriteLine( dt6.Subtract(dt5).TotalMilliseconds.ToString());

								#region Update delete flag
								SQL = string.Format("UPDATE DDA_Surfaces SET Deleted=1 WHERE SurfaceKey={0}",surfacekey);
								cmdsource.ExecuteNonQuery(SQL);

								SQL = string.Format("SELECT COUNT(SurfaceKey) FROM DDA_Surfaces WHERE DiskKey={0} AND (Deleted IS NULL OR Deleted=0)",diskkey);
								if(!cmdsource.CheckExistSQL(SQL))
								{
									SQL = string.Format("UPDATE DDA_Disks SET Deleted=1 WHERE DiskKey={0}",diskkey);
									cmdsource.ExecuteNonQuery(SQL);
								}
								#endregion Update delete flag

								DateTime dt7 = DateTime.Now;
								System.Diagnostics.Debug.WriteLine("Update delete flag :" +  dt7.Subtract(dt6).TotalMilliseconds.ToString());

								//this.OutputHistory.AddNewLine(this.ID,string.Format("copy row of surface {0} and Results",surfacekey));
							}
							catch(Exception ex)
							{
								this.OutputHistory.AddNewLine(this.ID,string.Format("Cannot connect to database server, skip this command"));
								WriteTrace("ERROR : " + ex.ToString());
								break;
							}

							if(stopflag)
								break;

							irow++;
						}	
						ds.Dispose();
						this.OutputHistory.AddNewLine(this.ID,string.Format("Copy {0} rows of Surfaces and Results",irow));

						#region delete source
						try
						{
							//delete surface
							SQL = string.Format("DELETE FROM DDA_Surfaces WHERE Deleted=1");
							cmdsource.ExecuteNonQuery(SQL);
						}
						catch(Exception ex)
						{
							SkipError(ex);
						}
						this.OutputHistory.AddNewLine(this.ID,string.Format("Delete {0} rows of Surfaces",irow));

						try
						{
							//delete disk
							SQL = string.Format("DELETE FROM DDA_Disks WHERE Deleted=1");
							//SQL = string.Format("DELETE FROM DDA_Disks WHERE NOT EXISTS(SELECT SurfaceKey FROM DDA_Surfaces WHERE DDA_Disks.DiskKey=DDA_Surfaces.DiskKey)");
							cmdsource.ExecuteNonQuery(SQL);
						}
						catch(Exception ex)
						{
							SkipError(ex);
						}
						this.OutputHistory.AddNewLine(this.ID,string.Format("Delete {0} rows of Disks",irow));

						try
						{
							//delete disk
							SQL = string.Format("DELETE FROM DDA_Results WHERE NOT EXISTS(SELECT ResultDetailKey FROM DDA_ResultDetail WHERE DDA_Results.ResultKey=DDA_ResultDetail.ResultKey)");
							cmdsource.ExecuteNonQuery(SQL);
						}
						catch(Exception ex)
						{
							SkipError(ex);
						}
						this.OutputHistory.AddNewLine(this.ID,string.Format("Delete {0} rows of Result",irow));

						#endregion delete source

					}
					else
					{
						break;
					}

					if(stopflag)
						break;
				}
				catch(Exception ex)
				{
					SkipError(ex);
					break;
				}
			}
		}


		private void SkipError(Exception ex)
		{
			if(ex.Message.IndexOf("Cannot insert duplicate key")>=0) return;
			this.OutputHistory.AddNewLine(this.ID,string.Format("Cannot connect to database server, retry later"));
			WriteTrace("ERROR : " + ex.ToString());
		}

	}

}
