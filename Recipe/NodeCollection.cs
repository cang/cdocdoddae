using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SiGlaz.Recipes
{
	public class NodeCollection : CollectionBase
	{
		public int Add(Node node)
		{
			return List.Add(node);
		}

		public void Add(params Node[] nodes)
		{
			this.InnerList.AddRange(nodes);
		}

		public Node this[int index]
		{
			get
			{
				return List[index] as Node;
			}
			set
			{
				List[index] = value;
			}
		}

		public Node First
		{
			get
			{
				return this[0];
			}
		}

		public Node NodeInPoint(Point pt)
		{
			foreach(Node node in this.List)
			{
				if(node.CursorCheck(pt,ref pt))
					return node;
			}
			return null;
		}
	        
	}

}
