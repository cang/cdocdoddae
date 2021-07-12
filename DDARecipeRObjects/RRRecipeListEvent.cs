using System;

using SiGlaz.Recipes;
using DDARecipe;

namespace DDARecipeRObjects
{
	/// <summary>
	/// Summary description for RRecipeListEvent.
	/// </summary>
	public class RRecipeListEvent : MarshalByRefObject
	{
		public RRecipeListEvent()
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

		public event			NodeEventHandler	OnBeginNode;
		public event			NodeEventHandler	OnCompleteNode;
		public event			NodeEventHandler	OnExceptionNode;
		public event			NodeEventHandler	OnWaitingForData;
		public event			NodeEventHandler	OnMessage;

		public event			RecipeEventHandler	OnStart;
		public event			RecipeEventHandler	OnBegin;
		public event			RecipeEventHandler	OnStop;
		public event			RecipeEventHandler	OnComplete;
		public event			RecipeEventHandler	OnException;

		public event			RecipeEventHandler	OnStartCmd;
		public event			RecipeEventHandler	OnStopCmd;

		public event			MessageEventHandler	OnRefresh;

//		/// <summary>
//		/// sender is new line (string)
//		/// </summary>
//		public event	EventHandlerRecipe		OnTextAddNewLine;
//		public event	EventHandlerRecipe		OnTraceAddNewLine;

		#endregion Event

		#region Handler Event

		private void HandleException(Exception ex)
		{
			SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogError(ex);
		}

