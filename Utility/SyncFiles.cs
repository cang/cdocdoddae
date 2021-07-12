using System;
using System.IO;

//NOT USING NOW

namespace SiGlaz.Utility
{
	public class SyncFiles
	{
		public SyncFiles()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static bool DeleteFile (string  fileName )
		{
			object interProcessResourceAccessObject = null;
		
			try
			{
				bool hasSignal = false;
				hasSignal = SyncFunc.BeginSynchResource(fileName, ref interProcessResourceAccessObject);

				if (!hasSignal) return false;

				return DeleteFileAsync(fileName);
			}
			catch //( Exception ex )
			{
				throw ;
			}
			finally 
			{
				SyncFunc.EndSynchResource(fileName, ref interProcessResourceAccessObject);
			}
		}

		private static bool DeleteFileAsync(string  fileName )
		{
			try
			{
				if ( ExistsFile( fileName ) )
				{
					File.SetAttributes( fileName,FileAttributes.Normal);
					File.Delete( fileName );
					return true;
				}
			}
			catch(IOException ex)
			{
				ex.Source="Utility.DeleteFile()";
				throw ex;
			}
			return false;
		}

		public static bool MoveFile (string sourceFileName, string destFileName)
		{
			if(Path.GetFileName(destFileName)=="")
			{
				destFileName=Path.Combine( Path.GetDirectoryName(destFileName),Path.GetFileName(sourceFileName));
			}			
			object interProcessResourceAccessObject = null;
		
			try
			{
				bool hasSignal = false;
				hasSignal = SyncFunc.BeginSynchResource(sourceFileName,destFileName, ref interProcessResourceAccessObject);

				if (!hasSignal) return false;

				return MoveFileAsync(sourceFileName, destFileName);
			}
			catch //( Exception ex )
			{
				throw ;
			}
			finally 
			{
				SyncFunc.EndSynchResource(sourceFileName,destFileName, ref interProcessResourceAccessObject);
			}
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
				ex.Source="Utility.ExistsFile()";
				throw ex;
			}
			return false;
		}

		private static bool MoveFileAsync (string  fromPath,string toPath)
		{
			try
			{
				if ( toPath==null || toPath==string.Empty ) return false;
				if (ExistsFile(fromPath))
				{
					//DeleteFile(toPath);
					string toDir=Path.GetDirectoryName(toPath);//only string process
					if(!Directory.Exists(toDir)) CreateFolder(toDir);


					File.Move(fromPath,toPath);
					return true;
				}
			}			
			catch//(Exception ex)
			{
				//ex.Source="Utility.MoveFile()";
				//WriteToTraceLog(ex,"Utility.MoveFile()");
				throw;
			}
			return false;
		}
		public static bool CreateFolder (string  folder )
		{
			object interProcessResourceAccessObject = null;
		
			try
			{
				bool hasSignal = false;
				hasSignal = SyncFunc.BeginSynchResource(folder, ref interProcessResourceAccessObject);

				if (!hasSignal) return false;

				return CreateFolderAsync(folder);
			}
			catch //( Exception ex )
			{
				throw ;
			}
			finally 
			{
				SyncFunc.EndSynchResource(folder, ref interProcessResourceAccessObject);
			}
		}
		private static bool CreateFolderAsync(string  folder )
		{
			try
			{
				Directory.CreateDirectory(folder);
				return true;
				
			}
			catch(IOException ex)
			{
				ex.Source="Utility.CreateFolderAsync()";
				throw ex;
			}
		}
		private static void CopyFileAsync(string sourceFileName, string destFileName)
		{	
			File.Copy ( sourceFileName ,destFileName,true);
		}

		public static void CopyFile(string sourceFileName, string destFileName)
		{			
			if(Path.GetFileName(destFileName)=="")
			{
				destFileName=Path.Combine( Path.GetDirectoryName(destFileName),Path.GetFileName(sourceFileName));
			}
			object interProcessResourceAccessObject = null;
		
			try
			{
				bool hasSignal = false;
				hasSignal = SyncFunc.BeginSynchResource(sourceFileName,destFileName, ref interProcessResourceAccessObject);

				if (!hasSignal) return;

				CopyFileAsync(sourceFileName, destFileName);
			}
			catch //( Exception ex )
			{
				throw ;
			}
			finally 
			{
				SyncFunc.EndSynchResource(sourceFileName,destFileName, ref interProcessResourceAccessObject);
			}
		}
	}
}
