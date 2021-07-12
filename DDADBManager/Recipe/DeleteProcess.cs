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
	public class DeleteProcess : ProcessBase
	{
		public SiGlaz.DAL.ConnectionParam	destination = new SiGlaz.DAL.ConnectionParam();

		public SchedularItem				schedular = new SchedularItem();
		public TransferTime					transfertime = new TransferTime();
		public int							NumberOfBatchRecord = 1000;

		public DeleteProcess() : base()
		{
			this.Name = "Delete Data";
			this.destination.Database ="DDAStagingArea";
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
					SingleTableCmd cmd = new SingleTableCmd(destination);
					if(!cmd.TestConnection())
						return "Destination Connection is invalid";

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

			this.IsWaiting = true;
			this.RaiseChangeStatus();
		}

		public override string StopImage
		{
			get
			{
				return "Images.data_delete_1.gif";
			}
		}

		public override string RunningImage
		{
			get
			{
				return "Images.data_delete_3.gif";
			}
		}

		public override string WaitingImage
		{
			get
			{
				return "Images.data_delete.gif";
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
					string SQL = "SELECT COUNT(DiskKey) FROM DDA_Disks WITH(NOLOCK)";
					string WHERE = string.Format(" WHERE TestDiskDate <='{0}'",dtBefore.ToString("yyyy-MM-dd HH:mm:ss"));
					if(!transfertime.moveAllDAta)
						SQL = SQL + WHERE;

					long rc = cmddes.ExecuteScalarSQL(SQL);
					if( rc < 1 ) break;

					try
					{
						rc = rc > NumberOfBatchRecord ? NumberOfBatchRecord : rc;

						SQL = string.Format(
							"DELETE DDA_Disks from (select top ({0}) * from DDA_Disks {1}) DDA_Disks", rc ,WHERE);
						cmddes.ExecuteNonQuery(SQL);

						this.OutputHistory.AddNewLine(this.ID,string.Format("Delete {0} rows of Disks",rc));
					}
					catch(Exception ex)
					{
						this.OutputHistory.AddNewLine(this.ID,string.Format("Cannot connect to database server, skip this command"));
						WriteTrace("ERROR : " + ex.ToString());
						break;
					}

				
//					SingleTableCmd cmddes = new SingleTableCmd(destination);
//					string SQL = "SELECT TOP 10000 DiskKey FROM DDA_Disks WITH(NOLOCK)";
//					if(!transfertime.moveAllDAta)
//						SQL = string.Format("{0} WHERE TestDiskDate <='{1}'",SQL,dtBefore.ToString("yyyy-MM-dd HH:mm:ss"));
//
//					DataSet ds = cmddes.ExecuteDataset(SQL);
//
//					//move to destination
//					if(ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
//					{
//						if(stopflag)
//							break;
//
//						this.OutputHistory.AddNewLine(this.ID,"Delete data ...");
//						int irow = 0;
//						foreach(DataRow dr in ds.Tables[0].Rows)
//						{
//							if(stopflag)
//								break;
//
//							try
//							{
//								long diskkey = (long)dr["DiskKey"];
//								try
//								{
//									//delete surface
//									SQL = string.Format("DELETE FROM DDA_Disks WHERE DiskKey=" + diskkey);
//									cmddes.ExecuteNonQuery(SQL);
//								}
//								catch(Exception ex)
//								{
//									SkipError(ex);
//								}
//							}
//							catch(Exception ex)
//							{
//								this.OutputHistory.AddNewLine(this.ID,string.Format("Cannot connect to database server, skip this command"));
//								WriteTrace("ERROR : " + ex.ToString());
//								break;
//							}
//
//							if(stopflag)
//								break;
//
//							irow++;
//						}	
//
//						ds.Dispose();
//						this.OutputHistory.AddNewLine(this.ID,string.Format("Delete {0} rows of Disks",irow));
//
//
						try
						{
							//delete result
							SQL = string.Format("DELETE FROM DDA_Results WHERE NOT EXISTS(SELECT ResultDetailKey FROM DDA_ResultDetail WHERE DDA_Results.ResultKey=DDA_ResultDetail.ResultKey)");
							cmddes.ExecuteNonQuery(SQL);
						}
						catch(Exception ex)
						{
							SkipError(ex);
						}

						this.OutputHistory.AddNewLine(this.ID,string.Format("Delete {0} rows of Result",rc));
//
//					}
//					else
//					{
//						break;
//					}

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
