using System;
using System.Collections;

namespace SiGlaz.Common.DDA.Const
{
	/// <summary>
	/// Summary description for CategoryConst.
	/// </summary>
	public class CategoryConst
	{
		public	const string CatOrder = "CatOrder";
		public	const string CatName = "CatName";
		public	const string CatID = "CatID";
		public	const string CCType = "CCType";
		public	const string ChipCountFail = "ChipCountFail";
		public	const string Description = "Description";

		public static string Caption(string fieldname)
		{
			switch(fieldname)
			{
				case CatOrder:
					return "ID";
				case CatID:
					return "Code";
				case CatName:
					return "Category Name";
				case CCType:
					return "Type";
				default:
					return fieldname;
			}
		}

		public static int ColumnSize(string fieldname)
		{
			switch(fieldname)
			{
				case CatOrder:
					return 40;
				case CatName:
					return 100;
				case CatID:
					return 50;
				case CCType:
					return 75;
				case ChipCountFail:
					return 100;
				default:
					return 200;
			}
		}
		public static string[] FieldList
		{
			get
			{
				ArrayList alResult = new ArrayList();
				alResult.Add(CatOrder);
				alResult.Add(CatID);
				alResult.Add(CatName);
				alResult.Add(CCType);
				//alResult.Add(Description);
				return alResult.ToArray(typeof(string)) as string[];
			}
		}

		public static string[] FieldListChipCount
		{
			get
			{
				ArrayList alResult = new ArrayList();
				alResult.Add(CatOrder);
				alResult.Add(CatID);
				alResult.Add(CatName);
				alResult.Add(CCType);
				alResult.Add(ChipCountFail);
				return alResult.ToArray(typeof(string)) as string[];
			}
		}


	}
}
