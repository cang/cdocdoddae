using System;
using System.Drawing;

namespace SiGlaz.Recipes
{
	/// <summary>
	/// Summary description for LinkTrue.
	/// </summary>
	public class LinkFalse : Link
	{
		public LinkFalse() : base()
		{
		}
	
		public override void Draw(System.Drawing.Graphics g)
		{
			if(InValidPoint()) return;

			Pen pen = new Pen(Color.Red,1);
			g.DrawLines(pen,PointPath);

			DrawArrow(g,pen,this.PointPath[this.PointPath.Length-2].X,
				this.PointPath[this.PointPath.Length-2].Y,
				this.PointPath[this.PointPath.Length-1].X,
				this.PointPath[this.PointPath.Length-1].Y,
				12,
				25);

			pen.Dispose();
			DrawCaption(g);
		}

	}

}
