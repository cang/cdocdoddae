using System;
using System.Threading;

//NOT USING NOW

namespace SiGlaz.Utility
{
	public class SyncFunc
	{
		public static string EndSynchResource(string  resourceName, ref object interProcessResourceAccessObject)
		{
			try
			{
				Mutex interProcessResourceAccessMutex = interProcessResourceAccessObject as Mutex;
				//realse mutex
				if (interProcessResourceAccessMutex != null)
				{
					interProcessResourceAccessMutex.ReleaseMutex();
					interProcessResourceAccessMutex.Close();
					interProcessResourceAccessMutex = null;
					interProcessResourceAccessObject =	null;
				}			
			}
			catch(Exception ex)
			{
				return ex.Message;
			}
			return "";
		}

		public static string EndSynchResource(string  resourceName)
		{
			object obj = null;
			return EndSynchResource(resourceName,ref obj);
		}

		public static string EndSynchResource(ref object interProcessResourceAccessObject)
		{
			try
			{
				Mutex interProcessResourceAccessMutex = interProcessResourceAccessObject as Mutex;
				//realse mutex
				if (interProcessResourceAccessMutex != null)
				{
					interProcessResourceAccessMutex.ReleaseMutex();
					interProcessResourceAccessMutex.Close();
					interProcessResourceAccessMutex = null;
					interProcessResourceAccessObject =	null;
				}			
			}
			catch(Exception ex)
			{
				return ex.Message;
			}
			return "";
		}


		public static bool BeginSynchResource(string  resourceName, ref object interProcessResourceAccessObject)
		{
			bool hasSignal = false;
			Mutex interProcessResourceAccessMutex = null;
			try
			{
				//create mutex
				string asyncName =InterprocessObjNameTranslate(resourceName);
				interProcessResourceAccessMutex = new Mutex(false,asyncName);
				hasSignal =	interProcessResourceAccessMutex.WaitOne(300000, false);//wait for max 5 minutes = 5 x 60 seconds x 1000 
				interProcessResourceAccessObject = interProcessResourceAccessMutex as Object;
				return hasSignal;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public static bool BeginSynchResource(string  resourceName)
		{
			object obj = null;
			return BeginSynchResource(resourceName,ref obj);
		}


		public static bool BeginSynchResource(string  resourceName,string  destinationName,  ref object interProcessResourceAccessHandles)
		{
			bool hasSignal = false;
			Mutex[] mutexObjects=null;

			try
			{
				mutexObjects=new Mutex[2];
				mutexObjects[0]=null;
				mutexObjects[1]=null;


				//create mutex
				string asyncResourceName =InterprocessObjNameTranslate(resourceName);
				string asyncDestinationName =InterprocessObjNameTranslate(destinationName);

				Mutex interProcessResourceAccessMutex = new Mutex(false,asyncResourceName);
				Mutex interProcessDestinationAccessMutex = new Mutex(false,asyncDestinationName);
				mutexObjects[0]=interProcessResourceAccessMutex;
				mutexObjects[1]=interProcessDestinationAccessMutex;
				
				hasSignal =	interProcessDestinationAccessMutex.WaitOne(300000, false);//wait for max 5 minutes = 5 x 60 seconds x 1000 
				if(hasSignal)
				{
					hasSignal =	interProcessResourceAccessMutex.WaitOne(300000, false);//wait for max 5 minutes = 5 x 60 seconds x 1000 
				}

				interProcessResourceAccessHandles = mutexObjects as Object;

				return hasSignal;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public static string EndSynchResource(string  resourceName,string  destinationName,  ref object interProcessResourceAccessHandles)
		{
			try
			{
				//ep kieu object ve handle
				Mutex[] mutexObjects=	interProcessResourceAccessHandles as Mutex[];
				if(mutexObjects!=null)
				{
					if(mutexObjects.Length==2)
					{
						Mutex interProcessResourceAccessMutex = mutexObjects[0];
						Mutex interProcessDestinationAccessMutex = mutexObjects[1];

						if (interProcessResourceAccessMutex != null)
						{
	
							interProcessResourceAccessMutex.ReleaseMutex();
							interProcessResourceAccessMutex.Close();
							interProcessResourceAccessMutex = null;							
						}	
						if (interProcessDestinationAccessMutex != null)
						{
	
							interProcessDestinationAccessMutex.ReleaseMutex();
							interProcessDestinationAccessMutex.Close();
							interProcessDestinationAccessMutex = null;							
						}	
					}
					mutexObjects=null;
					interProcessResourceAccessHandles=null;
				}		
			}
			catch(Exception ex)
			{
				return ex.Message;
			}
			return "";
		}
		static public string InterprocessObjNameTranslate(string str)
		{
			string finalName="DDA_" + str.Replace(@"\","_");
			return @"Global\" + finalName.ToUpper();
		}
	}
}
