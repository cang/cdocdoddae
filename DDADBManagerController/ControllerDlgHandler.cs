using System;
using System.Windows.Forms;
using DDADBManager.Process;
using SiGlaz.Common.DDA;
using DDADBManagerController;
using System.IO;


namespace DDADBManager
{
	/// <summary>
	/// Summary description for MainDlgHandler.
	/// </summary>
	public class ControllerDlgHandler
	{
		private ControllerDlg		_Form;

		public ControllerDlgHandler()
		{
		}

		public ControllerDlg Form
		{
			get
			{
				return _Form;
			}
			set
			{
				_Form = value;
				//Test();
				InitForm();
			}
		}

		public void InitForm()
		{
			this.Form.toolBar1.ButtonClick+=new System.Windows.Forms.ToolBarButtonClickEventHandler(toolBar1_ButtonClick);
			this.Form.schemaViewCrl1.OnSelectedChanged+=new EventHandler(schemaViewCrl1_OnSelectedChanged);

			this.Form.Closing+=new System.ComponentModel.CancelEventHandler(Form_Closing);
			this.Form.miExit.Click+=new EventHandler(miExit_Click);
			this.Form.miWebServiceConfig.Click+=new EventHandler(miWebServiceConfig_Click);
			this.Form.miSaveFile.Click+=new EventHandler(miSaveFile_Click);
			this.Form.miOpenFile.Click+=new EventHandler(miOpenFile_Click);
			this.Form.miCreateProcess.Click+=new EventHandler(miCreateProcess_Click);
			this.Form.miModifyProcess.Click+=new EventHandler(miModifyProcess_Click);
			this.Form.miDeleteProcess.Click+=new EventHandler(miDeleteProcess_Click);
			this.Form.miDeleteAll.Click+=new EventHandler(miDeleteAll_Click);
			this.Form.miRun.Click+=new EventHandler(miRun_Click);
			this.Form.miStop.Click+=new EventHandler(miStop_Click);
			this.Form.miRunAll.Click+=new EventHandler(miRunAll_Click);
			this.Form.miStopAll.Click+=new EventHandler(miStopAll_Click);
			this.Form.miAbout.Click+=new EventHandler(miAbout_Click);
			this.Form.miDiskTypeConfiguration.Click+=new EventHandler(miDiskTypeConfiguration_Click);
			this.Form.miProductCode.Click+=new EventHandler(miProductCode_Click);
			this.Form.miOptions.Click+=new EventHandler(miOptions_Click);
			this.Form.miAddTransferTask.Click+=new EventHandler(miAddTransferTask_Click);
			this.Form.miAddDeleteTask.Click+=new EventHandler(miAddDeleteTask_Click);

			this.Form.Load+=new EventHandler(Form_Load);

			UpdateGUICmd();
		}


