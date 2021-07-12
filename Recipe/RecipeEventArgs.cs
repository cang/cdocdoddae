using System;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace SiGlaz.Recipes
{
	[Serializable]
	public class RecipeEventArgs : EventArgs
	{
		string _Message = string.Empty;
		public int RecipeID = -1;

		public RecipeEventArgs()
		{
		}

		public RecipeEventArgs(string message)
		{
			this._Message = message;
		}

		public string Message
		{
			get
			{
				return _Message;
			}
			set
			{
				_Message = value;
			}
		}

		public static new RecipeEventArgs	Empty
		{
			get
			{
				return new RecipeEventArgs();
			}
		}


	}
}
