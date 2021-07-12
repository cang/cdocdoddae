using System;

namespace SiGlaz.Common.DDA
{
	/// <summary>
	/// Summary description for Fab.
	/// </summary>
	/// 
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class WordCell
	{
		//private		int			_WordCellKey;
		private		string		_WordCellID;

//		public int		WordCellKey
//		{
//			get
//			{
//				return _WordCellKey;
//			}
//			set
//			{
//				_WordCellKey = value;
//			}
//		}

		public string		WordCellID
		{
			get
			{
				return _WordCellID;
			}
			set
			{
				_WordCellID = value;
			}
		}

		public WordCell()
		{
		}

		public WordCell(string name):this()
		{
			this.WordCellID  = name;
		}

//		public WordCell(int key,string name):this()
//		{
//			this.WordCellKey = key;
//			this.WordCellID  = name;
//		}

	}
}
