using System;
using System.Collections;

namespace SiGlaz.Common.DDA.Const
{
	/// <summary>
	/// Summary description for WaferConst.
	/// </summary>
	public class WaferConst
	{
		public const string DiskID = "DiskID";
		public const string Product = "Product"; //Old field : DiskTypeID
		public const string TesterGrade = "TesterGrade"; //Old field : Grade
		public const string SlotNoType = "SlotNoType"; //Old field : SlotNum
		public const string LotNo = "LotNo"; //Old field : LotID
		public const string CassetteID = "CassetteID";
		public const string Tester = "Tester"; //Old Field : Station
		public const string TestCell = "TestCell"; //Old field : WordCellID
		public const string Surface = "Surface";
		public const string SignatureName = "SignatureName";
		public const string NumberOfDefect = "NumberOfDefect";
		public const string NumberOfSignatureDefect = "NumberOfSignatureDefect";
		public const string PercentOfSignatureDefect = "PercentOfSignatureDefect";
		public const string TestDate = "TestDate";
		public const string L2_Top_Corr_cts = "L2_Top_Corr_cts"; //Add 2008-08-04
		public const string L2_Bot_Corr_cts = "L2_Bot_Corr_cts"; //Add 2008-08-04
		public const string L2_Top_NCorr_cts = "L2_Top_NCorr_cts"; //Add 2008-08-04
		public const string L2_Bot_NCorr_cts = "L2_Bot_NCorr_cts"; //Add 2008-08-04
		public const string TesterType = "TesterType"; //Add 2008-09-24
		public const string Rsc725 = "Rsc725"; //Add 2008-09-24
		public const string Rsc769 = "Rsc769"; //Add 2008-09-24
		public const string Rsc771 = "Rsc771"; //Add 2008-09-24
		public const string Rsc764 = "Rsc764"; //Add 2008-09-24
		public const string Rsc575 = "Rsc575"; //Add 2008-09-24
		public const string KKLot = "KKLot"; //Add 2008-09-24
		public const string KKSlot = "KKSlot"; //Add 2008-09-24
		public const string IRISBinNo = "IRISBinNo"; //Add 2008-11-13
		public const string DDAGrade = "DDAGrade"; //Add 2008-11-13
		public const string LotIDCode = "LotIDCode"; //Add 2008-11-13
		public const string Rsc450 = "Rsc450"; //Add 2009-02-19
		public const string Rsc453 = "Rsc453"; //Add 2009-02-19
		public const string Rsc600 = "Rsc600"; //Add 2009-02-19
		public const string Rsc766 = "Rsc766"; //Add 2009-02-19
		public const string Rsc0806 = "Rsc0806"; //Add 2010-07-09
		public const string Rsc3806 = "Rsc3806"; //Add 2010-07-09

		public WaferConst()
		{
		}

		public static string[] DataSource
		{
			get
			{
				ArrayList alResult = new ArrayList();
				alResult.Add(TesterGrade);
				alResult.Add(IRISBinNo);
				alResult.Add(CassetteID);
				alResult.Add(DiskID);
				alResult.Add(Product);
				alResult.Add(LotNo);
				alResult.Add(LotIDCode);
				alResult.Add(SlotNoType);
				alResult.Add(Tester);
				alResult.Add(Surface);
				alResult.Add(TestDate);
				alResult.Add(TestCell);
				alResult.Add(NumberOfDefect);
				alResult.Add(L2_Top_Corr_cts);
				alResult.Add(L2_Bot_Corr_cts);
				alResult.Add(L2_Top_NCorr_cts);
				alResult.Add(L2_Bot_NCorr_cts);
				alResult.Add(TesterType);
				alResult.Add(Rsc725);
				alResult.Add(Rsc769);
				alResult.Add(Rsc771);
				alResult.Add(Rsc764);
				alResult.Add(Rsc575);
				alResult.Add(Rsc450);
				alResult.Add(Rsc453);
				alResult.Add(Rsc600);
				alResult.Add(Rsc766);
				alResult.Add(Rsc0806);
				alResult.Add(Rsc3806);
				alResult.Add(KKLot);
				alResult.Add(KKSlot);
				return alResult.ToArray(typeof(string)) as string[];
			}
		}

		public static string[] SourceOfDisk
		{
			get
			{
				ArrayList alResult = new ArrayList();
				alResult.Add(TesterGrade);
				alResult.Add(IRISBinNo);
				alResult.Add(CassetteID);
				alResult.Add(DiskID);
				alResult.Add(Product);
				alResult.Add(LotNo);
				alResult.Add(LotIDCode);
				alResult.Add(SlotNoType);
				alResult.Add(Tester);
				alResult.Add(TestCell);
				alResult.Add(L2_Top_Corr_cts);
				alResult.Add(L2_Bot_Corr_cts);
				alResult.Add(L2_Top_NCorr_cts);
				alResult.Add(L2_Bot_NCorr_cts);
				alResult.Add(TesterType);
				alResult.Add(Rsc725);
				alResult.Add(Rsc769);
				alResult.Add(Rsc771);
				alResult.Add(Rsc764);
				alResult.Add(Rsc575);
				alResult.Add(Rsc450);
				alResult.Add(Rsc453);
				alResult.Add(Rsc600);
				alResult.Add(Rsc766);
				alResult.Add(Rsc0806);
				alResult.Add(Rsc3806);
				alResult.Add(KKLot);
				alResult.Add(KKSlot);
				return alResult.ToArray(typeof(string)) as string[];
			}
		}

		public static string[] SingleLayer
		{
			get
			{
				ArrayList alResult = new ArrayList();
				alResult.Add(TesterGrade);
				alResult.Add(DDAGrade);
				alResult.Add(IRISBinNo);
				alResult.Add(CassetteID);
				alResult.Add(DiskID);
				alResult.Add(Product);
				alResult.Add(LotNo);
				alResult.Add(LotIDCode);
				alResult.Add(SignatureName);
				alResult.Add(SlotNoType);
				alResult.Add(Tester);
				alResult.Add(Surface);
				alResult.Add(TestDate);
				alResult.Add(TestCell);
				alResult.Add(NumberOfDefect);
				alResult.Add(NumberOfSignatureDefect);
				alResult.Add(PercentOfSignatureDefect);
				alResult.Add(L2_Top_Corr_cts);
				alResult.Add(L2_Bot_Corr_cts);
				alResult.Add(L2_Top_NCorr_cts);
				alResult.Add(L2_Bot_NCorr_cts);
				alResult.Add(TesterType);
				alResult.Add(Rsc725);
				alResult.Add(Rsc769);
				alResult.Add(Rsc771);
				alResult.Add(Rsc764);
				alResult.Add(Rsc575);
				alResult.Add(Rsc450);
				alResult.Add(Rsc453);
				alResult.Add(Rsc600);
				alResult.Add(Rsc766);
				alResult.Add(Rsc0806);
				alResult.Add(Rsc3806);
				alResult.Add(KKLot);
				alResult.Add(KKSlot);
				return alResult.ToArray(typeof(string)) as string[];
			}
		}

		public static bool IsNumericColumn(string columnName)
		{
			switch (columnName)
			{
				case SlotNoType:
				case NumberOfDefect:
				case NumberOfSignatureDefect:
				case PercentOfSignatureDefect:
				case L2_Top_Corr_cts:
				case L2_Bot_Corr_cts:
				case L2_Top_NCorr_cts:
				case L2_Bot_NCorr_cts:
					return true;

				default:
					return false;
			}
		}
	}
}
