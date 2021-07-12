using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;

namespace SiGlaz.DDA.Engine.SlotPattern
{
	public class PHASE 
	{
		public enum TYPE { up, down, hor };
		public TYPE type;
		public int count;

		public PHASE(TYPE t, int c) { type = t; count = c; }
	};

	public class PhaseVector
	{
		public ArrayList data = new ArrayList();
		public PHASE this[int i]
		{
			get { return (PHASE)data[i]; }
			set { data[i] = value; }
		}
		public int Count
		{
			get { return data.Count; }
		}
	};

	public class SlotSignature
	{
		private string m_name;
		private string m_datetime;
		private ArrayList m_elements = new ArrayList();
		public int id;

		public enum SORTED_BY
		{
			None=0,
			SlotID,
			WaferID
		}
		public SORTED_BY sorted_by = SORTED_BY.SlotID;

		public string m_WaferIDPrefix = "";
		public string m_WaferIDSuffix = "";

		public int actual_slot = -1;
		// Constructor
		// Input:
		// int numcolumn: number of column in Slot (currently 25)
		public SlotSignature()
		{
		}

		public SlotSignature(SlotSignature src)
		{
			m_name = src.m_name; m_datetime = src.m_datetime; id = src.id; actual_slot = src.actual_slot;
			sorted_by = src.sorted_by;
			m_WaferIDPrefix = src.m_WaferIDPrefix; m_WaferIDSuffix = src.m_WaferIDSuffix;
			for (int i = 0; i < src.Elements.Count; i++)
			{
				SlotElement e_src = (SlotElement)src.Elements[i];
				SlotElement e = new SlotElement(e_src.m_value, e_src.stringToSort, e_src.intToSort, e_src.isPredictedSlot);
				Elements.Add(e);
			}
		}

		public string Name
		{
			get
			{
				return m_name;
			}
			set
			{
				m_name = value;
			}
		}
		public string DateTimeString
		{
			get
			{
				return m_datetime;
			}
			set
			{
				m_datetime = value;
			}
		}
		public ArrayList Elements
		{
			get
			{
				return m_elements;
			}
			set
			{
				m_elements = value;
			}
		}
		public int ActualSlot
		{
			get
			{
				if (actual_slot == -1)
				{
					actual_slot = 0;
					for (int i = 0; i < Elements.Count; i++)
					{
						if (((SlotElement)Elements[i]).m_value >= 0)
							actual_slot ++;
					}
				}

				return actual_slot;
			}
		}

		public void AddValue(SlotElement val)
		{
			m_elements.Add((SlotElement)val);
		}































































































































		public int LParse(string s)
		{
			string stmp = "";
			for (int i = 0; i < s.Length; i++)
			{
				if (char.IsNumber(s,i))
					stmp += s[i];
			}
			int ret = 0;
			try
			{
				ret = int.Parse(stmp);
			}
			catch
			{
			}
			return ret;
		}
		public void SuggestWaferIDPrefix()
		{
			m_WaferIDPrefix = "";
			if (Elements == null || Elements.Count == 0) return;

			string s = ((SlotElement)Elements[Elements.Count-1]).stringToSort;
			int len = s.Length;
			int n = 2;
			if (s[len-1] == '\"')
			{
				n = 3; m_WaferIDSuffix = "\"";
			}

			if (len <= n) return;

			m_WaferIDPrefix = ((SlotElement)Elements[Elements.Count-1]).stringToSort.Substring(0, len - n);
		}
		public void SortandFillbySlotID()
		{
			SortElementsByInt();
			SuggestWaferIDPrefix();
			for (int i = Elements.Count - 2; i >= 0; i--)
			{
				for (int slotid = ((SlotElement)Elements[i+1]).intToSort - 1; slotid > ((SlotElement)Elements[i]).intToSort; slotid--)
				{
					SlotElement insertElement = new SlotElement(-1, m_WaferIDPrefix + slotid.ToString() + m_WaferIDSuffix, slotid);
					Elements.Insert(i+1, insertElement);
				}
			}
			sorted_by = SORTED_BY.SlotID;
		}
		public void SortandFillbyWaferID()
		{
			SortElements();
			SuggestWaferIDPrefix();
			for (int i = Elements.Count - 2; i >= 0; i--)
			{
				int i1waferid = LParse(((SlotElement)Elements[i]).stringToSort);
				int i2waferid = LParse(((SlotElement)Elements[i+1]).stringToSort);
				for (int iwaferid = i2waferid - 1; iwaferid > i1waferid; iwaferid--)
				{
					SlotElement insertElement = new SlotElement(-1, m_WaferIDPrefix + iwaferid.ToString() + m_WaferIDSuffix, iwaferid);
					Elements.Insert(i+1, insertElement);
				}
			}
			sorted_by = SORTED_BY.WaferID;
		}

