using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using DDARMWinUI.Dialogs;
using SiGlaz.Common.DDA;


namespace DDARMWinUI.Controls
{
	public class ctrlRecipeList : System.Windows.Forms.UserControl
	{
		#region Members
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ListView lvRecipeList;
		private System.Windows.Forms.ColumnHeader colID;
		private System.Windows.Forms.ColumnHeader colRecipeName;
		private System.Windows.Forms.ColumnHeader colSignature;
		private System.Windows.Forms.ColumnHeader colDescription;
		private System.Windows.Forms.ContextMenu ctmRecipeList;
		private System.Windows.Forms.MenuItem mnuItemNew;
		private System.Windows.Forms.MenuItem mnuItemEdit;
		private System.Windows.Forms.MenuItem mnuItemDelete;
		private System.Windows.Forms.ImageList _imgListToolBar;
		private System.Windows.Forms.ImageList _imgListListView;
		private System.Windows.Forms.ColumnHeader colStatus;
		private System.Windows.Forms.Panel pBottom;
		private System.Windows.Forms.Panel pClient;
		private DDARMWinUI.Controls.ctrlDebugResult ctrlDebugResult1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.ColumnHeader colPreviousRecipe;
		private Hashtable		htListItem = new Hashtable();
		//public bool isSave =false;
		private WebServiceProxy.CategoryProxy.Category _sigService = null;
		private System.Windows.Forms.ColumnHeader colTesterType;
		private System.Windows.Forms.ColumnHeader colBreak;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem miEDITTESTERTYPE;
		private SiGlaz.DDA.Business.Category _sigService1 = null;
		#endregion
		
