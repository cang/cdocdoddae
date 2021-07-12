using System;

namespace KOIDTSSimpleMsg
{
	/// <summary>
	/// Summary description for RObject.
	/// </summary>
	public class RObject : REvent,RMethod
	{
		public RObject()
		{
		}

		#region RMethod Members

		public void Hello(ComunicationObject obj)
		{
			if(obj!=null)
			{
				HandlerOnMessageSimple(null,"Hello :" + obj.Mgs);
			}
		}

		public void Start()
		{
			//Cache.ServerProcess.StartProcess();
		}

		public void Stop()
		{
			//Cache.ServerProcess.StopProcess();
		}


		#endregion
	}

}
