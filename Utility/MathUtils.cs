using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Text.RegularExpressions;

namespace SiGlaz.Utility
{
	/// <summary>
	/// Summary description for Math.
	/// </summary>
	public class MathUtils
	{
		public  const	double INCHPERMM = 25.4;

		public MathUtils()
		{
		}
		public static bool LineIntersecSegment(Point ptLine1,Point ptLine2,Point pt1,Point pt2)
		{
			//Ax+By+C=0
			double A=ptLine2.Y-ptLine1.Y;
			double B=ptLine1.X-ptLine2.X;
			double C=ptLine1.Y*(ptLine2.X-ptLine1.X) - ptLine1.X*(ptLine2.Y-ptLine1.Y);
			return (A*pt1.X + B*pt1.Y + C) * (A*pt2.X + B*pt2.Y + C) <= 0;
		}

		public static bool SegmentIntersecSegment(Point pt1,Point pt2,Point pt3,Point pt4)
		{
			return LineIntersecSegment(pt1,pt2,pt3,pt4) && LineIntersecSegment(pt3,pt4,pt1,pt2);
		}
		public static bool SegmentIntersecRectangle(Point pt1,Point pt2,Rectangle rc)
		{
			Point ptt1,ptt2;

			ptt1=new Point(rc.Left,rc.Top);
			ptt2=new Point(rc.Left,rc.Top + rc.Height);
			if( SegmentIntersecSegment(pt1,pt2,ptt1,ptt2) )
				return true;

			ptt2=new Point(rc.Left + rc.Width,rc.Top);
			if( SegmentIntersecSegment(pt1,pt2,ptt1,ptt2) )
				return true;

			ptt1=new Point(rc.Left + rc.Width,rc.Top + rc.Height);
			if( SegmentIntersecSegment(pt1,pt2,ptt1,ptt2) )
				return true;

			ptt2=new Point(rc.Left,rc.Top + rc.Height);
			if( SegmentIntersecSegment(pt1,pt2,ptt1,ptt2) )
				return true;

			return false;
		}


		/// <summary>
		/// PercentAreaRecAndRing : 0 - 1
		/// </summary>
		/// <param name="rc"></param>
		/// <param name="ring1"></param>
		/// <param name="ring2"></param>
		/// <returns></returns>
		public static double PercentAreaRecAndRing(RectangleF rcTest, RectangleF ring1,RectangleF ring2)
		{
			if(rcTest.IsEmpty)
				return 0;

			PointF pt0=new PointF( ring1.Width/2 + ring1.Left , ring1.Height/2 + ring1.Top );
			float ra1= ring1.Width/2;
			float ra2= ring2.Width/2;

			double sumin=0;
			for(float y=rcTest.Top;y<=rcTest.Top + rcTest.Height ;y++)
			{
				for(float x=rcTest.Left;x<=rcTest.Left + rcTest.Width ;x++)
				{
					double xx=(x-pt0.X)*(x-pt0.X) + (y-pt0.Y)*(y-pt0.Y);
					if( xx >= ra1*ra1 && xx <= ra2*ra2)
					{
						sumin++;
					}
				}
			}
			return sumin/(rcTest.Width*rcTest.Height);

//			Matrix mt=new Matrix();
//            
//
//			//Ring Shape
//			GraphicsPath gpring=new GraphicsPath();
//			gpring.StartFigure();
//			gpring.AddEllipse(ring1);
//			gpring.AddEllipse(ring2);
//			gpring.CloseFigure();
//			Region rngring=new Region(gpring);
//
//			//Rectange Shape
//			GraphicsPath gprc=new GraphicsPath();
//			gprc.AddRectangle(rcTest);
//			Region rngrc=new Region(gprc);
//
//			//Intersect
//			rngrc.Intersect(rngring);
//			RectangleF []arc=rngrc.GetRegionScans(mt);
//
//			double result=0;
//			if(arc==null)
//				result=0;
//			else
//			{
//				double aa=rcTest.Width*rcTest.Height;
//				double sum=0;
//				foreach(RectangleF rc in arc)
//				{
//					sum+= (rc.Width*rc.Height);
//				}
//				result= sum/aa;
//			}
//
//			mt.Dispose();
//			rngrc.Dispose();
//			rngring.Dispose();
//			gprc.Dispose();
//			gpring.Dispose();
//
//			return result;
		}