		public  void RunSelectedProcess()
		{
			int processid = RemotableSchemacController.SchemaControler.Schema.Process.IndexOf(this.Form.schemaViewCrl1.SelectedControl.DataSourceBase);
			if(processid>=0)
			{
				string sinvalid = 
					RemotableSchemacController.SchemaControler.RunProcess(processid);
				if( sinvalid!=string.Empty)
				{
					MessageBox.Show("Invalid Taks List : " + sinvalid,this.Form.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
					return;
				}
			}
		}

		public  void StopSelectedProcess()
		{
			int processid = RemotableSchemacController.SchemaControler.Schema.Process.IndexOf(this.Form.schemaViewCrl1.SelectedControl.DataSourceBase);
			if(processid>=0)
			{
				RemotableSchemacController.SchemaControler.StopProcess(processid);
			}
		}

		public  void DeleteSelectedProcess()
		{
			if(MessageBox.Show(this.Form,"Do you want to delete selected process(es)?",this.Form.Text,MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
			{
				ProcessBase obj = this.Form.schemaViewCrl1.SelectedControl.DataSourceBase;

				this.Form.schemaViewCrl1.Delete(this.Form.schemaViewCrl1.SelectedControl);

				RemotableSchemacController.SchemaControler.Schema.Process.Remove(obj);
				UpdateSchemaToRemote();
			}
		}

		public  void DeleteAll()
		{
			if(MessageBox.Show(this.Form,"Do you want to delete all processes?",this.Form.Text,MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
			{
				this.Form.schemaViewCrl1.DeleteAll();

				RemotableSchemacController.SchemaControler.Schema.Process.Clear();
				UpdateSchemaToRemote();
			}
		}

		private bool AnyRun
		{
			get
			{
				foreach(View.ProcessViewCtrl recipectrl in this.Form.schemaViewCrl1.AllProcessCtrl)
				{
					if(recipectrl.DataSourceBase.IsRunning)
						return true;
				}
				return false;
			}
		}

		public  void RunAll()
		{
			string sinvalid = RemotableSchemacController.SchemaControler.RunAllProcess();
			if( sinvalid!=string.Empty)
			{
				MessageBox.Show("Invalid Taks List : " + sinvalid,this.Form.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
		}

		public  void StopAll()
		{
			RemotableSchemacController.SchemaControler.StopAllProcess();
//			foreach(DDADBManager.Process.ProcessBase process in RemotableSchemacController.SchemaControler.Schema.Process)
//			{
//				process.IsRunning = false;
//			}
		}

		public  void StopAllNoGUI()
		{
			RemotableSchemacController.SchemaControler.RemoteSchema.UnRegisterEvent();

			this.Form.OuputCtrl.DataSource = null;
			this.Form.TraceCtrl.DataSource = null;

			this.Form.tabPage1.Controls.Clear();
			this.Form.tabPage2.Controls.Clear();
		

			//this.Form.dm.Contents.Clear();
			foreach(View.ProcessViewCtrl recipectrl in this.Form.schemaViewCrl1.AllProcessCtrl)
			{
				if(recipectrl is View.LoadETestProcessViewCtrl)
				{
					(recipectrl as View.LoadETestProcessViewCtrl).DataSource = null;
				}
				//RemotableSchemacController.SchemaControler.StopAllProcess();
			}

			this.Form.Controls.Remove(this.Form.schemaViewCrl1);
		}


		public  void CreateProcess()
		{
			Cursor.Current = Cursors.WaitCursor;

			Dialog.LoadETestEditDlg dlg = new DDADBManager.Dialog.LoadETestEditDlg();

			if( dlg.ShowDialog(this.Form) == DialogResult.OK)
			{
				View.LoadETestProcessViewCtrl view1 = new DDADBManager.View.LoadETestProcessViewCtrl();

				Process.LoadETestProcess obj = dlg.DataSource;
				obj.ID = RemotableSchemacController.SchemaControler.Schema.MaxTaskID + 1;

				view1.DataSource = obj;
				Form.schemaViewCrl1.Add(view1);

				RemotableSchemacController.SchemaControler.Schema.Process.Add(obj);

				UpdateSchemaToRemote();//temporary , cannot allow adding new Task when running;
			}
		}

		public  void CreateTransferProcess()
		{
			Dialog.TransferEditDlg dlg = new DDADBManager.Dialog.TransferEditDlg();
			Cursor.Current = Cursors.WaitCursor;

			if( dlg.ShowDialog(this.Form) == DialogResult.OK)
			{
				View.LoadETestProcessViewCtrl view1 = new DDADBManager.View.LoadETestProcessViewCtrl();
				
				Process.TransferProcess obj = dlg.DataSource;
				obj.ID = RemotableSchemacController.SchemaControler.Schema.MaxTaskID + 1;

				view1.DataSource = obj;
				Form.schemaViewCrl1.Add(view1);

				RemotableSchemacController.SchemaControler.Schema.Process.Add(obj);

				UpdateSchemaToRemote();//temporary , cannot allow adding new Task when running;
			}
		}

		public  void CreateDeleteProcess()
		{
			Dialog.DeleteEditDlg dlg = new DDADBManager.Dialog.DeleteEditDlg();
			Cursor.Current = Cursors.WaitCursor;

			if( dlg.ShowDialog(this.Form) == DialogResult.OK)
			{
				View.LoadETestProcessViewCtrl view1 = new DDADBManager.View.LoadETestProcessViewCtrl();
				
				Process.DeleteProcess obj = dlg.DataSource;
				obj.ID = RemotableSchemacController.SchemaControler.Schema.MaxTaskID + 1;

				view1.DataSource = obj;
				Form.schemaViewCrl1.Add(view1);

				RemotableSchemacController.SchemaControler.Schema.Process.Add(obj);

				UpdateSchemaToRemote();//temporary , cannot allow adding new Task when running;
			}
		}


		public  void ModifyProcess()
		{
			Cursor.Current = Cursors.WaitCursor;

			Process.ProcessBase baseobj = Form.schemaViewCrl1.SelectedControl.DataSourceBase;

			if(baseobj is LoadETestProcess)
			{
				Dialog.LoadETestEditDlg dlg = new DDADBManager.Dialog.LoadETestEditDlg();
				dlg.DataSource = baseobj as LoadETestProcess;
				if( dlg.ShowDialog(this.Form) == DialogResult.OK)
				{
					(Form.schemaViewCrl1.SelectedControl as View.LoadETestProcessViewCtrl).DataSource =dlg.DataSource;
					UpdateSchemaToRemote();// luc dang chay khong duoc mofidy --> safe code
				}
			}
			else if(baseobj is TransferProcess)
			{
				Dialog.TransferEditDlg dlg = new DDADBManager.Dialog.TransferEditDlg();
				dlg.DataSource = baseobj as TransferProcess;
				if( dlg.ShowDialog(this.Form) == DialogResult.OK)
				{
					(Form.schemaViewCrl1.SelectedControl as View.LoadETestProcessViewCtrl).DataSource =dlg.DataSource;
					UpdateSchemaToRemote();// luc dang chay khong duoc mofidy --> safe code
				}
			}
			else if(baseobj is DeleteProcess)
			{
				Dialog.DeleteEditDlg dlg = new DDADBManager.Dialog.DeleteEditDlg();
				dlg.DataSource = baseobj as DeleteProcess;
				if( dlg.ShowDialog(this.Form) == DialogResult.OK)
				{
					(Form.schemaViewCrl1.SelectedControl as View.LoadETestProcessViewCtrl).DataSource =dlg.DataSource;
					UpdateSchemaToRemote();// luc dang chay khong duoc mofidy --> safe code
				}
			}
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if( e.Button == this.Form.btnRunProcess)
			{
				RunSelectedProcess();
			}
			else if( e.Button == this.Form.btnRunAll)
			{
				RunAll();
			}
			else if( e.Button == this.Form.btnStopProcess)
			{
				StopSelectedProcess();
			}
			else if( e.Button == this.Form.btnStopAll)
			{
				StopAll();
			}
			else if( e.Button == this.Form.btnDeleteProcess)
			{
				DeleteSelectedProcess();
			}
			else if( e.Button == this.Form.btnNewProcess)
			{
				CreateProcess();
			}
			else if( e.Button == this.Form.btnModifyProcess)
			{
				ModifyProcess();
			}
			else if( e.Button == this.Form.btnDeleteAll)
			{
				DeleteAll();
			}
			else if( e.Button== this.Form.btnAbout)
			{
				miAbout_Click(null,null);
			}
		}

		private delegate void MessageHandler();
		public void UpdateGUICmd()
		{
			if(!this.Form.InvokeRequired)
				UpdateGUICmdSafe();
			else
				this.Form.BeginInvoke(new MessageHandler(UpdateGUICmdSafe));
		}

		public void UpdateGUICmdSafe()
		{
//			this.Form.btnModifyProcess.Enabled = this.Form.miModifyProcess.Enabled = this.Form.schemaViewCrl1.SelectedControl!=null && !this.Form.schemaViewCrl1.SelectedControl.DataSourceBase.IsRunning ;
//			this.Form.btnDeleteProcess.Enabled = this.Form.miDeleteProcess.Enabled = this.Form.schemaViewCrl1.SelectedControl!=null && !this.Form.schemaViewCrl1.SelectedControl.DataSourceBase.IsRunning ;

			this.Form.btnRunProcess.Enabled = this.Form.miRun.Enabled =
				this.Form.schemaViewCrl1.SelectedControl!=null && !this.Form.schemaViewCrl1.SelectedControl.DataSourceBase.IsRunning;
			this.Form.btnStopProcess.Enabled = this.Form.miStop.Enabled =
				this.Form.schemaViewCrl1.SelectedControl!=null && this.Form.schemaViewCrl1.SelectedControl.DataSourceBase.IsRunning;

//			this.Form.btnDeleteAll.Enabled = this.Form.miDeleteAll.Enabled = this.Form.schemaViewCrl1.SelectedControl!=null && !this.Form.schemaViewCrl1.SelectedControl.DataSourceBase.IsRunning;
			this.Form.btnStopAll.Enabled= this.Form.miStopAll.Enabled = this.Form.schemaViewCrl1.SelectedControl!=null;
			this.Form.btnRunAll.Enabled = this.Form.miRunAll.Enabled = this.Form.schemaViewCrl1.AllProcessCtrl.Length>0;

			this.Form.mnuTOOLS.Enabled = !this.AnyRun;
			this.Form.miOpenFile.Enabled = !this.AnyRun;

			//In this version, forge all taks must stop before change schema
			this.Form.btnNewProcess.Enabled = this.Form.miCreateProcess.Enabled = !this.AnyRun;
			this.Form.miAddTransferTask.Enabled = this.Form.miAddDeleteTask.Enabled = !this.AnyRun;

			this.Form.btnModifyProcess.Enabled = this.Form.miModifyProcess.Enabled = !this.AnyRun && this.Form.schemaViewCrl1.SelectedControl!=null;
			this.Form.btnDeleteProcess.Enabled = this.Form.miDeleteProcess.Enabled = !this.AnyRun && this.Form.schemaViewCrl1.SelectedControl!=null;
			this.Form.btnDeleteAll.Enabled = this.Form.miDeleteAll.Enabled = !this.AnyRun ;//&& this.Form.schemaViewCrl1.SelectedControl!=null;
		}

		object prevslectedobjt = null;
		private void schemaViewCrl1_OnSelectedChanged(object sender, EventArgs e)
		{
			UpdateGUICmd();
			if(sender==null) return;

			if(prevslectedobjt!=sender)
			{
				prevslectedobjt=sender;
				this.Form.OuputCtrl.DataSource = (sender as View.ProcessViewCtrl).DataSourceBase.OutputHistory;
				this.Form.TraceCtrl.DataSource = (sender as View.ProcessViewCtrl).DataSourceBase.TraceHistory;
			}
		}

		private void Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			StopAllNoGUI();
		}

		private void miExit_Click(object sender, EventArgs e)
		{
			if(MessageBox.Show(this.Form,"Do you want to exit program?",this.Form.Text,MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
			{
				System.Windows.Forms.Application.Exit();
			}
		}

		private void miWebServiceConfig_Click(object sender, EventArgs e)
		{
			Program.LoadApplicationDataFromServer();//new

			DlgConnectionConfig dlg = new DlgConnectionConfig();
			dlg.Icon = this.Form.Icon;

			if( dlg.ShowDialog(this.Form) == DialogResult.OK)
			{
				Cursor.Current = Cursors.WaitCursor;
				this.Form.Refresh();

				string configFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Connection.cfg");
				SiGlaz.DAL.ConnectionParam param = new SiGlaz.DAL.ConnectionParam();
				param.Load(configFileName);
				RemotableSchemacController.SchemaControler.RemoteSchema.SetConnectionParam(param);

				byte[] lpbyte= SiGlaz.Common.DDA.AppData.Data.SaveApplicationData();
				RemotableSchemacController.SchemaControler.RemoteSchema.SaveApplicationConfig(lpbyte);

				DDARecipe.DDAExternalData.RefreshDiskType();
				if( !RemotableSchemacController.SchemaControler.RemoteSchema.RefreshExternalData() )
				{
					MessageBox.Show(this.Form,"DDAServices cannot connect to database. Please check database and restart DDAServices",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);
					return;
				}

				//Refresh for Recipe Manager server
				RemotableSchemacController.SchemaControler.RemoteRecipeList.SetConnectionParam(param);
				RemotableSchemacController.SchemaControler.RemoteRecipeList.SaveApplicationConfig(lpbyte);

				//Force Reload Recipes on GUI 
				RemotableSchemacController.SchemaControler.RemoteRecipeList.HandlerOnRefresh(SiGlaz.Recipes.RecipeEventArgs.Empty);
			}
		}


		private void miSaveFile_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter =  "DDADB Schema files (*.dbs)|*.dbs|All files (*.*)|*.*";
			dlg.Title = "Export Database Schema";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				try
				{
					this.Form.Refresh();
					Cursor.Current = Cursors.WaitCursor;

					RemotableSchemacController.SchemaControler.Schema.Save(dlg.FileName);
				}
				catch(Exception ex)
				{
					MessageBox.Show(this.Form,"Cannot save into file\r\n" + ex.StackTrace);
				}
			}
		}

		private void miOpenFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter =  "DDADB Schema files (*.dbs)|*.dbs|All files (*.*)|*.*";
			dlg.Title = "Import Database Schema";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				try
				{
					this.Form.Refresh();
					Cursor.Current = Cursors.WaitCursor;

					RemotableSchemacController.SchemaControler.Schema.Load(dlg.FileName);
					RemotableSchemacController.SchemaControler.Schema.ResetStatus();

					UpdateSchemaToRemote();
	
					this.Form.schemaViewCrl1.DeleteAll();
					foreach(ProcessBase obj in RemotableSchemacController.SchemaControler.Schema.Process)
					{
						View.LoadETestProcessViewCtrl view1 = new DDADBManager.View.LoadETestProcessViewCtrl();
						view1.DataSource = obj;
						Form.schemaViewCrl1.Add(view1);
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show(this.Form,"Cannot load from file\r\n" + ex.Message);
				}
			}
		}

		public void OpenFromRemote()
		{
			try
			{
				this.Form.Refresh();
				Cursor.Current = Cursors.WaitCursor;

				RemotableSchemacController.SchemaControler.RequireSchema();

				//Register Event 
				RemotableSchemacController.SchemaControler.RemoteSchema.RegisterEvent();

				Schema  objschema =  RemotableSchemacController.SchemaControler.Schema;
		
				this.Form.schemaViewCrl1.DeleteAll();

				int id = 0;
				foreach(ProcessBase obj in objschema.Process)
				{
					View.LoadETestProcessViewCtrl view1 = new DDADBManager.View.LoadETestProcessViewCtrl();
					view1.DataSource = obj;

					//Update content of Output and Trace
					obj.OutputHistory._ContentLine = RemotableSchemacController.SchemaControler.RemoteSchema.RequireOutput(id);
					obj.TraceHistory._ContentLine = RemotableSchemacController.SchemaControler.RemoteSchema.RequireTrace(id);

					Form.schemaViewCrl1.Add(view1);

					id++;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this.Form,"Cannot load data from server\r\n" + ex.Message);
			}
		}

		private void miCreateProcess_Click(object sender, EventArgs e)
		{
			this.CreateProcess();
		}

		private void miModifyProcess_Click(object sender, EventArgs e)
		{
			this.ModifyProcess();
		}

		private void miDeleteProcess_Click(object sender, EventArgs e)
		{
			this.DeleteSelectedProcess();
		}

		private void miDeleteAll_Click(object sender, EventArgs e)
		{
			this.DeleteAll();
		}

		private void miRun_Click(object sender, EventArgs e)
		{
			this.RunSelectedProcess();
		}

		private void miStop_Click(object sender, EventArgs e)
		{
			this.StopSelectedProcess();
		}

		private void miRunAll_Click(object sender, EventArgs e)
		{
			this.RunAll();
		}

		private void miStopAll_Click(object sender, EventArgs e)
		{
			this.StopAll();
		}

		private void miAbout_Click(object sender, EventArgs e)
		{
			AboutSSA dlg = new AboutSSA();
			dlg.ShowDialog(this.Form);
		}

		private void miDiskTypeConfiguration_Click(object sender, EventArgs e)
		{
			DDARecipe.Dialogs.DlgDiskTypeConfiguration dlg = new DDARecipe.Dialogs.DlgDiskTypeConfiguration();

			this.Form.Refresh();
			Cursor.Current = Cursors.WaitCursor;

			dlg.LoadData();

			if( dlg.ShowDialog()==DialogResult.OK)
			{
				DDARecipe.DDAExternalData.RefreshDiskType();
				if(!RemotableSchemacController.SchemaControler.RemoteSchema.RefreshExternalData())
				{
					MessageBox.Show(this.Form,"DDAServices cannot connect to database. Please check database and restart DDAServices",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);
					return;
				}
			}
		}

		private void Form_Load(object sender, EventArgs e)
		{
			OpenFromRemote();
		}

		private void UpdateSchemaToRemote()
		{
			try
			{
				Cursor.Current = Cursors.WaitCursor;

				RemotableSchemacController.SchemaControler.RemoteSchema.UnRegisterEvent();

				RemotableSchemacController.SchemaControler.SaveShema();
				
				RemotableSchemacController.SchemaControler.RemoteSchema.RegisterEvent();
			}
			catch(Exception ex)
			{
				MessageBox.Show(this.Form,"Cannot save into server\r\n" + ex.StackTrace);
			}
		}

		private void miProductCode_Click(object sender, EventArgs e)
		{
			DDARecipe.Dialogs.DlgProduct dlg = new DDARecipe.Dialogs.DlgProduct();

			this.Form.Refresh();
			Cursor.Current = Cursors.WaitCursor;

			if( dlg.ShowDialog()==DialogResult.OK)
			{
				DDARecipe.DDAExternalData.RefreshDiskType();
				if(!RemotableSchemacController.SchemaControler.RemoteSchema.RefreshExternalData())
				{
					MessageBox.Show(this.Form,"DDAServices cannot connect to database. Please check database and restart DDAServices",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);
					return;
				}
			}
		}

		private void miOptions_Click(object sender, EventArgs e)
		{
			DDARecipe.Dialogs.DlgOptions dlg = new DDARecipe.Dialogs.DlgOptions(false,true);
			
			Cursor.Current = Cursors.WaitCursor;
			this.Form.Refresh();

			Program.LoadApplicationDataFromServer();//new

			dlg.LoadData();
			if( dlg.ShowDialog(this.Form) == DialogResult.OK)
			{
				byte[] lpbyte= SiGlaz.Common.DDA.AppData.Data.SaveApplicationData();
				RemotableSchemacController.SchemaControler.RemoteSchema.SaveApplicationConfig(lpbyte);
			}
		}

		private void miAddTransferTask_Click(object sender, EventArgs e)
		{
			this.CreateTransferProcess();
		}

		private void miAddDeleteTask_Click(object sender, EventArgs e)
		{
			this.CreateDeleteProcess();
		}
	}
}
