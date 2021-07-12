using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace DDANavigator.Controls
{
	#region Delegate Evetns
	public delegate void TimeChangedHandler(SiGlaz.Common.DDA.Basic.TimeFilter time);
	public delegate void FabChangedHandler(string fabID);
	#endregion

	public class ctrlTimeFilter : System.Windows.Forms.UserControl
	{
		#region Events
		public event TimeChangedHandler OnTimeChanged;
		public event FabChangedHandler OnFabChanged;
		#endregion

		#region Members
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numWeek;
		private System.Windows.Forms.RadioButton raLastWeeks;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numDay;
		private System.Windows.Forms.RadioButton raLastDays;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numHour;
		private System.Windows.Forms.RadioButton raLastHours;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.DateTimePicker dtpkTo;
		public System.Windows.Forms.DateTimePicker dtpkFrom;
		private System.Windows.Forms.ComboBox cboFabID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton raDateTime;
		private System.ComponentModel.Container components = null;
		private bool _isSaved = true;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.GroupBox groupBox1;
		#endregion

		#region Constructor & Destructor
		public ctrlTimeFilter()
		{
			InitializeComponent();

			InitData();
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
			this.label5 = new System.Windows.Forms.Label();
			this.numWeek = new System.Windows.Forms.NumericUpDown();
			this.raLastWeeks = new System.Windows.Forms.RadioButton();
			this.label4 = new System.Windows.Forms.Label();
			this.numDay = new System.Windows.Forms.NumericUpDown();
			this.raLastDays = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.numHour = new System.Windows.Forms.NumericUpDown();
			this.raLastHours = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.dtpkTo = new System.Windows.Forms.DateTimePicker();
			this.dtpkFrom = new System.Windows.Forms.DateTimePicker();
			this.cboFabID = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.raDateTime = new System.Windows.Forms.RadioButton();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.numWeek)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numDay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numHour)).BeginInit();
			this.groupBox4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(176, 80);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(46, 16);
			this.label5.TabIndex = 32;
			this.label5.Text = "Week(s)";
			// 
			// numWeek
			// 
			this.numWeek.Enabled = false;
			this.numWeek.Location = new System.Drawing.Point(104, 76);
			this.numWeek.Minimum = new System.Decimal(new int[] {
																	1,
																	0,
																	0,
																	0});
			this.numWeek.Name = "numWeek";
			this.numWeek.Size = new System.Drawing.Size(68, 20);
			this.numWeek.TabIndex = 11;
			this.numWeek.Value = new System.Decimal(new int[] {
																  1,
																  0,
																  0,
																  0});
			this.numWeek.ValueChanged += new System.EventHandler(this.HandlerTimeChange);
			this.numWeek.Leave += new System.EventHandler(this.HandlerTimeChange);
			// 
			// raLastWeeks
			// 
			this.raLastWeeks.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raLastWeeks.Location = new System.Drawing.Point(20, 76);
			this.raLastWeeks.Name = "raLastWeeks";
			this.raLastWeeks.Size = new System.Drawing.Size(68, 24);
			this.raLastWeeks.TabIndex = 10;
			this.raLastWeeks.Text = "Last";
			this.raLastWeeks.CheckedChanged += new System.EventHandler(this.HandlerTimeChange);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(176, 60);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 16);
			this.label4.TabIndex = 29;
			this.label4.Text = "Day(s)";
			// 
			// numDay
			// 
			this.numDay.Enabled = false;
			this.numDay.Location = new System.Drawing.Point(104, 56);
			this.numDay.Maximum = new System.Decimal(new int[] {
																   7,
																   0,
																   0,
																   0});
			this.numDay.Minimum = new System.Decimal(new int[] {
																   1,
																   0,
																   0,
																   0});
			this.numDay.Name = "numDay";
			this.numDay.Size = new System.Drawing.Size(68, 20);
			this.numDay.TabIndex = 9;
			this.numDay.Value = new System.Decimal(new int[] {
																 1,
																 0,
																 0,
																 0});
			this.numDay.ValueChanged += new System.EventHandler(this.HandlerTimeChange);
			this.numDay.Leave += new System.EventHandler(this.HandlerTimeChange);
			// 
			// raLastDays
			// 
			this.raLastDays.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raLastDays.Location = new System.Drawing.Point(20, 56);
			this.raLastDays.Name = "raLastDays";
			this.raLastDays.Size = new System.Drawing.Size(68, 24);
			this.raLastDays.TabIndex = 8;
			this.raLastDays.Text = "Last";
			this.raLastDays.CheckedChanged += new System.EventHandler(this.HandlerTimeChange);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(176, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 16);
			this.label3.TabIndex = 26;
			this.label3.Text = "Hour(s)";
			// 
			// numHour
			// 
			this.numHour.Enabled = false;
			this.numHour.Location = new System.Drawing.Point(104, 36);
			this.numHour.Maximum = new System.Decimal(new int[] {
																	24,
																	0,
																	0,
																	0});
			this.numHour.Minimum = new System.Decimal(new int[] {
																	1,
																	0,
																	0,
																	0});
			this.numHour.Name = "numHour";
			this.numHour.Size = new System.Drawing.Size(68, 20);
			this.numHour.TabIndex = 7;
			this.numHour.Value = new System.Decimal(new int[] {
																  1,
																  0,
																  0,
																  0});
			this.numHour.ValueChanged += new System.EventHandler(this.HandlerTimeChange);
			this.numHour.Leave += new System.EventHandler(this.HandlerTimeChange);
			// 
			// raLastHours
			// 
			this.raLastHours.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raLastHours.Location = new System.Drawing.Point(20, 36);
			this.raLastHours.Name = "raLastHours";
			this.raLastHours.Size = new System.Drawing.Size(68, 24);
			this.raLastHours.TabIndex = 6;
			this.raLastHours.Text = "Last";
			this.raLastHours.CheckedChanged += new System.EventHandler(this.HandlerTimeChange);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(236, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(8, 16);
			this.label2.TabIndex = 23;
			this.label2.Text = "-";
			// 
			// dtpkTo
			// 
			this.dtpkTo.CustomFormat = "MM/dd/yyyy HH:mm:ss";
			this.dtpkTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpkTo.Location = new System.Drawing.Point(244, 16);
			this.dtpkTo.Name = "dtpkTo";
			this.dtpkTo.Size = new System.Drawing.Size(132, 20);
			this.dtpkTo.TabIndex = 5;
			this.dtpkTo.Leave += new System.EventHandler(this.HandlerTimeChange);
			this.dtpkTo.ValueChanged += new System.EventHandler(this.HandlerTimeChange);
			// 
			// dtpkFrom
			// 
			this.dtpkFrom.CustomFormat = "MM/dd/yyyy HH:mm:ss";
			this.dtpkFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpkFrom.Location = new System.Drawing.Point(104, 16);
			this.dtpkFrom.Name = "dtpkFrom";
			this.dtpkFrom.Size = new System.Drawing.Size(132, 20);
			this.dtpkFrom.TabIndex = 4;
			this.dtpkFrom.Leave += new System.EventHandler(this.HandlerTimeChange);
			this.dtpkFrom.ValueChanged += new System.EventHandler(this.HandlerTimeChange);
			// 
			// cboFabID
			// 
			this.cboFabID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFabID.Location = new System.Drawing.Point(68, 18);
			this.cboFabID.Name = "cboFabID";
			this.cboFabID.Size = new System.Drawing.Size(240, 21);
			this.cboFabID.TabIndex = 1;
			this.cboFabID.SelectedIndexChanged += new System.EventHandler(this.cboFabID_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 18;
			this.label1.Text = "Plant ID:";
			// 
			// raDateTime
			// 
			this.raDateTime.Checked = true;
			this.raDateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raDateTime.Location = new System.Drawing.Point(20, 16);
			this.raDateTime.Name = "raDateTime";
			this.raDateTime.Size = new System.Drawing.Size(80, 20);
			this.raDateTime.TabIndex = 3;
			this.raDateTime.TabStop = true;
			this.raDateTime.Text = "Date/Time";
			this.raDateTime.CheckedChanged += new System.EventHandler(this.HandlerTimeChange);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.btnRefresh);
			this.groupBox4.Controls.Add(this.cboFabID);
			this.groupBox4.Controls.Add(this.label1);
			this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox4.Location = new System.Drawing.Point(0, 0);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(392, 48);
			this.groupBox4.TabIndex = 0;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Select Plant ID";
			// 
			// btnRefresh
			// 
			this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnRefresh.Location = new System.Drawing.Point(312, 16);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(64, 23);
			this.btnRefresh.TabIndex = 19;
			this.btnRefresh.Text = "&Refresh";
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.raLastWeeks);
			this.groupBox1.Controls.Add(this.numWeek);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.raDateTime);
			this.groupBox1.Controls.Add(this.numDay);
			this.groupBox1.Controls.Add(this.raLastDays);
			this.groupBox1.Controls.Add(this.dtpkTo);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.dtpkFrom);
			this.groupBox1.Controls.Add(this.numHour);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.raLastHours);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(0, 52);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(392, 104);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Select Test Date Condition";
			// 
			// ctrlTimeFilter
			// 
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox4);
			this.Name = "ctrlTimeFilter";
			this.Size = new System.Drawing.Size(392, 156);
			this.Load += new System.EventHandler(this.ctrlTimeFilter_Load);
			((System.ComponentModel.ISupportInitialize)(this.numWeek)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numDay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numHour)).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Properties
		public bool IsSaved
		{
			get { return _isSaved; }
			set { _isSaved = value; }
		}

		public DateTimePicker FromDate
		{
			get { return dtpkFrom; }
		}

		public DateTimePicker ToDate
		{
			get { return dtpkTo; }
		}

		public RadioButton RadioDateTime
		{
			get { return raDateTime; }
		}

		public RadioButton RadioLastHours
		{
			get { return raLastHours; }
		}

		public RadioButton RadioLastDays
		{
			get { return raLastDays; }
		}

		public RadioButton RadioLastWeeks
		{
			get { return raLastWeeks; }
		}

		public NumericUpDown NumericHour
		{
			get { return numHour; }
		}

		public NumericUpDown NumericDay
		{
			get { return numDay; }
		}

		public NumericUpDown NumericWeek
		{
			get { return numWeek; }
		}

		public ComboBox ComboFabID
		{
			get { return cboFabID; }
		}
		#endregion

		#region UI Command
		private void InitData()
		{
			dtpkTo.Value = DateTime.Now;
			dtpkFrom.Value = DateTime.Now.AddDays(-7);
			numHour.Value = 12;
		}

		public void DisplayFabList()
		{
			string fab = cboFabID.Text;
			cboFabID.Items.Clear();

			WebServiceProxy.WebProxyFactory.MessageType = WebServiceProxy.WebProxyFactory.eMessageType.None;
			WebServiceProxy.CategoryProxy.Category cmd = WebServiceProxy.WebProxyFactory.CreateCategory();
			WebServiceProxy.WebProxyFactory.MessageType = WebServiceProxy.WebProxyFactory.eMessageType.WindowMessage;

			if(cmd == null) 
				return;

			WebServiceProxy.CategoryProxy.DataSetResult result = cmd.FabList();
			ArrayList fabIDList = new ArrayList();
			if(result.Description == string.Empty && result.Result != null && result.Result.Tables.Count > 0)
			{
				foreach(DataRow row in result.Result.Tables[0].Rows)
				{
					if( row["FabID"]!= DBNull.Value )
						fabIDList.Add( row["FabID"].ToString() );	
				}
			}

			foreach (string fabID in fabIDList)
				cboFabID.Items.Add(fabID);

			if (cboFabID.Items.Count > 0)
				cboFabID.SelectedIndex = 0;

			for (int i = 0; i < cboFabID.Items.Count; i++)
			{
				if (fab.ToLower() == cboFabID.Items[i].ToString().ToLower())
				{
					cboFabID.SelectedIndex = i;
					break;
				}
			}
		}

		public SiGlaz.Common.DDA.Basic.TimeFilter TimeFilter
		{
			get
			{
				SiGlaz.Common.DDA.Basic.TimeFilter result = null;
				UpdateData(true, null, ref result);
				return result;
			}
		}

		public void UpdateData(bool update, string fabID, ref SiGlaz.Common.DDA.Basic.TimeFilter timeFilter)
		{
			if(update)
			{
				if(timeFilter==null)
					 timeFilter = new SiGlaz.Common.DDA.Basic.TimeFilter();

				if (raDateTime.Checked)
				{
					timeFilter.Type =  SiGlaz.Common.DDA.TimeRangeType.FromDateToDate;
					timeFilter.From = dtpkFrom.Value;
					timeFilter.To = dtpkTo.Value;
				}
				else if (raLastHours.Checked)
				{
					timeFilter.Type = SiGlaz.Common.DDA.TimeRangeType.LastNHours;
					timeFilter.N = (int)numHour.Value;
				}
				else if (raLastDays.Checked)
				{
					timeFilter.Type = SiGlaz.Common.DDA.TimeRangeType.LastNDays;
					timeFilter.N = (int)numDay.Value;
				}
				else
				{
					timeFilter.Type = SiGlaz.Common.DDA.TimeRangeType.LastNWeeks;
					timeFilter.N = (int)numWeek.Value;
				}
			}
			else
			{
				//FabID
				for(int i = 0; i < cboFabID.Items.Count; i++)
				{
					if (fabID.ToLower() == cboFabID.Items[i].ToString().ToLower())
					{
						cboFabID.SelectedIndex = i;
						break;
					}
				}

					//Time Filter
				if (timeFilter != null)
				{
					switch (timeFilter.Type)
					{
						case SiGlaz.Common.DDA.TimeRangeType.FromDateToDate:
							raDateTime.Checked = true;
							raLastHours.Checked = false;
							raLastDays.Checked = false;
							raLastWeeks.Checked = false;
							dtpkFrom.Value = timeFilter.From;
							dtpkTo.Value = timeFilter.To;
							break;
						case SiGlaz.Common.DDA.TimeRangeType.LastNHours:
							raDateTime.Checked = false;
							raLastHours.Checked = true;
							raLastDays.Checked = false;
							raLastWeeks.Checked = false;
							numHour.Value = (Decimal)timeFilter.N;
							break;
						case SiGlaz.Common.DDA.TimeRangeType.LastNDays:
							raDateTime.Checked = false;
							raLastHours.Checked = false;
							raLastDays.Checked = true;
							raLastWeeks.Checked = false;
							numDay.Value = (Decimal)timeFilter.N;
							break;
						case SiGlaz.Common.DDA.TimeRangeType.LastNWeeks:
							raDateTime.Checked = false;
							raLastHours.Checked = false;
							raLastDays.Checked = false;
							raLastWeeks.Checked = true;
							numWeek.Value = (Decimal)timeFilter.N;
							break;
					}
				}
		
			}
		}

		private void RefreshTimeFilter()
		{
			if (raDateTime.Checked)
			{
				dtpkFrom.Enabled = true;
				dtpkTo.Enabled = true;
				numHour.Enabled = false;
				numDay.Enabled = false;
				numWeek.Enabled = false;
			}
			else if (raLastHours.Checked)
			{
				dtpkFrom.Enabled = false;
				dtpkTo.Enabled = false;
				numHour.Enabled = true;
				numDay.Enabled = false;
				numWeek.Enabled = false;
			}
			else if (raLastDays.Checked)
			{
				dtpkFrom.Enabled = false;
				dtpkTo.Enabled = false;
				numHour.Enabled = false;
				numDay.Enabled = true;
				numWeek.Enabled = false;
			}
			else
			{
				dtpkFrom.Enabled = false;
				dtpkTo.Enabled = false;
				numHour.Enabled = false;
				numDay.Enabled = false;
				numWeek.Enabled = true;
			}
		}
		
		public string GetFabID()
		{
			return cboFabID.Text;
		}

		public bool CheckInfo()
		{
			bool result = true;

			if (cboFabID.Text == "")
			{
				result = false;
				MessageBox.Show("Please select Plant ID.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else if (dtpkFrom.Value > dtpkTo.Value)
			{
				result = false;
				dtpkFrom.Value = dtpkTo.Value.Date;
				MessageBox.Show("The date in the From box must be less than one in the To box.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			return result;
		}
		#endregion

		#region Windows Events Handles

		private void HandlerTimeChange(object sender, System.EventArgs e)
		{
			RefreshTimeFilter();
			_isSaved = false;

			if( OnTimeChanged != null)
				OnTimeChanged(this.TimeFilter);
		}
		
		private void cboFabID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			_isSaved = false;
		
			if (OnFabChanged != null)
				OnFabChanged(GetFabID());
		}

		private void ctrlTimeFilter_Load(object sender, System.EventArgs e)
		{
		}

		private void btnRefresh_Click(object sender, System.EventArgs e)
		{
			DisplayFabList();	
		}
		#endregion
	}
}
