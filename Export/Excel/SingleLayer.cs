using System;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Globalization;
using System.Collections;
using System.Drawing;
using SpreadsheetGear;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Const;
using SiGlaz.Common.DDA.Basic;
using SiGlaz.Common.DDA.Recipe;
using SiGlaz.Common.DDA.Result;
using SiGlaz.Utility;
using SiGlaz.DAL;
using SiGlaz.DDA.Business;
using System.Data.SqlClient;

namespace SiGlaz.Export.Excel
{
	public class SingleLayer
	{
		#region Members
		private SingleLayerRecipe _input = null;
		private CultureInfo _currentCultural = System.Threading.Thread.CurrentThread.CurrentCulture;
		private string _tempDir = string.Format("{0}\\temp", Application.StartupPath);
		private int _rowCount = 0;
		private int _pageCount = 0;
		private ViewMode _viewMode = ViewMode.Disk;
		private ExportType _exportType = ExportType.DataAndImage;
		private ConnectionParam _param = new ConnectionParam();
		private SiGlaz.DDA.Business.SingleLayer _singleLayerQuery = null;
		#endregion

		#region Constructor
		public SingleLayer(SingleLayerRecipe input, ViewMode viewMode, ExportType exportType)
		{
			_input = input;
			_viewMode = viewMode;
			_exportType = exportType;

			_param.Server = AppData.Data.ServerName;
			_param.Database = AppData.Data.DatabaseName;
			_param.Username = AppData.Data.UserName;
			RijndaelCrypto crypto = new RijndaelCrypto();
			_param.Password = crypto.Decrypt(AppData.Data.Password);
			_singleLayerQuery = new SiGlaz.DDA.Business.SingleLayer(_param);
		}
		#endregion

		#region Public Methods
		public bool Export2Excel(string fileName, ref string error)
		{
			bool result = true;
			Cursor.Current = Cursors.WaitCursor;

			if (_exportType == ExportType.DataAndImage)
			{
				if (SiGlaz.Utility.Utility.CreateDirectory(_tempDir, ref error))
					result = Export2ExcelWithImage(fileName, ref error);
			}
			else
				result = Export2ExcelWithoutImage(fileName, ref error);

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

			try
			{
				reader = _singleLayerQuery.GetSingleLayerAllWithReader(_input);
				if (reader == null) return result;
				ExportDataReaderToCSV.Export(reader, _input.TableLayout.DisplayColumns, fileName);
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

				_singleLayerQuery.CloseCurrentConnection();
			}

			return result;
		}
		#endregion

		#region Private Methods
		private DataTable GetData(int index)
		{
			_input.TableLayout.PageIndex = index;
			
			WebServiceProxy.SingleLayerProxy.SingleLayerRecipe param = (WebServiceProxy.SingleLayerProxy.SingleLayerRecipe)WebServiceProxy.ConvertProxy.Convert(_input, typeof(WebServiceProxy.SingleLayerProxy.SingleLayerRecipe));
			WebServiceProxy.SingleLayerProxy.SingleLayer service = WebServiceProxy.WebProxyFactory.CreateSingleLayer();
			if(service == null) return null;
			WebServiceProxy.SingleLayerProxy.DataSetResult result = service.GetSingleLayerPaging(param, (WebServiceProxy.SingleLayerProxy.DDADBType)AppData.Data.DBType);

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
	
			return result.Result.Tables[0];
		}

//		private DataTable GetData2()
//		{
//			WebServiceProxy.SingleLayerProxy.SingleLayerRecipe param = (WebServiceProxy.SingleLayerProxy.SingleLayerRecipe)WebServiceProxy.ConvertProxy.Convert(_input, typeof(WebServiceProxy.SingleLayerProxy.SingleLayerRecipe));
//			WebServiceProxy.SingleLayerProxy.SingleLayer service = WebServiceProxy.WebProxyFactory.CreateSingleLayer();
//			if(service == null) return null;
//			WebServiceProxy.SingleLayerProxy.DataSetResult result = service.GetSingleLayerAll(param, (WebServiceProxy.SingleLayerProxy.DDADBType)AppData.Data.DBType);
//
//			if (result.Result != null && result.Result.Tables.Count > 0)
//			{
//				DataTable dtResult = result.Result.Tables[0];
//				if (dtResult.Rows.Count <= 0)
//					return null;
//			}
//			else
//				return null;
//	
//			return result.Result.Tables[0];
//		}

