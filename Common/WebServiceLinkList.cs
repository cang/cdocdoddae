using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;

namespace SiGlaz.Common.DDA
{
	/// <summary>
	/// Summary description for WebServiceLinkList.
	/// </summary>
	/// 
	[Serializable]
	public class WebServiceLinkList
	{
		private Hashtable	_list;
		public	WebServiceLinkList()
		{
			_list = new Hashtable();
		}

		public	string this[WebServicetypeType type]
		{
			get
			{
				if(!_list.ContainsKey(type))
					return string.Empty;
				else
					return _list[type] as string;
			}
			set
			{
				if(!_list.ContainsKey(type))
					_list.Add(type,value);
				else
					_list[type]=value;
			}
		}

		ArrayList alWebServiceLink = new ArrayList();//Temp Array
		[XmlElement(typeof(WebServiceLinkItem))]
		public ArrayList Items
		{
			get
			{
				return alWebServiceLink;
			}
			set
			{
				alWebServiceLink = value;
			}
		}

		public void WebServiceLinksArrayToHash()
		{
			_list.Clear();
			foreach(WebServiceLinkItem item in alWebServiceLink)
			{
				_list.Add(Enum.Parse(typeof(WebServicetypeType),item.key),item.link);
			}
			alWebServiceLink.Clear();
		}

		public void WebServiceLinksHashToArray()
		{
			alWebServiceLink.Clear();
			foreach(WebServicetypeType key in _list.Keys)
			{
				WebServiceLinkItem item = new WebServiceLinkItem();
				item.key = Enum.GetName( typeof(WebServicetypeType) ,key);
				item.link = _list[key] as string;
				alWebServiceLink.Add(item);
			}
		}

	}

	[Serializable]
	public class WebServiceLinkItem
	{
		public string key;
		public string link = string.Empty;
	}
}
