using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Const;
using SiGlaz.Common.DDA.Basic;
using SiGlaz.Common.DDA.Recipe;
using SiGlaz.Common.DDA.Result;
using DDANavigator.Dialogs;
using SSA.SystemFrameworks;
using SiGlaz.SharedMemory;
using SiGlaz.Export.Excel;

namespace DDANavigator.Controls
{
	public class ctrlTableView : ctrlBase
	{
		#region Members
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbPageCount;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numPageIndex;
		private System.Windows.Forms.Button btnNextTop;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.Button btnBackTop;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList _imgList;
		private int _pageCount = 0;
		private int _rowCount = 0;
		private DataSourceRecipe _dataSource = null;
		private SingleLayerRecipe _singleLayer = null;
		private FunctionType _type = FunctionType.DataSource;
		private bool _hasData = false;
		private System.Windows.Forms.ComboBox cboSurface;
		private System.Windows.Forms.RadioButton raFlat;
		private System.Windows.Forms.RadioButton raPolar;
        private int _rowIndex = -1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button btnExport;
		private int _columnIndex = -1;
		private System.Windows.Forms.Label lbSurfaceView;
		private string _exportFileName = string.Empty;
		private int _maxSignature = 0;
		private ExportType _exportType = ExportType.DataAndImage;
        private DataGridView dgData;
        private ContextMenuStrip contextMenuStripDetail;
        private ToolStripMenuItem viewDataWithDDAToolStripMenuItem;
		public string SqlWhere =  string.Empty;
		#endregion
		
