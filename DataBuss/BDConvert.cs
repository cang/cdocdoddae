using System;
using System.Data;
using System.Collections;


namespace SiGlaz.DDA.Business
{
	/// <summary>
	/// Summary description for BDConvert.
	/// </summary>
	public class BDConvert
	{
		public BDConvert()
		{
		}

		public static byte[]	ConvertTOSURFRaw(DataSet ds)
		{
			if(ds==null || ds.Tables.Count<=0 || ds.Tables[0].Rows.Count <=0)
				return null;

			SiGlaz.DAL.SURFFormat.SUDRFParser surf = ConvertToSURF(ds);
			byte[] lpbyte = surf.Write();
			return SiGlaz.Utility.Compression.Compressor.Compress(lpbyte);
		}

		public static SiGlaz.DAL.SURFFormat.SUDRFParser ConvertToSURF(DataSet ds)
		{
			if(ds==null || ds.Tables.Count<=0 || ds.Tables[0].Rows.Count <=0)
				return null;

			DataRow dr =ds.Tables[0].Rows[0];

			bool IsDefectList = (bool)dr["IsDefectList"];
			bool NoCompress = (bool)dr["NoCompress"];
			byte[] lpbyte = (byte[])dr["RawData"];
			if(!NoCompress)
				lpbyte = SiGlaz.Utility.Compression.Compressor.DeCompress(lpbyte);

			if(IsDefectList)
			{
				SiGlaz.DAL.SURFFormat.SUDRFParser  result = new SiGlaz.DAL.SURFFormat.SUDRFParser();

				if(!dr.IsNull("TesterType"))
					result.TesterType  = dr["TesterType"].ToString();

				if(!dr.IsNull("ProductCode"))
					result.DiskType = dr["ProductCode"].ToString();

				result.ClassLookup = new SiGlaz.DAL.SURFFormat.ClassLookup();//no 

				//1 disk 
				SiGlaz.DAL.SURFFormat.Disk disk = new SiGlaz.DAL.SURFFormat.Disk();

				if(!dr.IsNull("DiskID"))
					disk.ID = dr["DiskID"].ToString();
				if(!dr.IsNull("TestGrade"))
					disk.TestGrade = dr["TestGrade"].ToString();

				if(!dr.IsNull("BinNo"))
					disk.BinNo = dr["BinNo"].ToString();

				if(!dr.IsNull("CassetteID"))
					disk.CassetteID = dr["CassetteID"].ToString();
				if(!dr.IsNull("ProductCode"))
					disk.ProductCode = dr["ProductCode"].ToString();

				disk.DiskSize = new SiGlaz.DAL.SURFFormat.DiskSize(true);

				if(!dr.IsNull("InnerDiameter"))
					disk.DiskSize.InnerDiameter = (float)( (double)dr["InnerDiameter"]*1000f );

				if(!dr.IsNull("OuterDiameter"))
					disk.DiskSize.OuterDiameter = (float)( (double)dr["OuterDiameter"]*1000f );

				if(!dr.IsNull("LotNo"))
					disk.LotID = dr["LotNo"].ToString();

				if(!dr.IsNull("LotIDCode"))
					disk.LotIDCode = dr["LotIDCode"].ToString();

				if(!dr.IsNull("SlotNum"))
					disk.SlotNumber = (short)dr["SlotNum"];

				if(!dr.IsNull("Tester"))
					disk.Station = dr["Tester"].ToString();
				disk.TotalSlot = 1;

				if(!dr.IsNull("TestCell"))
					disk.WordCell = dr["TestCell"].ToString();

				if(!dr.IsNull("L2_Bot_Corr_cts"))
					disk.L2_Bot_Corr_cts = (int)dr["L2_Bot_Corr_cts"];

				if(!dr.IsNull("L2_Bot_NCorr_cts"))
					disk.L2_Bot_NCorr_cts = (int)dr["L2_Bot_NCorr_cts"];

				if(!dr.IsNull("L2_Top_Corr_cts"))
					disk.L2_Top_Corr_cts = (int)dr["L2_Top_Corr_cts"];

				if(!dr.IsNull("L2_Top_NCorr_cts"))
					disk.L2_Top_NCorr_cts = (int)dr["L2_Top_NCorr_cts"];

				//one 1
				SiGlaz.DAL.SURFFormat.Surface obj = new SiGlaz.DAL.SURFFormat.Surface();
				obj.Site = (SiGlaz.DAL.SURFFormat.SurfaceSite)dr["Surface"];
				obj.ID = (int)obj.Site;
				obj.RingList =null;
				obj.TestDate = new SiGlaz.DAL.SURFFormat.TestDate();
				obj.TestDate.Value = (DateTime)dr["TestDate"];
				obj.DefectList = new SiGlaz.DAL.SURFFormat.DefectList(true);
				obj.DefectList.DefectRecordSpec = SiGlaz.DAL.SURFFormat.DefectList.DEFECT_RECORD_SPEC;//can coi lai o day

				obj.DefectList.DeserializeBinary(lpbyte);

				disk.Surfaces.Add(obj);

				result.Disks.Add(disk);

				return result;
			}
			else
			{
				return SiGlaz.DAL.SURFFormat.SUDRFParser.Open(lpbyte);
			}
		}

