using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace DDARecipe.Controls
{
	/// <summary>
	/// Summary description for ctrlTimeFilter.
	/// </summary>
	public class ctrlTimeFilter : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton raLastWeeks;
		private System.Windows.Forms.NumericUpDown numWeek;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RadioButton raDateTime;
		private System.Windows.Forms.NumericUpDown numDay;
		private System.Windows.Forms.RadioButton raLastDays;
		public System.Windows.Forms.DateTimePicker dtpkFrom;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.RadioButton raAll;
		private System.Windows.Forms.Button btnMore;
		private System.Windows.Forms.RadioButton raDefault;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ctrlTimeFilter()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnMore = new System.Windows.Forms.Button();
			this.raAll = new System.Windows.Forms.RadioButton();
			this.raLastWeeks = new System.Windows.Forms.RadioButton();
			this.numWeek = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.raDateTime = new System.Windows.Forms.RadioButton();
			this.numDay = new System.Windows.Forms.NumericUpDown();
			this.raLastDays = new System.Windows.Forms.RadioButton();
			this.dtpkFrom = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.raDefault = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numWeek)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numDay)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.raDefault);
			this.groupBox1.Controls.Add(this.btnMore);
			this.groupBox1.Controls.Add(this.raAll);
			this.groupBox1.Controls.Add(this.raLastWeeks);
			this.groupBox1.Controls.Add(this.numWeek);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.raDateTime);
			this.groupBox1.Controls.Add(this.numDay);
			this.groupBox1.Controls.Add(this.raLastDays);
			this.groupBox1.Controls.Add(this.dtpkFrom);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(320, 184);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Run surfaces in date range:";
			// 
			// btnMore
			// 
			this.btnMore.Location = new System.Drawing.Point(197, 144);
			this.btnMore.Name = "btnMore";
			this.btnMore.TabIndex = 7;
			this.btnMore.Text = "More...";
			this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
			// 
			// raAll
			// 
			this.raAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raAll.Location = new System.Drawing.Point(16, 48);
			this.raAll.Name = "raAll";
			this.raAll.Size = new System.Drawing.Size(68, 24);
			this.raAll.TabIndex = 0;
			this.raAll.Text = "All";
			this.raAll.CheckedChanged += new System.EventHandler(this.raAll_CheckedChanged);
			// 
			// raLastWeeks
			// 
			this.raLastWeeks.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raLastWeeks.Location = new System.Drawing.Point(16, 96);
			this.raLastWeeks.Name = "raLastWeeks";
			this.raLastWeeks.Size = new System.Drawing.Size(68, 24);
			this.raLastWeeks.TabIndex = 2;
			this.raLastWeeks.Text = "Last";
			this.raLastWeeks.CheckedChanged += new System.EventHandler(this.raLastWeeks_CheckedChanged);
			// 
			// numWeek
			// 
			this.numWeek.Enabled = false;
			this.numWeek.Location = new System.Drawing.Point(136, 96);
			this.numWeek.Maximum = new System.Decimal(new int[] {
																	100000,
																	0,
																	0,
																	0});
			this.numWeek.Minimum = new System.Decimal(new int[] {
																	1,
																	0,
																	0,
																	0});
			this.numWeek.Name = "numWeek";
			this.numWeek.Size = new System.Drawing.Size(68, 20);
			this.numWeek.TabIndex = 5;
			this.numWeek.Value = new System.Decimal(new int[] {
																  1,
																  0,
																  0,
																  0});
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(232, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Day(s)";
			// 
			// raDateTime
			// 
			this.raDateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raDateTime.Location = new System.Drawing.Point(16, 120);
			this.raDateTime.Name = "raDateTime";
			this.raDateTime.Size = new System.Drawing.Size(112, 20);
			this.raDateTime.TabIndex = 3;
			this.raDateTime.Text = "From Date/Time:";
			this.raDateTime.CheckedChanged += new System.EventHandler(this.raDateTime_CheckedChanged);
			// 
			// numDay
			// 
			this.numDay.Enabled = false;
			this.numDay.Location = new System.Drawing.Point(136, 72);
			this.numDay.Maximum = new System.Decimal(new int[] {
																   36500,
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
			this.numDay.TabIndex = 4;
			this.numDay.Value = new System.Decimal(new int[] {
																 1,
																 0,
																 0,
																 0});
			// 
			// raLastDays
			// 
			this.raLastDays.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raLastDays.Location = new System.Drawing.Point(16, 72);
			this.raLastDays.Name = "raLastDays";
			this.raLastDays.Size = new System.Drawing.Size(68, 24);
			this.raLastDays.TabIndex = 1;
			this.raLastDays.Text = "Last";
			this.raLastDays.CheckedChanged += new System.EventHandler(this.raLastDays_CheckedChanged);
			// 
			// dtpkFrom
			// 
			this.dtpkFrom.CustomFormat = "MM/dd/yyyy HH:mm:ss";
			this.dtpkFrom.Enabled = false;
			this.dtpkFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpkFrom.Location = new System.Drawing.Point(136, 120);
			this.dtpkFrom.Name = "dtpkFrom";
			this.dtpkFrom.Size = new System.Drawing.Size(136, 20);
			this.dtpkFrom.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(232, 96);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(46, 16);
			this.label5.TabIndex = 6;
			this.label5.Text = "Week(s)";
			// 
			// raDefault
			// 
			this.raDefault.Checked = true;
			this.raDefault.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raDefault.Location = new System.Drawing.Point(16, 24);
			this.raDefault.Name = "raDefault";
			this.raDefault.Size = new System.Drawing.Size(240, 24);
			this.raDefault.TabIndex = 8;
			this.raDefault.Text = "After the recipe creation time";
			// 
			// ctrlTimeFilter
			// 
			this.Controls.Add(this.groupBox1);
			this.Name = "ctrlTimeFilter";
			this.Size = new System.Drawing.Size(320, 184);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numWeek)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numDay)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void raAll_CheckedChanged(object sender, System.EventArgs e)
		{
			numDay.Enabled = numWeek.Enabled = dtpkFrom.Enabled = false;
			btnMore.Enabled = false;
		}

		private void raLastDays_CheckedChanged(object sender, System.EventArgs e)
		{
			numDay.Enabled = true;
			numWeek.Enabled = dtpkFrom.Enabled = false;
			btnMore.Enabled = true;
		}

		private void raLastWeeks_CheckedChanged(object sender, System.EventArgs e)
		{
			numWeek.Enabled = true;
			numDay.Enabled = dtpkFrom.Enabled = false;
			btnMore.Enabled = true;
		}

		private void raDateTime_CheckedChanged(object sender, System.EventArgs e)
		{
			dtpkFrom.Enabled = true;
			numDay.Enabled = numWeek.Enabled = false;
			btnMore.Enabled = true;
		}


		private void btnMore_Click(object sender, System.EventArgs e)
		{
			Dialogs.DlgMoreCondition dlg = new Dialogs.DlgMoreCondition();
			dlg.Data = MoreData;
			if( dlg.ShowDialog(this) == DialogResult.OK)
			{
				MoreData = dlg.Data;
			}
		}

		public SiGlaz.Common.DDA.Basic.GradeCondition MoreData;
		public SiGlaz.Common.DDA.Basic.TimeFilter Data
		{
			get
			{
				if(raAll.Checked)
					return null;

				SiGlaz.Common.DDA.Basic.TimeFilter result = new SiGlaz.Common.DDA.Basic.TimeFilter();
				
				if(raDefault.Checked)
				{
					result.Type = SiGlaz.Common.DDA.TimeRangeType.LastNHours;
					result.N = -1;
				}
				else if(raLastDays.Checked)
				{
					result.Type = SiGlaz.Common.DDA.TimeRangeType.LastNDays;
					result.N = (int)numDay.Value;
				}
				else if(raLastWeeks.Checked)
				{
					result.Type = SiGlaz.Common.DDA.TimeRangeType.LastNWeeks;
					result.N = (int)numWeek.Value;
				}
				else
				{
					result.Type = SiGlaz.Common.DDA.TimeRangeType.FromDateToDate;
					result.From = dtpkFrom.Value;
				}

				return result;
			}
			set
			{
				if(value==null) 
				{
					raAll.Checked = true;
					return;
				}

				if(value.Type == SiGlaz.Common.DDA.TimeRangeType.LastNHours)
				{
					if( value.N == -1)
					{
						raDefault.Checked = true;
					}
				}
				else if(value.Type == SiGlaz.Common.DDA.TimeRangeType.LastNDays)
				{
					raLastDays.Checked = true;
					numDay.Value = value.N;
				}
				else if(value.Type == SiGlaz.Common.DDA.TimeRangeType.LastNWeeks)
				{
					raLastWeeks.Checked = true;
					numWeek.Value = value.N;
				}
				else
				{
					raDateTime.Checked = true;
					dtpkFrom.Value = value.From;
				}

			}
		}
		
	}
}
