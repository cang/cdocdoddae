using System;
using System.IO;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SiGlaz.Recipes
{
	/// <summary>
	/// Summary description for Shape.
	/// </summary>
	/// 
	public abstract class Shape
	{
		#region fields
		public int			ID;
		public string		Name = string.Empty;
		public string		Caption = string.Empty;
		public Recipe		Parent = null;

		//temp
		public bool			Selected = false;
		public bool			CanResize = true;
		public eAligment	CaptionAligment = eAligment.Center;
		public bool			CaptionVisible = true;
		#endregion fields

		#region constructor
		public Shape()
		{
			Caption = this.GetType().Name;
		}
		#endregion constructor

		#region GUI
		public virtual void Draw(Graphics g)
		{
		}

		public virtual void DrawCaption(Graphics g)
		{
		}

		public virtual void DrawSelected(Graphics g)
		{
		}

		public virtual void DrawLastSelected(Graphics g)
		{
		}

		public virtual void DrawActive(Graphics g)
		{
		}

		public virtual void Move(Size delta)
		{
		}
		
		public void DrawRoundRect(Graphics g, Pen p, float X, float Y, float width, float height, float radius)
		{
			if( width < 2 || height <2 || radius<=0 || radius ==width || radius==height)
			{
				g.DrawRectangle(p,X,Y,width,height);
				return;
			}
			GraphicsPath gp=new GraphicsPath();
			gp.AddLine(X + radius, Y, X + width - (radius*2), Y);
			gp.AddArc(X + width - (radius*2), Y, radius*2, radius*2, 270, 90);
			gp.AddLine(X + width, Y + radius, X + width, Y + height - (radius*2));
			gp.AddArc(X + width - (radius*2), Y + height - (radius*2), radius*2, radius*2,0,90);
			gp.AddLine(X + width - (radius*2), Y + height, X + radius, Y + height);
			gp.AddArc(X, Y + height - (radius*2), radius*2, radius*2, 90, 90);
			gp.AddLine(X, Y + height - (radius*2), X, Y + radius);
			gp.AddArc(X, Y, radius*2, radius*2, 180, 90);
			gp.CloseFigure();
			g.DrawPath(p, gp);
			gp.Dispose();
		}

		public void FillRoundRect(Graphics g, Brush brush, float X, float Y, float width, float height, float radius)
		{
			if( width < 2 || height <2 || radius<=0 || radius ==width || radius==height)
			{
				g.FillRectangle(brush,X,Y,width,height);
				return;
			}

			GraphicsPath gp=new GraphicsPath();
			gp.AddLine(X + radius, Y, X + width - (radius*2), Y);
			gp.AddArc(X + width - (radius*2), Y, radius*2, radius*2, 270, 90);
			gp.AddLine(X + width, Y + radius, X + width, Y + height - (radius*2));
			gp.AddArc(X + width - (radius*2), Y + height - (radius*2), radius*2, radius*2,0,90);
			gp.AddLine(X + width - (radius*2), Y + height, X + radius, Y + height);
			gp.AddArc(X, Y + height - (radius*2), radius*2, radius*2, 90, 90);
			gp.AddLine(X, Y + height - (radius*2), X, Y + radius);
			gp.AddArc(X, Y, radius*2, radius*2, 180, 90);
			gp.CloseFigure();
			g.FillPath(brush,gp);
			gp.Dispose();
		}

		public void DrawArrow(Graphics g,Pen pen,int x1,int y1,int x2,int y2,int arrowsize,float arrowangle)
		{
			double dx = x2-x1;
			double dy = y2-y1;
			double angle =  Math.Atan2(dy,dx);
			int x11 = x2 - (int)(arrowsize * Math.Cos(angle));
			int y11 = y2 - (int)(arrowsize * Math.Sin(angle));

			PointF []apt1 = new PointF[] {new PointF(x11,y11)};
			PointF []apt2 = new PointF[] {new PointF(x11,y11)};

			Matrix mt = new Matrix();
			mt.RotateAt(arrowangle,new PointF(x2,y2));
			mt.TransformPoints(apt1);
			mt.Reset();
			mt.RotateAt(-arrowangle,new PointF(x2,y2));
			mt.TransformPoints(apt2);

			g.DrawLine(pen,(int)apt1[0].X,(int)apt1[0].Y,x2,y2);
			g.DrawLine(pen,(int)apt2[0].X,(int)apt2[0].Y,x2,y2);

			mt.Dispose();
		}

		public abstract bool CursorCheck(Point pt,ref Point ptOut);
		public abstract bool InRectangle(Rectangle rc);
		public abstract Rectangle	Bound
		{
			get;
		}

		#endregion GUI

		#region Events

		public virtual void DoubleClick()
		{
			//MessageBox.Show("DoubleClick on " + this.Name ,Application.ProductName);
			Property();
		}

		public virtual void LeftClick()
		{
		}

		public virtual void RightClick()
		{
			//MessageBox.Show("RightClick on " + this.Name ,Application.ProductName);
			Dialogs.DlgEditShape dlg = new SiGlaz.Recipes.Dialogs.DlgEditShape(this);
			dlg.ShowDialog();
		}

		public virtual void Property()
		{
		}

		#endregion Events

		#region archive

		public virtual void Serialize(BinaryWriter stream)
		{
			stream.Write(ID);
			stream.Write(Name);
			stream.Write(Caption);
		}

		public virtual void Deserialize(BinaryReader stream,int versionnumber)
		{
			this.ID = stream.ReadInt32();
			this.Name = stream.ReadString();
			this.Caption = stream.ReadString();
		}

		#endregion archive

		public virtual Shape Copy()
		{
			return MemberwiseClone() as Shape;
		}

	}

}
