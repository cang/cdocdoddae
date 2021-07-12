using System;
using System.IO;
using System.Data;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;

using KOIDTSSimpleMsg;
using SiGlaz.DAL;
using SiGlaz.Common.DDA;

using System.Threading;

using SiGlaz.Utility.Wind32;

namespace KOIDTSCmd
{	
	class Class1
	{
		[STAThread]
		static void Main(string[] args)
		{
			SiGlaz.Utility.EventViewerLog.GlobalLog = new SiGlaz.Utility.EventViewerLog("EISKOIDDAService");

			PersonalFolder = SiGlaz.Common.DDA.AppData.GetCommonApplicationDataPath("KOIDTSCmd");

			LoadStatusExexcute();//Load va chay dau tien ... neu nhu stop va start lai services

			InitEvent();

			InitRemote();

			ListenEvent();//waiting here

			FreeEvent();
	

		}
		#region Remoting
		private static void InitRemote()
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
			KOIDTSSimpleMsg.Cache.GetInstance().InitRemoting();            
		}

		private static void SendMgs(string msg)
		{
			try
			{
				(KOIDTSSimpleMsg.Cache.GetInstance().GetRemoteSingletonObject(typeof(KOIDTSSimpleMsg.RObject)) as KOIDTSSimpleMsg.RObject).HandlerOnMessageSimple(null,msg);
			}
			catch (System.Exception e)
			{
				SiGlaz.Utility.Utility.WriteToTraceLog(e,"Process");
			}
			
		}

		#endregion

		#region API


		static string _name = "SiGlaz_KOIDTS_Client";
		static string _echeckname =  "Global\\" + _name ;
		static IntPtr _echeck = IntPtr.Zero;

		static string _servername = "SiGlaz_KOIDTS_Server";
		static string _echecknameraise = "Global\\" + _servername;
		static IntPtr _echeckraise = IntPtr.Zero;

		static AutoResetEvent restartEvent = null;

		static bool		IsRunning = false;

		private static void InitEvent()
		{
			_echeck = Kernel32.CreateEvent(IntPtr.Zero,true,false,_echeckname);
			if(_echeck==IntPtr.Zero)
			{
				throw new Exception("Cannot create " + _echeckname + " event");
			}
			Kernel32.ResetEvent(_echeck);

			_echeckraise = Kernel32.CreateEvent( IntPtr.Zero,true,false,_echecknameraise);
			if(_echeckraise==IntPtr.Zero)
			{
				throw new Exception("Cannot create " + _echecknameraise + " event");
			}
			//ResetEvent(_echeckraise);
		}

		private static void FreeEvent()
		{
			if(_echeck!=IntPtr.Zero)
			{
				Kernel32.SetEvent(_echeck);
				Kernel32.CloseHandle(_echeck);
			}

			if(_echeckraise!=IntPtr.Zero)
			{
				Kernel32.SetEvent(_echeckraise);
				Kernel32.CloseHandle(_echeckraise);
			}
		}
		
		private static void ListenEvent()
		{
			while (true)
			{
				Kernel32.WaitForSingleObject(_echeck,int.MaxValue);
				Kernel32.ResetEvent(_echeck);

				//Get status
				LoadStatusExexcute();
			}
		}
		#endregion
	

		static void WriteOuput(string msg)
		{
			string fileName =string.Format("{0}\\SiGlaz_KOIDTS_Server.txt",PersonalFolder);
			//SiGlaz.Utility.GlobalLock lck = new SiGlaz.Utility.GlobalLock(fileName);
			SiGlaz.Utility.MutexSecurity lck = new SiGlaz.Utility.MutexSecurity(fileName);
			StreamWriter stream = null;
			try
			{
				lck.WaitOne();
				stream = new StreamWriter(fileName,false);
				stream.WriteLine(  msg);
			}
			catch
			{
				
			}
			finally
			{
				if ( stream != null )
				{
					stream.Close();
					stream = null;
				}		
				lck.Done();				
			}
			Kernel32.SetEvent(_echeckraise);
		}


