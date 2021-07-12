using System;
using System.Windows.Forms;
using System.Collections;

using SiGlaz.Common.DDA;
using SSA.SystemFrameworks;
using SSA.KlarfViewCtrl;


namespace DDARecipe
{
	/// <summary>
	/// Summary description for SwitchMode.
	/// </summary>
	public class RemoveDuplicateDefects : SiGlaz.Recipes.NodeBitmap
	{
        public short ClassNumber = -2;


		public RemoveDuplicateDefects() : base()
		{
		}

		public override SiGlaz.Recipes.Shape Copy()
		{
			SiGlaz.Recipes.Shape result = base.Copy();
            (result as RemoveDuplicateDefects).ClassNumber = this.ClassNumber;
			return result;
		}
	
		public override void Serialize(System.IO.BinaryWriter stream)
		{
			base.Serialize (stream);
            stream.Write(ClassNumber);
		}

		public override void Deserialize(System.IO.BinaryReader stream, int versionnumber)
		{
			base.Deserialize (stream, versionnumber);
            ClassNumber = stream.ReadInt16();
		}

        public override void Property()
        {
            using (RemoveDefectDlg dlg = new RemoveDefectDlg())
            {
                dlg.ClassNumber = this.ClassNumber;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.ClassNumber = dlg.ClassNumber;
                }
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

            //<param name="ClassNum"> -2 = min, -1=max, 0,1,2 ...</param>
            map.RemoveDoublicateByRadiusAngle(ClassNumber);
		}

        public override void Import(object obj)
        {
            if (obj == null) return;
            if (obj.GetType() != typeof(SiGlaz.DDA.Framework.Automation.RemoveDuplicateDefectStep)) return;

            SiGlaz.DDA.Framework.Automation.RemoveDuplicateDefectStep  desobj = obj as SiGlaz.DDA.Framework.Automation.RemoveDuplicateDefectStep;
            this.ClassNumber = desobj.ClassNumber;
        }

	}
}
