using System;
using System.Windows.Forms;

namespace SiGlaz.Utility
{
	/// <summary>
	/// Summary description for KeyProcess.
	/// </summary>
	public class KeyProcess
	{
		public KeyProcess()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static bool NoShiftAndControlKeyPressed
		{
			get
			{
				bool selectone=(Control.ModifierKeys & Keys.Control) != Keys.Control 
					&&
					(Control.ModifierKeys & Keys.Shift) != Keys.Shift;
				return selectone;
			}
		}

		
	}
}
