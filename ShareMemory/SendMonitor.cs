using System;
using System.Threading;
using SiGlaz.IO.FileMap;

namespace SiGlaz.SharedMemory
{
	/// <summary>
	/// Summary description for SendMonitor.
	/// </summary>
	public class SendMonitor : BaseMonitor
	{
		public SendMonitor(string sharename) : base(sharename)
		{
		}

		public SendMonitor(string sharename,int datamaxsize) : base(sharename,datamaxsize)
		{
		}

		~SendMonitor()
		{
			this.Dispose();
		}

		public void RaiseEvent(int msg)
		{
			lock(_Messsage)
			{
				_Messsage.Message = msg;
				_SegmentStatus.Lock();
				_SegmentStatus.WriteBytes(_Messsage.SerializeBinary());
				_SegmentStatus.Unlock();
			}
			if(_ev!=null)
				_ev.SetEvent();
			//Win32Native.SetEvent(_echeck);
		}

	}
}
