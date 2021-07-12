using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;

namespace SiGlaz.Engine
{
	/// <summary>
	/// Summary description for GeometryHelper.
	/// </summary>
	public class GeometryHelper
	{
		public GeometryHelper()
		{
		}

		public  static	float MATRIXSIZE = 600;
		public  static	float Flatness = 1f;//0.25
		public  static	float ZoneAndDieThreshold = 50.0F;
		public  const	float RADIAN_MULT = (float)(Math.PI / 180f);
		public  const	float DEGREE_MULT = (float)(180f / Math.PI);

		public static double ComputePolygonArea(Polygon poly)
		{
			if (poly.NofContours <= 0)
				return 0;
			
			Tristrip strips = poly.ToTristrip();
			int num = strips.NofStrips;
			double area = 0;

			for (int i=0; i<num; i++)
			{
				for (int j=0; j<strips.Strip[i].NofVertices-2; j++)
				{
					double temp = area2D_Triangle(
						new PointF((float)strips.Strip[i].Vertex[j].X, (float)strips.Strip[i].Vertex[j].Y),
						new PointF((float)strips.Strip[i].Vertex[j+1].X, (float)strips.Strip[i].Vertex[j+1].Y),
						new PointF((float)strips.Strip[i].Vertex[j+2].X, (float)strips.Strip[i].Vertex[j+2].Y));
					
					area += Math.Abs(temp);
				}
			}

			return area;
		}

		public static float isLeft( PointF P0, PointF P1, PointF P2 )
		{
			return ((P1.X - P0.X) * (P2.Y - P0.Y)
				- (P2.X - P0.X) * (P1.Y - P0.Y));
		}
	
		public static float area2D_Triangle( PointF V0, PointF V1, PointF V2 )
		{
			return (float)(isLeft(V0, V1, V2) / 2.0);
		}

		public static bool PointInPolygon(PointF[] points, float x, float y)
		{
			int length  = points.Length;
			int counter = 0;
			float x_inter;

			PointF p1 = points[0];
			
			// check if point is the same with vertex
			if (p1.X == x && p1.Y == y)
				return true; 

			for ( int i = 1; i <= length; i++ ) 
			{
				PointF p2 = points[i%length];
				
				// check if point is the same with vertex
				if (p2.X == x && p2.Y == y)
					return true; 

				// Check if point is on an horizontal polygon boundary
				if (p1.Y == p2.Y && x > Math.Min(p1.X, p2.X) && x < Math.Max(p1.X, p2.X))
				{
					if (p1.Y == y)
						return true; // point is on boundary					
				}

				if ( y > Math.Min(p1.Y, p2.Y)) 
				{
					if ( y <= Math.Max(p1.Y, p2.Y)) 
					{
						if ( x <= Math.Max(p1.X, p2.X)) 
						{
							if ( p1.Y != p2.Y ) 
							{
								x_inter = (y - p1.Y) * (p2.X - p1.X) / (p2.Y - p1.Y) + p1.X;

								// Check if point is on the polygon boundary (other than horizontal)
								if (x_inter == x) 
									return true; // point is on boundary

								if ( p1.X == p2.X || x <= x_inter) 
									counter++;
							}
						}
					}
				}
				p1 = p2;
			}

			return ( counter % 2 == 1 );
		}


		#region PointInPolygon algorithm backup
		public static bool PointInPolygon3(PointF[] points, float x, float y)
		{
			int numVertices = points.Length;

			bool bInside = false;

			for ( long i=0, j=numVertices-1; i<numVertices; j = i++ )
			{
				if ( ( ( ( points[i].Y <= y ) && ( y < points[j].Y ) )
					|| ( ( points[j].Y <= y ) && ( y < points[i].Y ) ) )
					&& ( x < ( points[j].X - points[i].X ) * ( y - points[i].Y ) / ( points[j].Y - points[i].Y ) + points[i].X ) )
				{
					bInside = !bInside;
				}
			}
			return bInside;
		}

