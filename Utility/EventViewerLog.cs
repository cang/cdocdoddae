using System;
using System.Diagnostics;
using Microsoft.Win32;


namespace SiGlaz.Utility
{
	/// <summary>
	/// Summary description for EventViewerLog.
	/// </summary>
	public class EventViewerLog
	{
		public static EventViewerLog GlobalLog = new EventViewerLog("DDADB Services");

		public string LogName = "Disk Defect Analyzer";
		public string SourceName = string.Empty;

		public EventLog log = null;

        public EventViewerLog(string SourceName)
		{
			this.SourceName = SourceName;
			log = new EventLog(this.LogName,".",this.SourceName);
		}

		public void CreateSource()
		{
			Delete();

			//Check and resize Source Log
			string regString = @"SYSTEM\CurrentControlSet\Services\Eventlog\" + LogName;
			RegistryKey regItem=Registry.LocalMachine.OpenSubKey(regString,true);
			if(regItem==null )
				regItem=Registry.LocalMachine.CreateSubKey(regString);

			if( regItem.GetValue("MaxSize") == null)
				regItem.SetValue("MaxSize", (int)(1024*1024*10) );

			if( regItem.GetValue("Retention") == null)
				regItem.SetValue("Retention", (int)0 );
			regItem.Close();

			//Create All Source
			EventLog.CreateEventSource("DDADB Services",this.LogName);
			EventLog.CreateEventSource("DDA Database Manager",this.LogName);
			EventLog.CreateEventSource("DDA Recipe Manager",this.LogName);
			EventLog.CreateEventSource("DDA Recipe Process",this.LogName);
		}


		string []sourceslist;
		public void CreateSource(params string []sources)
		{
			Delete();

			//Check and resize Source Log
			string regString = @"SYSTEM\CurrentControlSet\Services\Eventlog\" + LogName;
			RegistryKey regItem=Registry.LocalMachine.OpenSubKey(regString,true);
			if(regItem==null )
				regItem=Registry.LocalMachine.CreateSubKey(regString);

			if( regItem.GetValue("MaxSize") == null)
				regItem.SetValue("MaxSize", (int)(1024*1024*10) );

			if( regItem.GetValue("Retention") == null)
				regItem.SetValue("Retention", (int)0 );
			regItem.Close();

			//Create Source
			sourceslist = sources;
			if(sourceslist!=null && sourceslist.Length>0)
			{
				foreach(string source in sourceslist)
					EventLog.CreateEventSource(source,this.LogName);
			}
		}

		public void Delete()
		{
			if(EventLog.SourceExists("DDADB Services"))
				EventLog.DeleteEventSource("DDADB Services");

			if(EventLog.SourceExists("DDA Database Manager"))
				EventLog.DeleteEventSource("DDA Database Manager");

			if(EventLog.SourceExists("DDA Recipe Manager"))
				EventLog.DeleteEventSource("DDA Recipe Manager");

			if(EventLog.SourceExists("DDA Recipe Process"))
				EventLog.DeleteEventSource("DDA Recipe Process");

			if(EventLog.Exists(this.LogName))
				EventLog.Delete(this.LogName);

			if(sourceslist!=null && sourceslist.Length>0)
			{
				foreach(string source in sourceslist)
				{
					if(EventLog.SourceExists(source))
						EventLog.DeleteEventSource(source);
				}
				sourceslist = null;
			}

		}

		public void WriteLogError(string message)
		{
			this.WriteLog(message,EventLogEntryType.Error);
		}

		public void WriteLogError(Exception ex)
		{
			string msg = String.Format("{0} : MESSAGE : {1} STACKTRACE : {2}", DateTime.Now.ToString("HH:mm:ss"), ex.Message,ex.StackTrace);
			this.WriteLog(msg,EventLogEntryType.Error);
		}

		public void WriteLogInformation(string message)
		{
			this.WriteLog(message,EventLogEntryType.Information);
		}

		public void WriteLog(string message,EventLogEntryType logType)
		{
			try
			{
				string msg = String.Format("{0} : {1}", DateTime.Now.ToString("HH:mm:ss"), message);
				log.WriteEntry(msg,logType);
			}
			catch
			{
			}
		}

	}
}
