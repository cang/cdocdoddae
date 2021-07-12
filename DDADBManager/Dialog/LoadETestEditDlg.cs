using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DDADBManager.Dialog
{
	/// <summary>
	/// Summary description for LoadETestEditDlg.
	/// </summary>
	public class LoadETestEditDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.GroupBox groupBox1;
		private DDADBManager.View.DataSourceCtrl dataSourceCtrl1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtProcessName;
		private System.Windows.Forms.GroupBox groupBox3;
		private DDADBManager.View.PostProcessFileCtrl postProcessFileCtrl1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnSetting;
		private DDADBManager.View.FabEditCtrl fabEditCtrl1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public LoadETestEditDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.fabEditCtrl1.LoadFabList();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(LoadETestEditDlg));
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dataSourceCtrl1 = new DDADBManager.View.DataSourceCtrl();
			this.label1 = new System.Windows.Forms.Label();
			this.txtProcessName = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.postProcessFileCtrl1 = new DDADBManager.View.PostProcessFileCtrl();
			this.label2 = new System.Windows.Forms.Label();
			this.btnSetting = new System.Windows.Forms.Button();
			this.fabEditCtrl1 = new DDADBManager.View.FabEditCtrl();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(332, 368);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOK.Location = new System.Drawing.Point(252, 368);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 7;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox1.Location = new System.Drawing.Point(-144, 352);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1104, 8);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			// 
			// dataSourceCtrl1
			// 
			this.dataSourceCtrl1.Location = new System.Drawing.Point(3, 112);
			this.dataSourceCtrl1.Name = "dataSourceCtrl1";
			this.dataSourceCtrl1.Size = new System.Drawing.Size(648, 104);
			this.dataSourceCtrl1.TabIndex = 4;
			this.dataSourceCtrl1.OnSize += new System.EventHandler(this.dataSourceCtrl1_OnSize);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(0, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Task Name";
			// 
			// txtProcessName
			// 
			this.txtProcessName.Location = new System.Drawing.Point(100, 4);
			this.txtProcessName.Name = "txtProcessName";
			this.txtProcessName.Size = new System.Drawing.Size(180, 20);
			this.txtProcessName.TabIndex = 0;
			this.txtProcessName.Text = "Load File";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox3.Controls.Add(this.postProcessFileCtrl1);
			this.groupBox3.Location = new System.Drawing.Point(3, 264);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(647, 84);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Post Process";
			// 
			// postProcessFileCtrl1
			// 
			this.postProcessFileCtrl1.Location = new System.Drawing.Point(8, 16);
			this.postProcessFileCtrl1.Name = "postProcessFileCtrl1";
			this.postProcessFileCtrl1.Size = new System.Drawing.Size(632, 64);
			this.postProcessFileCtrl1.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 235);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 10;
			this.label2.Text = "Pre Process :";
			// 
			// btnSetting
			// 
			this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSetting.Location = new System.Drawing.Point(100, 232);
			this.btnSetting.Name = "btnSetting";
			this.btnSetting.TabIndex = 11;
			this.btnSetting.Text = "Setting...";
			this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
			// 
			// fabEditCtrl1
			// 
			this.fabEditCtrl1.Location = new System.Drawing.Point(3, 32);
			this.fabEditCtrl1.Name = "fabEditCtrl1";
			this.fabEditCtrl1.Size = new System.Drawing.Size(648, 72);
			this.fabEditCtrl1.TabIndex = 12;
			// 
			// LoadETestEditDlg
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(652, 400);
			this.Controls.Add(this.fabEditCtrl1);
			this.Controls.Add(this.btnSetting);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtProcessName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.dataSourceCtrl1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LoadETestEditDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Load File Task";
			this.Load += new System.EventHandler(this.LoadETestEditDlg_Load);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if(this.fabEditCtrl1.ValidateString!=string.Empty)
			{
				MessageBox.Show(this.fabEditCtrl1.ValidateString,this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			if(this.dataSourceCtrl1.ValidateString!=string.Empty)
			{
				MessageBox.Show(this.dataSourceCtrl1.ValidateString,this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			if(this.DataSource.PreProcess==null)
			{
				MessageBox.Show("Please setup PreProcess",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			if(this.DataSource.PreProcess.ValidateString!=string.Empty)
			{
				MessageBox.Show(this.DataSource.PreProcess.ValidateString + ", please setup PreProcess",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			if(this.postProcessFileCtrl1.ValidateString!=string.Empty)
			{
				MessageBox.Show(this.postProcessFileCtrl1.ValidateString,this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}

			//Save Fab in database
			DialogResult = DialogResult.OK;
			Close();
		}

		Process.LoadETestProcess	_DataSource;// = new DDADBManager.Process.LoadETestProcess();

		private void LoadETestEditDlg_Load(object sender, System.EventArgs e)
		{
			//fabEditCtrl1.LoadFabList();
		}

		private void dataSourceCtrl1_OnSize(object sender, System.EventArgs e)
		{
			if(dataSourceCtrl1.Height<=104)
				this.Height -= (180 - 104);
			else
				this.Height += (180 - 104);
		}

		private void btnSetting_Click(object sender, System.EventArgs e)
		{
			PreProcessDlg dlg = new PreProcessDlg(DataSource);
			dlg.ShowDialog(this);
		}
		
		public Process.LoadETestProcess	DataSource
		{
			get
			{
				if( _DataSource==null)
				{
					_DataSource = new DDADBManager.Process.LoadETestProcess();
				}
				
				_DataSource.Fab = this.fabEditCtrl1.DataSource;

				//_DataSource.PreProcess = this.preProcessFileCtrl1.DataSource;
				_DataSource.PostProcess = this.postProcessFileCtrl1.DataSource;
				_DataSource.DataSource = this.dataSourceCtrl1.DataSource;
				_DataSource.Name = txtProcessName.Text;
				//_DataSource.MaxLayerOfLot = Convert.ToInt32(nudMaxLayer.Value);
				//_DataSource.NextLayerOnLotTimeOuts = Convert.ToInt32(nudTimeout.Value);

				return _DataSource;
			}
			set
			{
				if(value!=null)
				{
					_DataSource = value;

					//this.fabEditCtrl1.LoadFabList();
					this.fabEditCtrl1.DataSource =_DataSource.Fab;

					//this.preProcessFileCtrl1.DataSource = _DataSource.PreProcess;
					this.postProcessFileCtrl1.DataSource = _DataSource.PostProcess;
					this.dataSourceCtrl1.DataSource =_DataSource.DataSource;
					txtProcessName.Text =_DataSource.Name;
					//this.nudMaxLayer.Value = _DataSource.MaxLayerOfLot;
					//this.nudTimeout.Value = _DataSource.NextLayerOnLotTimeOuts;
				}
			}
		}

	}
}