		private void SortElements()
		{
			ArrayList alSorted = new ArrayList();
			foreach (SlotElement element in Elements)
			{
				bool bInserted = false;
				for (int i = 0; i < alSorted.Count; i++)
				{
					if (element.CompareTo(alSorted[i]) < 0)
					{
						alSorted.Insert(i, element);
						bInserted = true;
						break;
					}
				}
				if (bInserted == false)
					alSorted.Add(element);
			}
			Elements = alSorted;
		}
		private void SortElementsByInt()
		{
			ArrayList alSorted = new ArrayList();
			foreach (SlotElement element in Elements)
			{
				bool bInserted = false;
				for (int i = 0; i < alSorted.Count; i++)
				{
					if (element.intToSort < ((SlotElement)alSorted[i]).intToSort)
					{
						alSorted.Insert(i, element);
						bInserted = true;
						break;
					}
				}
				if (bInserted == false)
					alSorted.Add(element);
			}
			Elements = alSorted;
		}

		#region unused sort
		/*
				public void SortElements(string sortby)
				{
					if (sortby == "Inspector_ID") SortByInspector_ID();
					else if (sortby == "Inspector_Model") SortByInspector_Model();
					else if (sortby == "Inspector_Equipment") SortByInspector_Equipment();
					else if (sortby == "Lot_ID") SortByLot_ID();
					else if (sortby == "Setup_ID") SortBySetup_ID();
					else if (sortby == "Step_ID") SortByStep_ID();
					else if (sortby == "Device_ID") SortByDevice_ID();
					else if (sortby == "Slot_ID") SortBySlot_ID();
					else if (sortby == "Wafer_ID") SortByWafer_ID();
					else if (sortby == "Inspector_Model") SortByInspector_Model();
				}
				private void SortByInspector_ID()
				{
					ArrayList alSorted = new ArrayList();
					foreach (SlotElement element in Elements)
					{
						bool bInserted = false;
						for (int i = 0; i < alSorted.Count; i++)
						{
							if (element.Inspector_ID < ((SlotElement)alSorted[i]).Inspector_ID)
							{
								alSorted.Insert(i, element);
								bInserted = true;
								break;
							}
						}
						if (bInserted == false)
							alSorted.Add(element);
					}
					Elements = alSorted;
				}
				private void SortByInspector_Model()
				{
					ArrayList alSorted = new ArrayList();
					foreach (SlotElement element in Elements)
					{
						bool bInserted = false;
						for (int i = 0; i < alSorted.Count; i++)
						{
							if (element.Inspector_Model < ((SlotElement)alSorted[i]).Inspector_Model)
							{
								alSorted.Insert(i, element);
								bInserted = true;
								break;
							}
						}
						if (bInserted == false)
							alSorted.Add(element);
					}
					Elements = alSorted;
				}
				private void SortByInspector_Equipment()
				{
					ArrayList alSorted = new ArrayList();
					foreach (SlotElement element in Elements)
					{
						bool bInserted = false;
						for (int i = 0; i < alSorted.Count; i++)
						{
							if (element.Inspector_Equipment < ((SlotElement)alSorted[i]).Inspector_Equipment)
							{
								alSorted.Insert(i, element);
								bInserted = true;
								break;
							}
						}
						if (bInserted == false)
							alSorted.Add(element);
					}
					Elements = alSorted;
				}
				private void SortByLot_ID()
				{
					ArrayList alSorted = new ArrayList();
					foreach (SlotElement element in Elements)
					{
						bool bInserted = false;
						for (int i = 0; i < alSorted.Count; i++)
						{
							if (element.Lot_ID < ((SlotElement)alSorted[i]).Lot_ID)
							{
								alSorted.Insert(i, element);
								bInserted = true;
								break;
							}
						}
						if (bInserted == false)
							alSorted.Add(element);
					}
					Elements = alSorted;
				}
				private void SortBySetup_ID()
				{
					ArrayList alSorted = new ArrayList();
					foreach (SlotElement element in Elements)
					{
						bool bInserted = false;
						for (int i = 0; i < alSorted.Count; i++)
						{
							if (element.Setup_ID < ((SlotElement)alSorted[i]).Setup_ID)
							{
								alSorted.Insert(i, element);
								bInserted = true;
								break;
							}
						}
						if (bInserted == false)
							alSorted.Add(element);
					}
					Elements = alSorted;
				}
				private void SortByStep_ID()
				{
					ArrayList alSorted = new ArrayList();
					foreach (SlotElement element in Elements)
					{
						bool bInserted = false;
						for (int i = 0; i < alSorted.Count; i++)
						{
							if (element.Step_ID < ((SlotElement)alSorted[i]).Step_ID)
							{
								alSorted.Insert(i, element);
								bInserted = true;
								break;
							}
						}
						if (bInserted == false)
							alSorted.Add(element);
					}
					Elements = alSorted;
				}
				private void SortByDevice_ID()
				{
					ArrayList alSorted = new ArrayList();
					foreach (SlotElement element in Elements)
					{
						bool bInserted = false;
						for (int i = 0; i < alSorted.Count; i++)
						{
							if (element.Device_ID < ((SlotElement)alSorted[i]).Device_ID)
							{
								alSorted.Insert(i, element);
								bInserted = true;
								break;
							}
						}
						if (bInserted == false)
							alSorted.Add(element);
					}
					Elements = alSorted;
				}
				private void SortBySlot_ID()
				{
					ArrayList alSorted = new ArrayList();
					foreach (SlotElement element in Elements)
					{
						bool bInserted = false;
						for (int i = 0; i < alSorted.Count; i++)
						{
							if (element.Slot_ID < ((SlotElement)alSorted[i]).Slot_ID)
							{
								alSorted.Insert(i, element);
								bInserted = true;
								break;
							}
						}
						if (bInserted == false)
							alSorted.Add(element);
					}
					Elements = alSorted;
				}
				private void SortByWafer_ID()
				{
					ArrayList alSorted = new ArrayList();
					foreach (SlotElement element in Elements)
					{
						bool bInserted = false;
						for (int i = 0; i < alSorted.Count; i++)
						{
							if (element.Wafer_ID < ((SlotElement)alSorted[i]).Wafer_ID)
							{
								alSorted.Insert(i, element);
								bInserted = true;
								break;
							}
						}
						if (bInserted == false)
							alSorted.Add(element);
					}
					Elements = alSorted;
				}/**/
		#endregion

