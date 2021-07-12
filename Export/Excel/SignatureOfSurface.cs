using System;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Globalization;
using System.Collections;
using System.Drawing;
using SpreadsheetGear;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Basic;
using SiGlaz.Common.DDA.Recipe;
using SiGlaz.Common.DDA.Result;
using SiGlaz.Common.DDA.Const;
using SiGlaz.Utility;
using SiGlaz.DAL;
using SiGlaz.DDA.Business;
using System.Data.SqlClient;

namespace SiGlaz.Export.Excel
{
	public class SignatureOfSurface
	{
		#region Members
		private SingleLayerRecipe _input = null;
		private CultureInfo _currentCultural = System.Threading.Thread.CurrentThread.CurrentCulture;
		private string _tempDir = string.Format("{0}\\temp", Application.StartupPath);
		private int _rowCount = 0;
		private int _pageCount = 0;
		private int _maxSignatureCount = 0;
		private ViewMode _viewMode = ViewMode.Disk;
		private ExportType _exportType = ExportType.DataAndImage;
		private ConnectionParam _param = new ConnectionParam();
		private SiGlaz.DDA.Business.SingleLayer _singleLayerQuery = null;
		private SiGlaz.DDA.Business.SingleLayer _singleLayerQuery2 = null;
		private SiGlaz.DDA.Business.Source _sourceQuery = null;
		private string _sqlWhere = string.Empty;
		#endregion

		#region Constructor
		public SignatureOfSurface(SingleLayerRecipe input, ViewMode viewMode, ExportType exportType, string sqlWhere)
		{
			_input = input;
			_viewMode = viewMode;
			_exportType = exportType;
			_sqlWhere = sqlWhere;

			_param.Server = AppData.Data.ServerName;
			_param.Database = AppData.Data.DatabaseName;
			_param.Username = AppData.Data.UserName;
			RijndaelCrypto crypto = new RijndaelCrypto();
			_param.Password = crypto.Decrypt(AppData.Data.Password);
			_singleLayerQuery = new SiGlaz.DDA.Business.SingleLayer(_param);
			_sourceQuery = new Source(_param);
		}
		#endregion

		#region Public Methods
		public bool Export2Excel(string fileName, ref string error)
		{
			bool result = true;
			Cursor.Current = Cursors.WaitCursor;

			GetMaxSignatureCount2();

			if (_exportType == ExportType.DataAndImage)
			{
				if (SiGlaz.Utility.Utility.CreateDirectory(_tempDir, ref error))
					result = Export2ExcelWithImage(fileName, ref error);
			}
			else
			{
				_singleLayerQuery2 = new SiGlaz.DDA.Business.SingleLayer(_param);
				result = Export2ExcelWithoutImage(fileName, ref error);
			}

			return result;
		}

		private bool Export2ExcelWithImage(string fileName, ref string error)
		{
			bool result = true;
			IWorkbook workBook = SpreadsheetGear.Factory.GetWorkbook();

			try
			{
				SetCulturalWithEN_US();
				InitHeader(workBook.Worksheets[0]);
				FillData(workBook.Worksheets[0]);
				workBook.SaveAs(fileName, SpreadsheetGear.FileFormat.XLS97);
			}
			catch (Exception e)
			{
				result = false;
				error = e.Message;
			}
			finally
			{
				SetCulturalWithCurrent();
				workBook.Close();
				workBook = null;
				SiGlaz.Utility.Utility.DeleteDirectory(_tempDir);
			}

			return result;
		}

