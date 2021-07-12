using System;
using System.IO;

namespace SiGlaz.SharedMemory
{
	/// <summary>
	/// Summary description for SharedData.
	/// </summary>
	public class SharedData
	{
		public SharedData()
		{
		}

		#region archive
		public virtual void Serialize(BinaryWriter stream)
		{

		}

		public virtual void Deserialize(BinaryReader stream)
		{
		}

		public int		Length
		{
			get
			{
				MemoryStream stream = null;
				BinaryWriter bw  = null;
				try
				{
					stream = new MemoryStream();
					bw = new BinaryWriter(stream);
					this.Serialize(bw);
					bw.Flush();
					return (int)stream.Length;
				}
				catch
				{
					return DefaultLength;
				}
				finally
				{
					if(bw!=null)
					{
						bw.Close();
						bw = null;
					}
					if(stream!=null)
					{
						stream.Close();
						stream = null;
					}
				}
			}
		}
		public virtual byte[] SerializeBinary()
		{
			MemoryStream stream = null;
			BinaryWriter bw  = null;
			try
			{
				stream = new MemoryStream();
				bw = new BinaryWriter(stream);
				this.Serialize(bw);
				bw.Flush();
				return stream.ToArray();
			}
			catch
			{
				throw;
			}
			finally
			{
				if(bw!=null)
				{
					bw.Close();
					bw = null;
				}
				if(stream!=null)
				{
					stream.Close();
					stream = null;
				}
			}
		}

		public virtual void SerializeBinary(string filepath)
		{
			if( File.Exists(filepath))
			{
				File.SetAttributes(filepath,FileAttributes.Normal);
				File.Delete(filepath);
			}

			FileStream fs =null;
			BinaryWriter bw  = null;
			try
			{
				fs = File.Create(filepath);
				bw = new BinaryWriter(fs);
				this.Serialize(bw);
			}
			catch
			{
				throw;
			}
			finally
			{
				if(bw!=null)
				{
					bw.Close();
					bw = null;
				}
				if(fs!=null)
				{
					fs.Close();
					fs = null;
				}
			}
		}

		public virtual void DeserializeBinary(byte []lpbyte)
		{
			if( lpbyte==null || lpbyte.Length<=0 ) return;
			MemoryStream stream = null;
			BinaryReader br  = null;
			try
			{
				stream = new MemoryStream(lpbyte);
				br = new BinaryReader(stream);
				this.Deserialize(br);
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
				if(stream!=null)
				{
					stream.Close();
					stream = null;
				}
			}
		}


		public void			DeserializeBinary(string filepath)
		{
			if(!File.Exists(filepath))
				throw new IOException("File do not exist");

			FileStream fs =null;
			BinaryReader br  = null;
			try
			{
				fs = File.Open(filepath,FileMode.Open,FileAccess.Read,FileShare.Read);
				br = new BinaryReader(fs );
				this.Deserialize(br);
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
				if(fs!=null)
				{
					fs.Close();
					fs = null;
				}
			}
		}

		public int			LengthEx
		{
			get
			{
				return this.Length + DeltaLength;
			}
		}

		public static int	DefaultLength
		{
			get
			{
				return 1024*1024;
			}
		}

		public static int	DeltaLength
		{
			get
			{
				return 1024;
			}
		}

		#endregion archive

	}
}
