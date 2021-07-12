using System;
using System.Windows.Forms;
using System.Collections;

using SiGlaz.Common.DDA;
using DDARecipe;
using DDARecipe.Dialogs;

using SSA.SystemFrameworks;

namespace DDARecipe
{
	/// <summary>
	/// Summary description for CategoryFilter.
	/// </summary>
	public class ResultFilter: SiGlaz.Recipes.NodeBitmap
	{
		public eOutputType	Param = eOutputType.Keep;
		public bool			ClearResult = true;

		public ResultFilter(): base()
		{
		}

		public override SiGlaz.Recipes.Shape Copy()
		{
			SiGlaz.Recipes.Shape result = base.Copy();

			(result as ResultFilter).Param = this.Param;
			(result as ResultFilter).ClearResult = this.ClearResult;

			return result;
		}

		public override void Property()
		{
			DlgResultFilter dlg = new DlgResultFilter();
			dlg.Param = this.Param;
			dlg.chkClearResult.Checked = this.ClearResult;
			if( dlg.ShowDialog() == DialogResult.OK)
			{
				this.Param = dlg.Param;
				this.ClearResult = dlg.chkClearResult.Checked;
			}
		}

		public override void Serialize(System.IO.BinaryWriter stream)
		{
			base.Serialize (stream);
			stream.Write((int)Param);
			stream.Write(ClearResult);
		}

		public override void Deserialize(System.IO.BinaryReader stream, int versionnumber)
		{
			base.Deserialize (stream, versionnumber);
			Param = (eOutputType)stream.ReadInt32();
			if(versionnumber>=3)
				this.ClearResult = stream.ReadBoolean();
		}

		public override void Execute(SiGlaz.Recipes.WorkingSpace workingspace)
		{
			//base.Execute (workingspace);
			DDAWorkingSpace working = workingspace as DDAWorkingSpace;
			if(working.IsMulti) return;


			ArrayList alDefects = new ArrayList();
			if(working.Results!=null)
			{
				foreach(ResultItem item in working.Results)
				{
					if(item.ResultMultilayer!=null) continue;
					alDefects.AddRange(item.ResultMap.m_DefectList.defectrecordarray);
				}
			}

/*
			//Copy Result into ProcessMap
			if (Param == eOutputType.Keep)
			{
				working.ProcessMap.m_DefectList.defectrecordarray.Clear();
				working.ProcessMap.AddDefectsList(alDefects);
			}
			else
			{
				KlarfParserFile subobj = working.ProcessMap.CopyHeader();
				subobj.AddDefectsList(alDefects);
				working.ProcessMap = working.ProcessMap.Sub(subobj, KLARFCriterion.ByDefectID, float.Epsilon);
			}
*/

			//This code will wrong because Defect was clone in Zonal, ... processing
			working.ProcessMap.ResetFlag(false);
			KlarfParserFile.SetFlag(alDefects,true);
			alDefects = working.ProcessMap.GetByFlag(Param == eOutputType.Keep);
			working.ProcessMap.ResetFlag(false);

			working.ProcessMap.m_DefectList.defectrecordarray.Clear();
			working.ProcessMap.AddDefectsList(alDefects);

			//Clear result
			if(this.ClearResult && working.Results!=null)
			{
				working.Results.Clear();
				working.Results = null;
			}

		}

	}
}
