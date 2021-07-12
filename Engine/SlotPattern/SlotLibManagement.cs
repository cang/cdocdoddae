using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;


namespace SiGlaz.DDA.Engine.SlotPattern
{
	/// <summary>
	/// Summary description for LibManagement.
	/// </summary>
	public class SlotLibManagement
	{
		public ArrayList m_slot_library = new ArrayList();
		public bool change = false;
		private String m_LibRootPath;
		private String filelibrary;
		private bool m_bEnableMsgBox;

		public class SLOTLIB_FILEHEADER
		{
			public string sVersionInfo = "SlotSignatureLib 2.0";
			public int iNumColumn = 0; // unused in version 2.0: allow arbitrary number of slot
		};
		public SLOTLIB_FILEHEADER fileheader = new SLOTLIB_FILEHEADER();


		public string FilePath
		{
			get
			{
				return filelibrary;
			}
		}

		public ArrayList Library
		{
			get
			{
				return m_slot_library;
			}
			set
			{
				m_slot_library = value;
			}
		}

		/// <summary>
		/// Initial for Library !!!
		/// </summary>
		/// <param name="appPath">absolutely path of lib file </param>
		public SlotLibManagement(String LibPath, bool bEnableMsgBox)
		{
			m_bEnableMsgBox = bEnableMsgBox;
			filelibrary = LibPath;
			int pos=filelibrary.LastIndexOf("\\");
			if(pos>0)
				m_LibRootPath=filelibrary.Substring(0,pos);
			LoadLibrary20();
		}

		public SlotLibManagement(ArrayList m_slot_library)
		{
			this.m_slot_library=m_slot_library;
		}

