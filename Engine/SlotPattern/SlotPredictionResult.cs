using System;

namespace SiGlaz.DDA.Engine.SlotPattern
{
	/// <summary>
	/// Summary description for SlotPredictionResult.
	/// </summary>
	public class SlotPredictionResult
	{
		public SlotRecognitionResult recognizedResult;
		public SlotSignature predictedSig;
		public int confidentAfterPredict = 0;

		public SlotPredictionResult()
		{
		}
	}
}
