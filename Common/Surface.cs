using System;
using System.IO;

namespace SiGlaz.Common.DDA
{
	/// <summary>
	/// Summary description for Surface.
	/// </summary>
	/// 
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class Surface
	{
		//DDA_Surfaces Table
		public long			SurfaceKey;
		//public long			DiskKey;//From Disk
		public DateTime		TestDate = DateTime.Now;
		public eSurface		TopBottom;//	Default = top
		public int			NumberOfDefect;
		public bool			Loaded;

		public bool			IsDefectList = false;
		public bool			NoCompress = false;

		//DDA_SurfaceData Table
		public byte[]		RawData;
		/*
		 * temporary, contain SURF format data for quick loading, 
		 in the future this field only contain defectslist information for compact database
		 */
		public byte[]		SourceThumbnail;
		public byte[]		SourceThumbnailFlat;

		public Surface()
		{
		}

	}
}