		public static bool PointInPolygon2(PointF[] points, float x, float y)
		{
			float x_inter = 0;
			int intersections = 0;
			int numVertices = points.Length;
			
			for (int i=1; i<numVertices; i++)
			{
				PointF pt1 = points[i-1];
				PointF pt2 = points[i];

				// point is the same with vertex
				if ((pt1.X == x && pt1.Y == y) || (pt2.X == x && pt2.Y == y))
					return true; 
				
				// Check if point is on an horizontal polygon boundary
				if (pt1.Y == pt2.Y && x > Math.Min(pt1.X, pt2.X) && x < Math.Max(pt1.X, pt2.X))
					return true; // point is on boundary
				
				// Check if point is on the polygon boundary (other than horizontal)
				if (y > Math.Min(pt1.Y, pt2.Y) && y <= Math.Max(pt1.Y, pt2.Y) && x <= Math.Max(pt1.X, pt2.X) && pt1.Y != pt2.Y)
				{
					x_inter = (y - pt1.Y) * (pt2.X - pt1.X) / (pt2.Y - pt1.Y) + pt1.X; 
					// Check if point is on the polygon boundary (other than horizontal)
					if (x_inter == x) 
						return true; // point is on boundary

					if (pt1.X == pt2.X || x <= x_inter) 
						intersections++; 
				}
			}

			return (intersections%2 != 0);
		}
		
		#endregion

		/// <summary>
		/// Check whether point (x,y) is visible in an Ellipse.
		/// All of coordinates are Cartesian.
		/// </summary>
		/// <param name="rect">Rectangle bound of Ellipse</param>
		/// <param name="x">X - coordinate of checking point</param>
		/// <param name="y">Y - coordinate of checking point</param>
		/// <returns></returns>
		public static bool PointInEllipse(RectangleF rect, float x, float y)
		{
			if ( PointInRectangle(rect, x, y) == false)
				return false;
			x -= (rect.X + rect.Width * 0.5f);
			y -= (rect.Y + rect.Height * 0.5f);

			float a = rect.Size.Width * 0.5f;
			a *= a;
			float b = rect.Size.Height * 0.5f;
			b *= b;
			return ( x * x / a + y * y / b) <= 1;
		}

		/// <summary>
		/// Check whether point (x,y) is visible in an Arc
		/// </summary>
		/// <param name="center">Arc's center</param>
		/// <param name="radius">Arc's radius</param>
		/// <param name="startAngle">Arc's start angle - </param>
		/// <param name="sweepAngle">Arc's end angle</param>
		/// <param name="x">X - coordinate of checking point</param>
		/// <param name="y">Y - coordinate of checking point</param>
		/// <returns></returns>
		public static bool PointInArc(PointF center, float radius, float startAngle, float sweepAngle, float x, float y)
		{
			x = x - center.X;
			y = y - center.Y;
			float r2 = x * x + y * y;
			if ( r2 > radius * radius)
				return false;
			
			if (x==0 && y==0)
				return true;

			double _angle = (float)(Math.Atan2(y,x) * DEGREE_MULT);
			_angle += 90.0F;
			while (_angle < startAngle)
				_angle += 360.0F;

			return ((_angle - startAngle) <= sweepAngle);
		}

		public static bool PointInArcBoundary(PointF center, float radius, float startAngle, float sweepAngle, float x, float y)
		{
			return PointInArcBoundary(center, radius, startAngle, sweepAngle, x, y, 0.0F);
		}

		public static bool PointInArcBoundary(PointF center, float radius, float startAngle, float sweepAngle, float x, float y, float correctness)
		{
			x = x - center.X;
			y = y - center.Y;
			float r2 = x * x + y * y;
			if ( r2 > radius * radius)
				return false;
			if (x==0 && y==0)
				return true;

			double _angle = (float)(Math.Atan2(y,x) * DEGREE_MULT);
			_angle += 90.0F;
			while (_angle < startAngle)
				_angle += 360.0F;

			double delta = (_angle - startAngle);

			if (delta>=-correctness && delta<=correctness)
				return true;
			if (delta>=sweepAngle-correctness && delta<=correctness+sweepAngle)
				return true;
			return false;
		}