		/*		public int CalculateCorrectness(SlotSignature sig)
				{
					ArrayList normalthis = NormalizeValues();
					ArrayList normalthat = sig.NormalizeValues();

					if (normalthis.Count == 0)
						return 0;
					if (normalthis.Count != normalthat.Count)
						return 0;

					float diff = 0;
					float di;
					for (int i = 0; i < normalthis.Count; i++)
					{
						di = (float)normalthis[i] - (float)normalthat[i];
						diff += di*di;
					}
					diff = (float)Math.Sqrt(diff);

					if (diff > 100) diff = 100;

					return (int)(100 - diff);
				}
				/**/

		public ArrayList CalVaryRule_bk(bool bIgnoreMissingSlot)
		{
			ArrayList alRet = new ArrayList();

			int pre_val = ((SlotElement)Elements[0]).m_value;
			for (int i = 1; i < Elements.Count; i++)
			{
				int cur_val = ((SlotElement)Elements[i]).m_value;

				if (cur_val < 0) continue;
				// 				{
				// 					if (bIgnoreMissingSlot) continue;
				// 					else cur_val = 0;
				// 				}
				
				if (cur_val > pre_val)
				{
					if (alRet.Count == 0) alRet.Add((int)1);
					else
					{
						int pre_phase = (int)alRet[alRet.Count-1];
						if (pre_phase > 0) alRet[alRet.Count-1] = pre_phase + 1;
						else
						{
							alRet.Add((int)1);
						}
					}
				}
				else if (cur_val < pre_val)
				{
					if (alRet.Count == 0) alRet.Add((int)-1);
					else
					{
						int pre_phase = (int)alRet[alRet.Count-1];
						if (pre_phase < 0) alRet[alRet.Count-1] = pre_phase - 1;
						else
						{
							alRet.Add((int)-1);
						}
					}
				}
				else
				{
					if (alRet.Count == 0) alRet.Add((int)0);
					else
					{
						int pre_phase = (int)alRet[alRet.Count-1];
						if (pre_phase != 0) alRet.Add((int)0); // should add multi 0 to support n-in-1 pattern!!! Or modify correctness calculation algorithm
					}
				}

				pre_val = cur_val;
			}

			return alRet;
		}

