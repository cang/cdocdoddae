using System;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Collections;

namespace KOIDTSSimpleMsg
{
	/// <summary>
	/// Summary description for Cache.
	/// </summary>
	public class Cache
	{
		private static Cache myInstance;
		//		public static IObserver Observer;

		
		
		private Cache()
		{
		}

		public static Cache GetInstance()
		{
			if(myInstance==null)
			{
				myInstance = new Cache();
			}
			return myInstance;
		}

		private Hashtable _objects = new Hashtable();
		public void InitRemoting()
		{
			foreach (WellKnownServiceTypeEntry entry in RemotingConfiguration.GetRegisteredWellKnownServiceTypes())
			{
				MarshalByRefObject pxy = (MarshalByRefObject) Activator.GetObject(entry.ObjectType, "tcp://localhost:11000/" + entry.ObjectUri);
				pxy.CreateObjRef(entry.ObjectType);
				_objects[pxy.GetType()] = pxy;
			}
		}
	
		public object GetRemoteSingletonObject(Type type)
		{
			return _objects[type];
		}

	}
}
