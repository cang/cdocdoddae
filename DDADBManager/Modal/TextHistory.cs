using System;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

namespace DDADBManager.Modal
{
	public delegate void MessageLine(int id,string message);
	/// <summary>
	/// Summary description for TextHistory.
	/// </summary>
	public class TextHistory
	{
		public StringCollection		_ContentLine;
		public  static int			MaxLine = 100;

		/// <summary>
		/// sender is new line (string)
		/// </summary>
		public event	MessageLine	OnAddNewLine;

		public TextHistory()
		{
			_ContentLine = new StringCollection();
		}

		public int NumberLine
		{
			get
			{
				return _ContentLine.Count;
			}
		}

		public void Clear()
		{
			lock(_ContentLine)
			{
				_ContentLine.Clear();
			}
		}

		public void AddNewLine(int id,string text)
		{
			string newtext = string.Concat(Environment.NewLine,text);
			this.AddText(newtext);
			if(OnAddNewLine!=null)
				OnAddNewLine(id,newtext);
		}

		public void AddNewText(int id,string text)
		{
			string newtext = text;
			this.AddText(newtext);
			if(OnAddNewLine!=null)
				OnAddNewLine(id,newtext);
		}

		public void AddText(string text)
		{
			lock(_ContentLine)
			{
				if(_ContentLine.Count >= MaxLine)
					_ContentLine.RemoveAt(0);
				_ContentLine.Add(text);
			}
		}

		public string this[int line]
		{
			get
			{
				return _ContentLine[line];
			}
			set
			{
				_ContentLine[line] = value;
			}
		}

		public string			Content
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				lock(_ContentLine)
				{
					foreach(string s in this._ContentLine)
						sb.Append(s);
				}
				return sb.ToString();
			}
		}

	}
}
