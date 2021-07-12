using System;
using System.IO;
using System.Diagnostics;

namespace SiGlaz.Utility
{
	/// <summary>
	/// Summary description for DebugLog.
	/// </summary>
	public class DebugLog
	{
		public static int LogFileSize = 2048 * 1024;
		public static string LogFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TraceLog");
		public static string LogFilePath = string.Empty;
		private static object _SynObject = new object();

		private static void GenerateFileName()
		{
			LogFilePath = Path.Combine(LogFolderPath, String.Format("{0}.txt", DateTime.Now.ToString("yyyy-MM-dd")));
			
			int fileIndex = 1;
			while (File.Exists(LogFilePath))
			{
				FileInfo info = new FileInfo(LogFilePath);
				if (info.Length >= LogFileSize)
					LogFilePath = Path.Combine(LogFolderPath, String.Format("{0}_{1}.txt", DateTime.Now.ToString("yyyy-MM-dd"), fileIndex++));
				else
					break;
			}
		}

		public static void Write(string text,string file)
		{
			text = "[FILE] " + text;
			Write(text);
		}

		public static void Write(Exception ex,string file)
		{
			string msg = String.Format("[FILE] : {0} MESSAGE : {1} STACKTRACE : {2}", file, ex.Message,ex.StackTrace);
			Write(msg);
		}

		public static void Write(Exception ex)
		{
			string msg = String.Format("MESSAGE : {0} STACKTRACE : {1}",ex.Message,ex.StackTrace);
			Write(msg);
		}

        public static void Write(string text)
		{
			lock(_SynObject)//make sure only one log at the time
			{
				GenerateFileName();

				SiGlaz.Utility.FileUtils.CreateDirectory(LogFolderPath);

				FileStream stream  = null;
				StreamWriter sw = null;
			
				try
				{
					stream = new FileStream(LogFilePath, FileMode.Append, FileAccess.Write,FileShare.ReadWrite);
					sw = new StreamWriter(stream);

					sw.WriteLine("------------------------" + Environment.NewLine);
					sw.WriteLine(String.Format("{0} : {1}", DateTime.Now.ToString("HH:mm:ss"), text));
				}
				catch//(Exception ex)
				{
					//Debug.WriteLine(ex.Message);
					//skip any exception here
				}
				finally
				{
				
					if ( sw != null ) 
					{
						sw.Close();
						sw = null;
					}

					if ( stream != null )
					{
						stream.Close();
						stream = null;
					}
				}
			}
		}


	}
}
