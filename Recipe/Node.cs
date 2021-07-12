using System;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SiGlaz.Recipes
{
	/// <summary>
	/// Summary description for Node.
	/// </summary>
	/// 
	[NodeNextRule(true)]
	[NodeNextRule(false,typeof(NodeBegin))]
	public class Node : Shape
	{
		public Rectangle		Rect;
		public LinkCollection	Prevs = new LinkCollection();
		public LinkCollection	Nexts = new LinkCollection();
	
		public Point	Center
		{
			get
			{
				return new Point(Rect.X + Rect.Width/2,Rect.Y + Rect.Height/2);
			}
		}

		public Point	Location
		{
			get
			{
				return Rect.Location;
			}
			set
			{
				Rect.Location = value;
				//must refresh link here
			}
		}

		public int		MinSize
		{
			get
			{
				return (int)Math.Min(Rect.Width,Rect.Height);
			}
		}

		public Node() : base()
		{
			Rect.Width = 50;
			Rect.Height = 40;
			LoadSyntaxRule();
		}

		public override void Draw(Graphics g)
		{
			SolidBrush brush = new SolidBrush(ObjectConst.OBJ_BACKCOLOR);
			FillRoundRect(g,brush,Rect.X,Rect.Y,Rect.Width,Rect.Height,this.MinSize/4);
			DrawRoundRect(g,Pens.Black,Rect.X,Rect.Y,Rect.Width,Rect.Height,this.MinSize/4);
			brush.Dispose();
			DrawCaption(g);
		}

		public override void DrawActive(Graphics g)
		{
			Pen pen = new Pen(ObjectConst.OBJ_HOVERCOLOR,2);
			Rectangle rc = new Rectangle(Rect.X - 10, Rect.Y - 10, Rect.Width + 20, Rect.Height + 20);
			DrawRoundRect(g,pen,rc.X,rc.Y,rc.Width,rc.Height,this.MinSize/10);
			pen.Dispose();
		}

		public override void DrawSelected(Graphics g)
		{
			if(!Selected) return;
			CRectTracker tracker = new CRectTracker();
			tracker.DrawSelectionGhostRect(g,Rect);
			tracker.DrawSelectionTrackers(g,Rect);
		}

		public override void DrawLastSelected(Graphics g)
		{
			CRectTracker tracker = new CRectTracker();
			tracker.DrawSelectionSelectedTrackers (g,Rect);
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

			if(CaptionAligment==eAligment.Center)
			{
				g.DrawString(this.Caption,font,brush,this.Center,sf);
			}
			else if(CaptionAligment==eAligment.Top)
			{
				g.DrawString(this.Caption,font,brush,this.Center.X,Rect.Y - 10,sf);
			}
			else if(CaptionAligment==eAligment.Bottom)
			{
				g.DrawString(this.Caption,font,brush,this.Center.X,Rect.Y  + Rect.Height + 10,sf);
			}

			font.Dispose();
			brush.Dispose();
		}

		public override bool CursorCheck(Point pt,ref Point ptOut)
		{
			return Rect.Contains(pt);
		}

		public override void Move(Size delta)
		{
			base.Move (delta);
			Rect.Offset(delta.Width,delta.Height);
		}

		public override Rectangle Bound
		{
			get
			{
				return this.Rect;
			}
		}

		public virtual  Point IntersectWithLine(Point pt1, Point pt2)
		{
			Point []apt = new Point[]
			{
				new Point(Rect.X,Rect.Y),
				new Point(Rect.X + Rect.Width,Rect.Y),
				new Point(Rect.X + Rect.Width ,Rect.Y + Rect.Height),
				new Point(Rect.X,Rect.Y + Rect.Height),
				new Point(Rect.X,Rect.Y)
			};

			for(int i=0;i<apt.Length-1;i++)
			{
				Point pt = Point.Empty;
				if( SiGlaz.Utility.MathUtils.SegmentIntersectSegment(pt1,pt2,apt[i],apt[i+1],ref pt) )
				{
					return pt;
				}
			}
			return Point.Empty;
		}

		public NodeCollection PrevNodes
		{
			get
			{
				NodeCollection result = new NodeCollection();
				foreach(Link link in this.Prevs)
				{
					result.Add(link.Begin);
				}
				return result;
			}
		}

		public Node PrevFirstNode
		{
			get
			{
				NodeCollection result = this.PrevNodes;
				if( result.Count<1 ) return null;
				return result[0];
			}
		}


		public Node SeachPrevNode(Type type)
		{
			if(this.PrevFirstNode==null) return null;
			if(this.PrevFirstNode.GetType() == type)
				return this.PrevFirstNode;
			else
				return this.PrevFirstNode.SeachPrevNode(type);
		}

		public NodeCollection NextNodes
		{
			get
			{
				NodeCollection result = new NodeCollection();
				foreach(Link link in this.Nexts)
				{
					result.Add(link.End);
				}
				return result;
			}
		}

		public Node NextFirstNode
		{
			get
			{
				NodeCollection result = this.NextNodes;
				if( result.Count<1 ) return null;
				return result[0];
			}
		}

		public bool NodeInInNode(Node node)
		{
			foreach(Node obj in this.PrevNodes)
			{
				if(node == obj)
					return true;
			}
			return false;
		}

		public bool NodeInOutNode(Node node)
		{
			foreach(Node obj in this.NextNodes)
			{
				if(node == obj)
					return true;
			}
			return false;
		}

		public override bool InRectangle(Rectangle rc)
		{
			return SiGlaz.Utility.MathUtils.PercentAreaRecAndRec(this.Rect,rc)>=0.9999;
		}

		public Cursor CursorCheck(Point pt,ref eTracker tracker)
		{
			CRectTracker test = new CRectTracker();
			return test.CursorCheck(this.Rect,pt,ref tracker);
		}

		public virtual void Resize(eTracker tracker,Size delta)
		{
			Point ptTopLeft = new Point(this.Rect.X,this.Rect.Y);
			Point ptBottomRight = new Point(this.Rect.X + this.Rect.Width,this.Rect.Y + this.Rect.Height);

			if(tracker == eTracker.TopLeft)
			{
				ptTopLeft.Offset(delta.Width,delta.Height);
			}
			else if(tracker == eTracker.TopCenter)
			{
				ptTopLeft.Offset(0,delta.Height);
			}
			else if(tracker == eTracker.TopRight)
			{
				ptTopLeft.Offset(0,delta.Height);
				ptBottomRight.Offset(delta.Width,0);
			}
			else if(tracker == eTracker.CenterLeft)
			{
				ptTopLeft.Offset(delta.Width,0);
			}
			else if(tracker == eTracker.CenterRight)
			{
				ptBottomRight.Offset(delta.Width,0);
			}
			else if(tracker == eTracker.BottomLeft)
			{
				ptTopLeft.Offset(delta.Width,0);
				ptBottomRight.Offset(0,delta.Height);
			}
			else if(tracker == eTracker.BottomCenter)
			{
				ptBottomRight.Offset(0,delta.Height);
			}
			else if(tracker == eTracker.BottomRight)
			{
				ptBottomRight.Offset(delta.Width,delta.Height);
			}

			if( Math.Abs(ptTopLeft.X-ptBottomRight.X) >= ObjectConst.OBJ_LIMITSIZE
				&& 
				Math.Abs(ptTopLeft.Y-ptBottomRight.Y) >= ObjectConst.OBJ_LIMITSIZE )
				this.Rect = Rectangle.FromLTRB(ptTopLeft.X,ptTopLeft.Y,ptBottomRight.X,ptBottomRight.Y);
		}
               

		public virtual void LoadSyntaxRule()
		{
			Type type = this.GetType();
			SyntaxRule  rule = null;
			foreach(Attribute attr in type.GetCustomAttributes(true) )
			{
				if( attr is NodeNextRuleAttribute)
				{
					NodeNextRuleAttribute obj = attr as NodeNextRuleAttribute;

					//this type was added
					if(!ObjectConst.htSyntaxRule.ContainsKey(this.GetType().Name) )
					{
						if(rule == null)
							rule = new SyntaxRule(this.GetType());
						rule.Add(attr as NodeNextRuleAttribute);
					}
				}
			}

			if(rule!=null)
				ObjectConst.htSyntaxRule.Add(this.GetType().Name,rule);
		}

		public virtual bool CanGo(Node node)
		{
			SyntaxRule rule = ObjectConst.htSyntaxRule[this.GetType().Name] as SyntaxRule;
			if(rule==null) 
				return false;

			//Check prevent
			foreach(NodeNextRuleAttribute obj in rule.NextRule)
			{
				if(!obj.Allow)
				{
					if( obj.DesType == node.GetType() )
						return false;
				}
			}

			//Check allow
			foreach(NodeNextRuleAttribute obj in rule.NextRule)
			{
				if(obj.Allow)
				{
					if( obj.DesType == node.GetType() )
						return true;
				}
			}

			
			//Check prevent all
			foreach(NodeNextRuleAttribute obj in rule.NextRule)
			{
				if(obj.DesType == null && !obj.Allow)
					return false;
			}

			//Check allow all
			foreach(NodeNextRuleAttribute obj in rule.NextRule)
			{
				if(obj.DesType == null && obj.Allow)
					return true;
			}

			//default
			return false;
		}

		#region archive

		public override void Serialize(System.IO.BinaryWriter stream)
		{
			base.Serialize (stream);
			stream.Write(Rect.X);
			stream.Write(Rect.Y);
			stream.Write(Rect.Width);
			stream.Write(Rect.Height);
		}


		public override void Deserialize(System.IO.BinaryReader stream, int versionnumber)
		{
			base.Deserialize (stream, versionnumber);
			Rect.X = stream.ReadInt32();
			Rect.Y = stream.ReadInt32();
			Rect.Width = stream.ReadInt32();
			Rect.Height = stream.ReadInt32();
		}

		#endregion archive

		public override Shape Copy()
		{
			Shape result = base.Copy();
			(result as Node).Rect = this.Rect;
			(result as Node).Prevs = new LinkCollection();
			(result as Node).Nexts = new LinkCollection();
			return result;
		}

		public virtual bool	ValidateSyntax(ref string msg)
		{
			return true;
		}

		public virtual bool	Validate(ref string msg)
		{
			return true;
		}

		public virtual void Execute(WorkingSpace workingspace)
		{
		}

		public virtual void Import(object obj)
		{
			
		}
	}


}
