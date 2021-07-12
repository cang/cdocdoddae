using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;

namespace SiGlaz.Common
{
	/// <summary>
	/// Summary description for XMLSerialize.
	/// </summary>
	public class StringBuilderSerialize
	{
		//private const int DefaultBufferSize = 0x400;

		public StringBuilderSerialize()
		{
		}

		public static void Serialize(Stream stream,StringBuilder sbData)
		{
			if(sbData == null )
				return;

            StreamWriter sw = null;		
			try
			{
				sw = new StreamWriter(stream);
				sw.Write(sbData.ToString());
//				int length = sbData.Length;
//				int buffsize = 0;
//				int pos = 0;
			}
			catch
			{
				throw;
			}
			finally
			{
				if(sw!=null)
				{
					sw.Close();
					sw=null;
				}
			}
		}
		public static void Serialize(string filepath,	StringBuilder obj)
		{
			if( File.Exists(filepath))
			{
				File.SetAttributes(filepath,FileAttributes.Normal);
				File.Delete(filepath);
			}

			FileStream fs =null;
			try
			{
				fs = File.Create(filepath);
				Serialize(fs,obj);
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

		public static string Deserialize(Stream stream)
		{
			StreamReader sr = null;
			try
			{
				return sr.ReadToEnd();
			}
			catch
			{
				throw;
			}
			finally
			{
				if(sr!=null)
				{
					sr.Close();
					sr=null;
				}
			}
		}

		public static string Deserialize(string filepath)
		{
			if(!File.Exists(filepath))
				throw new IOException("File do not exist");

			FileStream fs =null;
			try
			{
				fs = File.Open(filepath,FileMode.Open,FileAccess.Read,FileShare.Read);
				return Deserialize(fs);
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


		public static byte[] Serialize(StringBuilder obj)
		{
			if(obj==null) return null;

			MemoryStream ms = null;
			try
			{
				ms = new MemoryStream();
				Serialize(ms,obj);
				ms.Flush();
				return ms.ToArray();
			}
			catch
			{
				throw;
			}
			finally
			{
				if(ms!=null)
				{
					ms.Close();
					ms = null;
				}
			}
		}

		public static string Deserialize(byte[] lpbyte)
		{
			if(lpbyte==null) return null;
			MemoryStream ms = null;
			try
			{
				ms = new MemoryStream(lpbyte);
				return Deserialize(ms);
			}
			catch
			{
				throw;
			}
			finally
			{
				if(ms!=null)
				{
					ms.Close();
					ms = null;
				}
			}
		}


	}
}
