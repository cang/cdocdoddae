using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DDARecipe.Dialogs
{
	/// <summary>
	/// Summary description for DlgMoreCondition.
	/// </summary>
	public class DlgMoreCondition : SiGlaz.Recipes.Dialogs.DlgBase
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtGrade;
		private System.Windows.Forms.Button btnHint;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton raAll;
		private System.Windows.Forms.RadioButton raDateTime;
		public System.Windows.Forms.DateTimePicker dtpkFrom;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton raDefault;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DlgMoreCondition()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtGrade = new System.Windows.Forms.TextBox();
			this.btnHint = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.raAll = new System.Windows.Forms.RadioButton();
			this.raDateTime = new System.Windows.Forms.RadioButton();
			this.dtpkFrom = new System.Windows.Forms.DateTimePicker();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.raDefault = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(142, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "This condition will process :";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(168, 6);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(40, 20);
			this.numericUpDown1.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(216, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "(%) surfaces";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(74, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Tester Grade:";
			// 
			// txtGrade
			// 
			this.txtGrade.Location = new System.Drawing.Point(88, 40);
			this.txtGrade.Name = "txtGrade";
			this.txtGrade.Size = new System.Drawing.Size(376, 20);
			this.txtGrade.TabIndex = 3;
			this.txtGrade.Text = "";
			// 
			// btnHint
			// 
			this.btnHint.Location = new System.Drawing.Point(464, 39);
			this.btnHint.Name = "btnHint";
			this.btnHint.Size = new System.Drawing.Size(40, 23);
			this.btnHint.TabIndex = 4;
			this.btnHint.Text = "Hint";
			this.btnHint.Click += new System.EventHandler(this.btnHint_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.raDefault);
			this.groupBox1.Controls.Add(this.raAll);
			this.groupBox1.Controls.Add(this.raDateTime);
			this.groupBox1.Controls.Add(this.dtpkFrom);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(8, 72);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(496, 104);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Date limit";
			// 
			// raAll
			// 
			this.raAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raAll.Location = new System.Drawing.Point(16, 40);
			this.raAll.Name = "raAll";
			this.raAll.Size = new System.Drawing.Size(68, 24);
			this.raAll.TabIndex = 0;
			this.raAll.Text = "All";
			this.raAll.CheckedChanged += new System.EventHandler(this.raAll_CheckedChanged);
			// 
			// raDateTime
			// 
			this.raDateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raDateTime.Location = new System.Drawing.Point(16, 64);
			this.raDateTime.Name = "raDateTime";
			this.raDateTime.Size = new System.Drawing.Size(112, 20);
			this.raDateTime.TabIndex = 3;
			this.raDateTime.Text = "From Date/Time:";
			this.raDateTime.CheckedChanged += new System.EventHandler(this.raDateTime_CheckedChanged);
			// 
			// dtpkFrom
			// 
			this.dtpkFrom.CustomFormat = "MM/dd/yyyy HH:mm:ss";
			this.dtpkFrom.Enabled = false;
			this.dtpkFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpkFrom.Location = new System.Drawing.Point(128, 64);
			this.dtpkFrom.Name = "dtpkFrom";
			this.dtpkFrom.Size = new System.Drawing.Size(136, 20);
			this.dtpkFrom.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnOK);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 184);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(514, 48);
			this.panel1.TabIndex = 6;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(256, 16);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(176, 16);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Location = new System.Drawing.Point(-16, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(888, 8);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			// 
			// raDefault
			// 
			this.raDefault.Checked = true;
			this.raDefault.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raDefault.Location = new System.Drawing.Point(16, 16);
			this.raDefault.Name = "raDefault";
			this.raDefault.Size = new System.Drawing.Size(264, 24);
			this.raDefault.TabIndex = 4;
			this.raDefault.TabStop = true;
			this.raDefault.Text = "After the recipe creation time";
			// 
			// DlgMoreCondition
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(514, 232);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnHint);
			this.Controls.Add(this.txtGrade);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numericUpDown1);
			this.Name = "DlgMoreCondition";
			this.Text = "More Condition";
			this.Load += new System.EventHandler(this.DlgMoreCondition_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			DialogResult  = DialogResult.OK;
			Close();
		}

		private void btnHint_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			
			DlgConditionHint dlg = new DlgConditionHint(null,DateTime.MinValue,DateTime.MaxValue,SiGlaz.Common.DDA.Const.WaferConst.TesterGrade, SiGlaz.Common.DDA.FunctionType.DataSource, true, false);

			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				this.Refresh();
				Cursor.Current = Cursors.WaitCursor;

				if (txtGrade.Text.Trim() != string.Empty)
					txtGrade.AppendText(string.Format("; {0}", dlg.Condition));
				else
					txtGrade.Text = dlg.Condition;
			}
		}

		private void raAll_CheckedChanged(object sender, System.EventArgs e)
		{
			dtpkFrom.Enabled = raDateTime.Checked;
		}

		private void raDateTime_CheckedChanged(object sender, System.EventArgs e)
		{
			dtpkFrom.Enabled = raDateTime.Checked;
		}

		private void DlgMoreCondition_Load(object sender, System.EventArgs e)
		{
		
		}

		public SiGlaz.Common.DDA.Basic.GradeCondition Data
		{
			get
			{
				if(numericUpDown1.Value<=0)
					return null;

				if( raAll.Checked && txtGrade.Text.Trim()==string.Empty)
					return null;

				SiGlaz.Common.DDA.Basic.GradeCondition result = new SiGlaz.Common.DDA.Basic.GradeCondition();
				result.ProcessPercent = (int)numericUpDown1.Value;

				if(txtGrade.Text.Trim()!=string.Empty)
				{
					string temp = txtGrade.Text.Trim();
					temp = temp.Replace(',',';');
					result.ListGradeString = SiGlaz.Utility.Utility.GetBasicQueryCondition("TestGrade",temp);
				}

				if( raDefault.Checked )
				{
					result.fromDateTime.Type = SiGlaz.Common.DDA.TimeRangeType.LastNHours;
					result.fromDateTime.N = -1;
				}
				else if(raDateTime.Checked)
				{
					result.fromDateTime = new SiGlaz.Common.DDA.Basic.TimeFilter();
					result.fromDateTime.Type = SiGlaz.Common.DDA.TimeRangeType.FromDateToDate;
					result.fromDateTime.From = dtpkFrom.Value;
				}
				else
					result.fromDateTime = null;

				return result;
			}
			set
			{
				if(value==null) return;

				numericUpDown1.Value = value.ProcessPercent;

				if(value.ListGradeString!=null && value.ListGradeString!=string.Empty)
				{
					ArrayList alGrade = new ArrayList();
					alGrade.Add(value.ListGradeString);
					txtGrade.Text = SiGlaz.Utility.Utility.GetValueByFieldName("TestGrade",alGrade);
				}

				if(value.fromDateTime!=null)
				{
					if( value.fromDateTime.Type == SiGlaz.Common.DDA.TimeRangeType.LastNHours)
					{
						if( value.fromDateTime.N ==-1)
						{
							raDefault.Checked = true;
						}
					}
					else if(value.fromDateTime.Type == SiGlaz.Common.DDA.TimeRangeType.FromDateToDate)
					{
						raDateTime.Checked = true;
						dtpkFrom.Value = value.fromDateTime.From;
					}
				}
				else
					raAll.Checked = true;
			}
					
		}
	}
}
