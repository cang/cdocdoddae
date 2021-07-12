using System;

namespace SiGlaz.DDA.Engine.SlotPattern
{
	/// <summary>
	/// Summary description for SlotRecognitionResult.
	/// </summary>
	public class SlotRecognitionResult : IComparable
	{
		public int maxcorrect = 0;
		public string category = "";
		public SlotSignature signature;
		public int iShift = 0;

		public int CompareTo(object obj) 
		{
			if(obj is SlotRecognitionResult) 
			{
				SlotRecognitionResult temp = (SlotRecognitionResult) obj;
				return maxcorrect - temp.maxcorrect;
			}
			throw new ArgumentException("object is not a SlotRecognitionResult");
		}

		public SlotRecognitionResult()
		{
		}
	}

}
