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
	public class UnlinkDefect : SiGlaz.Recipes.NodeBitmap
	{
		public UnlinkDefect() : base()
		{
		}

		public override SiGlaz.Recipes.Shape Copy()
		{
			SiGlaz.Recipes.Shape result = base.Copy();
			return result;
		}
	
		public override void Serialize(System.IO.BinaryWriter stream)
		{
			base.Serialize (stream);
		}

		public override void Deserialize(System.IO.BinaryReader stream, int versionnumber)
		{
			base.Deserialize (stream, versionnumber);
		}

		public override void Execute(SiGlaz.Recipes.WorkingSpace workingspace)
		{
			//base.Execute (workingspace);
			DDAWorkingSpace working = workingspace as DDAWorkingSpace;
			if(working.IsMulti) return;
		
			KlarfParserFile map = working.ProcessMap;
			if(map == null) 
				return;

			working.OldEngine.LinkDefectUnlink(map);
		}

	}
}