		public static bool PointInRing(PointF center, float minRadius, float maxRadius, float x, float y)
		{
			x = x - center.X;
			y = y - center.Y;
			float r2 = x * x + y * y;

			return ((r2 <= maxRadius*maxRadius) && (r2 >= minRadius * minRadius));
		}

		public static bool PointInRingBoundary(PointF center, float minRadius, float maxRadius, float x, float y)
		{
			return PointInRingBoundary(center, minRadius, maxRadius, x, y, 0.0F);
		}

		public static bool PointInRingBoundary(PointF center, float minRadius, float maxRadius, float x, float y, float correctness)
		{
			x = x - center.X;
			y = y - center.Y;
			
			float radius = (float)Math.Sqrt(x * x + y * y);			
			if (radius>=maxRadius-correctness && radius<=maxRadius+correctness)
				return true;
			if (radius>=maxRadius-correctness && radius<=maxRadius+correctness)
				return true;
			return false;
		}

		
		public static bool PointInRectangle(RectangleF rect, float x, float y)
		{
			return rect.Contains(x, y);
		}

		public static bool RectangleInCircle(PointF center, float radius, RectangleF rect)
		{
			Intersection result = Intersection.CircleRectangle(center, radius, rect);
			return result.Status == Status.Inside;
		}

		public static double EuclideDistance(PointF pt1, PointF pt2)
		{
			double sqr_dist = (pt1.X-pt2.X)*(pt1.X-pt2.X) + (pt1.Y-pt2.Y)*(pt1.Y-pt2.Y);
			return Math.Sqrt(sqr_dist);
		}

		public static float PolygonIntersectWithRect(Polygon poly,RectangleF rcDie)
		{
			if (poly==null)
				throw new System.InvalidOperationException("_polygon has not been created");

			float result = 0.0F;
			Polygon clipPoly = null;
			using (GraphicsPath path = new GraphicsPath())
			{
				path.AddRectangle(rcDie);
				using (Matrix matrix = new Matrix())
					path.Flatten(matrix, Flatness);
				clipPoly = new Polygon(path);
			}

			Polygon retPoly = (Polygon)poly.Clip(GpcOperation.Intersection, clipPoly);
			try
			{
				double area = ComputePolygonArea(retPoly);
				if (area <= 0)
					result = 0.0F;
				else
				{
					double dieArea = (rcDie.Width*rcDie.Height);
					result = (float)Math.Round(((area/dieArea)*100F), 3);
				}
			}
			finally
			{
				if (clipPoly != null) 
				{
					clipPoly.Dispose();
					clipPoly = null;
				}

				if (retPoly != null) 
				{
					retPoly.Dispose();
					retPoly = null;
				}
			}

			return result;
		}

		public static Point[]	GetChipsArray(Polygon poly,int mapx,int mapy)
		{
			if (poly==null)
				return new Point[0];

			ArrayList alChips = new ArrayList();

			float dx = MATRIXSIZE/mapx;
			float dy = MATRIXSIZE/mapy;

			for(int x = 0;x < mapx;x++)
			{
				for(int y = 0; y < mapy;y++)
				{
					RectangleF rc = new RectangleF(x*dx,y*dy,dx,dy);
					if( PolygonIntersectWithRect(poly,rc) >= ZoneAndDieThreshold )
					{
						alChips.Add(new Point(x,y));
					}
				}
			}
			return alChips.ToArray(typeof(Point)) as Point[];
		}

		public static Point[]	GetChipsArray(AreaContour[] contuors,int mapx,int mapy)
		{
			return GetChipsArray(AreaContour.ToPolygon(contuors),mapx,mapy);
		}

