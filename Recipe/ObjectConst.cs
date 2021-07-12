using System;
using System.Collections;
using System.Drawing;



namespace SiGlaz.Recipes
{
	/// <summary>
	/// Summary description for ObjectConst.
	/// </summary>
	public class ObjectConst
	{
		public const	int			RPOINT = 3;
		public const	int			OBJ_LIMITSIZE = 20;
		public static	Color		OBJ_BACKCOLOR = Color.FromArgb(123,207,247);
		public static	Color		OBJ_LINKCOLOR = Color.FromArgb(0,93,239);
		public static	Color		OBJ_HOVERCOLOR = Color.FromArgb(132,130,255);
		public static	Color		OBJ_POINTCOLOR = Color.FromArgb(255,203,0);
		/// <summary>
		/// key = Type Name, Value = Bitmap
		/// </summary>
		public static	Hashtable	htBitmap = new Hashtable();

		/// <summary>
		/// Key = Type Name, Value = Rule Collection
		/// </summary>
		public static	Hashtable	htSyntaxRule = new Hashtable();
	}
}
