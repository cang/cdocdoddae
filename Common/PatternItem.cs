using System;
using System.Collections;

namespace SiGlaz.Common.DDA
{
	/// <summary>
	/// Summary description for PatternItem.
	/// </summary>
	/// 
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class PatternItem
	{
		public			int				PatternKey = 0;
		public			int				PatternID = 0;
		public			string			PatternName = string.Empty;
		public			string			PatternPath = string.Empty;
		public			ePatternType	PatternType = 0;
		public			int				Parent = 0;
		public			byte[]			RawData = null;
		public			byte[]			Thumbnail = null;
		public			bool			Temp = false;
		public			short			Version = 1;

		public PatternItem()
		{
		}
	}

	public enum ePatternType : short
	{
		Pattern =0,
		Signature,
		Class,
		Library
	}

	public enum eLibraryType : byte
	{
		All,
		Static,
		Dynamic
	}

	/// <summary>
	/// Summary description for WaferCollection.
	/// </summary>
	/// 
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class PatternItemCollection : CollectionBase
	{
		public PatternItemCollection()
		{
		}

		public int Add(PatternItem obj)
		{
			return this.List.Add(obj);
		}

		public PatternItem this[int index]
		{
			get
			{
				return this.List[index] as PatternItem;
			}
			set
			{
				this.List[index] = value;
			}
		}

		public void AddRange(ICollection c)
		{
			this.InnerList.AddRange(c);
		}

	}

}
