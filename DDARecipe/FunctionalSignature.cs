using System;
using System.Windows.Forms;
using System.Collections;

using SiGlaz.Recipes;

using FPPCommon;
using SSA.SystemFrameworks;
using SSA.SystemFrameworks.Signatures;
using SSA.Business.Facade.BFacadeTC;

//using SSA.Common.TC.PatternRecognition2D;

namespace DDARecipe
{
	/// <summary>
	/// Summary description for AdvancedSignature.
	/// </summary>
	public class FunctionalSignature : NodeBitmap
	{
		public string	LibraryPath = string.Empty;
		public FPPCommon.FuncRecognitionParam Param = new FPPCommon.FuncRecognitionParam();

		public FunctionalSignature() : base()
		{
		}

		public override SiGlaz.Recipes.Shape Copy()
		{
			SiGlaz.Recipes.Shape result = base.Copy();

			(result as FunctionalSignature).LibraryPath = this.LibraryPath;
            (result as FunctionalSignature).Param = this.Param.Clone();

			return result;
		}

		public override void Property()
		{
			SiGlaz.DDA.Framework.Automation.FunctionSignatureStep step = new SiGlaz.DDA.Framework.Automation.FunctionSignatureStep();
			step.LibraryPath = this.LibraryPath;
			step.Param = this.Param;
			using(SiGlaz.DDA.WinControls.Automation.FuncSigRecognizerDlg dlg = new SiGlaz.DDA.WinControls.Automation.FuncSigRecognizerDlg(step))
			{
				if( dlg.ShowDialog() == DialogResult.OK)
				{
					this.LibraryPath = step.LibraryPath;
					this.Param = step.Param;
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
				this.Param = SiGlaz.Common.XmlSerializeCommon.Deserialize(lpbyte,typeof(FPPCommon.FuncRecognitionParam)) as FPPCommon.FuncRecognitionParam;
			}
		}
		
//		private void Loadlibrary(DDAWorkingSpace working)
//		{
//			if( this.LibraryPath == string.Empty ) return;
//
//			if( !working.htFuncLibrary.ContainsKey(LibraryPath) )
//			{
//				try
//				{
//					working.htFuncLibrary.Add(LibraryPath,new SSA.Business.Facade.BFacadeTC.FuncLibManagement(LibraryPath,false));
//				}
//				catch
//				{
//					throw new Exception( string.Format("Invalid library path {0}",LibraryPath));
//				}
//			}
//		}

//		protected SignatureObjectParam SignatureParam=null;
		public override void Execute(WorkingSpace workingspace)
		{
			//base.Execute (workingspace);
			DDAWorkingSpace working = workingspace as DDAWorkingSpace;
			if(working.IsMulti) return;

			SSA.SystemFrameworks.KlarfParserFile map = working.ProcessMap;

			//Loadlibrary(working);
			//SSA.Business.Facade.BFacadeTC.FuncLibManagement lib = working.htFuncLibrary[LibraryPath] as SSA.Business.Facade.BFacadeTC.FuncLibManagement;
            //SSA.Business.Facade.BFacadeTC.FuncLibManagement lib 
            //    = new SSA.Business.Facade.BFacadeTC.FuncLibManagement(string.Empty, false);
            //FuncSignatureResultCollection fsc = lib.Recognize(map.m_DefectList.defectrecordarray, map.ShiftAngle, this.Param);

            FuncLibManagement lib = new FuncLibManagement(string.Empty, false);//no use lib file
            FuncSignatureResultCollection fsc = lib.Recognize(true,
                map.OriginalNumberOfDefectVirtual,
                map.m_DefectList.defectrecordarray,
                map.ShiftAngle,
                Param);

            if (fsc != null && fsc.Count > 0)
            {
                working.HaveResult = true;

                //Insert result into database and return;
                foreach (FuncSignatureResult fsr1 in fsc)
                {
                    if (fsr1.confidence_level * 100 < this.Param.Threshold) continue;
                    working.UpdateDefectList(fsr1.signature.Name, fsr1.signature.Defects);
                }
            }
		}


		public override bool ValidateSyntax(ref string msg)
		{
			//Not use library path
//			if( !System.IO.File.Exists(this.LibraryPath))
//			{
//				msg =  string.Format("Invalid library path {0}",this.LibraryPath);
//				return false;
//			}
			return base.ValidateSyntax(ref msg);
		}

		public override void Import(object obj)
		{
			if(obj==null) return;
			if(obj.GetType()!= typeof(SiGlaz.DDA.Framework.Automation.FunctionSignatureStep)) return;

			SiGlaz.DDA.Framework.Automation.FunctionSignatureStep desobj = obj as SiGlaz.DDA.Framework.Automation.FunctionSignatureStep;
			this.LibraryPath = desobj.LibraryPath;
			this.Param = desobj.Param;
		}

	}
}
