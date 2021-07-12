using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SiGlaz.Recipes
{
	public enum  eTracker  : byte
	{
		Default,
		TopLeft,
		TopCenter,
		TopRight,
		CenterLeft,
		CenterRight,
		BottomLeft,
		BottomCenter,
		BottomRight
	}

	public class CRectTracker
	{
		private Rectangle m_TopLeft;
		private Rectangle m_TopCenter;
		private Rectangle m_TopRight;
		private Rectangle m_CenterLeft;
		private Rectangle m_CenterRight;
		private Rectangle m_BottomLeft;
		private Rectangle m_BottomCenter;
		private Rectangle m_BottomRight;
		private int m_nOffset = 6;

		public CRectTracker()
		{
		}

		public void InitTrackerRects(Rectangle rc)
		{
			Size sz = new Size(m_nOffset, m_nOffset);
			
			m_TopLeft = new Rectangle(new Point(rc.X - m_nOffset, rc.Y - m_nOffset), sz);
			m_TopCenter = new Rectangle(new Point(rc.X + (rc.Width / 2) - (m_nOffset / 2), rc.Y - m_nOffset), sz);
			m_TopRight = new Rectangle(new Point(rc.X + rc.Width , rc.Y - m_nOffset), sz);

			m_CenterLeft = new Rectangle(new Point(rc.X - m_nOffset, rc.Y + (rc.Height / 2) - (m_nOffset / 2)), sz);
			m_CenterRight = new Rectangle(new Point(rc.X + rc.Width,  rc.Y + (rc.Height / 2) - (m_nOffset / 2)), sz);
			
			m_BottomLeft = new Rectangle(new Point(rc.X - m_nOffset, rc.Y + rc.Height), sz);
			m_BottomCenter = new Rectangle(new Point(rc.X + (rc.Width / 2) - (m_nOffset / 2), rc.Y + rc.Height), sz);
			m_BottomRight = new Rectangle(new Point(rc.X + rc.Width, rc.Y + rc.Height), sz);
		}

		public void DrawSelectionGhostRect(Graphics g,Rectangle rc)
		{
			ControlPaint.DrawFocusRectangle(g, rc, Color.Black, Color.Transparent);
		}

		public void DrawSelectionSelectedTrackers(Graphics g,Rectangle rc)
		{
			InitTrackerRects(rc);

			// drawing to image
			g.FillRectangle(Brushes.White,m_TopLeft);
			g.DrawRectangle(Pens.Black,m_TopLeft);

			g.FillRectangle(Brushes.White, m_TopCenter);
			g.DrawRectangle(Pens.Black,m_TopCenter);

			g.FillRectangle(Brushes.White, m_TopRight);
			g.DrawRectangle(Pens.Black,m_TopRight);

			g.FillRectangle(Brushes.White, m_CenterLeft);
			g.DrawRectangle(Pens.Black,m_CenterLeft);

			g.FillRectangle(Brushes.White, m_CenterRight);
			g.DrawRectangle(Pens.Black,m_CenterRight);

			g.FillRectangle(Brushes.White, m_BottomLeft);
			g.DrawRectangle(Pens.Black,m_BottomLeft);

			g.FillRectangle(Brushes.White, m_BottomCenter);
			g.DrawRectangle(Pens.Black,m_BottomCenter);

			g.FillRectangle(Brushes.White, m_BottomRight);
			g.DrawRectangle(Pens.Black,m_BottomRight);
		}

		public void DrawSelectionTrackers(Graphics g,Rectangle rc)
		{
			Brush b = new SolidBrush(Color.Black);
			InitTrackerRects(rc);

			// drawing to image
			g.FillRectangle(b, m_TopLeft);
			g.FillRectangle(b, m_TopCenter);
			g.FillRectangle(b, m_TopRight);
			g.FillRectangle(b, m_CenterLeft);
			g.FillRectangle(b, m_CenterRight);
			g.FillRectangle(b, m_BottomLeft);
			g.FillRectangle(b, m_BottomCenter);
			g.FillRectangle(b, m_BottomRight);
		}

		public Cursor CursorCheck(Rectangle rc, Point pt,ref eTracker tracker)
		{
			InitTrackerRects(rc);

			if(m_TopLeft.Contains(pt))
			{
				tracker = eTracker.TopLeft;
				return Cursors.SizeNWSE;
			}
			else if(m_BottomRight.Contains(pt))
			{
				tracker = eTracker.BottomRight;
				return Cursors.SizeNWSE;
			}
			else if(m_TopRight.Contains(pt))
			{
				tracker = eTracker.TopRight;
				return Cursors.SizeNESW;
			}
			else if(m_BottomLeft.Contains(pt))
			{
				tracker = eTracker.BottomLeft;
				return Cursors.SizeNESW;
			}
			else if(m_CenterLeft.Contains(pt))
			{
				tracker = eTracker.CenterLeft;
				return Cursors.SizeWE;
			}
			else if(m_CenterRight.Contains(pt))
			{
				tracker = eTracker.CenterRight;
				return Cursors.SizeWE;
			}
			else if(m_TopCenter.Contains(pt))
			{
				tracker = eTracker.TopCenter;
				return Cursors.SizeNS;
			}
			else if(m_BottomCenter.Contains(pt))
			{
				tracker = eTracker.BottomCenter;
				return Cursors.SizeNS;
			}
			else
			{
				tracker = eTracker.Default;
				return Cursors.Default;
			}
		}

	}
}
