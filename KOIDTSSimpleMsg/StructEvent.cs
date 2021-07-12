using System;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

namespace KOIDTSSimpleMsg
{

	[Serializable]
	public class MessageEvent : EventArgs
	{
		public MessageEvent()
		{
		}
		public MessageEvent(string msg)
		{
			Message = msg;
		}

		public string Message = string.Empty;
	}

}
