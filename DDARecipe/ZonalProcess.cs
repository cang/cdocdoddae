using System;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using SiGlaz.Recipes;
using SSA.Business.Facade.FacadeDCDM.ZonalAnalysis;


namespace DDARecipe
{
	/// <summary>
	/// Summary description for ZonalProcess.
	/// </summary>
	public class ZonalProcess: NodeBitmap
	{
		public SSA.Business.Facade.FacadeDCDM.ZonalAnalysis.ZonalGroup ZonalGroup = new ZonalGroup();
		public string	FilePath = string.Empty;

		public ZonalProcess() : base()
		{

		}

		public override SiGlaz.Recipes.Shape Copy()
		{
			SiGlaz.Recipes.Shape result = base.Copy();

			(result as ZonalProcess).FilePath = this.FilePath;
			
			if(this.ZonalGroup!=null)
				(result as ZonalProcess).ZonalGroup = this.ZonalGroup.Clone() as SSA.Business.Facade.FacadeDCDM.ZonalAnalysis.ZonalGroup;

			return result;
		}

		public override void Property()
		{
			SiGlaz.DDA.Framework.Automation.ZonalStep zonalstep = new SiGlaz.DDA.Framework.Automation.ZonalStep();
			zonalstep.ZonalGroup = this.ZonalGroup;
			zonalstep.FileName = this.FilePath;

			using(SiGlaz.DDA.WinControls.Automation.DlgZoneAnalyzer dlg = new SiGlaz.DDA.WinControls.Automation.DlgZoneAnalyzer(zonalstep))
			{
				if(dlg.ShowDialog()== DialogResult.OK)
				{
					this.ZonalGroup = zonalstep.ZonalGroup;
					this.FilePath = zonalstep.FileName;
				}
			}
		}

		public override void Serialize(System.IO.BinaryWriter stream)
		{
			base.Serialize (stream);

			stream.Write(this.FilePath);

			//ZonalData
			MemoryStream ms = null;
			StreamWriter sw = null;
			try
			{
				ms = new MemoryStream();
				sw = new StreamWriter(ms,ZonalGroup.DefaultEncoding);
				this.ZonalGroup.Serialize(sw);
				sw.Flush();

				byte []lpbyte  = ms.ToArray();
				stream.Write(lpbyte.Length);
				stream.Write(lpbyte);
			}
			catch
			{
				if(sw!=null)
				{
					sw.Close();
					sw = null;
				}
				if(ms!=null)

				{
					ms.Close();
					ms = null;
				}
			}
		}

		public override void Deserialize(System.IO.BinaryReader stream, int versionnumber)
		{
			base.Deserialize (stream, versionnumber);

			this.FilePath = stream.ReadString();

			//ZonalData
			MemoryStream ms = null;
			StreamReader sr = null;
			try
			{
				int nb = stream.ReadInt32();
				byte []lpbyte = stream.ReadBytes(nb);

				ms = new MemoryStream(lpbyte);
				sr = new StreamReader(ms,ZonalGroup.DefaultEncoding);
				this.ZonalGroup.Deserialize(sr);
			}
			catch
			{
				if(sr!=null)
				{
					sr.Close();
					sr = null;
				}
				if(ms!=null)

				{
					ms.Close();
					ms = null;
				}
			}
		}

		public override void Execute(WorkingSpace workingspace)
		{
			//base.Execute (workingspace);
			DDAWorkingSpace working = workingspace as DDAWorkingSpace;
			if(working.IsMulti) return;

			SSA.SystemFrameworks.KlarfParserFile map = working.ProcessMap;

			ZonalGroup process = this.ZonalGroup.Clone() as ZonalGroup;
			SSA.SystemFrameworks.KlarfParserFile zonalmap = process.Analyze(map);

			/*          
			//This code will wrong because Defect was clone in Zonal, ... processing
			working.ProcessMap.ResetFlag(false);
			KlarfParserFile.SetFlag(alDefects,true);
			alDefects = working.ProcessMap.GetByFlag(Param == eOutputType.Keep);
			working.ProcessMap.ResetFlag(false);

			working.ProcessMap.m_DefectList.defectrecordarray.Clear();
			working.ProcessMap.AddDefectsList(alDefects);
			*/


			if(zonalmap!=null && zonalmap.defectcount>0)
			{
				//GET ORIGINAL DEFECT WAS CLONE BY ZONAL ANALYZER
				ArrayList alDefID = zonalmap.GetDefectIDList();
				ArrayList alDef = map.GetDefectList(alDefID);
				alDefID.Clear(); alDefID = null;

				working.HaveResult = true;
				working.UpdateDefectList(alDef);
				//working.UpdateDefectList(zonalmap.m_DefectList.defectrecordarray);
			}

		}

		public override void Import(object obj)
		{
			if(obj==null) return;
			if(obj.GetType()== typeof(SiGlaz.DDA.Framework.Automation.FilterByZonalStep)) 
			{
				SiGlaz.DDA.Framework.Automation.FilterByZonalStep desobj = obj as SiGlaz.DDA.Framework.Automation.FilterByZonalStep;
				this.FilePath = desobj.FileName;
				if(desobj.ZonalGroup !=null)
					this.ZonalGroup = desobj.ZonalGroup;
			}
			else if(obj.GetType()== typeof(SiGlaz.DDA.Framework.Automation.ZonalStep)) 
			{
				SiGlaz.DDA.Framework.Automation.ZonalStep desobj = obj as SiGlaz.DDA.Framework.Automation.ZonalStep;
				this.FilePath = desobj.FileName;
				if(desobj.ZonalGroup!=null)
					this.ZonalGroup = desobj.ZonalGroup;
			}
		}


		
		public override bool ValidateSyntax(ref string msg)
		{
			if(this.ZonalGroup==null)
			{
				msg =  "ZonalGroup is null.";
				return false;
			}

			if(this.ZonalGroup.Zonals==null || this.ZonalGroup.Zonals.Count<=0)
			{
				msg =  "Zonal is empty.";
				return false;
			}

			return base.ValidateSyntax(ref msg);
		}

	}
}
