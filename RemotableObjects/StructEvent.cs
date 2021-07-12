using System;

namespace DDADBRObjects
{
	/// <summary>
	/// Summary description for StructEvent.
	/// </summary>
	/// 
	[Serializable]
	public class SchemaEvent : EventArgs
	{
		public byte[] RawData = null;
		public SchemaEvent()
		{
		}

		public SchemaEvent(byte[] lpbyte):base()
		{
			this.RawData = lpbyte;
		}

		public DDADBManager.Process.Schema Schema
		{
			get
			{
				if(RawData==null)
					return null;

				DDADBManager.Process.Schema schema = new DDADBManager.Process.Schema();
				schema.DeserializeBinary(RawData);
				return schema;
			}
			set
			{
				if(value==null)
					return;

				RawData = value.SerializeBinary();
			}
		}
	}

	[Serializable]
	public class ProcessBaseEventArgs : EventArgs
	{
		public  int		ProcessID = -1;

		public ProcessBaseEventArgs()
		{
		}

		public ProcessBaseEventArgs(int processid)
		{
			this.ProcessID = processid;
		}
	}

	[Serializable]
	public class ProcessEventArgs : ProcessBaseEventArgs
	{
		public	bool	Abort;
		public	string	Filepath;

		public ProcessEventArgs(string filepath)
		{
			this.Filepath = filepath;
		}

		public ProcessEventArgs(int processid,string filepath) : base(processid)
		{
			this.Filepath = filepath;
		}
	}

	[Serializable]
	public class CheckFormatEventArgs : ProcessBaseEventArgs
	{
		public	bool IsValid;
		public	string Filepath;

		public CheckFormatEventArgs(string filepath)
		{
			this.Filepath = filepath;
		}

		public CheckFormatEventArgs(int processid,string filepath) : base(processid)
		{
			this.Filepath = filepath;
		}
	}

	[Serializable]
	public class FileControllerErrorEventArgs : ProcessBaseEventArgs
	{
		public	object obj;
		public	string msg;

		public  FileControllerErrorEventArgs(object obj,string msg)
		{
			this.obj = obj;
			this.msg = msg;
		}

		public  FileControllerErrorEventArgs(int processid,object obj,string msg): base(processid)
		{
			this.obj = obj;
			this.msg = msg;
		}
	}

}
