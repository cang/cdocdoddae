using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DDADBManager.Dialog
{
	/// <summary>
	/// Summary description for Form2.
	/// </summary>
	public class DeleteEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox cboDelayType;
		private System.Windows.Forms.NumericUpDown nudDelay;
		private System.Windows.Forms.RadioButton raRunByDelay;
		private System.Windows.Forms.LinkLabel hpToDDAStagingArea;
		private System.Windows.Forms.LinkLabel hpFromDDAStagingArea;
		private System.Windows.Forms.LinkLabel hpDDAArchive;
		private System.Windows.Forms.Button btnDestination;
		private System.Windows.Forms.DateTimePicker dtByDayAt;
		private System.Windows.Forms.ComboBox cboDay;
		private System.Windows.Forms.RadioButton raTransferDelay;
		private System.Windows.Forms.RadioButton raTransferDay;
		private System.Windows.Forms.NumericUpDown nudTransferDelay;
		private System.Windows.Forms.ComboBox cboTransferDelayType;
		private System.Windows.Forms.DateTimePicker dtTransferDateTime;
		private System.Windows.Forms.RadioButton raRunByDay;
		private System.Windows.Forms.RadioButton raMoveAll;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DeleteEditDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			cboDay.SelectedIndex=0;
			cboDelayType.SelectedIndex =0;
			cboTransferDelayType.SelectedIndex =0;

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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.raTransferDelay = new System.Windows.Forms.RadioButton();
			this.raTransferDay = new System.Windows.Forms.RadioButton();
			this.nudTransferDelay = new System.Windows.Forms.NumericUpDown();
			this.cboTransferDelayType = new System.Windows.Forms.ComboBox();
			this.dtTransferDateTime = new System.Windows.Forms.DateTimePicker();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dtByDayAt = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.cboDay = new System.Windows.Forms.ComboBox();
			this.raRunByDay = new System.Windows.Forms.RadioButton();
			this.cboDelayType = new System.Windows.Forms.ComboBox();
			this.nudDelay = new System.Windows.Forms.NumericUpDown();
			this.raRunByDelay = new System.Windows.Forms.RadioButton();
			this.panel2 = new System.Windows.Forms.Panel();
			this.raMoveAll = new System.Windows.Forms.RadioButton();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btnDestination = new System.Windows.Forms.Button();
			this.hpToDDAStagingArea = new System.Windows.Forms.LinkLabel();
			this.hpFromDDAStagingArea = new System.Windows.Forms.LinkLabel();
			this.hpDDAArchive = new System.Windows.Forms.LinkLabel();
			this.label4 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.nudTransferDelay)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudDelay)).BeginInit();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(112, 72);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(400, 8);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Schedule running";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 192);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Option:";
			// 
			// groupBox2
			// 
			this.groupBox2.Location = new System.Drawing.Point(72, 192);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(440, 8);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			// 
			// raTransferDelay
			// 
			this.raTransferDelay.Checked = true;
			this.raTransferDelay.Location = new System.Drawing.Point(8, 8);
			this.raTransferDelay.Name = "raTransferDelay";
			this.raTransferDelay.Size = new System.Drawing.Size(152, 24);
			this.raTransferDelay.TabIndex = 0;
			this.raTransferDelay.TabStop = true;
			this.raTransferDelay.Text = "Keep data within";
			this.raTransferDelay.CheckedChanged += new System.EventHandler(this.raTransferDelay_CheckedChanged);
			// 
			// raTransferDay
			// 
			this.raTransferDay.Location = new System.Drawing.Point(8, 34);
			this.raTransferDay.Name = "raTransferDay";
			this.raTransferDay.Size = new System.Drawing.Size(208, 24);
			this.raTransferDay.TabIndex = 3;
			this.raTransferDay.Text = "Keep data after: ";
			this.raTransferDay.CheckedChanged += new System.EventHandler(this.raTransferDay_CheckedChanged);
			// 
			// nudTransferDelay
			// 
			this.nudTransferDelay.Location = new System.Drawing.Point(232, 10);
			this.nudTransferDelay.Name = "nudTransferDelay";
			this.nudTransferDelay.Size = new System.Drawing.Size(48, 20);
			this.nudTransferDelay.TabIndex = 1;
			this.nudTransferDelay.Value = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   0});
			// 
			// cboTransferDelayType
			// 
			this.cboTransferDelayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTransferDelayType.Items.AddRange(new object[] {
																	  "Minute(s)",
																	  "Hour(s)",
																	  "Day(s)",
																	  "Week(s)",
																	  "Month(s)"});
			this.cboTransferDelayType.Location = new System.Drawing.Point(288, 10);
			this.cboTransferDelayType.Name = "cboTransferDelayType";
			this.cboTransferDelayType.Size = new System.Drawing.Size(72, 21);
			this.cboTransferDelayType.TabIndex = 2;
			// 
			// dtTransferDateTime
			// 
			this.dtTransferDateTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			this.dtTransferDateTime.Enabled = false;
			this.dtTransferDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtTransferDateTime.Location = new System.Drawing.Point(232, 34);
			this.dtTransferDateTime.Name = "dtTransferDateTime";
			this.dtTransferDateTime.Size = new System.Drawing.Size(128, 20);
			this.dtTransferDateTime.TabIndex = 4;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dtByDayAt);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.cboDay);
			this.panel1.Controls.Add(this.raRunByDay);
			this.panel1.Controls.Add(this.cboDelayType);
			this.panel1.Controls.Add(this.nudDelay);
			this.panel1.Controls.Add(this.raRunByDelay);
			this.panel1.Location = new System.Drawing.Point(16, 96);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(496, 80);
			this.panel1.TabIndex = 2;
			// 
			// dtByDayAt
			// 
			this.dtByDayAt.Enabled = false;
			this.dtByDayAt.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dtByDayAt.Location = new System.Drawing.Point(392, 34);
			this.dtByDayAt.Name = "dtByDayAt";
			this.dtByDayAt.ShowUpDown = true;
			this.dtByDayAt.Size = new System.Drawing.Size(96, 20);
			this.dtByDayAt.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Enabled = false;
			this.label3.Location = new System.Drawing.Point(368, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(18, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "At ";
			// 
			// cboDay
			// 
			this.cboDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDay.Enabled = false;
			this.cboDay.Items.AddRange(new object[] {
														"Every day",
														"Every Monday",
														"Every Tuesday",
														"Every Wednesday",
														"Every Thursday",
														"Every Friday",
														"Every Satuday",
														"Every Sunday",
														""});
			this.cboDay.Location = new System.Drawing.Point(232, 32);
			this.cboDay.Name = "cboDay";
			this.cboDay.Size = new System.Drawing.Size(128, 21);
			this.cboDay.TabIndex = 4;
			// 
			// raRunByDay
			// 
			this.raRunByDay.Location = new System.Drawing.Point(16, 32);
			this.raRunByDay.Name = "raRunByDay";
			this.raRunByDay.Size = new System.Drawing.Size(168, 24);
			this.raRunByDay.TabIndex = 3;
			this.raRunByDay.Text = "Run at specific time interval:";
			this.raRunByDay.CheckedChanged += new System.EventHandler(this.raRunByDay_CheckedChanged);
			// 
			// cboDelayType
			// 
			this.cboDelayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDelayType.Items.AddRange(new object[] {
															  "Minute(s)",
															  "Hour(s)"});
			this.cboDelayType.Location = new System.Drawing.Point(288, 8);
			this.cboDelayType.Name = "cboDelayType";
			this.cboDelayType.Size = new System.Drawing.Size(72, 21);
			this.cboDelayType.TabIndex = 2;
			// 
			// nudDelay
			// 
			this.nudDelay.Location = new System.Drawing.Point(232, 8);
			this.nudDelay.Name = "nudDelay";
			this.nudDelay.Size = new System.Drawing.Size(48, 20);
			this.nudDelay.TabIndex = 1;
			this.nudDelay.Value = new System.Decimal(new int[] {
																   1,
																   0,
																   0,
																   0});
			// 
			// raRunByDelay
			// 
			this.raRunByDelay.Checked = true;
			this.raRunByDelay.Location = new System.Drawing.Point(16, 8);
			this.raRunByDelay.Name = "raRunByDelay";
			this.raRunByDelay.TabIndex = 0;
			this.raRunByDelay.TabStop = true;
			this.raRunByDelay.Text = "Run every:";
			this.raRunByDelay.CheckedChanged += new System.EventHandler(this.raRunByDelay_CheckedChanged);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.raMoveAll);
			this.panel2.Controls.Add(this.dtTransferDateTime);
			this.panel2.Controls.Add(this.raTransferDelay);
			this.panel2.Controls.Add(this.raTransferDay);
			this.panel2.Controls.Add(this.cboTransferDelayType);
			this.panel2.Controls.Add(this.nudTransferDelay);
			this.panel2.Location = new System.Drawing.Point(16, 208);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(496, 96);
			this.panel2.TabIndex = 4;
			// 
			// raMoveAll
			// 
			this.raMoveAll.Location = new System.Drawing.Point(8, 62);
			this.raMoveAll.Name = "raMoveAll";
			this.raMoveAll.Size = new System.Drawing.Size(192, 24);
			this.raMoveAll.TabIndex = 5;
			this.raMoveAll.Text = "Delete all data";
			this.raMoveAll.CheckedChanged += new System.EventHandler(this.raMoveAll_CheckedChanged);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnCancel);
			this.panel3.Controls.Add(this.btnOK);
			this.panel3.Controls.Add(this.groupBox3);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(0, 368);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(514, 48);
			this.panel3.TabIndex = 7;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(260, 16);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(180, 16);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Location = new System.Drawing.Point(-16, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(888, 8);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.btnDestination);
			this.groupBox4.Location = new System.Drawing.Point(0, 8);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(512, 56);
			this.groupBox4.TabIndex = 1;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Transfer type";
			// 
			// btnDestination
			// 
			this.btnDestination.Location = new System.Drawing.Point(248, 16);
			this.btnDestination.Name = "btnDestination";
			this.btnDestination.Size = new System.Drawing.Size(136, 23);
			this.btnDestination.TabIndex = 2;
			this.btnDestination.Text = "Destination Connection";
			this.btnDestination.Click += new System.EventHandler(this.btnDestination_Click);
			// 
			// hpToDDAStagingArea
			// 
			this.hpToDDAStagingArea.Location = new System.Drawing.Point(296, 40);
			this.hpToDDAStagingArea.Name = "hpToDDAStagingArea";
			this.hpToDDAStagingArea.TabIndex = 6;
			this.hpToDDAStagingArea.TabStop = true;
			this.hpToDDAStagingArea.Text = "DDAStagingArea";
			// 
			// hpFromDDAStagingArea
			// 
			this.hpFromDDAStagingArea.AutoSize = true;
			this.hpFromDDAStagingArea.Location = new System.Drawing.Point(192, 48);
			this.hpFromDDAStagingArea.Name = "hpFromDDAStagingArea";
			this.hpFromDDAStagingArea.Size = new System.Drawing.Size(91, 16);
			this.hpFromDDAStagingArea.TabIndex = 10;
			this.hpFromDDAStagingArea.TabStop = true;
			this.hpFromDDAStagingArea.Text = "DDAStagingArea";
			// 
			// hpDDAArchive
			// 
			this.hpDDAArchive.AutoSize = true;
			this.hpDDAArchive.Location = new System.Drawing.Point(240, 48);
			this.hpDDAArchive.Name = "hpDDAArchive";
			this.hpDDAArchive.Size = new System.Drawing.Size(72, 16);
			this.hpDDAArchive.TabIndex = 11;
			this.hpDDAArchive.TabStop = true;
			this.hpDDAArchive.Text = "DDAArchives";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 320);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(177, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "Number Records for one batch job";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(248, 320);
			this.numericUpDown1.Maximum = new System.Decimal(new int[] {
																		   1000000000,
																		   0,
																		   0,
																		   0});
			this.numericUpDown1.Minimum = new System.Decimal(new int[] {
																		   10,
																		   0,
																		   0,
																		   0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(128, 20);
			this.numericUpDown1.TabIndex = 9;
			this.numericUpDown1.Value = new System.Decimal(new int[] {
																		 1000,
																		 0,
																		 0,
																		 0});
			// 
			// DeleteEditDlg
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(514, 416);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DeleteEditDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Transfer Task";
			this.Load += new System.EventHandler(this.TransferEditDlg_Load);
			((System.ComponentModel.ISupportInitialize)(this.nudTransferDelay)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudDelay)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void TransferEditDlg_Load(object sender, System.EventArgs e)
		{
		}

		DDADBManager.Process.DeleteProcess _DataSource;

		private void raRunByDelay_CheckedChanged(object sender, System.EventArgs e)
		{
			nudDelay.Enabled = cboDelayType.Enabled = raRunByDelay.Checked;
			cboDay.Enabled = dtByDayAt.Enabled = raRunByDay.Checked;
		}

		private void raRunByDay_CheckedChanged(object sender, System.EventArgs e)
		{
			nudDelay.Enabled = cboDelayType.Enabled = raRunByDelay.Checked;
			cboDay.Enabled = dtByDayAt.Enabled = raRunByDay.Checked;
		}

		private void raTransferDelay_CheckedChanged(object sender, System.EventArgs e)
		{
			nudTransferDelay.Enabled = cboTransferDelayType.Enabled = raTransferDelay.Checked;
			dtTransferDateTime.Enabled = raTransferDay.Checked;
		}

		private void raTransferDay_CheckedChanged(object sender, System.EventArgs e)
		{
			nudTransferDelay.Enabled = cboTransferDelayType.Enabled = raTransferDelay.Checked;
			dtTransferDateTime.Enabled = raTransferDay.Checked;
		}

		private void btnDestination_Click(object sender, System.EventArgs e)
		{
			ConnectionSettingDlg dlg = new ConnectionSettingDlg();
			dlg.Text = "Destination Connection";
			dlg.DataSource = this.DataSource.destination;
			if( dlg.ShowDialog(this) == DialogResult.OK)
			{
				this.DataSource.destination = dlg.DataSource;
			}
		}


		private void btnOK_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			//check validation
			if( !this.DataSource.destination.TestConnection())
			{
				MessageBox.Show(this, "Connection to destination database: fails", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			DialogResult = DialogResult.OK;
			Close();
		}

		private void raMoveAll_CheckedChanged(object sender, System.EventArgs e)
		{
			nudTransferDelay.Enabled = cboTransferDelayType.Enabled = raTransferDelay.Checked;
			dtTransferDateTime.Enabled = raTransferDay.Checked;
		}
	
		public DDADBManager.Process.DeleteProcess DataSource
		{
			get
			{
				if( _DataSource==null)
					_DataSource = new DDADBManager.Process.DeleteProcess();

				_DataSource.schedular.RunByDay = raRunByDay.Checked;

				_DataSource.schedular.delay = Convert.ToInt32(nudDelay.Value);
				
				_DataSource.schedular.delayMode =  (DDADBManager.Modal.RunningModeByDelay)cboDelayType.SelectedIndex;
				_DataSource.schedular.dayMode = (DDADBManager.Modal.RunningModeByDay)cboDay.SelectedIndex;

				_DataSource.schedular.atTime = dtByDayAt.Value;

				_DataSource.transfertime.transferBeforeTime = raTransferDay.Checked;

				_DataSource.transfertime.delay = Convert.ToInt32(nudTransferDelay.Value);
				_DataSource.transfertime.delaymode = (DDADBManager.Modal.TransferDelayMode)cboTransferDelayType.SelectedIndex;

				_DataSource.transfertime.datetime = dtTransferDateTime.Value;

				_DataSource.transfertime.moveAllDAta = raMoveAll.Checked;

				_DataSource.NumberOfBatchRecord = Convert.ToInt32(numericUpDown1.Value);

				return _DataSource;
			}
			set
			{
				if(value!=null)
				{
					_DataSource = value;

					raRunByDelay.Checked = !_DataSource.schedular.RunByDay;
					raRunByDay.Checked = _DataSource.schedular.RunByDay;

					nudDelay.Value = _DataSource.schedular.delay;
					cboDelayType.SelectedIndex = (int)_DataSource.schedular.delayMode;
					cboDay.SelectedIndex = (int)_DataSource.schedular.dayMode;
					dtByDayAt.Value = _DataSource.schedular.atTime;

					raTransferDelay.Checked = !_DataSource.transfertime.transferBeforeTime;
					raTransferDay.Checked = _DataSource.transfertime.transferBeforeTime;

					nudTransferDelay.Value = _DataSource.transfertime.delay;
					cboTransferDelayType.SelectedIndex = (int)_DataSource.transfertime.delaymode;

					dtTransferDateTime.Value = _DataSource.transfertime.datetime;

					raMoveAll.Checked = _DataSource.transfertime.moveAllDAta;

					numericUpDown1.Value = _DataSource.NumberOfBatchRecord;
				}
			}
		}

	}
}
