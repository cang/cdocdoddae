using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace KOIDTSMonitor
{
	/// <summary>
	/// Summary description for Program.
	/// </summary>
	public class Program
	{
		public Program()
		{
			//
			// TODO: Add constructor logic here
			//
		}
//
//		static Mutex mtRaiseEvent = null;
//		static void ListenEventFromClient()
//		{
//			mtRaiseEvent = new Mutex(false,"Global\\SiGlaz_KOIDTS_Client");
//			while(mtRaiseEvent.WaitOne() )
//			{
//				//Read from output file
//				string personalFolder = string.Format("{0}\\IDA Data\\KOIDTA", Environment.GetFolderPath(Environment.SpecialFolder.Personal)); 
//				string fileName = string.Format("{0}\\Infomationlog.txt",personalFolder);
//				using (StreamReader outTxt = new StreamReader(fileName))
//				{
//					while (outTxt.Peek() >=0 )
//					{
//						dlgmain.AddNewLine(outTxt.ReadLine());
//					}					
//				}				
//			}
//		}


	

		static DlgMonitor dlgmain = null;

		[STAThread]
		static void Main() 
		{
			dlgmain = new DlgMonitor();

			Application.Run(dlgmain);
		}

		
		

	}
}

