using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Threading;
using DeleteDDADB.Dialogs;

using SiGlaz.DAL;


namespace DeleteDDADB
{
	public class MainForm : System.Windows.Forms.Form
	{
		#region Members
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDatabase;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtServer;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkRemoveResult;
		private System.Windows.Forms.CheckBox chkDeleteSource;
		private System.Windows.Forms.Button btnExecute;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cboFab;
		private System.Windows.Forms.Button btnRefresh;
		private ConnectionParam _Param = null;
		private DlgStatus _dlgStatus = null;
		#endregion
		
		#region Contructor & Destructor
		public MainForm() 
		{
			InitializeComponent();
			EnableVisualStyles(this);
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.label4 = new System.Windows.Forms.Label();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDatabase = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtServer = new System.Windows.Forms.TextBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.chkRemoveResult = new System.Windows.Forms.CheckBox();
			this.chkDeleteSource = new System.Windows.Forms.CheckBox();
			this.btnExecute = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cboFab = new System.Windows.Forms.ComboBox();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(57, 16);
			this.label4.TabIndex = 22;
			this.label4.Text = "Password:";
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(104, 68);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(220, 20);
			this.txtUsername.TabIndex = 21;
			this.txtUsername.Text = "DDADBUser";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 16);
			this.label3.TabIndex = 20;
			this.label3.Text = "User  Name:";
			// 
			// txtDatabase
			// 
			this.txtDatabase.Location = new System.Drawing.Point(104, 44);
			this.txtDatabase.Name = "txtDatabase";
			this.txtDatabase.Size = new System.Drawing.Size(220, 20);
			this.txtDatabase.TabIndex = 19;
			this.txtDatabase.Text = "DDADB";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 16);
			this.label2.TabIndex = 18;
			this.label2.Text = "Database Name:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 16);
			this.label1.TabIndex = 16;
			this.label1.Text = "Server Name:";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(104, 92);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(220, 20);
			this.txtPassword.TabIndex = 23;
			this.txtPassword.Text = "DDADBPassword";
			// 
			// txtServer
			// 
			this.txtServer.Location = new System.Drawing.Point(104, 20);
			this.txtServer.Name = "txtServer";
			this.txtServer.Size = new System.Drawing.Size(220, 20);
			this.txtServer.TabIndex = 17;
			this.txtServer.Text = "SIGLAZ";
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnClose.Location = new System.Drawing.Point(179, 256);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(72, 23);
			this.btnClose.TabIndex = 24;
			this.btnClose.Text = "&Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtUsername);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtDatabase);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtServer);
			this.groupBox1.Controls.Add(this.txtPassword);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(7, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(336, 152);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Database Connection";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(212, 116);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 23);
			this.button1.TabIndex = 29;
			this.button1.Text = "&Test Connection";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// chkRemoveResult
			// 
			this.chkRemoveResult.Checked = true;
			this.chkRemoveResult.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkRemoveResult.Location = new System.Drawing.Point(12, 192);
			this.chkRemoveResult.Name = "chkRemoveResult";
			this.chkRemoveResult.Size = new System.Drawing.Size(128, 24);
			this.chkRemoveResult.TabIndex = 25;
			this.chkRemoveResult.Tag = "DEFAULT";
			this.chkRemoveResult.Text = "Delete All Results";
			// 
			// chkDeleteSource
			// 
			this.chkDeleteSource.Location = new System.Drawing.Point(12, 216);
			this.chkDeleteSource.Name = "chkDeleteSource";
			this.chkDeleteSource.Size = new System.Drawing.Size(148, 24);
			this.chkDeleteSource.TabIndex = 26;
			this.chkDeleteSource.Tag = "DEFAULT";
			this.chkDeleteSource.Text = "Delete All Data Sources";
			// 
			// btnExecute
			// 
			this.btnExecute.Location = new System.Drawing.Point(99, 256);
			this.btnExecute.Name = "btnExecute";
			this.btnExecute.TabIndex = 27;
			this.btnExecute.Text = "&Execute";
			this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Location = new System.Drawing.Point(-16, 240);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(440, 8);
			this.groupBox2.TabIndex = 28;
			this.groupBox2.TabStop = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 168);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(27, 16);
			this.label5.TabIndex = 29;
			this.label5.Text = "Fab:";
			// 
			// cboFab
			// 
			this.cboFab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFab.Location = new System.Drawing.Point(44, 164);
			this.cboFab.Name = "cboFab";
			this.cboFab.Size = new System.Drawing.Size(212, 21);
			this.cboFab.TabIndex = 30;
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point(260, 161);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(68, 24);
			this.btnRefresh.TabIndex = 31;
			this.btnRefresh.Text = "&Refresh";
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// MainForm
			// 
			this.AcceptButton = this.btnClose;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(350, 288);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.cboFab);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.btnExecute);
			this.Controls.Add(this.chkDeleteSource);
			this.Controls.Add(this.chkRemoveResult);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnClose);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Delete DDADB data";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Main
		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			Application.DoEvents();

			Application.Run(new MainForm());
		}
		#endregion
		
		#region Properties
		public ConnectionParam Param
		{
			get
			{
				if(_Param==null)
				{
					_Param = new ConnectionParam();
					try
					{
						_Param.Load(GetConfigurationFileName());
					}
					catch
					{
						_Param.Server = "SIGLAZ";
						_Param.Database = "DDADB";
						_Param.Username = "DDADBUser";
						_Param.Password = "DDADBPassword";
					}
				}
				return _Param;
			}
		}

		#endregion

		#region UI Command
		private string GetConfigurationFileName()
		{
			return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Connection.cfg");
		}

		protected virtual void EnableVisualStyles(Control ctrl)
		{
			if (ctrl == null)
				return;

			Type type = ctrl.GetType();
			if (type.IsSubclassOf(typeof(ButtonBase)))
				((ButtonBase)ctrl).FlatStyle = FlatStyle.System;

			if (ctrl.Controls.Count > 0)
			{
				foreach (Control childControl in ctrl.Controls)
					EnableVisualStyles(childControl);
			}
		}

		public void UpdateData(bool update)
		{
			if(update)
			{
				this.Param.Server = txtServer.Text;
				this.Param.Database = txtDatabase.Text;
				this.Param.Username = txtUsername.Text;
				this.Param.Password = txtPassword.Text;
			}
			else
			{
				txtServer.Text =   this.Param.Server;
				txtDatabase.Text = this.Param.Database;
				txtUsername.Text = this.Param.Username;
				txtPassword.Text = this.Param.Password;
			}
		}

		private void DisplayComboFab()
		{
			Cursor.Current = Cursors.WaitCursor;

			try
			{
				if (Param != null)
				{
					if (Param.TestConnection())
					{
						SiGlaz.DAL.GeneralCmd cmd = new SiGlaz.DAL.GeneralCmd(Param);
						DataSet dataSet = cmd.ExecuteDataset("SELECT * FROM DDA_Fabs");
						DataTable dt = dataSet.Tables[0];

						DataRow  dr = dt.NewRow();
						dr["FabKey"] = 0;
						dr["FabID"] = "All";
						dt.Rows.InsertAt(dr,0);

						dt.AcceptChanges();

						cboFab.ValueMember = "FabKey";
						cboFab.DisplayMember = "FabID";
						cboFab.DataSource = dt;
					}
				}
			}
			catch
			{
				
			}
		}


		private void DeleteData()
		{
			try
			{
				if (cboFab.SelectedIndex == 0)
				{
					GeneralCmd cmd = new GeneralCmd(this.Param);

					cmd.ExecuteNonQuery("DELETE FROM DDA_Results");
					cmd.ExecuteNonQuery("DELETE FROM DDA_Processed");
                    cmd.ExecuteNonQuery("DELETE FROM DDA_ProcessedOperation");
					cmd.ExecuteNonQuery("UPDATE DDA_Surfaces SET DDA_Surfaces.HasSignature = 0");

					if( chkDeleteSource.Checked)
					{
						cmd.ExecuteNonQuery("DELETE FROM DDA_Disks");
						cmd.ExecuteNonQuery("DELETE FROM DDA_Fabs");
                        cmd.ExecuteNonQuery("DELETE FROM DDA_SurfacesOperation");
					}
				}
				else if(cboFab.SelectedValue!=null)
				{
					GeneralCmd cmd = new GeneralCmd(Param);

					short fabid = (short)cboFab.SelectedValue;

					//Delete Result
					string SQL = string.Format("DELETE FROM dbo.DDA_Results FROM dbo.DDA_Results  as R INNER JOIN  dbo.DDA_ResultDetail ON R.ResultKey = dbo.DDA_ResultDetail.ResultKey INNER JOIN dbo.DDA_Surfaces ON dbo.DDA_ResultDetail.SurfaceKey = dbo.DDA_Surfaces.SurfaceKey INNER JOIN dbo.DDA_Disks ON dbo.DDA_Surfaces.DiskKey = dbo.DDA_Disks.DiskKey WHERE (dbo.DDA_Disks.FabKey = {0})",fabid);
					cmd.ExecuteNonQuery(SQL);

					//Delete Processed
					SQL = string.Format("DELETE FROM dbo.DDA_Processed FROM dbo.DDA_Processed as  pro INNER JOIN dbo.DDA_Surfaces ON pro.SurfaceKey = dbo.DDA_Surfaces.SurfaceKey INNER JOIN dbo.DDA_Disks ON dbo.DDA_Surfaces.DiskKey = dbo.DDA_Disks.DiskKey WHERE (dbo.DDA_Disks.FabKey = {0})",fabid);
					cmd.ExecuteNonQuery(SQL);

                    SQL = string.Format("DELETE FROM dbo.DDA_ProcessedOperation FROM DDA_ProcessedOperation as  pro INNER JOIN dbo.DDA_Surfaces ON pro.SurfaceKey = dbo.DDA_Surfaces.SurfaceKey INNER JOIN dbo.DDA_Disks ON dbo.DDA_Surfaces.DiskKey = dbo.DDA_Disks.DiskKey WHERE (dbo.DDA_Disks.FabKey = {0})", fabid);
                    cmd.ExecuteNonQuery(SQL);

					//Update Surface Has Signature Status
					SQL = string.Format("UPDATE DDA_Surfaces SET DDA_Surfaces.HasSignature = 0 FROM DDA_Surfaces INNER JOIN DDA_Disks ON DDA_Surfaces.DiskKey = DDA_Disks.DiskKey WHERE DDA_Disks.FabKey = {0}", fabid);
					cmd.ExecuteNonQuery(SQL);

					if (chkDeleteSource.Checked)
					{
						//Delete Source
						SQL = string.Format("DELETE FROM DDA_Disks WHERE FabKey ={0}",fabid);
						cmd.ExecuteNonQuery(SQL);

						//Delete fab
						SQL = string.Format("DELETE FROM DDA_Fabs WHERE FabKey ={0}",fabid);
						cmd.ExecuteNonQuery(SQL);
					}	
				}
				
				MessageBox.Show("Delete data successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch(Exception ex)
			{
				MessageBox.Show("Delete data fail :" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion
		
		#region Threading Worker
		private void ThreadingWorker(object sender)
		{
			try
			{
				System.Threading.Thread.Sleep(1000);
				DeleteData();
			}
			catch (System.Exception e)
			{
				MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);	
			}
			finally
			{
				if (_dlgStatus != null)
				{
					_dlgStatus.Close();
					_dlgStatus = null;
				}
			}
		}
		#endregion

		#region Windows Events Handles
		private void MainForm_Load(object sender, System.EventArgs e)
		{
			SiGlaz.Utility.PersistenceDefaultForm archive = new SiGlaz.Utility.PersistenceDefaultForm(this);
			archive.Load();
			UpdateData(false);
			DisplayComboFab();

			SqlHelper.Timeout = 60*60;//Timeout 1 tieng dong ho
		}

		private void btnExecute_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			UpdateData(true);
			if(!this.Param.TestConnection())
			{
				MessageBox.Show("Connect to database failed", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			try
			{
				_dlgStatus = new DlgStatus();
				ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadingWorker));
				_dlgStatus.ShowDialog();
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			SiGlaz.Utility.PersistenceDefaultForm archive = new SiGlaz.Utility.PersistenceDefaultForm(this);
			archive.Save();

			UpdateData(true);
			if(this.Param.TestConnection()) 
			{
				try
				{
					this.Param.Save(GetConfigurationFileName());
				}
				catch
				{
				}
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			UpdateData(true);
			if(!this.Param.TestConnection())
				MessageBox.Show("Connect to database fail", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			else
				MessageBox.Show("Connect to database successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void btnRefresh_Click(object sender, System.EventArgs e)
		{
			UpdateData(true);
			DisplayComboFab();
		}
		#endregion
	}
}
