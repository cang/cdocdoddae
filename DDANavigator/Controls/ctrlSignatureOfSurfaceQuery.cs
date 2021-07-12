using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using DDANavigator.Dialogs;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Basic;
using SiGlaz.Common.DDA.Recipe;
using SiGlaz.Utility;
using SiGlaz.Common.DDA.Const;

namespace DDANavigator.Controls
{
	public class ctrlSignatureOfSurfaceQuery : ctrlBase
	{
		#region Members
		private System.Windows.Forms.ImageList _imgList;
		private System.Windows.Forms.TabPage pageProperties;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnSelectColumns;
		private System.Windows.Forms.TabPage pageTable;
		private DDANavigator.Controls.ctrlTimeFilter _ctrlTimeFilter;
		private System.ComponentModel.IContainer components;
		private DDANavigator.Controls.ctrlTableView _ctrlTableView;
		private System.Windows.Forms.TabControl tabDataSource;
		private DDANavigator.Controls.ctrlDataFilterCondition_SingleLayer _ctrlDataFilterCondition;
		private TableLayout _tableLayout = null;
		private SingleLayerRecipe _singleLayer = null;
		private System.Windows.Forms.RadioButton raExcludeDuplicateDisc;
		private System.Windows.Forms.RadioButton raIncludeDuplicateDisc;
		private string _configPath = string.Format("{0}\\SignatureOfSurface.xml", AppData.ApplicationDataPath);
		private string _sqlWhere = string.Empty;
		#endregion
		