		public PhaseVector CalVaryRule(bool bIgnoreMissingSlot)
		{
			PhaseVector alRet = new PhaseVector();

			int pre_val = ((SlotElement)Elements[0]).m_value;
			for (int i = 1; i < Elements.Count; i++)
			{
				int cur_val = ((SlotElement)Elements[i]).m_value;

				if (cur_val < 0) continue;
				// 				{
				// 					if (bIgnoreMissingSlot) continue;
				// 					else cur_val = 0;
				// 				}
				
				if (cur_val > pre_val)
				{
					if (alRet.Count > 0 && alRet[alRet.Count-1].type == PHASE.TYPE.up)
						(alRet[alRet.Count-1] as PHASE).count++;
						//alRet[alRet.Count-1].count++;
					else
						alRet.data.Add(new PHASE(PHASE.TYPE.up, 1));
				}
				else if (cur_val < pre_val)
				{
					if (alRet.Count > 0 && alRet[alRet.Count-1].type == PHASE.TYPE.down)
						alRet[alRet.Count-1].count++;
					else
						alRet.data.Add(new PHASE(PHASE.TYPE.down, 1));
				}
				else
				{
					if (alRet.Count > 0 && alRet[alRet.Count-1].type == PHASE.TYPE.hor)
						alRet[alRet.Count-1].count++;
					else
						alRet.data.Add(new PHASE(PHASE.TYPE.hor, 1));
				}

				pre_val = cur_val;
			}

			return alRet;
		}

		private int _CalculateCorrectnessByPhase(SlotSignature sig, SlotRecognitionParam param, ref int ibestshift)
		{
			PhaseVector varysmall = CalVaryRule(param.bIgnoreMissingSlot);
			PhaseVector varybig = sig.CalVaryRule(param.bIgnoreMissingSlot);
			if (varysmall.Count > varybig.Count)
			{
				PhaseVector tmpal = varybig;
				varybig = varysmall;
				varysmall = tmpal;
			}

			float confident;
			float max_confident = 0;
			ibestshift = 0;
			for (int ishift= 0; ishift < varybig.Count; ishift++)
			{
				int diff = 0;
				int sum = 0;
				//int actual_matching = 0;
				for (int ielement = 0; ielement < varysmall.Count; ielement++)
				{
					if (varysmall[ielement].type == varybig[(ishift + ielement) % varybig.Count].type)
						diff += Math.Abs(varysmall[ielement].count - varybig[(ishift + ielement) % varybig.Count].count);
					else
						diff += varysmall[ielement].count + varybig[(ishift + ielement) % varybig.Count].count;
					sum += varysmall[ielement].count + varybig[(ishift + ielement) % varybig.Count].count;
					//actual_matching ++;


				}
				if (sum == 0) confident = 100;
				else confident = (sum - diff)*100/sum;
				confident = confident * varysmall.Count/varybig.Count;
				if (confident < 0) confident = 0;
				else if (confident > 100) confident = 100;

				if (confident > max_confident)
				{
					max_confident = confident;
					ibestshift = ishift;
				}

				if (!param.bShift) break;
			}

			return (int)max_confident;
		}

