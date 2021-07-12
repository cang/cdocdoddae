using System;
using System.Threading;

namespace SiGlaz.Utility
{
	/// <summary>
	/// Summary description for GlobalLock.
	/// </summary>
	public class GlobalLock : IDisposable
	{
		Mutex mt = null;

		public GlobalLock(string name)
		{
			name = name.Replace(@"\","_");
			string _lockName =  string.Format("Global\\SiGlaz.{0}",name);
			mt = new Mutex(false,_lockName);
		}

		public void WaitOne()
		{
			mt.WaitOne();
		}

		public bool WaitOne(int seconds)
		{
			return mt.WaitOne(seconds*1000,false);
		}

		public void Release()
		{
			mt.ReleaseMutex();
		}

		#region IDisposable Members

		public void Dispose()
		{
			mt.Close();
			mt = null;
		}

		#endregion

	}
}