		/// <summary>
		/// PercentAreaRecAndRec : 0 - 1
		/// </summary>
		/// <param name="rcTest"></param>
		/// <param name="rcRec"></param>
		/// <returns></returns>
		public static double PercentAreaRecAndRec(RectangleF rcTest, RectangleF rcRec)
		{
			if(rcTest.IsEmpty)
				return 0;

			GraphicsPath gp=new GraphicsPath();
			gp.AddRectangle(rcRec);
			Region rng=new Region(gp);

			double sumin=0;
			for(float y=rcTest.Top;y<=rcTest.Top + rcTest.Height ;y++)
			{
				for(float x=rcTest.Left;x<=rcTest.Left + rcTest.Width ;x++)
				{
					if( rng.IsVisible(x,y) )
					{
						sumin++;
					}
				}
			}

			rng.Dispose();
			gp.Dispose();

			return sumin/(rcTest.Width*rcTest.Height);
		}


		
		/// <summary>
		/// PercentAreaRecAndRec : 0 - 1
		/// </summary>
		/// <param name="rcTest"></param>
		/// <param name="rcRec"></param>
		/// <returns></returns>
		public static double PercentAreaRecAndEllipse(RectangleF rcTest, RectangleF rcRec)
		{
			if(rcTest.IsEmpty)
				return 0;

			GraphicsPath gp=new GraphicsPath();
			gp.AddEllipse(rcRec);
			Region rng=new Region(gp);

			double sumin=0;
			for(float y=rcTest.Top;y<=rcTest.Top + rcTest.Height ;y++)
			{
				for(float x=rcTest.Left;x<=rcTest.Left + rcTest.Width ;x++)
				{
					if( rng.IsVisible(x,y) )
					{
						sumin++;
					}
				}
			}

			rng.Dispose();
			gp.Dispose();

			return sumin/(rcTest.Width*rcTest.Height);
		}



		/// <summary>
		/// PercentAreaRecAndArc : 0 - 1
		/// </summary>
		/// <param name="rcTest"></param>
		/// <param name="center"></param>
		/// <param name="r"></param>
		/// <param name="fromangle"></param>
		/// <param name="toangle"></param>
		/// <returns></returns>
		public static double PercentAreaRecAndArc(RectangleF rcTest,PointF center, float r,float fromangle,float toangle)
		{
			if(rcTest.IsEmpty)
				return 0;

			GraphicsPath gp=new GraphicsPath();
			gp.AddPie(center.X-r,center.Y-r,r*2,r*2,fromangle,toangle-fromangle);
			Region rng=new Region(gp);

			double sumin=0;
			for(float y=rcTest.Top;y<=rcTest.Top + rcTest.Height ;y++)
			{
				for(float x=rcTest.Left;x<=rcTest.Left + rcTest.Width ;x++)
				{
					if( rng.IsVisible(x,y) )
					{
						sumin++;
					}
				}
			}

			rng.Dispose();
			gp.Dispose();

			return sumin/(rcTest.Width*rcTest.Height);
		}


		
		public static bool IsWholeNumber(string strNumber)
		{ 
			// use a regular expression to find out if string is actually a number
			if(strNumber==null || strNumber.Trim()=="" ) return false;
			Regex objNotWholePattern=new Regex("[^0-9]");
			return !objNotWholePattern.IsMatch(strNumber);
		}  


		// Function to test whether the string is valid number or not
		public static bool IsNumber(String strNumber)
		{
			Regex objNotNumberPattern=new Regex("[^0-9.-]");
			Regex objTwoDotPattern=new Regex("[0-9]*[.][0-9]*[.][0-9]*");
			Regex objTwoMinusPattern=new Regex("[0-9]*[-][0-9]*[-][0-9]*");
			String strValidRealPattern="^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
			String strValidIntegerPattern="^([-]|[0-9])[0-9]*$";
			Regex objNumberPattern =new Regex("(" + strValidRealPattern +")|(" + strValidIntegerPattern + ")");
			return !objNotNumberPattern.IsMatch(strNumber) &&
				!objTwoDotPattern.IsMatch(strNumber) &&
				!objTwoMinusPattern.IsMatch(strNumber) &&
				objNumberPattern.IsMatch(strNumber);
		}

		public static bool Circle_Line_Intersection(Point center,double r,Point pt1,Point pt2)
		{
			//Move to center
			pt1.Offset(-center.X,-center.Y);
			pt2.Offset(-center.X,-center.Y);

			double dx = pt2.X - pt1.X;
			double dy = pt2.Y - pt1.Y;

			double dr = Math.Sqrt(dx*dx + dy*dy);

			double D = (double)pt1.X*pt2.Y - (double)pt2.X*pt1.Y;
	
			double Delta = r*r*dr*dr - D*D;

			return Delta >= 0.0001;
		}

		public static bool Circle_Segment_Intersection(Point center,double r,Point pt1,Point pt2)
		{
			bool result = Circle_Line_Intersection(center,r,pt1,pt2);
			if(result)
			{
				double xmin = Math.Min(pt1.X,pt2.X);
				double xmax = Math.Max(pt1.X,pt2.X);
				double ymin = Math.Min(pt1.Y,pt2.Y);
				double ymax = Math.Max(pt1.Y,pt2.Y);

				if( center.X >= xmin - r && center.X <= xmax + r
					&& center.Y >= ymin - r && center.Y <= ymax + r)
					return true;
			}
			return false;
		}