		static void StopProcess()
		{
			if(threadProcess!=null)
			{
				exitProcess = true;
				threadProcess.Interrupt();
			}
		}

		static void LoadStatusExexcute()
		{
			//Get status
			string fileName =string.Format("{0}\\{1}",PersonalFolder,_name);
			SiGlaz.Common.Configuration.LoadData(fileName);				
			
			IsRunning = (bool)SiGlaz.Common.Configuration.GetValues("RUNNING_STATUS",false);

			if(restartEvent==null)
				restartEvent = new AutoResetEvent(true);

			if(IsRunning)
			{
				restartEvent.WaitOne();
				StartProcess();
			}
			else
				StopProcess();
		}


		static Thread threadProcess = null;
		static void StartProcess()
		{
			threadProcess = new Thread(new ThreadStart(StartProcessThread));
			threadProcess.IsBackground = true;
			threadProcess.Start();
		}
		

		static bool exitProcess = false;
		static void StartProcessThread()
		{
			try
			{
				while(!exitProcess)
					Process();
			}
			catch(System.Threading.ThreadInterruptedException)
			{
				return;
			}
			finally
			{
				exitProcess = false;
				restartEvent.Set();
			}
		}
	
		public static DataTable GetKOIParam(GeneralCmd cmd, int numTop, DateTime testDate)
		{
			DataSet ds = new DataSet();	
			object []objs = new object[3];
			objs[0] = numTop;
			objs[1] = AutoKOIID;
			objs[2] = testDate;
			ds = cmd.ExecuteDataset("GET_KOI_PARAM",objs);			
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];			
			return null;
		}

		public static DataTable GetEISParam(GeneralCmd cmd, int numTop, DateTime testDate)
		{
			DataSet ds = new DataSet();	
			object []objs = new object[3];
			objs[0] = numTop;
			objs[1] = AutoEISID;
			objs[2] = testDate;
			ds = cmd.ExecuteDataset("GET_EIS_PARAM",objs);			
			if (ds != null && ds.Tables.Count > 0)
				return ds.Tables[0];			
			return null;
		}

		private static int GetAutoID(GeneralCmd cmd)
		{
			if (!CheckIsExistsAutoID(cmd))
			{
				cmd.ExecuteNonQuery("Insert into DDA_ApplicationData([Key],[Value]) values ('KOIID',0)");
				return 0;
			}
			else
			{
				DataSet ds = new DataSet();	
				ds = cmd.ExecuteDataset("Select [Value] from DDA_ApplicationData where [Key] = 'KOIID'");				
				if (ds.Tables[0].Rows.Count > 0)
					return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
				return 0;
			}
		}

		private static bool CheckIsExistsAutoID(GeneralCmd cmd)
		{
			long exists = cmd.ExecuteScalarSQL("select count(*) from DDA_ApplicationData where [Key] = 'KOIID'");
			if (exists > 0)
				return true;
			return false;			
		}

		private static bool CheckIsExistsInDDAHeader(GeneralCmd cmd, object LotNo, object SlotNum, object WordCellKey)
		{
			return cmd.CheckExistSQL(string.Format("select top 1 1 from DDA_DiskHeaders where LotNum = '{0}' AND SlotNum = {1} AND WordCellKey = {2}",LotNo,SlotNum,WordCellKey));		
		}

		private static bool CheckIsExistsKOIHeader(GeneralCmd cmd, object LotNo, object SlotNum)
		{
			return cmd.CheckExistSQL(string.Format("select top 1 1 from DDA_KOI_Headers where Lot_Id = '{0}' AND Lot_Slot = '{1}'",LotNo,SlotNum));		
		}

		private static bool CheckIsExistsEISResource(GeneralCmd cmd, object LotNo)
		{
			return cmd.CheckExistSQL(string.Format("select top 1 1 from DDA_EIS_Resources where LotNum = '{0}'",LotNo));		
		}

		private static void UpdateNewAutoID(GeneralCmd cmd, int KoiID)
		{
			if (!CheckIsExistsAutoID(cmd))
				cmd.ExecuteNonQuery("Insert into DDA_ApplicationData([Key],[Value]) values ('KOIID',0)");
			else
			{
				cmd.ExecuteNonQuery(string.Format("Update DDA_ApplicationData set [Value] = {0} where [Key] = 'KOIID'",KoiID));					
			}			
		}			


		private static DataSet GetResult(GeneralCmd cmd,Object[] objs)
		{
			DataSet dsResult = new DataSet();	
			//using temp table : storepro =  sp_Retrieve_EIS_KOI_Data
			dsResult = cmd.ExecuteDataset("DDA_KOI_DTS_Retrieve_EIS_KOI_Data",objs);			
			if (dsResult != null && dsResult.Tables.Count > 0)
				return dsResult;
			return null;
		}

		public static DataSet GetResultKOI(GeneralCmd cmd,Object[] objs)
		{
			DataSet dsResult = new DataSet();	
			//using temp table : storepro =  sp_Retrieve_EIS_KOI_Data,DDA_KOI_DTS_Retrieve_EIS_KOI_Data
			dsResult = cmd.ExecuteDataset("DDA_KOI_DTS_Retrieve_KOI_Data_TestLocal",objs);			
			if (dsResult != null && dsResult.Tables.Count > 0)
				return dsResult;
			return null;
		}

		public static DataSet GetResultEIS(GeneralCmd cmd,Object[] objs)
		{
			DataSet dsResult = new DataSet();	
			//using temp table : storepro =  sp_Retrieve_EIS_KOI_Data,DDA_KOI_DTS_Retrieve_EIS_KOI_Data
			dsResult = cmd.ExecuteDataset("DDA_EIS_DTS_Retrieve_EIS_Data_TestCocal",objs);			
			if (dsResult != null && dsResult.Tables.Count > 0)
				return dsResult;
			return null;
		}


		static string PersonalFolder = string.Empty;
		private static long AutoKOIID = 0;
		private static long AutoEISID = 0;
		public static void Process()
		{
			try
			{			
				AutoKOIID = 0;
				AutoEISID = 0;
				DateTime timeBegin = DateTime.Now;
				SiGlaz.Utility.RijndaelCrypto Crypto = new SiGlaz.Utility.RijndaelCrypto();
			
				if(!Directory.Exists(PersonalFolder))
					Directory.CreateDirectory(PersonalFolder);

				Settings settings  = new Settings();
				string fileName = string.Format("{0}\\settings.xml",PersonalFolder);
				if (!File.Exists(fileName))
					return;
				settings = Settings.Deserialize(fileName);
				if (settings == null)
					return;

				ConnectionParam connectParam = new ConnectionParam();
				connectParam.Database = settings.Database;
				connectParam.Password = Crypto.Decrypt(settings.Password);
				connectParam.Server = settings.Server;
				connectParam.Username = settings.UserName;
			
				#region Select And Insert
				GeneralCmd cmd = new GeneralCmd(connectParam);	
				                                                                                                             
				//cmd.TestConnection();				
				//				int numOfDay = settings.NumOfDays;
				//				DateTime testDate = DateTime.Now.AddDays(-1 * numOfDay);
				DateTime testDate = DateTime.Now.AddHours(-1.0 * settings.NumOfHours);

				SendMgs(string.Format("Begin process at {0}...:", DateTime.Now));
				//Get result KOI Param
				DataTable dtparam = GetKOIParam(cmd,2,testDate);
				DataTable dtEISParam = GetEISParam(cmd,2,testDate);

				int nLoopKOI = 0;
				if (dtparam != null)
					nLoopKOI = dtparam.Rows.Count;

				int nLoopEIS = 0;
				if (dtEISParam != null)
					nLoopEIS = dtEISParam.Rows.Count;

				#region Loop 1
				while (nLoopKOI > 0 || nLoopEIS > 0)
				{	
					if (dtparam != null)
					{
						#region Loop 2 KOI
						foreach (DataRow row in dtparam.Rows)
						{														
							if(exitProcess)
								return;
							//WriteOuput("Check info");
							if (row["LotNo"] == null || row["LotNo"] == System.DBNull.Value || row["SlotNum"] == null || row["SlotNum"] == DBNull.Value ||  row["TestCell"] == null || row["TestCell"] == DBNull.Value)
								continue;

							object []objs = new object[3];
						

							objs[0] = row["TestCell"];
							objs[1] = row["LotNo"];
							objs[2] = row["SlotNum"];
							//WriteOuput("Get result.");
							DataSet dsResult = GetResultKOI(cmd,objs);

							if (dsResult!= null && dsResult.Tables.Count > 0  && dsResult.Tables[0].Rows.Count > 0)
							{
								#region Insert KOI
								SendMgs(string.Format(" 	KOI:Insert with LotN = {0}, SlotNum = {1}, TestCell = {2}",row["LotNo"],row["SlotNum"],row["WordCellKey"]));
								if (!CheckIsExistsKOIHeader(cmd,row["LotNo"],row["SlotNum"]))
								{
									if ((dsResult.Tables[0].Rows[0]["KKLot"] == System.DBNull.Value
										&& dsResult.Tables[0].Rows[0]["KKSlot"] == System.DBNull.Value
										&& dsResult.Tables[0].Rows[0]["Cass_ID"] == System.DBNull.Value)
										||
										(dsResult.Tables[0].Rows[0]["KKLot"] == null
										&& dsResult.Tables[0].Rows[0]["KKSlot"] == null
										&& dsResult.Tables[0].Rows[0]["Cass_ID"] == null)
										)
										continue;
									
									if(row["LotNo"].ToString() == "")
										continue;

									object []objs2 = new object[5];							
									objs2[0] = row["LotNo"];
									objs2[1] = row["SlotNum"];							
									objs2[2] = dsResult.Tables[0].Rows[0]["KKLot"];
									objs2[3] = dsResult.Tables[0].Rows[0]["KKSlot"];
									objs2[4] = dsResult.Tables[0].Rows[0]["Cass_ID"];
									cmd.ExecuteDataset("DDA_DDA_KOI_Headers_Insert",objs2);
								}
								//Update cass_ID to DISKS table
								object []objs3 = new object[4];
								objs3[0] = row["LotNo"];
								objs3[1] = row["SlotNum"];
								objs3[2] = row["WordCellKey"];
								objs3[3] = dsResult.Tables[0].Rows[0]["Cass_ID"];
								cmd.ExecuteDataset("DDA_Disks_Update_CassID",objs3);							
								#endregion																
							}		
							else
							{
								//No Data when execute store pr
								SendMgs(string.Format(" 	There is no data when running store DDA_KOI_DTS_Retrieve_KOI_Dat with LotN = {0}, SlotNum = {1}, TestCell = {2}",row["LotNo"],row["SlotNum"],row["WordCellKey"]));
							}
							if(exitProcess)
								return;							
						}						
						#endregion									
					}
					
					if(exitProcess)
						return;

					if (dtEISParam != null)
					{
						#region Loop 2 EIS
						foreach (DataRow row in dtEISParam.Rows)
						{														
							if(exitProcess)
								return;
							//WriteOuput("Check info");
							if (row["LotNo"] == null || row["LotNo"] == System.DBNull.Value)
								continue;

							object []objs = new object[1];							
							objs[0] = row["LotNo"];
							//WriteOuput("Get result.");
							DataSet dsEISResult = GetResultEIS(cmd,objs);

							if (dsEISResult!= null && dsEISResult.Tables.Count > 0  && dsEISResult.Tables[0].Rows.Count > 0)
							{
								#region Insert KOI
								DataRow rowEIS = dsEISResult.Tables[0].Rows[0];
								if (!CheckIsExistsEISResource(cmd,rowEIS["Lotnum"]))
								{
									if ( 
										(rowEIS["Rsc450"] == System.DBNull.Value 
										&& rowEIS["Rsc453"] == System.DBNull.Value 
										&& rowEIS["Rsc600"] == System.DBNull.Value
										&& rowEIS["Rsc725"] == System.DBNull.Value 
										&& rowEIS["Rsc766"] == System.DBNull.Value
										&& rowEIS["Rsc769"] == System.DBNull.Value
										&& rowEIS["Rsc771"] == System.DBNull.Value
										&& rowEIS["Rsc764"] == System.DBNull.Value
										&& rowEIS["Rsc575"] == System.DBNull.Value)
										|| 
										(rowEIS["Rsc450"] == null 
										&& rowEIS["Rsc453"] == null
										&& rowEIS["Rsc600"] == null
										&& rowEIS["Rsc725"] == null
										&& rowEIS["Rsc766"] == null
										&& rowEIS["Rsc769"] == null
										&& rowEIS["Rsc771"] == null
										&& rowEIS["Rsc764"] == null
										&& rowEIS["Rsc575"] == null)
										)
										continue;
									SendMgs(string.Format(" 	EIS:Insert with LotN = {0}",row["LotNo"]));
									object []objs2 = new object[10];
									if (rowEIS["Lotnum"].ToString() == "")
										continue;

									objs2[0] = rowEIS["Lotnum"];
									objs2[1] = rowEIS["Rsc725"];
									objs2[2] = rowEIS["Rsc769"];
									objs2[3] = rowEIS["Rsc771"];
									objs2[4] = rowEIS["Rsc764"];
									objs2[5] = rowEIS["Rsc575"];
									objs2[6] = rowEIS["Rsc450"];
									objs2[7] = rowEIS["Rsc453"];
									objs2[8] = rowEIS["Rsc600"];
									objs2[9] = rowEIS["Rsc766"];
									cmd.ExecuteDataset("DDA_DDA_EIS_Resources_Insert",objs2);
								}							
								#endregion																
							}		
							else
							{
								//No Data when execute store pr
								SendMgs(string.Format(" 	There is no data when running store DDA_EIS_DTS_Retrieve_EIS_Data with LotN = {0}",row["LotNo"]));
							}
							if(exitProcess)
								return;							
						}
						#endregion
					}

					#region Update Param
					if (dtparam.Rows.Count > 0)
					{
						AutoKOIID = Convert.ToInt64(dtparam.Rows[dtparam.Rows.Count - 1]["DiskKey"]);
						dtparam.Rows.Clear();	
					}
					
					if(dtEISParam.Rows.Count > 0)
					{
						AutoEISID = Convert.ToInt64(dtEISParam.Rows[dtEISParam.Rows.Count - 1]["DiskKey"]);	
						dtEISParam.Rows.Clear();	
					}
					
					dtparam = GetKOIParam(cmd,10000,testDate);
					dtEISParam = GetEISParam(cmd,10000,testDate);

					if (dtparam != null)
						nLoopKOI = dtparam.Rows.Count;
					else
						nLoopKOI = 0;

					if (dtEISParam != null)
						nLoopEIS = dtEISParam.Rows.Count;
					else
						nLoopEIS = 0;

					if(exitProcess)
						return;

					#endregion					
				}
				#endregion

				SendMgs(string.Format("End process at {0}",DateTime.Now));
				DateTime timeEnd = DateTime.Now;				

				#endregion			
				TimeSpan timeSp = timeEnd - timeBegin;
				Double totalMinisecondsProcess = timeSp.TotalMilliseconds; 
				
				Double millisecondsParam = 0;
				if (settings.Schedule == eSchedule.byMinute)
					millisecondsParam =  1000*60*settings.ScheduleNum;
				else
					millisecondsParam =  1000*60*60*settings.ScheduleNum;

				Double totalMillisecondsSleep = millisecondsParam - totalMinisecondsProcess;
				
				if (totalMillisecondsSleep > 0)
					System.Threading.Thread.Sleep(Convert.ToInt32(totalMillisecondsSleep));

				if(exitProcess)
					return;
				
			}
			catch(System.Threading.ThreadInterruptedException)
			{
				throw;
			}
			catch (System.Exception ex)
			{
				SendMgs(string.Format("Cannot start process, retry after 60 seconds"));	
				//System.Threading.Thread.Sleep(1000*60);
				SiGlaz.Utility.Utility.WriteToTraceLog(ex,"Process");
			}
		}
		
	
	}
}

