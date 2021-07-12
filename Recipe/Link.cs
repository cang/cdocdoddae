using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SiGlaz.Recipes
{
	/// <summary>
	/// Summary description for Link.
	/// </summary>
	public class Link : Shape
	{
		private Node		_Begin;
		private Node		_End;
		public Point[]	PointPath = new Point[2];

		public Link() : base()
		{
			Caption = string.Empty;
		}

		public Node		Begin
		{
			get
			{
				return _Begin;
			}
			set
			{
				if(this.Begin!=null)
				{
					this.Begin.Nexts.Remove(this);
				}
				if(value!=null)
				{
					_Begin = value;
					this.Begin.Nexts.Add(this);
					this.UpdateLinkPath();
				}
			}
		}
		
		public Node		End
		{
			get
			{
				return _End;
			}
			set
			{
				if(this.End!=null)
				{
					this.End.Prevs.Remove(this);
				}
				if(value!=null)
				{
					_End = value;
					this.End.Prevs.Add(this);
					this.UpdateLinkPath();
				}
			}
		}

		public bool InValidPoint()
		{
			foreach(Point pt in this.PointPath)
			{
				if(pt.IsEmpty) return true;
			}
			return false;
		}

		public override void Draw(System.Drawing.Graphics g)
		{
			if(InValidPoint()) return;

			Pen pen = new Pen(ObjectConst.OBJ_LINKCOLOR ,1);
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

		public override void DrawCaption(Graphics g)
		{
			if(!CaptionVisible) return;
			if( Caption==string.Empty) return;

			Font font = new Font("Arial",8);//new Font(FontFamily.GenericSansSerif,8,FontStyle.Regular);
			SolidBrush brush = new SolidBrush(Color.Black);
			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			sf.LineAlignment = StringAlignment.Center;

			Point pt = Point.Empty;
			if(this.PointPath.Length==2)
			{
				pt.X = (PointPath[0].X + PointPath[1].X)/2;
				pt.Y = (PointPath[0].Y + PointPath[1].Y)/2;
			}
			else if(this.PointPath.Length>2)
			{
				pt = PointPath[1];
			}
			pt.Offset(10,10);
			g.DrawString(this.Caption,font,brush,pt,sf);

			font.Dispose();
			brush.Dispose();
		}

		public override void DrawActive(Graphics g)
		{
			if(InValidPoint()) return;

			Pen pen = new Pen(ObjectConst.OBJ_HOVERCOLOR,2);

			SolidBrush brush = new SolidBrush(ObjectConst.OBJ_HOVERCOLOR);
			g.DrawLines(pen,PointPath);

			DrawArrow(g,pen,this.PointPath[this.PointPath.Length-2].X,
				this.PointPath[this.PointPath.Length-2].Y,
				this.PointPath[this.PointPath.Length-1].X,
				this.PointPath[this.PointPath.Length-1].Y,
				12,
				25);

			foreach(Point pt in PointPath)
			{
				g.FillEllipse(brush,pt.X - ObjectConst.RPOINT, pt.Y - ObjectConst.RPOINT, 2*ObjectConst.RPOINT, 2*ObjectConst.RPOINT);
			}

			pen.Dispose();
			brush.Dispose();
		}

		public override void DrawSelected(Graphics g)
		{
			if(!Selected) return;
			if(InValidPoint()) return;

			foreach(Point pt in PointPath)
			{
				g.FillEllipse(Brushes.White,pt.X - ObjectConst.RPOINT, pt.Y - ObjectConst.RPOINT, 2*ObjectConst.RPOINT, 2*ObjectConst.RPOINT);
				g.DrawEllipse(Pens.Black,pt.X - ObjectConst.RPOINT, pt.Y - ObjectConst.RPOINT, 2*ObjectConst.RPOINT, 2*ObjectConst.RPOINT);
			}
		}

		public override Rectangle Bound
		{
			get
			{
				Point ptTopLeft = this.PointPath[0];
				Point ptRightBottom = this.PointPath[0];
				foreach(Point pt in this.PointPath)
				{
					if(pt.X < ptTopLeft.X)
						ptTopLeft.X = pt.X;
					if(pt.Y < ptTopLeft.Y)
						ptTopLeft.Y = pt.Y;
					if(pt.X> ptRightBottom.X)
						ptRightBottom.X = pt.X;
					if(pt.Y> ptRightBottom.Y)
						ptRightBottom.Y = pt.Y;
				}
				return Rectangle.FromLTRB(ptTopLeft.X,ptTopLeft.Y,ptRightBottom.X,ptRightBottom.Y);
			}
		}

		public override bool CursorCheck(Point pt,ref Point ptOut)
		{
			//Check On this.PointPath
			for(int i=0;i<this.PointPath.Length;i++)
			{
				if( SiGlaz.Utility.MathUtils.CircleIntersectCircle(pt,ObjectConst.RPOINT,this.PointPath[i],ObjectConst.RPOINT) )
				{
					ptOut = this.PointPath[i];
					return true;
				}
			}

			//Check On Line
			for(int i=0;i<this.PointPath.Length-1;i++)
			{
				bool x =SiGlaz.Utility.MathUtils.Circle_Segment_Intersection(pt,ObjectConst.RPOINT,this.PointPath[i],this.PointPath[i+1]);
				if(x) 
				{
					ptOut = pt;
					return true;
				}
			}

			ptOut = Point.Empty;
			return false;
		}

		public override void Move(Size delta)
		{
			RemovePointInNode();

			//if( delta.IsEmpty()) return;

			if(Begin.Selected && End.Selected)//move all
			{
				for(int i=0;i<this.PointPath.Length;i++)
					this.PointPath[i].Offset(delta.Width,delta.Height);
			}
			else if(Begin.Selected || End.Selected)
			{
				if(this.PointPath.Length==2 || this.PointPath.Length>2 && Begin.Selected)
					PointPath[0] = Begin.IntersectWithLine(Begin.Center,this.PointPath[1]);

				if(this.PointPath.Length==2 || this.PointPath.Length>2 && End.Selected)
					PointPath[PointPath.Length-1] = End.IntersectWithLine(this.PointPath[PointPath.Length-2],End.Center);
			}
		}

		public void Resize(Size delta)
		{
			RemovePointInNode();

			if(this.PointPath.Length==2 || this.PointPath.Length>2 && Begin.Selected)
				PointPath[0] = Begin.IntersectWithLine(Begin.Center,this.PointPath[1]);

			if(this.PointPath.Length==2 || this.PointPath.Length>2 && End.Selected)
				PointPath[PointPath.Length-1] = End.IntersectWithLine(this.PointPath[PointPath.Length-2],End.Center);
		}


		public void Move(Point ptFrom,Point ptTo)
		{
			//Check On this.PointPath
			int deltax = ptTo.X - ptFrom.X;
			int deltay = ptTo.Y - ptFrom.Y;
			//for(int i=0;i<this.PointPath.Length;i++)
			for(int i=this.PointPath.Length-1;i>=0;i--)
			{
				if( SiGlaz.Utility.MathUtils.CircleIntersectCircle(ptFrom,ObjectConst.RPOINT,this.PointPath[i],ObjectConst.RPOINT) )
				{
					this.PointPath[i].Offset(deltax,deltay);
					return;
				}
			}
		}

		public void RemovePointInNode()
		{
			if( this.PointPath.Length>2) 
			{
				ArrayList alPoint = new ArrayList();
				alPoint.AddRange(this.PointPath);

				int i = 1;
				while( i>=1 && i<alPoint.Count-1 )
				{
					Point pt = (Point)alPoint[i];
					if(Begin.CursorCheck(pt,ref pt) || End.CursorCheck(pt,ref pt) )
					{
						alPoint.RemoveAt(i);
						continue;
					}
					i++;
				}

				if(this.PointPath.Length > alPoint.Count)
					this.PointPath = alPoint.ToArray(typeof(Point)) as Point[];
			}
		}

		public void RemovePoint()
		{
			if( this.PointPath.Length<=2) return;

			ArrayList alPoint = new ArrayList();
			alPoint.AddRange(this.PointPath);

			int i = 1;
			while( i>=1 && i<alPoint.Count-1 )
			{
				Point pt1 = (Point)alPoint[i-1];
				Point pt2 = (Point)alPoint[i];
				Point pt3 = (Point)alPoint[i+1];

				if( SiGlaz.Utility.MathUtils.Circle_Segment_Intersection(pt2,ObjectConst.RPOINT,pt1,pt3) )
				{
					alPoint.RemoveAt(i);
					continue;
				}
				i++;
			}

			if(this.PointPath.Length > alPoint.Count)
				this.PointPath = alPoint.ToArray(typeof(Point)) as Point[];
		}

		public int AddPoint(Point pt)
		{
			//Check On this.PointPath
			for(int i=0;i<this.PointPath.Length;i++)
			{
				if( SiGlaz.Utility.MathUtils.CircleIntersectCircle(pt,ObjectConst.RPOINT,this.PointPath[i],ObjectConst.RPOINT) )
					return i;
			}

			//Check On Line
			for(int i=0;i<this.PointPath.Length-1;i++)
			{
				bool x =SiGlaz.Utility.MathUtils.Circle_Segment_Intersection(pt,ObjectConst.RPOINT,this.PointPath[i],this.PointPath[i+1]);
				if(x) 
				{
					Point []apt = new Point[this.PointPath.Length+1];
					int j;
					for(j=0;j<=i;j++)
						apt[j]= this.PointPath[j];
					apt[j++]=pt;
					for(;j<apt.Length;j++)
						apt[j]= this.PointPath[j-1];

					this.PointPath = apt;

					return i;
				}
			}

			return -1;
		}

		public string ConnectNode(int idxIndex,Point ptnewpos,NodeCollection nodes)
		{
			string sresult = string.Empty;
			if( idxIndex==0 || idxIndex == this.PointPath.Length-1) 
			{
				Node newNode= nodes.NodeInPoint(ptnewpos);
				if(newNode != null && newNode!=this.Begin && newNode!=this.End)
				{
					//Begin Node change
					if(idxIndex==0)
					{
						//Connect from new Node to End Node
						if(newNode!=this.End && !newNode.NodeInOutNode(this.End) && !newNode.NodeInInNode(this.End) && newNode.CanGo(this.End)) 
						{
							//New Node
							this.Begin = newNode;
						}
						else if(!newNode.CanGo(this.End))
						{
							sresult = "Invalid Syntax \"cannot connect from " + newNode.GetType().Name + " to " + this.End.GetType().Name + "\"";
						}
					}
					else
					{
						//Connect from Begin node to new node
						if(newNode!=this.Begin && !newNode.NodeInInNode(this.Begin) && !newNode.NodeInOutNode(this.Begin) && this.Begin.CanGo(newNode)) 
						{
							//New Node
							this.End = newNode;
						}
						else if(!this.Begin.CanGo(newNode))
						{
							sresult = "Invalid Syntax \"cannot connect from " + this.Begin.GetType().Name + " to " + newNode.GetType().Name + "\"";
						}
					}
				}
			}

			this.UpdateLinkPath();
			return sresult;
		}

		private void UpdateLinkPath()
		{
			if( Begin==null ||  End==null) return;
			if( PointPath.Length==2)
			{
				if( this.Begin.Center.Equals(this.End.Center) )
				{
					PointPath[0] = this.Begin.Center;
					PointPath[1] = this.Begin.Center;
				}
				else
				{
					PointPath[0] = this.Begin.IntersectWithLine(this.Begin.Center,this.End.Center);
					PointPath[1] = this.End.IntersectWithLine(this.Begin.Center,this.End.Center);
				}
			}
			else
			{
				PointPath[0] = Begin.IntersectWithLine(Begin.Center,this.PointPath[1]);
				PointPath[PointPath.Length-1] = End.IntersectWithLine(this.PointPath[PointPath.Length-2],End.Center);
			}
		}

		public override bool InRectangle(Rectangle rc)
		{
			foreach(Point pt in this.PointPath)
				if( !rc.Contains(pt)) return false;
			return true;
		}

		#region archive

		public override void Serialize(System.IO.BinaryWriter stream)
		{
			base.Serialize (stream);
			stream.Write(this.Begin.ID);
			stream.Write(this.End.ID);
			stream.Write(this.PointPath.Length);
			foreach(Point pt in this.PointPath)
			{
				stream.Write(pt.X);
				stream.Write(pt.Y);
			}
		}

		public virtual void Deserialize(System.IO.BinaryReader stream,int versionnumber,ref int beginnode,ref int endnode)
		{
			base.Deserialize(stream,versionnumber);
			beginnode = stream.ReadInt32();
			endnode = stream.ReadInt32();
			int pointlength = stream.ReadInt32();
			this.PointPath = new Point[pointlength];
			for(int i=0;i<pointlength;i++)
			{
				this.PointPath[i].X = stream.ReadInt32();
				this.PointPath[i].Y = stream.ReadInt32();
			}
		}

		#endregion archive


		public override Shape Copy()
		{
			Shape result =  base.Copy ();
			(result as Link).PointPath = this.PointPath.Clone() as Point[];
			(result as Link).Begin = this.Begin;
			(result as Link).End = this.End;
			return result;
		}

	}



}
