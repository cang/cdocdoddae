using System;

namespace DDADBRObjects
{
	/// <summary>
	/// Summary description for RSchemaEvent.
	/// </summary>
	public class RSchemaEvent : MarshalByRefObject
	{
		public RSchemaEvent()
		{
		}

		/// <summary>
		/// Obtains a lifetime service object to control the lifetime policy for this
		/// instance.
		/// </summary>
		/// <returns>
		///An object of type System.Runtime.Remoting.Lifetime.ILease used to control
		///the lifetime policy for this instance. This is the current lifetime service
		///object for this instance if one exists; otherwise, a new lifetime service
		///object initialized to the value of the System.Runtime.Remoting.Lifetime.LifetimeServices.LeaseManagerPollTime
		///property.
		///null value means this object has to live forever.
		/// </returns>
		public override object InitializeLifetimeService()
		{
			// this object has to live "forever"
			return null;
		}

		#region Event
		public event EventHandlerProcess		OnProcess;
		public event EventHandlerProcess		OnBeginProcess;
		public event EventHandlerProcess		OnEndProcess;
		public event EventHandlerProcessInfor	OnProcessInfo;
		public event EventHandlerProcessError	OnError;
		public event EventHandlerProcessInfor	OnStatusChange;
		

		/// <summary>
		/// sender is new line (string)
		/// </summary>
		public event	EventHandlerProcess		OnTextAddNewLine;
		public event	EventHandlerProcess		OnTraceAddNewLine;

		public event	MessageHandler			OnRefresh;

		#endregion Event

		#region Handler Event

		private void HandleException(Exception ex)
		{
			SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
		}

		public void HandlerStatusChange(string des,ProcessBaseEventArgs e)
		{
			if(OnStatusChange != null)
			{
				EventHandlerProcessInfor messageDelegate = null;
				Delegate[] invocationList_ = null;
				try
				{
					invocationList_ = OnStatusChange.GetInvocationList();
				}
				catch (MemberAccessException ex)
				{
					HandleException(ex);
					return;
				}

				if (invocationList_ != null)
				{
					lock (invocationList_)
					{
						foreach (Delegate del in invocationList_)
						{
							try
							{
								messageDelegate = (EventHandlerProcessInfor)del;
								messageDelegate(des,e);
							}
							catch
							{
								OnStatusChange -= messageDelegate;
							}
						}
					}
				}
			}
		}

		public void HandlerProcess(string filepath,ProcessEventArgs e)
		{
			if (OnProcess != null)
			{
				EventHandlerProcess messageDelegate = null;
				Delegate[] invocationList_ = null;
				try
				{
					invocationList_ = OnProcess.GetInvocationList();
				}
				catch (MemberAccessException ex)
				{
					HandleException(ex);
				}

				if (invocationList_ != null)
				{
					lock (invocationList_)
					{
						foreach (Delegate del in invocationList_)
						{
							try
							{
								messageDelegate = (EventHandlerProcess)del;
								messageDelegate(filepath,e);
							}
							catch
							{
								OnProcess -= messageDelegate;
							}
						}
					}
				}
			}
		}