		private bool Export2ExcelWithoutImage(string fileName, ref string error)
		{
			bool result = true;
			SqlDataReader reader = null;
			StreamWriter sw = null;			

			try
			{
				sw = new StreamWriter(fileName, false);

				//Add Headers
				for (int i = 1; i <= _maxSignatureCount; i++)
					sw.Write(string.Format("Signature {0},", i));

				for (int i = 0; i < _input.TableLayout.DisplayColumns.Length; i++)
				{
					sw.Write(_input.TableLayout.DisplayColumns[i]);
					if (i < _input.TableLayout.DisplayColumns.Length - 1) sw.Write(",");
				}
				
				sw.Write(sw.NewLine);

				//Add All Rows
				reader = _singleLayerQuery.GetSurfaceHasSignatureAllWithReader(_input);
				if (reader == null) return result;
				long currentSurfaceKey = 0;
				long surfaceKey = 0;
				int signatureCount = 0;
				int colCount = reader.FieldCount;
				ArrayList values = new ArrayList();

				if (!reader.Read()) return true;
				currentSurfaceKey = Convert.ToInt64(reader.GetValue(0));
				for (int i = 3; i < colCount; i++)
					values.Add(reader.GetValue(i));

				signatureCount++;
				string signatureName = reader.GetValue(reader.GetOrdinal("SignatureName")).ToString();
				int grade = 0;

				if (!reader.IsDBNull(reader.GetOrdinal("Grade")))
				{
					grade = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Grade")));
					signatureName = string.Format("{0}-{1}", grade, signatureName);
				}

				sw.Write(string.Format("{0},", signatureName));

				while(true)
				{
					if (!reader.Read())
					{
						if (signatureCount < _maxSignatureCount)
						{
							for (int i = 0; i < _maxSignatureCount - signatureCount; i++)
								sw.Write(",");
						}

						for (int i = 0; i < values.Count; i++)
						{
							if (values[i] != null && values[i] != DBNull.Value)
								sw.Write(values[i].ToString());
	
							if (i < values.Count - 1) sw.Write(",");
						}

						return true; 
					}

					surfaceKey = Convert.ToInt64(reader.GetValue(0));
					
					if (currentSurfaceKey != surfaceKey)
					{
						if (signatureCount < _maxSignatureCount)
						{
							for (int i = 0; i < _maxSignatureCount - signatureCount; i++)
								sw.Write(",");
						}

						for (int i = 0; i < values.Count; i++)
						{
							if (values[i] != null && values[i] != DBNull.Value)
								sw.Write(values[i].ToString());
	
							if (i < values.Count - 1) sw.Write(",");
						}

						sw.Write(sw.NewLine);

						signatureCount = 0;
						currentSurfaceKey = surfaceKey;
						values.Clear();
						for (int i = 3; i < colCount; i++)
							values.Add(reader.GetValue(i));
					}
	
					signatureCount++;
					signatureName = reader.GetValue(reader.GetOrdinal("SignatureName")).ToString();
					grade = 0;

					if (!reader.IsDBNull(reader.GetOrdinal("Grade")))
					{
						grade = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Grade")));
						signatureName = string.Format("{0}-{1}", grade, signatureName);
					}

					sw.Write(string.Format("{0},", signatureName));
				}
			}
			catch (System.Exception e)
			{
				result = false;
				error = e.Message;
			}
			finally
			{
				if (reader != null)
				{
					reader.Close();
					reader = null;
				}

				if (sw != null)
				{
					sw.Close();
					sw = null;
				}

				_singleLayerQuery.CloseCurrentConnection();
				_singleLayerQuery2.CloseCurrentConnection();
			}

			return result;
		}

		private bool Export2ExcelWithoutImage2(string fileName, ref string error)
		{
			bool result = true;
			SqlDataReader reader1 = null;
			SqlDataReader reader2 = null;
			StreamWriter sw = null;			

			try
			{
				sw = new StreamWriter(fileName, false);

				//Add Headers
				for (int i = 1; i <= _maxSignatureCount; i++)
					sw.Write(string.Format("Signature {0},", i));

				for (int i = 0; i < _input.TableLayout.DisplayColumns.Length; i++)
				{
					sw.Write(_input.TableLayout.DisplayColumns[i]);
					if (i < _input.TableLayout.DisplayColumns.Length - 1) sw.Write(",");
				}
				
				sw.Write(sw.NewLine);

				//Add All Rows
				reader1 = _singleLayerQuery.GetSurfaceHasSignatureAllWithReader(_input);
				if (reader1 == null) return result;
				long surfaceKey = 0;
				int signatureCount = 0;
				int colCount = reader1.FieldCount;

				while (reader1.Read())
				{
					surfaceKey = Convert.ToInt64(reader1.GetValue(0));
					reader2 = _singleLayerQuery2.GetResultBySurfaceKeyWithReader(surfaceKey);
					if (reader2 == null) continue;
					signatureCount = 0;

					while (reader2.Read())
					{
						signatureCount++;
						string signatureName = reader2.GetValue(reader2.GetOrdinal("SignatureName")).ToString();
						int grade = 0;

						if (!reader2.IsDBNull(reader2.GetOrdinal("Grade")))
						{
							grade = Convert.ToInt32(reader2.GetValue(reader2.GetOrdinal("Grade")));
							signatureName = string.Format("{0}-{1}", grade, signatureName);
						}

						sw.Write(string.Format("{0},", signatureName));
					}

					if (signatureCount < _maxSignatureCount)
					{
						for (int i = 0; i < _maxSignatureCount - signatureCount; i++)
							sw.Write(",");
					}

					for (int i = 1; i < colCount; i++)
					{
						if (!reader1.IsDBNull(i))
							sw.Write(reader1.GetValue(i).ToString());

						if (i < colCount + _maxSignatureCount - 2) sw.Write(",");
					}

					sw.Write(sw.NewLine);

					if (reader2 != null)
					{
						reader2.Close();
						reader2 = null;
					}

					_singleLayerQuery2.CloseCurrentConnection();
				}
			}
			catch (System.Exception e)
			{
				result = false;
				error = e.Message;
			}
			finally
			{
				if (reader1 != null)
				{
					reader1.Close();
					reader1 = null;
				}

				if (reader2 != null)
				{
					reader2.Close();
					reader2 = null;
				}

				if (sw != null)
				{
					sw.Close();
					sw = null;
				}

				_singleLayerQuery.CloseCurrentConnection();
				_singleLayerQuery2.CloseCurrentConnection();
			}

			return result;
		}
		#endregion

