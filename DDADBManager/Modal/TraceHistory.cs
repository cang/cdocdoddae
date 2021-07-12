using System;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

namespace DDADBManager.Modal
{
	/// <summary>
	/// Summary description for TextHistory.
	/// </summary>
	public class TraceHistory
	{
		public delegate void TraceNewLinEventHandler(LineItem lineitem);

		public class ControlItem
		{
			public string text;
		}

		public class HyperLinkItem : ControlItem
		{
			public string hyperlink;
		}

		public class LineItem
		{
			public ArrayList LineItems = new ArrayList();
			public void AddItem(ControlItem item)
			{
				LineItems.Add(item);
			}

			public void AddText(string text)
			{
				ControlItem ctrl = new ControlItem();
				ctrl.text = text;
				this.AddItem(ctrl);
			}

			public void AddHyperlink(string text,string hyperlink)
			{
				HyperLinkItem ctrl = new HyperLinkItem();
				ctrl.text = text;
				ctrl.hyperlink = hyperlink;
				this.AddItem(ctrl);
			}

			public void AddHyperlink(string text)
			{
				HyperLinkItem ctrl = new HyperLinkItem();
				ctrl.text = text;
				ctrl.hyperlink = text;
				this.AddItem(ctrl);
			}
		}

		public ArrayList Contents = new ArrayList();

		public event TraceNewLinEventHandler OnNewLine;
		
		public TraceHistory()
		{
			
		}

		public void AddNewLine(LineItem lineitem)
		{
			if(Contents.Count >= Modal.TextHistory.MaxLine )
			{
				Contents.RemoveAt(0);
			}

			Contents.Add(lineitem);
			if(OnNewLine!=null)
				OnNewLine(lineitem);

		}
	
		public void AddNewLine(string text,string hyperlink)
		{
			LineItem lineitem = new LineItem();

			lineitem.AddText(text);

			if(hyperlink!=null && hyperlink!=string.Empty)
				lineitem.AddHyperlink(hyperlink);

			AddNewLine(lineitem);

		}

		public void AddNewLine(string text)
		{
			AddNewLine(text,null);
		}

	}
}
