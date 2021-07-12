using System;
using System.Threading;
using SiGlaz.IO.FileMap;

namespace SiGlaz.SharedMemory
{
	/// <summary>
	/// Summary description for BaseMonitor.
	/// </summary>
	/// 

	public class BaseMonitor : IDisposable
	{
		protected string				_SharedName		= string.Empty;
		protected SharedMessage			_Messsage		= new SharedMessage();
		protected Segment				_SegmentStatus	= null;
		protected Segment				_SegmentData	= null;


		protected string				 _echeckname	= "DDA_Event_";//@"Global\Siglaz_DDA_Event_";
		//protected IntPtr				_echeck			= IntPtr.Zero; 
		protected SiGlaz.Utility.InterProcessEvent		_ev;

		protected virtual void Init(int datamaxsize)
		{
			if( _SharedName==null || _SharedName==string.Empty) 
				throw new Exception("SharedName must setting");

			_SegmentStatus = new Segment(_SharedName + "_Status", SharedMemoryCreationFlag.Create,SharedMessage.Lenght);
			_SegmentData = new Segment(_SharedName + "_Data", SharedMemoryCreationFlag.Create,datamaxsize);

			_ev = new SiGlaz.Utility.InterProcessEvent(_echeckname);

//			_echeck = Win32Native.CreateEvent(IntPtr.Zero,true,false,_echeckname);
//			if(_echeck==IntPtr.Zero)
//			{
//				throw new Exception("Cannot create " + _echeckname + " event");
//			}
//			Win32Native.ResetEvent(_echeck);
		}

		public virtual void ReInit(int datamaxsize)
		{
			if( _SharedName==null || _SharedName==string.Empty) 
				throw new Exception("SharedName must setting");

			if(_SegmentData!=null)
			{
				_SegmentData.Dispose();
				_SegmentData = null;
			}

			_SegmentData = new Segment(_SharedName + "_Data", SharedMemoryCreationFlag.Create,datamaxsize);
		}

		public BaseMonitor(string sharename)
		{
			_SharedName = sharename;
			_echeckname = _echeckname + sharename;
			this.Init(SharedData.DefaultLength);
		}

		public BaseMonitor(string sharename,int datamaxsize)
		{
			_SharedName = sharename;
			_echeckname = _echeckname + sharename;
			this.Init(datamaxsize);
		}


		/// <summary>
		/// SharedData must override Serialize(BinaryWriter stream) function
		/// </summary>
		/// <param name="obj"></param>
		public void WriteBinary(SharedData obj)
		{
			if(obj==null)
				throw new Exception("data of SharedData on BaseMonitor.Write is null");

			if(_SegmentData!=null)
			{
				_SegmentData.Lock();
				_SegmentData.WriteBytes(obj.SerializeBinary());
				_SegmentData.Unlock();
			}
		}

		/// <summary>
		/// SharedData must use attribute [Serializable()] for all class inside SharedData obj
		/// </summary>
		/// <param name="obj"></param>
		public void WriteGraph(SharedData obj)
		{
			if(obj==null)
				throw new Exception("data of SharedData on BaseMonitor.Write is null");

			if(_SegmentData!=null)
			{
				_SegmentData.Lock();
				_SegmentData.SetData(obj);
				_SegmentData.Unlock();
			}
		}

		/// <summary>
		/// SharedData must override Deserialize(BinaryWriter stream) function
		/// </summary>
		/// <param name="obj"></param>
		public void ReadBinary(SharedData obj)
		{
			if(obj==null)
				throw new Exception("data of SharedData on BaseMonitor.Read is null");

			if(_SegmentData!=null)
			{
				_SegmentData.Lock();
				obj.DeserializeBinary(_SegmentData.ReadBytes());
				_SegmentData.Unlock();
			}
		}


		/// <summary>
		/// SharedData must use attribute [Serializable()] for all class inside SharedData obj
		/// </summary>
		/// <returns></returns>
		public SharedData ReadGraph()
		{
			if(_SegmentData!=null)
			{
				_SegmentData.Lock();
				SharedData result = _SegmentData.GetData() as SharedData;
				_SegmentData.Unlock();
				return result;
			}
			return null;
		}

		public string				SharedName		
		{
			get
			{
				return _SharedName;
			}
		}

		#region IDisposable Members

		protected virtual void Dispose( bool disposing )
		{
			// Only clean up managed resources if being called from IDisposable.Dispose
			if( disposing )
			{
				if(_SegmentData!=null)
				{
					_SegmentData.Dispose();
					_SegmentData = null;
				}
				if(_SegmentStatus!=null)
				{
					_SegmentStatus.Dispose();
					_SegmentStatus = null;
				}
				if(_ev!=null)
				{
					_ev.Dispose();
					_ev = null;
				}
			}

			// always clean up unmanaged resources
//			if(_echeck!= IntPtr.Zero)
//			{
//				//Console.WriteLine("Dispose " + this.ToString());
//				Win32Native.SetEvent(_echeck);
//				Win32Native.CloseHandle(_echeck);
//			}
		}

		~BaseMonitor()
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