		public static Polygon   GetPolygon(Point[] chips,int mapx,int mapy)
		{
			if (chips==null)
				return null;

			float dx = MATRIXSIZE/mapx;
			float dy = MATRIXSIZE/mapy;

			Polygon result = new Polygon();
			using(GraphicsPath gp = new GraphicsPath())
			{
				foreach(Point pt in chips)
				{
					float x = pt.X*dx;
					float y = pt.Y*dy;

					gp.Reset();
					RectangleF rect = new RectangleF(x,y,dx,dy);
					gp.AddRectangle(rect);
					using (Matrix matrix = new Matrix())
					{
						gp.Flatten(matrix,SiGlaz.Engine.GeometryHelper.Flatness);
					}

					// union polygon
					Polygon poly = new Polygon(gp);
					result = poly.Clip(GpcOperation.Union,result);

					// release polygon 
					if (poly != null) 
					{
						poly.Dispose();
						poly = null;
					}
				}
			}

			return result;
		}

		public static AreaContour[] GetAreaContuor(Point[] chips,int mapx,int mapy)
		{
			return AreaContour.FromPolygon(GetPolygon(chips,mapx,mapy));
		}

	}

	public enum Status : int
	{
		NoIntersection = 0,
		Intersect,
		Outside,
		Inside,
		Tangent,
		Coincident,	// line only
		Parallel // line only
	}
		
	public sealed class Intersection
	{
		private Status _status = Status.NoIntersection;
		private ArrayList _points = new ArrayList();

		public Status Status
		{
			get {return _status;}
			set {_status = value;}
		}

		public PointF[] Points
		{
			get {return (PointF[])_points.ToArray(typeof(PointF)); }
		}

		public Intersection()
		{
		}

		public Intersection(Status status)
		{
			_status = status;
		}

		public Intersection(Status status, PointF[] points)
		{
			_status = status;
			_points.AddRange(points);
		}

		public void AddPoint(PointF pt)
		{
			_points.Add(pt);
		}

		public void AddPoint(PointF[] pts)
		{
			_points.AddRange(pts);
		}

		public static Intersection LineLine(PointF a1, PointF a2, PointF b1, PointF b2)
		{
			Intersection result = null;
    
			float ua_t = (b2.X - b1.X) * (a1.Y - b1.Y) - (b2.Y - b1.Y) * (a1.X - b1.X);
			float ub_t = (a2.X - a1.X) * (a1.Y - b1.Y) - (a2.Y - a1.Y) * (a1.X - b1.X);
			float u_b  = (b2.Y - b1.Y) * (a2.X - a1.X) - (b2.X - b1.X) * (a2.Y - a1.Y);

			if ( u_b != 0 ) 
			{
				float ua = ua_t / u_b;
				float ub = ub_t / u_b;

				if ( 0 <= ua && ua <= 1 && 0 <= ub && ub <= 1 ) 
				{
					result = new Intersection(Status.Intersect);
					result.AddPoint(
						new PointF(
						a1.X + ua * (a2.X - a1.X),
						a1.Y + ua * (a2.Y - a1.Y)
						)
						);
				} 
				else 
				{
					result = new Intersection(Status.NoIntersection);
				}
			} 
			else 
			{
				if ( ua_t == 0 || ub_t == 0 ) 
				{
					result = new Intersection(Status.Coincident);
				} 
				else 
				{
					result = new Intersection(Status.Parallel);
				}
			}

			return result; 
		}

		public static Intersection LinePolygon(PointF pt1, PointF pt2, PointF[] points)
		{
			Intersection result = new Intersection();
			int length = points.Length;

			for ( int i = 0; i < length; i++ ) 
			{
				PointF b1 = points[i];
				PointF b2 = points[(i+1) % length];
				Intersection inter = Intersection.LineLine(pt1, pt2, b1, b2);

				result.AddPoint(inter.Points);
			}

			if ( result.Points.Length > 0 ) 
				result.Status = Status.Intersect;

			return result; 
		}

