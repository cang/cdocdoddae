using System;
using System.Windows.Forms;
using System.Drawing;
using SiGlaz.Common.DDA;


namespace DDARecipe
{
	/// <summary>
	/// Summary description for OutputDB.
	/// </summary>
	public class OutputSignature: Output
	{
		public Signature	Signature = new Signature();

		public bool			ClearResult = true;

		public OutputSignature(): base()
		{
		}

		public override SiGlaz.Recipes.Shape Copy()
		{
			SiGlaz.Recipes.Shape result = base.Copy();

			(result as OutputSignature).Signature = this.Signature.Copy();
			(result as OutputSignature).ClearResult = this.ClearResult;

			return result;
		}

		public override void Property()
		{
			Dialogs.DlgOutputSignature dlg = new Dialogs.DlgOutputSignature();
			dlg.Signature = this.Signature;
			dlg.chkClearResult.Checked = this.ClearResult;

			if( dlg.ShowDialog() == DialogResult.OK)
			{
				Signature sig = dlg.Signature  as Signature;
				if(sig!=null)
					this.Signature = sig;

				this.ClearResult = dlg.chkClearResult.Checked;
			}
		}
		
		public override void Serialize(System.IO.BinaryWriter stream)
		{
			base.Serialize (stream);

			stream.Write(Signature.SCKey);
			stream.Write(Signature.SignatureID);

			stream.Write(Signature.SignatureName);

			stream.Write(ClearResult);
		}

		public override void Deserialize(System.IO.BinaryReader stream, int versionnumber)
		{
			base.Deserialize (stream, versionnumber);

			if(versionnumber>=5)
			{
				this.Signature.SCKey  = stream.ReadInt32();
				this.Signature.SignatureID = stream.ReadInt32();
			}

			this.Signature.SignatureName = stream.ReadString();

			if(versionnumber>=2)
				this.ClearResult = stream.ReadBoolean();
		}

		public override void Execute(SiGlaz.Recipes.WorkingSpace workingspace)
		{
			DDAWorkingSpace working = workingspace as DDAWorkingSpace;

			if(working.Results!=null)// && working.Results.Count==1)
			{
				foreach(ResultItem item in working.Results)
				{
					item.SignatureID = this.Signature.SCKey;
					item.SignatureCode = this.Signature.SignatureID;
					item.SignatureName = this.Signature.SignatureName;
				}
			}
			base.Execute(workingspace);//Insert data

			if(working.NoConnectToDatabase)
			{
				return;
			}

			//Clear result
			if(this.ClearResult && working.Results!=null)
			{
				working.Results.Clear();
				working.Results = null;
			}

		}

	}
}
