using System;
using System.Text;
using System.Collections;
using System.Collections.Specialized;


namespace DDARecipe
{
	/// <summary>
	/// Summary description for TextHistory.
	/// </summary>
	public class TextHistory
	{
		private StringCollection	_Content;
		public  int					MaxLine = 100;

		/// <summary>
		/// sender is new line (string)
		/// </summary>
		public event	EventHandler	OnAddNewLine;

		public TextHistory()
		{
			_Content = new StringCollection();
		}

		public TextHistory(int maxline) : this()
		{
			MaxLine = maxline;
		}

		public void Clear()
		{
			lock(_Content)
			{
				_Content.Clear();
			}
		}

		public int NumberLine
		{
			get
			{
				return _Content.Count;
			}
		}

		public void AddNewLine(string text)
		{
			string newtext = string.Concat(Environment.NewLine,text);
			this.AddText(newtext);
			if(OnAddNewLine!=null)
				OnAddNewLine(newtext,EventArgs.Empty);
		}
		public void AddText(string text)
		{
			lock(_Content)
			{
				if(_Content.Count >= MaxLine)
					_Content.RemoveAt(0);
				_Content.Add(text);
			}
		}

		public string this[int line]
		{
			get
			{
				return _Content[line];
			}
			set
			{
				lock(_Content)
				{
					_Content[line] = value;
				}
			}
		}

		public string			Content
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				lock(_Content)
				{
					foreach(string s in this._Content)
						sb.Append(s);
				}

				return sb.ToString();
			}
		}

	}
}