		public static Intersection CircleRectangle(PointF center, float radius, RectangleF rect)
		{
			PointF min = new PointF(rect.Left, rect.Top);
			PointF max = new PointF(rect.Right, rect.Bottom);
			PointF topRight   = new PointF( max.X, min.Y );
			PointF bottomLeft = new PointF( min.X, max.Y );
    
			Intersection inter1 = CircleLine(center, radius, min, topRight);
			Intersection inter2 = CircleLine(center, radius, topRight, max);
			Intersection inter3 = CircleLine(center, radius, max, bottomLeft);
			Intersection inter4 = CircleLine(center, radius, bottomLeft, min);
    
			Intersection result = new Intersection();

			result.AddPoint(inter1.Points);
			result.AddPoint(inter2.Points);
			result.AddPoint(inter3.Points);
			result.AddPoint(inter4.Points);

			if ( result.Points.Length > 0 )
				result.Status = Status.Intersect;
			else
				result.Status = inter1.Status;

			return result; 
		}

		public static Intersection CircleLine(PointF center, float radius, PointF pt1, PointF pt2)
		{
			Intersection result;
			float a  = (pt2.X - pt1.X) * (pt2.X - pt1.X) +
				(pt2.Y - pt1.Y) * (pt2.Y - pt1.Y);
			float b  = 2 * ( (pt2.X - pt1.X) * (pt1.X - center.X) +
				(pt2.Y - pt1.Y) * (pt1.Y - center.Y)   );
			float cc = center.X*center.X + center.Y*center.Y + pt1.X*pt1.X + pt1.Y*pt1.Y -
				2 * (center.X * pt1.X + center.Y * pt1.Y) - radius*radius;
			float deter = b*b - 4*a*cc;

			if ( deter < 0 ) 
			{
				result = new Intersection(Status.Outside);
			} 
			else if ( deter == 0 ) 
			{
				result = new Intersection(Status.Tangent);
				// NOTE: should calculate this point
			} 
			else 
			{
				float e  = (float)Math.Sqrt(deter);
				float u1 = ( -b + e ) / ( 2*a );
				float u2 = ( -b - e ) / ( 2*a );

				if ( (u1 < 0 || u1 > 1) && (u2 < 0 || u2 > 1) ) 
				{
					if ( (u1 < 0 && u2 < 0) || (u1 > 1 && u2 > 1) ) 
					{
						result = new Intersection(Status.Outside);
					} 
					else 
					{
						result = new Intersection(Status.Inside);
					}
				} 
				else 
				{
					result = new Intersection(Status.Intersect);

					if ( 0 <= u1 && u1 <= 1)
						result.AddPoint( Lerp(pt1, pt2, u1));//  pt1.lerp(pt2, u1) );

					if ( 0 <= u2 && u2 <= 1)
						result.AddPoint( Lerp(pt1, pt2, u2));// pt1.lerp(pt2, u2) );
				}
			}
    
			return result; 
		}


		public static Intersection PolygonRectangle(PointF[] points, RectangleF rect)
		{
			PointF min        = new PointF(rect.Left, rect.Top);
			PointF max        = new PointF(rect.Right, rect.Bottom);
			PointF topRight   = new PointF( max.X, min.Y );
			PointF bottomLeft = new PointF( min.X, max.Y );
    
			Intersection inter1 = Intersection.LinePolygon(min, topRight, points);
			Intersection inter2 = Intersection.LinePolygon(topRight, max, points);
			Intersection inter3 = Intersection.LinePolygon(max, bottomLeft, points);
			Intersection inter4 = Intersection.LinePolygon(bottomLeft, min, points);
    
			Intersection result = new Intersection();

			result.AddPoint(inter1.Points);
			result.AddPoint(inter2.Points);
			result.AddPoint(inter3.Points);
			result.AddPoint(inter4.Points);

			if ( result.Points.Length > 0 )
				result.Status = Status.Intersect;

			return result; 
		}

		public static PointF Lerp(PointF pt1, PointF pt2, float t)
		{
			float xPos = pt1.X + (pt2.X - pt1.X) * t;
			float yPos = pt1.Y + (pt2.Y - pt1.Y) * t;
			return new PointF(xPos, yPos);
		}
	}
}
