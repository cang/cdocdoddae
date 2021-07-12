using System;
using System.Windows.Forms;
using System.Collections;

using SiGlaz.Common.DDA;
using SSA.SystemFrameworks;


namespace DDARecipe
{
	/// <summary>
	/// Summary description for SwitchMode.
	/// </summary>
	public class LinkDefect : SiGlaz.Recipes.NodeBitmap
	{
		public FPPCommon.LinkDefectParam Param = new FPPCommon.LinkDefectParam();

		public LinkDefect() : base()
		{

		}

		public override SiGlaz.Recipes.Shape Copy()
		{
			SiGlaz.Recipes.Shape result = base.Copy();

			(result as LinkDefect).Param = this.Param.Clone() as FPPCommon.LinkDefectParam;

			return result;
		}

		public override void Property()
		{
			using(SiGlaz.DDA.WinControls.Automation.LinkDefectDlg dlg = new SiGlaz.DDA.WinControls.Automation.LinkDefectDlg())
			{ 
				dlg.Data = this.Param;
				if( dlg.ShowDialog() == DialogResult.OK)
				{
					this.Param = dlg.Data;
				}
			}
		}

		
		public override void Serialize(System.IO.BinaryWriter stream)
		{
			base.Serialize (stream);

			stream.Write(this.Param.LimitDefectCount);
			stream.Write(this.Param.Proximity);
		}

		public override void Deserialize(System.IO.BinaryReader stream, int versionnumber)
		{
			base.Deserialize (stream, versionnumber);

			this.Param.LimitDefectCount = stream.ReadInt32();
			this.Param.Proximity = stream.ReadSingle();
		}

		public override void Execute(SiGlaz.Recipes.WorkingSpace workingspace)
		{
			//base.Execute (workingspace);
			DDAWorkingSpace working = workingspace as DDAWorkingSpace;
			if(working.IsMulti) return;
		
			KlarfParserFile map = working.ProcessMap;
			if(map == null) 
				return;

			working.OldEngine.LinkDefectProcess(map,this.Param);
		}

		public override void Import(object obj)
		{
			if(obj==null) return;
			if(obj.GetType()!= typeof(SiGlaz.DDA.Framework.Automation.LinkDefectStep)) return;

			SiGlaz.DDA.Framework.Automation.LinkDefectStep desobj = obj as SiGlaz.DDA.Framework.Automation.LinkDefectStep;
			this.Param = desobj.LinkDefectParam;
		}

	}
}
