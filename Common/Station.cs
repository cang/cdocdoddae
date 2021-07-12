using System;

namespace SiGlaz.Common.DDA
{
	/// <summary>
	/// Summary description for Fab.
	/// </summary>
	/// 
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class Station
	{
		//private		int			_StationKey;
		private		string		_Station;

//		public int		StationKey
//		{
//			get
//			{
//				return _StationKey;
//			}
//			set
//			{
//				_StationKey = value;
//			}
//		}

		public string		StationName
		{
			get
			{
				return _Station;
			}
			set
			{
				_Station = value;
			}
		}

		public Station()
		{
		}

		public Station(string station):this()
		{
			this.StationName  = station;
		}

//		public Station(int stationkey,string station):this()
//		{
//			this.StationKey = stationkey;
//			this.StationName  = station;
//		}

	}
}
