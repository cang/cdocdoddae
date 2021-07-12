using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace DDARecipe.Controls
{
	public class ctrlRecipe : System.Windows.Forms.UserControl
	{
		#region Members
		private SiGlaz.Windows.Forms.OutlookBar.OutlookBar listBar1;
		private System.Windows.Forms.ImageList ilOutlookBar;
		private System.Windows.Forms.Panel pRecipe;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ToolBarButton btnLink;
		private System.Windows.Forms.ToolBarButton btnLinkTrue;
		private System.Windows.Forms.ToolBarButton btnLinkFalse;
		private System.Windows.Forms.ToolBarButton btnOpen;
		private System.Windows.Forms.ToolBarButton btnSave;
		private System.Windows.Forms.ToolBarButton btnSep1;
		private System.Windows.Forms.ToolBarButton btnSelect;
		private System.ComponentModel.IContainer components;
		private DDARecipe recipe;
		private System.Windows.Forms.ToolBarButton btnCheck;
		private System.Windows.Forms.ImageList ilToolbar;
		private SiGlaz.Recipes.Canvas canvas;
		#endregion
		
		#region Constructor & Destructor
		public ctrlRecipe()
		{
			InitializeComponent();
			InitOutlookBar();
			InitRecipeGUI();
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ctrlRecipe));
            this.listBar1 = new SiGlaz.Windows.Forms.OutlookBar.OutlookBar();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.ilOutlookBar = new System.Windows.Forms.ImageList(this.components);
			this.pRecipe = new System.Windows.Forms.Panel();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.btnOpen = new System.Windows.Forms.ToolBarButton();
			this.btnSave = new System.Windows.Forms.ToolBarButton();
			this.btnSep1 = new System.Windows.Forms.ToolBarButton();
			this.btnSelect = new System.Windows.Forms.ToolBarButton();
			this.btnLink = new System.Windows.Forms.ToolBarButton();
			this.btnLinkTrue = new System.Windows.Forms.ToolBarButton();
			this.btnLinkFalse = new System.Windows.Forms.ToolBarButton();
			this.btnCheck = new System.Windows.Forms.ToolBarButton();
			this.ilToolbar = new System.Windows.Forms.ImageList(this.components);
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.SuspendLayout();
			// 
			// listBar1
			// 
			this.listBar1.AllowDragGroups = true;
			this.listBar1.AllowDragItems = true;
			this.listBar1.AutoScroll = true;
			this.listBar1.BackColor = System.Drawing.SystemColors.Menu;
			this.listBar1.Dock = System.Windows.Forms.DockStyle.Left;
			this.listBar1.DrawStyle = SiGlaz.Windows.Forms.OutlookBar.OutlookBarDrawStyle.OutlookBarDrawStyleOfficeXP;
			this.listBar1.GradientColorEnd = System.Drawing.Color.SkyBlue;
			this.listBar1.GradientColorStart = System.Drawing.Color.AliceBlue;
			this.listBar1.HoveredBackground = null;
			this.listBar1.LargeImageList = null;
			this.listBar1.Location = new System.Drawing.Point(0, 36);
			this.listBar1.Name = "listBar1";
			this.listBar1.NormalBackground = null;
			this.listBar1.SelectedBackground = null;
			this.listBar1.SelectedItem = null;
			this.listBar1.SelectOnMouseDown = true;
			this.listBar1.Size = new System.Drawing.Size(156, 458);
			this.listBar1.SmallImageList = null;
			this.listBar1.TabIndex = 0;
			this.listBar1.ToolTip = this.toolTip1;
			// 
			// ilOutlookBar
			// 
			this.ilOutlookBar.ImageSize = new System.Drawing.Size(32, 32);
			this.ilOutlookBar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilOutlookBar.ImageStream")));
			this.ilOutlookBar.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// pRecipe
			// 
			this.pRecipe.AutoScroll = true;
			this.pRecipe.BackColor = System.Drawing.Color.White;
			this.pRecipe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pRecipe.Location = new System.Drawing.Point(159, 36);
			this.pRecipe.Name = "pRecipe";
			this.pRecipe.Size = new System.Drawing.Size(593, 458);
			this.pRecipe.TabIndex = 1;
			this.pRecipe.Paint += new System.Windows.Forms.PaintEventHandler(this.pRecipe_Paint);
			// 
			// toolBar1
			// 
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.btnOpen,
																						this.btnSave,
																						this.btnSep1,
																						this.btnSelect,
																						this.btnLink,
																						this.btnLinkTrue,
																						this.btnLinkFalse,
																						this.btnCheck});
			this.toolBar1.ButtonSize = new System.Drawing.Size(24, 24);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.ilToolbar;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(752, 36);
			this.toolBar1.TabIndex = 2;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// btnOpen
			// 
			this.btnOpen.ImageIndex = 0;
			this.btnOpen.ToolTipText = "Import from recipe file";
			// 
			// btnSave
			// 
			this.btnSave.ImageIndex = 1;
			this.btnSave.ToolTipText = "Export to recipe file";
			// 
			// btnSep1
			// 
			this.btnSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// btnSelect
			// 
			this.btnSelect.ImageIndex = 2;
			this.btnSelect.Pushed = true;
			this.btnSelect.ToolTipText = "Select";
			// 
			// btnLink
			// 
			this.btnLink.ImageIndex = 3;
			this.btnLink.ToolTipText = "Normal Link";
			// 
			// btnLinkTrue
			// 
			this.btnLinkTrue.ImageIndex = 4;
			this.btnLinkTrue.ToolTipText = "Link True";
			// 
			// btnLinkFalse
			// 
			this.btnLinkFalse.ImageIndex = 5;
			this.btnLinkFalse.ToolTipText = "Link False";
			// 
			// btnCheck
			// 
			this.btnCheck.ImageIndex = 6;
			this.btnCheck.ToolTipText = "Validate Recipe";
			// 
			// ilToolbar
			// 
			this.ilToolbar.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ilToolbar.ImageSize = new System.Drawing.Size(24, 24);
			this.ilToolbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilToolbar.ImageStream")));
			this.ilToolbar.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(156, 36);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 458);
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			// 
			// ctrlRecipe
			// 
			this.Controls.Add(this.pRecipe);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.listBar1);
			this.Controls.Add(this.toolBar1);
			this.Name = "ctrlRecipe";
			this.Size = new System.Drawing.Size(752, 494);
			this.Load += new System.EventHandler(this.ctrlRecipe_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region UI Command
		public void InitOutlookBar()
		{
            this.listBar1.BackColor = System.Drawing.SystemColors.Menu;
            this.listBar1.GradientColorEnd = SystemColors.ControlLight;// System.Drawing.Color.SkyBlue;
            this.listBar1.GradientColorStart = SystemColors.Control;//System.Drawing.Color.AliceBlue;

			//Init group
			listBar1.LargeImageList = this.ilOutlookBar;

			SiGlaz.Windows.Forms.OutlookBar.OutlookBarGroup gitem;
			SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem item;

			#region Control Block
			gitem = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarGroup("Control Block");
			listBar1.Groups.Add(gitem);

			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("Begin",0,"Begin",typeof(Begin));
			gitem.Items.Add(item);

			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("End",1,"End",typeof(End));
			gitem.Items.Add(item);

			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("Decision",2,"Decision",typeof(Decision));
			gitem.Items.Add(item);
			#endregion Control Block

			#region Data Source
			gitem = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarGroup("Data Source");
			listBar1.Groups.Add(gitem);

			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("Surface",3,"Load Surface from database",typeof(Surface));
			gitem.Items.Add(item);
			#endregion Data Source

			#region selection

			gitem = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarGroup("Selection");
			listBar1.Groups.Add(gitem);

			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("Header Option",23,"Select Surface by Header Condition",typeof(HeaderOption));
			gitem.Items.Add(item);

			#endregion selection

			#region Pre-process
			gitem = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarGroup("Pre-process");
			listBar1.Groups.Add(gitem);

			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("Switch Mode",6,"Switch Mode",typeof(SwitchMode));
			gitem.Items.Add(item);

			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("RemoveDuplicateDefects",19,"Remove Duplicate Defects",typeof(RemoveDuplicateDefects));
			gitem.Items.Add(item);

			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("Channel Filter",7,"Category Filter",typeof(ChannelFilter));
			gitem.Items.Add(item);

			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("KnnMinMaxFilter",8,"KnnMinMaxFilter",typeof(KnnMinMaxFilter));
			gitem.Items.Add(item);

			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("KnnPercentFilter",9,"KnnPercentFilter",typeof(KnnPercentFilter));
			gitem.Items.Add(item);

			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("ResultFilter",10,"ResultFilter",typeof(ResultFilter));
			gitem.Items.Add(item);

			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("LinkDefect",11,"LinkDefect",typeof(LinkDefect));
			gitem.Items.Add(item);

			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("LinkDefectFilter",12,"LinkDefectFilter",typeof(LinkDefectFilter));
			gitem.Items.Add(item);

			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("UnlinkDefect",13,"UnlinkDefect",typeof(UnlinkDefect));
			gitem.Items.Add(item);

			#endregion Pre-process

			#region process
			gitem = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarGroup("Process");
			listBar1.Groups.Add(gitem);

			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("AdvancedSignature",5,"Object Rule Processs",typeof(AdvancedSignature));
			gitem.Items.Add(item);

			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("FlatViewAdvancedSignature",18,"Object Rule Processs for Flat View Mode",typeof(FlatViewAdvancedSignature));
			gitem.Items.Add(item);

			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("ZonalProcess",14,"Zonal Processs",typeof(ZonalProcess));
			gitem.Items.Add(item);

			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("FunctionalSignature",15,"FunctionalSignature",typeof(FunctionalSignature));
			gitem.Items.Add(item);

			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("SpiralSignature",21,"SpiralSignature",typeof(SpiralSignature));
			gitem.Items.Add(item);

			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("PatternRecognition",16,"PatternRecognition",typeof(PatternRecognition));
			gitem.Items.Add(item);
			
			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("ClearResult",20,"ClearResult",typeof(ClearResult));
			gitem.Items.Add(item);

			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("TesterNoiseDetection",22,"TesterNoiseDetection",typeof(TesterNoiseDetection));
			gitem.Items.Add(item);

			#endregion process

			#region output
			gitem = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarGroup("Output");
			listBar1.Groups.Add(gitem);

			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("Output",4,"Output to database",typeof(Output));
			gitem.Items.Add(item);

			item = new SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem("Output Signature",17,"Customize Signature Output",typeof(OutputSignature));
			gitem.Items.Add(item);
			#endregion output
		}

		public void NewRecipe()
		{
			recipe = new DDARecipe();
			recipe.OnDrawLinkFinish+=new EventHandler(recipe_OnDrawLinkFinish);
			recipe.ParentControl = canvas;
		}

		public void InitRecipeGUI()
		{
			canvas = new SiGlaz.Recipes.Canvas();
			canvas.Location = new Point(0,0);
			canvas.Size = new Size(600,600);
			canvas.AllowDrop = true;
			canvas.DragEnter+=new DragEventHandler(canvas_DragEnter);
			canvas.DragDrop+=new DragEventHandler(canvas_DragDrop);
			canvas.DragOver+=new DragEventHandler(canvas_DragOver);
			canvas.MouseDown+=new MouseEventHandler(canvas_MouseDown);
			this.pRecipe.Controls.Add(canvas);
		}


		[DllImport("gdi32.dll")]
		private static extern long BitBlt(
			IntPtr hdcDest,
			int xDest,
			int yDest,
			int nWidth,
			int nHeight,
			IntPtr hdcSource,
			int xSrc,
			int ySrc,
			Int32 dwRop);
		const int SRCCOPY=13369376;

		private Bitmap getImage(Control ctr)
		{
			Graphics grCtrl = Graphics.FromHwnd(ctr.Handle);
			Bitmap result = new Bitmap(ctr.Width,ctr.Height, grCtrl);
			
			IntPtr hdcCtrl = grCtrl.GetHdc();
			Graphics grDest = Graphics.FromImage(result);
			IntPtr hdcDest =  grDest.GetHdc();
		
			BitBlt(hdcDest, 0, 0, ctr.Width, ctr.Height, hdcCtrl, 0, 0, SRCCOPY);
			grCtrl.ReleaseHdc(hdcCtrl);
			grDest.ReleaseHdc(hdcDest);
			return result;

		}
		public Bitmap bmp
		{			
			get {return getImage(this.pRecipe);}
		}
		#endregion

		#region Windows Events Handle
		private void canvas_DragDrop(object sender, DragEventArgs e)
		{
			SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem item = e.Data.GetData( typeof(SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem) ) as SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem;
			Point pt = new Point(e.X,e.Y);
			pt = canvas.PointToClient(pt);
			Type type = item.Tag as Type;
			if( type!=null)
			{
				recipe.AddNode(type,pt.X,pt.Y);
				listBar1.SelectedItem.SelectedItem = false;
				listBar1.SelectedItem = null;
			}
		}

		private void canvas_DragOver(object sender, DragEventArgs e)
		{
		}

		private void canvas_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}

		private void ResetAll(ToolBar toolbar,bool push)
		{
			foreach(ToolBarButton btn in toolbar.Buttons)
			{
				btn.Pushed = push;
			}
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			ResetAll(toolBar1,false);
			if(e.Button == btnLink)
			{
				recipe.DrawLinkType = typeof(Link);
				e.Button.Pushed = true;
			}
			else if(e.Button == btnLinkTrue)
			{
				recipe.DrawLinkType = typeof(TrueLink);
				e.Button.Pushed = true;
			}
			else if(e.Button == btnLinkFalse)
			{
				recipe.DrawLinkType = typeof(FalseLink);
				e.Button.Pushed = true;
			}
			else if(e.Button == btnSelect)
			{
				recipe.DrawLinkType = null;
				btnSelect.Pushed = true;
			}
			else if(e.Button == btnCheck)
			{
				string msg = string.Empty;
				if(recipe.ValidateSyntax(ref msg) )
					MessageBox.Show("Recipe is validate.",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Information);
				else
					MessageBox.Show("Invalidate syntax : " + msg,Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			else if(e.Button == btnSave)
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.Title = "Export recipe file document";
				dlg.Filter = "Recipe file document (*.rec)|*.rec|All files (*.*)|*.*";
				dlg.FilterIndex = 0;
				if( dlg.ShowDialog() == DialogResult.OK)
				{
					string msg = string.Empty;
					if(recipe.ValidateSyntax(ref msg) )
					{
						this.Refresh();
						Cursor.Current = Cursors.WaitCursor;

						recipe.SerializeBinary(dlg.FileName);
					}
					else
						MessageBox.Show("Invalidate syntax : " + msg,Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);
				}
			}
			else if(e.Button == btnOpen)
			{
				OpenFileDialog dlg = new OpenFileDialog();
				dlg.Title = "Import recipe file document";
				dlg.Filter = "Recipe file document (*.rec)|*.rec|All files (*.*)|*.*";
				dlg.FilterIndex = 0;
				if( dlg.ShowDialog() == DialogResult.OK)
				{
					this.Refresh();
					Cursor.Current = Cursors.WaitCursor;


					try
					{
						int oldid = recipe.ID;
						recipe.DeserializeBinary(dlg.FileName);
						recipe.ID = oldid;
						recipe.PrevRecipeID = -1;
					}
					catch
					{
						MessageBox.Show("Invalidate Recipe file document",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);
					}
				}
			}
		}

		private void recipe_OnDrawLinkFinish(object sender, EventArgs e)
		{
			if(sender is TrueLink)
				btnLinkTrue.Pushed = false;
			else if(sender is FalseLink)
				btnLinkFalse.Pushed = false;
			else if(sender is Link)
				btnLink.Pushed = false;
			btnSelect.Pushed = true;
		}

		private void ctrlRecipe_Load(object sender, System.EventArgs e)
		{
			if( this.Recipe==null)
				this.NewRecipe();
		}

		private void canvas_MouseDown(object sender, MouseEventArgs e)
		{
			if(listBar1.SelectedItem!=null)
			{
				SiGlaz.Windows.Forms.OutlookBar.OutlookBarItem item = listBar1.SelectedItem;
				Point pt = new Point(e.X,e.Y);
				//pt = canvas.PointToClient(pt);
				Type type = item.Tag as Type;
				if( type!=null)
				{
					recipe.AddNode(type,pt.X,pt.Y);
					listBar1.SelectedItem.SelectedItem = false;
					listBar1.SelectedItem = null;
				}
			}
		}

		#endregion

		private void pRecipe_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		}

		#region property

		public DDARecipe Recipe
		{
			get
			{
				return recipe;
			}
			set
			{
				if(recipe!=null)
				{
					recipe.OnDrawLinkFinish-=new EventHandler(recipe_OnDrawLinkFinish);
					recipe.ParentControl = null;
				}
				recipe = value;
				if(recipe!=null)
				{
					recipe.OnDrawLinkFinish+=new EventHandler(recipe_OnDrawLinkFinish);
					recipe.ParentControl = canvas;
				}

				this.toolBar1.Visible = !recipe.ReadOnly;
				this.listBar1.Visible = !recipe.ReadOnly;
			}

		}

		#endregion property

	
	}
}
