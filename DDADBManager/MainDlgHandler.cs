using System;
using System.Windows.Forms;
using DDADBManager.Process;
using SiGlaz.Common.DDA;

namespace DDADBManager
{
	/// <summary>
	/// Summary description for MainDlgHandler.
	/// </summary>
	public class MainDlgHandler
	{
		private MainDlg		_Form;

		public MainDlgHandler()
		{
		}

		public MainDlg Form
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

			UpdateGUICmd();
		}

//		private void Test()
//		{
//			Process.LoadETestProcess xx1 = new DDADBManager.Process.LoadETestProcess();
//			Modal.SourceFolder source  = new DDADBManager.Modal.SourceFolder();
//			source.FolderPath = "D:\\abc";
//			xx1.DataSource = source;
//
//			Process.LoadETestProcess xx2 = new DDADBManager.Process.LoadETestProcess();
//			source  = new DDADBManager.Modal.SourceFolder();
//			source.FolderPath = "D:\\def";
//			xx2.DataSource = source;
//
//			View.LoadETestProcessViewCtrl view1 = new DDADBManager.View.LoadETestProcessViewCtrl();
//			view1.DataSource = xx1;
//			Form.schemaViewCrl1.Add(view1);
//
//			View.LoadETestProcessViewCtrl view2 = new DDADBManager.View.LoadETestProcessViewCtrl();
//			view2.DataSource = xx2;
//			Form.schemaViewCrl1.Add(view2);
//		}

		public  void RunSelectedProcess()
		{
			this.Form.schemaViewCrl1.SelectedControl.Run();
		}

		public  void StopSelectedProcess()
		{
			this.Form.schemaViewCrl1.SelectedControl.Stop();
		}

