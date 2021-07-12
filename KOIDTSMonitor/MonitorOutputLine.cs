using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using SiGlaz.Utility.Wind32;

namespace KOIDTSMonitor
{
	/// <summary>
	/// Summary description for MonitorOutputLine.
	/// </summary>
	public class MonitorOutputLine : IDisposable
	{
		private string eventName = string.Empty;
		private string _Name = string.Empty;

		private bool	_dispose = false;

		public event EventHandler	OnOutputLine;

		public MonitorOutputLine() : this("SiGlaz_KOIDTS_Server")
		{
		}

		public MonitorOutputLine(string eName)
		{
			_Name = eName;
			eventName =  "Global\\" + eName;
			MyInit();
		}

		static IntPtr _echeckraise = IntPtr.Zero;
		private void MyInit()
		{
//			IntPtr securityDescPtr = new IntPtr( 0 );
//			IntPtr eventAttributesPtr = new IntPtr( 0 );
//
//			Kernel32.SECURITY_DESCRIPTOR sd = new SiGlaz.Utility.Wind32.Kernel32.SECURITY_DESCRIPTOR();
//			Kernel32.InitializeSecurityDescriptor(out sd,(uint)1);
//			Kernel32.SetSecurityDescriptorDacl(ref sd,false,IntPtr.Zero,false);
//			Kernel32.SECURITY_ATTRIBUTES sa = new SiGlaz.Utility.Wind32.Kernel32.SECURITY_ATTRIBUTES();
//			sa.nLength = Marshal.SizeOf(sa);
//			securityDescPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(sd));
//			Marshal.StructureToPtr(sd,securityDescPtr,false);
//			sa.lpSecurityDescriptor = securityDescPtr;
// 
//			eventAttributesPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(sa));
//			Marshal.StructureToPtr(sa,eventAttributesPtr,false);

			_echeckraise = Kernel32.CreateEvent(IntPtr.Zero,true,false,eventName);
			if(_echeckraise==IntPtr.Zero)
			{
				string sss = Kernel32.GetLastErrorString();

				throw new Exception("Cannot create " + eventName + " event");
			}
		}

		private bool InitializeSecurityDescriptor(Kernel32.SECURITY_DESCRIPTOR sd)
		{
			return Kernel32.InitializeSecurityDescriptor(out sd,(int)1);
		}

		public void Listen()
		{
			(new Thread(new ThreadStart(ListenThread))).Start();
		}
		
		private void ListenThread()
		{
			while(true)
			{
				Kernel32.WaitForSingleObject(_echeckraise,int.MaxValue);
				Kernel32.ResetEvent(_echeckraise);

				if(_dispose)
					return;
			
				string personalFolder = SiGlaz.Common.DDA.AppData.GetCommonApplicationDataPath("KOIDTSCmd");				
				string fileName = string.Format("{0}\\{1}.txt",personalFolder,_Name);

				//SiGlaz.Utility.GlobalLock lck = new SiGlaz.Utility.GlobalLock(fileName);
				SiGlaz.Utility.MutexSecurity lck = new SiGlaz.Utility.MutexSecurity(fileName);
				StreamReader stream = null;
				try
				{
					lck.WaitOne();
					stream = new StreamReader(fileName);
					if(OnOutputLine!=null)
					{
						OnOutputLine(Environment.NewLine + stream.ReadLine(),EventArgs.Empty);

					}
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
					//lck.Dispose();
				}

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
			if(_echeckraise!= IntPtr.Zero)
			{
				_dispose = true;
				Kernel32.SetEvent(_echeckraise);
				Kernel32.CloseHandle(_echeckraise);
			}
		}

		~MonitorOutputLine()
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