		public ArrayList NormalizeValues(bool bIgnoreMissingSlot)
		{
			float missing_val = -1;
			//			if (!bIgnoreMissingSlot) missing_val = 0;

			ArrayList alRet = new ArrayList();
			int sum = 0;
			foreach (SlotElement element in Elements)
			{
				if (element.m_value >= 0)
					sum += element.m_value;
			}

			if (sum > 0)
			{
				foreach (SlotElement element in Elements)
				{
					if (element.m_value >= 0)
						alRet.Add((float)(element.m_value*100.0/sum));
					else
						alRet.Add(missing_val);
				}
			}
			else
			{
				foreach (SlotElement element in Elements)
				{
					if (element.m_value >= 0)
						alRet.Add((float)0);
					else
						alRet.Add(missing_val);
				}
			}

			return alRet;
		}

		public ArrayList NormalizeValues(int i1, int i2, bool bIgnoreMissingSlot)
		{
			float missing_val = -1;
			//			if (!bIgnoreMissingSlot) missing_val = 0;

			ArrayList alRet = new ArrayList();
			int sum = 0;
			for (int i = i1; i <= i2; i++)
			{
				int val = ((SlotElement)Elements[i % Elements.Count]).m_value;
				if (val >= 0)
					sum += val;
			}

			if (sum > 0)
			{
				for (int i = i1; i <= i2; i++)
				{
					int val = ((SlotElement)Elements[i % Elements.Count]).m_value;
					if (val >= 0)
						alRet.Add((float)(val*100.0/sum));
					else
						alRet.Add(missing_val);
				}
			}
			else
			{
				foreach (SlotElement element in Elements)
				{
					if (element.m_value >= 0)
						alRet.Add((float)0);
					else
						alRet.Add(missing_val);
				}
			}

			return alRet;
		}

		public int CalculateCorrectness(SlotSignature sig, SlotRecognitionParam param, ref int ibestshift)
		{
			if (param.method == SlotRecognitionParam.METHOD.byRule)
				return _CalculateCorrectnessByPhase(sig, param, ref ibestshift);

			int confidentByPhase = 0;
			if (param.method == SlotRecognitionParam.METHOD.byBoth)
				confidentByPhase = _CalculateCorrectnessByPhase(sig, param, ref ibestshift);

			SlotSignature sigbig, sigsmall;
			if (Elements.Count > sig.Elements.Count)
			{
				sigbig = this;
				sigsmall = sig;
			}
			else
			{
				sigbig = sig;
				sigsmall = this;
			}

			if (sigsmall.Elements.Count == 0)
				return 0;

			int actual_max = Math.Max(this.ActualSlot, sig.ActualSlot);

			ArrayList normalsmall = sigsmall.NormalizeValues(param.bIgnoreMissingSlot);

			float confident;
			float max_confident = 0;
			ibestshift = 0;
			for (int ishift= 0; ishift < sigbig.Elements.Count; ishift++)
			{
				ArrayList normalbig = sigbig.NormalizeValues(ishift, ishift + sigsmall.Elements.Count-1, param.bIgnoreMissingSlot); //DTL: Should normalize the whole big pattern?
				float diff = 0;
				float di;
				int actual_matching = 0;
				for (int ielement = 0; ielement < normalsmall.Count; ielement++)
				{
					if ((float)normalsmall[ielement] >= 0 && (float)normalbig[ielement] >= 0)
					{
						di = (float)normalsmall[ielement] - (float)normalbig[ielement];
						diff += di*di;
						actual_matching ++;
					}
				}
				diff = (float)Math.Sqrt(diff);
				//confident = param.bIgnoreMissingSlot?(100 - diff):(100 - diff)*actual_matching/actual_max;
				confident = (100 - diff)*actual_matching/actual_max;
				if (confident < 0) confident = 0;

				if (confident > max_confident)
				{
					max_confident = confident;
					ibestshift = ishift;
				}

				if (!param.bShift) break;
			}

			if (param.method == SlotRecognitionParam.METHOD.byBoth)
			{
				max_confident = (max_confident + confidentByPhase)/2;
			}

			return (int)max_confident;
		}

		public SlotSignature Shift(int iShift)
		{
			SlotSignature result = new SlotSignature();
			result.m_name = m_name; result.m_datetime = m_datetime; result.id = id; result.actual_slot = actual_slot;
			
			for (int i = 0; i < Elements.Count; i++)
			{
				result.Elements.Add(Elements[(iShift + i) % Elements.Count]);
			}
			return result;
		}

