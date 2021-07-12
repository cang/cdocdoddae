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
	public class LinkDefectFilter : SiGlaz.Recipes.NodeBitmap
	{
		public FPPCommon.LinkDefectEnumOption Param = new FPPCommon.LinkDefectEnumOption();

		public LinkDefectFilter() : base()
		{

		}

		public override SiGlaz.Recipes.Shape Copy()
		{
			SiGlaz.Recipes.Shape result = base.Copy();

			(result as LinkDefectFilter).Param = this.Param;

			return result;
		}

		public override void Property()
		{
			using(SiGlaz.DDA.WinControls.Automation.LinkDefectFilterDlg dlg = new SiGlaz.DDA.WinControls.Automation.LinkDefectFilterDlg())
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
			stream.Write((int)this.Param);
		}

		public override void Deserialize(System.IO.BinaryReader stream, int versionnumber)
		{
			base.Deserialize (stream, versionnumber);
			this.Param = (FPPCommon.LinkDefectEnumOption)stream.ReadInt32();
		}

		public override void Execute(SiGlaz.Recipes.WorkingSpace workingspace)
		{
			//base.Execute (workingspace);
			DDAWorkingSpace working = workingspace as DDAWorkingSpace;
			if(working.IsMulti) return;
		
			KlarfParserFile map = working.ProcessMap;
			if(map == null) 
				return;

			working.OldEngine.LinkDefectFilter(map,this.Param);
		}


		public override void Import(object obj)
		{
			if(obj==null) return;
			if(obj.GetType()!= typeof(SiGlaz.DDA.Framework.Automation.LinkDefectFilterStep)) return;

			SiGlaz.DDA.Framework.Automation.LinkDefectFilterStep desobj = obj as SiGlaz.DDA.Framework.Automation.LinkDefectFilterStep;
			this.Param = desobj.Param;
		}

	}
}
