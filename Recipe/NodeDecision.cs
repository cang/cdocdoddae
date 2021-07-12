using System;
using System.Drawing;

namespace SiGlaz.Recipes
{
	/// <summary>
	/// Summary description for NodeDecision.
	/// </summary>
	public class NodeDecision : NodeBitmap
	{
		public NodeDecision() : base()
		{
//			Rect.Width = 20;
//			Rect.Height = 32;
//			CaptionAligment = eAligment.Bottom;
		}

//		public override void Draw(System.Drawing.Graphics g)
//		{
//			//base.Draw (g);
//			SolidBrush brush = new SolidBrush(ObjectConst.OBJ_BACKCOLOR);
//			Point []apt = new Point[4];
//			apt[0].X = Rect.X;
//			apt[0].Y = Rect.Y + Rect.Height/2;
//
//			apt[1].X = Rect.X + Rect.Width/2;
//			apt[1].Y = Rect.Y;
//
//			apt[2].X = Rect.X + Rect.Width;
//			apt[2].Y = Rect.Y + Rect.Height/2;
//
//			apt[3].X = Rect.X + Rect.Width/2;
//			apt[3].Y = Rect.Y + Rect.Height;
//
//			g.FillPolygon(brush,apt);
//			g.DrawPolygon(Pens.Black,apt);
//
//			brush.Dispose();
//			DrawCaption(g);
//		}

		public Node	TrueNode
		{
			get
			{
				foreach(Link link in this.Nexts)
				{
					if(link is LinkTrue)
					{
						return link.End;
					}
				}
				return null;
			}
		}

		public Node	FalseNode
		{
			get
			{
				foreach(Link link in this.Nexts)
				{
					if(link is LinkFalse)
					{
						return link.End;
					}
				}
				return null;
			}
		}

	}

}
