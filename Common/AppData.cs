using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using SiGlaz.Common.DDA.Basic;
using System.Collections;

namespace SiGlaz.Common.DDA
{
	/// <summary>
	/// Summary description for AppData.
	/// </summary>
	/// 
	[Serializable]
	public class AppData
	{
		[XmlIgnore]
		public static string ApplicationDataPath = string.Format("{0}\\SiGlaz\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Application.ProductName);

		[XmlIgnore]
		public static string CommonApplicationDataPath = string.Format("{0}\\SiGlaz\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), Application.ProductName);

		[XmlIgnore]
		public static TableLayout CommonTableLayout;

		public static string GetApplicationDataPath(string productname)
		{
			 return string.Format("{0}\\SiGlaz\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), productname);
		}

		public static string GetCommonApplicationDataPath(string productname)
		{
			return string.Format("{0}\\SiGlaz\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),productname);
		}


		private static AppData _Data = new AppData();

		/// <summary>
		/// Use Web Service or Connect direct to database
		/// </summary>
		public		bool				UseWebService = true;

		public		WebServiceLinkList	WebServiceList = null;
		public		string				DDAPath  = string.Empty;
		public		SiGlaz.Common.DDA.DDADBType DBType = SiGlaz.Common.DDA.DDADBType.DDADB;
		public		int					NumberOfProcessToReStart = 1000;
		private		System.Diagnostics.Process _DDAProcess;
		public		bool				UsingIDAPortalWebService = true;

		public		short				FabKey = 0;
		public		ArrayList			RunningRecipeIDList = new ArrayList();
		public		int MaxRow			= 10000;

		public		int					ListenWaitingSecond = 60;//seconds
		public		int					ListenWaitingSecondFolder = 5;
		public		int					WaitingToRetryError = 60;
		public		int					WaitingToMoreInformation = 60;
		public		bool				ShowProcessStep = false;

		public		int					WaitingToStartupSecond = 60*5;

		public		Basic.TimeFilter	ProcessSurfaceFromDate = null;
		public		Basic.GradeCondition ProcessSurfaceMore = null;

		//2010-01-24 by Cang
		public		bool				AllowMultiApplicationServer = false;//Global Variable sys to DDADB
		public		bool				AllowTrackProcessingTime = false;
		public		int					OperationHours = 24;


		public string ServerName = "(local)";
		public string DatabaseName = "DDADB";
		public string UserName = "DDADBUser";
		public string Password = "sCDlZ0SbkN+5R0GVZTZZPc+oY2C6xOZCn2dRGwA6b2c=";


		public AppData()
		{
			DDAPath  = string.Format("{0}\\SiGlaz\\Disk Defect Analyzer\\DDA.exe", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
			WebServiceList = new WebServiceLinkList();
			WebServiceList[WebServicetypeType.Root] = "http://localhost/DDAWebService";
		}

		public	static AppData Data
		{
			get
			{
				return _Data;
			}
		}

		public void LoadApplicationData(byte[] lpbyte)
		{
			if( lpbyte==null) 
			{
				ProcessSurfaceFromDate = new TimeFilter();
				ProcessSurfaceFromDate.Type = TimeRangeType.LastNHours;
				ProcessSurfaceFromDate.N = -1;

				return;//keep default
			}

			AppData obj = SiGlaz.Common.XmlSerializeCommon.Deserialize(lpbyte,typeof(AppData)) as AppData;
			obj.WebServiceList.WebServiceLinksArrayToHash();
			this.CopyFrom(obj);
		}

		public void LoadApplicationData(string filepath)
		{
			if( !System.IO.File.Exists(filepath))
			{
				ProcessSurfaceFromDate = new TimeFilter();
				ProcessSurfaceFromDate.Type = TimeRangeType.LastNHours;
				ProcessSurfaceFromDate.N = -1;

				return;//keep default
			}

			AppData obj = SiGlaz.Common.XmlSerializeCommon.Deserialize(filepath,typeof(AppData)) as AppData;
			obj.WebServiceList.WebServiceLinksArrayToHash();
			this.CopyFrom(obj);
		}

		public byte[] SaveApplicationData()
		{
			this.WebServiceList.WebServiceLinksHashToArray();
			return SiGlaz.Common.XmlSerializeCommon.Serialize(this);
		}

		public void SaveApplicationData(string filepath)
		{
			this.WebServiceList.WebServiceLinksHashToArray();
			SiGlaz.Common.XmlSerializeCommon.Serialize(filepath,this);
		}

		public void CopyFrom(AppData source)
		{
			this.WebServiceList = source.WebServiceList;//copy reference
			this.DDAPath = source.DDAPath;
			this.UseWebService = source.UseWebService;
			this.NumberOfProcessToReStart = source.NumberOfProcessToReStart;
			this.UsingIDAPortalWebService = source.UsingIDAPortalWebService;
			this.FabKey = source.FabKey;
			this.RunningRecipeIDList = source.RunningRecipeIDList;
			this.MaxRow = source.MaxRow;
			//this.FabID = source.FabID;
			this.DBType = source.DBType;

			this.ListenWaitingSecond = source.ListenWaitingSecond;
			this.ListenWaitingSecondFolder = source.ListenWaitingSecondFolder;
			this.WaitingToRetryError = source.WaitingToRetryError;
			this.WaitingToMoreInformation = source.WaitingToMoreInformation;

			this.ShowProcessStep = source.ShowProcessStep;
			this.WaitingToStartupSecond = source.WaitingToStartupSecond;

			this.ProcessSurfaceFromDate=source.ProcessSurfaceFromDate;

			this.ProcessSurfaceMore=source.ProcessSurfaceMore;

			this.ServerName = source.ServerName;
			this.DatabaseName = source.DatabaseName;
			this.UserName = source.UserName;
			this.Password = source.Password;
		}

		[XmlIgnore()]
		public System.Diagnostics.Process DDAProcess
		{
			get
			{
				if( _DDAProcess == null) return null;
				System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("DDA");
				foreach (System.Diagnostics.Process p in processes)
				{
					if( p.Id == _DDAProcess.Id)
						return _DDAProcess;
				}
				_DDAProcess = null;
				return null;
			}
			set
			{
				_DDAProcess = value;
			}
		}

		public static string GenProductID()
		{
			string sbase="0123456789ABCDEFGHIJKLMNOPQRSTUVXYZ";//abcdefghijklmnopqrstuvxyz";
			//8-4-4-4-12
			Random rnd=new Random();

			string sgen="";
			for(int i=0;i<8;i++)
				sgen+= sbase[rnd.Next(sbase.Length)];
			sgen+="-";
			for(int i=0;i<4;i++)
				sgen+= sbase[rnd.Next(sbase.Length)];
			sgen+="-";
			for(int i=0;i<4;i++)
				sgen+= sbase[rnd.Next(sbase.Length)];
			sgen+="-";
			for(int i=0;i<4;i++)
				sgen+= sbase[rnd.Next(sbase.Length)];
			sgen+="-";
			for(int i=0;i<12;i++)
				sgen+= sbase[rnd.Next(sbase.Length)];

			return sgen;
		}


	}
}