		public void HandlerBeginProcess(string filepath,ProcessEventArgs e)
		{
			if (OnBeginProcess != null)
			{
				EventHandlerProcess messageDelegate = null;
				Delegate[] invocationList_ = null;
				try
				{
					invocationList_ = OnBeginProcess.GetInvocationList();
				}
				catch (MemberAccessException ex)
				{
					HandleException(ex);
				}

				if (invocationList_ != null)
				{
					lock (invocationList_)
					{
						foreach (Delegate del in invocationList_)
						{
							try
							{
								messageDelegate = (EventHandlerProcess)del;
								messageDelegate(filepath,e);
							}
							catch
							{
								OnBeginProcess -= messageDelegate;
							}
						}
					}
				}
			}
		}
		public void HandlerEndProcess(string filepath,ProcessEventArgs e)
		{
			if (OnEndProcess != null)
			{
				EventHandlerProcess messageDelegate = null;
				Delegate[] invocationList_ = null;
				try
				{
					invocationList_ = OnEndProcess.GetInvocationList();
				}
				catch (MemberAccessException ex)
				{
					HandleException(ex);
				}

				if (invocationList_ != null)
				{
					lock (invocationList_)
					{
						foreach (Delegate del in invocationList_)
						{
							try
							{
								messageDelegate = (EventHandlerProcess)del;
								messageDelegate(filepath,e);
							}
							catch
							{
								OnEndProcess -= messageDelegate;
							}
						}
					}
				}
			}
		}
		public void HandlerProcessInfor(string description,ProcessBaseEventArgs e)
		{
			if (OnProcessInfo != null)
			{
				EventHandlerProcessInfor messageDelegate = null;
				Delegate[] invocationList_ = null;
				try
				{
					invocationList_ = OnProcessInfo.GetInvocationList();
				}
				catch (MemberAccessException ex)
				{
					HandleException(ex);
				}

				if (invocationList_ != null)
				{
					lock (invocationList_)
					{
						foreach (Delegate del in invocationList_)
						{
							try
							{
								messageDelegate = (EventHandlerProcessInfor)del;
								messageDelegate(description,e);
							}
							catch
							{
								OnProcessInfo -= messageDelegate;
							}
						}
					}
				}
			}
		}
		public void HandlerProcessError(string msg,FileControllerErrorEventArgs e)
		{
			if (OnError != null)
			{
				EventHandlerProcessError messageDelegate = null;
				Delegate[] invocationList_ = null;
				try
				{
					invocationList_ = OnError.GetInvocationList();
				}
				catch (MemberAccessException ex)
				{
					HandleException(ex);
				}

				if (invocationList_ != null)
				{
					lock (invocationList_)
					{
						foreach (Delegate del in invocationList_)
						{
							try
							{
								messageDelegate = (EventHandlerProcessError)del;
								messageDelegate(msg,e);
							}
							catch
							{
								OnError -= messageDelegate;
							}
						}
					}
				}
			}
		}

		public void HandlerTextAddNewLine(string msg,ProcessEventArgs e)
		{
			if (OnTextAddNewLine != null)
			{
				EventHandlerProcess messageDelegate = null;
				Delegate[] invocationList_ = null;
				try
				{
					invocationList_ = OnTextAddNewLine.GetInvocationList();
				}
				catch (MemberAccessException ex)
				{
					HandleException(ex);
				}

				if (invocationList_ != null)
				{
					lock (invocationList_)
					{
						foreach (Delegate del in invocationList_)
						{
							try
							{
								messageDelegate = (EventHandlerProcess)del;
								messageDelegate(msg,e);
							}
							catch
							{
								OnTextAddNewLine -= messageDelegate;
							}
						}
					}
				}
			}
		}

		public void HandlerTraceAddNewLine(string msg,ProcessEventArgs e)
		{
			if (OnTraceAddNewLine != null)
			{
				EventHandlerProcess messageDelegate = null;
				Delegate[] invocationList_ = null;
				try
				{
					invocationList_ = OnTraceAddNewLine.GetInvocationList();
				}
				catch (MemberAccessException ex)
				{
					HandleException(ex);
				}

				if (invocationList_ != null)
				{
					lock (invocationList_)
					{
						foreach (Delegate del in invocationList_)
						{
							try
							{
								messageDelegate = (EventHandlerProcess)del;
								messageDelegate(msg,e);
							}
							catch
							{
								OnTraceAddNewLine -= messageDelegate;
							}
						}
					}
				}
			}
		}

		public void HandlerOnRefresh(string msg)
		{
			if (OnRefresh != null)
			{
				MessageHandler messageDelegate = null;
				Delegate[] invocationList_ = null;
				try
				{
					invocationList_ = OnRefresh.GetInvocationList();
				}
				catch (MemberAccessException ex)
				{
					HandleException(ex);
				}

				if (invocationList_ != null)
				{
					lock (invocationList_)
					{
						foreach (Delegate del in invocationList_)
						{
							try
							{
								messageDelegate = (MessageHandler)del;
								messageDelegate(msg);
							}
							catch
							{
								OnRefresh -= messageDelegate;
							}
						}
					}
				}
			}
		}
		#endregion Handler Event

	}
}
