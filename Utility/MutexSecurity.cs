using System;

namespace SiGlaz.Utility
{
	
	public class MutexSecurity
	{
		SecUtil.MutexSecurityNuetral mt = null;		
		public MutexSecurity(string name)
		{
			name = name.Replace(@"\","_");
			string _lockName =  string.Format("Global\\SiGlaz.{0}",name);
			mt = new SecUtil.MutexSecurityNuetral(_lockName);
		}

		public void WaitOne()
		{
			mt.WaitOne();
		}

		public void Done()
		{
			mt.Done();
		}
	}
}
