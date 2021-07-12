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

namespace DDANavigator.Controls
{
	public class ctrlParetoChartQuery : ctrlBase
	{
		#region Members
		private System.Windows.Forms.ImageList _imgList;
		private System.Windows.Forms.TabPage pageProperties;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TabPage pageTable;
		private System.Windows.Forms.TabControl tabParetoChart;
		private System.ComponentModel.IContainer components;
		private string _configPath = string.Format("{0}\\ParetoChart.xml", AppData.ApplicationDataPath);
		private SingleLayerRecipe _singleLayer = null;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private DDANavigator.Controls.ctrlTimeFilter _ctrlTimeFilter;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.RadioButton raExcludeDuplicateDisc;
		private System.Windows.Forms.RadioButton raIncludeDuplicateDisc;
		private DDANavigator.Controls.ctrlDataFilterCondition_SingleLayer _ctrlDataFilterCondition;
        private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.RadioButton raIndividualTestCell;
		private System.Windows.Forms.RadioButton raIndividualResource;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel pGroupBy;
		private System.Windows.Forms.ComboBox cboGroupBy;
		private System.Windows.Forms.Label lbGroupBy;
		private WebServiceProxy.SingleLayerProxy.ChartResult _result = null;
        private ctrlChartView2 _ctrlChartView2;
		private bool _flag = true;
		#endregion
		
