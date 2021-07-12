using System;
using System.Threading;
using SiGlaz.IO.FileMap;


namespace SiGlaz.SharedMemory
{
	/// <summary>
	/// Summary description for ReceivedMonitor.
	/// </summary>
	public class ReceivedMonitor : BaseMonitor
	{
		protected Thread				_thread			= null;
		public event EventHandlerReceived	OnReceived;

		public ReceivedMonitor(string sharename) : base(sharename)
		{
		}

		public ReceivedMonitor(string sharename,int datamaxsize) : base(sharename,datamaxsize)
		{
		}

		protected override void Dispose(bool disposing)
		{
			AbortThread();
			base.Dispose (disposing);
		}

		~ReceivedMonitor()
		{
			this.Dispose();
		}

		protected override void Init(int datamaxsize)
		{
			base.Init (datamaxsize);
			_thread = new Thread(new ThreadStart(ThreadingMethod));
			_thread.Start();
		}

		public void HanlderEventReceived()
		{
			if(OnReceived!=null)
			{
				OnReceived(_Messsage.Copy());
			}
		}

		bool	_Abort;
		public void ThreadingMethod()
		{
			_Abort = false;
			while(!_Abort)
			{
				if(_ev!=null)
					_ev.WaitForSingleObject();

				if(_ev!=null)
					_ev.ResetEvent();

//				Win32Native.WaitForSingleObject(_echeck,int.MaxValue);
//				Win32Native.ResetEvent(_echeck);

				if(_Abort) return;

				byte[] lpbyte = null;
				try
				{
					_SegmentStatus.Lock();
					lpbyte = _SegmentStatus.ReadBytes();
					_SegmentStatus.Unlock();
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex.ToString());
					return;
				}

				lock(_Messsage)
				{
					_Messsage.DeserializeBinary(lpbyte);
					HanlderEventReceived();
				}
			}
		}

		public void AbortThread()
		{
			_Abort=true;

			if(_ev!=null)
				_ev.SetEvent();
//			Win32Native.SetEvent(_echeck);
		}

	}

	public delegate void EventHandlerReceived(SharedMessage msg);

}
