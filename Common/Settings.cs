using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace SiGlaz.Common.DDA
{
	public class Settings
	{
		public Settings()
		{
		}

		public string Database = "DDADB";
		public string Server = "(local)";
		public string UserName = "sa";
		public string Password = "";
		public eSchedule Schedule =  eSchedule.Hourly;
		public int ScheduleNum = 2;
		public bool ResetValue = false;
		//public int NumOfDays = 3;
		public int NumOfHours = 72; //= 3 days

		public void Serialize(Stream stream)
		{
			XmlSerializer s = new XmlSerializer(typeof(Settings));
			s.Serialize(stream,this);
		}

		public void Serialize(string filename)
		{
			using (FileStream fs = new FileStream(filename,FileMode.Create))
			{
				Serialize(fs);
			}
		}

		public static Settings Deserialize(string filename)
		{
			try
			{
				using (FileStream fs = new FileStream(filename,FileMode.Open))
				{
					XmlSerializer s = new XmlSerializer(typeof(Settings));
					return s.Deserialize(fs) as Settings;
				}
			}
			catch
			{
				return null;
			}
		}
	}

	public	enum	eSchedule
	{
		Hourly,
		byMinute		
	}
}
