using System;
using System.Collections;
using System.Drawing;

namespace SiGlaz.Utility
{
	/// <summary>
	/// Summary description for ColorUtils.
	/// </summary>
	public class ColorUtils
	{
		public ColorUtils()
		{
		}

		public static Color	String2Color(string ssColor)
		{
			string []sss=ssColor.Split(",".ToCharArray());
			if(sss.Length<3)
				return Color.FromName(ssColor);
			else
				return Color.FromArgb( Convert.ToInt32(sss[0]),Convert.ToInt32(sss[1]),Convert.ToInt32(sss[2]) );
		}

		public static string Color2String(Color color)
		{
			if(color.IsNamedColor)
				return color.Name;
			else
				return string.Format("{0},{1},{2}",color.R,color.G,color.B);
		}

		public static Color[] InitArrKnownColor()
		{
			System.Array colorsArray = Enum.GetValues(typeof(KnownColor));
			ArrayList alResult = new ArrayList();
			
			for(int i=0;i<colorsArray.Length;i++)
			{
				Color clr = Color.FromKnownColor( (KnownColor)colorsArray.GetValue(i) );
				if( clr ==Color.Transparent)
					continue;
				if( clr.R >= 200 &&  clr.G >= 200 && clr.B >= 200)
					continue;
				alResult.Add(clr);
			}

			return alResult.ToArray(typeof(Color)) as Color[];
		}

		public static Color[] InitArrColor(ColorType type,int lenght,int alpha)
		{
			int [,] arraytable = null;
			ColorMap map = new ColorMap(lenght,alpha);
			switch (type)
			{
				case ColorType.Autumn:
					arraytable = map.Autumn();
					break;
				case ColorType.Cool:
					arraytable = map.Cool();
					break;
				case ColorType.Gray:
					arraytable = map.Gray();
					break;
				case ColorType.Hot:
					arraytable = map.Hot();
					break;
				case ColorType.Jet:
					arraytable = map.Jet();
					break;
				case ColorType.Spring:
					arraytable = map.Spring();
					break;
				case ColorType.Summer:
					arraytable = map.Summer();
					break;
				case ColorType.Winter:
					arraytable = map.Winter();
					break;
				default:
					arraytable = map.Spring();
					break;
			}
			ArrayList arrColor=new ArrayList();
			for(int i=0;i< lenght;i++)
			{
				arrColor.Add(Color.FromArgb(arraytable[i,0],arraytable[i,1],arraytable[i,2],arraytable[i,3]));
			}
			return arrColor.ToArray(typeof(Color)) as Color[];
		}

		public static Color[] InitArrColor()
		{
			return InitArrColor(ColorType.Spring,64,255);
		}

		public enum ColorType
		{
			Spring,
			Summer,
			Autumn,
			Winter,
			Gray,
			Jet,
			Hot,
			Cool
		}
	}

	
}
