using System;
using System.Diagnostics;
using System.Collections;
using System.Threading;
using System.Reflection;

namespace SiGlaz.Recipes
{

	[AttributeUsage(AttributeTargets.Class)]
	public class NodeBitmapResourceAttribute : Attribute
	{
		string resourcename;

		/// <summary>
		/// Can use full path or file name in Images subfolder
		/// </summary>
		/// <param name="resourcename"></param>
		public NodeBitmapResourceAttribute(string resourcename)
		{
			this.resourcename = resourcename;
		}
		public string ResourceName 
		{
			get
			{
				return resourcename;
			}
			set
			{
				resourcename = value;
			}
		}
	}

	
	[AttributeUsage(AttributeTargets.Class)]
	public class NodeBitmapFileAttribute : Attribute
	{
		string file;
		/// <summary>
		/// file = file path or file name in current folder, or "images" subfolder in current folder
		/// </summary>
		/// <param name="file"></param>
		public NodeBitmapFileAttribute(string file)
		{
			this.file = file;
		}
		public string File 
		{
			get
			{
				return file;
			}
			set
			{
				file = value;
			}
		}
	}

	[AttributeUsage(AttributeTargets.Class, AllowMultiple=true, Inherited=true)]
	public class NodeNextRuleAttribute : Attribute
	{
		bool		_Allow;
		Type		_DesType;

		/// <summary>
		/// allow : allow from this node to type node
		/// </summary>
		/// <param name="allow">allow or prevent</param>
		/// <param name="type">destincation node, null = all nodes </param>
		public NodeNextRuleAttribute(bool allow,Type destype)
		{
			this.Allow = allow;
			this.DesType = destype;
		}

		public NodeNextRuleAttribute(bool allow) : this(allow,null)
		{
		}

		public bool	Allow
		{
			get
			{
				return _Allow;
			}
			set
			{
				_Allow = value;
			}
		}

		public Type DesType
		{
			get
			{
				return _DesType;
			}
			set
			{
				_DesType = value;
			}
		}
	}


	[AttributeUsage(AttributeTargets.Class, AllowMultiple=true, Inherited=true)]
	public class LinkNextRuleAttribute : NodeNextRuleAttribute
	{
		/// <summary>
		/// allow : allow from this node to type link
		/// </summary>
		/// <param name="allow">allow or prevent</param>
		/// <param name="type">destincation node, null = all links </param>
		public LinkNextRuleAttribute(bool allow,Type destype)  : base(allow,destype)
		{
		}
		public LinkNextRuleAttribute(bool allow) : base(allow)
		{
		}
	}

}
