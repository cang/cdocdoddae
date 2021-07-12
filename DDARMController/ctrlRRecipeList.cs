using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using DDARMWinUI;

namespace DDARMController
{
	/// <summary>
	/// Summary description for ctrlRRecipeList.
	/// </summary>
	public class ctrlRRecipeList : DDARMWinUI.Controls.ctrlRecipeList
	{
		public System.Windows.Forms.Timer timer1;
		public System.Windows.Forms.Timer timer2;
		private System.ComponentModel.IContainer components;

		public ctrlRRecipeList() : base()
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
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			// 
			// lvRecipeList
			// 
			this.lvRecipeList.Name = "lvRecipeList";
			// 
			// timer1
			// 
			this.timer1.Interval = 60000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			this.timer1.Enabled  = false;
			// 
			// timer2
			// 
			this.timer2.Interval = 60000;
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			this.timer2.Enabled  = false;
			// 
			// ctrlRRecipeList
			// 
			this.Name = "ctrlRRecipeList";

		}
		#endregion

		private bool RunRecipe(int index)
		{
			try
			{
				RemotableEventController.Controler.RemoteRecipeList.RunRecipe(index);
				return true;
			}
			catch(Exception ex)
			{
				RemotableEventController.ProcessFailToConnectToServices(ex);
				System.Windows.Forms.Application.Exit();
				return false;
			}
		}

		private bool StopRecipe(int index)
		{
			try
			{
				RemotableEventController.Controler.RemoteRecipeList.StopRecipe(index);
				return true;
			}
			catch(Exception ex)
			{
				RemotableEventController.ProcessFailToConnectToServices(ex);
				System.Windows.Forms.Application.Exit();
				return false;
			}
		}


		public override void Run()
		{
			if( !CheckRun()) return;

			Cursor.Current = Cursors.WaitCursor;
	
			bool runed = false;
			foreach(ListViewItem item in lvRecipeList.SelectedItems)
			{
				DDARecipe.DDARecipe recipe = item.Tag as DDARecipe.DDARecipe;

				if(!recipe.IsRunning && !recipe.WaitingToRun && !recipe.WaitingToStop)
				{
					RegisterRunRecipe(recipe);

					recipe.TextHistory.AddNewLine("Prepare running");
					UpdateStatus(recipe.ID,"Prepare running");
					recipe.WaitingToRun = true;

					//recipe.RunRecipe();
					//RemotableEventController.Controler.RemoteRecipeList.RunRecipe(item.Index);
					if(!this.RunRecipe(item.Index))
						return;

					UpdateStatusCurrentRecipe();
					
					runed = true;
				}
			}
			if(runed)
				SetRunning();

		}


		public override void Stop()
		{
			Cursor.Current = Cursors.WaitCursor;

			bool stoped = false;

			foreach(ListViewItem item in lvRecipeList.SelectedItems)
			{
				DDARecipe.DDARecipe recipe = item.Tag as DDARecipe.DDARecipe;
				if(recipe.IsRunning && !recipe.WaitingToRun && !recipe.WaitingToStop)
				{
					recipe.TextHistory.AddNewLine("Prepare stop");
					UpdateStatus(recipe.ID,"Prepare stop");
					recipe.WaitingToStop = true;
	
					//RemotableEventController.Controler.RemoteRecipeList.StopRecipe(item.Index);
					if(!this.StopRecipe(item.Index))
						return;

					stoped = true;
				}
			}

			if(stoped)
				SetStop();
		}

		public override void LoadRecipeList()
		{
			Cursor.Current = Cursors.WaitCursor;

			//Load Recipe List from datasbase
			base.LoadRecipeList ();

			UpdateRecipeFromListView();

			//Load recipe status
			DDARecipeRObjects.RecipeListEvent e =
				RemotableEventController.Controler.RemoteRecipeList.RequireRecipeList();
						
			//RemotableEventController.Controler.RecipeList.Clear();
			foreach(ListViewItem item in lvRecipeList.Items)
			{
				DDARecipe.DDARecipe recipe = item.Tag as DDARecipe.DDARecipe;
				//RemotableEventController.Controler.RecipeList.Add(recipe);

				//update status to GUI
				if(e.RecipeRunningStatus!=null && e.RecipeRunningStatus.Contains(recipe.ID))
				{
					recipe.IsRunning = true;

					RegisterRunRecipe(recipe);

					//Update message
					recipe.TextHistory.AddNewLine("running");
					UpdateStatus(recipe.ID,"running");
				}
			}

			if(e.RecipeRunningStatus!=null && e.RecipeRunningStatus.Count>0)
				UpdateStatusCurrentRecipe();

			//isSave=false;
			HandleStateChange();
		}

