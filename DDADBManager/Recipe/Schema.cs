using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using DDADBManager.Process;

namespace DDADBManager.Process
{
	/// <summary>
	/// Summary description for Schema.
	/// </summary>
	public class Schema
	{
		private ArrayList	_Process = new ArrayList();

		public Schema()
		{
		}

		public ProcessBase this[int index]
		{
			get
			{
				if(this.Process.Count>index)
					return this.Process[index] as ProcessBase;
				else
					return null;
			}
			set
			{
				if(this.Process.Count>index)
					this.Process[index]  = value;
			}
		}

		public int			ProcessCount
		{
			get
			{
				return _Process.Count;
			}
		}

        [XmlElement(typeof(ProcessBase))]
		[XmlElement(typeof(LoadETestProcess))]
		public ArrayList	Process
		{
			get
			{
				return _Process;
			}
			set
			{
				_Process = value;
			}
		}

		public int  MaxTaskID
		{
			get
			{
				int maxid = 0;
				if(_Process!=null)
				{
					foreach(ProcessBase obj in _Process)
					{
						if(obj.ID > maxid )
							maxid = obj.ID;
					}
				}
				return maxid;
			}
		}

		public void ResetStatus()
		{
			if(_Process!=null)
			{
				foreach(ProcessBase obj in _Process)
				{
					obj.IsRunning = obj.IsWaiting = false;
				}
			}
		}

		public void Serialize(Stream stream)
		{
			XmlSerializer xml = null;
			try
			{
				xml = new XmlSerializer(this.GetType());
				xml.Serialize(stream,this);
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

		public byte[] SerializeBinary()
		{
			MemoryStream stream = null;
			try
			{
				stream = new MemoryStream();
				this.Serialize(stream);
				return stream.ToArray();
			}
			catch
			{
				throw;
			}
			finally
			{
				if(stream!=null)
				{
					stream.Close();
					stream = null;
				}
			}
		}

		public void Serialize(string filepath)
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
				Serialize(fs);
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

		public void Deserialize(Stream stream)
		{
			XmlSerializer xml = null;
			try
			{
				xml = new XmlSerializer(this.GetType());
				Schema obj = xml.Deserialize(stream) as Schema;
				this.Process = obj.Process;
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

		public void DeserializeBinary(byte []lpbyte)
		{
			if( lpbyte==null || lpbyte.Length<=0 ) return;

			MemoryStream stream = null;
			try
			{
				stream = new MemoryStream(lpbyte);
				this.Deserialize(stream);
			}
			catch
			{
				throw;
			}
			finally
			{
				if(stream!=null)
				{
					stream.Close();
					stream = null;
				}
			}
		}


		public void Deserialize(string filepath)
		{
			if(!File.Exists(filepath))
				throw new IOException("File do not exist");

			FileStream fs =null;
			try
			{
				fs = File.Open(filepath,FileMode.Open,FileAccess.Read,FileShare.ReadWrite);
				Deserialize(fs);
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

		public void Save(string filepath)
		{
			this.Serialize(filepath);
		}

		public void Load(string filepath)
		{
			this.Deserialize(filepath);
		}

	}
}
