using System;
using System.IO;
using System.Drawing;

namespace SiGlaz.Utility
{
	/// <summary>
	/// Summary description for Thumbnail.
	/// </summary>
	public class Thumbnail
	{
		public static byte[] Combine(byte[] sourceImage, byte[] resultImage)
		{
			MemoryStream sourceMemory = null;
			MemoryStream resultMemory = null;
			Bitmap sourceBitmap = null;
			Bitmap resultBitmap = null;
			Bitmap combinedImage = null;
			MemoryStream combinedMemory = null;
			Graphics g = null;
			try
			{
				sourceMemory = new MemoryStream(sourceImage);
				resultMemory = new MemoryStream(resultImage);
				sourceBitmap = new Bitmap(sourceMemory);
				resultBitmap = new Bitmap(resultMemory);
			
				combinedImage = new Bitmap(200, 100);
				g = Graphics.FromImage(combinedImage);
				g.DrawImage(sourceBitmap, new Rectangle(0, 0, 100, 100), new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), GraphicsUnit.Pixel);
				g.DrawImage(resultBitmap, new Rectangle (100, 0, 100, 100), new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), GraphicsUnit.Pixel);
				combinedMemory = new MemoryStream();
				combinedImage.Save(combinedMemory, System.Drawing.Imaging.ImageFormat.Jpeg);
				byte[] result = combinedMemory.ToArray();
				return result;
			}
			catch
			{
				return null;
			}
			finally
			{
				if ( sourceMemory != null )
				{
					sourceMemory.Close();
					sourceMemory = null;
				}
				if ( resultMemory != null )
				{
					resultMemory.Close();
					resultMemory = null;
				}
				if ( sourceBitmap != null )
				{
					sourceBitmap.Dispose();
					sourceBitmap = null;
				}
				if ( resultBitmap != null )
				{
					resultBitmap.Dispose();
					resultBitmap = null;
				}
				if ( combinedImage != null )
				{
					combinedImage.Dispose();
					combinedImage = null;
				}
				if ( combinedMemory != null )
				{
					combinedMemory.Close();
					combinedMemory = null;
				}
				if ( g != null )
				{
					g.Dispose();
					g = null;
				}
			}
			
		}

		public static byte[] Split(byte[] originalImage)
		{
			MemoryStream originalMemory = null;
			MemoryStream resultMemory = null;
			Bitmap originalBitmap = null;
			Bitmap resultBitmap = null;
			Graphics g = null;
			try
			{
				originalMemory = new MemoryStream(originalImage);
				originalBitmap = new Bitmap(originalMemory);
			
				resultBitmap = new Bitmap(100, 100);
				g = Graphics.FromImage(resultBitmap);
				g.DrawImage(originalBitmap, new Rectangle(0, 0, 100, 100), new Rectangle(0, 0, 100, 100), GraphicsUnit.Pixel);
				resultMemory = new MemoryStream();
				resultBitmap.Save(resultMemory, System.Drawing.Imaging.ImageFormat.Jpeg);
				byte[] result = resultMemory.ToArray();
				return result;
			}
			catch
			{
				return null;
			}
			finally
			{
				if ( originalMemory != null )
				{
					originalMemory.Close();
					originalMemory = null;
				}
				if ( resultMemory != null )
				{
					resultMemory.Close();
					resultMemory = null;
				}
				if ( originalBitmap != null )
				{
					originalBitmap.Dispose();
					originalBitmap = null;
				}
				if ( resultBitmap != null )
				{
					resultBitmap.Dispose();
					resultBitmap = null;
				}
				if ( g != null )
				{
					g.Dispose();
					g = null;
				}
			}
			
		}
	}
}
