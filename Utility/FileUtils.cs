using System;
using System.IO;

namespace SiGlaz.Utility
{
	/// <summary>
	/// Summary description for FileUtils.
	/// </summary>
	public class FileUtils
	{
		public FileUtils()
		{
		}

		public static bool ExistsFile (string  fileName )
		{
			try
			{
				if ( fileName==null || fileName==string.Empty ) return false;
				if ( File.Exists ( fileName ) )
					return true;
			}
			catch(IOException ex)
			{
				ex.Source="FileUtils.ExistsFile()";
				throw ex;
			}
			return false;
		}

		public static bool DeleteFile (string  fileName )
		{
			try
			{
				if(ExistsFile(fileName))
				{
					File.SetAttributes(fileName,FileAttributes.Normal);
					File.Delete(fileName );
					return true;
				}
			}
			catch(IOException ex)
			{
				ex.Source="FileUtils.DeleteFile()";
				throw ex;
			}
			finally 
			{
			}
			return false;
		}

		public static void CopyContentManual(string sourceFileName, string destFileName)
		{
			FileStream fsSource = null;
			FileStream fsDes = null;
			BinaryReader br = null;
			BinaryWriter bw = null;

			try
			{
				//SiGlaz.Utility.DebugLog.Write("fsSource = new FileStream");
				fsSource = new FileStream(sourceFileName,FileMode.Open,FileAccess.Read,FileShare.ReadWrite);

				//SiGlaz.Utility.DebugLog.Write("fsDes = new FileStream");
				fsDes = new FileStream(destFileName,FileMode.Create,FileAccess.Write,FileShare.None);

				//SiGlaz.Utility.DebugLog.Write("br = new BinaryReader");
				br = new BinaryReader(fsSource);

				//SiGlaz.Utility.DebugLog.Write("bw = new BinaryWriter(fsDes);");
				bw = new BinaryWriter(fsDes);

				int nbuff = 255;
				byte[] lpbyte = null;

				while(br.PeekChar()>-1)
				{
					lpbyte = br.ReadBytes(nbuff);
					if(lpbyte!=null)
					{
						bw.Write(lpbyte);
					}
				}
			}
			catch
			{
				throw;
			}
			finally
			{
				if(br!=null)
				{
					br.Close();
					br = null;
				}
				if(bw!=null)
				{
					bw.Close();
					bw = null;
				}
				if(fsSource!=null)
				{
					fsSource.Close();
					fsSource = null;
				}
				if(fsDes!=null)
				{
					fsDes.Close();
					fsDes = null;
				}
			}
		}

		public static void CopyFile(string sourceFileName, string destFileName)
		{			
			try
			{
				DeleteFile(destFileName);
				CreateDirectory(Path.GetDirectoryName(destFileName));
				File.Copy(sourceFileName,destFileName);
			}
			catch(IOException ex)
			{
				ex.Source="FileUtils.CopyFile()";
				throw ex;
			}
			finally 
			{
			}
		}

		public static void CopyFileManual(string sourceFileName, string destFileName)
		{			
			try
			{
				DeleteFile(destFileName);
				CreateDirectory(Path.GetDirectoryName(destFileName));
				CopyContentManual(sourceFileName,destFileName);
			}
			catch(IOException ex)
			{
				ex.Source="FileUtils.CopyFile()";
				throw ex;
			}
			finally 
			{
			}
		}


		public static void MoveFile(string sourceFileName, string destFileName)
		{			
			try
			{
				CopyFile(sourceFileName,destFileName);
				DeleteFile(sourceFileName);
			}
			catch(IOException ex)
			{
				ex.Source="FileUtils.MoveFile()";
				throw ex;
			}
			finally 
			{
			}
		}

		public static bool ExistsDirectory(string  dirpath )
		{
			try
			{
				if ( dirpath==null || dirpath==string.Empty ) return false;
				if ( Directory.Exists ( dirpath ) )
					return true;
			}
			catch(IOException ex)
			{
				ex.Source="FileUtils.DirectoryFile()";
				throw ex;
			}
			return false;
		}

		public static bool CreateDirectory(string dirpath)
		{
					
			try
			{
				if(ExistsDirectory(dirpath)) return false;
				Directory.CreateDirectory(dirpath);
				return true;
			}
			catch(IOException ex)
			{
				ex.Source="FileUtils.CreateDirectory()";
				throw ex;
			}
			finally 
			{
			}
		}


		public static void DeleteDirectory(string  dirpath)
		{
			if ( dirpath==null || dirpath==string.Empty ) return;
			if(!ExistsDirectory(dirpath)) return;
			try
			{
				Directory.Delete(dirpath,true);
			}
			catch(IOException ex)
			{
				ex.Source="FileUtils.DeleteDirectory()";
				throw ex;
			}
		}


		public static bool FileReplaceContent(string source,string des,string seachpattern,string replacepattern)
		{
			if(!System.IO.File.Exists(source)) return false;
			DeleteFile(des);

			System.IO.StreamReader sr = null;
			System.IO.StreamWriter sw = null;

			try
			{
				sr = System.IO.File.OpenText(source);
				sw = System.IO.File.CreateText(des);

				string sall = sr.ReadToEnd();
				sall = sall.Replace(seachpattern,replacepattern);
				sw.Write(sall);
				return true;
			}
			catch
			{
				return false;
			}
			finally
			{
				if(sr!=null)
				{
					sr.Close();
					sr = null;
				}
				if(sw!=null)
				{
					sw.Close();
					sw=null;
				}
			}
		}


	}
}