		public static double Determinant(double a,double b,double c,double d)
		{
			return a*d-b*c;
		}

		public static bool LineIntersectLine(Point pt1,Point pt2,Point pt3,Point pt4,ref Point ptOut)
		{
			double z = Determinant(pt1.X-pt2.X,pt1.Y-pt2.Y,pt3.X-pt4.X,pt3.Y-pt4.Y);
			if( z==0) return false;

			double a = Determinant(pt1.X,pt1.Y,pt2.X,pt2.Y);
			double b = pt1.X - pt2.X;
			double c = Determinant(pt3.X,pt3.Y,pt4.X,pt4.Y);
			double d = pt3.X - pt4.X;
			double x = Determinant(a,b,c,d)/z;

			b = pt1.Y - pt2.Y;
			d = pt3.Y - pt4.Y;
			double y = Determinant(a,b,c,d)/Determinant(pt1.X-pt2.X,pt1.Y-pt2.Y,pt3.X-pt4.X,pt3.Y-pt4.Y);

			ptOut = new Point( (int)Math.Round(x),(int)Math.Round(y) );
			return true;
		}

		public static bool SegmentIntersectSegment(Point pt1,Point pt2,Point pt3,Point pt4,ref Point ptOut)
		{
			if(!LineIntersectLine(pt1,pt2,pt3,pt4,ref ptOut))
				return false;

			if( !Circle_Segment_Intersection(ptOut,1,pt1,pt2)
				||
				!Circle_Segment_Intersection(ptOut,1,pt3,pt4) )
				return false;

			return true;
		}

		public static bool CircleIntersectCircle(Point pt1,int r1,Point pt2,int r2)
		{
			double dx = pt2.X - pt1.X;
			double dy = pt2.Y - pt1.Y;
			double dd = dx*dx + dy*dy;
			double rr = r1*r1 + r2*r2;

			return dd<=rr + double.Epsilon;
		}

		public static Rectangle Rectanglize(Point pt1, Point pt2)
		{
			int x = (int)Math.Min(pt1.X , pt2.X);
			int y = (int)Math.Min(pt1.Y , pt2.Y);
			int w = (int)Math.Abs(pt1.X-pt2.X) + 1;
			int h = (int)Math.Abs(pt1.Y-pt2.Y) + 1;
			return new Rectangle(x,y,w,h);
		}

		class  PointDistanceCpr : IComparer
		{
			#region IComparer Members
			public int Compare(object x, object y)
			{
				Point ptx = (Point)x;
				Point pty = (Point)y;

				double dx = (double)ptx.X*ptx.X + ptx.Y*ptx.Y;
				double dy = (double)pty.X*pty.X + pty.Y*pty.Y;

				if( dx < dy ) 
					return -1;
				else if( dx > dy )
					return 1;
				else
					return 0;

			}
			#endregion
		}

		public static void GetNearestPoints(int dx,int dy,ref int[] pointx,ref int [] pointy)
		{
			int ddx = dx*2+1;
			int ddy = dy*2+1;
			ArrayList alPoint = new ArrayList();
			for(int y=-dy;y<=dy;y++)
			{
				for(int x=-dx;x<=dx;x++)
				{
					if(x==0 && y==0) continue;
					alPoint.Add( new Point(x,y));
				}
			}
			alPoint.Sort(new PointDistanceCpr());

			pointx = new int[alPoint.Count];
			pointy = new int[alPoint.Count];
			for(int i=0;i<alPoint.Count;i++)
			{
				pointx[i] = ((Point)alPoint[i]).X;
				pointy[i] = ((Point)alPoint[i]).Y;
				alPoint[i] = null;
			}
			alPoint.Clear();
			alPoint = null;
		}

		public static double DistanceOf(int x1,int y1,int x2,int y2)
		{
			double dx = x2-x1;
			double dy = y2-y1;
			return Math.Sqrt(dx*dx+dy*dy);
		}

		public static void Swap(ref int x1,ref int x2)
		{
			x1 = x1 + x2;
			x2 = x1 - x2;
			x1 = x1 - x2;
		}

		public static void MinMax(ref int min,ref int max)
		{
			if(min > max)
				Swap(ref min,ref max);
		}

		public static bool CheckContidion(double left,string oper,double right)
		{
			switch(oper)
			{
				case "==":
					return left==right;
				case "<=":
					return left<=right;
				case "<":
					return left<right;
				case ">":
					return left>right;
				case ">=":
					return left>=right;
				default:
					return false;
			}
		}

	}
}
