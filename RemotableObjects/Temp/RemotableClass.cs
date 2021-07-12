using System;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;


namespace DDADBRObjects
{

	/// <summary>
	/// Shared remoting class that orchestrate messaging tasks 
	/// </summary>
	public class RemoteClass:MarshalByRefObject
	{
        
		/// <summary>
		/// Occurs when a broadcast message received.
		/// </summary>
		public event MessageHandler MessageReceived;

		/// <summary>
		/// Initializes a new instance of the R.RemoteClass class.
		/// </summary>
		public RemoteClass()
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
			return null;
		}

		/// <summary>
		/// Broadcast message to all clients
		/// </summary>
		/// <param name="message">message string</param>
		public void Send(string message)
		{
			Console.WriteLine("SERVER Received messge " + message);

			if (MessageReceived != null)
				MessageReceived(message);

//			if (MessageReceived != null)
//			{
//				MessageHandler messageDelegate = null;
//				Delegate[] invocationList_ = null;
//				try
//				{
//					invocationList_ = MessageReceived.GetInvocationList();
//				}
//				catch (MemberAccessException ex)
//				{
//					throw ex;
//				}
//				if (invocationList_ != null)
//				{
//					lock (this)
//					{
//						foreach (Delegate del in invocationList_)
//						{
//							try
//							{
//								messageDelegate = (MessageHandler)del;
//								messageDelegate(message);
//							}
//							catch (Exception e)
//							{
//								MessageReceived -= messageDelegate;
//							}
//						}
//					}
//				}
//			}
		}


	}


    

}
