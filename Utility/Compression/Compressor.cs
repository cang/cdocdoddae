using System;
using System.IO;

namespace SiGlaz.Utility.Compression
{
	public class Compressor
	{
		private static bool   _MultiInstance = false;	
		private static object _syncDeflatorObject = new object();
		private static object _syncInflatorObject = new object();

		private static void Write(byte[] lpbyte,string filepath)
		{
			if(File.Exists(filepath) )
			{
				File.SetAttributes(filepath,FileAttributes.Normal);
				File.Delete(filepath);
			}

			FileStream fs = null;
			try
			{
				fs = File.Create(filepath);
				fs.Write(lpbyte,0,lpbyte.Length);
				fs.Flush();
			}
			catch
			{
				throw;
			}
			finally
			{
				if(fs!=null)
				{
					fs.Close();
					fs = null;
				}
			}
		}

		private static byte[] Read(string filepath)
		{
			if( !File.Exists(filepath) )
				return null;

			FileStream fs = null;
			try
			{
				fs = File.OpenRead(filepath);
				int length = (int)fs.Length;
				byte[] lpbyte = new byte[fs.Length];
				fs.Read(lpbyte,0,length);
				return lpbyte;
			}
			catch
			{
				throw;
			}
			finally
			{
				if(fs!=null)
				{
					fs.Close();
					fs = null;
				}
			}
		}


		public  static bool MultiInstance
		{
			get
			{
				return _MultiInstance;
			}
			set
			{
				_MultiInstance = value;
			}
		}

		public static byte[] Compress(byte[] buffer)
		{
			if(!_MultiInstance)
			{
				lock (_syncDeflatorObject)
				{
					return Deflator.Instance.Compress(buffer, 0, buffer.Length, CompressionLevel.Maximum, 0, 0);
				}
			}
			else
			{
				Deflator defInstance = new Deflator();
				byte[] lpbyte = defInstance.Compress(buffer, 0, buffer.Length, CompressionLevel.Maximum, 0, 0);
				defInstance = null;
				return lpbyte;
			}
		}

		public static byte[] Compress(string filepath)
		{
			return Compress(Read(filepath));
		}

		public static void CompressToFile(byte[] buffer,string filepath)
		{
			Write( Compress(buffer) , filepath);
		}
		public static void CompressToFile(string sourcefile,string desfile)
		{
			Write( Compress( Read(sourcefile) ) , desfile);
		}

		public static byte[] DeCompress(byte[] buffer)
		{
			if(!_MultiInstance)
			{
				lock (_syncInflatorObject)
				{
					return Inflator.Instance.Decompress(buffer, 0, 0, 0);
				}
			}
			else
			{
				Inflator infInstance = new Inflator();
				byte[] lpbyte = infInstance.Decompress(buffer, 0, 0, 0);
				infInstance = null;
				return lpbyte;
			}
		}

		public static byte[] DeCompress(string filepath)
		{
			return DeCompress( Read(filepath) );
		}

		public static void DeCompressToFile(byte[] buffer,string filepath)
		{
			Write( DeCompress(buffer),filepath );
		}

		public static void DeCompressToFile(string sourcefile,string desfile)
		{
			Write( DeCompress( Read(sourcefile) ) , desfile);
		}


	}
}