		#region Private Methods
		private void GetMaxSignatureCount()
		{
			GetMaxSignatureCountByPageIndex(1);

			for (int pageIndex = 2; pageIndex <= _pageCount; pageIndex++)
				GetMaxSignatureCountByPageIndex(pageIndex);
		}

		private void GetMaxSignatureCount2()
		{
			_maxSignatureCount = _singleLayerQuery.GetMaxSignatureCount(_input);
		}

		private void GetMaxSignatureCountByPageIndex(int index)
		{
			DataTable dtResult = GetData(index);

			foreach (DataRow row in dtResult.Rows)
			{
				DataTable dtDetail = GetResultBySurfaceKey(Convert.ToInt64(row["SurfaceKey"]));

				if (dtDetail != null && _maxSignatureCount < dtDetail.Rows.Count)
					_maxSignatureCount	= dtDetail.Rows.Count;
			}
		}

		private void FillData(SpreadsheetGear.IWorksheet workSheet)
		{
			int rowIndex = 1;
			DataTable dtResult = GetData3();

			if (dtResult != null && dtResult.Rows.Count > 0)
			{
				Color color = Color.Black;
				IRange range = null;
				long surfaceKey = 0;
				int signatureCount = 0;
				DataTable dtSignatre = null;

				foreach (DataRow row in dtResult.Rows)
				{
					int colIndex = 0;

					surfaceKey = Convert.ToInt64(row["SurfaceKey"]);
					string imgPath = string.Format("{0}\\SourceThumbnail{1}.png", _tempDir, rowIndex);
					if (_exportType == ExportType.DataAndImage)
					{
						SaveSourceThumbnail2(surfaceKey, imgPath);
						AddImage(workSheet, rowIndex, colIndex++, imgPath, 82, 90, 91.5);
					}

					dtSignatre = GetResultBySurfaceKey2(surfaceKey);
					signatureCount = 1;

					if (dtSignatre != null && dtSignatre.Rows.Count > 0)
					{
						for (int i = 0; i < _maxSignatureCount; i++)
						{
							if (i < dtSignatre.Rows.Count)
							{
								string signatureName = dtSignatre.Rows[i]["SignatureName"].ToString();
								int grade = 0;
								if (dtSignatre.Rows[i]["Grade"] != DBNull.Value && dtSignatre.Rows[i]["Grade"] != null)
								{
									grade = Convert.ToInt32(dtSignatre.Rows[i]["Grade"]);
									signatureName = string.Format("{0}-{1}", grade, signatureName);
								}

								if (_exportType == ExportType.DataAndImage)
								{
									imgPath = string.Format("{0}\\ResultThumbnail{1}.png", _tempDir, signatureCount);
									SaveResultThumbnail2(Convert.ToInt64(dtSignatre.Rows[i]["ResultDetailKey"]), imgPath, surfaceKey, signatureName);
									AddImage(workSheet, rowIndex, colIndex++, imgPath, 82, 90, 91.5);
								}
								else
								{
									range = workSheet.Cells[rowIndex, colIndex++];
									SetCellInfo(range, signatureName, HAlign.Center, VAlign.Center, color, 10, false, Color.White, 30, true);
								}
							}
							else
							{
								range = workSheet.Cells[rowIndex, colIndex++];
								SetCellInfo(range, string.Empty, HAlign.Center, VAlign.Center, color, 10, false, Color.White, 15, true);
							}
						}
					}

					if (_exportType == ExportType.DataAndImage)
						colIndex = _maxSignatureCount + 1;
					else
						colIndex = _maxSignatureCount;

					foreach (string columnName in _input.TableLayout.DisplayColumns)
					{
						{
							WaferResultItem resultItem = new WaferResultItem(row);
							range = workSheet.Cells[rowIndex, colIndex++];
							SetCellInfo(range, resultItem[columnName].ToString(), HAlign.Center, VAlign.Center, color, 10, false, Color.White, 30, true);
						}
					}

					rowIndex ++;
				}
			}
		}

