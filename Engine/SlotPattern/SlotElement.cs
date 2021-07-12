using System;

namespace SiGlaz.DDA.Engine.SlotPattern
{
	/// <summary>
	/// Summary description for SlotElement.
	/// </summary>
	public class SlotElement:IComparable
	{
		public int m_value;

		public string stringToSort;
		public int intToSort;

		public bool isPredictedSlot = false;

		public SlotElement()
		{
			m_value = 0;
			stringToSort = "";
			intToSort = 0;
		}

		public SlotElement(int val)
		{
			m_value = val;
			stringToSort = "";
			intToSort = 0;
		}

		public SlotElement(int val, string s, int i)
		{
			m_value = val;
			stringToSort = s;
			intToSort = i;
		}

		public SlotElement(int val, string s, int i, bool predicted)
		{
			m_value = val;
			stringToSort = s;
			intToSort = i;
			isPredictedSlot = predicted;
		}

		public int LParse(string s)
		{
			string stmp = "";
			for (int i = 0; i < s.Length; i++)
			{
				if (char.IsNumber(s,i))
					stmp += s[i];
			}
			int ret = 0;
			try
			{
				ret = int.Parse(stmp);
			}
			catch
			{
			}
			return ret;
		}

		public int CompareTo(object obj)
		{
			SlotElement element = (SlotElement)obj;

			int i1waferid = LParse(this.stringToSort);
			int i2waferid = LParse(element.stringToSort);
			int ret = i1waferid.CompareTo(i2waferid);
			if (ret != 0)
				return ret;

			return this.stringToSort.CompareTo(element.stringToSort);
		}
	}

}
