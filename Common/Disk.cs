using System;
using System.IO;


namespace SiGlaz.Common.DDA
{
	/// <summary>
	/// Summary description for Disk.
	/// </summary>
	/// 
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class Disk
	{
		public		string		FabID = string.Empty;
		public		short		FabKey;

		public		string		TesterType = string.Empty;
		public		short		TesterTypeId;

		public		long		DiskKey;
		public		string		DiskID = string.Empty;
		public		string		BinNum = string.Empty;
		public		string		TestGrade = string.Empty;
		public		short		SlotNum;
		public		string		LotID = string.Empty;
		public		string		LotIDCode = string.Empty;

		public		string		CassetteID = string.Empty;

		public		string		Station = string.Empty;
		public		int			StationKey;

		public		string		WordCell = string.Empty;
		public		int			WordCellKey;

		public		bool		DiskSizeContainDiameter;
		public		double		InnerDiameter;
		public		double		OuterDiameter;

		public		string		ProductCode = string.Empty;
		public		int			ProductKey;


		public		int			L2_Top_Corr_cts;
		public		int			L2_Bot_Corr_cts;
		public		int			L2_Top_NCorr_cts;
		public		int			L2_Bot_NCorr_cts;

		public		DateTime	TestDiskDate = DateTime.Now;

		public		string		FileName = null;

		public Disk()
		{
		}
	}
}
