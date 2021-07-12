using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Basic;
using SiGlaz.Common.DDA.Const;

namespace DDANavigator.Controls
{
	public class ctrlTableLayout : System.Windows.Forms.UserControl
	{
		#region Members
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Button btnLeft;
		private System.Windows.Forms.Button btnRight;
		private System.Windows.Forms.ColumnHeader colOutputField;
		private System.Windows.Forms.ColumnHeader colAllColumn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numPageSize;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ListView lvSelectedField;
		private System.Windows.Forms.ListView lvAvailableField;
		private System.Windows.Forms.Button btnDown;
		private System.Windows.Forms.Button btnUp;
		private System.Windows.Forms.Button btnTopDown;
		private System.Windows.Forms.Button btnTopUp;
		private FunctionType _type = FunctionType.SingleLayer;
		#endregion
		
		#region Constructor & Destructor
		public ctrlTableLayout()
		{
			InitializeComponent();
			GetDefault();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ctrlTableLayout));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.btnDown = new System.Windows.Forms.Button();
			this.btnUp = new System.Windows.Forms.Button();
			this.btnTopDown = new System.Windows.Forms.Button();
			this.btnTopUp = new System.Windows.Forms.Button();
			this.btnLeft = new System.Windows.Forms.Button();
			this.btnRight = new System.Windows.Forms.Button();
			this.lvSelectedField = new System.Windows.Forms.ListView();
			this.colOutputField = new System.Windows.Forms.ColumnHeader();
			this.lvAvailableField = new System.Windows.Forms.ListView();
			this.colAllColumn = new System.Windows.Forms.ColumnHeader();
			this.label1 = new System.Windows.Forms.Label();
			this.numPageSize = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.numPageSize)).BeginInit();
			this.SuspendLayout();
			// 
			// imageList
			// 
			this.imageList.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// btnDown
			// 
			this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDown.ImageIndex = 4;
			this.btnDown.ImageList = this.imageList;
			this.btnDown.Location = new System.Drawing.Point(332, 0);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(23, 23);
			this.btnDown.TabIndex = 33;
			this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
			// 
			// btnUp
			// 
			this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUp.ImageIndex = 3;
			this.btnUp.ImageList = this.imageList;
			this.btnUp.Location = new System.Drawing.Point(308, 0);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(23, 23);
			this.btnUp.TabIndex = 32;
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// btnTopDown
			// 
			this.btnTopDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTopDown.ImageIndex = 2;
			this.btnTopDown.ImageList = this.imageList;
			this.btnTopDown.Location = new System.Drawing.Point(284, 0);
			this.btnTopDown.Name = "btnTopDown";
			this.btnTopDown.Size = new System.Drawing.Size(23, 23);
			this.btnTopDown.TabIndex = 31;
			this.btnTopDown.Click += new System.EventHandler(this.btnTopDown_Click);
			// 
			// btnTopUp
			// 
			this.btnTopUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTopUp.ImageIndex = 1;
			this.btnTopUp.ImageList = this.imageList;
			this.btnTopUp.Location = new System.Drawing.Point(260, 0);
			this.btnTopUp.Name = "btnTopUp";
			this.btnTopUp.Size = new System.Drawing.Size(23, 23);
			this.btnTopUp.TabIndex = 30;
			this.btnTopUp.Click += new System.EventHandler(this.btnTopUp_Click);
			// 
			// btnLeft
			// 
			this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnLeft.Location = new System.Drawing.Point(224, 144);
			this.btnLeft.Name = "btnLeft";
			this.btnLeft.Size = new System.Drawing.Size(32, 24);
			this.btnLeft.TabIndex = 29;
			this.btnLeft.Text = "<";
			this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
			// 
			// btnRight
			// 
			this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnRight.Location = new System.Drawing.Point(224, 116);
			this.btnRight.Name = "btnRight";
			this.btnRight.Size = new System.Drawing.Size(32, 24);
			this.btnRight.TabIndex = 28;
			this.btnRight.Text = ">";
			this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
			// 
			// lvSelectedField
			// 
			this.lvSelectedField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lvSelectedField.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  this.colOutputField});
			this.lvSelectedField.FullRowSelect = true;
			this.lvSelectedField.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvSelectedField.HideSelection = false;
			this.lvSelectedField.LargeImageList = this.imageList;
			this.lvSelectedField.Location = new System.Drawing.Point(260, 28);
			this.lvSelectedField.Name = "lvSelectedField";
			this.lvSelectedField.Size = new System.Drawing.Size(220, 244);
			this.lvSelectedField.SmallImageList = this.imageList;
			this.lvSelectedField.TabIndex = 27;
			this.lvSelectedField.View = System.Windows.Forms.View.Details;
			// 
			// colOutputField
			// 
			this.colOutputField.Text = "Selected Column(s)";
			this.colOutputField.Width = 219;
			// 
			// lvAvailableField
			// 
			this.lvAvailableField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lvAvailableField.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							   this.colAllColumn});
			this.lvAvailableField.FullRowSelect = true;
			this.lvAvailableField.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvAvailableField.HideSelection = false;
			this.lvAvailableField.LargeImageList = this.imageList;
			this.lvAvailableField.Location = new System.Drawing.Point(0, 28);
			this.lvAvailableField.Name = "lvAvailableField";
			this.lvAvailableField.Size = new System.Drawing.Size(220, 244);
			this.lvAvailableField.SmallImageList = this.imageList;
			this.lvAvailableField.TabIndex = 26;
			this.lvAvailableField.View = System.Windows.Forms.View.Details;
			// 
			// colAllColumn
			// 
			this.colAllColumn.Text = "Available Columns";
			this.colAllColumn.Width = 220;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 284);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 16);
			this.label1.TabIndex = 34;
			this.label1.Text = "Page Size:";
			// 
			// numPageSize
			// 
			this.numPageSize.Location = new System.Drawing.Point(68, 280);
			this.numPageSize.Minimum = new System.Decimal(new int[] {
																		1,
																		0,
																		0,
																		0});
			this.numPageSize.Name = "numPageSize";
			this.numPageSize.Size = new System.Drawing.Size(72, 20);
			this.numPageSize.TabIndex = 35;
			this.numPageSize.Value = new System.Decimal(new int[] {
																	  10,
																	  0,
																	  0,
																	  0});
			// 
			// ctrlTableLayout
			// 
			this.Controls.Add(this.numPageSize);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnDown);
			this.Controls.Add(this.btnUp);
			this.Controls.Add(this.btnTopDown);
			this.Controls.Add(this.btnTopUp);
			this.Controls.Add(this.btnLeft);
			this.Controls.Add(this.btnRight);
			this.Controls.Add(this.lvSelectedField);
			this.Controls.Add(this.lvAvailableField);
			this.Name = "ctrlTableLayout";
			this.Size = new System.Drawing.Size(484, 304);
			((System.ComponentModel.ISupportInitialize)(this.numPageSize)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Properties
		public FunctionType Type
		{
			get { return _type; }
			set { _type = value; }
		}
		#endregion

		#region UI Command
		private bool CheckFieldName(string fieldName)
		{
			bool bResult = false;

			foreach(ListViewItem item in lvSelectedField.Items)
			{
				if(item.Text == fieldName)
				{
					bResult = true;
					break;
				}
			}

			return bResult;
		}

		private bool CheckFieldName2(string fieldName)
		{
			bool bResult = false;

			foreach(ListViewItem item in lvAvailableField.Items)
			{
				if(item.Text == fieldName)
				{
					bResult = true;
					break;
				}
			}

			return bResult;
		}

		private void DisplayField_SingleLayer()
		{
			if (!CheckFieldName(WaferConst.TesterGrade))
				lvAvailableField.Items.Add(WaferConst.TesterGrade, 0);

			if (!CheckFieldName(WaferConst.DDAGrade))
				lvAvailableField.Items.Add(WaferConst.DDAGrade, 0);

			if (!CheckFieldName(WaferConst.IRISBinNo))
				lvAvailableField.Items.Add(WaferConst.IRISBinNo, 0);

			if (!CheckFieldName(WaferConst.CassetteID))
				lvAvailableField.Items.Add(WaferConst.CassetteID, 0);

			if (!CheckFieldName(WaferConst.DiskID))
				lvAvailableField.Items.Add(WaferConst.DiskID, 0);

			if (!CheckFieldName(WaferConst.Product))
				lvAvailableField.Items.Add(WaferConst.Product, 0);

			if (!CheckFieldName(WaferConst.LotNo))
				lvAvailableField.Items.Add(WaferConst.LotNo, 0);

			if (!CheckFieldName(WaferConst.LotIDCode))
				lvAvailableField.Items.Add(WaferConst.LotIDCode, 0);
			
			if (!CheckFieldName(WaferConst.SignatureName))
				lvAvailableField.Items.Add(WaferConst.SignatureName, 0);

			if (!CheckFieldName(WaferConst.SlotNoType))
				lvAvailableField.Items.Add(WaferConst.SlotNoType, 0);

			if (!CheckFieldName(WaferConst.Tester))
				lvAvailableField.Items.Add(WaferConst.Tester, 0);

			if (!CheckFieldName(WaferConst.Surface))
				lvAvailableField.Items.Add(WaferConst.Surface, 0);

			if (!CheckFieldName(WaferConst.TestDate))
				lvAvailableField.Items.Add(WaferConst.TestDate, 0);

			if (!CheckFieldName(WaferConst.TestCell))
				lvAvailableField.Items.Add(WaferConst.TestCell, 0);		

			if (!CheckFieldName(WaferConst.NumberOfDefect))
				lvAvailableField.Items.Add(WaferConst.NumberOfDefect, 0);

			if (!CheckFieldName(WaferConst.NumberOfSignatureDefect))
				lvAvailableField.Items.Add(WaferConst.NumberOfSignatureDefect, 0);

			if (!CheckFieldName(WaferConst.PercentOfSignatureDefect))
				lvAvailableField.Items.Add(WaferConst.PercentOfSignatureDefect, 0);

			if (!CheckFieldName(WaferConst.L2_Top_Corr_cts))
				lvAvailableField.Items.Add(WaferConst.L2_Top_Corr_cts, 0);

			if (!CheckFieldName(WaferConst.L2_Bot_Corr_cts))
				lvAvailableField.Items.Add(WaferConst.L2_Bot_Corr_cts, 0);

			if (!CheckFieldName(WaferConst.L2_Top_NCorr_cts))
				lvAvailableField.Items.Add(WaferConst.L2_Top_NCorr_cts, 0);

			if (!CheckFieldName(WaferConst.L2_Bot_NCorr_cts))
				lvAvailableField.Items.Add(WaferConst.L2_Bot_NCorr_cts, 0);

			if (!CheckFieldName(WaferConst.TesterType))
				lvAvailableField.Items.Add(WaferConst.TesterType, 0);

			if (!CheckFieldName(WaferConst.Rsc725))
				lvAvailableField.Items.Add(WaferConst.Rsc725, 0);

			if (!CheckFieldName(WaferConst.Rsc769))
				lvAvailableField.Items.Add(WaferConst.Rsc769, 0);

			if (!CheckFieldName(WaferConst.Rsc771))
				lvAvailableField.Items.Add(WaferConst.Rsc771, 0);

			if (!CheckFieldName(WaferConst.Rsc764))
				lvAvailableField.Items.Add(WaferConst.Rsc764, 0);

			if (!CheckFieldName(WaferConst.Rsc575))
				lvAvailableField.Items.Add(WaferConst.Rsc575, 0);

			if (!CheckFieldName(WaferConst.Rsc450))
				lvAvailableField.Items.Add(WaferConst.Rsc450, 0);

			if (!CheckFieldName(WaferConst.Rsc453))
				lvAvailableField.Items.Add(WaferConst.Rsc453, 0);

			if (!CheckFieldName(WaferConst.Rsc600))
				lvAvailableField.Items.Add(WaferConst.Rsc600, 0);

			if (!CheckFieldName(WaferConst.Rsc766))
				lvAvailableField.Items.Add(WaferConst.Rsc766, 0);

			if (!CheckFieldName(WaferConst.Rsc0806))
				lvAvailableField.Items.Add(WaferConst.Rsc0806, 0);

			if (!CheckFieldName(WaferConst.Rsc3806))
				lvAvailableField.Items.Add(WaferConst.Rsc3806, 0);

			if (!CheckFieldName(WaferConst.KKLot))
				lvAvailableField.Items.Add(WaferConst.KKLot, 0);

			if (!CheckFieldName(WaferConst.KKSlot))
				lvAvailableField.Items.Add(WaferConst.KKSlot, 0);
		}

		private void DisplayField_DataSource()
		{
			if (!CheckFieldName(WaferConst.TesterGrade))
				lvAvailableField.Items.Add(WaferConst.TesterGrade, 0);

			if (!CheckFieldName(WaferConst.IRISBinNo))
				lvAvailableField.Items.Add(WaferConst.IRISBinNo, 0);

			if (!CheckFieldName(WaferConst.CassetteID))
				lvAvailableField.Items.Add(WaferConst.CassetteID, 0);

			if (!CheckFieldName(WaferConst.DiskID))
				lvAvailableField.Items.Add(WaferConst.DiskID, 0);

			if (!CheckFieldName(WaferConst.Product))
				lvAvailableField.Items.Add(WaferConst.Product, 0);

			if (!CheckFieldName(WaferConst.LotNo))
				lvAvailableField.Items.Add(WaferConst.LotNo, 0);

			if (!CheckFieldName(WaferConst.LotIDCode))
				lvAvailableField.Items.Add(WaferConst.LotIDCode, 0);
			
			if (!CheckFieldName(WaferConst.SlotNoType))
				lvAvailableField.Items.Add(WaferConst.SlotNoType, 0);

			if (!CheckFieldName(WaferConst.Tester))
				lvAvailableField.Items.Add(WaferConst.Tester, 0);

			if (!CheckFieldName(WaferConst.Surface))
				lvAvailableField.Items.Add(WaferConst.Surface, 0);

			if (!CheckFieldName(WaferConst.TestDate))
				lvAvailableField.Items.Add(WaferConst.TestDate, 0);

			if (!CheckFieldName(WaferConst.TestCell))
				lvAvailableField.Items.Add(WaferConst.TestCell, 0);

			if (!CheckFieldName(WaferConst.NumberOfDefect))
				lvAvailableField.Items.Add(WaferConst.NumberOfDefect, 0);

			if (!CheckFieldName(WaferConst.L2_Top_Corr_cts))
				lvAvailableField.Items.Add(WaferConst.L2_Top_Corr_cts, 0);

			if (!CheckFieldName(WaferConst.L2_Bot_Corr_cts))
				lvAvailableField.Items.Add(WaferConst.L2_Bot_Corr_cts, 0);

			if (!CheckFieldName(WaferConst.L2_Top_NCorr_cts))
				lvAvailableField.Items.Add(WaferConst.L2_Top_NCorr_cts, 0);

			if (!CheckFieldName(WaferConst.L2_Bot_NCorr_cts))
				lvAvailableField.Items.Add(WaferConst.L2_Bot_NCorr_cts, 0);

			if (!CheckFieldName(WaferConst.TesterType))
				lvAvailableField.Items.Add(WaferConst.TesterType, 0);

			if (!CheckFieldName(WaferConst.Rsc725))
				lvAvailableField.Items.Add(WaferConst.Rsc725, 0);

			if (!CheckFieldName(WaferConst.Rsc769))
				lvAvailableField.Items.Add(WaferConst.Rsc769, 0);

			if (!CheckFieldName(WaferConst.Rsc771))
				lvAvailableField.Items.Add(WaferConst.Rsc771, 0);

			if (!CheckFieldName(WaferConst.Rsc764))
				lvAvailableField.Items.Add(WaferConst.Rsc764, 0);

			if (!CheckFieldName(WaferConst.Rsc575))
				lvAvailableField.Items.Add(WaferConst.Rsc575, 0);

			if (!CheckFieldName(WaferConst.Rsc450))
				lvAvailableField.Items.Add(WaferConst.Rsc450, 0);

			if (!CheckFieldName(WaferConst.Rsc453))
				lvAvailableField.Items.Add(WaferConst.Rsc453, 0);

			if (!CheckFieldName(WaferConst.Rsc600))
				lvAvailableField.Items.Add(WaferConst.Rsc600, 0);

			if (!CheckFieldName(WaferConst.Rsc766))
				lvAvailableField.Items.Add(WaferConst.Rsc766, 0);

			if (!CheckFieldName(WaferConst.Rsc0806))
				lvAvailableField.Items.Add(WaferConst.Rsc0806, 0);

			if (!CheckFieldName(WaferConst.Rsc3806))
				lvAvailableField.Items.Add(WaferConst.Rsc3806, 0);

			if (!CheckFieldName(WaferConst.KKLot))
				lvAvailableField.Items.Add(WaferConst.KKLot, 0);

			if (!CheckFieldName(WaferConst.KKSlot))
				lvAvailableField.Items.Add(WaferConst.KKSlot, 0);
		}

		private void DisplayField_SourceOfDisk()
		{
			if (!CheckFieldName(WaferConst.TesterGrade))
				lvAvailableField.Items.Add(WaferConst.TesterGrade, 0);

			if (!CheckFieldName(WaferConst.IRISBinNo))
				lvAvailableField.Items.Add(WaferConst.IRISBinNo, 0);

			if (!CheckFieldName(WaferConst.CassetteID))
				lvAvailableField.Items.Add(WaferConst.CassetteID, 0);

			if (!CheckFieldName(WaferConst.DiskID))
				lvAvailableField.Items.Add(WaferConst.DiskID, 0);

			if (!CheckFieldName(WaferConst.Product))
				lvAvailableField.Items.Add(WaferConst.Product, 0);

			if (!CheckFieldName(WaferConst.LotNo))
				lvAvailableField.Items.Add(WaferConst.LotNo, 0);

			if (!CheckFieldName(WaferConst.LotIDCode))
				lvAvailableField.Items.Add(WaferConst.LotIDCode, 0);
			
			if (!CheckFieldName(WaferConst.SlotNoType))
				lvAvailableField.Items.Add(WaferConst.SlotNoType, 0);

			if (!CheckFieldName(WaferConst.Tester))
				lvAvailableField.Items.Add(WaferConst.Tester, 0);

			if (!CheckFieldName(WaferConst.TestCell))
				lvAvailableField.Items.Add(WaferConst.TestCell, 0);

			if (!CheckFieldName(WaferConst.L2_Top_Corr_cts))
				lvAvailableField.Items.Add(WaferConst.L2_Top_Corr_cts, 0);

			if (!CheckFieldName(WaferConst.L2_Bot_Corr_cts))
				lvAvailableField.Items.Add(WaferConst.L2_Bot_Corr_cts, 0);

			if (!CheckFieldName(WaferConst.L2_Top_NCorr_cts))
				lvAvailableField.Items.Add(WaferConst.L2_Top_NCorr_cts, 0);

			if (!CheckFieldName(WaferConst.L2_Bot_NCorr_cts))
				lvAvailableField.Items.Add(WaferConst.L2_Bot_NCorr_cts, 0);

			if (!CheckFieldName(WaferConst.TesterType))
				lvAvailableField.Items.Add(WaferConst.TesterType, 0);

			if (!CheckFieldName(WaferConst.Rsc725))
				lvAvailableField.Items.Add(WaferConst.Rsc725, 0);

			if (!CheckFieldName(WaferConst.Rsc769))
				lvAvailableField.Items.Add(WaferConst.Rsc769, 0);

			if (!CheckFieldName(WaferConst.Rsc771))
				lvAvailableField.Items.Add(WaferConst.Rsc771, 0);

			if (!CheckFieldName(WaferConst.Rsc764))
				lvAvailableField.Items.Add(WaferConst.Rsc764, 0);

			if (!CheckFieldName(WaferConst.Rsc575))
				lvAvailableField.Items.Add(WaferConst.Rsc575, 0);

			if (!CheckFieldName(WaferConst.Rsc450))
				lvAvailableField.Items.Add(WaferConst.Rsc450, 0);

			if (!CheckFieldName(WaferConst.Rsc453))
				lvAvailableField.Items.Add(WaferConst.Rsc453, 0);

			if (!CheckFieldName(WaferConst.Rsc600))
				lvAvailableField.Items.Add(WaferConst.Rsc600, 0);

			if (!CheckFieldName(WaferConst.Rsc766))
				lvAvailableField.Items.Add(WaferConst.Rsc766, 0);

			if (!CheckFieldName(WaferConst.Rsc0806))
				lvAvailableField.Items.Add(WaferConst.Rsc0806, 0);

			if (!CheckFieldName(WaferConst.Rsc3806))
				lvAvailableField.Items.Add(WaferConst.Rsc3806, 0);

			if (!CheckFieldName(WaferConst.KKLot))
				lvAvailableField.Items.Add(WaferConst.KKLot, 0);

			if (!CheckFieldName(WaferConst.KKSlot))
				lvAvailableField.Items.Add(WaferConst.KKSlot, 0);
		}

	
		private void DisplayAvailableField()
		{
			lvAvailableField.Items.Clear();

			switch (_type)
			{
				case FunctionType.SingleLayer:
					DisplayField_SingleLayer();
					break;

				case FunctionType.SignatureOfSurface:
				case FunctionType.DataSource:
					DisplayField_DataSource();
					break;

				case FunctionType.SourceOfDisk:
					DisplayField_SourceOfDisk();
					break;
			}
		}

		private void Default_SingleLayer()
		{
			lvSelectedField.Items.Add(WaferConst.TesterGrade, 0);
			lvSelectedField.Items.Add(WaferConst.DDAGrade, 0);
			lvSelectedField.Items.Add(WaferConst.IRISBinNo, 0);
			lvSelectedField.Items.Add(WaferConst.CassetteID, 0);
			lvSelectedField.Items.Add(WaferConst.DiskID, 0);
			lvSelectedField.Items.Add(WaferConst.Product, 0);
			lvSelectedField.Items.Add(WaferConst.LotNo, 0);
			lvSelectedField.Items.Add(WaferConst.LotIDCode, 0);
			lvSelectedField.Items.Add(WaferConst.SignatureName, 0);
			lvSelectedField.Items.Add(WaferConst.SlotNoType, 0);
			lvSelectedField.Items.Add(WaferConst.Tester, 0);
			lvSelectedField.Items.Add(WaferConst.Surface, 0);
			lvSelectedField.Items.Add(WaferConst.TestDate, 0);
			lvSelectedField.Items.Add(WaferConst.TestCell, 0);
			lvSelectedField.Items.Add(WaferConst.NumberOfDefect, 0);
			lvSelectedField.Items.Add(WaferConst.NumberOfSignatureDefect, 0);
			lvSelectedField.Items.Add(WaferConst.PercentOfSignatureDefect, 0);
			lvSelectedField.Items.Add(WaferConst.L2_Top_Corr_cts, 0);
			lvSelectedField.Items.Add(WaferConst.L2_Bot_Corr_cts, 0);
			lvSelectedField.Items.Add(WaferConst.L2_Top_NCorr_cts, 0);
			lvSelectedField.Items.Add(WaferConst.L2_Bot_NCorr_cts, 0);
			lvSelectedField.Items.Add(WaferConst.TesterType, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc725, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc769, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc771, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc764, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc575, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc450, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc453, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc600, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc766, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc0806, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc3806, 0);
			lvSelectedField.Items.Add(WaferConst.KKLot, 0);
			lvSelectedField.Items.Add(WaferConst.KKSlot, 0);
		}
		
		private void Default_DataSource()
		{
			lvSelectedField.Items.Add(WaferConst.TesterGrade, 0);
			lvSelectedField.Items.Add(WaferConst.IRISBinNo, 0);
			lvSelectedField.Items.Add(WaferConst.CassetteID, 0);
			lvSelectedField.Items.Add(WaferConst.DiskID, 0);
			lvSelectedField.Items.Add(WaferConst.Product, 0);
			lvSelectedField.Items.Add(WaferConst.LotNo, 0);
			lvSelectedField.Items.Add(WaferConst.LotIDCode, 0);
			lvSelectedField.Items.Add(WaferConst.SlotNoType, 0);
			lvSelectedField.Items.Add(WaferConst.Tester, 0);
			lvSelectedField.Items.Add(WaferConst.Surface, 0);
			lvSelectedField.Items.Add(WaferConst.TestDate, 0);
			lvSelectedField.Items.Add(WaferConst.TestCell, 0);
			lvSelectedField.Items.Add(WaferConst.NumberOfDefect, 0);
			lvSelectedField.Items.Add(WaferConst.L2_Top_Corr_cts, 0);
			lvSelectedField.Items.Add(WaferConst.L2_Bot_Corr_cts, 0);
			lvSelectedField.Items.Add(WaferConst.L2_Top_NCorr_cts, 0);
			lvSelectedField.Items.Add(WaferConst.L2_Bot_NCorr_cts, 0);
			lvSelectedField.Items.Add(WaferConst.TesterType, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc725, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc769, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc771, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc764, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc575, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc450, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc453, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc600, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc766, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc0806, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc3806, 0);
			lvSelectedField.Items.Add(WaferConst.KKLot, 0);
			lvSelectedField.Items.Add(WaferConst.KKSlot, 0);
		}

		private void Default_SourceOfDisk()
		{
			lvSelectedField.Items.Add(WaferConst.TesterGrade, 0);
			lvSelectedField.Items.Add(WaferConst.IRISBinNo, 0);
			lvSelectedField.Items.Add(WaferConst.CassetteID, 0);
			lvSelectedField.Items.Add(WaferConst.DiskID, 0);
			lvSelectedField.Items.Add(WaferConst.Product, 0);
			lvSelectedField.Items.Add(WaferConst.LotNo, 0);
			lvSelectedField.Items.Add(WaferConst.LotIDCode, 0);
			lvSelectedField.Items.Add(WaferConst.SlotNoType, 0);
			lvSelectedField.Items.Add(WaferConst.Tester, 0);
			lvSelectedField.Items.Add(WaferConst.TestCell, 0);
			lvSelectedField.Items.Add(WaferConst.L2_Top_Corr_cts, 0);
			lvSelectedField.Items.Add(WaferConst.L2_Bot_Corr_cts, 0);
			lvSelectedField.Items.Add(WaferConst.L2_Top_NCorr_cts, 0);
			lvSelectedField.Items.Add(WaferConst.L2_Bot_NCorr_cts, 0);
			lvSelectedField.Items.Add(WaferConst.TesterType, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc725, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc769, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc771, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc764, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc575, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc450, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc453, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc600, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc766, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc0806, 0);
			lvSelectedField.Items.Add(WaferConst.Rsc3806, 0);
			lvSelectedField.Items.Add(WaferConst.KKLot, 0);
			lvSelectedField.Items.Add(WaferConst.KKSlot, 0);
		}
		
		public void GetDefault()
		{
			lvSelectedField.Items.Clear();
			lvAvailableField.Items.Clear();

			switch (_type)
			{
				case FunctionType.SingleLayer:
					Default_SingleLayer();
					break;

				case FunctionType.SignatureOfSurface:
				case FunctionType.DataSource:
					Default_DataSource();
					break;

				case FunctionType.SourceOfDisk:
					Default_SourceOfDisk();
					break;
			}
		}

		public bool CheckInfo()
		{
			bool result = true;

			if (lvSelectedField.Items.Count <= 0)
			{
				result = false;
				MessageBox.Show("Please select at least one field.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			return result;
		}

		public void DisplayInfo(TableLayout tableLayout)
		{
			if (tableLayout != null)
			{
				//Display Selected Field(s)
				lvSelectedField.Items.Clear();

				foreach (string columnName in tableLayout.DisplayColumns)
					lvSelectedField.Items.Add(columnName, 0);

				DisplayAvailableField();

				//Display Page Size
				numPageSize.Value = tableLayout.PageSize;
				numPageSize.Text = tableLayout.PageSize.ToString();
			}
		}
		
		public TableLayout GetTableLayout()
		{
			TableLayout tableLayout = new TableLayout();

			ArrayList cols = new ArrayList();
			tableLayout.DisplayColumns = new string[lvSelectedField.Items.Count];

			for (int i = 0; i < lvSelectedField.Items.Count; i++)
			{
				ListViewItem item = lvSelectedField.Items[i];
				cols.Add(item.Text);
			}

			tableLayout.PageSize = (int)numPageSize.Value;
			tableLayout.DisplayColumns = (string[])cols.ToArray(typeof(string));

			return tableLayout;
		}

		#endregion

		#region Windows Events Handles
		private void btnRight_Click(object sender, System.EventArgs e)
		{
			if(lvAvailableField.SelectedItems.Count > 0)
			{
				foreach(ListViewItem item in lvAvailableField.SelectedItems)
				{
					if(!CheckFieldName(item.Text))
					{
						lvSelectedField.Items.Add(item.Text, 0);
						lvAvailableField.Items.Remove(item);
					}
				}
			}
		}

		private void btnLeft_Click(object sender, System.EventArgs e)
		{
			if(lvSelectedField.SelectedItems.Count>0)
			{
				foreach(ListViewItem item in lvSelectedField.SelectedItems)
				{
					lvAvailableField.Items.Add(item.Text, 0);
					lvSelectedField.Items.Remove(item);
				}
			}
		}

		private void btnTopUp_Click(object sender, System.EventArgs e)
		{
			if(lvSelectedField.SelectedItems.Count > 0)
			{
				ListViewItem item = lvSelectedField.Items.Insert(0, (ListViewItem)lvSelectedField.SelectedItems[0].Clone());
				lvSelectedField.Items.Remove(lvSelectedField.SelectedItems[0]);
				item.Selected = true;
			}
		}

		private void btnTopDown_Click(object sender, System.EventArgs e)
		{
			if(lvSelectedField.SelectedItems.Count > 0)
			{
				ListViewItem item = lvSelectedField.Items.Add((ListViewItem)lvSelectedField.SelectedItems[0].Clone());
				lvSelectedField.Items.Remove(lvSelectedField.SelectedItems[0]);
				item.Selected = true;
			}
		}

		private void btnUp_Click(object sender, System.EventArgs e)
		{
			if(lvSelectedField.SelectedItems.Count > 0)
			{
				if(lvSelectedField.SelectedItems[0].Index > 0)
				{
					ListViewItem item = lvSelectedField.Items.Insert(lvSelectedField.SelectedItems[0].Index - 1,(ListViewItem)lvSelectedField.SelectedItems[0].Clone());
					lvSelectedField.Items.Remove(lvSelectedField.SelectedItems[0]);
					item.Selected = true;
				}
			}
		}

		private void btnDown_Click(object sender, System.EventArgs e)
		{
			if(lvSelectedField.SelectedItems.Count > 0)
			{
				if(lvSelectedField.SelectedItems[0].Index < lvSelectedField.Items.Count - 1)
				{
					ListViewItem item = lvSelectedField.Items.Insert(lvSelectedField.SelectedItems[0].Index + 2, (ListViewItem)lvSelectedField.SelectedItems[0].Clone());					
					lvSelectedField.Items.Remove(lvSelectedField.SelectedItems[0]);
					item.Selected = true;
				}
			}
		}
		#endregion
	}
}
