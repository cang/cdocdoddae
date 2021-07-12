using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using DDARecipe.Controls;

namespace DDARecipe.Dialogs
{
	/// <summary>
	/// Summary description for DlgOptions.
	/// </summary>
	public class DlgOptions : SiGlaz.Recipes.Dialogs.DlgBase
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabRecipe;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.ComboBox cboFab;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown nudWatingTime;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TabPage tabDDADBManager;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown nudRetryErrorTime;
		private System.Windows.Forms.NumericUpDown nudListenfolderTime;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.NumericUpDown nudGetMoreTime;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.CheckBox chkShowProcessNode;
		private ctrlTimeFilter ctrlTimeFilter1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DlgOptions()
		{
			InitializeComponent();
		}

		bool recipe=true;
		bool loader=true;

		public DlgOptions(bool recipe,bool loader):this()
		{
			this.recipe = recipe;
			this.loader = loader;
			ReLoadLayoyt();
		}

		public void ReLoadLayoyt()
		{
			if(!recipe)
				tabControl1.TabPages.Remove(tabRecipe);
			if(!loader)
				tabControl1.TabPages.Remove(tabDDADBManager);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgOptions));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabRecipe = new System.Windows.Forms.TabPage();
			this.ctrlTimeFilter1 = new ctrlTimeFilter();
			this.chkShowProcessNode = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.nudWatingTime = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.cboFab = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabDDADBManager = new System.Windows.Forms.TabPage();
			this.label9 = new System.Windows.Forms.Label();
			this.nudGetMoreTime = new System.Windows.Forms.NumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.nudRetryErrorTime = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.nudListenfolderTime = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabRecipe.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudWatingTime)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.tabDDADBManager.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudGetMoreTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudRetryErrorTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudListenfolderTime)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnOK);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 408);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(530, 48);
			this.panel1.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(268, 16);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(188, 16);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(-16, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(888, 8);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.tabControl1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(530, 408);
			this.panel2.TabIndex = 1;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabRecipe);
			this.tabControl1.Controls.Add(this.tabDDADBManager);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(530, 408);
			this.tabControl1.TabIndex = 0;
			// 
			// tabRecipe
			// 
			this.tabRecipe.Controls.Add(this.ctrlTimeFilter1);
			this.tabRecipe.Controls.Add(this.chkShowProcessNode);
			this.tabRecipe.Controls.Add(this.label4);
			this.tabRecipe.Controls.Add(this.nudWatingTime);
			this.tabRecipe.Controls.Add(this.label3);
			this.tabRecipe.Controls.Add(this.groupBox2);
			this.tabRecipe.Controls.Add(this.btnRefresh);
			this.tabRecipe.Controls.Add(this.cboFab);
			this.tabRecipe.Controls.Add(this.label1);
			this.tabRecipe.Location = new System.Drawing.Point(4, 22);
			this.tabRecipe.Name = "tabRecipe";
			this.tabRecipe.Size = new System.Drawing.Size(522, 382);
			this.tabRecipe.TabIndex = 0;
			this.tabRecipe.Text = "Recipe Settings";
			// 
			// ctrlTimeFilter1
			// 
			this.ctrlTimeFilter1.Data = null;
			this.ctrlTimeFilter1.Location = new System.Drawing.Point(8, 104);
			this.ctrlTimeFilter1.Name = "ctrlTimeFilter1";
			this.ctrlTimeFilter1.Size = new System.Drawing.Size(501, 176);
			this.ctrlTimeFilter1.TabIndex = 36;
			// 
			// chkShowProcessNode
			// 
			this.chkShowProcessNode.Location = new System.Drawing.Point(8, 80);
			this.chkShowProcessNode.Name = "chkShowProcessNode";
			this.chkShowProcessNode.Size = new System.Drawing.Size(384, 24);
			this.chkShowProcessNode.TabIndex = 5;
			this.chkShowProcessNode.Text = "Debug Mode - Show Process Detail of Node";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(320, 50);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 16);
			this.label4.TabIndex = 4;
			this.label4.Text = "second(s)";
			// 
			// nudWatingTime
			// 
			this.nudWatingTime.Location = new System.Drawing.Point(224, 48);
			this.nudWatingTime.Maximum = new System.Decimal(new int[] {
																		  100000,
																		  0,
																		  0,
																		  0});
			this.nudWatingTime.Minimum = new System.Decimal(new int[] {
																		  1,
																		  0,
																		  0,
																		  0});
			this.nudWatingTime.Name = "nudWatingTime";
			this.nudWatingTime.Size = new System.Drawing.Size(88, 20);
			this.nudWatingTime.TabIndex = 3;
			this.nudWatingTime.Value = new System.Decimal(new int[] {
																		60,
																		0,
																		0,
																		0});
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 50);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(191, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Waiting time to listen to new surface :";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(8, 288);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(501, 83);
			this.groupBox2.TabIndex = 35;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Reset Recipe Status";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(429, 56);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(68, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Reset";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(472, 32);
			this.label2.TabIndex = 0;
			this.label2.Text = "In case, there is any unhandled exception which affects recipe status, all recipe" +
				"s must be reset.";
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point(440, 12);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(68, 24);
			this.btnRefresh.TabIndex = 1;
			this.btnRefresh.Text = "&Refresh";
			// 
			// cboFab
			// 
			this.cboFab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFab.Location = new System.Drawing.Point(224, 14);
			this.cboFab.Name = "cboFab";
			this.cboFab.Size = new System.Drawing.Size(212, 21);
			this.cboFab.TabIndex = 32;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Select Plant to run";
			// 
			// tabDDADBManager
			// 
			this.tabDDADBManager.Controls.Add(this.label9);
			this.tabDDADBManager.Controls.Add(this.nudGetMoreTime);
			this.tabDDADBManager.Controls.Add(this.label10);
			this.tabDDADBManager.Controls.Add(this.label7);
			this.tabDDADBManager.Controls.Add(this.nudRetryErrorTime);
			this.tabDDADBManager.Controls.Add(this.label8);
			this.tabDDADBManager.Controls.Add(this.label5);
			this.tabDDADBManager.Controls.Add(this.nudListenfolderTime);
			this.tabDDADBManager.Controls.Add(this.label6);
			this.tabDDADBManager.Location = new System.Drawing.Point(4, 22);
			this.tabDDADBManager.Name = "tabDDADBManager";
			this.tabDDADBManager.Size = new System.Drawing.Size(522, 382);
			this.tabDDADBManager.TabIndex = 1;
			this.tabDDADBManager.Text = "DDADB Loader";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(360, 72);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(54, 16);
			this.label9.TabIndex = 47;
			this.label9.Text = "second(s)";
			// 
			// nudGetMoreTime
			// 
			this.nudGetMoreTime.Location = new System.Drawing.Point(264, 68);
			this.nudGetMoreTime.Maximum = new System.Decimal(new int[] {
																		   100000,
																		   0,
																		   0,
																		   0});
			this.nudGetMoreTime.Minimum = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   0});
			this.nudGetMoreTime.Name = "nudGetMoreTime";
			this.nudGetMoreTime.Size = new System.Drawing.Size(88, 20);
			this.nudGetMoreTime.TabIndex = 46;
			this.nudGetMoreTime.Value = new System.Decimal(new int[] {
																		 60,
																		 0,
																		 0,
																		 0});
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(12, 72);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(189, 16);
			this.label10.TabIndex = 45;
			this.label10.Text = "Waiting time to get more information:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(360, 44);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(54, 16);
			this.label7.TabIndex = 44;
			this.label7.Text = "second(s)";
			// 
			// nudRetryErrorTime
			// 
			this.nudRetryErrorTime.Location = new System.Drawing.Point(264, 40);
			this.nudRetryErrorTime.Maximum = new System.Decimal(new int[] {
																			  100000,
																			  0,
																			  0,
																			  0});
			this.nudRetryErrorTime.Minimum = new System.Decimal(new int[] {
																			  1,
																			  0,
																			  0,
																			  0});
			this.nudRetryErrorTime.Name = "nudRetryErrorTime";
			this.nudRetryErrorTime.Size = new System.Drawing.Size(88, 20);
			this.nudRetryErrorTime.TabIndex = 43;
			this.nudRetryErrorTime.Value = new System.Decimal(new int[] {
																			60,
																			0,
																			0,
																			0});
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(12, 44);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(208, 16);
			this.label8.TabIndex = 42;
			this.label8.Text = "Waiting time to retry after error happend:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(360, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(54, 16);
			this.label5.TabIndex = 41;
			this.label5.Text = "second(s)";
			// 
			// nudListenfolderTime
			// 
			this.nudListenfolderTime.Location = new System.Drawing.Point(264, 12);
			this.nudListenfolderTime.Maximum = new System.Decimal(new int[] {
																				100000,
																				0,
																				0,
																				0});
			this.nudListenfolderTime.Minimum = new System.Decimal(new int[] {
																				1,
																				0,
																				0,
																				0});
			this.nudListenfolderTime.Name = "nudListenfolderTime";
			this.nudListenfolderTime.Size = new System.Drawing.Size(88, 20);
			this.nudListenfolderTime.TabIndex = 40;
			this.nudListenfolderTime.Value = new System.Decimal(new int[] {
																			  5,
																			  0,
																			  0,
																			  0});
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(214, 16);
			this.label6.TabIndex = 39;
			this.label6.Text = "Waiting time to listen new file from Folder:";
			// 
			// DlgOptions
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(530, 456);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DlgOptions";
			this.Text = "Options";
			this.Load += new System.EventHandler(this.DlgOptions_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabRecipe.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudWatingTime)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.tabDDADBManager.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudGetMoreTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudRetryErrorTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudListenfolderTime)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void DlgOptions_Load(object sender, System.EventArgs e)
		{
			//LoadData();
		}


		DataTable dtFab = null;
		public void LoadData()
		{
			if(loader)
			{
				nudListenfolderTime.Value = SiGlaz.Common.DDA.AppData.Data.ListenWaitingSecondFolder;
				nudRetryErrorTime.Value = SiGlaz.Common.DDA.AppData.Data.WaitingToRetryError;
				nudGetMoreTime.Value = SiGlaz.Common.DDA.AppData.Data.WaitingToMoreInformation;
			}

			if(recipe)
			{
				nudWatingTime.Value = SiGlaz.Common.DDA.AppData.Data.ListenWaitingSecond;
				chkShowProcessNode.Checked = SiGlaz.Common.DDA.AppData.Data.ShowProcessStep;

				//Load Fab
				if( SiGlaz.Common.DDA.AppData.Data.UseWebService)
				{
					WebServiceProxy.CategoryProxy.Category proxy = WebServiceProxy.WebProxyFactory.CreateCategory();
					if(proxy!=null)
					{
						WebServiceProxy.CategoryProxy.DataSetResult result = proxy.FabList();
						if(result.Result!=null)
							dtFab = result.Result.Tables[0];
					}
				}
				else
				{
					SiGlaz.DDA.Business.Category proxy = new SiGlaz.DDA.Business.Category();
					SiGlaz.Common.DDA.Result.DataSetResult result = proxy.FabList();
					if(result.Result!=null)
						dtFab = result.Result.Tables[0];
				}

				if(dtFab!=null)
				{
					DataRow  dr = dtFab.NewRow();
					dr["FabKey"] = 0;
					dr["FabID"] = "All";
					dtFab.Rows.InsertAt(dr,0);

					dtFab.AcceptChanges();

					cboFab.ValueMember = "FabKey";
					cboFab.DisplayMember = "FabID";
					cboFab.DataSource = dtFab;


					for(int i=0;i<dtFab.Rows.Count;i++)
					{
						if( (short)dtFab.Rows[i][0] == SiGlaz.Common.DDA.AppData.Data.FabKey)
						{
							cboFab.SelectedIndex = i;
							break;
						}
					}
				}

				if(cboFab.SelectedIndex==0)
					SiGlaz.Common.DDA.AppData.Data.FabKey = 0;

				ctrlTimeFilter1.Data = SiGlaz.Common.DDA.AppData.Data.ProcessSurfaceFromDate;
				ctrlTimeFilter1.MoreData = SiGlaz.Common.DDA.AppData.Data.ProcessSurfaceMore;
			}
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if(recipe)
			{
				if(cboFab.SelectedValue!=null)
					SiGlaz.Common.DDA.AppData.Data.FabKey = (short)cboFab.SelectedValue;
				SiGlaz.Common.DDA.AppData.Data.ListenWaitingSecond = (int)nudWatingTime.Value;
				SiGlaz.Common.DDA.AppData.Data.ShowProcessStep = chkShowProcessNode.Checked;

				SiGlaz.Common.DDA.AppData.Data.ProcessSurfaceFromDate = ctrlTimeFilter1.Data;
				SiGlaz.Common.DDA.AppData.Data.ProcessSurfaceMore = ctrlTimeFilter1.MoreData;
			}
			if(loader)
			{
				SiGlaz.Common.DDA.AppData.Data.ListenWaitingSecondFolder = (int)nudListenfolderTime.Value;
				SiGlaz.Common.DDA.AppData.Data.WaitingToRetryError = (int)nudRetryErrorTime.Value;
				SiGlaz.Common.DDA.AppData.Data.WaitingToMoreInformation = (int)nudGetMoreTime.Value;
			}

			DialogResult = DialogResult.OK;
			Close();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if(MessageBox.Show("Are you sure that you want to reset all recipes' status ?",Application.ProductName,MessageBoxButtons.YesNo,MessageBoxIcon.Question)!= DialogResult.Yes)
				return;

			if(SiGlaz.Common.DDA.AppData.Data.UseWebService)
			{
				WebServiceProxy.RecipeProxy.Recipe proxy = WebServiceProxy.WebProxyFactory.CreateRecipe();
				proxy.ResetRecipeStatus();
			}
			else
			{
				SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
				proxy.ResetRecipeStatus();
			}
		}
	
	}
}