		private void FillData2(SpreadsheetGear.IWorksheet workSheet)
		{
			int rowIndex = 1;
			
			rowIndex = FillDataByPageIndex(1, rowIndex, workSheet);
		
			for (int pageIndex = 2; pageIndex <= _pageCount; pageIndex++)
				rowIndex = FillDataByPageIndex(pageIndex, rowIndex, workSheet);
		}
		
		private DataTable GetResultBySurfaceKey(long surfaceKey)
		{
			DataTable result = null;
			try
			{
				WebServiceProxy.SingleLayerProxy.SingleLayerRecipe param = (WebServiceProxy.SingleLayerProxy.SingleLayerRecipe)WebServiceProxy.ConvertProxy.Convert(_input, typeof(WebServiceProxy.SingleLayerProxy.SingleLayerRecipe));
				WebServiceProxy.SingleLayerProxy.SingleLayer service = WebServiceProxy.WebProxyFactory.CreateSingleLayer();
				if (service == null) return null;
				result = service.GetResultBySurfaceKey(surfaceKey, param, (WebServiceProxy.SingleLayerProxy.DDADBType)AppData.Data.DBType).Result.Tables[0];
			}
			catch (System.Exception e)
			{
				SiGlaz.Utility.Utility.WriteToTraceLog(e, "GetResultBySurfaceKey");
			}

			return result;
		}

		private DataTable GetResultBySurfaceKey2(long surfaceKey)
		{
			DataTable result = null;
			try
			{
				DataSetResult ds = _singleLayerQuery.GetResultBySurfaceKey(surfaceKey, _sqlWhere);
				
				if (ds != null && ds.Result != null && ds.Result.Tables.Count > 0)
					result = ds.Result.Tables[0];
			}
			catch (System.Exception e)
			{
				SiGlaz.Utility.Utility.WriteToTraceLog(e, "GetResultBySurfaceKey");
			}

			return result;
		}

		private void InitHeader(SpreadsheetGear.IWorksheet workSheet)
		{
			IRange range = null;
			int colIndex = 0;
			int rowIndex = 0;
			Color fontColor = Color.White;
			Color bgColor = Color.FromArgb(153, 51, 0);

			workSheet.Name = "Signature of Surface";

			if (_exportType == ExportType.DataAndImage)
			{
				range = workSheet.Cells[rowIndex, colIndex++];
				SetCellInfo(range, "Source Map", HAlign.Center, VAlign.Center, fontColor, 10, true, bgColor, 14, false);
			}
			
			for (int i = 1; i <= _maxSignatureCount; i++)
			{
				range = workSheet.Cells[rowIndex, colIndex++];
				SetCellInfo(range, string.Format("Signature {0}", i), HAlign.Center, VAlign.Center, fontColor, 10, true, bgColor, 14, false);
			}

			foreach (string columnName in _input.TableLayout.DisplayColumns)
			{
				range = workSheet.Cells[rowIndex, colIndex++];
				SetCellInfo(range, columnName, HAlign.Center, VAlign.Center, fontColor, 10, true, bgColor, 30, false);
			}
		}

