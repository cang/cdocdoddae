using System;
using System.IO;

namespace WebServiceProxy
{
	/// <summary>
	/// Summary description for ConvertProxy.
	/// </summary>
	public class ConvertProxy
	{
		public static object Convert(object obj,Type newtype)
		{
			if(obj ==null) return null;
			if(obj.GetType() == newtype)
				return obj;

			MemoryStream ms = null;
			try
			{
				ms = new MemoryStream();
				SiGlaz.Common.XmlSerializeCommon.Serialize(ms,obj);
				ms.Flush();
				ms.Seek(0,SeekOrigin.Begin);
				return SiGlaz.Common.XmlSerializeCommon.Deserialize(ms,newtype);
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
					ms=null;
				}
			}
		}

		
	}
}
