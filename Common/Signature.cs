using System;
using System.IO;

namespace SiGlaz.Common.DDA
{
	/// <summary>
	/// Summary description for Signature.
	/// </summary>
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class Signature
	{
		protected		int		_SCKey;		
		protected		string	_SignatureName=string.Empty;
		public			int		SignatureID;

		public int		SCKey
		{
			get
			{
				return _SCKey;
			}
			set
			{
				_SCKey = value;
			}
		}

		public string		SignatureName
		{
			get
			{
				return _SignatureName;
			}
			set
			{
				_SignatureName = value;
			}
		}

		public Signature Copy()
		{
			return MemberwiseClone() as Signature;
		}

		public Signature()
		{			
		}

		public Signature(int sckey,int signatureid,string signaturename):this()
		{
			this.SCKey = sckey;
			this.SignatureName=signaturename;
			this.SignatureID = signatureid;
		}


		public virtual void Serialize(BinaryWriter stream)
		{
			//Write header
			stream.Write(_SCKey);
			stream.Write(_SignatureName);
			stream.Write(SignatureID);
		}

		public virtual void SerializeBinary(string filepath)
		{
			SiGlaz.Utility.FileUtils.DeleteFile(filepath);
			FileStream stream = null;
			BinaryWriter bw  = null;
			try
			{
				stream = File.Create(filepath);
				bw = new BinaryWriter(stream);
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
				if(stream!=null)
				{
					stream.Close();
					stream = null;
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


		public virtual void Deserialize(BinaryReader stream)
		{
			try
			{
				this._SCKey= stream.ReadInt32();
				this._SignatureName = stream.ReadString();
				this.SignatureID = stream.ReadInt32();
			}
			catch
			{
				throw;
			}
		}
	
		public virtual void DeserializeBinary(string filepath)
		{
			if( !SiGlaz.Utility.FileUtils.ExistsFile(filepath) ) return;
			FileStream stream = null;
			BinaryReader br  = null;
			try
			{
				stream = File.Open(filepath,FileMode.Open);
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


	}
}