		private int FillDataByPageIndex(int pageIndex, int rowIndex, SpreadsheetGear.IWorksheet workSheet)
		{
			DataTable dtResult = GetData(pageIndex);

			if (dtResult != null && dtResult.Rows.Count > 0)
			{
				Color color = Color.Black;
				IRange range = null;
				long surfaceKey = 0;
				int signatureCount = 0;
				DataTable dtSignatre = null;
				WebServiceProxy.SingleLayerProxy.SingleLayer service = WebServiceProxy.WebProxyFactory.CreateSingleLayer();

				foreach (DataRow row in dtResult.Rows)
				{
					int colIndex = 0;

					surfaceKey = Convert.ToInt64(row["SurfaceKey"]);
					string imgPath = string.Format("{0}\\SourceThumbnail{1}.png", _tempDir, rowIndex);
					if (_exportType ==ExportType.DataAndImage)
					{
						
						SaveSourceThumbnail(surfaceKey, imgPath);
						AddImage(workSheet, rowIndex, colIndex++, imgPath, 82, 90, 91.5);
					}

					dtSignatre = GetResultBySurfaceKey(surfaceKey);
					signatureCount = 1;

					if (dtSignatre != null && dtSignatre.Rows.Count > 0)
					{
						for (int i = 0; i < _maxSignatureCount; i++)
						{
							if (i < dtSignatre.Rows.Count)
							{
								string signatureName = dtSignatre.Rows[i]["SignatureName"].ToString();
								int grade = 0;
								if (dtSignatre.Rows[0]["Grade"] != DBNull.Value && dtSignatre.Rows[0]["Grade"] != null)
								{
									grade = Convert.ToInt32(dtSignatre.Rows[0]["Grade"]);
									signatureName = string.Format("{0}-{1}", grade, signatureName);
								}

								if (_exportType == ExportType.DataAndImage)
								{
									imgPath = string.Format("{0}\\ResultThumbnail{1}.png", _tempDir, signatureCount);
									SaveResultThumbnail(Convert.ToInt64(dtSignatre.Rows[i]["ResultDetailKey"]), imgPath, surfaceKey, signatureName);
									AddImage(workSheet, rowIndex, colIndex++, imgPath, 82, 90, 91.5);
								}
								else
								{
									range = workSheet.Cells[rowIndex, colIndex++];
									//string signatureName = GetSignatureName(Convert.ToInt64(dtSignatre.Rows[i]["ResultDetailKey"]));
									SetCellInfo(range, signatureName, HAlign.Center, VAlign.Center, color, 10, false, Color.White, 30, true);
								}
							}
							else
							{
								range = workSheet.Cells[rowIndex, colIndex++];
								SetCellInfo(range, string.Empty, HAlign.Center, VAlign.Center, color, 10, false, Color.White, 15, true);
							}
						}
					}

					if (_exportType == ExportType.DataAndImage)
						colIndex = _maxSignatureCount + 1;
					else
						colIndex = _maxSignatureCount;

					foreach (string columnName in _input.TableLayout.DisplayColumns)
					{
						if (columnName != WaferConst.Surface)
						{
							WaferResultItem resultItem = new WaferResultItem(row);
							range = workSheet.Cells[rowIndex, colIndex++];
							SetCellInfo(range, resultItem[columnName].ToString(), HAlign.Center, VAlign.Center, color, 10, false, Color.White, 30, true);
						}
						else
						{
							if (Convert.ToInt32(row[columnName]) == 0)
							{
								range = workSheet.Cells[rowIndex, colIndex++];
								SetCellInfo(range, "Top", HAlign.Center, VAlign.Center, color, 10, false, Color.White, 30, true);
							}
							else
							{
								range = workSheet.Cells[rowIndex, colIndex++];
								SetCellInfo(range, "Bottom", HAlign.Center, VAlign.Center, color, 10, false, Color.White, 30, true);
							}
						}
					}

					rowIndex ++;
				}
			}

			return rowIndex;
		}

		private DataTable GetData(int index)
		{
			int pageSize = _input.TableLayout.PageSize;
			_input.TableLayout.PageSize = 1000;
			_input.TableLayout.PageIndex = index;
			
			WebServiceProxy.SingleLayerProxy.SingleLayerRecipe param = (WebServiceProxy.SingleLayerProxy.SingleLayerRecipe)WebServiceProxy.ConvertProxy.Convert(_input, typeof(WebServiceProxy.SingleLayerProxy.SingleLayerRecipe));
			WebServiceProxy.SingleLayerProxy.SingleLayer service = WebServiceProxy.WebProxyFactory.CreateSingleLayer();
			if(service == null) return null;
			WebServiceProxy.SingleLayerProxy.DataSetResult result = service.GetSurfaceHasSignature(param, (WebServiceProxy.SingleLayerProxy.DDADBType)AppData.Data.DBType);

			_rowCount = result.TotalRow;
			_pageCount = TableLayout.GetTotalages( _rowCount, _input.TableLayout.PageSize);

			if (result.Result != null && result.Result.Tables.Count > 0)
			{
				DataTable dtResult = result.Result.Tables[0];
				if (dtResult.Rows.Count <= 0)
					return null;
			}
			else
				return null;
	
			_input.TableLayout.PageSize = pageSize;

			return result.Result.Tables[0];
		}