		public override void RunAll()
		{
			if( !CheckRunAll())
				return;

			Cursor.Current = Cursors.WaitCursor;

			bool runed = false;

			foreach(ListViewItem item in lvRecipeList.Items)
			{
				DDARecipe.DDARecipe recipe = item.Tag as DDARecipe.DDARecipe;
				if(!recipe.IsRunning && !recipe.WaitingToRun && !recipe.WaitingToStop)
				{
					RegisterRunRecipe(recipe);

					recipe.TextHistory.AddNewLine("Prepare running");
					UpdateStatus(recipe.ID,"Prepare running");
					recipe.WaitingToRun = true;

					//recipe.RunRecipe();
					//RemotableEventController.Controler.RemoteRecipeList.RunRecipe(item.Index);
					if(!this.RunRecipe(item.Index))
						return;

					runed = true;
				}
			}

			UpdateStatusCurrentRecipe();

			if(runed)
				SetRunning();
		}

		public override void StopAll()
		{
			Cursor.Current = Cursors.WaitCursor;

			bool stoped = false;

			foreach(ListViewItem item in lvRecipeList.Items)
			{
				DDARecipe.DDARecipe recipe = item.Tag as DDARecipe.DDARecipe;
				if(recipe.IsRunning && !recipe.WaitingToRun && !recipe.WaitingToStop)
				{
					recipe.TextHistory.AddNewLine("Prepare stop");
					UpdateStatus(recipe.ID,"Prepare stop");
					recipe.WaitingToStop = true;

					//RemotableEventController.Controler.RemoteRecipeList.StopRecipe(item.Index);
					if(!this.StopRecipe(item.Index))
						return;

					stoped = true;
				}
			}

			if(stoped)
				SetStop();
		}


		public override bool NewRecipe()
		{
			if(base.NewRecipe ())
			{
				UpdateRecipeFromListView();
				RemotableEventController.Controler.RemoteRecipeList.RefreshRecipeList();
			}
			return true;
		}

		public override bool DeleteRecipe()
		{
			if(base.DeleteRecipe ())
			{
				UpdateRecipeFromListView();
				RemotableEventController.Controler.RemoteRecipeList.RefreshRecipeList();
			}	
			return true;
		}

		public override bool EditRecipe()
		{
			if(base.EditRecipe ())
			{
				RemotableEventController.Controler.RemoteRecipeList.RefreshRecipeList();
			}
			return true;
		}

		public override bool EditTesterType()
		{
			if(base.EditTesterType ())
			{
				RemotableEventController.Controler.RemoteRecipeList.RefreshRecipeList();
			}
			return true;
		}

		public override bool DeleteAll()
		{
			if(base.DeleteAll ())
			{
				UpdateRecipeFromListView();
				RemotableEventController.Controler.RemoteRecipeList.RefreshRecipeList();
			}
			return true;
		}

