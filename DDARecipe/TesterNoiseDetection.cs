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
	public class TesterNoiseDetection : NodeBitmap
	{
		#region Member Fields
		private FPPCommon.TesterNoiseParam _param = new TesterNoiseParam();
		#endregion

		#region Properties
		public FPPCommon.TesterNoiseParam Param
		{
			get { return _param; }
			set { _param = value; }
		}
		#endregion Properties

		public TesterNoiseDetection() : base()
		{
		}

		public override SiGlaz.Recipes.Shape Copy()
		{
			SiGlaz.Recipes.Shape result = base.Copy();

			(result as TesterNoiseDetection).Param = this.Param.Clone() as FPPCommon.TesterNoiseParam;

			return result;
		}

		public override void Property()
		{
			using(Dialogs.TesterNoiseDlg dlg = new Dialogs.TesterNoiseDlg())
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
			stream.Write(Param.ConfidenceThreshold);
			stream.Write(Param.MinNumberOfDefect);
			stream.Write(Param.Include);
		}

		public override void Deserialize(System.IO.BinaryReader stream, int versionnumber)
		{
			base.Deserialize (stream, versionnumber);
			if(versionnumber>=6)
			{
				this.Param.ConfidenceThreshold = stream.ReadDouble();
				this.Param.MinNumberOfDefect = stream.ReadInt32();
				this.Param.Include = stream.ReadBoolean();
			}
		}

		public override void Execute(WorkingSpace workingspace)
		{
			//base.Execute (workingspace);
			DDAWorkingSpace working = workingspace as DDAWorkingSpace;
			if(working.IsMulti) return;

			SSA.SystemFrameworks.KlarfParserFile map = working.ProcessMap;

			double confidentLevel = 0;
			SSA.Business.Facade.BFacadeTC.SpatialPatternDetection detector  = new SSA.Business.Facade.BFacadeTC.SpatialPatternDetection(map);
			ArrayList alDefect = detector.TesterNoiseAnalyzer(map,this.Param,ref confidentLevel);

			if (alDefect!=null && alDefect.Count>0)
			{
				map.ResetFlag(false);
				KlarfParserFile.SetFlag(alDefect,true);
				ArrayList alResult = map.GetByFlag(Param.Include);
				KlarfParserFile.SetFlag(alDefect,false);

				if(alResult!=null && alResult.Count>0)
				{
					working.HaveResult = true;
					working.UpdateDefectList(alResult);
				}
			}
		}

		public override void Import(object obj)
		{
			if(obj==null) return;
			if(obj.GetType()== typeof(SiGlaz.DDA.Framework.Automation.TesterNoiseDetectionStep)) 
			{
				SiGlaz.DDA.Framework.Automation.TesterNoiseDetectionStep desobj = obj as SiGlaz.DDA.Framework.Automation.TesterNoiseDetectionStep;
				this.Param = desobj.Param;
			}
			else if(obj.GetType()== typeof(SiGlaz.DDA.Framework.Automation.FilterByTesterNoiseStep)) 
			{
				SiGlaz.DDA.Framework.Automation.FilterByTesterNoiseStep desobj = obj as SiGlaz.DDA.Framework.Automation.FilterByTesterNoiseStep;
				this.Param = desobj.Param;
			}
		}

	}
}
