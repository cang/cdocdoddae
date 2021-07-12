using System;
using System.Threading;
using System.Windows.Forms;

namespace SiGlaz.Utility
{
	/// <summary>
	/// Summary description for ControlWin32.
	/// </summary>
	public class ControlWin32
	{
		public ControlWin32()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public const int WM_VSCROLL = 277;
		public const int SB_BOTTOM = 7;
		public static void ScrollToBottom(Control ctrl)
		{
			try
			{
				Monitor.Enter(ctrl);
				SiGlaz.Utility.Win32.User32.SendMessage(ctrl.Handle,
					WM_VSCROLL,(uint)SB_BOTTOM,(uint)0); 
			}
			finally
			{
				Monitor.Exit(ctrl);
			}
		}
	}
}
