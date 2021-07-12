using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DDARecipe.Dialogs
{
	/// <summary>
	/// Summary description for TesterNoiseDlg.
	/// </summary>
	public class TesterNoiseDlg : SiGlaz.Recipes.Dialogs.DlgBase
	{
		#region Members
		private System.Windows.Forms.Button button_Cancel;
		private System.Windows.Forms.Button button_OK;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkClassify;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public	ArrayList	alClassNumber=null;
		private System.Windows.Forms.Button btnSetting;
		public System.Windows.Forms.NumericUpDown nudMinDefects;
		public System.Windows.Forms.NumericUpDown nudThreshold;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton radRemove;
		private System.Windows.Forms.RadioButton radKeep;
		public	FPPCommon.ClassLookUpType  type=FPPCommon.ClassLookUpType.ClassNumber;

		#endregion

		#region Constructor & ~Constructor
		public TesterNoiseDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.HelpRequested += new HelpEventHandler(Form_HelpRequested);

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		public void Form_HelpRequested(object sender,HelpEventArgs e)
		{		
			e.Handled = true;
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
		#endregion
		
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button_Cancel = new System.Windows.Forms.Button();
			this.button_OK = new System.Windows.Forms.Button();
			this.nudMinDefects = new System.Windows.Forms.NumericUpDown();
			this.nudThreshold = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.chkClassify = new System.Windows.Forms.CheckBox();
			this.btnSetting = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.radRemove = new System.Windows.Forms.RadioButton();
			this.radKeep = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.nudMinDefects)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudThreshold)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// button_Cancel
			// 
			this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button_Cancel.Location = new System.Drawing.Point(144, 176);
			this.button_Cancel.Name = "button_Cancel";
			this.button_Cancel.TabIndex = 23;
			this.button_Cancel.Text = "Cancel";
			// 
			// button_OK
			// 
			this.button_OK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button_OK.Location = new System.Drawing.Point(64, 176);
			this.button_OK.Name = "button_OK";
			this.button_OK.TabIndex = 22;
			this.button_OK.Text = "OK";
			this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
			// 
			// nudMinDefects
			// 
			this.nudMinDefects.Increment = new System.Decimal(new int[] {
																			5,
																			0,
																			0,
																			65536});
			this.nudMinDefects.Location = new System.Drawing.Point(188, 64);
			this.nudMinDefects.Maximum = new System.Decimal(new int[] {
																		  100000000,
																		  0,
																		  0,
																		  0});
			this.nudMinDefects.Name = "nudMinDefects";
			this.nudMinDefects.Size = new System.Drawing.Size(60, 20);
			this.nudMinDefects.TabIndex = 17;
			this.nudMinDefects.Tag = "DEFAULT";
			this.nudMinDefects.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudMinDefects.Value = new System.Decimal(new int[] {
																		10,
																		0,
																		0,
																		0});
			// 
			// nudThreshold
			// 
			this.nudThreshold.DecimalPlaces = 2;
			this.nudThreshold.Increment = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   65536});
			this.nudThreshold.Location = new System.Drawing.Point(188, 36);
			this.nudThreshold.Maximum = new System.Decimal(new int[] {
																		 1,
																		 0,
																		 0,
																		 0});
			this.nudThreshold.Name = "nudThreshold";
			this.nudThreshold.Size = new System.Drawing.Size(60, 20);
			this.nudThreshold.TabIndex = 16;
			this.nudThreshold.Tag = "DEFAULT";
			this.nudThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudThreshold.Value = new System.Decimal(new int[] {
																	   3,
																	   0,
																	   0,
																	   65536});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label2.Location = new System.Drawing.Point(8, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(169, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "The minimum number of defects:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Location = new System.Drawing.Point(8, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(134, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "The confidence threshold:";
			// 
			// chkClassify
			// 
			this.chkClassify.Location = new System.Drawing.Point(4, 4);
			this.chkClassify.Name = "chkClassify";
			this.chkClassify.Size = new System.Drawing.Size(212, 24);
			this.chkClassify.TabIndex = 35;
			this.chkClassify.Tag = "";
			this.chkClassify.Text = "Filter by ClassNum before processing";
			this.chkClassify.Visible = false;
			this.chkClassify.CheckedChanged += new System.EventHandler(this.chkClassify_CheckedChanged);
			// 
			// btnSetting
			// 
			this.btnSetting.Enabled = false;
			this.btnSetting.Location = new System.Drawing.Point(223, 3);
			this.btnSetting.Name = "btnSetting";
			this.btnSetting.Size = new System.Drawing.Size(61, 23);
			this.btnSetting.TabIndex = 36;
			this.btnSetting.Text = "&Settings...";
			this.btnSetting.Visible = false;
			this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.radRemove);
			this.groupBox3.Controls.Add(this.radKeep);
			this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox3.Location = new System.Drawing.Point(9, 96);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(271, 72);
			this.groupBox3.TabIndex = 37;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Filter Options";
			// 
			// radRemove
			// 
			this.radRemove.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radRemove.Location = new System.Drawing.Point(8, 44);
			this.radRemove.Name = "radRemove";
			this.radRemove.Size = new System.Drawing.Size(220, 23);
			this.radRemove.TabIndex = 2;
			this.radRemove.Text = "Remove";
			// 
			// radKeep
			// 
			this.radKeep.Checked = true;
			this.radKeep.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.radKeep.Location = new System.Drawing.Point(8, 20);
			this.radKeep.Name = "radKeep";
			this.radKeep.Size = new System.Drawing.Size(220, 23);
			this.radKeep.TabIndex = 1;
			this.radKeep.TabStop = true;
			this.radKeep.Text = "Keep";
			// 
			// TesterNoiseDlg
			// 
			this.AcceptButton = this.button_OK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button_Cancel;
			this.ClientSize = new System.Drawing.Size(290, 208);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.btnSetting);
			this.Controls.Add(this.chkClassify);
			this.Controls.Add(this.button_Cancel);
			this.Controls.Add(this.button_OK);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.nudMinDefects);
			this.Controls.Add(this.nudThreshold);
			this.Name = "TesterNoiseDlg";
			this.ShowInTaskbar = false;
			this.Text = "Tester Noise Detection";
			this.Load += new System.EventHandler(this.TesterNoiseDlg_Load);
			((System.ComponentModel.ISupportInitialize)(this.nudMinDefects)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudThreshold)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Windows Events Handles
		private void chkClassify_CheckedChanged(object sender, System.EventArgs e)
		{
			btnSetting.Enabled = chkClassify.Checked;
			//			if( !chkClassify.Checked  ) return;
			//
			//			ClassNumFilter dlg=new ClassNumFilter(data);
			//			dlg.alClassLookup=alClassNumber;
			//			dlg.cboType.SelectedIndex=0;
			//			dlg.cboType.Enabled=false;
			//			dlg.cboType.Enabled=true;
			//			if(dlg.ShowDialog(this)==DialogResult.OK)
			//			{
			//				alClassNumber=dlg.alClassLookup;
			//				type=(FPPCommon.ClassLookUpType)dlg.cboType.SelectedItem;
			//			}
			//			else
			//			{
			//				alClassNumber=null;
			//				chkClassify.Checked=false;
			//			}
		}

		private void button_OK_Click(object sender, System.EventArgs e)
		{
			//			PersistenceDefault obj=new PersistenceDefault(this);
			//			obj.Save();
			//
			//			string filepath = Global.ApplicationDataPath + "\\DefaultData\\" + this.Name + "_more.xml";
			//			if(!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(filepath)) )
			//				System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(filepath));
			//			FPPCommon.SingleClassNumStruct default_more = new FPPCommon.SingleClassNumStruct();
			//			default_more.alClassNumber= alClassNumber;
			//			default_more.Use=chkClassify.Checked;
			//			FPPCommon.XMLSerialization.Serialize(default_more,filepath);

			DialogResult=DialogResult.OK;
			Close();
		}

		#endregion

		private void btnSetting_Click(object sender, System.EventArgs e)
		{
			//			if( !chkClassify.Checked  ) return;
			//			ClassNumFilter dlg=new ClassNumFilter(data);
			//			dlg.alClassLookup=alClassNumber;
			//			dlg.cboType.SelectedIndex=0;
			//			dlg.cboType.Enabled=false;
			//			dlg.cboType.Enabled=true;
			//			if(dlg.ShowDialog(this)==DialogResult.OK)
			//			{
			//				alClassNumber=dlg.alClassLookup;
			//				type=(FPPCommon.ClassLookUpType)dlg.cboType.SelectedItem;
			//			}
		}

		private void TesterNoiseDlg_Load(object sender, System.EventArgs e)
		{
			//			PersistenceDefault obj=new PersistenceDefault(this);
			//			obj.Load();
			//
			//			string filepath = Global.ApplicationDataPath + "\\DefaultData\\" + this.Name + "_more.xml";
			//			FPPCommon.SingleClassNumStruct default_more = FPPCommon.XMLSerialization.Derialize(typeof(FPPCommon.SingleClassNumStruct),filepath) as FPPCommon.SingleClassNumStruct;
			//			if(default_more!=null) 
			//			{
			//				alClassNumber = default_more.alClassNumber;
			//				chkClassify.Checked = default_more.Use;
			//			}
		}

		public FPPCommon.TesterNoiseParam Data
		{
			get
			{
				FPPCommon.TesterNoiseParam param=new FPPCommon.TesterNoiseParam();

				param.ConfidenceThreshold = (double)nudThreshold.Value;
				param.MinNumberOfDefect = (int)this.nudMinDefects.Value;
				param.Include = radKeep.Checked;

				return param;
			}
			set
			{
				if(value==null) return;

				nudThreshold.Value  = Convert.ToDecimal(value.ConfidenceThreshold);
				nudMinDefects.Value = Convert.ToDecimal(value.MinNumberOfDefect);
				radKeep.Checked = value.Include;
				radRemove.Checked = !value.Include;
			}
		}

		public ArrayList ClassMumbers
		{
			get
			{
				if(chkClassify.Checked)
					return alClassNumber;
				else
					return null;
			}
		}
	}
}
