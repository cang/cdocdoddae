//using System;
//using System.Drawing;
//using System.Collections;
//using System.ComponentModel;
//using System.Windows.Forms;
//using System.IO;
//using System.Globalization;
//using System.Data.OleDb;
//using System.Data;
//using SpreadsheetGear;
//
//using SiGlaz.Common.DDA;
//
//namespace DDARMWinUI.Dialogs
//{
//	public class DlgSignatureCategory : System.Windows.Forms.Form
//	{
//		#region Members
//		private System.Windows.Forms.ToolBar tbMain;
//		private System.Windows.Forms.ToolBarButton btnAddNew;
//		private System.Windows.Forms.ToolBarButton btnEdit;
//		private System.Windows.Forms.ToolBarButton btnDelete;
//		private System.Windows.Forms.ToolBarButton btnExport;
//		private System.Windows.Forms.ToolBarButton btnImport;
//		private System.Windows.Forms.ImageList imglToolBar;
//		private System.Windows.Forms.HelpProvider helpProvider1;
//		private System.Windows.Forms.ListView lvMaster;
//		private System.Windows.Forms.ColumnHeader colSignatureName;
//		private System.Windows.Forms.Button btnCancel;
//		private System.Windows.Forms.Button btnOK;
//		private System.Windows.Forms.ColumnHeader colDesc;
//		private System.ComponentModel.IContainer components;
//		private WebServiceProxy.CategoryProxy.Category _SigService = null;
//		private SiGlaz.DDA.Business.Category _SigService1 = null;
//		private System.Windows.Forms.ToolTip toolTip1;
//		private System.Windows.Forms.ContextMenu contextMenu1;
//		private System.Windows.Forms.MenuItem mnNewSignature;
//		private System.Windows.Forms.MenuItem mnEditSig;
//		private System.Windows.Forms.MenuItem mnDelete;
//		private System.Windows.Forms.MenuItem mnImport;
//		private System.Windows.Forms.MenuItem mnExport;
//		private System.Windows.Forms.ImageList _imgListToolBar;
//		private System.Windows.Forms.MenuItem menuItem1;
//		private System.Windows.Forms.ToolBarButton toolBarButton1;
//		private CultureInfo _currentCultural = System.Threading.Thread.CurrentThread.CurrentCulture;
//		#endregion
//		
//		#region Constructor & Destructor
//		public DlgSignatureCategory()
//		{
//			InitializeComponent();
//			LoadSignatureList();
//		}
//
//		protected override void Dispose( bool disposing )
//		{
//			if( disposing )
//			{
//				if(components != null)
//				{
//					components.Dispose();
//				}
//			}
//			base.Dispose( disposing );
//		}
//		#endregion
//
//		#region Windows Form Designer generated code
//		/// <summary>
//		/// Required method for Designer support - do not modify
//		/// the contents of this method with the code editor.
//		/// </summary>
//		private void InitializeComponent()
//		{
//			this.components = new System.ComponentModel.Container();
//			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgSignatureCategory));
//			this.tbMain = new System.Windows.Forms.ToolBar();
//			this.btnAddNew = new System.Windows.Forms.ToolBarButton();
//			this.btnEdit = new System.Windows.Forms.ToolBarButton();
//			this.btnDelete = new System.Windows.Forms.ToolBarButton();
//			this.btnExport = new System.Windows.Forms.ToolBarButton();
//			this.btnImport = new System.Windows.Forms.ToolBarButton();
//			this.imglToolBar = new System.Windows.Forms.ImageList(this.components);
//			this.helpProvider1 = new System.Windows.Forms.HelpProvider();
//			this.lvMaster = new System.Windows.Forms.ListView();
//			this.colSignatureName = new System.Windows.Forms.ColumnHeader();
//			this.colDesc = new System.Windows.Forms.ColumnHeader();
//			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
//			this.mnNewSignature = new System.Windows.Forms.MenuItem();
//			this.mnEditSig = new System.Windows.Forms.MenuItem();
//			this.mnDelete = new System.Windows.Forms.MenuItem();
//			this.mnImport = new System.Windows.Forms.MenuItem();
//			this.mnExport = new System.Windows.Forms.MenuItem();
//			this.btnCancel = new System.Windows.Forms.Button();
//			this.btnOK = new System.Windows.Forms.Button();
//			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
//			this._imgListToolBar = new System.Windows.Forms.ImageList(this.components);
//			this.menuItem1 = new System.Windows.Forms.MenuItem();
//			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
//			this.SuspendLayout();
//			// 
//			// tbMain
//			// 
//			this.tbMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
//																					  this.btnAddNew,
//																					  this.btnEdit,
//																					  this.btnDelete,
//																					  this.toolBarButton1,
//																					  this.btnImport,
//																					  this.btnExport});
//			this.tbMain.DropDownArrows = true;
//			this.tbMain.ImageList = this.imglToolBar;
//			this.tbMain.Location = new System.Drawing.Point(0, 0);
//			this.tbMain.Name = "tbMain";
//			this.tbMain.ShowToolTips = true;
//			this.tbMain.Size = new System.Drawing.Size(482, 28);
//			this.tbMain.TabIndex = 1;
//			this.tbMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbMain_ButtonClick);
//			// 
//			// btnAddNew
//			// 
//			this.btnAddNew.ImageIndex = 0;
//			this.btnAddNew.Tag = "New";
//			this.btnAddNew.ToolTipText = "Create new Signature";
//			// 
//			// btnEdit
//			// 
//			this.btnEdit.ImageIndex = 1;
//			this.btnEdit.Tag = "Edit";
//			this.btnEdit.ToolTipText = "Edit signature";
//			// 
//			// btnDelete
//			// 
//			this.btnDelete.ImageIndex = 2;
//			this.btnDelete.Tag = "Delete";
//			this.btnDelete.ToolTipText = "Delete signature";
//			// 
//			// btnExport
//			// 
//			this.btnExport.ImageIndex = 4;
//			this.btnExport.Tag = "Export";
//			this.btnExport.ToolTipText = "Export signature list";
//			// 
//			// btnImport
//			// 
//			this.btnImport.ImageIndex = 5;
//			this.btnImport.Tag = "Import";
//			this.btnImport.ToolTipText = "Import signature list";
//			// 
//			// imglToolBar
//			// 
//			this.imglToolBar.ImageSize = new System.Drawing.Size(16, 16);
//			this.imglToolBar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglToolBar.ImageStream")));
//			this.imglToolBar.TransparentColor = System.Drawing.Color.Transparent;
//			// 
//			// lvMaster
//			// 
//			this.lvMaster.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
//																					   this.colSignatureName,
//																					   this.colDesc});
//			this.lvMaster.ContextMenu = this.contextMenu1;
//			this.lvMaster.FullRowSelect = true;
//			this.lvMaster.GridLines = true;
//			this.lvMaster.Location = new System.Drawing.Point(0, 28);
//			this.lvMaster.Name = "lvMaster";
//			this.lvMaster.Size = new System.Drawing.Size(480, 352);
//			this.lvMaster.TabIndex = 4;
//			this.lvMaster.View = System.Windows.Forms.View.Details;
//			this.lvMaster.DoubleClick += new System.EventHandler(this.lvMaster_DoubleClick);
//			// 
//			// colSignatureName
//			// 
//			this.colSignatureName.Text = "Signature Name";
//			this.colSignatureName.Width = 193;
//			// 
//			// colDesc
//			// 
//			this.colDesc.Text = "Description";
//			this.colDesc.Width = 282;
//			// 
//			// contextMenu1
//			// 
//			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
//																						 this.mnNewSignature,
//																						 this.mnEditSig,
//																						 this.mnDelete,
//																						 this.menuItem1,
//																						 this.mnImport,
//																						 this.mnExport});
//			// 
//			// mnNewSignature
//			// 
//			this.mnNewSignature.Index = 0;
//			this.mnNewSignature.Text = "New";
//			this.mnNewSignature.Click += new System.EventHandler(this.mnNewSignature_Click);
//			// 
//			// mnEditSig
//			// 
//			this.mnEditSig.Index = 1;
//			this.mnEditSig.Text = "Edit";
//			this.mnEditSig.Click += new System.EventHandler(this.mnEditSig_Click);
//			// 
//			// mnDelete
//			// 
//			this.mnDelete.Index = 2;
//			this.mnDelete.Text = "Delete";
//			this.mnDelete.Click += new System.EventHandler(this.mnDelete_Click);
//			// 
//			// mnImport
//			// 
//			this.mnImport.Index = 4;
//			this.mnImport.Text = "Import";
//			this.mnImport.Click += new System.EventHandler(this.mnImport_Click);
//			// 
//			// mnExport
//			// 
//			this.mnExport.Index = 5;
//			this.mnExport.Text = "Export";
//			this.mnExport.Click += new System.EventHandler(this.mnExport_Click);
//			// 
//			// btnCancel
//			// 
//			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
//			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
//			this.btnCancel.Location = new System.Drawing.Point(396, 392);
//			this.btnCancel.Name = "btnCancel";
//			this.btnCancel.TabIndex = 8;
//			this.btnCancel.Text = "Cancel";
//			// 
//			// btnOK
//			// 
//			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
//			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
//			this.btnOK.Location = new System.Drawing.Point(312, 392);
//			this.btnOK.Name = "btnOK";
//			this.btnOK.TabIndex = 7;
//			this.btnOK.Text = "OK";
//			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
//			// 
//			// _imgListToolBar
//			// 
//			this._imgListToolBar.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
//			this._imgListToolBar.ImageSize = new System.Drawing.Size(16, 16);
//			this._imgListToolBar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imgListToolBar.ImageStream")));
//			this._imgListToolBar.TransparentColor = System.Drawing.Color.Transparent;
//			// 
//			// menuItem1
//			// 
//			this.menuItem1.Index = 3;
//			this.menuItem1.Text = "-";
//			// 
//			// toolBarButton1
//			// 
//			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
//			// 
//			// DlgSignatureCategory
//			// 
//			this.AcceptButton = this.btnOK;
//			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
//			this.CancelButton = this.btnCancel;
//			this.ClientSize = new System.Drawing.Size(482, 423);
//			this.Controls.Add(this.btnCancel);
//			this.Controls.Add(this.btnOK);
//			this.Controls.Add(this.lvMaster);
//			this.Controls.Add(this.tbMain);
//			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
//			this.MaximizeBox = false;
//			this.MinimizeBox = false;
//			this.Name = "DlgSignatureCategory";
//			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
//			this.Text = "Signature Category";
//			this.ResumeLayout(false);
//
//		}
//		#endregion
//
//		#region UI Command
//
//		private void InitService()
//		{
//			if(AppData.Data.UseWebService)
//				_SigService = WebServiceProxy.WebProxyFactory.CreateCategory();
//			else
//				_SigService1 = new SiGlaz.DDA.Business.Category();
//		}
//
//		private void AddSignatureToListView(WebServiceProxy.CategoryProxy.Signature sig)
//		{
//			ListViewItem item = new ListViewItem(sig.SignatureName.ToString());			
//			//item.SubItems.Add(sig.SignatureName);		
//			item.SubItems.Add(sig.SignatureDescription);
//			item.Tag = sig;
//			lvMaster.Items.Add(item);
//		}
//
//		private void UpdateSignatureToListView(WebServiceProxy.CategoryProxy.Signature sig,int index)
//		{
//			this.lvMaster.Items[index].SubItems[0].Text = sig.SignatureName;
//			this.lvMaster.Items[index].SubItems[1].Text = sig.SignatureDescription;			
//		}
//
//		public void LoadSignatureList()
//		{
//			InitService();
//
//			if(AppData.Data.UseWebService)
//			{
//				if (_SigService != null)
//				{
//					try
//					{
//						WebServiceProxy.CategoryProxy.SignatureListResult _SigCollection = null;
//						lvMaster.Items.Clear();
//						_SigCollection = _SigService.SignatureList();
//
//						if (_SigCollection != null && _SigCollection.signature != null && _SigCollection.signature.Length > 0)
//						{
//							foreach(WebServiceProxy.CategoryProxy.Signature sig in _SigCollection.signature)
//							{		
//								if ( 
//									sig.SignatureName.ToUpper() != "Unknown".ToUpper()
//									&& sig.SignatureName.ToUpper() != "No-Signature".ToUpper()
//									&& sig.SignatureName.ToUpper() != "Empty".ToUpper()
//									)
//									AddSignatureToListView(sig);
//							}
//						}
//					}
//					catch (System.Exception e)
//					{
//						MessageBox.Show(e.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
//					}
//				}
//			}
//			else
//			{
//				if (_SigService1 != null)
//				{
//					try
//					{
//						SiGlaz.Common.DDA.Result.SignatureListResult _SigCollection = null;
//						lvMaster.Items.Clear();
//						_SigCollection = _SigService1.SignatureList();
//
//						if (_SigCollection != null && _SigCollection.signature != null && _SigCollection.signature.Count > 0)
//						{
//							foreach(SiGlaz.Common.DDA.Signature sig in _SigCollection.signature)
//							{					
//								WebServiceProxy.CategoryProxy.Signature sig1 = WebServiceProxy.ConvertProxy.Convert(sig,typeof(WebServiceProxy.CategoryProxy.Signature)) as WebServiceProxy.CategoryProxy.Signature;
//
//								if (sig1.SignatureName.ToUpper() != "Unknown".ToUpper())
//									AddSignatureToListView(sig1);							
//							}
//						}
//					}
//					catch (System.Exception e)
//					{
//						MessageBox.Show(e.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
//					}
//				}
//			}
//		}
//
//		public void NewSignature()
//		{
//			//_SigCollection			
//			DlgSignatureCategoryItemDefine dlg = new DlgSignatureCategoryItemDefine(null);
//			if (dlg.ShowDialog(this) == DialogResult.OK)
//			{
//				this.AddSignatureToListView(dlg.Sig);
//			}
//		}
//
//		public void EditSignature()
//		{
//			if (lvMaster.SelectedItems.Count > 0)
//			{
//				if(AppData.Data.UseWebService)
//				{
//					WebServiceProxy.CategoryProxy.Signature sig =  lvMaster.SelectedItems[0].Tag as WebServiceProxy.CategoryProxy.Signature;
//					DlgSignatureCategoryItemDefine dlg = new DlgSignatureCategoryItemDefine(sig);
//					if	(dlg.ShowDialog(this) == DialogResult.OK)
//					{
//						// Update Db
//						_SigService.SignatureUpdate(dlg.Sig,dlg.Sig.SCKey);
//						//Update listview
//						this.UpdateSignatureToListView(dlg.Sig,lvMaster.SelectedItems[0].Index);
//					}
//				}
//				else
//				{
//					WebServiceProxy.CategoryProxy.Signature sig =  lvMaster.SelectedItems[0].Tag as WebServiceProxy.CategoryProxy.Signature;
//					DlgSignatureCategoryItemDefine dlg = new DlgSignatureCategoryItemDefine(sig);
//					if	(dlg.ShowDialog(this) == DialogResult.OK)
//					{
//						SiGlaz.Common.DDA.Signature sig1 = WebServiceProxy.ConvertProxy.Convert(dlg.Sig,typeof(SiGlaz.Common.DDA.Signature)) as SiGlaz.Common.DDA.Signature;
//						// Update Db
//						_SigService1.SignatureUpdate(sig1,dlg.Sig.SCKey);
//						//Update listview
//						this.UpdateSignatureToListView(dlg.Sig,lvMaster.SelectedItems[0].Index);
//					}
//				}
//			}
//			else
//				MessageBox.Show("Please select at least one item.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
//		}
//
//		public void DeleteSignature()
//		{
//			if(lvMaster.SelectedItems.Count < 0) return;
//
//			// Ask here  ...
//			if(MessageBox.Show("Do you want to delete selected Signature ?",Application.ProductName ,MessageBoxButtons.YesNo,MessageBoxIcon.Question)!= DialogResult.Yes)
//				return;
//
//			for(int i=0;i<lvMaster.Items.Count;i++)
//			{
//				if(lvMaster.Items[i].Selected)
//				{
//					WebServiceProxy.CategoryProxy.Signature sig =  lvMaster.SelectedItems[0].Tag as WebServiceProxy.CategoryProxy.Signature;
//	
//					// Delete in Db
//					if( AppData.Data.UseWebService)
//					{
//						WebServiceProxy.CategoryProxy.ResultBase result = _SigService.SignatureDelete(sig.SCKey);
//
//						if (result.Code == WebServiceProxy.CategoryProxy.ErrorCode.OK)
//							lvMaster.Items.RemoveAt(i--);
//						else
//							MessageBox.Show(string.Format("{0}: {1}", result.Code, result.Description), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
//					}
//					else
//					{
//						SiGlaz.Common.DDA.Result.ResultBase result = _SigService1.SignatureDelete(sig.SCKey);
//
//						if (result.Code == ErrorCode.OK)
//							lvMaster.Items.RemoveAt(i--);
//						else
//							MessageBox.Show(string.Format("{0}: {1}", result.Code, result.Description), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
//					}
//
//					
//				}
//			}
//		}
//		public void DeleteAll()
//		{
//			if(MessageBox.Show("Do you want to delete selected Signature ?",Application.ProductName ,MessageBoxButtons.YesNo,MessageBoxIcon.Question)!= DialogResult.Yes)
//				return;
//			lvMaster.Items.Clear();
//		}
//
//		private void SaveAll()
//		{	
//			if( AppData.Data.UseWebService)
//			{
//				foreach(ListViewItem item in lvMaster.Items)
//				{				
//					WebServiceProxy.CategoryProxy.Signature sig =  item.Tag as WebServiceProxy.CategoryProxy.Signature;
//					_SigService.SignatureInsert(sig);				
//				}
//			}
//			else
//			{
//				foreach(ListViewItem item in lvMaster.Items)
//				{				
//					WebServiceProxy.CategoryProxy.Signature sig =  item.Tag as WebServiceProxy.CategoryProxy.Signature;
//					SiGlaz.Common.DDA.Signature sig1 = WebServiceProxy.ConvertProxy.Convert(sig,typeof(SiGlaz.Common.DDA.Signature)) as SiGlaz.Common.DDA.Signature;
//					_SigService1.SignatureInsert(sig1);				
//				}
//			}
//		}
//
//		private bool CheckSignatureNameExistInListView(string signatureName)
//		{
//			foreach (ListViewItem item in lvMaster.Items)
//			{
//				if (item.Text.ToLower() == signatureName.ToLower())
//					return true;
//			}
//
//			return false;
//		}
//
//		private void ImportSignature()
//		{
//			Cursor.Current = Cursors.WaitCursor;
//
//			OpenFileDialog dlg = new OpenFileDialog();
//			dlg.Title = "Import";
//			dlg.Filter = "(*.xls)|*.xls";
//
//			if (dlg.ShowDialog(this) == DialogResult.OK)
//			{
//				OleDbConnection connection = null;
//				OleDbCommand cmd = null;
//				OleDbDataReader reader = null;
//				String excelFileName = dlg.FileName;
//				bool isCorrectFormat = false;
//
//				try
//				{
//					connection = new OleDbConnection(String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";", excelFileName));
//					connection.Open();
//
//					DataTable dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] {null, null, null, "TABLE"});
//
//					String sheetName = "'Signature List$'";
//
//					if ( dt != null )
//					{
//						for ( int i = 0; i < dt.Rows.Count; ++i )
//						{
//							if ( dt.Rows[i]["TABLE_NAME"].ToString().ToLower().CompareTo(sheetName.ToLower()) == 0 )
//							{
//								isCorrectFormat = true;
//								break;
//							}
//						}
//					}
//
//					if ( !isCorrectFormat )
//					{
//						MessageBox.Show(this, "Failed to import signature list from Excel.\r\nError: The Excel file is in invalid format.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
//						return;
//					}
//				
//					cmd = connection.CreateCommand();
//					cmd.CommandType = CommandType.Text;
//					cmd.CommandText  = String.Format("SELECT * FROM [{0}]", sheetName);
//					reader = cmd.ExecuteReader();
//
//					while ( reader.Read() )
//					{
//						if (reader[0] != DBNull.Value && reader[0] != null)
//						{
//							string signatureName = reader[0].ToString();
//							string description = string.Empty;
//
//							if (reader[1] != DBNull.Value && reader[1] != null)
//								description = reader[1].ToString();
//
//							if (!CheckSignatureNameExistInListView(signatureName))
//							{
//								WebServiceProxy.CategoryProxy.Signature sig = new WebServiceProxy.CategoryProxy.Signature();
//								sig.SignatureName = signatureName;
//								sig.SignatureDescription = description;
//
//								if( AppData.Data.UseWebService)
//									sig.SCKey = (int)_SigService.SignatureInsert(sig);				
//								else
//								{
//									SiGlaz.Common.DDA.Signature sig1 = WebServiceProxy.ConvertProxy.Convert(sig,typeof(SiGlaz.Common.DDA.Signature)) as SiGlaz.Common.DDA.Signature;
//									sig.SCKey = (int)_SigService1.SignatureInsert(sig1);				
//								}
//
//								ListViewItem item = new ListViewItem(signatureName);
//								item.SubItems.Add(description);
//								item.Tag = sig;
//								lvMaster.Items.Add(item);
//							}
//						}
//					}
//
//					MessageBox.Show(this, "Importing signature list from Excel completed successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
//				}
//				catch (Exception ex)
//				{
//					MessageBox.Show(this, String.Format("Failed to import signature list from Excel.\r\nError:\r\n{0}", ex.Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
//				}
//				finally
//				{
//					if ( reader != null )
//					{
//						reader.Close();
//						reader = null;
//					}
//
//					if ( cmd != null )
//					{
//						cmd.Dispose();
//						cmd = null;
//					}
//
//					if ( connection != null )
//					{
//						connection.Close();
//						connection.Dispose();
//						connection = null;
//					}
//				}
//			}
//		}
//
//		private void InitHeader(IWorksheet workSheet)
//		{
//			int colIndex = 0;
//			int rowIndex = 0;
//			IRange range = null;
//			
//			workSheet.Name = "Signature List";
//
//			range = workSheet.Cells[rowIndex, colIndex++];
//			SetCellInfo(range, "Signature Name", HAlign.Center, VAlign.Center, Color.Blue, 10, true, Color.Yellow, 30, true);
//
//			range = workSheet.Cells[rowIndex, colIndex++];
//			SetCellInfo(range, "Description", HAlign.Center, VAlign.Center, Color.Blue, 10, true, Color.Yellow, 40, true);
//		}
//
//		private void FillSignatureList(IWorksheet workSheet)
//		{
//			int rowIndex = 1;
//			int colIndex = 0;
//			IRange range = null;
//
//			foreach (ListViewItem item in lvMaster.Items)
//			{
//				colIndex = 0;
//				range = workSheet.Cells[rowIndex, colIndex++];
//				SetCellInfo(range, item.Text, HAlign.Center, VAlign.Center, Color.Black, 10, false, Color.White, 30, true);
//
//				range = workSheet.Cells[rowIndex, colIndex++];
//				SetCellInfo(range, item.SubItems[1].Text, HAlign.Center, VAlign.Center, Color.Black, 10, false, Color.White, 30, true);
//
//				rowIndex ++;
//			}
//		}
//
//		private void ExportSignature()
//		{
//			if (lvMaster.Items.Count > 0)
//			{
//				SaveFileDialog dlg = new SaveFileDialog();
//				dlg.Title = "Export";
//				dlg.Filter = "(*.xls)|*.xls";
//
//				if (dlg.ShowDialog(this) == DialogResult.OK)
//				{
//					Cursor.Current = Cursors.WaitCursor;
//					IWorkbook workBook = SpreadsheetGear.Factory.GetWorkbook();
//
//					try
//					{
//						SetCulturalWithEN_US();
//						InitHeader(workBook.Worksheets[0]);
//						FillSignatureList(workBook.Worksheets[0]);
//
//						workBook.SaveAs(dlg.FileName, FileFormat.XLS97);
//
//						MessageBox.Show("Export signature list successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
//					}
//					catch (System.Exception e)
//					{
//						MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
//					}
//					finally
//					{
//						SetCulturalWithCurrent();
//						workBook.Close();
//						workBook = null;
//					}
//				}
//			}
//		}
//
//		private void SetCulturalWithEN_US()
//		{
//			if(_currentCultural.Name != "en-US")
//				System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
//		}
//
//		private void SetCulturalWithCurrent()
//		{
//			if( _currentCultural.Name != "en-US")
//				System.Threading.Thread.CurrentThread.CurrentCulture = _currentCultural;	
//		}
//
//		private void SetCellInfo(IRange range, object value, HAlign hAlign, VAlign vAlign, Color fontColor, double fontSize, bool bold, Color backColor, double colWidth, bool hasWrapText)
//		{
//			range.Borders.Color = Color.Black;
//			range.Borders.Weight = SpreadsheetGear.BorderWeight.Thin;
//			range.Borders.LineStyle = SpreadsheetGear.LineStyle.Continuous;
//			range.HorizontalAlignment = hAlign;
//			range.VerticalAlignment = vAlign;
//			range.Font.Color = fontColor;
//			range.Font.Size = fontSize;
//			range.Font.Bold = bold;
//			range.Interior.Color = backColor;
//			range.ColumnWidth = colWidth;
//			range.Value = value;
//			range.WrapText = hasWrapText;
//		}
//		#endregion
//		
//		#region Windows Events Handles
//		private void tbMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
//		{
//			switch ( e.Button.Tag.ToString().ToUpper())
//			{
//				case "NEW":
//					NewSignature();
//					break;
//
//				case "EDIT":
//					EditSignature();
//					break;
//
//				case "DELETE":
//					DeleteSignature();
//					break;				
//
//				case "IMPORT":
//					ImportSignature();
//					break;
//
//				case "EXPORT":
//					ExportSignature();
//					break;
//			}   
//		}
//
//		private void mnNewSignature_Click(object sender, System.EventArgs e)
//		{
//			NewSignature();
//		}
//
//		private void mnEditSig_Click(object sender, System.EventArgs e)
//		{
//			EditSignature();
//		}
//
//		private void mnDelete_Click(object sender, System.EventArgs e)
//		{
//			DeleteSignature();
//		}
//		private void lvMaster_DoubleClick(object sender, System.EventArgs e)
//		{
//			EditSignature();
//		}
//
//		private void btnOK_Click(object sender, System.EventArgs e)
//		{
//			SaveAll();
//		}
//		private void mnImport_Click(object sender, System.EventArgs e)
//		{
//			ImportSignature();
//		}
//
//		private void mnExport_Click(object sender, System.EventArgs e)
//		{
//			ExportSignature();
//		}
//		#endregion	
//	}
//}
