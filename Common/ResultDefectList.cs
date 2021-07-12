using System;
using System.Collections;
using System.IO;

namespace SiGlaz.Common.DDA
{
	/// <summary>
	/// Summary description for ResultDefectList.
	/// </summary>
	public class ResultDefectList
	{
		public ArrayList	alDefectListID = new ArrayList();

		public ResultDefectList()
		{
		}

		public  void Deserialize(BinaryReader sobj)
		{
			int n = sobj.ReadInt32();
			alDefectListID.Clear();
			for(int i=0;i<n;i++)
			{
				alDefectListID.Add( sobj.ReadInt32() );
			}
		}

		public static ResultDefectList Deserialize(byte[] lpbyte)
		{
			if(lpbyte==null) return null;

			ResultDefectList obj = new ResultDefectList();
			if(obj==null) return obj;

			MemoryStream ms = null;
			BinaryReader sobj = null;
			try
			{
				ms = new MemoryStream(lpbyte);
				sobj = new BinaryReader(ms);
				obj.Deserialize(sobj);
				return obj;
			}
			catch
			{
				throw;
			}
			finally
			{
				if(sobj!=null)
				{
					sobj.Close();
					sobj = null;
				}
				if(ms!=null)
				{
					ms.Close();
					ms = null;
				}
			}
		}

		public byte[] Serialize()
		{
			if(this.alDefectListID.Count<=0) return null;

			MemoryStream ms = null;
			BinaryWriter sobj = null;
			try
			{
				ms = new MemoryStream();
				sobj = new BinaryWriter(ms);

				int n = this.alDefectListID.Count;
				sobj.Write(n);
				for(int i=0;i<n;i++)
				{
					sobj.Write((int)this.alDefectListID[i]);
				}
				ms.Flush();

				return ms.ToArray();
			}
			catch
			{
				throw;
			}
			finally
			{
				if(sobj!=null)
				{
					sobj.Close();
					sobj = null;
				}
				if(ms!=null)
				{
					ms.Close();
					ms = null;
				}
			}
		}
	}
}
