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
	public class ChannelFilter : SiGlaz.Recipes.NodeBitmap
	{
		private ArrayList	ChannelIDList = new ArrayList();
		private bool		Keep = true;

		public ChannelFilter() : base()
		{

		}

		public override SiGlaz.Recipes.Shape Copy()
		{
			SiGlaz.Recipes.Shape result = base.Copy();

			if( this.ChannelIDList!=null)
				(result as ChannelFilter).ChannelIDList = this.ChannelIDList.Clone() as ArrayList;

			(result as ChannelFilter).Keep = this.Keep;

			return result;
		}

		public override void Property()
		{
			using(SSA.KlarfViewCtrl.DlgChannelOptions dlg = new SSA.KlarfViewCtrl.DlgChannelOptions())
			{ 
				dlg.ucChannelOption1.ucChannelSelecttion1.InitData();
				dlg.ucChannelOption1.ucChannelSelecttion1.LoadData();

				dlg.ucChannelOption1.ucChannelSelecttion1.ChannelSelections  = this.ChannelIDList;
				dlg.ucChannelOption1.ucOuputOptions1.Keep = this.Keep;

				if( dlg.ShowDialog() == DialogResult.OK)
				{
					this.ChannelIDList = dlg.ucChannelOption1.ucChannelSelecttion1.ChannelSelections;
					this.Keep = dlg.ucChannelOption1.ucOuputOptions1.Keep;
				}

			}
		}

		
		public override void Serialize(System.IO.BinaryWriter stream)
		{
			base.Serialize (stream);
			stream.Write(this.Keep);
			int count = this.ChannelIDList==null?0:this.ChannelIDList.Count;
			stream.Write(count);
			for(int i=0;i<count;i++)
			{
				stream.Write((int)this.ChannelIDList[i]);
			}
		}

		public override void Deserialize(System.IO.BinaryReader stream, int versionnumber)
		{
			base.Deserialize (stream, versionnumber);
			this.Keep = stream.ReadBoolean();
			int count = stream.ReadInt32();
			for(int i=0;i<count;i++)
			{
				if(this.ChannelIDList==null)
					this.ChannelIDList = new ArrayList();
				this.ChannelIDList.Add(stream.ReadInt32());
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

			ChannelProcess process = new ChannelProcess(map);
			process.FilterByChannel(this.ChannelIDList,this.Keep);
		}

		public override bool ValidateSyntax(ref string msg)
		{
			if(this.ChannelIDList==null || this.ChannelIDList.Count<=0)
			{
				msg = "You must set Channel parameters.";
				return false;
			}

			return base.ValidateSyntax(ref msg);
		}

		public override void Import(object obj)
		{
			if(obj==null) return;
			if(obj.GetType()!= typeof(SiGlaz.DDA.Framework.Automation.FilterByChannelStep)) return;

			SiGlaz.DDA.Framework.Automation.FilterByChannelStep desobj = obj as SiGlaz.DDA.Framework.Automation.FilterByChannelStep;
			if(desobj.ChannelIDList!=null)
				this.ChannelIDList = desobj.ChannelIDList;
			this.Keep = desobj.Keep;
		}

	}
}
