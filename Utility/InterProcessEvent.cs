using System;
using SiGlaz.Utility.Wind32;
using System.Runtime.InteropServices;
using System.Threading;

namespace SiGlaz.Utility
{
	/// <summary>
	/// Summary description for InterProcessEvent.
	/// </summary>
	public class InterProcessEvent : IDisposable
	{
		private IntPtr  Handle = IntPtr.Zero;
		public string	EventName =	string.Empty;
		public string   EventPath = string.Empty;

		public event	EventHandler	OnExecute;

		public InterProcessEvent(string eName) : this(eName,false)
		{
		}

		public InterProcessEvent(string eName,bool open)
		{	
			EventName = eName;
			EventName = EventName.Replace(@"\","_");

			EventPath =  string.Format("Global\\SiGlaz.{0}",EventName);

			InitEvent(open);
		}

		public void InitEvent(bool open)
		{
			if(open)
			{
				//#define EVENT_ALL_ACCESS (STANDARD_RIGHTS_REQUIRED|SYNCHRONIZE|0x3) 
				//#define STANDARD_RIGHTS_REQUIRED         (0x000F0000L)
				//#define SYNCHRONIZE                      (0x00100000L)
				int unEventPermissions = 2031619;// Same as EVENT_ALL_ACCESS value
				Handle = Kernel32.OpenEvent(unEventPermissions,false,EventPath);
			}
			else
			{
				IntPtr securityDescPtr = new IntPtr(0);
				IntPtr eventAttributesPtr = new IntPtr(0);

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

				Handle = Kernel32.CreateEvent(eventAttributesPtr,true,false,EventPath);

				//Free ???
				Marshal.FreeCoTaskMem(securityDescPtr);
				Marshal.FreeCoTaskMem(eventAttributesPtr);
			}

			if(Handle==IntPtr.Zero)
			{
				throw new Exception("Cannot create " + EventName + " event");
			}
		}

		public void FreeEvent()
		{
			if(Handle!=IntPtr.Zero)
			{
				Kernel32.SetEvent(Handle);
				Kernel32.CloseHandle(Handle);
			}
		}

		public bool ResetEvent()
		{
			return Kernel32.ResetEvent(Handle);
		}

		public bool SetEvent()
		{
			return Kernel32.SetEvent(Handle);
		}

		public int WaitForSingleObject(int milisecond)
		{
			return Kernel32.WaitForSingleObject(Handle,milisecond);
		}

		public int WaitForSingleObject()
		{
			return this.WaitForSingleObject(int.MaxValue);
		}


		#region IDisposable Members

		protected virtual void Dispose( bool disposing )
		{
			// Only clean up managed resources if being called from IDisposable.Dispose
			if( disposing )
			{
			}

			// always clean up unmanaged resources
			Stop();//free thread before free event
			FreeEvent();
		}

		~InterProcessEvent()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
			Dispose(true);
		}

		#endregion

		private bool	isStarted = false;
		private Thread	threadEvent = null;

		private void StartThread()
		{
			while (isStarted)
			{
				WaitForSingleObject();
				if(!isStarted)
					break;
				ResetEvent();

				//Get status
				if(OnExecute!=null)
				{
					OnExecute(null,EventArgs.Empty);
				}
			}
		}

		public void RaiseEvent()
		{
			SetEvent();
		}

		public void Start()
		{
			if(isStarted) return;

			isStarted = true;
			threadEvent = new Thread(new ThreadStart(StartThread));
			threadEvent.IsBackground = true;
			threadEvent.Start();
		}

		public void Stop()
		{
			isStarted = false;
			SetEvent();
		}

	}
}
