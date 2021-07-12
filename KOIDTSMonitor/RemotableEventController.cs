using System;
using KOIDTSSimpleMsg;


namespace KOIDTSMonitor
{
	/// <summary>
	/// Summary description for RemotableEventController.
	/// </summary>
	public class RemotableEventController
	{
		public static RemotableEventController Controler = new RemotableEventController();

		public RObject	_remoteObj = null;
		public REvent	_remoteEvent = new REvent();

		public RemotableEventController()
		{
		}

		public void InitRemotingObjects()
		{
			_remoteObj= new RObject();
			_remoteObj.OnMessageSimple+=new MessageHandlerSimple(_remoteEvent.HandlerOnMessageSimple);

			_remoteEvent.OnMessageSimple+=new MessageHandlerSimple(_remoteEvent_OnMessageSimple);
		}

		private void _remoteEvent_OnMessageSimple(object obj, string msg)
		{
			Console.WriteLine(msg);
		}
	}
}