		public SlotSignature Predict(SlotSignature src, SlotRecognitionParam.METHOD method, int iShift)
		{
			SlotSignature srcShift = src.Shift(iShift);
			return (method == SlotRecognitionParam.METHOD.byValue)?_PredictByAmplitude(srcShift):_PredictByPhase(srcShift);
		}

		private SlotSignature _PredictByAmplitude(SlotSignature src)
		{
			SlotSignature result = new SlotSignature(this);

			// Tim min, max
			int minI = -1, maxI = -1, minR = -1, maxR = -1;
			for (int i = 0; i < Math.Min(src.Elements.Count, Elements.Count); i++)
			{
				int Ii = (Elements[i] as SlotElement).m_value;
				if (Ii < 0) continue; // don't remove this because it affects below.

				if (minI == -1 || minI > Ii) minI = Ii;
				if (maxI < Ii) maxI = Ii;

				int Ri = (src.Elements[i] as SlotElement).m_value;
				if (minR == -1 || minR > Ri) minR = Ri;
				if (maxR < Ri) maxR = Ri;
			}

			// initial = special value for special case minR == maxR
			float k = 1;
			int vbase = (minI + maxI)/2;

			if (maxR > minR)
			{
				k = (maxI - minI)/(maxR - minR);
				vbase = minI;
			}

			// Calculate predicted values
			for (int i = 0; i < src.Elements.Count; i++)
			{
				if ((src.Elements[i] as SlotElement).m_value < 0) continue;

				int v = vbase + (int)(((src.Elements[i] as SlotElement).m_value - minR) * k);
				if (v < 0) v = 0;

				if (i >= Elements.Count) // missing slot outside
				{
					SlotElement newElement = new SlotElement(v, m_WaferIDPrefix + ((int)(i + 1)).ToString() + m_WaferIDSuffix, i + 1, true);
					result.Elements.Add(newElement);
				}
				else if ((Elements[i] as SlotElement).m_value < 0) // missing slot inside
				{
					(result.Elements[i] as SlotElement).m_value = v;
					(result.Elements[i] as SlotElement).isPredictedSlot = true;
				}
			}

			return result;
		}

		private void _PredictEndByPhase(SlotSignature src, int start, float k, SlotSignature result)
		{
			if (start < 0) return;

			for (int i = start + 1; i < src.Elements.Count; i++)
			{
				int v = (src.Elements[i] as SlotElement).m_value - (src.Elements[i - 1] as SlotElement).m_value;
				v = (result.Elements[i - 1] as SlotElement).m_value + (int)(v * k + 0.5f);
				if (v < 0) v = 0;
				SlotElement newElement = new SlotElement(v, m_WaferIDPrefix + ((int)(i + 1)).ToString() + m_WaferIDSuffix, i + 1, true);
				result.Elements.Add(newElement);
			}
		}

		private void _PredictSegmentByPhase(SlotSignature src, int start, int end, float k, SlotSignature result)
		{
			if (end <= start + 1) return;

			// < truong hop start==-1 hoac end==count ...>
			int Rstart = (src.Elements[start] as SlotElement).m_value, Rend = (src.Elements[end] as SlotElement).m_value;
			int Istart = (Elements[start] as SlotElement).m_value, Iend = (Elements[end] as SlotElement).m_value;

			int minI = Math.Min(Istart, Iend);
			int maxI = Math.Max(Istart, Iend);
			int minR = Math.Min(Rstart, Rend);
			int maxR = Math.Max(Rstart, Rend);

			// 			float k = 1f;
			// 			if (minR < maxR)
			// 				k = (maxI - minI)/(maxR - minR);

			int v = 0;
			int m = (start + end)/2;
			int Rm = (src.Elements[m] as SlotElement).m_value;
			if (Rm > minR && Rm < maxR)
				v = Istart + (int)(k*(Rm - Rstart) + 0.5f);
			else if (Rm < minR)
				v = minI + (Rm - minR);
			else if (Rm > maxR)
				v = maxI + (Rm - maxR);
			else if (Rm == Rstart) // so sanh Rstart truoc Rend vi Rm luon co kha nang ga^`n Rstart hon do phep la^'y pha^`n nguye^n
				v = Istart;
			else
				v = Iend;

			if (v < 0) v = 0;
			(result.Elements[m] as SlotElement).m_value = v;
			(result.Elements[m] as SlotElement).isPredictedSlot = true;

			_PredictSegmentByPhase(src, start, m, k, result);
			_PredictSegmentByPhase(src, m, end, k, result);
		}