		public static SSA.SystemFrameworks.KlarfParserFile ConvertToKlarf(DataSet ds)
		{
			SiGlaz.DAL.SURFFormat.SUDRFParser surf = ConvertToSURF(ds);
			if(surf==null)
				return null;
			ArrayList alKlarf = SSA.SystemFrameworks.KlarfParserFile.OpenSURF(surf,string.Empty);
			if( alKlarf.Count>0)
				return alKlarf[0] as SSA.SystemFrameworks.KlarfParserFile;
			return null;
		}

		public static void ConvertSURFToCommonStruct(SiGlaz.DAL.SURFFormat.SUDRFParser surf,SiGlaz.Common.DDA.Disk outdisk,SiGlaz.Common.DDA.Surface outsurface)
		{
			SiGlaz.DAL.SURFFormat.Disk disk = surf.Disks[0] as SiGlaz.DAL.SURFFormat.Disk;
			SiGlaz.DAL.SURFFormat.Surface surface = disk.Surfaces[0] as SiGlaz.DAL.SURFFormat.Surface;


			outdisk.DiskID = disk.ID;
			outdisk.TestGrade = disk.TestGrade;
			outdisk.BinNum = disk.BinNo;
			outdisk.CassetteID = disk.CassetteID;

			outdisk.ProductCode = disk.ProductCode;

			outdisk.LotID = disk.LotID;
			outdisk.LotIDCode = disk.LotIDCode;
			outdisk.SlotNum = (short)disk.SlotNumber;
			outdisk.Station = disk.Station;
			outdisk.WordCell = disk.WordCell;
			outdisk.InnerDiameter = disk.DiskSize.InnerDiameter/1000f;
			outdisk.OuterDiameter = disk.DiskSize.OuterDiameter/1000f;

			outdisk.L2_Bot_Corr_cts= disk.L2_Bot_Corr_cts;
			outdisk.L2_Bot_NCorr_cts= disk.L2_Bot_NCorr_cts;
			outdisk.L2_Top_Corr_cts= disk.L2_Top_Corr_cts;
			outdisk.L2_Top_NCorr_cts= disk.L2_Top_NCorr_cts;
			outdisk.TestDiskDate = surface.TestDate.Value;

			outdisk.TesterType = surf.TesterType;//new
			
			outsurface.Loaded = true;
			outsurface.NumberOfDefect = surface.DefectList.Defects!=null?surface.DefectList.Defects.Count:0;
			outsurface.TestDate = surface.TestDate.Value;
			outsurface.TopBottom = (SiGlaz.Common.DDA.eSurface)surface.Site;

			outsurface.IsDefectList = true;
			outsurface.NoCompress = false;//compress

			byte[] lpbyte = surface.DefectList.SerializeBinary();

			outsurface.RawData = SiGlaz.Utility.Compression.Compressor.Compress(lpbyte);
		}

        public static SSA.SystemFrameworks.KlarfParserFile ConvertFromBinaryToKlarfParserFile(byte[] _DataSourceRaw)
        {
            SSA.SystemFrameworks.KlarfParserFile rv = null;
            try
            {
                //Update Klarf
                if (_DataSourceRaw != null)
                {
                    byte[] buffer = SiGlaz.Utility.Compression.Compressor.DeCompress(_DataSourceRaw);
                    rv = SSA.SystemFrameworks.KlarfParserFile.OpenSURF(buffer)[0] as SSA.SystemFrameworks.KlarfParserFile;
                }
                return rv;
            }
            catch
            {
                throw;
            }
        }

        public static SSA.SystemFrameworks.KlarfParserFile ConvertFromBinaryToGetResult(SSA.SystemFrameworks.KlarfParserFile klarf, byte[] _DefectListRaw)
        {
            try
            {
                SSA.SystemFrameworks.KlarfParserFile rv = klarf.CopyHeader();


                //Update DefectList
                if (_DefectListRaw != null && klarf != null)
                {
                    byte[] buffer = SiGlaz.Utility.Compression.Compressor.DeCompress(_DefectListRaw);
                    SiGlaz.Common.DDA.ResultDefectList resultDefectList = SiGlaz.Common.DDA.ResultDefectList.Deserialize(buffer) as SiGlaz.Common.DDA.ResultDefectList;

                    if (resultDefectList != null && resultDefectList.alDefectListID != null)
                    {
                        ArrayList alDefect = klarf.GetDefectList(resultDefectList.alDefectListID);
                        rv.AddDefectsList(alDefect);
                    }
                }

                return rv;
            }
            catch
            {
                throw;
            }
        }
	}
}
