using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace SiGlaz.Recipes
{
	/// <summary>
	/// Summary description for ImageNode.
	/// </summary>
	/// 
	public class NodeBitmap : Node
	{
		public NodeBitmap() : base()
		{
			CanResize = false;
			CaptionAligment = eAligment.Bottom;
			LoadBitmapResource();
		}

		private void LoadBitmapResource()
		{
			Type type = this.GetType();
			foreach(Attribute attr in type.GetCustomAttributes(true) )
			{
				if( attr is NodeBitmapResourceAttribute)
				{
					NodeBitmapResourceAttribute obj = attr as NodeBitmapResourceAttribute;
					if( !ObjectConst.htBitmap.ContainsKey(this.GetType().Name) )
					{
						Bitmap	bmp = null;
						try{bmp = new Bitmap(this.GetType(),"Images." + obj.ResourceName);}catch{}
						if(bmp==null)
							try{bmp = new Bitmap(this.GetType(),obj.ResourceName);}catch{}
						if(bmp!=null)
							ObjectConst.htBitmap.Add(this.GetType().Name,bmp);
					}
					else
						break;
				}
				else if( attr is NodeBitmapFileAttribute)
				{
					NodeBitmapFileAttribute obj = attr as NodeBitmapFileAttribute;
					if( !ObjectConst.htBitmap.ContainsKey(this.GetType().Name) )
					{
						Bitmap	bmp = null;

						string path = obj.File;
						if(!File.Exists(path))
						{
							if( File.Exists(Path.Combine( AppDomain.CurrentDomain.BaseDirectory , path ) ) )
								path = Path.Combine( AppDomain.CurrentDomain.BaseDirectory , path );
							else if( File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Images", path ) ))
								path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Images", path );
						}
						if(File.Exists(path))
						{
							try{bmp = new Bitmap(path);}
							catch{}
							if(bmp!=null)
								ObjectConst.htBitmap.Add(this.GetType().Name,bmp);
						}
					}
					else
						break;
				}
			}

			if(this.Bitmap==null)
			{
				Bitmap	bmp = null;
				try{bmp = new Bitmap(this.GetType(),"Images." + this.GetType().Name + ".gif");}
				catch{}
				if(bmp!=null)
					ObjectConst.htBitmap.Add(this.GetType().Name,bmp);
			}

			if(this.Bitmap!=null)
			{
				this.Rect.Width = this.Bitmap.Width;
				this.Rect.Height = this.Bitmap.Height;
			}
		}

		public virtual Bitmap			Bitmap
		{
			get
			{
				return ObjectConst.htBitmap[this.GetType().Name] as Bitmap;
			}
		}

		public override void Draw(Graphics g)
		{
			if( this.Bitmap==null)
			{
				base.Draw(g);
				return;
			}
			g.DrawImage(this.Bitmap,this.Rect,0,0,this.Bitmap.Width,this.Bitmap.Height,GraphicsUnit.Pixel);
			DrawCaption(g);
		}

	}


}
