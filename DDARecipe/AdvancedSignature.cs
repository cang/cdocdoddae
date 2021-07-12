using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

using SiGlaz.Recipes;

using FPPCommon;
using SSA.SystemFrameworks;
using SSA.SystemFrameworks.Signatures;
//using SSA.Common.TC.PatternRecognition2D;

namespace DDARecipe
{
	/// <summary>
	/// Summary description for AdvancedSignature.
	/// </summary>
	public class AdvancedSignature : NodeBitmap
	{
		public string	LibraryPath = string.Empty;
		public string	FullPathOfSignatureName = string.Empty;

		public AdvancedSignature() : base()
		{
		}

		public override SiGlaz.Recipes.Shape Copy()
		{
			SiGlaz.Recipes.Shape result = base.Copy();

			(result as AdvancedSignature).LibraryPath = this.LibraryPath;
			(result as AdvancedSignature).FullPathOfSignatureName = this.FullPathOfSignatureName;

			return result;
		}

		public override void Property()
		{
			SiGlaz.DDA.WinControls.Automation.DlgSignatureObject  dlg = new SiGlaz.DDA.WinControls.Automation.DlgSignatureObject();
			dlg.LibraryPath = this.LibraryPath;
			dlg.FullPathOfSignatureName = this.FullPathOfSignatureName;
			if( dlg.ShowDialog() == DialogResult.OK)
			{
				this.LibraryPath =dlg.LibraryPath;
				this.FullPathOfSignatureName =dlg.FullPathOfSignatureName;

			}
		}

		public override void Serialize(System.IO.BinaryWriter stream)
		{
			base.Serialize (stream);

			stream.Write(LibraryPath);
			stream.Write(FullPathOfSignatureName);
		}

		public override void Deserialize(System.IO.BinaryReader stream, int versionnumber)
		{
			base.Deserialize (stream, versionnumber);

			this.LibraryPath = stream.ReadString();
			this.FullPathOfSignatureName = stream.ReadString();
		}


		
		private void LoadSignature(bool force)
		{
			if(SignatureParam==null || force)
			{
				try
				{
					if(System.IO.Path.GetExtension(this.LibraryPath).ToUpper()==".MDB")
					{				
/*		
						IDABusiness.Connection.DBController.ConnectDB(this.LibraryPath);
						IDABusiness.Query.QueryData qd = new IDABusiness.Query.QueryData();
						string[] paths = this.FullPathOfSignatureName.Split(@"\".ToCharArray());
						System.Data.DataTable dt = qd.GetToolToolParametersOnly(paths[0],paths[1],paths[2]);
						if(dt!=null && dt.Rows.Count>0)
						{
							SignatureParam = SiGlaz.DDASignatureLib.UI.LibCommon.GetSignatureObjectParam(Convert.FromBase64String(Convert.ToString(dt.Rows[0][0])));
						}
*/
                        throw new Exception("The library file is not mdb file.");
                    }
					else
					{
						SignatureLibrary lib = SignatureLibrary.Deserialize(this.LibraryPath);
						SignatureParam = lib.GetSignatureFromFullPath(this.FullPathOfSignatureName).item;
						lib.Data.Clear();
						lib = null;
					}
				}
				catch
				{
					throw new Exception("Cannot found signature " + this.FullPathOfSignatureName + " in the library.");
				}
			}
		}

		protected SignatureObjectParam SignatureParam=null;
		public override void Execute(WorkingSpace workingspace)
		{
			//base.Execute (workingspace);
			DDAWorkingSpace working = workingspace as DDAWorkingSpace;
			if(working.IsMulti) return;

			SSA.SystemFrameworks.KlarfParserFile map = working.ProcessMap;

			SSA.SystemFrameworks.FrameworksDCDM.m_parserfile = map;

			LoadSignature(false);
			FPPCommon.SignatureObjectParam objparam = this.SignatureParam.Clone();

			ArrayList alDefect = working.OldEngine.SignatureAnalyzer(objparam);

			if(alDefect!=null && alDefect.Count>0)
			{
				working.HaveResult = true;
				working.UpdateDefectList(alDefect);
			}
		}

		public override bool ValidateSyntax (ref string msg)
		{
			if( !System.IO.File.Exists(this.LibraryPath))
			{
				msg =  string.Format("Invalid library path {0}",this.LibraryPath);
				return false;
			}

			try
			{
				SignatureLibrary lib = SignatureLibrary.Deserialize(this.LibraryPath);
				SignatureParam = lib.GetSignatureFromFullPath(this.FullPathOfSignatureName).item;
				lib.Data.Clear();
				lib = null;
			}
			catch
			{
				msg =  "Cannot found signature " + this.FullPathOfSignatureName + " in the library.";
				return false;
			}

			return base.ValidateSyntax(ref msg);
		}


		public override void Import(object obj)
		{
			if(obj==null) return;

			if(obj.GetType()== typeof(SiGlaz.DDA.Framework.Automation.FilterBySignature))
			{
				SiGlaz.DDA.Framework.Automation.FilterBySignature desobj = obj as SiGlaz.DDA.Framework.Automation.FilterBySignature;
				this.LibraryPath = desobj.LibraryPath;
				this.FullPathOfSignatureName = desobj.FullPathOfSignatureName;
			}
			else if(obj.GetType()== typeof(SiGlaz.DDA.Framework.Automation.SignatureStep))
			{
				SiGlaz.DDA.Framework.Automation.SignatureStep desobj = obj as SiGlaz.DDA.Framework.Automation.SignatureStep;
				this.LibraryPath = desobj.LibraryPath;
				this.FullPathOfSignatureName = desobj.FullPathOfSignatureName;
			}

		}

	}
}
