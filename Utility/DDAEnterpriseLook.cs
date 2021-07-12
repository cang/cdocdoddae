using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
namespace SiGlaz.Utility
{
	/// <summary>
	/// Summary description for DDAEnterpriseLook.
	/// </summary>
	public class DDAEnterpriseLook
	{			
		private static Semaphore _locker = null;
	
		public static bool Begin(int _threadLimit, string AppLookName)
		{
			string _lockName =  string.Format("Global\\SiGlaz.{0}",AppLookName);
			_locker = new Semaphore(_threadLimit, _lockName);
			int timeOut = _locker.Wait(100);
			if (timeOut == WaitHandle.WaitTimeout)
			{
				string msg = string.Format("{0} only permits user to run {1} applications in one computer at the same time, please check !!!",Application.ProductName,_threadLimit);
				MessageBox.Show(null, msg, Application.ProductName);
				return false;
			}
	
			return true;
		}
	
		public static void End()
		{
			if (_locker != null)
				_locker.Release();
			_locker = null;
		}
	}
}
