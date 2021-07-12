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

namespace KOIDTS_DDA_Service
{	
	public class ServerProcess : IDisposable
	{
		public const int CACHE_SIZE = 10000;

		public ServerProcess()
		{
			Init();
		}

		public void Init()
		{
			_name = "SiGlaz_KOIDTS_Client";
			_servername = "SiGlaz_KOIDTS_Server";

			_echeckname =  "Global\\" + _name ;
			_echecknameraise = "Global\\" + _servername;

			PersonalFolder = SiGlaz.Common.DDA.AppData.GetCommonApplicationDataPath("KOIDTSCmd");

			LoadStatusExexcute();//Load va chay dau tien ... neu nhu stop va start lai services
			
			InitRemote();

			//ListenEvent();//waiting here
			(new Thread(new ThreadStart(ListenEvent))).Start();
			#region Mutex API

			InitEvent();

			#endregion

		}

		#region Remoting
		private void InitRemote()
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
			KOIDTSSimpleMsg.Cache.GetInstance().InitRemoting();            
		}

		private void SendMgs(string msg)
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
		public string _name = string.Empty;
		public string _echeckname =  string.Empty;
		public IntPtr _echeck = IntPtr.Zero;

		public string _servername = string.Empty;
		public string _echecknameraise = string.Empty;
		public IntPtr _echeckraise = IntPtr.Zero;

		public AutoResetEvent restartEvent = null;

		public bool		IsRunning = false;

		public void InitEvent()
		{
			IntPtr securityDescPtr = new IntPtr( 0 );
			IntPtr eventAttributesPtr = new IntPtr( 0 );

			Kernel32.SECURITY_DESCRIPTOR sd = new SiGlaz.Utility.Wind32.Kernel32.SECURITY_DESCRIPTOR();
			Kernel32.InitializeSecurityDescriptor(out sd,(uint)1);
			Kernel32.SetSecurityDescriptorDacl(ref sd,true,IntPtr.Zero,false);
			Kernel32.SECURITY_ATTRIBUTES sa = new SiGlaz.Utility.Wind32.Kernel32.SECURITY_ATTRIBUTES();
			sa.nLength = Marshal.SizeOf(sa);
			securityDescPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(sd));
			Marshal.StructureToPtr(sd,securityDescPtr,false);
			sa.lpSecurityDescriptor = securityDescPtr;
 
			eventAttributesPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(sa));
			Marshal.StructureToPtr(sa,eventAttributesPtr,false);

			_echeck = Kernel32.CreateEvent(eventAttributesPtr,true,false,_echeckname);
			if(_echeck==IntPtr.Zero)
			{
				throw new Exception("Cannot create " + _echeckname + " event");
			}
			Kernel32.ResetEvent(_echeck);

			_echeckraise = Kernel32.CreateEvent( eventAttributesPtr,true,false,_echecknameraise);
			if(_echeckraise==IntPtr.Zero)
			{
				throw new Exception("Cannot create " + _echecknameraise + " event");
			}
			//ResetEvent(_echeckraise);

			SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogInformation("xong InitEvent");
		}


		public void FreeEvent()
		{
			exitListen = true;

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
		
		private bool exitListen = false;
		public void ListenEvent()
		{
			//SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogInformation("ListenEvent");

			while (!exitListen)
			{
				Kernel32.WaitForSingleObject(_echeck,int.MaxValue);
				if(exitListen)
					return;

				//SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogInformation("cho ListenEvent");

				Kernel32.ResetEvent(_echeck);

				//Get status
				LoadStatusExexcute();
			}
		}
		#endregion
	
		public void WriteOuput(string msg)
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
				//lck.Release();
				//lck.Dispose();
			}
			Kernel32.SetEvent(_echeckraise);
		}


		public void StopProcess()
		{
			if(threadProcess!=null)
			{
				exitProcess = true;
				threadProcess.Interrupt();
			}
		}

		public void StopKOIProcess()
		{
			if(threadProcessKOI!=null)
			{
				exitProcess = true;
				threadProcessKOI.Interrupt();
			}
		}

		public void StopEISProcess()
		{
			if(threadProcessEIS!=null)
			{
				exitProcess = true;
				threadProcessEIS.Interrupt();
			}
		}


		public void LoadStatusExexcute()
		{
			//Get status
			string fileName =string.Format("{0}\\{1}",PersonalFolder,_name);
			SiGlaz.Common.Configuration.LoadData(fileName);	
						
			IsRunning = (bool)SiGlaz.Common.Configuration.GetValues("RUNNING_STATUS",false);

			if(restartEvent==null)
				restartEvent = new AutoResetEvent(true);


			//SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogInformation("truoc restartEvent.WaitOne();");

			if(IsRunning)
			{
				restartEvent.WaitOne();
				StartProcessEIS();
				StartProcessKOI();
				//StartProcess();
			}
			else
			{
				//StopProcess();
				StopEISProcess();
				StopKOIProcess();
			}

			//SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogInformation("sau restartEvent.WaitOne();");
		}


		public Thread threadProcess = null;
		public Thread threadProcessKOI = null;
		public Thread threadProcessEIS = null;

		public void StartProcessKOI()
		{
			threadProcessKOI = new Thread(new ThreadStart(StartProcessKOIThread));
			threadProcessKOI.IsBackground = true;
			threadProcessKOI.Start();
		}

		public void StartProcessEIS()
		{
			threadProcessEIS = new Thread(new ThreadStart(StartProcessEISThread));
			threadProcessEIS.IsBackground = true;
			threadProcessEIS.Start();
		}

		public void StartProcess()
		{
			threadProcess = new Thread(new ThreadStart(StartProcessThread));
			threadProcess.IsBackground = true;
			threadProcess.Start();
		}
		

		public bool exitProcess = false;
		public void StartProcessKOIThread()
		{
			try
			{
				while(!exitProcess)
					ProcessKOI();
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

		public void StartProcessEISThread()
		{
			try
			{
				while(!exitProcess)
					ProcessEIS();
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

		public void StartProcessThread()
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

		public DataTable GetKOIParam(GeneralCmd cmd, int numTop, DateTime testDate)
		{
			DataSet ds = new DataSet();	
			object []objs = new object[3];
			objs[0] = numTop;
			objs[1] = AutoKOIID;
			objs[2] = testDate;

			SendMgs(string.Format("Begin load KOI at {0}...:", DateTime.Now));

			ds = cmd.ExecuteDataset("GET_KOI_PARAM",objs);		
	
			if (ds != null && ds.Tables.Count > 0)
			{
				SendMgs(string.Format("Finish load KOI at {0}...Total {1}", DateTime.Now,ds.Tables[0].Rows.Count));
				return ds.Tables[0];		
			}

			SendMgs(string.Format("Finish load KOI at {0}...no data", DateTime.Now));
			return null;
		}

		public DataTable GetEISParam(GeneralCmd cmd, int numTop, DateTime testDate)
		{
			DataSet ds = new DataSet();	
			object []objs = new object[3];
			objs[0] = numTop;
			objs[1] = AutoEISID;
			objs[2] = testDate;

			SendMgs(string.Format("Begin load EIS at {0}...:", DateTime.Now));

			ds = cmd.ExecuteDataset("GET_EIS_PARAM",objs);			
			if (ds != null && ds.Tables.Count > 0)
			{
				SendMgs(string.Format("Finish load EIS at {0}...Total {1}", DateTime.Now,ds.Tables[0].Rows.Count));
				return ds.Tables[0];	
			}

			SendMgs(string.Format("Finish load EIS at {0}...no data", DateTime.Now));
			return null;
		}	

		private long AutoKOIID = 0;
		private long AutoEISID = 0;
		private long GetAutoID(GeneralCmd cmd)
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
					return Convert.ToInt64(ds.Tables[0].Rows[0][0]);
				return 0;
			}
		}

		private bool CheckIsExistsAutoID(GeneralCmd cmd)
		{			
			return cmd.CheckExistSQL("select top 1 1 from DDA_ApplicationData where [Key] = 'KOIID'");		
		}

		private static bool CheckIsExistsKOIHeader(GeneralCmd cmd, object LotNo, object SlotNum)
		{
			return cmd.CheckExistSQL(string.Format("select top 1 1 from DDA_KOI_Headers where Lot_Id = '{0}' AND Lot_Slot = '{1}'",LotNo,SlotNum));		
		}

		private static bool CheckIsExistsEISResource(GeneralCmd cmd, object LotNo)
		{
			return cmd.CheckExistSQL(string.Format("select top 1 1 from DDA_EIS_Resources where LotNum = '{0}'",LotNo));		
		}

		private void UpdateNewAutoID(GeneralCmd cmd, int KoiID)
		{
			if (!CheckIsExistsAutoID(cmd))
				cmd.ExecuteNonQuery("Insert into DDA_ApplicationData([Key],[Value]) values ('KOIID',0)");
			else
			{
				cmd.ExecuteNonQuery(string.Format("Update DDA_ApplicationData set [Value] = {0} where [Key] = 'KOIID'",KoiID));					
			}			
		}

		public DataSet GetResultKOI(GeneralCmd cmd,Object[] objs)
		{
			DataSet dsResult = new DataSet();	
			//using temp table : storepro =  DDA_KOI_DTS_Retrieve_KOI_Data_TestLocal,DDA_KOI_DTS_Retrieve_EIS_KOI_Data
			dsResult = cmd.ExecuteDataset("DDA_KOI_DTS_Retrieve_KOI_Data",objs);			
			if (dsResult != null && dsResult.Tables.Count > 0)
				return dsResult;
			return null;
		}

		public DataSet GetResultEIS(GeneralCmd cmd,Object[] objs)
		{
			DataSet dsResult = new DataSet();	
			//using temp table : storepro =  DDA_EIS_DTS_Retrieve_EIS_Data_TestCocal,DDA_KOI_DTS_Retrieve_EIS_KOI_Data
			dsResult = cmd.ExecuteDataset("DDA_EIS_DTS_Retrieve_EIS_Data",objs);			
			if (dsResult != null && dsResult.Tables.Count > 0)
				return dsResult;
			return null;
		}
		
		int nullcountKOI = 0;
		int nullcountEIS = 0;

		void CheckKOINumCount()
		{
			nullcountKOI++;
			if(nullcountKOI>=1000)
			{
				SendMgs("1000 KOI data has null value");
				nullcountKOI=0;
			}
		}

		void CheckEISNumCount()
		{
			nullcountEIS++;
			if(nullcountEIS>=1000)
			{
				SendMgs("1000 EIS data has null value");
				nullcountEIS=0;
			}
		}

		public string PersonalFolder = string.Empty;

		public void ProcessKOI()
		{
			try
			{			
				AutoKOIID = 0;

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
				                                                                                                             
				DateTime testDate = DateTime.Now.AddHours(-1.0 * settings.NumOfHours);

				SendMgs(string.Format("Begin process at {0}...:", DateTime.Now));

				//Get result KOI Param
				DataTable dtparam = GetKOIParam(cmd,CACHE_SIZE,testDate);

				int nLoopKOI = 0;
				if (dtparam != null)
					nLoopKOI = dtparam.Rows.Count;

				nullcountKOI = 0;

				#region Loop 1
				while (nLoopKOI > 0)
				{	
					if (dtparam != null)
					{
						#region Loop 2 KOI
						foreach (DataRow row in dtparam.Rows)
						{														
							if(exitProcess)
								return;
							
							if (row["LotNo"] == null || row["LotNo"] == System.DBNull.Value || row["SlotNum"] == null || row["SlotNum"] == DBNull.Value ||  row["TestCell"] == null || row["TestCell"] == DBNull.Value)
							{
								CheckKOINumCount();
								continue;
							}

							object []objs = new object[3];
						

							objs[0] = row["TestCell"];
							objs[1] = row["LotNo"];
							objs[2] = row["SlotNum"];
							//WriteOuput("Get result.");
							DataSet dsResult = GetResultKOI(cmd,objs);

							if (dsResult!= null && dsResult.Tables.Count > 0  && dsResult.Tables[0].Rows.Count > 0)
							{
								#region Insert KOI								
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
									{
										CheckKOINumCount();
										continue;
									}
									
									SendMgs(string.Format(" 	KOI:Insert with LotN = {0}, SlotNum = {1}, TestCell = {2}",row["LotNo"],row["SlotNum"],row["WordCellKey"]));
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

					#region Update Param
					if (dtparam.Rows.Count > 0)
					{
						AutoKOIID = Convert.ToInt64(dtparam.Rows[dtparam.Rows.Count - 1]["DiskKey"]);
						dtparam.Rows.Clear();	
					}
					
					//Check process data
					if(nLoopKOI < CACHE_SIZE && nLoopKOI <= nullcountKOI)
						break;

					dtparam = GetKOIParam(cmd,CACHE_SIZE,testDate);

					if (dtparam != null)
						nLoopKOI = dtparam.Rows.Count;
					else
						nLoopKOI = 0;

					nullcountKOI = 0;

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
				System.Threading.Thread.Sleep(1000*60);
				SiGlaz.Utility.Utility.WriteToTraceLog(ex,"Process");
			}
		}


		public void ProcessEIS()
		{
			try
			{			
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
				                                                                                                             
				DateTime testDate = DateTime.Now.AddHours(-1.0 * settings.NumOfHours);

				SendMgs(string.Format("Begin process at {0}...:", DateTime.Now));

				//Get result KOI Param
				DataTable dtEISParam = GetEISParam(cmd,CACHE_SIZE,testDate);

				int nLoopEIS = 0;
				if (dtEISParam != null)
					nLoopEIS = dtEISParam.Rows.Count;

				nullcountEIS = 0;

				#region Loop 1
				while (nLoopEIS > 0)
				{	
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
							{
								CheckEISNumCount();
								continue;
							}

							long result = cmd.ExecuteScalarProc("spDDA2EISCopyData", row["LotNo"]);

							if( result== 0 )
							{
								CheckEISNumCount();
								continue;
							}
							else if( result == 1 )
							{
								SendMgs(string.Format("EIS - Insert Lot : {0} ",row["LotNo"]));
							}

							if(exitProcess)
								return;							
						}
						#endregion
					}

					#region Update Param
				
					if(dtEISParam.Rows.Count > 0)
					{
						AutoEISID = Convert.ToInt64(dtEISParam.Rows[dtEISParam.Rows.Count - 1]["DiskKey"]);	
						dtEISParam.Rows.Clear();	
					}

					//Check process data
					if( nLoopEIS < CACHE_SIZE && nLoopEIS <= nullcountEIS)
						break;

					dtEISParam = GetEISParam(cmd,CACHE_SIZE,testDate);

					if (dtEISParam != null)
						nLoopEIS = dtEISParam.Rows.Count;
					else
						nLoopEIS = 0;

					nullcountEIS = 0;

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
				System.Threading.Thread.Sleep(1000*60);
				SiGlaz.Utility.Utility.WriteToTraceLog(ex,"Process");
			}
		}


		public void Process()
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
				DataTable dtparam = GetKOIParam(cmd,CACHE_SIZE,testDate);
				DataTable dtEISParam = GetEISParam(cmd,CACHE_SIZE,testDate);

				int nLoopKOI = 0;
				if (dtparam != null)
					nLoopKOI = dtparam.Rows.Count;

				int nLoopEIS = 0;
				if (dtEISParam != null)
					nLoopEIS = dtEISParam.Rows.Count;

				nullcountKOI = 0;
				nullcountEIS = 0;

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
							
							if (row["LotNo"] == null || row["LotNo"] == System.DBNull.Value || row["SlotNum"] == null || row["SlotNum"] == DBNull.Value ||  row["TestCell"] == null || row["TestCell"] == DBNull.Value)
							{
								CheckKOINumCount();
								continue;
							}

							object []objs = new object[3];
						

							objs[0] = row["TestCell"];
							objs[1] = row["LotNo"];
							objs[2] = row["SlotNum"];
							//WriteOuput("Get result.");
							DataSet dsResult = GetResultKOI(cmd,objs);

							if (dsResult!= null && dsResult.Tables.Count > 0  && dsResult.Tables[0].Rows.Count > 0)
							{
								#region Insert KOI								
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
									{
										CheckKOINumCount();
										continue;
									}
									
									SendMgs(string.Format(" 	KOI:Insert with LotN = {0}, SlotNum = {1}, TestCell = {2}",row["LotNo"],row["SlotNum"],row["WordCellKey"]));
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
							{
								CheckEISNumCount();
								continue;
							}

							if( cmd.ExecuteScalarProc("spDDA2EISCopyData", row["LotNo"]) == 0 )
							{
								CheckEISNumCount();
								continue;
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

					//Check process data
					if( (nLoopKOI < CACHE_SIZE && nLoopKOI <= nullcountKOI)
						&&
						(nLoopKOI < CACHE_SIZE && nLoopEIS <= nullcountEIS)
						)
						break;

					dtparam = GetKOIParam(cmd,CACHE_SIZE,testDate);
					dtEISParam = GetEISParam(cmd,CACHE_SIZE,testDate);

					if (dtparam != null)
						nLoopKOI = dtparam.Rows.Count;
					else
						nLoopKOI = 0;

					if (dtEISParam != null)
						nLoopEIS = dtEISParam.Rows.Count;
					else
						nLoopEIS = 0;

					nullcountKOI = 0;
					nullcountEIS = 0;

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
				System.Threading.Thread.Sleep(1000*60);
				SiGlaz.Utility.Utility.WriteToTraceLog(ex,"Process");
			}
		}


		#region IDisposable Members

		protected virtual void Dispose( bool disposing )
		{
			// Only clean up managed resources if being called from IDisposable.Dispose
			if( disposing )
			{
			}

			// always clean up unmanaged resources
			FreeEvent();
		}

		~ServerProcess()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
			Dispose(true);
		}

		#endregion
	}
}

