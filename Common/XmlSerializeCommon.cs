using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SiGlaz.Common
{
	/// <summary>
	/// Summary description for XMLSerialize.
	/// </summary>
	public class XmlSerializeCommon
	{
		public XmlSerializeCommon()
		{
		}

		public static void Serialize(Stream stream,object obj)
		{
			XmlSerializer xml = null;
			try
			{
				xml = new XmlSerializer(obj.GetType());
				xml.Serialize(stream,obj);
			}
			catch
			{
				throw;
			}
			finally
			{
				if(xml!=null)
				{
					xml=null;
				}
			}
		}
		public static void Serialize(string filepath,	object obj)
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

		public static object Deserialize(Stream stream,Type type)
		{
			XmlSerializer xml = null;
			try
			{
				xml = new XmlSerializer(type);
				return xml.Deserialize(stream);
			}
			catch
			{
				throw;
			}
			finally
			{
				if(xml!=null)
				{
					xml=null;
				}
			}
		}

		public static object Deserialize(string filepath,Type type)
		{
			if(!File.Exists(filepath))
				throw new IOException("File do not exist");

			FileStream fs =null;
			try
			{
				fs = File.Open(filepath,FileMode.Open,FileAccess.Read,FileShare.Read);
				return Deserialize(fs,type);
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


		public static byte[] Serialize(object obj)
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

		public static object Deserialize(byte[] lpbyte,Type type)
		{
			if(lpbyte==null) return null;
			MemoryStream ms = null;
			try
			{
				ms = new MemoryStream(lpbyte);
				return Deserialize(ms,type);
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
