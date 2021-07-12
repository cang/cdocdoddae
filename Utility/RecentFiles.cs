using System;
using System.Collections;
using Microsoft.Win32;

namespace SiGlaz.Utility
{

	public class RecentFiles
	{
		string		_ManufactureName = "SiGlaz";
		string		_ProductName = string.Empty;
		const  string RECENT = "RECENT";
		int			_RecentLimit = 20;

		public		RecentFiles()
		{
		}
		public		RecentFiles(string productname) : this()
		{
			_ProductName = productname;
		}
		public		RecentFiles(string productname,int size) : this(productname)
		{
			_RecentLimit = size;
		}

		public	ArrayList LoadRecentFiles()
		{
			string regString=string.Format("SOFTWARE\\{0}\\{1}\\{2}",_ManufactureName,_ProductName,RECENT);
			RegistryKey regItem=Registry.CurrentUser.OpenSubKey(regString,true);
			if(regItem==null )
				regItem=Registry.LocalMachine.CreateSubKey(regString);
			string []keys = regItem.GetValueNames();
			ArrayList alSubkey = new ArrayList();
			foreach(string subkey in keys)
			{
				alSubkey.Add( new RecentFileItem(subkey, regItem.GetValue( subkey).ToString()));
			}
			alSubkey.Sort();
			return alSubkey;
		}

		public	void SaveRecentFile(string newfilepath)
		{
			string regString=string.Format("SOFTWARE\\{0}\\{1}\\{2}",_ManufactureName,_ProductName,RECENT);
			RegistryKey regItem=Registry.CurrentUser.OpenSubKey(regString,true);
			if(regItem==null )
				regItem=Registry.LocalMachine.CreateSubKey(regString);
			string []keys = regItem.GetValueNames();

			//Load old data
			Array.Sort(keys);
			ArrayList alFilePath = new ArrayList();
			foreach(string subkey in keys)
			{
				alFilePath.Add(regItem.GetValue(subkey).ToString());
			}
			if(alFilePath.Count>0)
			{
				if(alFilePath[alFilePath.Count-1].ToString() == newfilepath) return;
			}

			//Replace
			if(alFilePath.Count >=_RecentLimit)
			{
				alFilePath.RemoveAt(0);
				for(int i=1;i<=alFilePath.Count;i++)
				{
					string filepath = alFilePath[i-1].ToString();
					regItem.SetValue("File" + i , filepath);
				}
			}

			regItem.SetValue("File" + (alFilePath.Count+1) , newfilepath);
			regItem.Flush();
		}
	}

	public		class		RecentFileItem : IComparable
	{
		public string key;
		public string filepath;
		public RecentFileItem(string key, string filepath)
		{
			this.key = key;
			this.filepath = filepath;
		}
		#region IComparable Members

		public int CompareTo(object obj)
		{
			RecentFileItem x = obj as RecentFileItem;
			int id1 = 0,id2 = 0;
			try
			{
				id1 = Convert.ToInt32(this.key.Substring(4));
				id2 = Convert.ToInt32(x.key.Substring(4));
			}
			catch{}
			return (id2 - id1);
		}

		#endregion
	}

}