		private DataTable GetData3()
		{
			DataSetResult result = _singleLayerQuery.GetSurfaceHasSignatureAll(_input);

			if (result.Result != null && result.Result.Tables.Count > 0)
			{
				DataTable dtResult = result.Result.Tables[0];
				if (dtResult.Rows.Count <= 0)
					return null;
			}
			else
				return null;
	
			return result.Result.Tables[0];
		}

		private void SaveSourceThumbnail(long surfaceKey, string fileName)
		{
			Bitmap bmp = null;
			Bitmap newBmp = null;
			Graphics g = null;
			MemoryStream memory = null;
			byte[] buffer = null;
			
			try
			{
				WebServiceProxy.SourceProxy.Source proxy = WebServiceProxy.WebProxyFactory.CreateSource();

				if (_viewMode == ViewMode.Disk)
					buffer = proxy.GetSourceThumbnail(surfaceKey, (WebServiceProxy.SourceProxy.DDADBType)AppData.Data.DBType);
				else
					buffer = proxy.GetSourceThumbnailFlat(surfaceKey, (WebServiceProxy.SourceProxy.DDADBType)AppData.Data.DBType);
				
				memory = new MemoryStream(buffer);
				newBmp = new Bitmap(memory);

				bmp = new Bitmap(100, 120);
				g = Graphics.FromImage(bmp);
				g.DrawImage(newBmp, 0, 0, 100, 100);

				bmp.Save(fileName);
			}
			catch (Exception e)
			{
				SiGlaz.Utility.Utility.WriteToTraceLog(e, "Export Signature of Surface Excel Report (SaveSourceThumbnail)");
			}
			finally
			{
				if (g != null)
				{
					g.Dispose();
					g = null;
				}

				if (newBmp != null)
				{
					newBmp.Dispose();
					newBmp = null;
				}

				if (memory != null)
				{
					memory.Close();
					memory = null;
				}
				
				if (bmp != null)
				{
					bmp.Dispose();
					bmp = null;
				}
			}
		}

		private void SaveSourceThumbnail2(long surfaceKey, string fileName)
		{
			Bitmap bmp = null;
			Bitmap newBmp = null;
			Graphics g = null;
			MemoryStream memory = null;
			byte[] buffer = null;
			
			try
			{
				if (_viewMode == ViewMode.Disk)
					buffer = _sourceQuery.GetSourceThumbnail(surfaceKey);
				else
					buffer = _sourceQuery.GetSourceThumbnailFlat(surfaceKey);
				
				memory = new MemoryStream(buffer);
				newBmp = new Bitmap(memory);

				bmp = new Bitmap(100, 120);
				g = Graphics.FromImage(bmp);
				g.DrawImage(newBmp, 0, 0, 100, 100);

				bmp.Save(fileName);
			}
			catch (Exception e)
			{
				SiGlaz.Utility.Utility.WriteToTraceLog(e, "Export Signature of Surface Excel Report (SaveSourceThumbnail)");
			}
			finally
			{
				if (g != null)
				{
					g.Dispose();
					g = null;
				}

				if (newBmp != null)
				{
					newBmp.Dispose();
					newBmp = null;
				}

				if (memory != null)
				{
					memory.Close();
					memory = null;
				}
				
				if (bmp != null)
				{
					bmp.Dispose();
					bmp = null;
				}
			}
		}