		private SlotSignature _PredictByPhase(SlotSignature src)
		{
			// Tim min, max
			int minI = -1, maxI = -1, minR = -1, maxR = -1;
			for (int i = 0; i < Math.Min(src.Elements.Count, Elements.Count); i++)
			{
				int Ri = (src.Elements[i] as SlotElement).m_value;
				if (Ri >= 0)
				{
					if (minR == -1 || minR > Ri) minR = Ri;
					if (maxR < Ri) maxR = Ri;
				}

				int Ii = (Elements[i] as SlotElement).m_value;
				if (Ii >= 0)
				{
					if (minI == -1 || minI > Ii) minI = Ii;
					if (maxI < Ii) maxI = Ii;
				}
			}

			float k = 1;
			if (minR < maxR)
				k = (maxI - minI)/(maxR - minR);

			SlotSignature result = new SlotSignature(this);

			bool bPrevSlot = true;
			int start = -1;
			int end = src.Elements.Count;
			for (int i = 0; i < src.Elements.Count; i++)
			{
				//Find gaps
				if (i >= Elements.Count || (Elements[i] as SlotElement).m_value < 0) // missing slot
				{
					if (bPrevSlot) 
					{
						start = i-1; bPrevSlot = false;
					}
				}
				else
				{
					if (!bPrevSlot) 
					{
						end = i; bPrevSlot = true;
						_PredictSegmentByPhase(src, start, end, k, result);
					}
				}
			}

			if (!bPrevSlot)
				_PredictEndByPhase(src, start, k, result);

			return result;
		}

		public void DrawThumpnail(Graphics g)
		{
			SolidBrush m_brush = new SolidBrush(Color.White);
			Pen m_pen = new Pen(Color.Green,1);

			g.Clear(Color.White);

			g.ResetClip();
			g.DrawRectangle(m_pen,0,0,199,199);

			//Draw X-Y Axis
			m_pen.Width = 2;
			m_pen.Color = Color.Blue;
			int x0 = 20, y0 = 20;
			int w = 160;
			g.DrawLine(m_pen, x0, 200-y0, x0+w, 200-y0);
			g.DrawLine(m_pen, x0, 200-y0, x0, 200-(y0+w));

			//Draw Graph
			int rMark = 2;
			m_pen.Color = Color.Red;
			ArrayList normalizeval = NormalizeValues(true);
			if (normalizeval.Count > 0)
			{
				int xprev = x0, yprev = 200 - (int)(y0 + (float)normalizeval[0]); //first point is never missed, so its value is always >= 0
				int x = xprev, y = yprev;
				g.DrawRectangle(m_pen, xprev - rMark, yprev - rMark, rMark+rMark, rMark+rMark);
				for (int i = 1; i < normalizeval.Count; i++)
				{
					x = x0 + (int)(i*100/normalizeval.Count);
					y = ((float)normalizeval[i] >= 0)? 200 - (int)(y0 + (float)normalizeval[i]) : -1;
					if (yprev >= 0 && y >= 0)
						g.DrawLine(m_pen, xprev, yprev, x, y);
					else
					{
						if (yprev >= 0)
							g.DrawRectangle(m_pen, xprev - rMark, yprev - rMark, rMark+rMark, rMark+rMark);
						else if (y >= 0)
							g.DrawRectangle(m_pen, x - rMark, y - rMark, rMark+rMark, rMark+rMark);
					}
					xprev = x; yprev = y;
				}
				g.DrawRectangle(m_pen, x - rMark, y - rMark, rMark+rMark, rMark+rMark);
			}
			m_pen.Dispose();
			m_brush.Dispose();
		}

		public Bitmap DrawThumpnailToBitmap()
		{
			Bitmap bmp=new Bitmap(200,200,PixelFormat.Format24bppRgb);
			Graphics g=Graphics.FromImage(bmp);
			DrawThumpnail(g);
			g.Dispose();
			return bmp;
		}

	}

}

