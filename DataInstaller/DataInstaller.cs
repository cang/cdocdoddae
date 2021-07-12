using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using Microsoft.Win32;


namespace DataInstaller
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	[RunInstaller(true)]
	public class DataInstaller : Installer 
	{
		public override void Install( IDictionary mySavedState )
		{
			string setuplog = System.IO.Path.Combine(Context.Parameters["InstallDir"], "setup.log");
//			try
//			{
//				SiGlaz.ADLib.IDAUsers users = new SiGlaz.ADLib.IDAUsers();
//				string supath = System.IO.Path.Combine(Context.Parameters["InstallDir"], "su.dat");
//				if ( !users.Serialize(supath) )
//					System.Windows.Forms.MessageBox.Show(null, "Cannot create data file.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
//			}
//			catch
//			{
//			}

			//setup lisenceto
			StreamWriter sw =null;
			try
			{
				//LOG
				if( File.Exists(setuplog) )
				{
					File.SetAttributes(setuplog,FileAttributes.Normal);
					File.Delete(setuplog);
				}
				sw = new StreamWriter(setuplog);

				string sourcefile=System.IO.Path.Combine(Context.Parameters["SetupDir"],"Setup.lic");
				string desfile=System.IO.Path.Combine(Context.Parameters["InstallDir"],"App.cfig");
				string regString=string.Format("SOFTWARE\\{0}\\{1}",Context.Parameters["Manufacturer"],Context.Parameters["ProductName"]);

				//LOG
				sw.WriteLine( string.Format("REGISTRY AT : {0}",regString));
				sw.WriteLine( string.Format("SOURCE PATH : {0}",sourcefile));
				sw.WriteLine( string.Format("DESTINATION PATH : {0}",desfile));

				//try to fix someproblem with shared disk [2007-08-24]
				if(!System.IO.File.Exists(sourcefile) )
					if( sourcefile.IndexOf("\\") ==0) //only change when source file can not be opened
						sourcefile=sourcefile.Insert(0,"\\");

				//LOG
				sw.WriteLine( string.Format("SOURCE PATH AFTER CHECK : {0}",sourcefile));

				RegistryKey regItem=Registry.LocalMachine.OpenSubKey(regString,true);
				if(regItem==null )
					regItem=Registry.LocalMachine.CreateSubKey(regString);

				//Deploy direct from setup.lic file
				if( System.IO.File.Exists(sourcefile) )
				{
					//LOG
					sw.WriteLine( string.Format("GOTO IN LICENSE FILE AND DEPLOY PRODUCT"));

					ProductSecurity.DeployProduct(sourcefile,desfile);

					//Save to register
					string productid=ProductSecurity.GetProductID(sourcefile);
					string licenseto=ProductSecurity.GetLicenseTo(sourcefile);
					regItem.SetValue("ProductID",productid);
					regItem.SetValue("LicenseTo",licenseto);
					regItem.Close();

					//LOG
					sw.WriteLine( string.Format("PRODUCT ID : {0}",productid));
					sw.WriteLine( string.Format("LICENSE TO : {0}",licenseto));
				}
				else //check in register
				{
					//Get from register
					string productid=regItem.GetValue("ProductID",ProductSecurity.GenProductID()).ToString();
					string licenseto=regItem.GetValue("LicenseTo","Evaluation").ToString();

					//Save to desfile
					ProductSecurity.DeployProduct(desfile,productid,licenseto);
				}

			}
			catch(Exception ex)
			{
				//LOG
				sw.WriteLine("Exception Message : " + ex.Message);
				sw.WriteLine("Exception Trace : " + ex.StackTrace);
				sw.WriteLine("Exception ToString : " + ex.ToString());
			}
			finally
			{
				if(sw!=null)
				{
					sw.Close();
					sw = null;
				}
			}

			base.Install( mySavedState );
		}

//		public override void Uninstall(IDictionary savedState)
//		{
//			try
//			{
//				String filename = System.IO.Path.Combine(Context.Parameters["InstallDir"], "su.dat");
//				if ( System.IO.File.Exists(filename) )
//					System.IO.File.Delete(filename);
//
////				filename=System.IO.Path.Combine(Context.Parameters["InstallDir"],"App.cfig");
////				if ( System.IO.File.Exists(filename) )
////					System.IO.File.Delete(filename);
//			}
//			catch
//			{
//			}
//
//			base.Uninstall (savedState);
//		}

	}
}