		#region Constructor & Destructor
		public ctrlTableView()
		{
			InitializeComponent();
			cboSurface.SelectedIndex = 0;
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.raFlat = new System.Windows.Forms.RadioButton();
            this.raPolar = new System.Windows.Forms.RadioButton();
            this.cboSurface = new System.Windows.Forms.ComboBox();
            this.lbSurfaceView = new System.Windows.Forms.Label();
            this.lbPageCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numPageIndex = new System.Windows.Forms.NumericUpDown();
            this.btnNextTop = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnBackTop = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgData = new System.Windows.Forms.DataGridView();
            this._imgList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStripDetail = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewDataWithDDAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPageIndex)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
            this.contextMenuStripDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.raFlat);
            this.panel1.Controls.Add(this.raPolar);
            this.panel1.Controls.Add(this.cboSurface);
            this.panel1.Controls.Add(this.lbSurfaceView);
            this.panel1.Controls.Add(this.lbPageCount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numPageIndex);
            this.panel1.Controls.Add(this.btnNextTop);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnBackTop);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 360);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 32);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnExport);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(800, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(108, 32);
            this.panel3.TabIndex = 50;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(8, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(92, 23);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "&Export to Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // raFlat
            // 
            this.raFlat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.raFlat.Location = new System.Drawing.Point(564, 8);
            this.raFlat.Name = "raFlat";
            this.raFlat.Size = new System.Drawing.Size(68, 20);
            this.raFlat.TabIndex = 49;
            this.raFlat.Text = "Flat";
            // 
            // raPolar
            // 
            this.raPolar.Checked = true;
            this.raPolar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.raPolar.Location = new System.Drawing.Point(496, 8);
            this.raPolar.Name = "raPolar";
            this.raPolar.Size = new System.Drawing.Size(68, 20);
            this.raPolar.TabIndex = 48;
            this.raPolar.TabStop = true;
            this.raPolar.Text = "Disk";
            this.raPolar.CheckedChanged += new System.EventHandler(this.raPolar_CheckedChanged);
            // 
            // cboSurface
            // 
            this.cboSurface.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSurface.Items.AddRange(new object[] {
            "ALL",
            "TOP",
            "BOTTOM"});
            this.cboSurface.Location = new System.Drawing.Point(388, 6);
            this.cboSurface.Name = "cboSurface";
            this.cboSurface.Size = new System.Drawing.Size(92, 21);
            this.cboSurface.TabIndex = 47;
            this.cboSurface.SelectedIndexChanged += new System.EventHandler(this.cboSurface_SelectedIndexChanged);
            // 
            // lbSurfaceView
            // 
            this.lbSurfaceView.AutoSize = true;
            this.lbSurfaceView.Location = new System.Drawing.Point(340, 11);
            this.lbSurfaceView.Name = "lbSurfaceView";
            this.lbSurfaceView.Size = new System.Drawing.Size(47, 13);
            this.lbSurfaceView.TabIndex = 46;
            this.lbSurfaceView.Text = "Surface:";
            // 
            // lbPageCount
            // 
            this.lbPageCount.AutoSize = true;
            this.lbPageCount.Location = new System.Drawing.Point(276, 12);
            this.lbPageCount.Name = "lbPageCount";
            this.lbPageCount.Size = new System.Drawing.Size(13, 13);
            this.lbPageCount.TabIndex = 45;
            this.lbPageCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "of";
            // 
            // numPageIndex
            // 
            this.numPageIndex.Enabled = false;
            this.numPageIndex.Location = new System.Drawing.Point(108, 8);
            this.numPageIndex.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.numPageIndex.Name = "numPageIndex";
            this.numPageIndex.Size = new System.Drawing.Size(80, 20);
            this.numPageIndex.TabIndex = 43;
            this.numPageIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnNextTop
            // 
            this.btnNextTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNextTop.Location = new System.Drawing.Point(224, 8);
            this.btnNextTop.Name = "btnNextTop";
            this.btnNextTop.Size = new System.Drawing.Size(28, 20);
            this.btnNextTop.TabIndex = 42;
            this.btnNextTop.Text = ">>";
            this.btnNextTop.Click += new System.EventHandler(this.btnNextTop_Click);
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNext.Location = new System.Drawing.Point(192, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(28, 20);
            this.btnNext.TabIndex = 41;
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBack.Location = new System.Drawing.Point(76, 8);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(28, 20);
            this.btnBack.TabIndex = 40;
            this.btnBack.Text = "<";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnBackTop
            // 
            this.btnBackTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBackTop.Location = new System.Drawing.Point(44, 8);
            this.btnBackTop.Name = "btnBackTop";
            this.btnBackTop.Size = new System.Drawing.Size(28, 20);
            this.btnBackTop.TabIndex = 39;
            this.btnBackTop.Text = "<<";
            this.btnBackTop.Click += new System.EventHandler(this.btnBackTop_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Page:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(908, 360);
            this.panel2.TabIndex = 1;
            // 
            // dgData
            // 
            this.dgData.AllowUserToAddRows = false;
            this.dgData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgData.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgData.Location = new System.Drawing.Point(0, 0);
            this.dgData.MultiSelect = false;
            this.dgData.Name = "dgData";
            this.dgData.ReadOnly = true;
            this.dgData.RowHeadersVisible = false;
            this.dgData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgData.Size = new System.Drawing.Size(908, 360);
            this.dgData.TabIndex = 6;
            this.dgData.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgData_CellMouseDown);
            this.dgData.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgData_CellMouseMove);
            this.dgData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgData_CellMouseDoubleClick);
            // 
            // _imgList
            // 
            this._imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this._imgList.ImageSize = new System.Drawing.Size(100, 100);
            this._imgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenuStripDetail
            // 
            this.contextMenuStripDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewDataWithDDAToolStripMenuItem});
            this.contextMenuStripDetail.Name = "contextMenuStripDetail";
            this.contextMenuStripDetail.Size = new System.Drawing.Size(180, 26);
            // 
            // viewDataWithDDAToolStripMenuItem
            // 
            this.viewDataWithDDAToolStripMenuItem.Name = "viewDataWithDDAToolStripMenuItem";
            this.viewDataWithDDAToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.viewDataWithDDAToolStripMenuItem.Text = "View data with DDA";
            this.viewDataWithDDAToolStripMenuItem.Click += new System.EventHandler(this.viewDataWithDDAToolStripMenuItem_Click);
            // 
            // ctrlTableView
            // 
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ctrlTableView";
            this.Size = new System.Drawing.Size(908, 392);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numPageIndex)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
            this.contextMenuStripDetail.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Properties
		public bool HasData
		{
			get { return _hasData; }
			set { _hasData = value; }
		}

		public bool ShowHideSurfaceView
		{
			set
			{
				lbSurfaceView.Visible = value;
				cboSurface.Visible = value;
			}
		}
		#endregion

		#region UI Command
        private DataGridViewImageColumn CreateDataGridViewImageColumn(string name, int width)
        {
            DataGridViewImageColumn col = new DataGridViewImageColumn();
            col.HeaderText = name;
            col.Width = 105;
            col.SortMode = DataGridViewColumnSortMode.NotSortable;
            return col;
        }

        private DataGridViewTextBoxColumn CreateDataGridViewTextBoxColumn(string name, int width, DataGridViewContentAlignment align, bool isNumeric)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = name;
            col.Width = width;
            col.SortMode = DataGridViewColumnSortMode.Automatic;
            col.DefaultCellStyle.Alignment = align;
            if (isNumeric) col.ValueType = typeof(double);
            return col;
        }

		private void InitTable(FunctionType type)
		{
            dgData.Rows.Clear();

			switch (type)
			{
				case FunctionType.SingleLayer:
					Init_SingleLayer_Table();
					break;

				case FunctionType.DataSource:
					Init_DataSource_Table();
					break;

				case FunctionType.SourceOfDisk:
					Init_SourceOfDisk();
					break;
			}
		}

		private void Init_SourceOfDisk()
		{
            //Clear Data Grid View
            dgData.Rows.Clear();
            dgData.Columns.Clear();

            //Add Source Top Thumbnail
            DataGridViewImageColumn dataGridViewCol = CreateDataGridViewImageColumn("Top Thumbnail", 100);
            dgData.Columns.Add(dataGridViewCol);

            //Add Source Bottom Thumbnail
            dataGridViewCol = CreateDataGridViewImageColumn("Bottom Thumbnail", 100);
            dgData.Columns.Add(dataGridViewCol);

            foreach (string columnName in _dataSource.TableLayout.DisplayColumns)
            {
                DataGridViewTextBoxColumn gridViewCol = CreateDataGridViewTextBoxColumn(columnName, 150,
                    DataGridViewContentAlignment.MiddleCenter, WaferConst.IsNumericColumn(columnName));
                dgData.Columns.Add(gridViewCol);
            }

            dgData.ContextMenuStrip = contextMenuStripDetail;
		}

		private void Init_DataSource_Table()
		{
            //Clear Data Grid View
            dgData.Rows.Clear();
            dgData.Columns.Clear();

            //Add Source Thumbnail
            DataGridViewImageColumn dataGridViewCol = CreateDataGridViewImageColumn("Source Thumbnail", 100);
            dgData.Columns.Add(dataGridViewCol);

            foreach (string columnName in _dataSource.TableLayout.DisplayColumns)
            {
                DataGridViewTextBoxColumn gridViewCol = CreateDataGridViewTextBoxColumn(columnName, 150,
                    DataGridViewContentAlignment.MiddleCenter, WaferConst.IsNumericColumn(columnName));
                dgData.Columns.Add(gridViewCol);
            }

            dgData.ContextMenuStrip = contextMenuStripDetail;
		}

		private void Init_SingleLayer_Table()
		{
            //Clear Data Grid View
            dgData.Rows.Clear();
            dgData.Columns.Clear();

            //Add Source Thumbnail
            DataGridViewImageColumn dataGridViewCol = CreateDataGridViewImageColumn("Source Thumbnail", 100);
            dgData.Columns.Add(dataGridViewCol);

            //Add Result Thumbnail
            dataGridViewCol = CreateDataGridViewImageColumn("Result Thumbnail", 100);
            dgData.Columns.Add(dataGridViewCol);

            foreach (string columnName in _singleLayer.TableLayout.DisplayColumns)
            {
                DataGridViewTextBoxColumn gridViewCol = CreateDataGridViewTextBoxColumn(columnName, 150,
                    DataGridViewContentAlignment.MiddleCenter, WaferConst.IsNumericColumn(columnName));
                dgData.Columns.Add(gridViewCol);
            }

            dgData.ContextMenuStrip = contextMenuStripDetail;
		}

		private void Init_SignatureOfSurface_Table(DataTable result, int maxSignature)
		{
            //Clear Data Grid View
            dgData.Rows.Clear();
            dgData.Columns.Clear();

            //Add Source Thumbnail
            DataGridViewImageColumn dataGridViewCol = CreateDataGridViewImageColumn("Source Thumbnail", 100);
            dgData.Columns.Add(dataGridViewCol);

            for (int i = 1; i <= maxSignature; i++)
            {
                dataGridViewCol = CreateDataGridViewImageColumn(string.Format("Signature {0}", i), 100);
                dgData.Columns.Add(dataGridViewCol);
            }

            foreach (string columnName in _singleLayer.TableLayout.DisplayColumns)
            {
                DataGridViewTextBoxColumn gridViewCol = CreateDataGridViewTextBoxColumn(columnName, 150,
                    DataGridViewContentAlignment.MiddleCenter, WaferConst.IsNumericColumn(columnName));
                dgData.Columns.Add(gridViewCol);
            }

            dgData.ContextMenuStrip = contextMenuStripDetail;
		}

		public void RefreshData(DataSourceRecipe dataSource, FunctionType type)
		{
			_hasData = false;
			if(dataSource == null) return;
			_dataSource = dataSource;
			_type = type;

            MethodInvoker invoke = delegate
            {
                if (type == FunctionType.DataSource)
                    _dataSource.ViewSurface = (ViewSurface)cboSurface.SelectedIndex;

                dgData.Rows.Clear();
                _imgList.Images.Clear();
                Size size = new Size(100, 100);
                size = new Size(100, 100);
                _imgList.ImageSize = size;
                numPageIndex.Value = 0;
                lbPageCount.Text = "0";

                if (!CheckLimitRecord(type))
                {
                    _hasData = true;
                    return;
                }

                InitTable(_type);
                DisplayDataByPageIndex(1);

                dgData.Tag = _type;
            };

            BeginInvoke(invoke);
		}

		private bool CheckLimitRecord(FunctionType type)
		{
			bool result = true;
			int totalRow = 0;
			WebServiceProxy.SourceProxy.Source sourceService = null;
			WebServiceProxy.SingleLayerProxy.SingleLayer singleLayerService = null;

			switch (type)
			{
				case FunctionType.DataSource:
					sourceService = WebServiceProxy.WebProxyFactory.CreateSource();
					totalRow = (int)sourceService.GetTotalRow_SurfaceOfDisk(_dataSource.QueryCondition.GetConditionString(), (WebServiceProxy.SourceProxy.DDADBType)AppData.Data.DBType).id64;
					break;

				case FunctionType.SourceOfDisk:
					sourceService = WebServiceProxy.WebProxyFactory.CreateSource();
					totalRow = (int)sourceService.GetTotalRow_SourceOfDisk(_dataSource.QueryCondition.GetConditionString(), (WebServiceProxy.SourceProxy.DDADBType)AppData.Data.DBType).id64;	
					break;

				case FunctionType.SingleLayer:
					singleLayerService = WebServiceProxy.WebProxyFactory.CreateSingleLayer();
					totalRow = (int)singleLayerService.GetTotalRow_SingleLayer(_singleLayer.QueryCondition.GetConditionString(), (WebServiceProxy.SingleLayerProxy.DDADBType)AppData.Data.DBType).id64;
					break;

				case FunctionType.SignatureOfSurface:
					singleLayerService = WebServiceProxy.WebProxyFactory.CreateSingleLayer();
					totalRow = (int)singleLayerService.GetTotalRow_SurfaceHasSignature(_singleLayer.QueryCondition.GetConditionString(), (WebServiceProxy.SingleLayerProxy.DDADBType)AppData.Data.DBType).id64;
					break;
			}

			if (totalRow > AppData.Data.MaxRow)
			{
				result = false;
				MessageBox.Show(string.Format("The query rows as {0} exceeds Limit Records as {1}. Please reset conditions to query data.", totalRow, AppData.Data.MaxRow), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			return result;
		}

		public void RefreshData(SingleLayerRecipe singleLayer, FunctionType type)
		{
			_hasData = false;
			if(singleLayer == null) return;
			_singleLayer = singleLayer;
			_type = type;

            MethodInvoker invoke = delegate
            {
                _singleLayer.ViewSurface = (ViewSurface)cboSurface.SelectedIndex;

                dgData.Rows.Clear();
                _imgList.Images.Clear();
                Size size = new Size(100, 100);

                switch (_type)
                {
                    case FunctionType.SingleLayer:
                        size = new Size(100, 100);
                        break;
                    case FunctionType.SignatureOfSurface:
                        size = new Size(100, 120);
                        break;
                }

                _imgList.ImageSize = size;
                numPageIndex.Value = 0;
                lbPageCount.Text = "0";

                if (!CheckLimitRecord(type))
                {
                    _hasData = true;
                    return;
                }

                InitTable(_type);
                DisplayDataByPageIndex(1);

                dgData.Tag = _type;
            };

            BeginInvoke(invoke);
		}

		private void DisplayDataByPageIndex(int index)
		{
			Cursor.Current = Cursors.WaitCursor;
			DataTable dtResult = GetData(index);

            dgData.Rows.Clear();
			_imgList.Images.Clear();

			if (dtResult != null)
			{
				if (dtResult.Rows.Count > 0)
				{
					_hasData = true;
					numPageIndex.Value = index;
				}

				lbPageCount.Text = _pageCount.ToString();

				switch (_type)
				{
					case FunctionType.SingleLayer:
						AddData_SingleLayer(dtResult);
						break;
					case FunctionType.DataSource:
						AddData_DataSource(dtResult);
						break;
					case FunctionType.SignatureOfSurface:
						AddData_SignatureOfSurface(dtResult);
						break;

					case FunctionType.SourceOfDisk:
						AddData_SourceOfDisk(dtResult);
						break;
				}
			}
			Cursor.Current = Cursors.Default;
		}

		private DataTable GetData(int index)
		{
			DataTable dtResult = null;

			try
			{
				switch (_type)
				{
					case FunctionType.DataSource:
						_dataSource.TableLayout.PageIndex = index;
					
						WebServiceProxy.SourceProxy.DataSourceRecipe sourceParam = (WebServiceProxy.SourceProxy.DataSourceRecipe)WebServiceProxy.ConvertProxy.Convert(_dataSource, typeof(WebServiceProxy.SourceProxy.DataSourceRecipe));
						WebServiceProxy.SourceProxy.Source sourceService = WebServiceProxy.WebProxyFactory.CreateSource();
						if(sourceService == null) return null;						

						WebServiceProxy.SourceProxy.DataSetResult sourceResult = sourceService.GetDataSourcePaging(sourceParam, (WebServiceProxy.SourceProxy.DDADBType)AppData.Data.DBType);

						_rowCount = sourceResult.TotalRow;
						_pageCount = TableLayout.GetTotalages( _rowCount, _dataSource.TableLayout.PageSize);

						if (sourceResult.Result != null && sourceResult.Result.Tables.Count > 0)
						{
							dtResult = sourceResult.Result.Tables[0];
							if (dtResult.Rows.Count <= 0)
							{
								_hasData = false;
								return null;
							}
						}
						else
						{
							_hasData = false;
							return null;
						}
			
						return sourceResult.Result.Tables[0];

					case FunctionType.SingleLayer:
						_singleLayer.TableLayout.PageIndex = index;

						WebServiceProxy.SingleLayerProxy.SingleLayerRecipe singleLayerParam = (WebServiceProxy.SingleLayerProxy.SingleLayerRecipe)WebServiceProxy.ConvertProxy.Convert(_singleLayer, typeof(WebServiceProxy.SingleLayerProxy.SingleLayerRecipe));
						WebServiceProxy.SingleLayerProxy.SingleLayer singleLayerService = WebServiceProxy.WebProxyFactory.CreateSingleLayer();
						if(singleLayerService == null) return null;
						WebServiceProxy.SingleLayerProxy.DataSetResult singleLayerResult = singleLayerService.GetSingleLayerPaging(singleLayerParam, (WebServiceProxy.SingleLayerProxy.DDADBType)AppData.Data.DBType);
					
						_rowCount = singleLayerResult.TotalRow;
						_pageCount = TableLayout.GetTotalages( _rowCount, _singleLayer.TableLayout.PageSize);

						if (singleLayerResult.Result != null && singleLayerResult.Result.Tables.Count > 0)
						{
							dtResult = singleLayerResult.Result.Tables[0];
							if (dtResult.Rows.Count <= 0)
							{
								_hasData = false;
								return null;
							}
						}
						else
						{
							_hasData = false;
							return null;
						}
			
						return singleLayerResult.Result.Tables[0];

					case FunctionType.SignatureOfSurface:
						_singleLayer.TableLayout.PageIndex = index;

						WebServiceProxy.SingleLayerProxy.SingleLayerRecipe singleLayerParam2 = (WebServiceProxy.SingleLayerProxy.SingleLayerRecipe)WebServiceProxy.ConvertProxy.Convert(_singleLayer, typeof(WebServiceProxy.SingleLayerProxy.SingleLayerRecipe));
						WebServiceProxy.SingleLayerProxy.SingleLayer singleLayerService2 = WebServiceProxy.WebProxyFactory.CreateSingleLayer();
						if(singleLayerService2 == null) return null;
						WebServiceProxy.SingleLayerProxy.DataSetResult singleLayerResult2 = singleLayerService2.GetSurfaceHasSignature(singleLayerParam2, (WebServiceProxy.SingleLayerProxy.DDADBType)AppData.Data.DBType);
					
						_rowCount = singleLayerResult2.TotalRow;
						_pageCount = TableLayout.GetTotalages( _rowCount, _singleLayer.TableLayout.PageSize);

						if (singleLayerResult2.Result != null && singleLayerResult2.Result.Tables.Count > 0)
						{
							dtResult = singleLayerResult2.Result.Tables[0];
							if (dtResult.Rows.Count <= 0)
							{
								_hasData = false;
								return null;
							}
						}
						else
						{
							_hasData = false;
							return null;
						}
			
						return singleLayerResult2.Result.Tables[0];

					case FunctionType.SourceOfDisk:
						_dataSource.TableLayout.PageIndex = index;
					
						WebServiceProxy.SourceProxy.DataSourceRecipe diskParam = (WebServiceProxy.SourceProxy.DataSourceRecipe)WebServiceProxy.ConvertProxy.Convert(_dataSource, typeof(WebServiceProxy.SourceProxy.DataSourceRecipe));
						WebServiceProxy.SourceProxy.Source diskService = WebServiceProxy.WebProxyFactory.CreateSource();
						if(diskService == null) return null;
						WebServiceProxy.SourceProxy.DataSetResult diskResult = diskService.GetSourceOfDiskPaging(diskParam, (WebServiceProxy.SourceProxy.DDADBType)AppData.Data.DBType);

						_rowCount = diskResult.TotalRow;
						_pageCount = TableLayout.GetTotalages( _rowCount, _dataSource.TableLayout.PageSize);

						if (diskResult.Result != null && diskResult.Result.Tables.Count > 0)
						{
							dtResult = diskResult.Result.Tables[0];
							if (dtResult.Rows.Count <= 0)
							{
								_hasData = false;
								return null;
							}
						}
						else
						{
							_hasData = false;
							return null;
						}
			
						return diskResult.Result.Tables[0];

				}
			}
			catch (System.Exception e)
			{
				MessageBox.Show(e.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return dtResult;
		}

		private DataTable GetResultBySurfaceKey(long surfaceKey)
		{
			DataTable result = null;
			try
			{
				WebServiceProxy.SingleLayerProxy.SingleLayerRecipe param = (WebServiceProxy.SingleLayerProxy.SingleLayerRecipe)WebServiceProxy.ConvertProxy.Convert(_singleLayer, typeof(WebServiceProxy.SingleLayerProxy.SingleLayerRecipe));
				WebServiceProxy.SingleLayerProxy.SingleLayer service = WebServiceProxy.WebProxyFactory.CreateSingleLayer();
				if (service == null) return null;
				result = service.GetResultBySurfaceKey(surfaceKey, SqlWhere, (WebServiceProxy.SingleLayerProxy.DDADBType)AppData.Data.DBType).Result.Tables[0];
			}
			catch (System.Exception e)
			{
				MessageBox.Show(e.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return result;
		}

		private void AddData_DataSource(DataTable dtResult)
		{
            //Clear Data Grid View
            dgData.Rows.Clear();
            foreach (DataRow row in dtResult.Rows)
            {
                int colIndex = 0;
                WaferResultItem result = new WaferResultItem(row);
                int rowIndex = dgData.Rows.Add();

                //Add Source Thumbnail
                AddSourceThumbnail2ImageList(Convert.ToInt64(result["SurfaceKey"]));
                dgData.Rows[rowIndex].Cells[colIndex++].Value = _imgList.Images[_imgList.Images.Count - 1];
                dgData.Rows[rowIndex].Height = 100;

                foreach (string columnName in _dataSource.TableLayout.DisplayColumns)
                {
                    if (columnName != WaferConst.Surface)
                        dgData.Rows[rowIndex].Cells[colIndex++].Value = result[columnName].ToString();
                    else
                    {
                        if (Convert.ToInt32(result[columnName]) == 0)
                            dgData.Rows[rowIndex].Cells[colIndex++].Value = "Top";
                        else
                            dgData.Rows[rowIndex].Cells[colIndex++].Value = "Bottom";
                    }
                }

                dgData.Rows[rowIndex].Tag = result;
            }
		}

		private int GetMaxSignature(DataTable result)
		{
			int max = 0;

			try
			{
				foreach (DataRow row in result.Rows)
				{
					DataTable dtDetail = GetResultBySurfaceKey(Convert.ToInt64(row["SurfaceKey"]));

					if (dtDetail != null && max < dtDetail.Rows.Count)
						max	= dtDetail.Rows.Count;
				}
			}
			catch (System.Exception e)
			{
				MessageBox.Show(e.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return max;
		}

		private void AddData_SingleLayer(DataTable dtResult)
		{
            try
            {
                //Clear Data Grid View
                dgData.Rows.Clear();

                foreach (DataRow row in dtResult.Rows)
                {
                    int colIndex = 0;
                    WaferResultItem result = new WaferResultItem(row);
                    int rowIndex = dgData.Rows.Add();

                    //Add Source Thumbnail
                    AddSourceThumbnail2ImageList(Convert.ToInt64(result["SurfaceKey"]));				
                    dgData.Rows[rowIndex].Cells[colIndex++].Value = _imgList.Images[_imgList.Images.Count - 1];
                    dgData.Rows[rowIndex].Height = 100;

                    //Add Result Thumbnail
                    AddResultThumbnail2ImageList(Convert.ToInt64(result["ResultDetailKey"]));
                    dgData.Rows[rowIndex].Cells[colIndex++].Value = _imgList.Images[_imgList.Images.Count - 1];
                    dgData.Rows[rowIndex].Height = 100;

                    foreach (string columnName in _singleLayer.TableLayout.DisplayColumns)
                    {
                        if (columnName != WaferConst.Surface)
                        {
                            if (columnName != WaferConst.PercentOfSignatureDefect)
                                dgData.Rows[rowIndex].Cells[colIndex++].Value = result[columnName].ToString();
                            else
                                dgData.Rows[rowIndex].Cells[colIndex++].Value = string.Format("{0}%", Math.Round(Convert.ToDouble(result[columnName]), 2));
                        }
                        else
                        {
                            if (Convert.ToInt32(result[columnName]) == 0)
                                dgData.Rows[rowIndex].Cells[colIndex++].Value = "Top";
                            else
                                dgData.Rows[rowIndex].Cells[colIndex++].Value = "Bottom";
                        }
                    }

                    dgData.Rows[rowIndex].Tag = result;
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
		}

		private void AddData_SignatureOfSurface(DataTable dtResult)
		{
            try
            {
                //Clear Data Grid View
                dgData.Rows.Clear();

                _maxSignature = GetMaxSignature(dtResult);
                Init_SignatureOfSurface_Table(dtResult, _maxSignature);

                foreach (DataRow row in dtResult.Rows)
                {
                    int colIndex = 0;
                    WaferResultItem result = new WaferResultItem(row);
                    int rowIndex = dgData.Rows.Add();

                    //Add Source Thumbnail
                    AddSourceThumbnail2ImageList_SignatureOfSurface(Convert.ToInt64(result["SurfaceKey"]));				
                    dgData.Rows[rowIndex].Cells[colIndex].Value = _imgList.Images[_imgList.Images.Count - 1];
                    dgData.Rows[rowIndex].Height = 100;
                    dgData.Rows[rowIndex].Cells[colIndex++].Tag = result;

                    //Add Signature Thumbnail
                    DataTable dtDetail = GetResultBySurfaceKey(Convert.ToInt64(result["SurfaceKey"]));
                    if (dtDetail != null && dtDetail.Rows.Count > 0)
                    {
                        foreach (DataRow detailRow in dtDetail.Rows)
                        {
                            WaferResultItem detailItem = new WaferResultItem(detailRow);
                            long resultDetailKey = Convert.ToInt64(detailRow["ResultDetailKey"]);

                            Bitmap bmpSource = _imgList.Images[_imgList.Images.Count - 1] as Bitmap;
                            string signatureName = detailRow["SignatureName"].ToString();
                            int grade = 0;
                            if (detailRow["Grade"] != DBNull.Value && detailRow["Grade"] != null)
                            {
                                grade = Convert.ToInt32(detailRow["Grade"]);
                                signatureName = string.Format("{0}-{1}", grade, signatureName);
                            }

                            AddResultThumbnail2ImageList_SignatureOfSurface(resultDetailKey, signatureName, bmpSource);

                            dgData.Rows[rowIndex].Cells[colIndex].Value = _imgList.Images[_imgList.Images.Count - 1];
                            dgData.Rows[rowIndex].Height = 120;
                            dgData.Rows[rowIndex].Cells[colIndex++].Tag = detailItem;
                        }
                    }

                    colIndex = _maxSignature + 1;
                    foreach (string columnName in _singleLayer.TableLayout.DisplayColumns)
                    {
                        if (columnName != WaferConst.Surface)
                            dgData.Rows[rowIndex].Cells[colIndex++].Value = result[columnName].ToString();
                        else
                        {
                            if (Convert.ToInt32(result[columnName]) == 0)
                                dgData.Rows[rowIndex].Cells[colIndex++].Value = "Top";
                            else
                                dgData.Rows[rowIndex].Cells[colIndex++].Value = "Bottom";
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
				MessageBox.Show(e.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return null;
		}

		private void AddData_SourceOfDisk(DataTable dtResult)
		{
            //Clear Data Grid View
            dgData.Rows.Clear();
            foreach (DataRow row in dtResult.Rows)
            {
                int colIndex = 0;
                WaferResultItem result = new WaferResultItem(row);
                int rowIndex = dgData.Rows.Add();

                //Add Thumbnail
                DataTable dtSurface = GetSurfaceByDisk(Convert.ToInt64(result["DiskKey"]));
                if (dtSurface != null && dtSurface.Rows.Count > 0)
                {
                    foreach (DataRow surfaceRow in dtSurface.Rows)
                    {
                        WaferResultItem surfaceResult = new WaferResultItem(surfaceRow);
                        long surfaceKey = Convert.ToInt64(surfaceRow["SurfaceKey"]);
                        int surface = Convert.ToInt32(surfaceRow["Surface"]);

                        if (surface == 1 && dtSurface.Rows.Count == 1)
                            dgData.Rows[rowIndex].Cells[colIndex++].Value = null;

                        AddSourceThumbnail2ImageList(surfaceKey);				
                        dgData.Rows[rowIndex].Cells[colIndex].Value = _imgList.Images[_imgList.Images.Count - 1];
                        dgData.Rows[rowIndex].Height = 100;
                        dgData.Rows[rowIndex].Cells[colIndex++].Tag = surfaceResult;
                    }

                    if (dtSurface.Rows.Count == 1 && Convert.ToInt32(dtSurface.Rows[0]["Surface"]) == 0)
                        dgData.Rows[rowIndex].Cells[colIndex++].Value = null;
                }
                else
                {
                    dgData.Rows[rowIndex].Cells[colIndex++].Value = null;
                    dgData.Rows[rowIndex].Cells[colIndex++].Value = null;
                }

                foreach (string columnName in _dataSource.TableLayout.DisplayColumns)
                    dgData.Rows[rowIndex].Cells[colIndex++].Value = result[columnName].ToString();

                dgData.Rows[rowIndex].Tag = result;
            }
		}

		private void AddSourceThumbnail2ImageList_SignatureOfSurface(long surfaceKey)
		{
			Bitmap bmp = null;
			Bitmap newBmp = null;
			Graphics g = null;
			MemoryStream memory = null;
			byte[] buffer = null;
			
			try
			{
				WebServiceProxy.SourceProxy.Source proxy = WebServiceProxy.WebProxyFactory.CreateSource();

				if (raPolar.Checked)
					buffer = proxy.GetSourceThumbnail(surfaceKey, (WebServiceProxy.SourceProxy.DDADBType)AppData.Data.DBType);
				else
					buffer = proxy.GetSourceThumbnailFlat(surfaceKey, (WebServiceProxy.SourceProxy.DDADBType)AppData.Data.DBType);
				
				memory = new MemoryStream(buffer);
				newBmp = new Bitmap(memory);

				bmp = new Bitmap(100, 120);
				g = Graphics.FromImage(bmp);
				g.DrawImage(newBmp, 0, 0, 100, 100);

				_imgList.Images.Add((Image)bmp.Clone());
			}
			catch
			{
				throw;
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

		private void AddResultThumbnail2ImageList_SignatureOfSurface(long resultDetailKey, string signatureName, Bitmap bmpSouce)
		{
			Bitmap bmp = null;
			Bitmap newBmp = null;
			MemoryStream memory = null;
			Graphics g = null;
			byte[] buffer = null;
				
			try
			{
				WebServiceProxy.SingleLayerProxy.SingleLayer proxy = WebServiceProxy.WebProxyFactory.CreateSingleLayer();

				if (raPolar.Checked)
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

				//Cang sua tam thoi - 2008-06-21 
				//neu nhu buffer==null thi day la loai : Empty hoac No_Signature --> lay tu source len
				if(buffer!=null) 
				{
					memory = new MemoryStream(buffer);
					newBmp = new Bitmap(memory);
				}

				bmp = new Bitmap(100, 120, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
			
				g = Graphics.FromImage(bmp);
				g.Clear(Color.White);

				if(buffer!=null) 
					g.DrawImage(newBmp,0, 0,100,100);
				else
					g.DrawImage(bmpSouce,new Rectangle(0, 0,100,100),0,0,100,100,GraphicsUnit.Pixel);

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

				_imgList.Images.Add((Image)bmp.Clone());
			}
			catch
			{
				throw;
			}
			finally
			{
				if (g != null)
				{
					g.Dispose();
					g = null;
				}

				if(memory!=null)//miss free memory strem
				{
					memory.Close();
					memory = null;
				}

				//what about bmp...? it was cloned

				if (newBmp != null)
				{
					newBmp.Dispose();
					newBmp = null;
				}
			}
		}

		private void AddSourceThumbnail2ImageList(long surfaceKey)
		{
			Bitmap bmp = null;
			MemoryStream memory = null;
			byte[] buffer = null;
			
			try
			{
				WebServiceProxy.SourceProxy.Source proxy = WebServiceProxy.WebProxyFactory.CreateSource();

				if (raPolar.Checked)
					buffer = proxy.GetSourceThumbnail(surfaceKey, (WebServiceProxy.SourceProxy.DDADBType)AppData.Data.DBType);
				else
					buffer = proxy.GetSourceThumbnailFlat(surfaceKey, (WebServiceProxy.SourceProxy.DDADBType)AppData.Data.DBType);
				
				memory = new MemoryStream(buffer);
				bmp = new Bitmap(memory);
				_imgList.Images.Add((Image)bmp.Clone());
			}
			catch 
			{
				throw;
			}
			finally
			{
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

		private void AddResultThumbnail2ImageList(long resultDetailKey)
		{
			Bitmap bmp = null;
			MemoryStream memory = null;
			byte[] buffer = null;
				
			try
			{
				WebServiceProxy.SingleLayerProxy.SingleLayer proxy = WebServiceProxy.WebProxyFactory.CreateSingleLayer();

				if (raPolar.Checked)
					buffer = proxy.GetResultThumbnail(resultDetailKey, (WebServiceProxy.SingleLayerProxy.DDADBType)AppData.Data.DBType);
				else
					buffer = proxy.GetResultThumbnailFlat(resultDetailKey, (WebServiceProxy.SingleLayerProxy.DDADBType)AppData.Data.DBType);

				//Cang sua tam thoi - 2008-06-21 
				//neu nhu buffer==null thi day la loai : Empty hoac No_Signature --> lay tu source len
				if(buffer!=null)
				{
					memory = new MemoryStream(buffer);
					bmp = new Bitmap(memory);
				
					_imgList.Images.Add((Image)bmp.Clone());
				}
			}
			catch
			{
				throw;
			}
		}

		private byte[] GetKlarfBuffer(long surfaceKey)
		{
			byte[] buffer = null;

			try
			{
				WebServiceProxy.SourceProxy.Source service = WebServiceProxy.WebProxyFactory.CreateSource();
				if (service == null) return null;
				buffer = SiGlaz.DDA.Business.BDConvert.ConvertTOSURFRaw(service.GetSourceRawData(surfaceKey, (WebServiceProxy.SourceProxy.DDADBType)AppData.Data.DBType));
			}
			catch (System.Exception e)
			{
				MessageBox.Show(e.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
			return buffer;
		}

		private byte[] GetAnalyzedDefectListBuffer(long resultDetailKey)
		{
			byte[] buffer = null;

			try
			{
				WebServiceProxy.SingleLayerProxy.SingleLayer service = WebServiceProxy.WebProxyFactory.CreateSingleLayer();
				if (service == null) return null;

				buffer = service.GetResultRawData(resultDetailKey, (WebServiceProxy.SingleLayerProxy.DDADBType)AppData.Data.DBType);
			}
			catch (System.Exception e)
			{
				MessageBox.Show(e.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return buffer;
		}

		private SSA.SystemFrameworks.KlarfParserFile GetKlarfFile(long surfaceKey)
		{
			SSA.SystemFrameworks.KlarfParserFile klarfFile = null;
			byte[] buffer = null;
		
			try
			{
				WebServiceProxy.SourceProxy.Source service = WebServiceProxy.WebProxyFactory.CreateSource();
				if (service == null) return null;
				
				buffer = SiGlaz.DDA.Business.BDConvert.ConvertTOSURFRaw(service.GetSourceRawData(surfaceKey, (WebServiceProxy.SourceProxy.DDADBType)AppData.Data.DBType));

				if (buffer == null)
					return null;

				buffer = SiGlaz.Utility.Compression.Compressor.DeCompress(buffer);
				klarfFile = SSA.SystemFrameworks.KlarfParserFile.OpenSURF(buffer)[0] as SSA.SystemFrameworks.KlarfParserFile;
			}
			catch (System.Exception e)
			{
				MessageBox.Show(e.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return klarfFile;
		}

		private ArrayList GetAnalyzedDefectList(long resultDetailKey, SSA.SystemFrameworks.KlarfParserFile klarfFile)
		{
			ArrayList analyzedDefects = null;
			byte[] buffer = null;

			try
			{
				WebServiceProxy.SingleLayerProxy.SingleLayer service = WebServiceProxy.WebProxyFactory.CreateSingleLayer();
				if (service == null) return null;

				buffer = service.GetResultRawData(resultDetailKey, (WebServiceProxy.SingleLayerProxy.DDADBType)AppData.Data.DBType);

				if (buffer == null)
					return null;

				buffer = SiGlaz.Utility.Compression.Compressor.DeCompress(buffer);
				ResultDefectList resultDefectList = ResultDefectList.Deserialize(buffer) as ResultDefectList;

				analyzedDefects = klarfFile.GetDefectList(resultDefectList.alDefectListID);
			}
			catch (System.Exception e)
			{
				MessageBox.Show(e.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return analyzedDefects;
		}

		private byte[] UpdateKlarfFile(long surfaceKey, SSA.SystemFrameworks.KlarfParserFile klarfFile)
		{
			try
			{
				WebServiceProxy.SingleLayerProxy.SingleLayerRecipe param = (WebServiceProxy.SingleLayerProxy.SingleLayerRecipe)WebServiceProxy.ConvertProxy.Convert(_singleLayer, typeof(WebServiceProxy.SingleLayerProxy.SingleLayerRecipe));
				WebServiceProxy.SingleLayerProxy.SingleLayer proxy = WebServiceProxy.WebProxyFactory.CreateSingleLayer();
				
				WebServiceProxy.SingleLayerProxy.DataSetResult dtDetail = proxy.GetResultBySurfaceKey(surfaceKey, param, (WebServiceProxy.SingleLayerProxy.DDADBType)AppData.Data.DBType);

				if (dtDetail != null && dtDetail.Result.Tables.Count > 0 && dtDetail.Result.Tables[0].Rows.Count > 0)
				{
					foreach (DataRow row in dtDetail.Result.Tables[0].Rows)
					{
						int signatureKey = Convert.ToInt32(row["SignatureKey"]);
						string signatureName = row["SignatureName"].ToString();

						klarfFile.m_ClassLookup.UpdateData(signatureKey, signatureName);
						ArrayList analyzedDefects = GetAnalyzedDefectList(Convert.ToInt64(row["ResultDetailKey"]), klarfFile);

						if (analyzedDefects != null)
						{
							foreach (DEFECTRECORDSPEC def in analyzedDefects)
								def.ClassNumber = (short)signatureKey;
						}
					}

					ArrayList alKlarf = new ArrayList();
					alKlarf.Add(klarfFile);

					byte[] buffer = SSA.SystemFrameworks.KlarfParserFile.WriteSURF(alKlarf);
					buffer = SiGlaz.Utility.Compression.Compressor.Compress(buffer);

					return buffer;
				}
			}
			catch (System.Exception e)
			{
				MessageBox.Show(e.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);				
			}

			return null;
		}

		private DDAResultData GetDDAResultSharedData()
		{
			DDAResultData sharedData = new DDAResultData();
			WaferResultItem item = null;
			sharedData = new DDAResultData();

			switch (_type)
			{
				case FunctionType.DataSource:
					item = (WaferResultItem)dgData.Rows[_rowIndex].Tag;
					sharedData.DataSourceRaw = GetKlarfBuffer(Convert.ToInt64(item["SurfaceKey"]));
					break;

				case FunctionType.SingleLayer:
                    item = (WaferResultItem)dgData.Rows[_rowIndex].Tag;
					sharedData.DataSourceRaw = GetKlarfBuffer(Convert.ToInt64(item["SurfaceKey"]));
					sharedData.DefectListRaw = GetAnalyzedDefectListBuffer(Convert.ToInt64(item["ResultDetailKey"]));
					break;

				case FunctionType.SignatureOfSurface:
					if (_columnIndex == 0)
					{
						item = (WaferResultItem)dgData.Rows[_rowIndex].Cells[0].Tag;
						sharedData.DataSourceRaw = GetKlarfBuffer(Convert.ToInt64(item["SurfaceKey"]));
						if (sharedData.DataSourceRaw!= null)
						{
                            KlarfParserFile klarf = SiGlaz.DDA.Business.BDConvert.ConvertFromBinaryToKlarfParserFile(sharedData.DataSourceRaw);

							byte[] buffer = UpdateKlarfFile( Convert.ToInt64(item["SurfaceKey"]),klarf);
							if (buffer != null)
								sharedData.DataSourceRaw = buffer;
						}
					}
					else if (dgData.Rows[_rowIndex].Cells[_columnIndex].Tag != null)
					{
                        item = (WaferResultItem)dgData.Rows[_rowIndex].Cells[0].Tag;
                        WaferResultItem detailItem = (WaferResultItem)dgData.Rows[_rowIndex].Cells[_columnIndex].Tag;
						sharedData.DataSourceRaw = GetKlarfBuffer(Convert.ToInt64(item["SurfaceKey"]));
						sharedData.DefectListRaw = GetAnalyzedDefectListBuffer(Convert.ToInt64(detailItem["ResultDetailKey"]));
					}

					break;
			}

			return sharedData;
		}

		private DDAResultDataCollection GetDDAResultDataCollection()
		{
			DDAResultDataCollection results = new DDAResultDataCollection();

            WaferResultItem topItem = (WaferResultItem)dgData.Rows[_rowIndex].Cells[0].Tag;
            WaferResultItem bottomItem = (WaferResultItem)dgData.Rows[_rowIndex].Cells[1].Tag;
			DDAResultData result = null;

			results.FocusedIndex = _columnIndex;

			switch (_type)
			{
				case FunctionType.SourceOfDisk:

					if (topItem != null)
					{
						result = new DDAResultData();
						result.DataSourceRaw = GetKlarfBuffer(Convert.ToInt64(topItem["SurfaceKey"]));
						results.Add(result);
					}
					
					if (bottomItem != null)
					{
						result = new DDAResultData();
						result.DataSourceRaw = GetKlarfBuffer(Convert.ToInt64(bottomItem["SurfaceKey"]));
						results.Add(result);
					}
					
					break;
			}

			return results;
		}

		private void ViewDetail()
		{
			Cursor.Current = Cursors.WaitCursor;

			if (_rowIndex > -1)
			{
				ViewMode viewMode = raPolar.Checked ? ViewMode.Disk : ViewMode.Flat;
				DDAResultData sharedData = null;
				WaferResultItem item = null;
				DlgDetailView dlg = null;

				switch (_type)
				{
					case FunctionType.DataSource:
					case FunctionType.SingleLayer:
						sharedData = GetDDAResultSharedData();
                        item = (WaferResultItem)dgData.Rows[_rowIndex].Tag;
						dlg = new DlgDetailView(item, sharedData, viewMode);
						dlg.ShowDialog();
						break;

					case FunctionType.SignatureOfSurface:
						sharedData = GetDDAResultSharedData();
						if (_columnIndex == 0)
						{
                            item = (WaferResultItem)dgData.Rows[_rowIndex].Cells[0].Tag;
							dlg = new DlgDetailView(item, sharedData, viewMode);
							dlg.ShowDialog();
						}
						else if (dgData.Rows[_rowIndex].Cells[_columnIndex].Tag != null)
						{
                            item = (WaferResultItem)dgData.Rows[_rowIndex].Cells[0].Tag;
                            WaferResultItem detailItem = (WaferResultItem)dgData.Rows[_rowIndex].Cells[_columnIndex].Tag;

							foreach (DataColumn col in detailItem.row.Table.Columns)
							{
								if (!item.row.Table.Columns.Contains(col.ColumnName))
								{
									DataColumn newColumn = new DataColumn(col.ColumnName, col.DataType);
									item.row.Table.Columns.Add(newColumn);
								}
							}

							item.row[WaferConst.SignatureName] = detailItem[WaferConst.SignatureName];
							item.row[WaferConst.NumberOfSignatureDefect] = detailItem[WaferConst.NumberOfSignatureDefect];
							item.row[WaferConst.PercentOfSignatureDefect] = Math.Round(Convert.ToDouble(detailItem[WaferConst.PercentOfSignatureDefect]), 2);

							dlg = new DlgDetailView(item, sharedData, viewMode);
							dlg.ShowDialog();
						}

						break;

					case FunctionType.SourceOfDisk:
						if ((_columnIndex == 0 || _columnIndex == 1) && dgData.Rows[_rowIndex].Cells[_columnIndex].Tag != null)
						{
							DDAResultDataCollection ddaResultDataCollection = GetDDAResultDataCollection();
							DlgSourceOfDiskViewLargeImage sourceOfDiskDlg = new DlgSourceOfDiskViewLargeImage(ddaResultDataCollection, viewMode);
							sourceOfDiskDlg.ShowDialog(this);
						}
						break;
				}
			}
			else
			{
				MessageBox.Show("Please select one record.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			_rowIndex = -1;
			_columnIndex = -1;		
		}

		private void RunDDA()
		{
			if (_rowIndex > -1)
			{
				Cursor.Current = Cursors.WaitCursor;
				if (File.Exists(AppData.Data.DDAPath) == false)
				{
					MessageBox.Show(string.Format("File {0} does not exist. Please reset DDA path.", AppData.Data.DDAPath), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					Cursor.Current = Cursors.WaitCursor;

					DDAResultDataCollection results = null;

					switch (_type)
					{
						case FunctionType.DataSource:
						case FunctionType.SingleLayer:
						case FunctionType.SignatureOfSurface:
							DDAResultData sharedData = GetDDAResultSharedData();
							if (sharedData.DataSourceRaw == null) return;
							results = new DDAResultDataCollection();
							results.Add(sharedData);
							break;

						case FunctionType.SourceOfDisk:
							results = GetDDAResultDataCollection();
							if (results == null || results.Count <= 0) return;
							break;
					}
					

					string temppath = AppData.ApplicationDataPath;//Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Templates),"DDANavData");

					if(!Directory.Exists(temppath))
						Directory.CreateDirectory(temppath);

					temppath = Path.Combine(temppath, "memorydata.dat");
					results.SerializeBinary(temppath);
					//sharedData.SerializeBinary(temppath);

					if(AppData.Data.DDAProcess==null)
					{
						if (File.Exists(temppath))
						{
							System.Diagnostics.ProcessStartInfo proInfo = new System.Diagnostics.ProcessStartInfo(AppData.Data.DDAPath,string.Format("\"{0}\" Memory", temppath));
							AppData.Data.DDAProcess = System.Diagnostics.Process.Start(proInfo);
						}
					}
					else
					{
						IntPtr pFoundWindow = AppData.Data.DDAProcess.MainWindowHandle; 
						SiGlaz.Utility.Win32.User32.SendMessage(pFoundWindow,(int)SiGlaz.Utility.Win32.Msgs.WM_USER + 1,0,0);
						SiGlaz.Utility.Win32.User32.SetWindowPos(pFoundWindow,IntPtr.Zero,0,0,0,0,
							(uint)(SiGlaz.Utility.Win32.SetWindowPosFlags.SWP_SHOWWINDOW |SiGlaz.Utility.Win32.SetWindowPosFlags.SWP_NOSIZE) );
					}

				}
			}
			else
				MessageBox.Show("Please select one record.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void ExportData()
		{
			Cursor.Current = Cursors.WaitCursor;
			ViewMode viewMode = raPolar.Checked ? ViewMode.Disk : ViewMode.Flat;
			string error = string.Empty;
			DlgMessageBox dlg = null;

			switch (_type)
			{
				case FunctionType.DataSource:
					SiGlaz.Export.Excel.DataSource exportDataSource = new DataSource(_dataSource, viewMode, _exportType);
					if (exportDataSource.Export2Excel(_exportFileName, ref error))
					{
						dlg = new DlgMessageBox(_exportFileName);
						dlg.ShowDialog();
					}
					else
						MessageBox.Show(string.Format("Export to Excel file fail: {0}", error), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;

				case FunctionType.SingleLayer:
					SiGlaz.Export.Excel.SingleLayer exportSingleLayer = new SingleLayer(_singleLayer, viewMode, _exportType);
					if (exportSingleLayer.Export2Excel(_exportFileName, ref error))
					{
						dlg = new DlgMessageBox(_exportFileName);
						dlg.ShowDialog();
					}
					else
						MessageBox.Show(string.Format("Export to Excel file fail: {0}", error), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;

				case FunctionType.SignatureOfSurface:
					SiGlaz.Export.Excel.SignatureOfSurface exportSignatureOfSurface = new SignatureOfSurface(_singleLayer, viewMode, _exportType, SqlWhere);
					if (exportSignatureOfSurface.Export2Excel(_exportFileName, ref error))
					{
						dlg = new DlgMessageBox(_exportFileName);
						dlg.ShowDialog();
					}
					else
						MessageBox.Show(string.Format("Export to Excel file fail: {0}", error), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;

				case FunctionType.SourceOfDisk:
					SiGlaz.Export.Excel.SourceOfDisk exportSourceOfDisk = new SourceOfDisk(_dataSource, viewMode, _exportType);
					if (exportSourceOfDisk.Export2Excel(_exportFileName, ref error))
					{
						dlg = new DlgMessageBox(_exportFileName);
						dlg.ShowDialog();
					}
					else
						MessageBox.Show(string.Format("Export to Excel file fail: {0}", error), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
			}
		}
		
		private void UpdateViewMap_SourceOfSurface()
		{
			_imgList.Images.Clear();

            foreach (DataGridViewRow row in dgData.Rows)
            {
                WaferResultItem resultItem = (WaferResultItem)(row).Tag;
                long surfaceKey = Convert.ToInt64(resultItem["SurfaceKey"]);
                AddSourceThumbnail2ImageList(surfaceKey);
                row.Cells[0].Value = _imgList.Images[_imgList.Images.Count - 1];
            }
		}

		private void UpdateViewMap_SourceOfDisk()
		{
			_imgList.Images.Clear();

            foreach (DataGridViewRow row in dgData.Rows)
            {
                WaferResultItem topItem = (WaferResultItem)(row.Cells[0]).Tag;
                WaferResultItem bottomItem = (WaferResultItem)(row.Cells[1]).Tag;

                if (topItem != null)
                {
                    long surfaceKey = Convert.ToInt64(topItem["SurfaceKey"]);
                    AddSourceThumbnail2ImageList(surfaceKey);
                    
                    row.Cells[0].Value = _imgList.Images[_imgList.Images.Count - 1];
                }

                if (bottomItem != null)
                {
                    long surfaceKey = Convert.ToInt64(bottomItem["SurfaceKey"]);
                    AddSourceThumbnail2ImageList(surfaceKey);
                    row.Cells[1].Value = _imgList.Images[_imgList.Images.Count - 1];
                }
            }
		}

		private void UpdateViewMap_SingleLayer()
		{
			_imgList.Images.Clear();

            foreach (DataGridViewRow row in dgData.Rows)
            {
                WaferResultItem resultItem = (WaferResultItem)(row).Tag;
                long surfaceKey = Convert.ToInt64(resultItem["SurfaceKey"]);
                long resultDetailKey = Convert.ToInt64(resultItem["ResultDetailKey"]);

                AddSourceThumbnail2ImageList(surfaceKey);
                row.Cells[0].Value = _imgList.Images[_imgList.Images.Count - 1];

                AddResultThumbnail2ImageList(resultDetailKey);
                row.Cells[1].Value = _imgList.Images[_imgList.Images.Count - 1];
            }
		}

		private void UpdateViewMap_SignatureOfSurface()
		{
			_imgList.Images.Clear();

            foreach (DataGridViewRow row in dgData.Rows)
            {
                WaferResultItem resultItem = (WaferResultItem)(row.Cells[0]).Tag;
                long surfaceKey = Convert.ToInt64(resultItem["SurfaceKey"]);


                AddSourceThumbnail2ImageList_SignatureOfSurface(surfaceKey);
                row.Cells[0].Value = _imgList.Images[_imgList.Images.Count - 1];

                for (int i = 1; i <= _maxSignature; i++)
                {
                    WaferResultItem resultDetailItem = (WaferResultItem)(row.Cells[i].Tag);

                    if (resultDetailItem != null)
                    {
                        long resultDetailKey = Convert.ToInt64(resultDetailItem["ResultDetailKey"]);
                        string signatureName = resultDetailItem["SignatureName"];
                        int grade = 0;
                        if (resultDetailItem["Grade"] != null && resultDetailItem["Grade"] != string.Empty)
                        {
                            grade = Convert.ToInt32(resultDetailItem["Grade"]);
                            signatureName = string.Format("{0}-{1}", grade, signatureName);
                        }

                        Bitmap bmpSource = _imgList.Images[_imgList.Images.Count - 1] as Bitmap;
                        AddResultThumbnail2ImageList_SignatureOfSurface(resultDetailKey, signatureName, bmpSource);
                        row.Cells[i].Value = _imgList.Images[_imgList.Images.Count - 1];
                    }
                }
            }
		}

		private void UpdateViewMap()
		{
			Cursor.Current = Cursors.WaitCursor;
			if (dgData.RowCount <= 0) return;

			switch (_type)
			{
				case FunctionType.DataSource:
					UpdateViewMap_SourceOfSurface();
					break;

				case FunctionType.SourceOfDisk:
					UpdateViewMap_SourceOfDisk();
					break;

				case FunctionType.SingleLayer:
					UpdateViewMap_SingleLayer();
					break;

				case FunctionType.SignatureOfSurface:
					UpdateViewMap_SignatureOfSurface();
					break;
			}
		}
		#endregion

		#region Windows Events Handles
		private void btnBackTop_Click(object sender, System.EventArgs e)
		{
			if (_pageCount > 0)
			{
				if (numPageIndex.Value != 1)
				{
					numPageIndex.Value = 1;
					DisplayDataByPageIndex((int)numPageIndex.Value);
				}				
			}
		}

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			if (numPageIndex.Value > 1)
			{
				numPageIndex.Value -= 1;

				DisplayDataByPageIndex((int)numPageIndex.Value);
			}
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			if (numPageIndex.Value < _pageCount)
			{
				numPageIndex.Value += 1;
				DisplayDataByPageIndex((int)numPageIndex.Value);
			}
		}

		private void btnNextTop_Click(object sender, System.EventArgs e)
		{
			if (numPageIndex.Value != _pageCount)
			{
				numPageIndex.Value = _pageCount;
				DisplayDataByPageIndex((int)numPageIndex.Value);
			}	
		}

		private void raPolar_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateViewMap();
//			switch (_type)
//			{
//				case FunctionType.DataSource:
//				case FunctionType.SourceOfDisk:
//					RefreshData(_dataSource, _type);
//					break;
//
//				case FunctionType.SingleLayer:
//				case FunctionType.SignatureOfSurface:
//					RefreshData(_singleLayer, _type);
//					break;
//			}
		}

		private void cboSurface_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			switch (_type)
			{
				case FunctionType.DataSource:
				case FunctionType.SourceOfDisk:
					RefreshData(_dataSource, _type);
					break;

				case FunctionType.SingleLayer:
				case FunctionType.SignatureOfSurface:
					RefreshData(_singleLayer, _type);
					break;
			}
		}

        private void dgData_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            dgData.Rows[e.RowIndex].Selected = true;
        }

        private void dgData_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            _columnIndex = e.ColumnIndex;
            _rowIndex = e.RowIndex;

            switch (_type)
            {
                case FunctionType.DataSource:
                    if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                        Cursor.Current = Cursors.Hand;
                    else
                        Cursor.Current = Cursors.Default;
                    break;
                case FunctionType.SingleLayer:
                    if ((e.ColumnIndex == 0 || e.ColumnIndex == 1) && e.RowIndex >= 0)
                        Cursor.Current = Cursors.Hand;
                    else
                        Cursor.Current = Cursors.Default;
                    break;
                case FunctionType.SignatureOfSurface: //No Context Menu
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {
                        if (dgData.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag != null)
                        {
                            Cursor.Current = Cursors.Hand;
                            dgData.ContextMenuStrip = contextMenuStripDetail;
                        }
                        else
                        {
                            Cursor.Current = Cursors.Default;
                            dgData.ContextMenuStrip = null;
                        }
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        dgData.ContextMenuStrip = null;
                    }
                    break;
                case FunctionType.SourceOfDisk:
                    dgData.ContextMenuStrip = null;
                    if ((e.ColumnIndex == 0 || e.ColumnIndex == 1) && e.RowIndex >= 0)
                    {
                        if (dgData.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag != null)
                        {
                            Cursor.Current = Cursors.Hand;
                            dgData.ContextMenuStrip = contextMenuStripDetail;
                        }
                        else
                        {
                            Cursor.Current = Cursors.Default;
                            dgData.ContextMenuStrip = null;
                        }
                    }
                    else
                        Cursor.Current = Cursors.Default;
                    break;
                default:
                    Cursor.Current = Cursors.Default;
                    break;
            }
        }

        private void dgData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                ViewDetail();
            }
            catch (System.Exception ex)
            {

            }
        }

        private void viewDataWithDDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RunDDA();
            }
            catch (System.Exception ex)
            {

            }
        }

		private void btnExport_Click(object sender, System.EventArgs e)
		{
			if (dgData.RowCount > 0)
			{
				SiGlaz.DAL.ConnectionParam param = new SiGlaz.DAL.ConnectionParam();
				param.Server = AppData.Data.ServerName;
				param.Database = AppData.Data.DatabaseName;
				param.Username = AppData.Data.UserName;
				SiGlaz.Utility.RijndaelCrypto crypto = new SiGlaz.Utility.RijndaelCrypto();
				param.Password = crypto.Decrypt(AppData.Data.Password);
				
				if (!param.TestConnection())
				{
					MessageBox.Show(string.Format("Testing connection fails. Please check if database: '{0}' exists or if authentication is correct.", AppData.Data.DatabaseName), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				Cursor.Current = Cursors.WaitCursor;
				DlgExportType exportDlg = new DlgExportType();

				try
				{
					if (exportDlg.ShowDialog() == DialogResult.OK)
					{
						_exportType = exportDlg.ExportType;

						SaveFileDialog dlg = new SaveFileDialog();
						dlg.Title = "Export to Excel";

						if (_exportType == ExportType.DataAndImage)
							dlg.Filter = "(*.xls)|*.xls";
						else
							dlg.Filter = "(*.csv)|*.csv";

						if (dlg.ShowDialog() == DialogResult.OK)
						{
							_dlgStatus = new DlgStatus();
							_exportFileName = dlg.FileName;
							ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadWorker));
							_dlgStatus.ShowDialog();
						}
					}			
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					if (_dlgStatus != null)
					{
						_dlgStatus.Dispose();
						_dlgStatus = null;
					}
				}
			}
		}
		#endregion

		#region Threading Worker
		private void ThreadWorker(object status)
		{
			Cursor.Current = Cursors.WaitCursor;

			try
			{
				System.Threading.Thread.Sleep(1000);
				ExportData();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
                base.CloseDialogWaiting();
			}
		}
		#endregion
	}
}
