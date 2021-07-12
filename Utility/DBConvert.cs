using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;

namespace SiGlaz.Utility
{
	/// <summary>
	/// Summary description for DBConvert.
	/// </summary>
	public class DBConvert
	{
		public DBConvert()
		{
		}
		public static string DbObject2String(object dbobject)
		{
			if( dbobject is DBNull)
				return "";
			else
				return dbobject.ToString();
		}
		public static int DbObject2in32(object dbobject,int defaultvalue)
		{
			if(dbobject is DBNull)
				return defaultvalue;
			else
				return Convert.ToInt32(dbobject);
		}
		public static float DbObject2Single(object dbobject,float defaultvalue)
		{
			if(dbobject is DBNull)
				return defaultvalue;
			else
				return Convert.ToSingle(dbobject);
		}
		public static DateTime DbObject2DateTime(object dbobject)
		{
			if(dbobject is DBNull)
				return DateTime.Now;
			else
				return Convert.ToDateTime(dbobject);
		}
		
		public static byte[] Bitmap2Byte(Bitmap bmp)
		{
			if(bmp==null) return null;
			MemoryStream sm=new MemoryStream();
			bmp.Save(sm,ImageFormat.Png);
			byte[] lpbyte=sm.ToArray();
			sm.Close();
			return lpbyte;
		}

		public static Bitmap Byte2Bitmap(byte []lpbyte)
		{
			if( lpbyte==null) return null;
			MemoryStream ms=new MemoryStream(lpbyte);				
			Bitmap bmp=new Bitmap(ms);
			ms.Close();
			return bmp;
		}

	}
}
