using System;

namespace SiGlaz.Common.DDA
{
	/// <summary>
	/// Summary description for SurfaceResult.
	/// </summary>
	/// 
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class SurfaceResult
	{
		//DDA_Results Table
		public long			ResultKey;
		public int			SignatureKey;
		//public bool			IsMultiLayer;
		public DateTime		AnalyzeTime;
		//public int			NumberOfDefect;
		//public double		PercentOfDefect;
		public int			RecipeKey;

		//DDA_ResultDetail Table
		public long			ResultDetailKey;
		//public long			ResultKey;
		public long			SurfaceKey;
		public int			NumberOfDefect;
		public double		PercentOfDefect;

		//DDA_ResultDetailData Table
		//public long			ResultDetailKey;
		public byte[]		RawData;
		public byte[]		SourceThumbnail;
		public byte[]		SourceThumbnailFlat;

		public int			ProcessingDuration;

		public SurfaceResult()
		{
		}
	}
}
