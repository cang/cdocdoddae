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
	public class KnnMinMaxFilter : SiGlaz.Recipes.NodeBitmap
	{
		private FPPCommon.KNNMinMaxParam Param = new FPPCommon.KNNMinMaxParam();

		public KnnMinMaxFilter() : base()
		{
			Param.MinKDistance = 0;
			Param.MaxKDistance = 100000;
		}

		public override SiGlaz.Recipes.Shape Copy()
		{
			SiGlaz.Recipes.Shape result = base.Copy();

			(result as KnnMinMaxFilter).Param = this.Param.Clone() as FPPCommon.KNNMinMaxParam;

			return result;
		}

		public override void Property()
		{
			using(SiGlaz.DDA.WinControls.Automation.DlgKnnMinMax dlg = new SiGlaz.DDA.WinControls.Automation.DlgKnnMinMax())
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
				this.Param = SiGlaz.Common.XmlSerializeCommon.Deserialize(lpbyte,typeof(FPPCommon.KNNMinMaxParam)) as FPPCommon.KNNMinMaxParam;
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

			FPPCommon.KNNMinMaxParam param = this.Param.Clone() as FPPCommon.KNNMinMaxParam;

			if(param.alClassNumber!=null && param.alClassNumber.Count==0)
				param.alClassNumber = null;

			SSA.SystemFrameworks.FrameworksDCDM.m_parserfile = map;
			working.OldEngine.KnnMinMaxFilter(ref param);
		}


		public override void Import(object obj)
		{
			if(obj==null) return;
			if(obj.GetType()!= typeof(SiGlaz.DDA.Framework.Automation.FilterByKnnMinMaxStep)) return;

			SiGlaz.DDA.Framework.Automation.FilterByKnnMinMaxStep desobj = obj as SiGlaz.DDA.Framework.Automation.FilterByKnnMinMaxStep;
			this.Param = desobj.KnnMinMaxParam;
		}
	}
}
