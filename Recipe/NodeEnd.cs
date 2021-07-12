using System;
using System.Drawing;

namespace SiGlaz.Recipes
{
	/// <summary>
	/// Summary description for NodeEnd.
	/// </summary>
	/// 
	[NodeNextRule(false)]
	public class NodeEnd : NodeBitmap
	{
		public NodeEnd() : base()
		{
			//Rect.Width = Rect.Height = 20;
			//this.CanResize = false;
			//this.CaptionAligment = eAligment.Bottom;
		}

		public override void Execute(WorkingSpace workingspace)
		{
			base.Execute (workingspace);

			workingspace.Selection = false;
			workingspace.HaveResult = false;
		}


//		public override void Draw(System.Drawing.Graphics g)
//		{
//			//base.Draw (g);
//			g.FillEllipse(Brushes.Black,this.Rect.X + 3,this.Rect.Y + 3, this.Rect.Width - 6,this.Rect.Height-6 );
//			g.DrawEllipse(Pens.Black,this.Rect);
//			DrawCaption(g);
//		}
	}
}
