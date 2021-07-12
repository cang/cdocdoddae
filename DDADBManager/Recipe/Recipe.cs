using System;
using System.Xml;
using System.Xml.Serialization;

namespace DDADBManager.Process
{
	/// <summary>
	/// Summary description for Process.
	/// </summary>
	/// 
	[XmlInclude(typeof(LoadETestProcess))]
	[XmlInclude(typeof(TransferProcess))]
	[XmlInclude(typeof(DeleteProcess))]
	public class ProcessBase 
	{
		
		private		int			_ID;
		private		string		_Name;
		private		RunMode		_RunMode;
		private		bool		_IsRunning;
		private		bool		_IsWaiting;

		private		Modal.TextHistory	_OutputHistory  = new DDADBManager.Modal.TextHistory();
		private		Modal.TextHistory	_TraceHistory = new DDADBManager.Modal.TextHistory();

		public event EventHandlerProcessInfor OnStateChange;

		#region Event
		public event EventHandlerProcess		OnProcess;
		public event EventHandlerProcess		OnBeginProcess;
		public event EventHandlerProcess		OnEndProcess;
		public event EventHandlerProcessInfor	OnProcessInfo;
		public event EventHandlerProcessError	OnError;
		#endregion Event

		#region Handler Event
		public void HandlerProcess(string filepath,ProcessEventArgs e)
		{
			if(OnProcess!=null)
				OnProcess(this.ID,filepath,e);
		}
		public void HandlerBeginProcess(string filepath,ProcessEventArgs e)
		{
			if(OnBeginProcess!=null)
				OnBeginProcess(this.ID,filepath,e);
		}
		public void HandlerEndProcess(string filepath,ProcessEventArgs e)
		{
			if(OnEndProcess!=null)
				OnEndProcess(this.ID,filepath,e);
		}
		public void HandlerProcessInfor(string description,EventArgs e)
		{
			if(OnProcessInfo!=null)
				OnProcessInfo(this.ID,description,e);
		}
		public void HandlerProcessError(string msg,FileControllerErrorEventArgs e)
		{
			if(OnError!=null)
				OnError(this.ID,msg,e);
		}
		#endregion Handler Event

		public ProcessBase()
		{
		}



		[XmlIgnore()]
		public		Modal.TextHistory  OutputHistory
		{
			get
			{
				return _OutputHistory;
			}
			set
			{
				_OutputHistory = value;
			}
		}

		[XmlIgnore()]
		public		Modal.TextHistory  TraceHistory
		{
			get
			{
				return _TraceHistory;
			}
			set
			{
				_TraceHistory = value;
			}
		}

		
		//[XmlIgnore()]
		public		bool  IsWaiting
		{
			get
			{
				return _IsWaiting;
			}
			set
			{
				bool old = _IsWaiting;
				_IsWaiting = value;
				if(old!=value)
					RaiseChangeStatus();
			}
		}

		//[XmlIgnore()]
		public		bool  IsRunning
		{
			get
			{
				return _IsRunning;
			}
			set
			{
				bool old = _IsRunning;
				_IsRunning = value;
				if(old!=value)
					RaiseChangeStatus();
			}
		}

		public		void RaiseChangeStatus()
		{
			if(OnStateChange!=null)
				OnStateChange(this.ID,string.Empty,EventArgs.Empty);
		}

		//[XmlIgnore()]
		public		int		ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}

		public		string		Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		[XmlIgnore()]
		public		RunMode		RunMode
		{
			get
			{
				return _RunMode;
			}
			set
			{
				_RunMode = value;
			}
		}

		public virtual void DoPreProcess()
		{
		}

		public virtual void Execute()
		{
			InitProcess();
		}

		public virtual void DoPostProcess()
		{
			
		}

		public virtual void Property()
		{
			System.Windows.Forms.MessageBox.Show("Property do not implement yet");
		}

//		public virtual void ForceAbort()
//		{
//		}

		public virtual void Stop()
		{
		}

		public virtual void InitProcess()
		{
			IsRunning = true;
			IsWaiting = true;
		}

		public virtual string ValidateString
		{
			get
			{
				return string.Empty;
			}
		}

		public virtual string RunningImage
		{
			get
			{
				return "Images.loadetest1.gif";
			}
		}

		public virtual string WaitingImage
		{
			get
			{
				return "Images.loadetest2.gif";
			}
		}

		public virtual string StopImage
		{
			get
			{
				return "Images.loadetest.gif";
			}
		}

		protected void WriteTrace(string text)
		{
			SiGlaz.Utility.DebugLog.Write(text);
			this.TraceHistory.AddNewLine(this.ID,"Error : " + SiGlaz.Utility.DebugLog.LogFilePath );
		}



	}

	public enum RunMode : byte
	{
		RunOneTime,
		Monitor
	}
}
