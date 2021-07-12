using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Security;
using System.Security.Permissions;
using System.Diagnostics;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.InteropServices;

namespace SiGlaz.Utility
{
	public class Utility
	{
		public Utility()
		{
		}

		#region WriteToTraceLog
		public static string fpTraceLog="";
		public static string GenTraceLogFilename()
		{
			const long maxsize=1024*1024;//1MB
			if(!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LOG")))
				Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LOG"));

			if(fpTraceLog=="")
				fpTraceLog=String.Format("{0}\\LOG\\TraceLog_{1}_{2}.txt",AppDomain.CurrentDomain.BaseDirectory, System.Diagnostics.Process.GetCurrentProcess().Id,DateTime.Now.ToString("yy_MM_dd_HH_mm_ss"));
			else if( File.Exists(fpTraceLog) )
			{
				//check size
				FileInfo ofi=new FileInfo(fpTraceLog);
				if( ofi.Length > maxsize )
				{
					//create new file name
					fpTraceLog=String.Format("{0}\\LOG\\TraceLog_{1}_{2}.txt",AppDomain.CurrentDomain.BaseDirectory, System.Diagnostics.Process.GetCurrentProcess().Id,DateTime.Now.ToString("yy_MM_dd_HH_mm_ss"));
				}
				ofi=null;
			}

			if(!File.Exists(fpTraceLog) )
			{
				FileStream fs=null;
				StreamWriter sw=null;
				Assembly executingAssembly = null;
				try
				{
					fs=new FileStream(fpTraceLog,FileMode.Create,FileAccess.Write);
					sw=new StreamWriter(fs);

					executingAssembly = Assembly.GetExecutingAssembly();

					//Add Version
					string sversion = string.Format( "==========================================================\r\n TraceLog Version on Date : {0}\r\n==========================================================\r\n",File.GetLastWriteTime(Application.ExecutablePath).ToString("yyyy-MM-dd") );
					sw.WriteLine(sversion);
					sversion=null;
				}
				catch
				{
				}
				finally
				{
					if(sw!=null)
						sw.Close();
					if(fs!=null)
						fs.Close();

					executingAssembly = null;
				}
			}

			return fpTraceLog;
		}

		public static void WriteToTraceLog(object my_obj,string Desc)
		{
			TextWriterTraceListener oListener = null;
			FileStream fs=null;
			try
			{
				fs=new FileStream(GenTraceLogFilename(),FileMode.Append,FileAccess.Write);
				oListener =	new TextWriterTraceListener(fs);
				System.Diagnostics.Trace.Listeners.Clear();
				System.Diagnostics.Trace.Listeners.Add(oListener);

				Exception EX=null;
				if(my_obj!=null)
					EX=(Exception)my_obj;

				System.Diagnostics.Trace.WriteLine(DateTime.Now.ToString() +"----------------------------------------------------");
				if(EX!=null)
				{
					System.Diagnostics.Trace.WriteLine("(Message) : " + EX.Message );
					if(EX.TargetSite!=null)
						System.Diagnostics.Trace.WriteLine("(TargetSite) : " + EX.TargetSite.Name );
					System.Diagnostics.Trace.WriteLine("(StackTrace) : " + EX.StackTrace );
					System.Diagnostics.Trace.WriteLine("(ToString) : " + EX.ToString());
				}
				System.Diagnostics.Trace.WriteLine("(Desc) : " + Desc);
				//System.Diagnostics.Trace.WriteLine("(Schema) : " + GlobalData.m_SchemaCtrl.m_strDocumentFileName);
				System.Diagnostics.Trace.WriteLine(DateTime.Now.ToString() +"----------------------------------------------------");

				System.Diagnostics.Trace.Flush();
			}
			catch //( Exception ex )
			{
				//string a ="";
			}
			finally
			{
				System.Diagnostics.Trace.Listeners.Remove(oListener);
				if ( oListener != null ) 
					oListener.Close();
				if(fs!=null)
					fs.Close();
			}
		}

		public static void WriteToTraceLog(string Desc)
		{
			WriteToTraceLog(null,Desc);
		}

		#endregion

		public static string GetValueByFieldName(string fieldName, ArrayList conditions)
		{
			string value = string.Empty;
			
			foreach (string condition in conditions)
			{
				string tmpName = condition.Substring(0, condition.IndexOf(' '));
				if (fieldName.ToUpper() == tmpName.ToUpper())
				{
					value = condition.Replace(fieldName, "");
					value = value.Replace(" = ", "").Replace(" LIKE ", "");
					value = value.Replace(" OR ", "; ");
					value = value.Replace("'", "");
				}
			}

			return value;
		}

		public static string GetBasicQueryCondition(string fieldName, string value)
		{
			string condition = string.Empty;

			if (value != string.Empty)
			{
				string[] s = value.Split(";".ToCharArray());
				string str = string.Empty;

				foreach (string ss in s)
				{
					str = ss.Trim();
					str = str.Replace("'", "");
	
					if (str == string.Empty) continue;
					
					if (fieldName.ToUpper() != "SlotNoType".ToUpper())
					{
						if (str.IndexOf("%") >= 0 || str.IndexOf("*") >= 0)
							condition += string.Format("{0} LIKE '{1}' OR ", fieldName, str);
						else
							condition += string.Format("{0} = '{1}' OR ", fieldName, str);
					}
					else
						condition += string.Format("{0} = {1} OR ", fieldName, str);
				}

				if (condition != string.Empty)
					condition = condition.Substring(0, condition.Length - 4);
			}

			return condition;
		}

		public static bool CheckFieldNumeric(string condition)
		{
			bool result = true;

			if (condition != string.Empty)
			{
				string[] s = condition.Split(";".ToCharArray());
				string str = string.Empty;

				foreach (string ss in s)
				{
					str = ss.Trim();

					if (str == string.Empty) continue;
					
					if (!IsNumeric(str))
					{
						result = false;
						break;
					}
					else if (Convert.ToInt32(str) < -1)
					{
						result = false;
						break;
					}
				}
			}

			return result;
		}

		public static bool IsNumeric(Object obj)
		{
			bool result = true;

			try
			{
				int i = Convert.ToInt32(obj);
			}
			catch
			{
				result = false;
			}

			return result;
		}

		public static bool CreateDirectory(string path, ref string error)
		{
			bool result = false;

			try
			{
				if (!Directory.Exists(path))
					Directory.CreateDirectory(path);

				result = true;
			}
			catch (System.Exception e)
			{
				error = e.Message;
			}
			
			return result;
		}

		public static void DeleteDirectory(string path)
		{
			try
			{
				if (Directory.Exists(path))
					Directory.Delete(path, true);
			}
			catch (System.Exception e)
			{
				WriteToTraceLog(e, "DeleteDirectory");
			}
		}

		#region GetImageControl
		[DllImport("gdi32.dll")]
		private static extern long BitBlt(
			IntPtr hdcDest,
			int xDest,
			int yDest,
			int nWidth,
			int nHeight,
			IntPtr hdcSource,
			int xSrc,
			int ySrc,
			Int32 dwRop);
		const int SRCCOPY=13369376;

		public static Bitmap getImage(Control ctr)
		{
			Graphics grCtrl = Graphics.FromHwnd(ctr.Handle);
			Bitmap result = new Bitmap(ctr.Width,ctr.Height, grCtrl);
			
			IntPtr hdcCtrl = grCtrl.GetHdc();
			Graphics grDest = Graphics.FromImage(result);
			IntPtr hdcDest =  grDest.GetHdc();
		
			BitBlt(hdcDest, 0, 0, ctr.Width, ctr.Height, hdcCtrl, 0, 0, SRCCOPY);
			grCtrl.ReleaseHdc(hdcCtrl);
			grDest.ReleaseHdc(hdcDest);
			return result;

		}
		#endregion
	}
}
