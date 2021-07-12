using System;
using System.Drawing;

namespace SiGlaz.Recipes
{
	/// <summary>
	/// Summary description for NodeBegin.
	/// </summary>
	/// 
	[NodeNextRule(false)]
	[NodeNextRule(true,typeof(NodeSource))]
	public class NodeBegin : NodeBitmap
	{
		public NodeBegin() : base()
		{
			//Rect.Width = Rect.Height = 20;
			//this.CanResize = false;
			//this.CaptionAligment = eAligment.Bottom;
		}

//		public override void Draw(System.Drawing.Graphics g)
//		{
//			//base.Draw (g);
//			g.FillEllipse(Brushes.Black,this.Rect);
//			DrawCaption(g);
//		}

	}
}
