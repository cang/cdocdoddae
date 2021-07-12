using System;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace CreateDDADB
{
	public class DBFuncs
	{
		public DBFuncs()
		{

		}

		public bool DetachDatabase(string ServerName, string DatabaseName, string UserName, string Password, string path)
		{
			string strFileTemp=Application.StartupPath+"\\detack_db.sql";
			string outputFile = Application.StartupPath + "\\output.txt";
			bool bResult=true;

			System.Reflection.Assembly thisExe;
			thisExe = System.Reflection.Assembly.GetExecutingAssembly();
			System.IO.Stream file = thisExe.GetManifestResourceStream("CreateDDADB.Data.detack_db.sql");


			try
			{
				byte[] buff = new byte[file.Length];
				file.Read(buff, 0, (int)file.Length);

				string strSQL = System.Text.Encoding.ASCII.GetString(buff, 0, buff.Length);

				strSQL = strSQL.Replace("#DBNAME",DatabaseName);
				StreamWriter sw = new StreamWriter(strFileTemp, false,System.Text.Encoding.ASCII);
				sw.Write(strSQL);
				sw.Close();

				string args=String.Format("-S{0} -U{1} -P{2} -i\"{3}\" -o\"{4}\"",ServerName,UserName,Password,strFileTemp, outputFile);
				Process p=new Process();
				ProcessStartInfo psinf=new ProcessStartInfo("osql.exe", args);	
				psinf.WindowStyle=ProcessWindowStyle.Hidden;
				p.StartInfo=psinf;
				p.StartInfo.WorkingDirectory=Application.StartupPath;
				p.Start();
				p.EnableRaisingEvents=true;
				p.WaitForExit();
				p.Close();

				StreamReader sr = new StreamReader(outputFile);
				string strOutput = sr.ReadToEnd();

				if (strOutput.IndexOf("SQL Server does not exist or access denied") >= 0 || strOutput.IndexOf("Login failed for user") >= 0 || strOutput.IndexOf("Cannot open user default database") >= 0 || strOutput.IndexOf("Cannot change default database belonging to someone else") >= 0 || strOutput.IndexOf("Cannot alter the login 'sa'") >= 0 || strOutput.IndexOf("Cannot detach the database") >= 0)
				{
					bResult = false;
					MessageBox.Show(strOutput, "Create DDADB", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					string mdfFile = string.Format("{0}\\{1}_Data.MDF", path, DatabaseName);
					string logFile = string.Format("{0}\\{1}_Log.LDF", path, DatabaseName);

					if (File.Exists(mdfFile))
						File.Delete(mdfFile);

					if (File.Exists(logFile))
						File.Delete(logFile);
				}
				
				sr.Close();
			}
			catch(Exception ex)
			{
				bResult=false;
				MessageBox.Show(ex.Message,"Create DDADB",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			finally
			{
				if (file != null)
				{
					file.Close();
					file = null;
				}
				File.Delete(strFileTemp);
			}

			return bResult;
		}

		public bool RunScript(string ServerName, string DatabaseName,string UserName, string Password,string resourcvename,params string[]pr)
		{
			string strFileTemp=Application.StartupPath+"\\TempScript.sql";

			bool bResult=true;

			string name = resourcvename;

			System.Reflection.Assembly thisExe;
			thisExe = System.Reflection.Assembly.GetExecutingAssembly();
			System.IO.Stream file = thisExe.GetManifestResourceStream(name);

			try
			{
				byte[] buff = new byte[file.Length];
				file.Read(buff, 0, (int)file.Length);

				string strSQL = System.Text.Encoding.ASCII.GetString(buff, 0, buff.Length);
				string password = "DDADBPassword";

				if(pr!=null && pr.Length>0)
				{
					strSQL=strSQL.Replace("#DBTYPE",pr[0]);//add new
				}

				strSQL=strSQL.Replace("#DBNAME",DatabaseName).Replace("#PASSWORD", password);
				StreamWriter sw=new StreamWriter(strFileTemp,false,System.Text.Encoding.ASCII);
				sw.Write(strSQL);
				sw.Close();

				string args=String.Format("-S{0} -U{1} -P{2} -i\"{3}\"",ServerName,UserName,Password,strFileTemp);
				Process p=new Process();
				ProcessStartInfo psinf=new ProcessStartInfo("osql.exe", args);	
				psinf.WindowStyle=ProcessWindowStyle.Hidden;
				p.StartInfo=psinf;
				p.StartInfo.WorkingDirectory=Application.StartupPath;
				p.Start();
				p.EnableRaisingEvents=true;
				p.WaitForExit();
				p.Close();
			}
			catch(Exception ex)
			{
				bResult=false;
				MessageBox.Show(ex.Message,"Create DDADB",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			finally
			{
				if (file != null)
				{
					file.Close();
					file = null;
				}
				File.Delete(strFileTemp);
			}

			return bResult;
		}


		public bool RunScriptDatabase(string ServerName, string DatabaseName,string UserName, string Password)
		{
			string strFileTemp=Application.StartupPath+"\\ScriptDatabase.sql";
			bool bResult=true;

			string name = string.Empty;

			name = "CreateDDADB.Data.ScriptDatabase.sql";

			System.Reflection.Assembly thisExe;
			thisExe = System.Reflection.Assembly.GetExecutingAssembly();
			System.IO.Stream file = thisExe.GetManifestResourceStream(name);

			try
			{
				byte[] buff = new byte[file.Length];
				file.Read(buff, 0, (int)file.Length);

				string strSQL = System.Text.Encoding.ASCII.GetString(buff, 0, buff.Length);
				string password = "DDADBPassword";
				
				strSQL=strSQL.Replace("#DBNAME",DatabaseName).Replace("#PASSWORD", password);
				StreamWriter sw=new StreamWriter(strFileTemp,false,System.Text.Encoding.ASCII);
				sw.Write(strSQL);
				sw.Close();

				string args=String.Format("-S{0} -U{1} -P{2} -i\"{3}\"",ServerName,UserName,Password,strFileTemp);
				Process p=new Process();
				ProcessStartInfo psinf=new ProcessStartInfo("osql.exe", args);	
				psinf.WindowStyle=ProcessWindowStyle.Hidden;
				p.StartInfo=psinf;
				p.StartInfo.WorkingDirectory=Application.StartupPath;
				p.Start();
				p.EnableRaisingEvents=true;
				p.WaitForExit();
				p.Close();
			}
			catch(Exception ex)
			{
				bResult=false;
				MessageBox.Show(ex.Message,"Create DDADB",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			finally
			{
				if (file != null)
				{
					file.Close();
					file = null;
				}
				File.Delete(strFileTemp);
			}

			return bResult;
		}

		public bool CreateDatabase(string ServerName, string DatabaseName,string UserName, string Password, string PathName)
		{
			string strFileTemp = Application.StartupPath+"\\CreateDatabase.sql";
			bool bResult = true;
			string name = "CreateDDADB.Data.CreateDatabase.sql";

			System.Reflection.Assembly thisExe;
			thisExe = System.Reflection.Assembly.GetExecutingAssembly();
			System.IO.Stream file = thisExe.GetManifestResourceStream(name);

			try
			{
				byte[] buff = new byte[file.Length];
				file.Read(buff, 0, (int)file.Length);

				string strSQL = System.Text.Encoding.ASCII.GetString(buff, 0, buff.Length);
				strSQL = strSQL.Replace("#NAME", PathName).Replace("#DBNAME", DatabaseName);
				StreamWriter sw = new StreamWriter(strFileTemp, false,System.Text.Encoding.ASCII);
				sw.Write(strSQL);
				sw.Close();

				string args=String.Format("-S{0} -U{1} -P{2} -i\"{3}\"",ServerName,UserName,Password,strFileTemp);
				Process p=new Process();
				ProcessStartInfo psinf=new ProcessStartInfo("osql.exe", args);	
				psinf.WindowStyle=ProcessWindowStyle.Hidden;
				p.StartInfo=psinf;
				p.StartInfo.WorkingDirectory=Application.StartupPath;
				p.Start();
				p.EnableRaisingEvents=true;
				p.WaitForExit();
				p.Close();

				string mdfFile = string.Format("{0}\\{1}_Data.MDF", PathName, DatabaseName);
				string logFile = string.Format("{0}\\{1}_Log.LDF", PathName, DatabaseName);

				if (File.Exists(mdfFile) == false || File.Exists(logFile) == false)
				{
					bResult = false;
					MessageBox.Show("Cannot create database.", "Create DDADB", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch(Exception ex)
			{
				bResult = false;
				MessageBox.Show(ex.Message ,"Create DDADB", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			finally
			{
				if (file != null)
				{
					file.Close();
					file = null;
				}
				File.Delete(strFileTemp);
			}

			return bResult;
		}	

		public bool DropConnection(string ServerName, string DatabaseName,string UserName, string Password)
		{
			string strFileTemp=Application.StartupPath+"\\DropConnection.sql";
			string outputFile = Application.StartupPath + "\\output.txt";
			bool bResult=true;

			System.Reflection.Assembly thisExe;
			thisExe = System.Reflection.Assembly.GetExecutingAssembly();
			System.IO.Stream file = thisExe.GetManifestResourceStream("CreateDDADB.Data.DropConnection.sql");

			try
			{
				byte[] buff = new byte[file.Length];
				file.Read(buff, 0, (int)file.Length);

				string strSQL = System.Text.Encoding.ASCII.GetString(buff, 0, buff.Length);

				strSQL = strSQL.Replace("#DBNAME",DatabaseName);
				StreamWriter sw = new StreamWriter(strFileTemp, false,System.Text.Encoding.ASCII);
				sw.Write(strSQL);
				sw.Close();

				string args=String.Format("-S{0} -U{1} -P{2} -i\"{3}\" -o\"{4}\"",ServerName,UserName,Password,strFileTemp, outputFile);
				Process p=new Process();
				ProcessStartInfo psinf=new ProcessStartInfo("osql.exe", args);	
				psinf.WindowStyle=ProcessWindowStyle.Hidden;
				p.StartInfo=psinf;
				p.StartInfo.WorkingDirectory=Application.StartupPath;
				p.Start();
				p.EnableRaisingEvents=true;
				p.WaitForExit();
				p.Close();
			}
			catch(Exception ex)
			{
				bResult=false;
				MessageBox.Show(ex.Message,"Create DDADB",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			finally
			{
				if (file != null)
				{
					file.Close();
					file = null;
				}
				File.Delete(strFileTemp);
			}

			return bResult;
		}

	}
}