		#region Contructor & Destructor
		public ctrlRecipeList()
		{
			InitializeComponent();
		}

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
		
		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ctrlRecipeList));
			this.lvRecipeList = new System.Windows.Forms.ListView();
			this.colID = new System.Windows.Forms.ColumnHeader();
			this.colRecipeName = new System.Windows.Forms.ColumnHeader();
			this.colSignature = new System.Windows.Forms.ColumnHeader();
			this.colPreviousRecipe = new System.Windows.Forms.ColumnHeader();
			this.colStatus = new System.Windows.Forms.ColumnHeader();
			this.colBreak = new System.Windows.Forms.ColumnHeader();
			this.colTesterType = new System.Windows.Forms.ColumnHeader();
			this.colDescription = new System.Windows.Forms.ColumnHeader();
			this.ctmRecipeList = new System.Windows.Forms.ContextMenu();
			this.mnuItemNew = new System.Windows.Forms.MenuItem();
			this.mnuItemEdit = new System.Windows.Forms.MenuItem();
			this.mnuItemDelete = new System.Windows.Forms.MenuItem();
			this._imgListToolBar = new System.Windows.Forms.ImageList(this.components);
			this.ctrlDebugResult1 = new DDARMWinUI.Controls.ctrlDebugResult();
			this._imgListListView = new System.Windows.Forms.ImageList(this.components);
			this.pBottom = new System.Windows.Forms.Panel();
			this.pClient = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.miEDITTESTERTYPE = new System.Windows.Forms.MenuItem();
			this.pBottom.SuspendLayout();
			this.pClient.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvRecipeList
			// 
			this.lvRecipeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.colID,
																						   this.colRecipeName,
																						   this.colSignature,
																						   this.colPreviousRecipe,
																						   this.colStatus,
																						   this.colBreak,
																						   this.colTesterType,
																						   this.colDescription});
			this.lvRecipeList.ContextMenu = this.ctmRecipeList;
			this.lvRecipeList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvRecipeList.FullRowSelect = true;
			this.lvRecipeList.GridLines = true;
			this.lvRecipeList.HideSelection = false;
			this.lvRecipeList.Location = new System.Drawing.Point(0, 0);
			this.lvRecipeList.Name = "lvRecipeList";
			this.lvRecipeList.Size = new System.Drawing.Size(912, 300);
			this.lvRecipeList.TabIndex = 0;
			this.lvRecipeList.View = System.Windows.Forms.View.Details;
			this.lvRecipeList.DoubleClick += new System.EventHandler(this.lvRecipeList_DoubleClick);
			this.lvRecipeList.SelectedIndexChanged += new System.EventHandler(this.lvRecipeList_SelectedIndexChanged);
			// 
			// colID
			// 
			this.colID.Text = "ID";
			this.colID.Width = 33;
			// 
			// colRecipeName
			// 
			this.colRecipeName.Text = "Recipe Name";
			this.colRecipeName.Width = 123;
			// 
			// colSignature
			// 
			this.colSignature.Text = "Signature";
			this.colSignature.Width = 117;
			// 
			// colPreviousRecipe
			// 
			this.colPreviousRecipe.Text = "Previous Recipe";
			this.colPreviousRecipe.Width = 131;
			// 
			// colStatus
			// 
			this.colStatus.Text = "Status";
			this.colStatus.Width = 154;
			// 
			// colBreak
			// 
			this.colBreak.Text = "Break";
			// 
			// colTesterType
			// 
			this.colTesterType.Text = "Tester Type";
			this.colTesterType.Width = 100;
			// 
			// colDescription
			// 
			this.colDescription.Text = "Description";
			this.colDescription.Width = 329;
			// 
			// ctmRecipeList
			// 
			this.ctmRecipeList.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						  this.mnuItemNew,
																						  this.mnuItemEdit,
																						  this.mnuItemDelete,
																						  this.menuItem1,
																						  this.miEDITTESTERTYPE});
			this.ctmRecipeList.Popup += new System.EventHandler(this.ctmRecipeList_Popup);
			// 
			// mnuItemNew
			// 
			this.mnuItemNew.Index = 0;
			this.mnuItemNew.OwnerDraw = true;
			this.mnuItemNew.Text = "New";
			this.mnuItemNew.Click += new System.EventHandler(this.mnuItem_Click);
			// 
			// mnuItemEdit
			// 
			this.mnuItemEdit.Index = 1;
			this.mnuItemEdit.OwnerDraw = true;
			this.mnuItemEdit.Text = "Edit";
			this.mnuItemEdit.Click += new System.EventHandler(this.mnuItem_Click);
			// 
			// mnuItemDelete
			// 
			this.mnuItemDelete.Index = 2;
			this.mnuItemDelete.OwnerDraw = true;
			this.mnuItemDelete.Text = "Delete";
			this.mnuItemDelete.Click += new System.EventHandler(this.mnuItem_Click);
			// 
			// _menuEx
			// 
			// 
			// _imgListToolBar
			// 
			this._imgListToolBar.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this._imgListToolBar.ImageSize = new System.Drawing.Size(16, 16);
			this._imgListToolBar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imgListToolBar.ImageStream")));
			this._imgListToolBar.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// ctrlDebugResult1
			// 
			this.ctrlDebugResult1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ctrlDebugResult1.Location = new System.Drawing.Point(0, 0);
			this.ctrlDebugResult1.Name = "ctrlDebugResult1";
			this.ctrlDebugResult1.Recipe = null;
			this.ctrlDebugResult1.Size = new System.Drawing.Size(912, 180);
			this.ctrlDebugResult1.TabIndex = 0;
			// 
			// _imgListListView
			// 
			this._imgListListView.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this._imgListListView.ImageSize = new System.Drawing.Size(16, 16);
			this._imgListListView.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// pBottom
			// 
			this.pBottom.Controls.Add(this.ctrlDebugResult1);
			this.pBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pBottom.Location = new System.Drawing.Point(0, 300);
			this.pBottom.Name = "pBottom";
			this.pBottom.Size = new System.Drawing.Size(912, 180);
			this.pBottom.TabIndex = 1;
			// 
			// pClient
			// 
			this.pClient.Controls.Add(this.lvRecipeList);
			this.pClient.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pClient.Location = new System.Drawing.Point(0, 0);
			this.pClient.Name = "pClient";
			this.pClient.Size = new System.Drawing.Size(912, 300);
			this.pClient.TabIndex = 2;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.Location = new System.Drawing.Point(0, 297);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(912, 3);
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 3;
			this.menuItem1.Text = "-";
			// 
			// miEDITTESTERTYPE
			// 
			this.miEDITTESTERTYPE.Index = 4;
			this.miEDITTESTERTYPE.Text = "Edit Tester Type";
			this.miEDITTESTERTYPE.Click += new System.EventHandler(this.mnuItem_Click);
			// 
			// ctrlRecipeList
			// 
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.pClient);
			this.Controls.Add(this.pBottom);
			this.Name = "ctrlRecipeList";
			this.Size = new System.Drawing.Size(912, 480);
			this.pBottom.ResumeLayout(false);
			this.pClient.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region events
		public	event	EventHandler			OnStateChange;

		public void HandleStateChange()
		{
			if(OnStateChange!=null)
			{
				OnStateChange(null,EventArgs.Empty);
			}
		}

		#endregion events

		#region UI Command

		private void UpdateRecipeToListView(DDARecipe.DDARecipe recipe,int index)
		{
			this.lvRecipeList.Items[index].SubItems[1].Text = recipe.Name;
			this.lvRecipeList.Items[index].SubItems[2].Text = recipe.SignatureName;
			this.lvRecipeList.Items[index].SubItems[3].Text = recipe.PrevRecipeName;

			this.lvRecipeList.Items[index].SubItems[7].Text = recipe.Description;
			this.lvRecipeList.Items[index].SubItems[6].Text = recipe.TesterType;
			this.lvRecipeList.Items[index].SubItems[5].Text = recipe.BreakWhenFound.ToString();
		}

		private void AddRecipeToListView(DDARecipe.DDARecipe recipe)
		{
			ListViewItem item = new ListViewItem(recipe.ID.ToString());

			item.SubItems.Add(recipe.Name);
			item.SubItems.Add(recipe.SignatureName);
			item.SubItems.Add(recipe.PrevRecipeName);
			

			ListViewItem.ListViewSubItem msgitem = item.SubItems.Add( string.Empty);
			item.Tag = recipe;
			lvRecipeList.Items.Add(item);
			htListItem.Add( recipe.ID,msgitem);

			item.SubItems.Add(recipe.BreakWhenFound.ToString());

			item.SubItems.Add(recipe.TesterType);

			item.SubItems.Add(recipe.Description);

			recipe.ShowProcessStep = (bool)SiGlaz.Common.Configuration.GetValues("SHOW_PROCESS_STEP",false);
		}

		public virtual void LoadRecipeList()
		{
			lvRecipeList.Items.Clear();
			htListItem.Clear();

			if(AppData.Data.UseWebService)
			{
				try
				{
					WebServiceProxy.RecipeProxy.Recipe proxy  = WebServiceProxy.WebProxyFactory.CreateRecipe();
					if(proxy==null)
						return;

					WebServiceProxy.RecipeProxy.RecipeListResult _recipeCollection = proxy.RecipeList();
					if (_recipeCollection != null && _recipeCollection.Recipes != null && _recipeCollection.Recipes.Length > 0)
					{
						foreach (WebServiceProxy.RecipeProxy.DDARecipe recipe in _recipeCollection.Recipes)
						{
							DDARecipe.DDARecipe obj = new DDARecipe.DDARecipe();
							WebServiceProxy.RecipeProxy.BinaryResult result = proxy.GetRawData(recipe.RecipeKey);
							if(result.Result!=null)
								recipe.RawData = result.Result;

							obj.CommonStruct = WebServiceProxy.ConvertProxy.Convert( recipe, typeof(SiGlaz.Common.DDA.DDARecipe) ) as SiGlaz.Common.DDA.DDARecipe;
							AddRecipeToListView(obj);
						}
					}

					proxy.Dispose();
					proxy = null;
				}
				catch (System.Exception e)
				{
					MessageBox.Show(e.Message, Application.ProductName , MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				try
				{
					SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
					SiGlaz.Common.DDA.Result.RecipeListResult _recipeCollection = proxy.RecipeList();
					if (_recipeCollection != null && _recipeCollection.Recipes != null && _recipeCollection.Recipes.Count > 0)
					{
						foreach (SiGlaz.Common.DDA.DDARecipe recipe in _recipeCollection.Recipes)
						{
							DDARecipe.DDARecipe obj = new DDARecipe.DDARecipe();
							SiGlaz.Common.DDA.Result.BinaryResult result = proxy.GetRawData(recipe.RecipeKey);
							if(result.Result!=null)
								recipe.RawData = result.Result;
							obj.CommonStruct = recipe;
							AddRecipeToListView(obj);
						}
					}
					proxy = null;
				}
				catch (System.Exception e)
				{
					MessageBox.Show(e.Message, Application.ProductName , MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			//isSave=false;
			HandleStateChange();
		}

		private void ExecuteCmd(string cmd)
		{
			Cursor.Current = Cursors.WaitCursor;
			switch (cmd)
			{
				case "New":
					NewRecipe();
					break;
				case "Edit":
					EditRecipe();
					break;
				case "Delete":
					DeleteRecipe();
					break;
				case "Edit Tester Type":
					EditTesterType();
					break;
			}
		}

		public virtual bool NewRecipe()
		{
			//_recipeCollection
			DDARecipe.DDARecipe newrecipe = DDARecipe.DDARecipe.CreateNew(-1);
			DlgRecipeProperties dlg = new DlgRecipeProperties(newrecipe,this.RecipeList);
			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				Cursor.Current = Cursors.WaitCursor;
				this.ParentForm.Refresh();

				this.AddRecipeToListView(dlg.Recipe);
				return true;
			}
			return false;
		}

		public virtual bool EditRecipe()
		{
			if (lvRecipeList.SelectedItems.Count > 0)
			{
				Cursor.Current = Cursors.WaitCursor;
				this.ParentForm.Refresh();

				DDARecipe.DDARecipe recipe =  lvRecipeList.SelectedItems[0].Tag as DDARecipe.DDARecipe;

				recipe.ReadOnly = this.ReadOnly(recipe);
				if(recipe.ReadOnly)
					MessageBox.Show("This Recipe can be read only cause by being processed or edited by different application.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);

				this.UpdateStatus( recipe, SiGlaz.Common.DDA.eRecipeStatus.Edited);

				DlgRecipeProperties dlg = new DlgRecipeProperties(recipe,this.RecipeList);
				if (dlg.ShowDialog(this) == DialogResult.OK)
				{
					Cursor.Current = Cursors.WaitCursor;
					this.ParentForm.Refresh();

					if(!recipe.ReadOnly)
					{
						this.UpdateRecipeToListView(dlg.Recipe,lvRecipeList.SelectedItems[0].Index);
						return true;
					}
				}

				this.UpdateStatus( recipe, SiGlaz.Common.DDA.eRecipeStatus.Normal);
			}
			else
				MessageBox.Show("Please select at least one item.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

			return false;
		}

		public virtual bool EditTesterType()
		{
			if (lvRecipeList.SelectedItems.Count > 0)
			{
				Cursor.Current = Cursors.WaitCursor;
				this.ParentForm.Refresh();

				//Check
				foreach(ListViewItem item in lvRecipeList.SelectedItems)
				{
					DDARecipe.DDARecipe recipe =  item.Tag as DDARecipe.DDARecipe;
					if(this.ReadOnly(recipe))
					{
						MessageBox.Show("This Recipe can be read only cause by being processed or edited by different application.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return false;
					}
				}

				//get input
				DlgImportDDAJobs dlgImport = new DlgImportDDAJobs();
				dlgImport.DisplayTesterTypeList();

				if( dlgImport.ShowDialog(this) == DialogResult.OK)
				{
					Cursor.Current = Cursors.WaitCursor;
					this.ParentForm.Refresh();

					//Update data
					foreach(ListViewItem item in lvRecipeList.SelectedItems)
					{
						DDARecipe.DDARecipe recipe =  item.Tag as DDARecipe.DDARecipe;
						recipe.TesterType = dlgImport.TesterType;
	
						try
						{
							if(SiGlaz.Common.DDA.AppData.Data.UseWebService)
							{
								WebServiceProxy.RecipeProxy.Recipe proxy = WebServiceProxy.WebProxyFactory.CreateRecipe();
								SiGlaz.Common.DDA.DDARecipe obj = recipe.CommonStruct;
								WebServiceProxy.RecipeProxy.DDARecipe xx = WebServiceProxy.ConvertProxy.Convert( obj,  typeof( WebServiceProxy.RecipeProxy.DDARecipe ) ) as WebServiceProxy.RecipeProxy.DDARecipe;
								WebServiceProxy.RecipeProxy.ResultBase result = proxy.InsertRecipe(xx);
								recipe.ID = result.id32;
							}
							else
							{
								SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
								SiGlaz.Common.DDA.DDARecipe obj = recipe.CommonStruct;
								SiGlaz.Common.DDA.Result.ResultBase result = proxy.InsertRecipe(obj);
								recipe.ID = result.id32;
							}
						}
						catch
						{
							MessageBox.Show("Cannot save this recipe.",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);
							return false;
						}

						this.UpdateRecipeToListView(recipe,item.Index);
					}
				}
			}
			else
				MessageBox.Show("Please select at least one item.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

			return false;
		}


		public virtual bool DeleteRecipe()
		{
			if(lvRecipeList.SelectedItems.Count <= 0) return false;

			// Ask here  ...
			if(MessageBox.Show("Do you want to delete selected recipe(s)?",Application.ProductName ,MessageBoxButtons.YesNo,MessageBoxIcon.Question)!= DialogResult.Yes)
				return false;

			Cursor.Current = Cursors.WaitCursor;
			this.ParentForm.Refresh();

			//Check Delete here 
			if(!CanDelete()) return false;

			//Delete on list view
			for(int i=0;i<lvRecipeList.Items.Count;i++)
			{
				if(lvRecipeList.Items[i].Selected)
				{
					int recipekey  = (lvRecipeList.Items[i].Tag as DDARecipe.DDARecipe).ID;
					this.Delete(recipekey);//delete on database

					if( htListItem.ContainsKey(recipekey))
						htListItem.Remove(recipekey);
					lvRecipeList.Items.RemoveAt(i--);
				}
			}

			//isSave=true;

			return true;
		}

		public void UpdateStatus(DDARecipe.DDARecipe recipe,SiGlaz.Common.DDA.eRecipeStatus status)
		{
			if(SiGlaz.Common.DDA.AppData.Data.UseWebService)
			{
				WebServiceProxy.RecipeProxy.Recipe proxy = WebServiceProxy.WebProxyFactory.CreateRecipe();
				proxy.UpdateStatus(recipe.ID,(WebServiceProxy.RecipeProxy.eRecipeStatus)status);
			}
			else
			{
				SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
				proxy.UpdateStatus(recipe.ID,status);
			}
		}

		public bool ReadOnly(DDARecipe.DDARecipe recipe)
		{
			if(SiGlaz.Common.DDA.AppData.Data.UseWebService)
			{
				WebServiceProxy.RecipeProxy.Recipe proxy = WebServiceProxy.WebProxyFactory.CreateRecipe();
				return proxy.GetStatus( recipe.ID) != WebServiceProxy.RecipeProxy.eRecipeStatus.Normal;
			}
			else
			{
				SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
				return proxy.GetStatus( recipe.ID) != SiGlaz.Common.DDA.eRecipeStatus.Normal;
			}
		}

		public bool RecipeIsEdited(DDARecipe.DDARecipe recipe)
		{
			if(SiGlaz.Common.DDA.AppData.Data.UseWebService)
			{
				WebServiceProxy.RecipeProxy.Recipe proxy = WebServiceProxy.WebProxyFactory.CreateRecipe();
				return proxy.RecipeIsEdited(recipe.ID);
			}
			else
			{
				SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
				return proxy.RecipeIsEdited(recipe.ID);
			}
		}

		public bool CanDelete()
		{
			bool result = false;
			if(SiGlaz.Common.DDA.AppData.Data.UseWebService)
			{
				WebServiceProxy.RecipeProxy.Recipe proxy = WebServiceProxy.WebProxyFactory.CreateRecipe();
				result = proxy.CanDelete();
			}
			else
			{
				SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
				result =  proxy.CanDelete();
			}

			if(!result)
				MessageBox.Show("This Recipe can not be processed cause by being processed or edited by different application.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);

			return result;
		}

		public void Delete(long recipekey)
		{
			if(SiGlaz.Common.DDA.AppData.Data.UseWebService)
			{
				WebServiceProxy.RecipeProxy.Recipe proxy = WebServiceProxy.WebProxyFactory.CreateRecipe();
				proxy.DeleteRecipe(recipekey);
			}
			else
			{
				SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
				proxy.DeleteRecipe(recipekey);
			}
		}

		public virtual bool DeleteAll()
		{
			if(MessageBox.Show("Do you want to delete all recipes?",Application.ProductName,MessageBoxButtons.YesNo,MessageBoxIcon.Question)!= DialogResult.Yes)
				return false;

			//Check Delete here 
			if(!CanDelete()) return false;

			//Delete on list view
			for(int i=0;i<lvRecipeList.Items.Count;i++)
			{
				int recipekey  = (lvRecipeList.Items[i].Tag as DDARecipe.DDARecipe).ID;
				this.Delete(recipekey);//delete on database
			}

            //Delete on listview
			lvRecipeList.Items.Clear();
			htListItem.Clear();
			//isSave=true;

			return true;
		}

		public bool CheckRun()
		{
			string recipelist = string.Empty;
			foreach(ListViewItem item in lvRecipeList.SelectedItems)
			{
				DDARecipe.DDARecipe recipe = item.Tag as DDARecipe.DDARecipe;
				if(this.RecipeIsEdited(recipe) )
					recipelist+= "," + recipe.Name;
			}
			if(recipelist!=string.Empty)
			{
				recipelist = recipelist.Substring(1);
				MessageBox.Show("Recipes : " + recipelist + " can not be processed cause by being edited by different application", Application.ProductName , MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return false;
			}
			return true;
		}


		public virtual void Run()
		{
			if( !CheckRun()) return;

			foreach(ListViewItem item in lvRecipeList.SelectedItems)
			{
				DDARecipe.DDARecipe recipe = item.Tag as DDARecipe.DDARecipe;
				if(!recipe.IsRunning)
				{
					RegisterRunRecipe(recipe);
					recipe.RunRecipe();
					UpdateStatusCurrentRecipe();

					//this.UpdateRunningStatus(recipe,SiGlaz.Common.DDA.AppData.Data.FabKey,SiGlaz.Common.DDA.eRecipeStatus.Running);

					//update 2008-06-17 by Cang
					recipe.IsRunning = true;//cap nhat ngay lap tuc tinh trang chay
					recipe.TextHistory.AddNewLine("Prepare running");
				}
			}
		}

		public virtual void Stop()
		{
			foreach(ListViewItem item in lvRecipeList.SelectedItems)
			{
				DDARecipe.DDARecipe recipe = item.Tag as DDARecipe.DDARecipe;
				if(recipe.IsRunning)
				{
					recipe.Stop();

					//this.UpdateRunningStatus(recipe,SiGlaz.Common.DDA.AppData.Data.FabKey,SiGlaz.Common.DDA.eRecipeStatus.Normal);
					//UnregisterStopRecipe(recipe);
				}
			}
		}


		public bool CheckRunAll()
		{
			string recipelist = string.Empty;
			foreach(ListViewItem item in lvRecipeList.Items)
			{
				DDARecipe.DDARecipe recipe = item.Tag as DDARecipe.DDARecipe;
				if( this.RecipeIsEdited(recipe) )
					recipelist+= "," + recipe.Name;
			}
			if(recipelist!=string.Empty)
			{
				recipelist = recipelist.Substring(1);
				MessageBox.Show("Recipes :" + recipelist + " can not be processed cause by being edited by different application", Application.ProductName , MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return false;
			}
			return true;
		}

		public virtual void RunAll()
		{
			if( !CheckRunAll())
				return;

			foreach(ListViewItem item in lvRecipeList.Items)
			{
				DDARecipe.DDARecipe recipe = item.Tag as DDARecipe.DDARecipe;
				if(!recipe.IsRunning && recipe.send==null)
				{
					RegisterRunRecipe(recipe);
					recipe.RunRecipe();
					UpdateStatusCurrentRecipe();

					//this.UpdateRunningStatus(recipe,SiGlaz.Common.DDA.AppData.Data.FabKey,SiGlaz.Common.DDA.eRecipeStatus.Running);

					//update 2008-06-17 by Cang
					recipe.IsRunning = true;//cap nhat ngay lap tuc tinh trang chay
					recipe.TextHistory.AddNewLine("Prepare running");
				}
			}
		}


		public virtual void StopAll()
		{
			foreach(ListViewItem item in lvRecipeList.Items)
			{
				DDARecipe.DDARecipe recipe = item.Tag as DDARecipe.DDARecipe;
				if(recipe.IsRunning && recipe.send!=null)
				{
					recipe.Stop();

					//this.UpdateRunningStatus(recipe,SiGlaz.Common.DDA.AppData.Data.FabKey,SiGlaz.Common.DDA.eRecipeStatus.Normal);
					//UnregisterStopRecipe(recipe);
				}
			}
		}

		public void ShowProcessStep(bool show)
		{
			foreach(ListViewItem item in lvRecipeList.Items)
			{
				DDARecipe.DDARecipe recipe = item.Tag as DDARecipe.DDARecipe;
				recipe.ShowProcessStep = show;
			}
		}

		public ArrayList RecipeList
		{
			get
			{
				ArrayList alRecipes = new ArrayList();
				foreach(ListViewItem item in lvRecipeList.Items)
				{
					alRecipes.Add(item.Tag as DDARecipe.DDARecipe);
				}
				return alRecipes;
			}
		}

		public ArrayList SelectedRecipeList
		{
			get
			{
				ArrayList alRecipes = new ArrayList();
				foreach(ListViewItem item in lvRecipeList.SelectedItems)
				{
					alRecipes.Add(item.Tag as DDARecipe.DDARecipe);
				}
				return alRecipes;
			}
		}

		public void UpdateStatusCurrentRecipe()
		{
			if(lvRecipeList.SelectedItems.Count <= 0) return;

			DDARecipe.DDARecipe recipe =  lvRecipeList.SelectedItems[0].Tag as DDARecipe.DDARecipe;
			if(recipe!=null)
			{
				ctrlDebugResult1.Recipe = recipe;
				ctrlDebugResult1.ScrollToBottom();
			}
		}

		protected long InsertSingature(SiGlaz.Common.DDA.Signature sig)
		{
			WebServiceProxy.CategoryCmd cmd = new WebServiceProxy.CategoryCmd();
			return cmd.SignatureInsert(sig,true,false);
		}

		protected int InsertRecipe(DDARecipe.DDARecipe recipe)
		{
			try
			{
				if( AppData.Data.UseWebService)
				{
					WebServiceProxy.RecipeProxy.Recipe _recipeService = WebServiceProxy.WebProxyFactory.CreateRecipe();
					SiGlaz.Common.DDA.DDARecipe obj = recipe.CommonStruct;
					WebServiceProxy.RecipeProxy.DDARecipe xx = WebServiceProxy.ConvertProxy.Convert( obj,  typeof( WebServiceProxy.RecipeProxy.DDARecipe ) ) as WebServiceProxy.RecipeProxy.DDARecipe;

					WebServiceProxy.RecipeProxy.ResultBase result = _recipeService.InsertRecipeForce(xx);
					return result.id32;
				}
				else
				{
					SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
					SiGlaz.Common.DDA.DDARecipe obj = recipe.CommonStruct;

					SiGlaz.Common.DDA.Result.ResultBase result = proxy.InsertRecipeForce(obj);
					return result.id32;
				}
			}
			catch (System.Exception e)
			{
				MessageBox.Show(e.Message, Application.ProductName , MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return 0;
		}

		protected void UpdateRecipe(DDARecipe.DDARecipe recipe)
		{
			try
			{
				if( AppData.Data.UseWebService)
				{
					WebServiceProxy.RecipeProxy.Recipe _recipeService = WebServiceProxy.WebProxyFactory.CreateRecipe();
					SiGlaz.Common.DDA.DDARecipe obj = recipe.CommonStruct;
					WebServiceProxy.RecipeProxy.DDARecipe xx = WebServiceProxy.ConvertProxy.Convert( obj,  typeof( WebServiceProxy.RecipeProxy.DDARecipe ) ) as WebServiceProxy.RecipeProxy.DDARecipe;
					_recipeService.UpdateRecipe(xx);
				}
				else
				{
					SiGlaz.DDA.Business.Recipe proxy = new SiGlaz.DDA.Business.Recipe();
					SiGlaz.Common.DDA.DDARecipe obj = recipe.CommonStruct;
					proxy.UpdateRecipe(obj);
				}
			}
			catch (System.Exception e)
			{
				MessageBox.Show(e.Message, Application.ProductName , MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public virtual void Import(ArrayList SignatureList,ArrayList RecipeList)
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

				LoadRecipeList();

				MessageBox.Show("Recipe file has been imported successfully.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (System.Exception e)
			{
				MessageBox.Show(e.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}


		public void ImportDDAJobStep()
		{
			//if(!this.CanDelete()) return;

			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Title = "Import DDA Job Step";
			dlg.Filter = "DDA Job File (*.ddj)|*.ddj";

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				try
				{
					Cursor.Current = Cursors.WaitCursor;
					this.Refresh();

					DlgImportDDAJobs dlgImport = new DlgImportDDAJobs();
					dlgImport.DisplayTesterTypeList();

					if( dlgImport.ShowDialog(this) == DialogResult.OK)
					{
						DDARecipe.RecipeData recipeData = new DDARecipe.RecipeData();	

						recipeData.ImportDDAJobStep(dlg.FileName,dlgImport.TesterType);

						this.Import(recipeData.alSignature,recipeData.alRecipe);
					}
				}
				catch (System.Exception e)
				{
					MessageBox.Show(e.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		public void Import()
		{
			//if(!this.CanDelete()) return;

			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Title = "Import";
			dlg.Filter = "Recipe list file document (*.rel)|*.rel";

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				try
				{
					Cursor.Current = Cursors.WaitCursor;
					this.Refresh();

					DDARecipe.RecipeData recipeData = new DDARecipe.RecipeData();	
					recipeData.DeserializeBinary(dlg.FileName);

					this.Import(recipeData.alSignature,recipeData.alRecipe);
				}
				catch (System.Exception e)
				{
					MessageBox.Show(e.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);	
				}				
			}
		}

		private ArrayList GetRecipeList(bool isAllRecipes)
		{
			ArrayList alRecipe = new ArrayList();

			if (isAllRecipes)
			{
				foreach (ListViewItem item in lvRecipeList.Items)
					alRecipe.Add(item.Tag);
			}
			else
			{
				foreach (ListViewItem item in lvRecipeList.SelectedItems)
					alRecipe.Add(((DDARecipe.DDARecipe)item.Tag).Copy());

				for (int i = 0; i < alRecipe.Count; i++)
				{
					if (!CheckRecipeIDExist(alRecipe, ((DDARecipe.DDARecipe)alRecipe[i]).PrevRecipeID))
						((DDARecipe.DDARecipe)alRecipe[i]).PrevRecipeID = -1;
				}
			}

			return alRecipe;
		}

		private bool CheckRecipeIDExist(ArrayList alRecipe, int prevRecipeID)
		{
			foreach (DDARecipe.DDARecipe recipe in alRecipe)
			{
				if (recipe.ID == prevRecipeID)
					return true;
			}

			return false;
		}

		public void Export()
		{
			Cursor.Current = Cursors.WaitCursor;

			if (lvRecipeList.Items.Count > 0)
			{
				DlgExportRecipe dlgExportRecipe = new DlgExportRecipe();

				if (dlgExportRecipe.ShowDialog() == DialogResult.Cancel)
					return;

				if (!dlgExportRecipe.IsAllRecipes && lvRecipeList.SelectedItems.Count <= 0)
				{
					MessageBox.Show("Please select at least one recipe.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				SaveFileDialog dlg = new SaveFileDialog();
				dlg.Title = "Export";
				dlg.Filter = "Recipe list file document (*.rel)|*.rel";
			
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					try
					{
						Cursor.Current = Cursors.WaitCursor;
						ArrayList alSignature = GetSignatureList();

						if (alSignature != null && alSignature.Count > 0)
						{
							ArrayList alRecipe = GetRecipeList(dlgExportRecipe.IsAllRecipes);
							DDARecipe.RecipeData recipeData = new DDARecipe.RecipeData();							
							recipeData.alSignature = alSignature;
							recipeData.alRecipe = alRecipe;
							recipeData.SerializeBinary(dlg.FileName);
						}

						MessageBox.Show("Recipe list has been exported successfully.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch (System.Exception e)
					{
						MessageBox.Show(e.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);						
					}
				}
			}
		}

		protected void InitService()
		{
			if(AppData.Data.UseWebService)
				_sigService = WebServiceProxy.WebProxyFactory.CreateCategory();
			else
				_sigService1 = new SiGlaz.DDA.Business.Category();
		}

		public ArrayList GetSignatureList()
		{
			ArrayList alSignature = new ArrayList();
			InitService();

			if(AppData.Data.UseWebService)
			{
				if (_sigService != null)
				{
					try
					{
						WebServiceProxy.CategoryProxy.SignatureListResult _sigCollection = null;
						_sigCollection = _sigService.SignatureList();

						if (_sigCollection != null && _sigCollection.signature != null && _sigCollection.signature.Length > 0)
						{
							foreach(WebServiceProxy.CategoryProxy.Signature sig in _sigCollection.signature)
							{
								SiGlaz.Common.DDA.Signature sig1 = WebServiceProxy.ConvertProxy.Convert(sig,typeof(SiGlaz.Common.DDA.Signature)) as SiGlaz.Common.DDA.Signature;
								
								alSignature.Add(sig1);							
							}
						}
					}
					catch (System.Exception e)
					{
						MessageBox.Show(e.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			else
			{
				if (_sigService1 != null)
				{
					try
					{
						SiGlaz.Common.DDA.Result.SignatureListResult _sigCollection = null;
						_sigCollection = _sigService1.SignatureList();

						if (_sigCollection != null && _sigCollection.signature != null && _sigCollection.signature.Count > 0)
						{
							foreach(SiGlaz.Common.DDA.Signature sig in _sigCollection.signature)
								alSignature.Add(sig);
						}
					}
					catch (System.Exception e)
					{
						MessageBox.Show(e.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}

			return alSignature;
		}
		#endregion

		#region Windows Events Handles

		private void mnuItem_Click(object sender, System.EventArgs e)
		{
			ExecuteCmd(((MenuItem)sender).Text);
		}

		private void lvRecipeList_DoubleClick(object sender, System.EventArgs e)
		{
			if(lvRecipeList.SelectedItems.Count<=0) return;
			DDARecipe.DDARecipe recipe =  lvRecipeList.SelectedItems[0].Tag as DDARecipe.DDARecipe;
			if(recipe.IsRunning)
				return;
			else
				EditRecipe();
		}

		private void lvRecipeList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateStatusCurrentRecipe();
			HandleStateChange();
		}

		private void ctmRecipeList_Popup(object sender, System.EventArgs e)
		{
			UpdateCommandGUI();
		}

		private bool IsEditAndDelete(ArrayList recipes)
		{
			foreach(DDARecipe.DDARecipe recipe in recipes)
			{
				if(recipe.IsRunning)
					return false;
			}
			return recipes.Count>0;
		}

		private bool NoAnyRun(ArrayList recipes)
		{
			foreach(DDARecipe.DDARecipe recipe in recipes)
			{
				if(recipe.IsRunning)
					return false;
			}
			return true;
		}

		public void  UpdateCommandGUI()
		{
			//Get Recipe List
			ArrayList selectedRecipeList = this.SelectedRecipeList;
			mnuItemNew.Enabled = NoAnyRun(RecipeList);
			mnuItemEdit.Enabled = this.IsEditAndDelete(selectedRecipeList);
			mnuItemDelete.Enabled = this.IsEditAndDelete(selectedRecipeList);
		}

		#endregion

		#region handler recipe event

		public void RegisterRunRecipe(DDARecipe.DDARecipe recipe)
		{
			recipe.OnStart+=new SiGlaz.Recipes.Recipe.RecipeEventHandler(recipe_OnStart);
			recipe.OnBegin+=new SiGlaz.Recipes.Recipe.RecipeEventHandler(recipe_OnBegin);
			recipe.OnBeginNode+=new SiGlaz.Recipes.Recipe.NodeEventHandler(recipe_OnBeginNode);
			recipe.OnComplete+=new SiGlaz.Recipes.Recipe.RecipeEventHandler(recipe_OnComplete);
			recipe.OnCompleteNode+=new SiGlaz.Recipes.Recipe.NodeEventHandler(recipe_OnCompleteNode);
			recipe.OnException+=new SiGlaz.Recipes.Recipe.RecipeEventHandler(recipe_OnException);
			recipe.OnExceptionNode+=new SiGlaz.Recipes.Recipe.NodeEventHandler(recipe_OnExceptionNode);
			recipe.OnStop+=new SiGlaz.Recipes.Recipe.RecipeEventHandler(recipe_OnStop);
			recipe.OnWaitingForData+=new SiGlaz.Recipes.Recipe.NodeEventHandler(recipe_OnWaitingForData);
			recipe.OnMessage+=new SiGlaz.Recipes.Recipe.NodeEventHandler(recipe_OnMessage);
		}

		public void UnregisterStopRecipe(DDARecipe.DDARecipe recipe)
		{
			recipe.OnStart-=new SiGlaz.Recipes.Recipe.RecipeEventHandler(recipe_OnStart);
			recipe.OnBegin-=new SiGlaz.Recipes.Recipe.RecipeEventHandler(recipe_OnBegin);
			recipe.OnBeginNode-=new SiGlaz.Recipes.Recipe.NodeEventHandler(recipe_OnBeginNode);
			recipe.OnComplete-=new SiGlaz.Recipes.Recipe.RecipeEventHandler(recipe_OnComplete);
			recipe.OnCompleteNode-=new SiGlaz.Recipes.Recipe.NodeEventHandler(recipe_OnCompleteNode);
			recipe.OnException-=new SiGlaz.Recipes.Recipe.RecipeEventHandler(recipe_OnException);
			recipe.OnExceptionNode-=new SiGlaz.Recipes.Recipe.NodeEventHandler(recipe_OnExceptionNode);
			recipe.OnStop-=new SiGlaz.Recipes.Recipe.RecipeEventHandler(recipe_OnStop);
			recipe.OnWaitingForData-=new SiGlaz.Recipes.Recipe.NodeEventHandler(recipe_OnWaitingForData);
			recipe.OnMessage-=new SiGlaz.Recipes.Recipe.NodeEventHandler(recipe_OnMessage);
		}

        public void UnregisterStopRecipeSafe(int recipeid)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate {
                    UnregisterStopRecipe(recipeid);
                });
            }
            else
                UnregisterStopRecipe(recipeid);
        }


		private void UnregisterStopRecipe(int recipeid)
		{
			foreach(ListViewItem item in lvRecipeList.Items)
			{
				DDARecipe.DDARecipe recipe = item.Tag as DDARecipe.DDARecipe;
				if(recipe!=null && recipe.ID==recipeid)
				{
					UnregisterStopRecipe(recipe);
					break;
				}
			}
		}

		public virtual void recipe_OnStart(SiGlaz.Recipes.RecipeEventArgs e)
		{
			UpdateStatus((e as DDARecipe.DDARecipeEventArgs).RecipeID,"Start");
			HandleStateChange();
		}

		public void recipe_OnBegin(SiGlaz.Recipes.RecipeEventArgs e)
		{
			UpdateStatus((e as DDARecipe.DDARecipeEventArgs).RecipeID,"Begin to process");
		}

		public void recipe_OnBeginNode(SiGlaz.Recipes.Node node, SiGlaz.Recipes.RecipeEventArgs e)
		{
			DDARecipe.DDARecipe recipe = node.Parent as DDARecipe.DDARecipe;
			string msg = string.Format("Begin to process node [{0}]",node.Name);
			UpdateStatus(recipe.ID,msg);
		}

		public void recipe_OnComplete(SiGlaz.Recipes.RecipeEventArgs e)
		{
			UpdateStatus((e as DDARecipe.DDARecipeEventArgs).RecipeID,"Complete");
		}

		public void recipe_OnCompleteNode(SiGlaz.Recipes.Node node, SiGlaz.Recipes.RecipeEventArgs e)
		{
			DDARecipe.DDARecipe recipe = node.Parent as DDARecipe.DDARecipe;
			string msg = string.Format("Node [{0}] was completely processed",node.Name) ;
			UpdateStatus(recipe.ID,msg);
		}

		public void recipe_OnException(SiGlaz.Recipes.RecipeEventArgs e)
		{
			UpdateStatus((e as DDARecipe.DDARecipeEventArgs).RecipeID,"Exception");
		}

		public void recipe_OnExceptionNode(SiGlaz.Recipes.Node node, SiGlaz.Recipes.RecipeEventArgs e)
		{
			DDARecipe.DDARecipe recipe = node.Parent as DDARecipe.DDARecipe;
			string msg = string.Format("Exception at node [{0}]",node.Name);
			UpdateStatus(recipe.ID,msg);
		}

		public virtual void recipe_OnStop(SiGlaz.Recipes.RecipeEventArgs e)
		{
			UpdateStatus((e as DDARecipe.DDARecipeEventArgs).RecipeID,"Stop");
			HandleStateChange();
			UnregisterStopRecipeSafe(e.RecipeID);
		}

		public void recipe_OnWaitingForData(SiGlaz.Recipes.Node node, SiGlaz.Recipes.RecipeEventArgs e)
		{
			DDARecipe.DDARecipe recipe = node.Parent as DDARecipe.DDARecipe;
			string msg = string.Format("Waiting new data for processing at node [{0}]",node.Name);
			UpdateStatus(recipe.ID,msg);
		}

		public void recipe_OnMessage(SiGlaz.Recipes.Node node, SiGlaz.Recipes.RecipeEventArgs e)
		{
			string msg = string.Empty;
			if(node!=null)
			{
				DDARecipe.DDARecipe recipe = node.Parent as DDARecipe.DDARecipe;
				msg = string.Format("Message at node [{0}]",node.Name);
				UpdateStatus(recipe.ID,msg);
			}
			else
			{
				msg = string.Format(e.Message);
				UpdateStatus(-1,msg);
			}
		}

		private delegate void MessageHandler(int id,string message);
		public void UpdateStatus(int id,string msg)
		{
			if(!this.lvRecipeList.InvokeRequired)
			{
				UpdateStatusSafe(id,msg);
			}
			else
			{
				MessageHandler statusDelegate =
					new MessageHandler(UpdateStatusSafe);

				this.lvRecipeList.BeginInvoke(statusDelegate,
					new object[] { id,msg });
			}
		}

		public void UpdateStatusSafe(int id,string msg)
		{
			if(!htListItem.ContainsKey(id)) return;
			try
			{
				ListViewItem .ListViewSubItem item = htListItem[id] as ListViewItem .ListViewSubItem;
				item.Text = msg;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.ToString());
			}
		}

		#endregion handler recipe event

		
	}
}