		private DataTable GetData3()
		{
			DataSetResult result = _singleLayerQuery.GetSingleLayerAll(_input);

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

//		private DataTable GetSingleLayerDetail(long resultKey)
//		{
//			bool hasImage = true ? _exportType == ExportType.DataAndImage : false;
//			WebServiceProxy.SingleLayerProxy.SingleLayerRecipe param = (WebServiceProxy.SingleLayerProxy.SingleLayerRecipe)WebServiceProxy.ConvertProxy.Convert(_input, typeof(WebServiceProxy.SingleLayerProxy.SingleLayerRecipe));
//			WebServiceProxy.SingleLayerProxy.SingleLayer service = WebServiceProxy.WebProxyFactory.CreateSingleLayer();
//			if(service == null) return null;
//			WebServiceProxy.SingleLayerProxy.DataSetResult result = service.GetSingleLayerDetail(resultKey, hasImage, (WebServiceProxy.SingleLayerProxy.DDADBType)AppData.Data.DBType);
//
//			if (result.Result != null && result.Result.Tables.Count > 0)
//			{
//				DataTable dtResult = result.Result.Tables[0];
//				if (dtResult.Rows.Count <= 0)
//					return null;
//			}
//			else
//				return null;
//	
//			return result.Result.Tables[0];
//		}

		private DataTable GetSingleLayerDetail2(long resultKey)
		{
			bool hasImage = true ? _exportType == ExportType.DataAndImage : false;
			DataSetResult result = _singleLayerQuery.GetSingleLayerDetail(resultKey, hasImage);

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

		private void FillData2(SpreadsheetGear.IWorksheet workSheet)
		{
			int rowIndex = 1;
			
			rowIndex = FillDataByPageIndex(1, rowIndex, workSheet);
		
			for (int pageIndex = 2; pageIndex <= _pageCount; pageIndex++)
				rowIndex = FillDataByPageIndex(pageIndex, rowIndex, workSheet);
		}

		private void FillData(SpreadsheetGear.IWorksheet workSheet)
		{
			DataTable dtResult = GetData3();
			if (dtResult == null || dtResult.Rows.Count <= 0) return;
			int rowIndex = 1;
			Color color = Color.Black;
			IRange range = null;
			WaferResultItem resultItem = null;

			foreach (DataRow row in dtResult.Rows)
			{
				long resutlKey = Convert.ToInt64(row["ResultKey"]);
				DataTable dtDetail = GetSingleLayerDetail2(resutlKey);
				if (dtDetail == null || dtDetail.Rows.Count <= 0) continue;
				resultItem = new WaferResultItem(dtDetail.Rows[0]);

				int colIndex = 0;
				if (_exportType == ExportType.DataAndImage)
				{
					string imgPath = string.Format("{0}\\SourceThumbnail{1}.png", _tempDir, rowIndex);
					SaveSourceThumbnail2(dtDetail.Rows[0], imgPath);
					AddImage(workSheet, rowIndex, colIndex++, imgPath, 82, 75, 76);

					imgPath = string.Format("{0}\\ResultThumbnail{1}.png", _tempDir, rowIndex);
					SaveResultThumbnail2(dtDetail.Rows[0], imgPath);
				
					if (File.Exists(imgPath))
						AddImage(workSheet, rowIndex, colIndex++, imgPath, 82, 75, 76);
					else
					{
						imgPath = string.Format("{0}\\SourceThumbnail{1}.png", _tempDir, rowIndex);
						AddImage(workSheet, rowIndex, colIndex++, imgPath, 82, 75, 76);
					}
				}

				foreach (string columnName in _input.TableLayout.DisplayColumns)
				{
					range = workSheet.Cells[rowIndex, colIndex++];
					if (columnName != WaferConst.Surface)
						SetCellInfo(range, resultItem[columnName], HAlign.Center, VAlign.Center, color, 10, false, Color.White, 30, true);
					else
					{
						if (Convert.ToInt32(resultItem[columnName]) == 0)
							SetCellInfo(range, "Top", HAlign.Center, VAlign.Center, color, 10, false, Color.White, 30, true);
						else
							SetCellInfo(range, "Bottom", HAlign.Center, VAlign.Center, color, 10, false, Color.White, 30, true);
					}
				}

				rowIndex ++;
			}
		}

		private int FillDataByPageIndex(int pageIndex, int rowIndex, SpreadsheetGear.IWorksheet workSheet)
		{
			DataTable dtResult = GetData(pageIndex);

			if (dtResult != null && dtResult.Rows.Count > 0)
			{
				Color color = Color.Black;
				IRange range = null;
				WaferResultItem resultItem = null;

				foreach (DataRow row in dtResult.Rows)
				{
					resultItem = new WaferResultItem(row);

					int colIndex = 0;
					if (_exportType == ExportType.DataAndImage)
					{
						string imgPath = string.Format("{0}\\SourceThumbnail{1}.png", _tempDir, rowIndex);
						SaveSourceThumbnail(Convert.ToInt64(row["SurfaceKey"]), imgPath);
						AddImage(workSheet, rowIndex, colIndex++, imgPath, 82, 75, 76);

						imgPath = string.Format("{0}\\ResultThumbnail{1}.png", _tempDir, rowIndex);
						SaveResultThumbnail(Convert.ToInt64(row["ResultDetailKey"]), imgPath);
					
						if (File.Exists(imgPath))
							AddImage(workSheet, rowIndex, colIndex++, imgPath, 82, 75, 76);
						else
						{
							imgPath = string.Format("{0}\\SourceThumbnail{1}.png", _tempDir, rowIndex);
							AddImage(workSheet, rowIndex, colIndex++, imgPath, 82, 75, 76);
						}
					}

					foreach (string columnName in _input.TableLayout.DisplayColumns)
					{
						range = workSheet.Cells[rowIndex, colIndex++];
						if (columnName != WaferConst.Surface)
							SetCellInfo(range, resultItem[columnName], HAlign.Center, VAlign.Center, color, 10, false, Color.White, 30, true);
						else
						{
							if (Convert.ToInt32(resultItem[columnName]) == 0)
								SetCellInfo(range, "Top", HAlign.Center, VAlign.Center, color, 10, false, Color.White, 30, true);
							else
								SetCellInfo(range, "Bottom", HAlign.Center, VAlign.Center, color, 10, false, Color.White, 30, true);
						}
					}

					rowIndex ++;
				}
			}

			return rowIndex;
		}

		private void SaveSourceThumbnail(long surfaceKey, string fileName)
		{
			byte[] thumbnail = null;
			FileStream fs = null;
			
			try
			{
				WebServiceProxy.SourceProxy.Source proxy = WebServiceProxy.WebProxyFactory.CreateSource();

				if (_viewMode == ViewMode.Disk)
					thumbnail = proxy.GetSourceThumbnail(surfaceKey, (WebServiceProxy.SourceProxy.DDADBType)AppData.Data.DBType);
				else
					thumbnail = proxy.GetSourceThumbnailFlat(surfaceKey, (WebServiceProxy.SourceProxy.DDADBType)AppData.Data.DBType);

				fs = File.Create(fileName);
				fs.Write(thumbnail, 0, thumbnail.Length);
			}
			catch (System.Exception e)
			{
				SiGlaz.Utility.Utility.WriteToTraceLog(e, "Export Single Signature Excel Report (SaveSourceThumbnail)");
			}
			finally
			{
				if (fs != null)
				{
					fs.Close();
					fs = null;
				}

				if (thumbnail != null)
					thumbnail = null;
			}
		}

		private void SaveSourceThumbnail2(DataRow row, string fileName)
		{
			byte[] thumbnail = null;
			FileStream fs = null;
			
			try
			{
				if (_viewMode == ViewMode.Disk)
					thumbnail = (byte[])row["SourceThumbnail"];
				else
					thumbnail = (byte[])row["SourceThumbnailFlat"];

				fs = File.Create(fileName);
				fs.Write(thumbnail, 0, thumbnail.Length);
			}
			catch (System.Exception e)
			{
				SiGlaz.Utility.Utility.WriteToTraceLog(e, "Export Single Signature Excel Report (SaveSourceThumbnail)");
			}
			finally
			{
				if (fs != null)
				{
					fs.Close();
					fs = null;
				}

				if (thumbnail != null)
					thumbnail = null;
			}
		}

		private void SaveResultThumbnail(long resultDetailKey, string fileName)
		{
			byte[] thumbnail = null;
			FileStream fs = null;
			
			try
			{
				WebServiceProxy.SingleLayerProxy.SingleLayer proxy = WebServiceProxy.WebProxyFactory.CreateSingleLayer();

				if (_viewMode == ViewMode.Disk)
					thumbnail = proxy.GetResultThumbnail(resultDetailKey, (WebServiceProxy.SingleLayerProxy.DDADBType)AppData.Data.DBType);
				else
					thumbnail = proxy.GetResultThumbnailFlat(resultDetailKey, (WebServiceProxy.SingleLayerProxy.DDADBType)AppData.Data.DBType);

				if (thumbnail != null)
				{
					fs = File.Create(fileName);
					fs.Write(thumbnail, 0, thumbnail.Length);
				}
			}
			catch (System.Exception e)
			{
				SiGlaz.Utility.Utility.WriteToTraceLog(e, "Export Single Signature Excel Report (SaveResultThumbnail)");
			}
			finally
			{
				if (fs != null)
				{
					fs.Close();
					fs = null;
				}

				if (thumbnail != null)
					thumbnail = null;
			}
		}

		private void SaveResultThumbnail2(DataRow row, string fileName)
		{
			byte[] thumbnail = null;
			FileStream fs = null;
			
			try
			{
				if (_viewMode == ViewMode.Disk)
				{
					if (row["ResultThumbnail"] != null && row["ResultThumbnail"] != DBNull.Value)
						thumbnail = (byte[])row["ResultThumbnail"];
				}
				else
				{
					if (row["ResultThumbnailFlat"] != null && row["ResultThumbnailFlat"] != DBNull.Value)
						thumbnail = (byte[])row["ResultThumbnailFlat"];
				}

				if (thumbnail != null)
				{
					fs = File.Create(fileName);
					fs.Write(thumbnail, 0, thumbnail.Length);
				}
			}
			catch (System.Exception e)
			{
				SiGlaz.Utility.Utility.WriteToTraceLog(e, "Export Single Signature Excel Report (SaveResultThumbnail)");
			}
			finally
			{
				if (fs != null)
				{
					fs.Close();
					fs = null;
				}

				if (thumbnail != null)
					thumbnail = null;
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

		private void InitHeader(SpreadsheetGear.IWorksheet workSheet)
		{
			IRange range = null;
			int colIndex = 0;
			int rowIndex = 0;
			Color fontColor = Color.White;
			Color bgColor = Color.FromArgb(152, 51, 0);

			if (_exportType == ExportType.DataAndImage)
			{
				workSheet.Name = "Single Signature";
				range = workSheet.Cells[rowIndex, colIndex++];
				SetCellInfo(range, "Source Map", HAlign.Center, VAlign.Center, fontColor, 10, true, bgColor, 14, false);

				range = workSheet.Cells[rowIndex, colIndex++];
				SetCellInfo(range, "Result Map", HAlign.Center, VAlign.Center, fontColor, 10, true, bgColor, 14, false);
			}
			
			foreach (string columnName in _input.TableLayout.DisplayColumns)
			{
				range = workSheet.Cells[rowIndex, colIndex++];
				SetCellInfo(range, columnName, HAlign.Center, VAlign.Center, fontColor, 10, true, bgColor, 30, false);
			}
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