		public  void DeleteSelectedProcess()
		{
			if(MessageBox.Show(this.Form,"Do you want to delete selected process(es)?",this.Form.Text,MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
			{
				this.Form.schemaViewCrl1.Delete(this.Form.schemaViewCrl1.SelectedControl);
			}
		}

		public  void DeleteAll()
		{
			if(MessageBox.Show(this.Form,"Do you want to delete all processes ?",this.Form.Text,MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
			{
				this.Form.schemaViewCrl1.DeleteAll();
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
			foreach(View.ProcessViewCtrl recipectrl in this.Form.schemaViewCrl1.AllProcessCtrl)
			{
				if(!recipectrl.DataSourceBase.IsRunning)
					recipectrl.Run();
			}
		}

		public  void StopAll()
		{
			foreach(View.ProcessViewCtrl recipectrl in this.Form.schemaViewCrl1.AllProcessCtrl)
			{
				if(recipectrl.DataSourceBase.IsRunning)
					recipectrl.Stop();
			}
		}


		public  void StopAllNoGUI()
		{
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

				if(recipectrl.DataSourceBase.IsRunning)
				{
					recipectrl.Stop();
				}
			}

			this.Form.Controls.Remove(this.Form.schemaViewCrl1);
		}


		public  void CreateProcess()
		{
			Dialog.LoadETestEditDlg dlg = new DDADBManager.Dialog.LoadETestEditDlg();
			Cursor.Current = Cursors.WaitCursor;

			if( dlg.ShowDialog(this.Form) == DialogResult.OK)
			{
				View.LoadETestProcessViewCtrl view1 = new DDADBManager.View.LoadETestProcessViewCtrl();

				Process.LoadETestProcess obj = dlg.DataSource;

				Schema  schema = new Schema();
				schema.Process = this.Form.schemaViewCrl1.AllProcessSource;

				obj.ID = schema.MaxTaskID+1;

				view1.DataSource = obj;

				Form.schemaViewCrl1.Add(view1);
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

				Schema  schema = new Schema();
				schema.Process = this.Form.schemaViewCrl1.AllProcessSource;

				obj.ID = schema.MaxTaskID+1;

				view1.DataSource = obj;

				Form.schemaViewCrl1.Add(view1);
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

				Schema  schema = new Schema();
				schema.Process = this.Form.schemaViewCrl1.AllProcessSource;

				obj.ID = schema.MaxTaskID+1;

				view1.DataSource = obj;

				Form.schemaViewCrl1.Add(view1);
			}
		}

		public  void ModifyProcess()
		{
			Process.ProcessBase baseobj = Form.schemaViewCrl1.SelectedControl.DataSourceBase;

			if(baseobj is LoadETestProcess)
			{
				Dialog.LoadETestEditDlg dlg = new DDADBManager.Dialog.LoadETestEditDlg();
				Cursor.Current = Cursors.WaitCursor;

				dlg.DataSource = baseobj as LoadETestProcess;
				if( dlg.ShowDialog(this.Form) == DialogResult.OK)
				{
					(Form.schemaViewCrl1.SelectedControl as View.LoadETestProcessViewCtrl).DataSource =dlg.DataSource;

				}
			}
			else if(baseobj is TransferProcess)
			{
				Dialog.TransferEditDlg dlg = new DDADBManager.Dialog.TransferEditDlg();
				Cursor.Current = Cursors.WaitCursor;

				dlg.DataSource = baseobj as TransferProcess;
				if( dlg.ShowDialog(this.Form) == DialogResult.OK)
				{
					(Form.schemaViewCrl1.SelectedControl as View.LoadETestProcessViewCtrl).DataSource =dlg.DataSource;
				}
			}
			else if(baseobj is DeleteProcess)
			{
				Dialog.DeleteEditDlg dlg = new DDADBManager.Dialog.DeleteEditDlg();
				Cursor.Current = Cursors.WaitCursor;

				dlg.DataSource = baseobj as DeleteProcess;
				if( dlg.ShowDialog(this.Form) == DialogResult.OK)
				{
					(Form.schemaViewCrl1.SelectedControl as View.LoadETestProcessViewCtrl).DataSource =dlg.DataSource;
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

		public void UpdateGUICmd()
		{
			this.Form.btnModifyProcess.Enabled = this.Form.miModifyProcess.Enabled = this.Form.schemaViewCrl1.SelectedControl!=null && !this.Form.schemaViewCrl1.SelectedControl.DataSourceBase.IsRunning ;
			this.Form.btnDeleteProcess.Enabled = this.Form.miDeleteProcess.Enabled = this.Form.schemaViewCrl1.SelectedControl!=null && !this.Form.schemaViewCrl1.SelectedControl.DataSourceBase.IsRunning ;

			this.Form.btnRunProcess.Enabled = this.Form.miRun.Enabled =
				this.Form.schemaViewCrl1.SelectedControl!=null && !this.Form.schemaViewCrl1.SelectedControl.DataSourceBase.IsRunning;
			this.Form.btnStopProcess.Enabled = this.Form.miStop.Enabled =
				this.Form.schemaViewCrl1.SelectedControl!=null && this.Form.schemaViewCrl1.SelectedControl.DataSourceBase.IsRunning;

			this.Form.btnDeleteAll.Enabled = this.Form.miDeleteAll.Enabled = this.Form.schemaViewCrl1.SelectedControl!=null && !this.Form.schemaViewCrl1.SelectedControl.DataSourceBase.IsRunning;
			this.Form.btnStopAll.Enabled= this.Form.miStopAll.Enabled = this.Form.schemaViewCrl1.SelectedControl!=null;
			this.Form.btnRunAll.Enabled = this.Form.miRunAll.Enabled = this.Form.schemaViewCrl1.AllProcessCtrl.Length>0;
			this.Form.mnuTOOLS.Enabled = !this.AnyRun;
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
			DDARecipe.Dialogs.DlgWebServiceConfiguration dlg = new DDARecipe.Dialogs.DlgWebServiceConfiguration();
			if( dlg.ShowDialog(this.Form) == DialogResult.OK)
			{
				Cursor.Current = Cursors.WaitCursor;
				this.Form.Refresh();

				DDARecipe.DDAExternalData.RefreshDiskType();
			}
		}


		private void miSaveFile_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter =  "DDADB Schema files (*.dbs)|*.dbs|All files (*.*)|*.*";
			dlg.Title = "Save Database Schema";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				try
				{
					this.Form.Refresh();
					Cursor.Current = Cursors.WaitCursor;

					Schema  obj = new Schema();
					obj.Process = this.Form.schemaViewCrl1.AllProcessSource;
					obj.Save(dlg.FileName);
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
			dlg.Title = "Open Database Schema";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				try
				{
					this.Form.Refresh();
					Cursor.Current = Cursors.WaitCursor;

					Schema  objschema =  new Schema();
					objschema.Load(dlg.FileName);

					this.Form.schemaViewCrl1.DeleteAll();
					foreach(ProcessBase obj in objschema.Process)
					{
						obj.IsRunning = false;
						obj.IsWaiting = false;

						View.LoadETestProcessViewCtrl view1 = new DDADBManager.View.LoadETestProcessViewCtrl();
						view1.DataSource = obj;// as LoadETestProcess;
						Form.schemaViewCrl1.Add(view1);
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show(this.Form,"Cannot load from file\r\n" + ex.Message);
				}
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
				Cursor.Current = Cursors.WaitCursor;
				this.Form.Refresh();

				DDARecipe.DDAExternalData.RefreshDiskType();
			}
		}

		private void miProductCode_Click(object sender, EventArgs e)
		{
			DDARecipe.Dialogs.DlgProduct dlg = new DDARecipe.Dialogs.DlgProduct();

			this.Form.Refresh();
			Cursor.Current = Cursors.WaitCursor;

			if( dlg.ShowDialog()==DialogResult.OK)
			{
				Cursor.Current = Cursors.WaitCursor;
				this.Form.Refresh();

				DDARecipe.DDAExternalData.RefreshDiskType();
			}
		}

		private void miOptions_Click(object sender, EventArgs e)
		{
			DDARecipe.Dialogs.DlgOptions dlg = new DDARecipe.Dialogs.DlgOptions(false,true);
			dlg.Icon = this.Form.Icon;

			this.Form.Refresh();
			Cursor.Current = Cursors.WaitCursor;

			if( dlg.ShowDialog()==DialogResult.OK)
			{
				Cursor.Current = Cursors.WaitCursor;
				this.Form.Refresh();

				//DDARecipe.DDAExternalData.RefreshDiskType();
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