		#region Constructor & Destructor
		public ctrlParetoChartQuery()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlParetoChartQuery));
            this._imgList = new System.Windows.Forms.ImageList(this.components);
            this.pageProperties = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._ctrlTimeFilter = new DDANavigator.Controls.ctrlTimeFilter();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.raIndividualResource = new System.Windows.Forms.RadioButton();
            this.raIndividualTestCell = new System.Windows.Forms.RadioButton();
            this.raExcludeDuplicateDisc = new System.Windows.Forms.RadioButton();
            this.raIncludeDuplicateDisc = new System.Windows.Forms.RadioButton();
            this._ctrlDataFilterCondition = new DDANavigator.Controls.ctrlDataFilterCondition_SingleLayer();
            this.pageTable = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this._ctrlChartView2 = new DDANavigator.Controls.ctrlChartView2();
            this.pGroupBy = new System.Windows.Forms.Panel();
            this.cboGroupBy = new System.Windows.Forms.ComboBox();
            this.lbGroupBy = new System.Windows.Forms.Label();
            this.tabParetoChart = new System.Windows.Forms.TabControl();
            this.pageProperties.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pageTable.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pGroupBy.SuspendLayout();
            this.tabParetoChart.SuspendLayout();
            this.SuspendLayout();
            // 
            // _imgList
            // 
            this._imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imgList.ImageStream")));
            this._imgList.TransparentColor = System.Drawing.Color.Transparent;
            this._imgList.Images.SetKeyName(0, "");
            this._imgList.Images.SetKeyName(1, "");
            this._imgList.Images.SetKeyName(2, "");
            this._imgList.Images.SetKeyName(3, "");
            // 
            // pageProperties
            // 
            this.pageProperties.Controls.Add(this.panel1);
            this.pageProperties.ImageIndex = 0;
            this.pageProperties.Location = new System.Drawing.Point(4, 23);
            this.pageProperties.Name = "pageProperties";
            this.pageProperties.Size = new System.Drawing.Size(1036, 845);
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
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1036, 845);
            this.panel1.TabIndex = 35;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSearch.Location = new System.Drawing.Point(12, 664);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(76, 23);
            this.btnSearch.TabIndex = 41;
            this.btnSearch.Text = "&Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(0, 652);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1012, 4);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._ctrlTimeFilter);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(12, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(432, 188);
            this.groupBox3.TabIndex = 37;
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
            this.groupBox6.Controls.Add(this.panel2);
            this.groupBox6.Controls.Add(this.raExcludeDuplicateDisc);
            this.groupBox6.Controls.Add(this.raIncludeDuplicateDisc);
            this.groupBox6.Controls.Add(this._ctrlDataFilterCondition);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox6.Location = new System.Drawing.Point(12, 200);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(432, 444);
            this.groupBox6.TabIndex = 38;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "2. Select Data Range";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.raIndividualResource);
            this.panel2.Controls.Add(this.raIndividualTestCell);
            this.panel2.Location = new System.Drawing.Point(20, 412);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(296, 24);
            this.panel2.TabIndex = 7;
            // 
            // raIndividualResource
            // 
            this.raIndividualResource.Location = new System.Drawing.Point(4, 4);
            this.raIndividualResource.Name = "raIndividualResource";
            this.raIndividualResource.Size = new System.Drawing.Size(152, 24);
            this.raIndividualResource.TabIndex = 5;
            this.raIndividualResource.Text = "Individual Resource";
            // 
            // raIndividualTestCell
            // 
            this.raIndividualTestCell.Checked = true;
            this.raIndividualTestCell.Location = new System.Drawing.Point(168, 4);
            this.raIndividualTestCell.Name = "raIndividualTestCell";
            this.raIndividualTestCell.Size = new System.Drawing.Size(152, 24);
            this.raIndividualTestCell.TabIndex = 6;
            this.raIndividualTestCell.TabStop = true;
            this.raIndividualTestCell.Text = "Individual Test Cell";
            // 
            // raExcludeDuplicateDisc
            // 
            this.raExcludeDuplicateDisc.Location = new System.Drawing.Point(188, 388);
            this.raExcludeDuplicateDisc.Name = "raExcludeDuplicateDisc";
            this.raExcludeDuplicateDisc.Size = new System.Drawing.Size(164, 24);
            this.raExcludeDuplicateDisc.TabIndex = 4;
            this.raExcludeDuplicateDisc.Text = "Exclude duplicate disc info";
            // 
            // raIncludeDuplicateDisc
            // 
            this.raIncludeDuplicateDisc.Checked = true;
            this.raIncludeDuplicateDisc.Location = new System.Drawing.Point(24, 388);
            this.raIncludeDuplicateDisc.Name = "raIncludeDuplicateDisc";
            this.raIncludeDuplicateDisc.Size = new System.Drawing.Size(152, 24);
            this.raIncludeDuplicateDisc.TabIndex = 3;
            this.raIncludeDuplicateDisc.TabStop = true;
            this.raIncludeDuplicateDisc.Text = "Include duplicate disc info";
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
            // pageTable
            // 
            this.pageTable.Controls.Add(this.panel3);
            this.pageTable.Controls.Add(this.pGroupBy);
            this.pageTable.ImageIndex = 1;
            this.pageTable.Location = new System.Drawing.Point(4, 23);
            this.pageTable.Name = "pageTable";
            this.pageTable.Size = new System.Drawing.Size(1036, 845);
            this.pageTable.TabIndex = 1;
            this.pageTable.Text = "Chart";
            this.pageTable.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._ctrlChartView2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1036, 818);
            this.panel3.TabIndex = 2;
            // 
            // _ctrlChartView2
            // 
            this._ctrlChartView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ctrlChartView2.Location = new System.Drawing.Point(0, 0);
            this._ctrlChartView2.Name = "_ctrlChartView2";
            this._ctrlChartView2.Size = new System.Drawing.Size(1036, 818);
            this._ctrlChartView2.TabIndex = 1;
            // 
            // pGroupBy
            // 
            this.pGroupBy.Controls.Add(this.cboGroupBy);
            this.pGroupBy.Controls.Add(this.lbGroupBy);
            this.pGroupBy.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pGroupBy.Location = new System.Drawing.Point(0, 818);
            this.pGroupBy.Name = "pGroupBy";
            this.pGroupBy.Size = new System.Drawing.Size(1036, 27);
            this.pGroupBy.TabIndex = 1;
            // 
            // cboGroupBy
            // 
            this.cboGroupBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGroupBy.Enabled = false;
            this.cboGroupBy.Location = new System.Drawing.Point(80, 4);
            this.cboGroupBy.Name = "cboGroupBy";
            this.cboGroupBy.Size = new System.Drawing.Size(140, 21);
            this.cboGroupBy.TabIndex = 1;
            this.cboGroupBy.SelectedIndexChanged += new System.EventHandler(this.cboGroupBy_SelectedIndexChanged);
            // 
            // lbGroupBy
            // 
            this.lbGroupBy.AutoSize = true;
            this.lbGroupBy.Location = new System.Drawing.Point(8, 8);
            this.lbGroupBy.Name = "lbGroupBy";
            this.lbGroupBy.Size = new System.Drawing.Size(51, 13);
            this.lbGroupBy.TabIndex = 0;
            this.lbGroupBy.Text = "Test Cell:";
            // 
            // tabParetoChart
            // 
            this.tabParetoChart.Controls.Add(this.pageProperties);
            this.tabParetoChart.Controls.Add(this.pageTable);
            this.tabParetoChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabParetoChart.ImageList = this._imgList;
            this.tabParetoChart.ItemSize = new System.Drawing.Size(81, 19);
            this.tabParetoChart.Location = new System.Drawing.Point(0, 0);
            this.tabParetoChart.Name = "tabParetoChart";
            this.tabParetoChart.SelectedIndex = 0;
            this.tabParetoChart.Size = new System.Drawing.Size(1044, 872);
            this.tabParetoChart.TabIndex = 3;
            // 
            // ctrlParetoChartQuery
            // 
            this.Controls.Add(this.tabParetoChart);
            this.Name = "ctrlParetoChartQuery";
            this.Size = new System.Drawing.Size(1044, 872);
            this.Load += new System.EventHandler(this.ctrlParetoChartQuery_Load);
            this.pageProperties.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pageTable.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.pGroupBy.ResumeLayout(false);
            this.pGroupBy.PerformLayout();
            this.tabParetoChart.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region	Properties
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

		public DDANavigator.Controls.ctrlDataFilterCondition_SingleLayer CtrlDataFilterCondition
		{
			get { return _ctrlDataFilterCondition; }
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

				if (_singleLayer.GroupBy == "TestCell")
				{
					raIndividualResource.Checked = false;
					raIndividualTestCell.Checked = true;

					if (_ctrlDataFilterCondition.ResourceType == "(All)")
						raIndividualResource.Enabled = false;
					else
						raIndividualResource.Enabled = true;

				}
				else
				{
					if (_ctrlDataFilterCondition.ResourceType == "(All)")
					{
						raIndividualResource.Enabled = false;
						raIndividualResource.Checked = false;
						raIndividualTestCell.Checked = true;
					}
					else
					{
						raIndividualResource.Enabled = true;
						raIndividualResource.Checked = true;
						raIndividualTestCell.Checked = false;
					}
				}
			}
		}


		public void DisplayFabList()
		{
			_ctrlTimeFilter.DisplayFabList();
		}


		private SingleLayerRecipe GetInput()
		{
			SingleLayerRecipe singleLayer = new SingleLayerRecipe();
			singleLayer.TimeFilter = _ctrlTimeFilter.TimeFilter;
			singleLayer.QueryCondition = _ctrlDataFilterCondition.GetQueryCondition();
			singleLayer.QueryCondition.FabId = _ctrlTimeFilter.GetFabID();
			singleLayer.ExcludeDuplicateDisk = raExcludeDuplicateDisc.Checked;
			
			if (raIndividualResource.Checked)
				singleLayer.GroupBy = _ctrlDataFilterCondition.ResourceType;
			else
				singleLayer.GroupBy = "TestCell";

			return singleLayer;
		}


		private void SearchData()
		{
			Cursor.Current = Cursors.WaitCursor;
			
			ClearChart();
			WebServiceProxy.SingleLayerProxy.SingleLayerRecipe input = (WebServiceProxy.SingleLayerProxy.SingleLayerRecipe)WebServiceProxy.ConvertProxy.Convert(_singleLayer, typeof(WebServiceProxy.SingleLayerProxy.SingleLayerRecipe));
			WebServiceProxy.SingleLayerProxy.SingleLayer service = WebServiceProxy.WebProxyFactory.CreateSingleLayer();
			if (service == null) return;
			_result = service.GetSignatureParetoChartIndividualResource_TestCell(input, (WebServiceProxy.SingleLayerProxy.DDADBType)AppData.Data.DBType);

			if (_result == null || _result.CategoryValues == null || _result.CategoryValues.Length <= 0)
			{
				MessageBox.Show(string.Format("No data in specific period time: From {0} To {1}.", _singleLayer.TimeFilter.From.ToString("MM/dd/yyyy HH:mm:ss"), _singleLayer.TimeFilter.To.ToString("MM/dd/yyyy HH:mm:ss")), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				_result = null;
				cboGroupBy.Enabled = false;
			}
			else
				InitGroupBy(_result);
		}

		private void InitGroupBy(WebServiceProxy.SingleLayerProxy.ChartResult result)
		{
			if (!this.InvokeRequired)
			{
				if (raIndividualTestCell.Checked)
					lbGroupBy.Text = "Test Cell";
				else
					lbGroupBy.Text = _ctrlDataFilterCondition.ResourceType;

				_flag = false;
				cboGroupBy.Items.Clear();
				cboGroupBy.Items.Add("(All)");

				foreach (WebServiceProxy.SingleLayerProxy.IndividualChartResult groupBy in result.IndividualChartResults)
					cboGroupBy.Items.Add(groupBy.GroupByName);

				_flag = true;

				cboGroupBy.SelectedIndex = 0;
				tabParetoChart.SelectedIndex = 1;
				cboGroupBy.Enabled = true;
			}
			else 
			{
				object[] obj = new object[1];
				obj[0] = result;
				this.BeginInvoke(new InitGroupByHandler(InitGroupBy), obj);
			}
		}

		private void ClearChart()
		{
            if (!this.InvokeRequired)
            {
                _ctrlChartView2.ClearChart();
            }
            else
                this.BeginInvoke(new ClearChartHandler(ClearChart));
		}


		private void ViewChart(WebServiceProxy.SingleLayerProxy.ChartResult result)
		{
			if (!this.InvokeRequired)
			{
				Cursor.Current = Cursors.WaitCursor;
                _ctrlChartView2.ClearChart();
				result.DataTitle = "Qty";
				result.DataTitle2 = "Yield (%)";
				result.CategoryTitle = "Grade-Signature";

				if (_ctrlDataFilterCondition.ResourceType == "(All)")
				{
					if (_ctrlDataFilterCondition.ResourceID == null || _ctrlDataFilterCondition.ResourceID.Trim() == string.Empty)
						result.ChartTitle = string.Format("MRS Defect Pareto by DDA Signature\nFrom: {0} - To: {1}", _singleLayer.TimeFilter.From.ToString("MM/dd/yyyy HH:mm:ss"), _singleLayer.TimeFilter.To.ToString("MM/dd/yyyy HH:mm:ss"));
					else
						result.ChartTitle = string.Format("MRS Defect Pareto by DDA Signature\nby Resource: '{0}'\nFrom: {1} - To: {2}", _ctrlDataFilterCondition.ResourceID,_singleLayer.TimeFilter.From.ToString("MM/dd/yyyy HH:mm:ss"), _singleLayer.TimeFilter.To.ToString("MM/dd/yyyy HH:mm:ss"));
				}
				else
				{
					if (_ctrlDataFilterCondition.ResourceID == null || _ctrlDataFilterCondition.ResourceID.Trim() == string.Empty)
						result.ChartTitle = string.Format("MRS Defect Pareto by DDA Signature\nby Operation: '{0}'\nFrom: {1} - To: '{2}'", _ctrlDataFilterCondition.ResourceType,_singleLayer.TimeFilter.From.ToString("MM/dd/yyyy HH:mm:ss"), _singleLayer.TimeFilter.To.ToString("MM/dd/yyyy HH:mm:ss"));
					else
						result.ChartTitle = string.Format("MRS Defect Pareto by DDA Signature\nby Operation: '{0}' by Resource: '{1}'\nFrom: {2} - To: '{3}'", _ctrlDataFilterCondition.ResourceType, _ctrlDataFilterCondition.ResourceID,_singleLayer.TimeFilter.From.ToString("MM/dd/yyyy HH:mm:ss"), _singleLayer.TimeFilter.To.ToString("MM/dd/yyyy HH:mm:ss"));
				}

                _ctrlChartView2.CreateSignatureParetoChart(result);
				
			}
			else 
			{
				object[] obj = new object[1];
				obj[0] = result;
				this.BeginInvoke(new ViewChartHandler(ViewChart), obj);
			}
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
		#endregion

		#region Windows Events Handles
		private void ctrlParetoChartQuery_Load(object sender, System.EventArgs e)
		{
			_ctrlDataFilterCondition.Type = FunctionType.SingleLayer;
			DisplayFabList();
			_ctrlDataFilterCondition.FabID = _ctrlTimeFilter.GetFabID();
			_ctrlDataFilterCondition.TimeFilter = _ctrlTimeFilter.TimeFilter;
			_ctrlTimeFilter.OnTimeChanged += new TimeChangedHandler(_ctrlTimeFilter_OnTimeChanged);
			_ctrlTimeFilter.OnFabChanged += new FabChangedHandler(_ctrlTimeFilter_OnFabChanged);
			_ctrlDataFilterCondition.OnResourceTypeChanged += new ResourceTypeChangedHandler(_ctrlDataFilterCondition_OnResourceTypeChanged);
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
                _dlgStatus = new DlgStatus();
                System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(ThreadWorker));
                _dlgStatus.ShowDialog();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
		}


		private void _ctrlDataFilterCondition_OnResourceTypeChanged(string resourceType)
		{
			if (resourceType == "(All)")
			{
				raIndividualResource.Checked = false;
				raIndividualResource.Enabled = false;
				raIndividualTestCell.Checked = true;
			}
			else
				raIndividualResource.Enabled = true;
		}

		private void cboGroupBy_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cboGroupBy.Text == "(All)")
				ViewChart(_result);
			else
			{
				string value = cboGroupBy.Text.ToLower();
				foreach (WebServiceProxy.SingleLayerProxy.IndividualChartResult chartResult in _result.IndividualChartResults)
				{
					if (chartResult.GroupByName.ToLower() == value)
					{
						ViewChart(chartResult.Result);
						return;
					}
				}
			}
		}
		#endregion

		#region Threading Worker
		public void ThreadWorker(object status)
		{
			Cursor.Current = Cursors.WaitCursor;

			try
			{
				System.Threading.Thread.Sleep(1000);
				SearchData();
			}
			catch (System.Exception e)
			{
				MessageBox.Show(e.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
                base.CloseDialogWaiting();
			}
		}
		#endregion
	}
}
