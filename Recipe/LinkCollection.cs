using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SiGlaz.Recipes
{
	public class LinkCollection : CollectionBase
	{
		public int Add(Link link)
		{
			return List.Add(link);
		}

		public void Add(params Link[] links)
		{
			InnerList.AddRange(links);
		}

		public Link this[int index]
		{
			get
			{
				return List[index] as Link;
			}
			set
			{
				List[index] = value;
			}
		}

		public void Select(bool selected)
		{
			foreach(Shape obj in base.List)
			{
				obj.Selected = selected;
			}
		}

		public void Remove(Link link)
		{
			this.List.Remove(link);
		}

		public Link First
		{
			get
			{
				return this[0];
			}
		}


	}

}