		private string GetSignatureName(long resultDetailKey)
		{
			string signatureName = string.Empty;
			try
			{
				WebServiceProxy.SingleLayerProxy.SingleLayer proxy = WebServiceProxy.WebProxyFactory.CreateSingleLayer();
				WebServiceProxy.SingleLayerProxy.DataSetResult result = proxy.GetResultByResultDetailKey(resultDetailKey, (WebServiceProxy.SingleLayerProxy.DDADBType)AppData.Data.DBType);
				int ddaGrade = 0;

				if (result != null && result.Result.Tables.Count > 0 && result.Result.Tables[0].Rows.Count > 0)
				{
					signatureName = result.Result.Tables[0].Rows[0]["SignatureName"].ToString();

					if (result.Result.Tables[0].Rows[0]["Grade"] != DBNull.Value && result.Result.Tables[0].Rows[0]["Grade"] != null)
					{
						ddaGrade = Convert.ToInt32(result.Result.Tables[0].Rows[0]["Grade"]);
						signatureName = string.Format("{0}-{1}", ddaGrade, signatureName);
					}
				}
			}
			catch (Exception e)
			{
				SiGlaz.Utility.Utility.WriteToTraceLog(e, "Export Signature of Surface Excel Report (GetSignatureName)");
			}

			return signatureName;
		}

