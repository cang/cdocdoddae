using System;
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
	public class PatternRecognition : NodeBitmap
	{
		public string	LibraryPath = string.Empty;
		public FPPCommon.RecognizeParam Param = new FPPCommon.RecognizeParam();

		public PatternRecognition() : base()
		{
		}

		public override SiGlaz.Recipes.Shape Copy()
		{
			SiGlaz.Recipes.Shape result = base.Copy();

			(result as PatternRecognition).LibraryPath = this.LibraryPath;
			(result as PatternRecognition).Param = this.Param.Clone() as FPPCommon.RecognizeParam;

			return result;
		}

		public override void Property()
		{
			using(SiGlaz.DDA.WinControls.Automation.RecognizeThreshold dlg = new SiGlaz.DDA.WinControls.Automation.RecognizeThreshold())
			{
				dlg.Data = this.Param;
				if(this.LibraryPath!=string.Empty)
					dlg.LibPath = this.LibraryPath;

				if( dlg.ShowDialog() == DialogResult.OK)
				{
					this.LibraryPath= dlg.LibPath;
					this.Param = dlg.Data;
				}
			}
		}

		public override void Serialize(System.IO.BinaryWriter stream)
		{
			base.Serialize (stream);

			stream.Write(LibraryPath);

			byte[] lpbyte = SiGlaz.Common.XmlSerializeCommon.Serialize(this.Param);
			int count = lpbyte==null?0:lpbyte.Length;
			stream.Write(count);
			stream.Write(lpbyte,0,count);
			
		}

		public override void Deserialize(System.IO.BinaryReader stream, int versionnumber)
		{
			base.Deserialize (stream, versionnumber);

			this.LibraryPath = stream.ReadString();

			int count = stream.ReadInt32();
			if(count>0)
			{
				byte[] lpbyte = stream.ReadBytes(count);
				this.Param = SiGlaz.Common.XmlSerializeCommon.Deserialize(lpbyte,typeof(FPPCommon.RecognizeParam)) as FPPCommon.RecognizeParam;
			}
		
		}

		private void Loadlibrary(DDAWorkingSpace working)
		{
			if( this.LibraryPath == string.Empty ) return;
			if( !working.htPatternLibrary.ContainsKey(LibraryPath) )
			{
				try
				{
					working.htPatternLibrary.Add(LibraryPath,new SSA.Common.TC.PatternRecognition2D.Wafer_Pattern_Management(LibraryPath));
				}
				catch
				{
					throw new Exception( string.Format("Invalid library path {0}",LibraryPath));
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

			Loadlibrary(working);

		
			SSA.Common.TC.PatternRecognition2D.Wafer_Pattern_Management lib = working.htPatternLibrary[LibraryPath] as SSA.Common.TC.PatternRecognition2D.Wafer_Pattern_Management;
			RecognizeParam objparam = this.Param.Clone() as RecognizeParam;
			ArrayList ThumbnailImageNames=new ArrayList();
			ArrayList Categories=new ArrayList();
			ArrayList correctnessArr=new ArrayList();

			SSA.SystemFrameworks.FrameworksDCDM.m_parserfile = map;

			working.OldEngine.Recognize(lib,objparam,ThumbnailImageNames,Categories, correctnessArr);

			if(Categories.Count > 0 && Categories[0].ToString()!=string.Empty )
			{
				working.HaveResult = true;

				string name = Categories[0].ToString();
				//Insert result into database and return;
				working.UpdateDefectList(name,map.m_DefectList.defectrecordarray);
			}

		}

		public override bool ValidateSyntax(ref string msg)
		{
			if( !System.IO.File.Exists(this.LibraryPath))
			{
				msg =  string.Format("Invalid library path {0}",this.LibraryPath);
				return false;
			}

			return base.ValidateSyntax(ref msg);
		}

		public override void Import(object obj)
		{
			if(obj==null) return;
			if(obj.GetType()!= typeof(SiGlaz.DDA.Framework.Automation.PatternStep)) return;

			SiGlaz.DDA.Framework.Automation.PatternStep desobj = obj as SiGlaz.DDA.Framework.Automation.PatternStep;
			this.LibraryPath = desobj.LibraryPath;
			this.Param = desobj.Param;
		}

	}
}
