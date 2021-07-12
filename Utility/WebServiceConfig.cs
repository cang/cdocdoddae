using System;
using System.IO;
using System.Xml.Serialization;

namespace SiGlaz.Utility
{
	public class WebServiceConfig
	{
		#region Members
		private string _url = string.Empty;
		#endregion

		#region Contructor
		public WebServiceConfig()
		{
		}
		#endregion

		#region Properties
		[XmlElement("Url", typeof(string))]
		public string Url
		{
			get { return _url; }
			set { _url = value; }
		}
		#endregion

		#region Serialize & Deserialize
		public bool Serialize(string fileName, ref string error)
		{
			bool result = false;
			XmlSerializer xmlSerialize = null;
			StreamWriter sw = null;

			try
			{
				sw = new StreamWriter(fileName);
				xmlSerialize = new XmlSerializer(typeof(WebServiceConfig));
				xmlSerialize.Serialize(sw, this);

				result = true;
			}
			catch (System.Exception e)
			{
				error = e.Message;
			}
			finally
			{
				if (sw != null)
				{
					sw.Close();
					sw = null;
				}

				if (xmlSerialize != null)
					xmlSerialize = null;
			}

			return result;
		}

		public bool Deserialize(string fileName, ref string error)
		{
			bool result = false;
			XmlSerializer xmlSerialize = null;
			StreamReader sr = null;

			try
			{
				sr = new StreamReader(fileName);
				xmlSerialize = new XmlSerializer(typeof(WebServiceConfig));
				WebServiceConfig webService =  (WebServiceConfig)xmlSerialize.Deserialize(sr);

				_url = webService._url;

				result = true;
			}
			catch (System.Exception e)
			{
				error = e.Message;
			}
			finally
			{
				if (sr != null)
				{
					sr.Close();
					sr = null;
				}

				if (xmlSerialize != null)
					xmlSerialize = null;
			}

			return result;
		}
		#endregion
	}
}
