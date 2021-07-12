using System;
using System.IO;
using SiGlaz.IO.FileMap;

namespace SiGlaz.SharedMemory
{
	public class SharedMessage 
	{
		public int	Message;

		public SharedMessage()
		{
		}

		public SharedMessage Copy()
		{
			return MemberwiseClone() as SharedMessage;
		}

		public void Serialize(BinaryWriter stream)
		{
			stream.Write((int)this.Message);
		}
		public byte[] SerializeBinary()
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

		public void Deserialize(BinaryReader stream)
		{
			try
			{
				this.Message = stream.ReadInt32();
			}
			catch
			{
				throw;
			}
		}
	
		public void DeserializeBinary(byte []lpbyte)
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

		public static	int		Lenght
		{
			get
			{
				return 8+4;
			}
		}

	}

}
