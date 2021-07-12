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
	public class SwitchMode : SiGlaz.Recipes.NodeBitmap
	{
		public SSA.SystemFrameworks.MRSProcessingType	Mode = SSA.SystemFrameworks.MRSProcessingType.DiscMode;
		public float									Angle;
		public float									Ratio;

		public SwitchMode() : base()
		{

		}

		public override SiGlaz.Recipes.Shape Copy()
		{
			SiGlaz.Recipes.Shape result = base.Copy();

			(result as SwitchMode).Mode = this.Mode;
			(result as SwitchMode).Angle = this.Angle;
			(result as SwitchMode).Ratio = this.Ratio;

			return result;
		}

		public override void Property()
		{
			SiGlaz.DDA.Framework.Automation.SwitchModeStep stepobj = new SiGlaz.DDA.Framework.Automation.SwitchModeStep();
			stepobj.Mode = this.Mode;
			stepobj.Angle = this.Angle;
			stepobj.Ratio = this.Ratio;

			using(SiGlaz.DDA.WinControls.Automation.DlgSwitchMode dlg = new SiGlaz.DDA.WinControls.Automation.DlgSwitchMode(stepobj))
			{ 
				if( dlg.ShowDialog() == DialogResult.OK)
				{
					this.Mode = stepobj.Mode;
					this.Angle = stepobj.Angle;
					this.Ratio = stepobj.Ratio;
				}
			}
		}
	
		public override void Serialize(System.IO.BinaryWriter stream)
		{
			base.Serialize (stream);
			stream.Write((byte)Mode);
			stream.Write(Angle);
			stream.Write(Ratio);
		}

		public override void Deserialize(System.IO.BinaryReader stream, int versionnumber)
		{
			base.Deserialize (stream, versionnumber);
			this.Mode = (SSA.SystemFrameworks.MRSProcessingType)stream.ReadByte();
			this.Angle = stream.ReadSingle();
			if(versionnumber>=4)
				this.Ratio = stream.ReadSingle();
		}

		public override void Execute(SiGlaz.Recipes.WorkingSpace workingspace)
		{
			//base.Execute (workingspace);
			DDAWorkingSpace working = workingspace as DDAWorkingSpace;
			if(working.IsMulti) return;
		
			KlarfParserFile map = working.ProcessMap;
			if(map == null) 
				return;

			SSA.SystemFrameworks.InMemmoryData.mrsProcessingMode = this.Mode;
			SSA.SystemFrameworks.InMemmoryData.mrsShiftAngle = this.Angle;
			SSA.SystemFrameworks.InMemmoryData.HorVerRatio  = this.Ratio;


			if( this.Mode == MRSProcessingType.DiscMode )
				map.TranPolarFromOrigin();
			else
				map.TranCartesianFromOrigin(this.Angle,this.Ratio);
		}

		public override void Import(object obj)
		{
			if(obj==null) return;
			if(obj.GetType()!= typeof(SiGlaz.DDA.Framework.Automation.SwitchModeStep)) return;

			SiGlaz.DDA.Framework.Automation.SwitchModeStep desobj = obj as SiGlaz.DDA.Framework.Automation.SwitchModeStep;
			this.Mode = desobj.Mode;
			this.Angle = desobj.Angle;
			this.Ratio = desobj.Ratio;
		}
	}
}
