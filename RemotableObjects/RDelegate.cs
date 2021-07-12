using System;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

namespace DDADBRObjects
{
	/// <summary>
	/// Represents the method that will handle the R.RemoteClass.MessageReceived event.
	/// </summary>
	/// <param name="message">Received message</param>
	[Serializable]
	[ComVisible(true)]
	public delegate void MessageHandler(string message);

	[Serializable]
	[ComVisible(true)]
	public delegate void SchemaHandler(SchemaEvent e);

	[Serializable]
	[ComVisible(true)]
	public delegate void EventHandlerProcess(string filepath,ProcessEventArgs e);

	[Serializable]
	[ComVisible(true)]
	public delegate void EventHandlerProcessInfor(string description,ProcessBaseEventArgs e);

	[Serializable]
	[ComVisible(true)]
	public delegate void EventHandlerProcessError(string msg,FileControllerErrorEventArgs e);

	[Serializable]
	[ComVisible(true)]
	public delegate void EventHandlerCheckFormat(string filepath,CheckFormatEventArgs e);



}
