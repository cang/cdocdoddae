using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SiGlaz.Recipes
{
	public class ShapeCollection : CollectionBase
	{
		public bool				IsMove = false;
		public Shape			Hover = null;
		public Shape			Selected = null;

		public int				idxDownPoint=-1;
		public Point			ptCurrent = Point.Empty;
		public  Hashtable		htMaxid = new Hashtable();

		public int MaxId
		{
			get
			{
				int max = 0;
				foreach(Shape obj in List)
					if( max < obj.ID)
						max = obj.ID;
				return max;
			}
		}

		public new void Clear()
		{
			base.Clear();
			this.ResetSelection();
			htMaxid.Clear();
		}

		public int Add(Shape obj)
		{
			if(obj.ID == 0)
			{
				string type = obj.GetType().Name;
				if( !htMaxid.ContainsKey(type) )
					htMaxid.Add(type,0);

				int maxid = (int)htMaxid[type] + 1;
				htMaxid[type] = maxid;

				obj.ID = this.MaxId + 1;
				obj.Name = obj.GetType().Name + maxid.ToString();
			}
			return List.Add(obj);
		}

		public void Add(params Shape[] objs)
		{
			foreach(Shape obj in objs)
			{
				this.Add(obj);
			}
		}

		protected void PrepareRemove(Shape obj)
		{
			if(obj==null) return;
			if(obj is Link)
			{
				Link link = obj as Link;
				link.Begin = null;
				link.End = null;
			}
			else if(obj is Node)
			{
//				Node node = obj as Node;
//				foreach(Link link in node.Nexts)
//				{
//					this.Remove(link);
//				}
			}
		}

		public void Remove(Shape obj)
		{
			if(obj==null) return;
			PrepareRemove(obj);
			List.Remove(obj);
		}

		public new void RemoveAt(int index)
		{
			Shape obj = this[index] as Shape;
			PrepareRemove(obj);
			base.RemoveAt(index);
		}

		public Shape this[int index]
		{
			get
			{
				return List[index] as Shape;
			}
			set
			{
				List[index] = value;
			}
		}

		public NodeCollection Nodes
		{
			get
			{
				NodeCollection results = new NodeCollection();
				foreach(Shape obj in base.List)
				{
					if(obj is Node)
						results.Add(obj as Node);
				}
				return results;
			}
		}

		public NodeCollection NodesSelected
		{
			get
			{
				NodeCollection results = new NodeCollection();
				foreach(Shape obj in base.List)
				{
					if(obj is Node && obj.Selected)
						results.Add(obj as Node);
				}
				return results;
			}
		}

		public LinkCollection Links
		{
			get
			{
				LinkCollection results = new LinkCollection();
				foreach(Shape obj in base.List)
				{
					if(obj is Link)
						results.Add(obj as Link);
				}
				return results;
			}
		}

		public LinkCollection LinksSelected
		{
			get
			{
				LinkCollection results = new LinkCollection();
				foreach(Shape obj in base.List)
				{
					if(obj is Link && obj.Selected)
						results.Add(obj as Link);
				}
				return results;
			}
		}

		public ShapeCollection	GetList(Type type)
		{
			ShapeCollection results = new ShapeCollection();
			foreach(Shape obj in base.List)
			{
				if(obj.GetType() == type)
					results.Add(obj);
			}
			return results;
		}

		public void Select(bool selected)
		{
			foreach(Shape obj in base.List)
			{
				obj.Selected = selected;
			}
		}


		public void ResetSelection()
		{
			if(Selected!=null)
				Selected = null;

			if(Hover!=null)
				Hover = null;

			idxDownPoint = -1;

			ptCurrent = Point.Empty;
		}

		public void Delete()
		{
			//Check in remove links of node
			foreach(Node node in this.NodesSelected)
			{
				node.Prevs.Select(true);
				node.Nexts.Select(true);
			}

			//Remove selected item
			for(int i=0;i<this.Count;i++)
			{
				if(this[i].Selected)
				{
					
					this.RemoveAt(i);
					i--;
				}
			}

			ResetSelection();
		}

		public void Draw(Graphics g)
		{
			//Draw all
			foreach(Shape obj in base.List)
			{
				obj.Draw(g);
				if(!IsMove)
					obj.DrawSelected(g);
			}

			//Draw hover
			if(Hover!=null)
			{
				if(Hover is Link || !IsMove)
					Hover.DrawActive(g);
			}

			//Draw Last Selected
			if(Selected!=null)
			{
				if(!IsMove)
					Selected.DrawLastSelected(g);
			}

			if(!ptCurrent.IsEmpty)
			{
				if(!IsMove)
				{
					g.FillEllipse(Brushes.White,ptCurrent.X - ObjectConst.RPOINT, ptCurrent.Y - ObjectConst.RPOINT, 2*ObjectConst.RPOINT, 2*ObjectConst.RPOINT);
					g.DrawEllipse(Pens.DarkGray,ptCurrent.X - ObjectConst.RPOINT, ptCurrent.Y - ObjectConst.RPOINT, 2*ObjectConst.RPOINT, 2*ObjectConst.RPOINT);
				}
				else
				{
					SolidBrush bursh = new SolidBrush(ObjectConst.OBJ_POINTCOLOR);
					g.FillEllipse(bursh,ptCurrent.X - ObjectConst.RPOINT, ptCurrent.Y - ObjectConst.RPOINT, 2*ObjectConst.RPOINT, 2*ObjectConst.RPOINT);
					bursh.Dispose();
				}
			}
		}

		public void Move(Size delta)
		{
			foreach(Shape obj in this.Nodes )
			{
				if(obj.Selected)
					obj.Move(delta);
			}
			foreach(Shape obj in this.Links)
			{
				obj.Move(delta);
			}
		}

		public void SelectAtRectangle(Rectangle rc)
		{
			foreach(Shape obj in this.List)
			{
				if(obj.InRectangle(rc))
					obj.Selected = true;
			}
		}

		public void Resize(eTracker tracker,Size delta)
		{
			foreach(Node node in this.NodesSelected)
			{
				node.Resize(tracker,delta);
			}
			foreach(Link obj in this.Links)
			{
				obj.Resize(delta);
			}
		}

		public Rectangle Bound
		{
			get
			{
				Rectangle result = Rectangle.Empty;
				foreach(Shape obj in this.List)
				{
					result = Rectangle.Union(result,obj.Bound);
				}
				return result;
			}
		}

		public Shape	SearchById(int id)
		{
			foreach(Shape obj in this.List)
			{
				if(obj.ID == id)
					return obj;
			}
			return null;
		}



	}
}
