using System;

namespace SiGlaz.DDA.Engine.SlotPattern
{
	/// <summary>
	/// Summary description for SlotRecognitionParam.
	/// </summary>
	public class SlotRecognitionParam
	{
		public enum METHOD
		{
			byValue=0,
			byRule,
			byBoth
		}

		public int Threshold;
		public bool bShift;
		public bool bIgnoreMissingSlot;
		public METHOD method;

		public SlotRecognitionParam()
		{
		}
	}

}