		public override void Import(ArrayList SignatureList, ArrayList RecipeList)
		{
			if(SignatureList==null || RecipeList==null) return;

			try
			{
				InitService();

				Hashtable htSignature = new Hashtable();
				Hashtable htRecipe = new Hashtable();

				//Import Signature
				foreach (SiGlaz.Common.DDA.Signature sig in SignatureList)
				{
					int oldSigKey = sig.SCKey;

					long newSignatureKey = InsertSingature(sig);

					if (!htSignature.Contains(oldSigKey))
						htSignature.Add(oldSigKey, newSignatureKey);
				}

				//Import Recipe
				foreach (DDARecipe.DDARecipe recipe in RecipeList)
				{
					recipe.SignatureID = Convert.ToInt32(htSignature[recipe.SignatureID]);

					int oldrecipeid = recipe.ID;
					recipe.ID = (int)InsertRecipe(recipe);

					if (!htRecipe.ContainsKey(oldrecipeid))
						htRecipe.Add(oldrecipeid,recipe.ID);
				}

				//Update Prev Recipe
				foreach (DDARecipe.DDARecipe recipe in RecipeList)
				{
					if(htRecipe.ContainsKey(recipe.PrevRecipeID))
						recipe.PrevRecipeID = (int)htRecipe[recipe.PrevRecipeID];

					UpdateRecipe(recipe);
				}

				RemotableEventController.Controler.RemoteRecipeList.RefreshRecipeList();

				LoadRecipeList();

				MessageBox.Show("Recipe file has been imported successfully.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (System.Exception e)
			{
				MessageBox.Show(e.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void UpdateRecipeFromListView()
		{
			RemotableEventController.Controler.RecipeList.Clear();
			foreach(ListViewItem item in lvRecipeList.Items)
			{
				DDARecipe.DDARecipe recipe = item.Tag as DDARecipe.DDARecipe;
				RemotableEventController.Controler.RecipeList.Add(recipe);
			}
		}

		private void SetRunning()
		{
			timer1.Enabled = true;
		}

		private void ResetRuning()
		{
			timer1.Enabled = false;

			foreach(ListViewItem item in lvRecipeList.Items)
			{
				DDARecipe.DDARecipe recipe = item.Tag as DDARecipe.DDARecipe;
				if(recipe.WaitingToRun)
				{
					recipe.WaitingToRun = false;
					recipe.IsRunning = false;
					RemotableEventController.Controler.RemoteRecipeList.SetStopStatus(item.Index);

					recipe.TextHistory.AddNewLine("Cannot run recipe(s) because connecting to service or database fails");
					UpdateStatus(recipe.ID,"cannot run recipe");
				}
			}

			UpdateCommandGUI();
			HandleStateChange();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			ResetRuning();
		}

		private void SetStop()
		{
			timer2.Enabled = true;
			//System.Diagnostics.Debug.WriteLine("SetStop");
		}

		private void ResetStop()
		{
			timer2.Enabled = false;

			foreach(ListViewItem item in lvRecipeList.Items)
			{
				DDARecipe.DDARecipe recipe = item.Tag as DDARecipe.DDARecipe;
				if(recipe.WaitingToStop)
				{
					recipe.WaitingToStop = false;
					recipe.IsRunning = true;
					RemotableEventController.Controler.RemoteRecipeList.SetStartStatus(item.Index);

					recipe.TextHistory.AddNewLine("cannot stop recipe because cannot connect to service or database");
					UpdateStatus(recipe.ID,"cannot stop recipe");
				}
			}

			UpdateCommandGUI();
			HandleStateChange();
		}

		private void timer2_Tick(object sender, System.EventArgs e)
		{
			ResetStop();
		}

		public override void recipe_OnStart(SiGlaz.Recipes.RecipeEventArgs e)
		{
            if (InvokeRequired)
                Invoke( (MethodInvoker)delegate() { HandleRecipe_OnStart(e); });
            else
                HandleRecipe_OnStart(e);

			base.recipe_OnStart (e);
		}

        private void HandleRecipe_OnStart(SiGlaz.Recipes.RecipeEventArgs e)
        {
            bool needTimer = false;
            foreach (ListViewItem item in lvRecipeList.Items)
            {
                DDARecipe.DDARecipe recipe = item.Tag as DDARecipe.DDARecipe;
                if (recipe.WaitingToRun)
                {
                    needTimer = true;
                    break;
                }
            }
            if (!needTimer)
                timer1.Enabled = false;
        }


		public override void recipe_OnStop(SiGlaz.Recipes.RecipeEventArgs e)
		{
            if (InvokeRequired)
                Invoke((MethodInvoker)delegate() { HandleRecipe_OnStop(e); });
            else
                HandleRecipe_OnStop(e);

            base.recipe_OnStop (e);
		}

        private void HandleRecipe_OnStop(SiGlaz.Recipes.RecipeEventArgs e)
        {
            bool needTimer = false;
            foreach (ListViewItem item in lvRecipeList.Items)
            {
                DDARecipe.DDARecipe recipe = item.Tag as DDARecipe.DDARecipe;
                if (recipe.WaitingToStop)
                {
                    needTimer = true;
                    break;
                }
            }
            if (!needTimer)
                timer2.Enabled = false;
        }





	}
}
