using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace SiGlaz.Windows
{
	/// <summary>
	/// Summary description for ComboBoxEx.
	/// </summary>
	public class ComboBoxEx : ComboBox
	{
		private ImageList imageList;
		public ImageList ImageList
		{
			get {return imageList;}
			set {imageList = value;}
		}

		public ComboBoxEx()
		{
			DrawMode = DrawMode.OwnerDrawFixed;
		}

		public void AddItem(string text,int imgindex)
		{
			ComboBoxExItem item = new ComboBoxExItem(text,imgindex);
			this.Items.Add(item);
		}

		protected override void OnDrawItem(DrawItemEventArgs ea)
		{
			ea.DrawBackground();
			ea.DrawFocusRectangle();

			ComboBoxExItem item;
			Size imageSize = imageList.ImageSize;
			Rectangle bounds = ea.Bounds;

			try
			{
				item = (ComboBoxExItem)Items[ea.Index];

				if (item.ImageIndex != -1)
				{
					imageList.Draw(ea.Graphics, bounds.Left, bounds.Top,
						item.ImageIndex);
					ea.Graphics.DrawString(item.Text, ea.Font, new
						SolidBrush(ea.ForeColor), bounds.Left+imageSize.Width, bounds.Top);
				}
				else
				{
					ea.Graphics.DrawString(item.Text, ea.Font, new
						SolidBrush(ea.ForeColor), bounds.Left, bounds.Top);
				}
			}
			catch
			{
				if (ea.Index != -1)
				{
					ea.Graphics.DrawString(Items[ea.Index].ToString(), ea.Font, new
						SolidBrush(ea.ForeColor), bounds.Left, bounds.Top);
				}
				else
				{
					ea.Graphics.DrawString(Text, ea.Font, new
						SolidBrush(ea.ForeColor), bounds.Left, bounds.Top);
				}
			}

			base.OnDrawItem(ea);
		}
	}

	public class ComboBoxExItem
	{
		private string _text;
		private object _tag;

		public string Text
		{
			get {return _text;}
			set {_text = value;}
		}

		public object Tag
		{
			get
			{
				return _tag;
			}
			set
			{
				_tag = value;
			}
		}

		private int _imageIndex;
		public int ImageIndex
		{
			get {return _imageIndex;}
			set {_imageIndex = value;}
		}

		public ComboBoxExItem()
			: this("") 
		{
		}

		public ComboBoxExItem(string text)
			: this(text, -1) 
		{
		}

		public ComboBoxExItem(string text, int imageIndex)
		{
			_text = text;
			_imageIndex = imageIndex;
		}

		public ComboBoxExItem(string text, int imageIndex,object tag) : this(text,imageIndex)
		{
			_tag = tag;
		}

		public override string ToString()
		{
			return _text;
		}

	}
}