		#region Constructor & Destructor
		public ctrlSignatureOfSurfaceQuery()
		{
			InitializeComponent();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ctrlSignatureOfSurfaceQuery));
			this._imgList = new System.Windows.Forms.ImageList(this.components);
			this.tabDataSource = new System.Windows.Forms.TabControl();
			this.pageProperties = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnSearch = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this._ctrlTimeFilter = new DDANavigator.Controls.ctrlTimeFilter();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this._ctrlDataFilterCondition = new DDANavigator.Controls.ctrlDataFilterCondition_SingleLayer();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnSelectColumns = new System.Windows.Forms.Button();
			this.pageTable = new System.Windows.Forms.TabPage();
			this._ctrlTableView = new DDANavigator.Controls.ctrlTableView();
			this.raExcludeDuplicateDisc = new System.Windows.Forms.RadioButton();
			this.raIncludeDuplicateDisc = new System.Windows.Forms.RadioButton();
			this.tabDataSource.SuspendLayout();
			this.pageProperties.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.pageTable.SuspendLayout();
			this.SuspendLayout();
			// 
			// _imgList
			// 
			this._imgList.ImageSize = new System.Drawing.Size(16, 16);
			this._imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imgList.ImageStream")));
			this._imgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tabDataSource
			// 
			this.tabDataSource.Controls.Add(this.pageProperties);
			this.tabDataSource.Controls.Add(this.pageTable);
			this.tabDataSource.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabDataSource.ImageList = this._imgList;
			this.tabDataSource.Location = new System.Drawing.Point(0, 0);
			this.tabDataSource.Name = "tabDataSource";
			this.tabDataSource.SelectedIndex = 0;
			this.tabDataSource.Size = new System.Drawing.Size(1024, 816);
			this.tabDataSource.TabIndex = 2;
			// 
			// pageProperties
			// 
			this.pageProperties.Controls.Add(this.panel1);
			this.pageProperties.ImageIndex = 0;
			this.pageProperties.Location = new System.Drawing.Point(4, 23);
			this.pageProperties.Name = "pageProperties";
			this.pageProperties.Size = new System.Drawing.Size(1016, 789);
			this.pageProperties.TabIndex = 0;
			this.pageProperties.Text = "Properties";
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.btnSearch);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.groupBox3);
			this.panel1.Controls.Add(this.groupBox6);
			this.panel1.Controls.Add(this.groupBox5);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1016, 789);
			this.panel1.TabIndex = 35;
			// 
			// btnSearch
			// 
			this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSearch.Location = new System.Drawing.Point(12, 692);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(76, 23);
			this.btnSearch.TabIndex = 36;
			this.btnSearch.Text = "&Search";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Location = new System.Drawing.Point(0, 680);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(1012, 4);
			this.groupBox2.TabIndex = 35;
			this.groupBox2.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this._ctrlTimeFilter);
			this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox3.Location = new System.Drawing.Point(12, 8);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(432, 188);
			this.groupBox3.TabIndex = 32;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "1. Select Date Range";
			// 
			// _ctrlTimeFilter
			// 
			this._ctrlTimeFilter.IsSaved = false;
			this._ctrlTimeFilter.Location = new System.Drawing.Point(20, 16);
			this._ctrlTimeFilter.Name = "_ctrlTimeFilter";
			this._ctrlTimeFilter.Size = new System.Drawing.Size(392, 156);
			this._ctrlTimeFilter.TabIndex = 0;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.raExcludeDuplicateDisc);
			this.groupBox6.Controls.Add(this.raIncludeDuplicateDisc);
			this.groupBox6.Controls.Add(this._ctrlDataFilterCondition);
			this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox6.Location = new System.Drawing.Point(12, 200);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(432, 416);
			this.groupBox6.TabIndex = 33;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "2. Select Data Range";
			// 
			// _ctrlDataFilterCondition
			// 
			this._ctrlDataFilterCondition.CassetteID = "";
			this._ctrlDataFilterCondition.DDAGrade = "";
			this._ctrlDataFilterCondition.DiskID = "";
			this._ctrlDataFilterCondition.DiskTypeID = "";
			this._ctrlDataFilterCondition.FabID = "";
			this._ctrlDataFilterCondition.IRISBinNo = "";
			this._ctrlDataFilterCondition.Location = new System.Drawing.Point(20, 16);
			this._ctrlDataFilterCondition.LotIDCode = "";
			this._ctrlDataFilterCondition.LotNo = "";
			this._ctrlDataFilterCondition.Name = "_ctrlDataFilterCondition";
			this._ctrlDataFilterCondition.ResourceID = "";
			this._ctrlDataFilterCondition.ResourceType = "(All)";
			this._ctrlDataFilterCondition.SignatureName = "";
			this._ctrlDataFilterCondition.Size = new System.Drawing.Size(396, 372);
			this._ctrlDataFilterCondition.SlotNoType = "";
			this._ctrlDataFilterCondition.Station = "";
			this._ctrlDataFilterCondition.TabIndex = 0;
			this._ctrlDataFilterCondition.TesterType = "";
			this._ctrlDataFilterCondition.TestGrade = "";
			this._ctrlDataFilterCondition.TimeFilter = null;
			this._ctrlDataFilterCondition.Type = SiGlaz.Common.DDA.FunctionType.SingleLayer;
			this._ctrlDataFilterCondition.WordCellID = "";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.label3);
			this.groupBox5.Controls.Add(this.btnSelectColumns);
			this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox5.Location = new System.Drawing.Point(12, 620);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(432, 52);
			this.groupBox5.TabIndex = 34;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "3. Select Table Layout";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(28, 23);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(181, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "Select the column(s) to view report:";
			// 
			// btnSelectColumns
			// 
			this.btnSelectColumns.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSelectColumns.Location = new System.Drawing.Point(308, 16);
			this.btnSelectColumns.Name = "btnSelectColumns";
			this.btnSelectColumns.Size = new System.Drawing.Size(84, 23);
			this.btnSelectColumns.TabIndex = 6;
			this.btnSelectColumns.Text = "Custom...";
			this.btnSelectColumns.Click += new System.EventHandler(this.btnSelectColumns_Click);
			// 
			// pageTable
			// 
			this.pageTable.Controls.Add(this._ctrlTableView);
			this.pageTable.ImageIndex = 2;
			this.pageTable.Location = new System.Drawing.Point(4, 23);
			this.pageTable.Name = "pageTable";
			this.pageTable.Size = new System.Drawing.Size(1016, 789);
			this.pageTable.TabIndex = 1;
			this.pageTable.Text = "Table";
			this.pageTable.Visible = false;
			// 
			// _ctrlTableView
			// 
			this._ctrlTableView.Dock = System.Windows.Forms.DockStyle.Fill;
			this._ctrlTableView.HasData = false;
			this._ctrlTableView.Location = new System.Drawing.Point(0, 0);
			this._ctrlTableView.Name = "_ctrlTableView";
			this._ctrlTableView.Size = new System.Drawing.Size(1016, 789);
			this._ctrlTableView.TabIndex = 0;
			// 
			// raExcludeDuplicateDisc
			// 
			this.raExcludeDuplicateDisc.Checked = true;
			this.raExcludeDuplicateDisc.Location = new System.Drawing.Point(188, 388);
			this.raExcludeDuplicateDisc.Name = "raExcludeDuplicateDisc";
			this.raExcludeDuplicateDisc.Size = new System.Drawing.Size(164, 24);
			this.raExcludeDuplicateDisc.TabIndex = 4;
			this.raExcludeDuplicateDisc.TabStop = true;
			this.raExcludeDuplicateDisc.Text = "Exclude duplicate disc info";
			// 
			// raIncludeDuplicateDisc
			// 
			this.raIncludeDuplicateDisc.Location = new System.Drawing.Point(24, 388);
			this.raIncludeDuplicateDisc.Name = "raIncludeDuplicateDisc";
			this.raIncludeDuplicateDisc.Size = new System.Drawing.Size(152, 24);
			this.raIncludeDuplicateDisc.TabIndex = 3;
			this.raIncludeDuplicateDisc.Text = "Include duplicate disc info";
			// 
			// ctrlSignatureOfSurfaceQuery
			// 
			this.Controls.Add(this.tabDataSource);
			this.Name = "ctrlSignatureOfSurfaceQuery";
			this.Size = new System.Drawing.Size(1024, 816);
			this.Load += new System.EventHandler(this.ctrlDataSourceQuery_Load);
			this.tabDataSource.ResumeLayout(false);
			this.pageProperties.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.pageTable.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Properties
		public DDANavigator.Controls.ctrlDataFilterCondition_SingleLayer CtrlDataFilterCondition
		{
			get { return _ctrlDataFilterCondition; }
		}

		public TimeFilter TimeFilter
		{
			get { return _ctrlTimeFilter.TimeFilter; }
			set { _ctrlTimeFilter.UpdateData(false, string.Empty, ref value) ; }
		}

		public string FabID
		{
			get { return _ctrlTimeFilter.GetFabID(); }
			set 
			{ 
				TimeFilter timeFilter = null;
				_ctrlTimeFilter.UpdateData(false, value, ref timeFilter); 
			}
		}
		#endregion

		#region UI Command
		public void SaveConfig()
		{
			_singleLayer = GetInput();
			_singleLayer.Serialize(_configPath);
		}

		public void LoadConfig()
		{
			_singleLayer = new SingleLayerRecipe();
			_singleLayer = (SingleLayerRecipe)_singleLayer.Deserialze(_configPath);

			if (_singleLayer != null)
			{
				TimeFilter timeFilter = _singleLayer.TimeFilter;
				_ctrlTimeFilter.UpdateData(false, _singleLayer.QueryCondition.FabId, ref timeFilter);
				_ctrlDataFilterCondition.DisplayInfo(_singleLayer.QueryCondition);
				_tableLayout = _singleLayer.TableLayout;

				if (_singleLayer.ExcludeDuplicateDisk)
				{
					raIncludeDuplicateDisc.Checked = false;
					raExcludeDuplicateDisc.Checked = true;
				}
				else
				{
					raIncludeDuplicateDisc.Checked = true;
					raExcludeDuplicateDisc.Checked = false;
				}
			}
		}

		public void GetTableLayoutConfig()
		{
			_tableLayout = TableLayout.GetTableLayoutConfig(FunctionType.SignatureOfSurface);
		}

		public void SetTableLayoutConfig()
		{
			TableLayout.SetTableLayoutConfig(GetTableLayout(), FunctionType.SignatureOfSurface);
		}

		public TableLayout GetTableLayout()
		{
			if(_tableLayout == null || _tableLayout.DisplayColumns == null || _tableLayout.DisplayColumns.Length <= 0)
			{
				_tableLayout = new TableLayout();
				_tableLayout.GetDefault_SourceOfSurface();
			}

			return _tableLayout;
		}

		private SingleLayerRecipe GetInput()
		{
			SingleLayerRecipe singleLayer = new SingleLayerRecipe();
			singleLayer.TimeFilter = _ctrlTimeFilter.TimeFilter;
			singleLayer.QueryCondition = _ctrlDataFilterCondition.GetQueryCondition();
			singleLayer.QueryCondition.FabId = _ctrlTimeFilter.GetFabID();
			singleLayer.TableLayout = GetTableLayout();
			singleLayer.ExcludeDuplicateDisk = raExcludeDuplicateDisc.Checked;
			return singleLayer;
		}

		private string GetSqlWhere()
		{
			string sqlWhere = string.Empty;

			string signatureCondition = Utility.GetBasicQueryCondition(WaferConst.SignatureName, _ctrlDataFilterCondition.SignatureName);
			if (signatureCondition == string.Empty) signatureCondition = "1=1";

			string gradeCondition = Utility.GetBasicQueryCondition(WaferConst.DDAGrade, _ctrlDataFilterCondition.DDAGrade);
			if (gradeCondition == string.Empty) gradeCondition = "1=1";

			sqlWhere = string.Format("({0}) AND ({1})", signatureCondition, gradeCondition);
			sqlWhere = sqlWhere.Replace(WaferConst.DDAGrade, "Grade");

			return sqlWhere;
		}

		private void SearchData()
		{
			Cursor.Current = Cursors.WaitCursor;

			_ctrlTableView.SqlWhere = _sqlWhere;
			_ctrlTableView.RefreshData(_singleLayer, FunctionType.SignatureOfSurface);
		}

		private bool CheckInfo()
		{
			bool result = true;

			if (!_ctrlTimeFilter.CheckInfo())
				result = false;
			else if (!_ctrlDataFilterCondition.CheckInfo())
				result = false;

			return result;
		}

		public void DisplayFabList()
		{
			_ctrlTimeFilter.DisplayFabList();
		}
		#endregion

		#region Windows Events Handles
		private void btnSelectColumns_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			DlgTableLayout dlg = new DlgTableLayout(_tableLayout, FunctionType.SignatureOfSurface);

			if (dlg.ShowDialog(this) == DialogResult.OK)
				_tableLayout = dlg.TableLayout;
		}

		private void ctrlDataSourceQuery_Load(object sender, System.EventArgs e)
		{
			_ctrlDataFilterCondition.Type = FunctionType.SignatureOfSurface;
			DisplayFabList();
			_ctrlDataFilterCondition.FabID = _ctrlTimeFilter.GetFabID();
			_ctrlDataFilterCondition.TimeFilter = _ctrlTimeFilter.TimeFilter;
			_ctrlTimeFilter.OnTimeChanged += new TimeChangedHandler(_ctrlTimeFilter_OnTimeChanged);
			_ctrlTimeFilter.OnFabChanged += new FabChangedHandler(_ctrlTimeFilter_OnFabChanged);
		}

		private void _ctrlTimeFilter_OnTimeChanged(TimeFilter time)
		{
			_ctrlDataFilterCondition.TimeFilter = time;
			base.RaiseTimeChanged(time);
		}

		private void _ctrlTimeFilter_OnFabChanged(string fabID)
		{
			_ctrlDataFilterCondition.FabID = fabID;
			base.RaiseFabChanged(fabID);
		}

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			if (!CheckInfo()) return;

			try
			{
                _singleLayer = GetInput();
                _sqlWhere = GetSqlWhere();
				_dlgStatus = new DlgStatus();
				System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(ThreadWorker));
				_dlgStatus.ShowDialog();

				if (!_ctrlTableView.HasData)
					MessageBox.Show(string.Format("No data in specific period time: From {0} To {1}.", _singleLayer.TimeFilter.From.ToString("MM/dd/yyyy HH:mm:ss"), _singleLayer.TimeFilter.To.ToString("MM/dd/yyyy HH:mm:ss")), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				else
					tabDataSource.SelectedIndex = 1;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);				
			}
		}
		#endregion

		#region Threading Worker
		public void ThreadWorker(object staus)
		{
			Cursor.Current = Cursors.WaitCursor;

			try
			{
				System.Threading.Thread.Sleep(1000);
				SearchData();
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
