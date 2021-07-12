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
	public class SpiralSignature : NodeBitmap
	{
        #region Member Fields
        public FuncRecognitionParam Param = new FuncRecognitionParam();
        #endregion


		public SpiralSignature() : base()
		{
		}

		public override SiGlaz.Recipes.Shape Copy()
		{
			SiGlaz.Recipes.Shape result = base.Copy();
            (result as SpiralSignature).Param = this.Param.Clone();
			return result;
		}

        public override void Serialize(System.IO.BinaryWriter stream)
        {
            base.Serialize(stream);

            byte[] lpbyte = SiGlaz.Common.XmlSerializeCommon.Serialize(this.Param);
            int count = lpbyte == null ? 0 : lpbyte.Length;
            stream.Write(count);
            stream.Write(lpbyte, 0, count);

        }

        public override void Deserialize(System.IO.BinaryReader stream, int versionnumber)
        {
            base.Deserialize(stream, versionnumber);

            int count = stream.ReadInt32();
            if (count > 0)
            {
                byte[] lpbyte = stream.ReadBytes(count);
                this.Param = SiGlaz.Common.XmlSerializeCommon.Deserialize(lpbyte, typeof(FuncRecognitionParam)) as FuncRecognitionParam;
            }
        }

        public override void Property()
        {
            SiGlaz.DDA.Framework.Automation.SpiralSignatureStep param = new SiGlaz.DDA.Framework.Automation.SpiralSignatureStep();
            param.Param = this.Param;
            using (SiGlaz.DDA.WinControls.Automation.SpiralRecognizerDlg dlg = new SiGlaz.DDA.WinControls.Automation.SpiralRecognizerDlg(param))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //Auto update
                }
            }
        }
		
		public override void Execute(WorkingSpace workingspace)
		{
			//base.Execute (workingspace);
			DDAWorkingSpace working = workingspace as DDAWorkingSpace;
			if(working.IsMulti) return;

			SSA.SystemFrameworks.KlarfParserFile map = working.ProcessMap;

            SpiralFuncSignatureCollection fsc = SmoothLineTracer.DetectSpiral(
                    map.OriginalNumberOfDefectVirtual,
                    Param,
                    map.m_DefectList.defectrecordarray,
                    map.ShiftAngle);

			if (fsc != null && fsc.Count >  0)
			{
				working.HaveResult = true;

				//Insert result into database and return;
				foreach (SpiralFuncSignature fsr1 in fsc)
				{
					working.UpdateDefectList(fsr1.Name,fsr1.Defects);
				}
			}
		}

        public override void Import(object obj)
        {
            if (obj == null) return;
            if (obj.GetType() != typeof(SiGlaz.DDA.Framework.Automation.SpiralSignatureStep)) return;

            SiGlaz.DDA.Framework.Automation.SpiralSignatureStep desobj = obj as SiGlaz.DDA.Framework.Automation.SpiralSignatureStep;
            this.Param = desobj.Param;
        }

	}
}
