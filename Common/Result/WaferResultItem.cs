using System;
using System.Data;
using System.Drawing;

namespace SiGlaz.Common.DDA.Result
{
	/// <summary>
	/// Summary description for WaferResult.
	/// </summary>
	/// 
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class WaferResultItem : ResultItemBase
	{
		public Bitmap	thumbnail;

		public WaferResultItem():base()
		{
		}
		public WaferResultItem(DataRow row):base(row)
		{
		}

	}


}