		public virtual void HandlerOnBeginNode(int RecipeIndex,int nodeindex,RecipeEventArgs e)
		{
//			if(OnBeginNode!=null)
//				OnBeginNode(RecipeIndex,nodeindex,e);
			if (OnBeginNode != null)
			{
				NodeEventHandler messageDelegate = null;
				Delegate[] invocationList_ = null;
				try
				{
					invocationList_ = OnBeginNode.GetInvocationList();
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
								messageDelegate = (NodeEventHandler)del;
								messageDelegate(RecipeIndex,nodeindex,e);
							}
							catch
							{
								OnBeginNode -= messageDelegate;
							}
						}
					}
				}
			}
		}

		public virtual void HandlerOnCompleteNode(int RecipeIndex,int nodeindex,RecipeEventArgs e)
		{
//			if(OnCompleteNode!=null)
//				OnCompleteNode(RecipeIndex,nodeindex,e);
			if (OnCompleteNode != null)
			{
				NodeEventHandler messageDelegate = null;
				Delegate[] invocationList_ = null;
				try
				{
					invocationList_ = OnCompleteNode.GetInvocationList();
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
								messageDelegate = (NodeEventHandler)del;
								messageDelegate(RecipeIndex,nodeindex,e);
							}
							catch
							{
								OnCompleteNode -= messageDelegate;
							}
						}
					}
				}
			}
		}

		public virtual void HandlerOnExceptionNode(int RecipeIndex,int nodeindex,RecipeEventArgs e)
		{
//			if(OnExceptionNode!=null)
//				OnExceptionNode(RecipeIndex,nodeindex,e);
			if (OnExceptionNode != null)
			{
				NodeEventHandler messageDelegate = null;
				Delegate[] invocationList_ = null;
				try
				{
					invocationList_ = OnExceptionNode.GetInvocationList();
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
								messageDelegate = (NodeEventHandler)del;
								messageDelegate(RecipeIndex,nodeindex,e);
							}
							catch
							{
								OnExceptionNode -= messageDelegate;
							}
						}
					}
				}
			}
		}
		
		public virtual void HandlerOnWaitingForData(int RecipeIndex,int nodeindex,RecipeEventArgs e)
		{
//			if(OnWaitingForData!=null)
//				OnWaitingForData(RecipeIndex,nodeindex,e);
			if (OnWaitingForData != null)
			{
				NodeEventHandler messageDelegate = null;
				Delegate[] invocationList_ = null;
				try
				{
					invocationList_ = OnWaitingForData.GetInvocationList();
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
								messageDelegate = (NodeEventHandler)del;
								messageDelegate(RecipeIndex,nodeindex,e);
							}
							catch
							{
								OnWaitingForData -= messageDelegate;
							}
						}
					}
				}
			}
		}

		public virtual void HandlerOnMessage(int RecipeIndex,int nodeindex,RecipeEventArgs e)
		{
//			if(OnMessage!=null)
//				OnMessage(RecipeIndex,nodeindex,e);
			if (OnMessage != null)
			{
				NodeEventHandler messageDelegate = null;
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
								messageDelegate = (NodeEventHandler)del;
								messageDelegate(RecipeIndex,nodeindex,e);
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

		public virtual void HandlerOnStart(int RecipeIndex,RecipeEventArgs e)
		{
//			if(OnStart!=null)
//				OnStart(RecipeIndex,e);

			if (OnStart != null)
			{
				RecipeEventHandler messageDelegate = null;
				Delegate[] invocationList_ = null;
				try
				{
					invocationList_ = OnStart.GetInvocationList();
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
								messageDelegate = (RecipeEventHandler)del;
								messageDelegate(RecipeIndex,e);
							}
							catch
							{
								OnStart -= messageDelegate;
							}
						}
					}
				}
			}
		}
		
		public virtual void HandlerOnBegin(int RecipeIndex,RecipeEventArgs e)
		{
//			if(OnBegin!=null)
//				OnBegin(RecipeIndex,e);
			if (OnBegin != null)
			{
				RecipeEventHandler messageDelegate = null;
				Delegate[] invocationList_ = null;
				try
				{
					invocationList_ = OnBegin.GetInvocationList();
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
								messageDelegate = (RecipeEventHandler)del;
								messageDelegate(RecipeIndex,e);
							}
							catch
							{
								OnBegin -= messageDelegate;
							}
						}
					}
				}
			}
		}

		public virtual void HandlerOnStop(int RecipeIndex,RecipeEventArgs e)
		{
//			if(OnStop!=null)
//				OnStop(RecipeIndex,e);
			if (OnStop != null)
			{
				RecipeEventHandler messageDelegate = null;
				Delegate[] invocationList_ = null;
				try
				{
					invocationList_ = OnStop.GetInvocationList();
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
								messageDelegate = (RecipeEventHandler)del;
								messageDelegate(RecipeIndex,e);
							}
							catch
							{
								OnStop -= messageDelegate;
							}
						}
					}
				}
			}
		}

		public virtual void HandlerOnComplete(int RecipeIndex,RecipeEventArgs e)
		{
//			if(OnComplete!=null)
//				OnComplete(RecipeIndex,e);

			if (OnComplete != null)
			{
				RecipeEventHandler messageDelegate = null;
				Delegate[] invocationList_ = null;
				try
				{
					invocationList_ = OnComplete.GetInvocationList();
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
								messageDelegate = (RecipeEventHandler)del;
								messageDelegate(RecipeIndex,e);
							}
							catch
							{
								OnComplete -= messageDelegate;
							}
						}
					}
				}
			}
		}

		public virtual void HandlerOnException(int RecipeIndex,RecipeEventArgs e)
		{
//			if(OnException!=null)
//				OnException(RecipeIndex,e);

			if (OnException != null)
			{
				RecipeEventHandler messageDelegate = null;
				Delegate[] invocationList_ = null;
				try
				{
					invocationList_ = OnException.GetInvocationList();
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
								messageDelegate = (RecipeEventHandler)del;
								messageDelegate(RecipeIndex,e);
							}
							catch
							{
								OnException -= messageDelegate;
							}
						}
					}
				}
			}
		}


		public virtual void HandlerOnStartCmd(int RecipeIndex,RecipeEventArgs e)
		{
//			if(OnStartCmd!=null)
//				OnStartCmd(RecipeIndex,e);

			if (OnStartCmd != null)
			{
				RecipeEventHandler messageDelegate = null;
				Delegate[] invocationList_ = null;
				try
				{
					invocationList_ = OnStartCmd.GetInvocationList();
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
								messageDelegate = (RecipeEventHandler)del;
								messageDelegate(RecipeIndex,e);
							}
							catch
							{
								OnStartCmd -= messageDelegate;
							}
						}
					}
				}
			}
		}
		
		public virtual void HandlerOnStopCmd(int RecipeIndex,RecipeEventArgs e)
		{
//			if(OnStopCmd!=null)
//				OnStopCmd(RecipeIndex,e);

			if (OnStopCmd != null)
			{
				RecipeEventHandler messageDelegate = null;
				Delegate[] invocationList_ = null;
				try
				{
					invocationList_ = OnStopCmd.GetInvocationList();
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
								messageDelegate = (RecipeEventHandler)del;
								messageDelegate(RecipeIndex,e);
							}
							catch
							{
								OnStopCmd -= messageDelegate;
							}
						}
					}
				}
			}
		}

		public virtual void HandlerOnRefresh(RecipeEventArgs e)
		{
//			if(OnRefresh!=null)
//				OnRefresh(e);

			if (OnRefresh != null)
			{
				MessageEventHandler messageDelegate = null;
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
								messageDelegate = (MessageEventHandler)del;
								messageDelegate(e);
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
