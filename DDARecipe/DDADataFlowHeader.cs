using System;
using System.IO;


namespace DDARecipe
{
	/// <summary>
	/// Summary description for DDADataFlowHeader.
	/// </summary>
	/// 
	[Serializable]
	public class DDADataFlowHeader
	{
		public string		LotIDCode = string.Empty;
		public string		LotID = string.Empty;
		public string		DiskID = string.Empty;
		public string		BinNum = string.Empty;
		public string		TestGrade = string.Empty;
		public short		SlotNum;
		public string		CassetteID = string.Empty;
		public string		StationID = string.Empty;
		public string		WordCellID = string.Empty;
		public string		DiskType = string.Empty;
		public string		FabID = string.Empty;
		public double		InnerDiameter ;
		public double		OuterDiameter ;

		public DateTime		TestDate;
		public SiGlaz.Common.DDA.eSurface	Surface;
		public int			NumberOfDefect;

		public DDADataFlowHeader()
		{
		}

		public void Serialize(System.IO.BinaryWriter stream)
		{
			stream.Write(this.DiskID);
			stream.Write(this.LotIDCode);
			stream.Write(this.LotID);
			stream.Write(this.TestGrade);
			stream.Write(this.BinNum);
			stream.Write(this.SlotNum);
			stream.Write(this.CassetteID);
			stream.Write(this.StationID);
			stream.Write(this.WordCellID);
			stream.Write(this.DiskType);
			stream.Write(this.FabID);
			stream.Write(this.InnerDiameter);
			stream.Write(this.OuterDiameter);
			stream.Write(this.TestDate.Ticks);
			stream.Write((byte)this.Surface);
			stream.Write(NumberOfDefect);
		}

		public void Deserialize(System.IO.BinaryReader stream)
		{
			this.DiskID = stream.ReadString();
			this.LotIDCode = stream.ReadString();
			this.LotID = stream.ReadString();
			this.TestGrade = stream.ReadString();
			this.BinNum = stream.ReadString();
			this.SlotNum = stream.ReadInt16();
			this.CassetteID = stream.ReadString();
			this.StationID = stream.ReadString();
			this.WordCellID = stream.ReadString();
			this.DiskType = stream.ReadString();
			this.FabID = stream.ReadString();
			this.InnerDiameter = stream.ReadDouble();
			this.OuterDiameter = stream.ReadDouble();
			this.TestDate = new DateTime(stream.ReadInt64());
			this.Surface = (SiGlaz.Common.DDA.eSurface)stream.ReadByte();
			this.NumberOfDefect = stream.ReadInt32();
		}


		public override string ToString()
		{
			return LotIDCode + "-" + DiskID + "-" + Surface.ToString();
		}


	}
}
