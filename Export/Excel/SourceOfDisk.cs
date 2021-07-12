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
using SiGlaz.Utility;
using SiGlaz.DAL;
using SiGlaz.DDA.Business;
using System.Data.SqlClient;

namespace SiGlaz.Export.Excel
{
	public class SourceOfDisk
	{
		#region Members
		private DataSourceRecipe _input = null;
		private CultureInfo _currentCultural = System.Threading.Thread.CurrentThread.CurrentCulture;
		private string _tempDir = string.Format("{0}\\temp", Application.StartupPath);
		private int _rowCount = 0;
		private int _pageCount = 0;
		private ViewMode _viewMode = ViewMode.Disk;
		private ExportType _exportType = ExportType.DataAndImage;
		private ConnectionParam _param = new ConnectionParam();
		private Source _sourceQuery = null;
		#endregion

		#region Constructor
		public SourceOfDisk(DataSourceRecipe input, ViewMode viewMode, ExportType exportType)
		{
			_input = input;
			_viewMode = viewMode;
			_exportType = exportType;

			_param.Server = AppData.Data.ServerName;
			_param.Database = AppData.Data.DatabaseName;
			_param.Username = AppData.Data.UserName;
			RijndaelCrypto crypto = new RijndaelCrypto();
			_param.Password = crypto.Decrypt(AppData.Data.Password);
			_sourceQuery = new Source(_param);
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

		private bool Export2ExcelWithoutImage(string fileName, ref string error)
		{
			bool result = true;
			SqlDataReader reader = null;

			try
			{
				reader = _sourceQuery.GetSourceOfDiskAllWithReader(_input);
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

				_sourceQuery.CloseCurrentConnection();
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
		#endregion

		#region Private Methods
		private DataTable GetData(int index)
		{
			_input.TableLayout.PageIndex = index;
			
			WebServiceProxy.SourceProxy.DataSourceRecipe param = (WebServiceProxy.SourceProxy.DataSourceRecipe)WebServiceProxy.ConvertProxy.Convert(_input, typeof(WebServiceProxy.SourceProxy.DataSourceRecipe));
			WebServiceProxy.SourceProxy.Source service = WebServiceProxy.WebProxyFactory.CreateSource();
			if(service == null) return null;
			WebServiceProxy.SourceProxy.DataSetResult result = service.GetSourceOfDiskPaging(param, (WebServiceProxy.SourceProxy.DDADBType)AppData.Data.DBType);

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
//			WebServiceProxy.SourceProxy.DataSourceRecipe param = (WebServiceProxy.SourceProxy.DataSourceRecipe)WebServiceProxy.ConvertProxy.Convert(_input, typeof(WebServiceProxy.SourceProxy.DataSourceRecipe));
//			WebServiceProxy.SourceProxy.Source service = WebServiceProxy.WebProxyFactory.CreateSource();
//			if(service == null) return null;
//			WebServiceProxy.SourceProxy.DataSetResult result = service.GetSourceOfDiskAll(param, (WebServiceProxy.SourceProxy.DDADBType)AppData.Data.DBType);
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
			DataSetResult result = _sourceQuery.GetSourceOfDiskAll(_input);

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

//		private DataTable GetSourceOfDiskDetail(long diskKey)
//		{
//			bool hasImage = true ? _exportType == ExportType.DataAndImage : false;
//			WebServiceProxy.SourceProxy.DataSourceRecipe param = (WebServiceProxy.SourceProxy.DataSourceRecipe)WebServiceProxy.ConvertProxy.Convert(_input, typeof(WebServiceProxy.SourceProxy.DataSourceRecipe));
//			WebServiceProxy.SourceProxy.Source service = WebServiceProxy.WebProxyFactory.CreateSource();
//			if(service == null) return null;
//			WebServiceProxy.SourceProxy.DataSetResult result = service.GetDiskDetail(diskKey, hasImage, (WebServiceProxy.SourceProxy.DDADBType)AppData.Data.DBType);
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

		private DataTable GetSourceOfDiskDetail2(long diskKey)
		{
			bool hasImage = true ? _exportType == ExportType.DataAndImage : false;
			DataSetResult result = _sourceQuery.GetDiskDetail(diskKey, hasImage);

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
				long diskKey = Convert.ToInt64(row["DiskKey"]);
				DataTable dtDetail = GetSourceOfDiskDetail2(diskKey);
				if (dtDetail == null || dtDetail.Rows.Count <= 0) continue;
				resultItem = new WaferResultItem(dtDetail.Rows[0]);
				int colIndex = 0;
				
				if (_exportType == ExportType.DataAndImage)
				{
					string topImgPath = string.Format("{0}\\TopThumbnail{1}.png", _tempDir, rowIndex);
					string bottomImgPath = string.Format("{0}\\BottomThumbnail{1}.png", _tempDir, rowIndex);

					foreach (DataRow surfaceRow in dtDetail.Rows)
					{
						int surface = Convert.ToInt32(surfaceRow["Surface"]);
						if (surface == 1 && dtDetail.Rows.Count == 1)
						{
							range = workSheet.Cells[rowIndex, colIndex++];
							SetCellInfo(range, "", HAlign.Center, VAlign.Center, color, 10, false, Color.White, 15, true);
							SaveSourceThumbnail2(surfaceRow, bottomImgPath);
							AddImage(workSheet, rowIndex, colIndex++, bottomImgPath, 82, 75, 76);	
						}
						else
						{
							if (surface == 0)
							{
								SaveSourceThumbnail2(surfaceRow, topImgPath);
								AddImage(workSheet, rowIndex, colIndex++, topImgPath, 82, 75, 76);	
							}
							else
							{
								SaveSourceThumbnail2(surfaceRow, bottomImgPath);
								AddImage(workSheet, rowIndex, colIndex++, bottomImgPath, 82, 75, 76);	
							}
						
						}						
					}

					if (dtDetail.Rows.Count == 1 && Convert.ToInt32(dtDetail.Rows[0]["Surface"]) == 0)
					{
						range = workSheet.Cells[rowIndex, colIndex++];
						SetCellInfo(range, "", HAlign.Center, VAlign.Center, color, 10, false, Color.White, 15, true);
					}
				}
				

				foreach (string columnName in _input.TableLayout.DisplayColumns)
				{
					range = workSheet.Cells[rowIndex, colIndex++];
					SetCellInfo(range, resultItem[columnName], HAlign.Center, VAlign.Center, color, 10, false, Color.White, 30, true);
				}

				dtDetail.Rows.Clear();
				dtDetail = null;
				rowIndex ++;
			}
		}

		private DataTable GetSurfaceByDisk(long diskKey)
		{
			try
			{
				WebServiceProxy.SourceProxy.Source diskService = WebServiceProxy.WebProxyFactory.CreateSource();
				if(diskService == null) return null;

				WebServiceProxy.SourceProxy.DataSetResult result = diskService.GetSurfaceByDisk(diskKey, (WebServiceProxy.SourceProxy.DDADBType)AppData.Data.DBType);

				if (result != null && result.Result != null && result.Result.Tables.Count > 0)
					return result.Result.Tables[0];
			}
			catch (System.Exception e)
			{
				SiGlaz.Utility.Utility.WriteToTraceLog(e, "Export Source of Disk Excel Report (GetSurfaceByDisk)");
			}

			return null;
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
						string topImgPath = string.Format("{0}\\TopThumbnail{1}.png", _tempDir, rowIndex);
						string bottomImgPath = string.Format("{0}\\BottomThumbnail{1}.png", _tempDir, rowIndex);
						DataTable dtSurface = GetSurfaceByDisk(Convert.ToInt64(resultItem["DiskKey"]));

						foreach (DataRow surfaceRow in dtSurface.Rows)
						{
							long surfaceKey = Convert.ToInt64(surfaceRow["SurfaceKey"]);
							int surface = Convert.ToInt32(surfaceRow["Surface"]);

							if (surface == 1 && dtSurface.Rows.Count == 1)
							{
								range = workSheet.Cells[rowIndex, colIndex++];
								SetCellInfo(range, "", HAlign.Center, VAlign.Center, color, 10, false, Color.White, 15, true);

								SaveSourceThumbnail(surfaceKey, bottomImgPath);
								AddImage(workSheet, rowIndex, colIndex++, bottomImgPath, 82, 75, 76);	
							}
							else
							{
								if (surface == 0)
								{
									SaveSourceThumbnail(surfaceKey, topImgPath);
									AddImage(workSheet, rowIndex, colIndex++, topImgPath, 82, 75, 76);	
								}
								else
								{
									SaveSourceThumbnail(surfaceKey, bottomImgPath);
									AddImage(workSheet, rowIndex, colIndex++, bottomImgPath, 82, 75, 76);	
								}
							
							}						
						}

						if (dtSurface.Rows.Count == 1 && Convert.ToInt32(dtSurface.Rows[0]["Surface"]) == 0)
						{
							range = workSheet.Cells[rowIndex, colIndex++];
							SetCellInfo(range, "", HAlign.Center, VAlign.Center, color, 10, false, Color.White, 15, true);
						}
					}
					

					foreach (string columnName in _input.TableLayout.DisplayColumns)
					{
						range = workSheet.Cells[rowIndex, colIndex++];
						SetCellInfo(range, resultItem[columnName], HAlign.Center, VAlign.Center, color, 10, false, Color.White, 30, true);
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
				SiGlaz.Utility.Utility.WriteToTraceLog(e, "Export Data Source Excel Report (SaveSourceThumbnail)");
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
				SiGlaz.Utility.Utility.WriteToTraceLog(e, "Export Data Source Excel Report (SaveSourceThumbnail)");
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
			Color bgColor = Color.FromArgb(153, 51, 0);

			workSheet.Name = "Source of Disk";

			if (_exportType == ExportType.DataAndImage)
			{
				range = workSheet.Cells[rowIndex, colIndex++];
				SetCellInfo(range, "Top Map", HAlign.Center, VAlign.Center, fontColor, 10, true, bgColor, 14, false);

				range = workSheet.Cells[rowIndex, colIndex++];
				SetCellInfo(range, "Bottom Map", HAlign.Center, VAlign.Center, fontColor, 10, true, bgColor, 14, false);
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