		private void LoadLibrary10()
		{
			if (!File.Exists(filelibrary))
				return;

			FileStream fs = null;
			BinaryReader w = null;

			try
			{
				//FileStream fs = new FileStream(filelibrary, FileMode.Open);
				fs = File.Open(filelibrary,FileMode.Open,FileAccess.Read,FileShare.ReadWrite);

				w = new BinaryReader(fs);

				//Read file header
				SLOTLIB_FILEHEADER readedfileheader = new SLOTLIB_FILEHEADER();
				if (w.PeekChar() > -1)
				{
					readedfileheader.sVersionInfo = w.ReadString();
					readedfileheader.iNumColumn = w.ReadInt32();
					// Verify header
					if (readedfileheader.sVersionInfo != "SlotSignatureLib 1.0" || readedfileheader.iNumColumn != 25)
					{
						if (m_bEnableMsgBox)
							MessageBox.Show(filelibrary + " is not a valid Slot Signature Library file.",
								"Invalid Slot Signature Library", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						return;
					}
				}

				//Read every signature
				while (w.PeekChar() > -1)
				{
					SlotSignature signature = new SlotSignature();
					signature.Name = w.ReadString();
					signature.DateTimeString = w.ReadString();
					signature.id = w.ReadInt32();
					for(int a = 0; a < readedfileheader.iNumColumn; a++)
					{
						SlotElement element = new SlotElement(w.ReadInt32());
						signature.AddValue(element);
					}

					m_slot_library.Add(signature);
				}
			}
			catch
			{
			}
			finally
			{
				if(w!=null)
					w.Close();
				if(fs!=null)
					fs.Close();
			}
		}
		/*
				public void SaveLibrary10()
				{
					if(filelibrary==null) return;

					if(File.Exists(filelibrary) )
					{
						File.SetAttributes(filelibrary,FileAttributes.Normal);
						File.Delete(filelibrary);
					}

					FileStream fs = new FileStream(filelibrary, FileMode.Create);
					BinaryWriter w = new BinaryWriter(fs);

					w.Write(fileheader.sVersionInfo);
					w.Write(fileheader.iNumColumn);
					for(int k = 0; k <m_slot_library.Count; k++)
					{
						SlotSignature signature = (SlotSignature)m_slot_library[k];
						w.Write(signature.Name);
						w.Write(signature.DateTimeString);
						w.Write(signature.id);
						while (signature.Values.Count < fileheader.iNumColumn)
							signature.Values.Add(0);
						for(int a = 0; a < fileheader.iNumColumn; a++)
							w.Write((int)signature.Values[a]);
					}
					w.Close();
					fs.Close();
				}
		*/
		private void LoadLibrary20()
		{
			if (!File.Exists(filelibrary))
				return;

			FileStream fs = null;
			BinaryReader w = null;

			try
			{
				//FileStream fs = new FileStream(filelibrary, FileMode.Open);
				fs = File.Open(filelibrary,FileMode.Open,FileAccess.Read,FileShare.ReadWrite);

				w = new BinaryReader(fs);

				//Read file header
				if (w.PeekChar() > -1)
				{
					SLOTLIB_FILEHEADER readedfileheader = new SLOTLIB_FILEHEADER();
					readedfileheader.sVersionInfo = w.ReadString();
					readedfileheader.iNumColumn = w.ReadInt32();
					// Verify header
					if (readedfileheader.sVersionInfo != "SlotSignatureLib 2.0" || readedfileheader.iNumColumn != 0)
					{
						if (readedfileheader.sVersionInfo == "SlotSignatureLib 1.0" && readedfileheader.iNumColumn == 25)
						{
							w.Close();
							fs.Close();
							if (m_bEnableMsgBox)
								MessageBox.Show(filelibrary + " is Slot Signature Library version 1.0 and will be converted to Slot Signature Library version 2.0.",
									"Converting Slot Signature Library", MessageBoxButtons.OK, MessageBoxIcon.Information);
							LoadLibrary10();
							fileheader.sVersionInfo = "SlotSignatureLib 2.0";
							fileheader.iNumColumn = 0;
							change = true;
						}
						else if (m_bEnableMsgBox)
							MessageBox.Show(filelibrary + " is not a valid Slot Signature Library file.",
								"Invalid Slot Signature Library", MessageBoxButtons.OK, MessageBoxIcon.Stop);

						return;
					}
				}

				//Read every signature
				while (w.PeekChar() > -1)
				{
					SlotSignature signature = new SlotSignature();
					signature.Name = w.ReadString();
					signature.DateTimeString = w.ReadString();
					signature.id = w.ReadInt32();
					int numSlots = w.ReadInt32();
					for(int a = 0; a < numSlots; a++)
					{
						SlotElement element = new SlotElement(w.ReadInt32());
						signature.AddValue(element);
					}

					m_slot_library.Add(signature);
				}
			}
			catch
			{
			}
			finally
			{
				if(w!=null)
					w.Close();
				if(fs!=null)
					fs.Close();
			}
		}

		public void SaveLibrary20()
		{
			if(filelibrary==null) return;

			if(File.Exists(filelibrary) )
			{
				File.SetAttributes(filelibrary,FileAttributes.Normal);
				File.Delete(filelibrary);
			}

			FileStream fs = null;
			BinaryWriter w = null;
			try
			{
				fs = new FileStream(filelibrary, FileMode.Create);
				w = new BinaryWriter(fs);

				w.Write(fileheader.sVersionInfo);
				w.Write(fileheader.iNumColumn);
				for(int k = 0; k <m_slot_library.Count; k++)
				{
					SlotSignature signature = (SlotSignature)m_slot_library[k];
					w.Write(signature.Name);
					w.Write(signature.DateTimeString);
					w.Write(signature.id);
					w.Write(signature.Elements.Count);
					for(int a = 0; a < signature.Elements.Count; a++)
						w.Write(((SlotElement)signature.Elements[a]).m_value);
				}
			}
			catch
			{
			}
			finally
			{
				if(w!=null)
					w.Close();
				if(fs!=null)
					fs.Close();
			}
		}

		public void Recognize(SlotSignature realsig, SlotRecognitionParam param, ArrayList alResult)
		{
			foreach (SlotSignature sig in Library)
			{
				int iShift = 0;
				int correctness = realsig.CalculateCorrectness(sig, param, ref iShift);
				if (correctness >= param.Threshold && correctness > 0)
				{
					SlotRecognitionResult result = new SlotRecognitionResult();
					result.maxcorrect = correctness;
					result.category = sig.Name;
					result.signature= sig;
					result.iShift = iShift;
					//result.image = m_LibRootPath + "\\WaferMap" + sig.id.ToString() + ".gif";

					//tim xem trong mang co chua
					bool bExist = false;
					for (int j = 0; j < alResult.Count; j++)
					{
						SlotRecognitionResult resultj = (SlotRecognitionResult)alResult[j];
						if (result.category == resultj.category) // co roi: update maxcorrect, signature,...
						{
							bExist = true;
							if (resultj.maxcorrect < result.maxcorrect)
							{
								((SlotRecognitionResult)alResult[j]).maxcorrect = result.maxcorrect;
								((SlotRecognitionResult)alResult[j]).signature = result.signature;
							}
							break;
						}
					}
					if (bExist == false) // chua co: add
						alResult.Add(result);
				}
			}
			if( alResult!=null) alResult.Sort();
		}

		public void Predict(SlotSignature realsig, SlotRecognitionParam param, ArrayList alPredictedResult)
		{
			ArrayList alRecognizedResult = new ArrayList();
			Recognize(realsig, param, alRecognizedResult);
			if (alRecognizedResult.Count == 0)
				MessageBox.Show("There is no matched signature.", "Slot Signature Prediction", MessageBoxButtons.OK, MessageBoxIcon.Information);

			realsig.SuggestWaferIDPrefix();

			for (int i = alRecognizedResult.Count - 1; (i >= alRecognizedResult.Count - 3) && (i >= 0); i--)
			{
				SlotPredictionResult predictedResult = new SlotPredictionResult();
				predictedResult.recognizedResult = (SlotRecognitionResult)alRecognizedResult[i];
				predictedResult.predictedSig = realsig.Predict(predictedResult.recognizedResult.signature, param.method,
					predictedResult.recognizedResult.iShift);
				int iShift = 0;
				predictedResult.confidentAfterPredict = predictedResult.predictedSig.CalculateCorrectness(predictedResult.recognizedResult.signature, param, ref iShift);
				alPredictedResult.Add(predictedResult);
			}
		}

		public bool AttacthLibrary(SlotLibManagement desLib)
		{
			if(desLib==null || desLib.Library==null) return false;
			Library.Clear();
			for(int i=0;i<desLib.Library.Count;i++)
			{
				SlotSignature m_dactrung=(SlotSignature)desLib.Library[i];
				Library.Add(m_dactrung);
			}
			return true;
		}

		public void Export(string filelibrary)
		{
			if(filelibrary==null) return;

			if(File.Exists(filelibrary) )
			{
				File.SetAttributes(filelibrary,FileAttributes.Normal);
				File.Delete(filelibrary);
			}

			FileStream fs = null;
			BinaryWriter w = null;
			try
			{
				fs = new FileStream(filelibrary, FileMode.Create);
				w = new BinaryWriter(fs);

				w.Write(fileheader.sVersionInfo);
				w.Write(fileheader.iNumColumn);
				for(int k = 0; k <m_slot_library.Count; k++)
				{
					SlotSignature signature = (SlotSignature)m_slot_library[k];
					w.Write(signature.Name);
					w.Write(signature.DateTimeString);
					w.Write(signature.id);
					w.Write(signature.Elements.Count);
					for(int a = 0; a < signature.Elements.Count; a++)
						w.Write(((SlotElement)signature.Elements[a]).m_value);
				}
			}
			catch
			{
			}
			finally
			{
				if(w!=null)
					w.Close();
				if(fs!=null)
					fs.Close();
			}
		}
	}
}
