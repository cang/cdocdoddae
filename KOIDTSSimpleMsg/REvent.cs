using System;

namespace KOIDTSSimpleMsg
{
	/// <summary>
	/// Summary description for REvent.
	/// </summary>
	public class REvent : MarshalByRefObject	
	{
		public REvent()
		{
		}

		public override object InitializeLifetimeService()
		{
			// this object has to live "forever"
			return null;
		}

		#region Event
		public event MessageHandler OnMessage;
		public event MessageHandlerSimple OnMessageSimple;
		#endregion Event

		#region Handler Event

		private void HandleException(Exception ex)
		{
			//SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
		}

		public virtual void HandlerOnMessageSimple(object obj,string msg)
		{
			if (OnMessageSimple != null)
			{
				MessageHandlerSimple messageDelegate = null;
				Delegate[] invocationList_ = null;
				try
				{
					invocationList_ = OnMessageSimple.GetInvocationList();
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
								messageDelegate = (MessageHandlerSimple)del;
								messageDelegate(obj,msg);
							}
							catch
							{
								OnMessageSimple -= messageDelegate;
							}
						}
					}
				}
			}
		}

		public virtual void HandlerOnMessage(object obj,MessageEvent e)
		{
			if (OnMessage != null)
			{
				MessageHandler messageDelegate = null;
				Delegate[] invocationList_ = null;
				try
				{
					invocationList_ = OnMessage.GetInvocationList();
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
								messageDelegate(obj,e);
							}
							catch
							{
								OnMessage -= messageDelegate;
							}
						}
					}
				}
			}
		}

		#endregion Handler Event
	}
}
