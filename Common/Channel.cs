using System;

namespace SiGlaz.Common.DDA
{
	/// <summary>
	/// Summary description for Fab.
	/// </summary>
	/// 
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class Channel
	{
		public		int			ChannelID;
		public		string		ChannelName;

		public Channel()
		{
		}

		public Channel(int key,string name):this()
		{
			this.ChannelID = key;
			this.ChannelName  = name;
		}

	}
}
