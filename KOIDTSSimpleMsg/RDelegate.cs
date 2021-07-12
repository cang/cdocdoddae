using System;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;


namespace KOIDTSSimpleMsg
{
	/// <summary>
	/// Summary description for RDelegate.
	/// </summary>
	/// 
	[Serializable]
	[ComVisible(true)]
	public delegate			void			MessageHandler(object obj,MessageEvent e);

	[Serializable]
	[ComVisible(true)]
	public delegate			void			MessageHandlerSimple(object obj,string msg);

}