		private void SaveResultThumbnail(long resultDetailKey, string fileName, long surfaceKey, string signatureName)
		{
			Bitmap bmp = null;
			Bitmap newBmp = null;
			MemoryStream memory = null;
			Graphics g = null;
			byte[] buffer = null;
				
			try
			{
				WebServiceProxy.SingleLayerProxy.SingleLayer proxy = WebServiceProxy.WebProxyFactory.CreateSingleLayer();

				if (_viewMode == ViewMode.Disk)
					buffer = proxy.GetResultThumbnail(resultDetailKey, (WebServiceProxy.SingleLayerProxy.DDADBType)AppData.Data.DBType);
				else
					buffer = proxy.GetResultThumbnailFlat(resultDetailKey, (WebServiceProxy.SingleLayerProxy.DDADBType)AppData.Data.DBType);
				
//				WebServiceProxy.SingleLayerProxy.DataSetResult result = proxy.GetResultByResultDetailKey(resultDetailKey, (WebServiceProxy.SingleLayerProxy.DDADBType)AppData.Data.DBType);
//				string signatureName = string.Empty;
//				int ddaGrade = 0;
//
//				if (result != null && result.Result.Tables.Count > 0 && result.Result.Tables[0].Rows.Count > 0)
//				{
//					signatureName = result.Result.Tables[0].Rows[0]["SignatureName"].ToString();
//
//					if (result.Result.Tables[0].Rows[0]["Grade"] != DBNull.Value && result.Result.Tables[0].Rows[0]["Grade"] != null)
//					{
//						ddaGrade = Convert.ToInt32(result.Result.Tables[0].Rows[0]["Grade"]);
//						signatureName = string.Format("{0}-{1}", ddaGrade, signatureName);
//					}
//				}

				if (buffer != null)
				{
					memory = new MemoryStream(buffer);
					newBmp = new Bitmap(memory);
				}
				else
				{
					WebServiceProxy.SourceProxy.Source service = WebServiceProxy.WebProxyFactory.CreateSource();

					if (_viewMode == ViewMode.Disk)
						buffer = service.GetSourceThumbnail(surfaceKey, (WebServiceProxy.SourceProxy.DDADBType)AppData.Data.DBType);
					else
						buffer = service.GetSourceThumbnailFlat(surfaceKey, (WebServiceProxy.SourceProxy.DDADBType)AppData.Data.DBType);

					memory = new MemoryStream(buffer);
					newBmp = new Bitmap(memory);
				}
				
				bmp = new Bitmap(100, 120, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
			
				g = Graphics.FromImage(bmp);
				g.Clear(Color.White);
				
				g.DrawImage(newBmp, 0, 0, 100, 100);
				
				Font font = new Font("arial", 7);

				if (signatureName.Length <= 25)
				{
					float x = 46 - (float)((signatureName.Length/2) * (float)(100/25));
					g.DrawString(signatureName, font, Brushes.Blue, x, 100);
				}
				else
				{
					g.DrawString(signatureName.Substring(0, 25), font, Brushes.Blue, 0, 100);
					signatureName = signatureName.Substring(25, signatureName.Length - 25);
					float x = 46 - (float)((signatureName.Length/2) * (float)(100/25));
					g.DrawString(signatureName, font, Brushes.Blue, x, 109);
				}

				bmp.Save(fileName);
			}
			catch (Exception e)
			{
				SiGlaz.Utility.Utility.WriteToTraceLog(e, "Export Signature of Surface Excel Report (SaveResultThumbnail)");
			}
			finally
			{
				if (g != null)
				{
					g.Dispose();
					g = null;
				}
				
				if (newBmp != null)
				{
					newBmp.Dispose();
					newBmp = null;
				}
			}
		}

		private void SaveResultThumbnail2(long resultDetailKey, string fileName, long surfaceKey, string signatureName)
		{
			Bitmap bmp = null;
			Bitmap newBmp = null;
			MemoryStream memory = null;
			Graphics g = null;
			byte[] buffer = null;
				
			try
			{
				if (_viewMode == ViewMode.Disk)
					buffer = _singleLayerQuery.GetResultThumbnail(resultDetailKey);
				else
					buffer = _singleLayerQuery.GetResultThumbnailFlat(resultDetailKey);

				if (buffer != null)
				{
					memory = new MemoryStream(buffer);
					newBmp = new Bitmap(memory);
				}
				else
				{
					if (_viewMode == ViewMode.Disk)
						buffer = _sourceQuery.GetSourceThumbnail(surfaceKey);
					else
						buffer = _sourceQuery.GetSourceThumbnailFlat(surfaceKey);

					memory = new MemoryStream(buffer);
					newBmp = new Bitmap(memory);
				}
				
				bmp = new Bitmap(100, 120, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
			
				g = Graphics.FromImage(bmp);
				g.Clear(Color.White);
				
				g.DrawImage(newBmp, 0, 0, 100, 100);
				
				Font font = new Font("arial", 7);

				if (signatureName.Length <= 25)
				{
					float x = 46 - (float)((signatureName.Length/2) * (float)(100/25));
					g.DrawString(signatureName, font, Brushes.Blue, x, 100);
				}
				else
				{
					g.DrawString(signatureName.Substring(0, 25), font, Brushes.Blue, 0, 100);
					signatureName = signatureName.Substring(25, signatureName.Length - 25);
					float x = 46 - (float)((signatureName.Length/2) * (float)(100/25));
					g.DrawString(signatureName, font, Brushes.Blue, x, 109);
				}

				bmp.Save(fileName);
			}
			catch (Exception e)
			{
				SiGlaz.Utility.Utility.WriteToTraceLog(e, "Export Signature of Surface Excel Report (SaveResultThumbnail)");
			}
			finally
			{
				if (g != null)
				{
					g.Dispose();
					g = null;
				}
				
				if (newBmp != null)
				{
					newBmp.Dispose();
					newBmp = null;
				}
			}
		}

		private void AddImage(IWorksheet workSheet, int rowIndex, int colIndex, string imagePath, double width, double height, double rowHeight)
		{
			IRange range = workSheet.Cells[rowIndex, colIndex];
			range.Borders.Color = Color.Black;
			range.Borders.Weight = SpreadsheetGear.BorderWeight.Thin;
			range.Borders.LineStyle = SpreadsheetGear.LineStyle.Continuous;

			if (rowHeight > 0)
				range.RowHeight = rowHeight;
			
			double left = workSheet.WindowInfo.ColumnToPoints(colIndex) + 1;
			double top = workSheet.WindowInfo.RowToPoints(rowIndex) + 1; 
			workSheet.Shapes.AddPicture(imagePath, left, top, width, height);
		}

		private void SetCulturalWithEN_US()
		{
			if(_currentCultural.Name != "en-US")
				System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
		}

		private void SetCulturalWithCurrent()
		{
			if( _currentCultural.Name != "en-US")
				System.Threading.Thread.CurrentThread.CurrentCulture = _currentCultural;	
		}

		private void SetCellInfo(IRange range, object value, HAlign hAlign, VAlign vAlign, Color fontColor, double fontSize, bool bold, Color backColor, double colWidth, bool hasWrapText)
		{
			range.Borders.Color = Color.Black;
			range.Borders.Weight = SpreadsheetGear.BorderWeight.Thin;
			range.Borders.LineStyle = SpreadsheetGear.LineStyle.Continuous;
			range.HorizontalAlignment = hAlign;
			range.VerticalAlignment = vAlign;
			range.Font.Color = fontColor;
			range.Font.Size = fontSize;
			range.Font.Bold = bold;
			range.Interior.Color = backColor;
			range.ColumnWidth = colWidth;
			range.Value = value;
			range.WrapText = hasWrapText;
		}
		#endregion
	}
}
