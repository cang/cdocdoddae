using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SiGlaz.Engine
{
	/// <summary>
	/// Summary description for AreaContour.
	/// </summary>
	public class AreaContour
	{
		public bool IsHole = false;
		public PointF[] Points = null;

		public AreaContour Copy()
		{
			AreaContour obj = MemberwiseClone() as AreaContour;
			if(this.Points!=null)
				obj.Points = this.Points.Clone() as PointF[];
			return obj;
		}

		public static AreaContour[] FromPolygon(Polygon poly)
		{
			if(poly==null) return new AreaContour[0];
			AreaContour[] contours = new AreaContour[poly.NofContours];
			for (int i=0; i<poly.NofContours; i++)
			{
				AreaContour contour = new AreaContour();
				contour.IsHole = poly.ContourIsHole[i];
				VertexList vertices = poly.Contour[i];
				contour.Points = new PointF[vertices.NofVertices];
				for (int j=0; j<vertices.NofVertices; j++)
					contour.Points[j] = new PointF((float)vertices.Vertex[j].X, (float)vertices.Vertex[j].Y);
				contours[i] = contour;
			}
			return contours;
		}

		public static Polygon ToPolygon(AreaContour[] contour)
		{
			if (contour == null)
				return null;
			Polygon poly = new Polygon();
			poly.NofContours = contour.Length;
			poly.Contour = new VertexList[contour.Length];
			poly.ContourIsHole = new bool[contour.Length];
			
			for (int i=0; i<contour.Length; i++)
			{				
				VertexList vertices = new VertexList();
				vertices.NofVertices = contour[i].Points.Length;
				vertices.Vertex = new Vertex[vertices.NofVertices];
				
				for (int j=0; j<vertices.NofVertices; j++)
				{
					Vertex vertex = new Vertex(contour[i].Points[j].X, contour[i].Points[j].Y);
					vertices.Vertex[j] = vertex;
				}

				poly.Contour[i] = vertices;
				poly.ContourIsHole[i] = contour[i].IsHole;
			}

			return poly;
		}


		public static Region CreateRegion(AreaContour[] contour)
		{
            if(contour==null)
				throw new System.InvalidOperationException("AreaContour[] has not been created");

			GraphicsPath gp = new GraphicsPath();

			Region result = new Region();
			result.MakeEmpty();

			if( contour.Length==1)//truong hop chi co 1 polygon --> khong hieu tai sao Hole luon = true
			{
				gp.AddPolygon(contour[0].Points);
				result.Union(gp);
			}
			else
			{
				foreach(AreaContour area in contour)
				{
					if(!area.IsHole)
					{
						gp.Reset();
						gp.AddPolygon(area.Points);
						result.Union(gp);
					}
				}

				foreach(AreaContour area in contour)
				{
					if(area.IsHole)
					{
						gp.Reset();
						gp.AddPolygon(area.Points);
						result.Exclude(gp);
					}
				}
			}

			gp.Dispose();

			return result;
		}


	}

}
