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
	public class KnnPercentFilter : SiGlaz.Recipes.NodeBitmap
	{
		private FPPCommon.KNNPercentParam Param = new FPPCommon.KNNPercentParam();

		public KnnPercentFilter() : base()
		{

		}

		public override SiGlaz.Recipes.Shape Copy()
		{
			SiGlaz.Recipes.Shape result = base.Copy();

			(result as KnnPercentFilter).Param = this.Param.Clone() as FPPCommon.KNNPercentParam;

			return result;
		}

		public override void Property()
		{
			using(SiGlaz.DDA.WinControls.Automation.DlgKNNPercent dlg = new SiGlaz.DDA.WinControls.Automation.DlgKNNPercent())
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
			byte[] lpbyte = SiGlaz.Common.XmlSerializeCommon.Serialize(this.Param);
			int count = lpbyte==null?0:lpbyte.Length;
			stream.Write(count);
			stream.Write(lpbyte,0,count);
		}

		public override void Deserialize(System.IO.BinaryReader stream, int versionnumber)
		{
			base.Deserialize (stream, versionnumber);
			int count = stream.ReadInt32();
			if(count>0)
			{
				byte[] lpbyte = stream.ReadBytes(count);
				this.Param = SiGlaz.Common.XmlSerializeCommon.Deserialize(lpbyte,typeof(FPPCommon.KNNPercentParam)) as FPPCommon.KNNPercentParam;
			}
		}

		public override void Execute(SiGlaz.Recipes.WorkingSpace workingspace)
		{
			//base.Execute (workingspace);
			DDAWorkingSpace working = workingspace as DDAWorkingSpace;
			if(working.IsMulti) return;
		
			KlarfParserFile map = working.ProcessMap;
			if(map == null) 
				return;

			FPPCommon.KNNPercentParam param = this.Param.Clone() as FPPCommon.KNNPercentParam;

			if(param.alClassNumber!=null && param.alClassNumber.Count==0)
				param.alClassNumber = null;

			SSA.SystemFrameworks.FrameworksDCDM.m_parserfile = map;
			working.OldEngine.KnnPercentFilter(ref param);
		}


		public override void Import(object obj)
		{
			if(obj==null) return;
			if(obj.GetType()!= typeof(SiGlaz.DDA.Framework.Automation.FilterByKnnPercentStep)) return;

			SiGlaz.DDA.Framework.Automation.FilterByKnnPercentStep desobj = obj as SiGlaz.DDA.Framework.Automation.FilterByKnnPercentStep;
			this.Param = desobj.KNNPercentParam;
		}

	}
}
