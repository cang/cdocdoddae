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
	/// 
	[NodeNextRule(false)]
	[NodeNextRule(true,typeof(Decision))]
	public class HeaderOption : NodeBitmap
	{
		FPPCommon.FilterObjectParam param = new FilterObjectParam();

		public HeaderOption() : base()
		{
		}

		public override SiGlaz.Recipes.Shape Copy()
		{
			SiGlaz.Recipes.Shape result = base.Copy();

			if(this.param!=null)
				(result as HeaderOption).param = this.param.Clone() as FPPCommon.FilterObjectParam;

			return result;
		}

		public override void Serialize(System.IO.BinaryWriter stream)
		{
			base.Serialize (stream);

			stream.Write((byte)param.typeQuery);
			stream.Write(param.strQuery);
		}

		public override void Deserialize(System.IO.BinaryReader stream, int versionnumber)
		{
			base.Deserialize (stream, versionnumber);

			param.typeQuery = (FPPCommon.QUERY_TYPE)stream.ReadByte();
			param.strQuery = stream.ReadString();
		}

		public override void Property()
		{
			using(SSA.KlarfViewCtrl.OptionsSelectionDlg dlg = new SSA.KlarfViewCtrl.OptionsSelectionDlg(1))
			{ 
				dlg.Text = "Select Disk/Surface Header Condition";
				dlg.UseOrAnd = param.typeQuery == FPPCommon.QUERY_TYPE.OR;
				dlg.unverControl.ConditionExpression  = param.strQuery;
				if( dlg.ShowDialog() == DialogResult.OK)
				{
					param.typeQuery = dlg.UseOrAnd?FPPCommon.QUERY_TYPE.OR:FPPCommon.QUERY_TYPE.AND;
					param.strQuery = dlg.unverControl.ConditionExpression;
				}
			}
		}
		
		public override void Execute(WorkingSpace workingspace)
		{
			//base.Execute (workingspace);
			DDAWorkingSpace working = workingspace as DDAWorkingSpace;
			if(working.IsMulti) return;

			SSA.SystemFrameworks.KlarfParserFile map = working.ProcessMap;

			SSA.KlarfViewCtrl.OptionsSelectionrFieldDoc process = new SSA.KlarfViewCtrl.OptionsSelectionrFieldDoc();
			if(param.typeQuery== FPPCommon.QUERY_TYPE.OR)
			{
				working.Selection = process.CheckORANDCondition(SSA.KlarfViewCtrl.OptionsSelectionrFieldDoc.ParseSimple_OR_AND_Clause(param.strQuery),map,1,0);
			}
			else
			{
				working.Selection = process.CheckANDORCondition(SSA.KlarfViewCtrl.OptionsSelectionrFieldDoc.ParseSimple_AND_OR_Clause(param.strQuery),map,1,0);

			}
		}

//		public override void Import(object obj)
//		{
//			if(obj==null) return;
//			if(obj.GetType()!= typeof(SiGlaz.DDA.Framework.Automation.SpiralSignatureStep)) return;
////			SiGlaz.DDA.Framework.Automation.SpiralSignatureStep desobj = obj as SiGlaz.DDA.Framework.Automation.SpiralSignatureStep;
////			this.LibraryPath = desobj.LibraryPath;
////			this.Param = desobj.Param;
//		}

	}
}
