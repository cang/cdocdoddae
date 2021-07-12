using System;
using System.Runtime.Remoting;

namespace Server
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class DDADBManagerServer
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Console.WriteLine("DDADB Manager Server starting...");

           // SiGlaz.Utility.EventViewerLog.GlobalLog.WriteLogInformation("AAA");

			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

			WebServiceProxy.WebProxyFactory.MessageType = WebServiceProxy.WebProxyFactory.eMessageType.SystemEvent;

			DDADBRObjects.Cache.GetInstance().LoadApplicationData();

			DDARecipeRObjects.Cache.GetInstance().InitRemoting();
			DDARecipeRObjects.Cache.GetInstance().LoadApplicationData();

			Console.WriteLine("DDADB Manager Server start successfully");

			Console.ReadLine();

			DDADBRObjects.Cache.GetInstance().WhenStopService = true;
			DDADBRObjects.Cache.GetInstance().StopDefaultSchema();

			//Seach and kill all Running Recipes
			System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("DDARMProcess");
			if(processes!=null)
			{
				foreach(System.Diagnostics.Process p in processes)
				{
					p.Kill();
				}
			}

			SiGlaz.Utility.EventViewerLog.GlobalLog.Delete();
		
		}

	}
}
