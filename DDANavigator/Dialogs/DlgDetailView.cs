using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using SiGlaz.Common.DDA.Result;
using SiGlaz.Common.DDA.Const;
using SiGlaz.Common.DDA;
using SiGlaz.Utility;
using SSA.SystemFrameworks;
using SiGlaz.SharedMemory;
using SiGlaz.DDA.Business;

namespace DDANavigator.Dialogs
{
	public class DlgDetailView : System.Windows.Forms.Form
	{
		#region Members
		private System.Windows.Forms.TabControl tabDetail;
		private System.Windows.Forms.TabPage pageSourceImage;
		private System.Windows.Forms.PictureBox picSourceImage;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lbNotchOrientation;
		private System.Windows.Forms.TextBox txtNotchOrientation;
		private System.Windows.Forms.TabPage pageResultImage;
		private System.Windows.Forms.PictureBox picResultImage;
		private SiGlaz.Common.DDA.Result.WaferResultItem  _item = null;
		private System.Windows.Forms.Label lbSignatureName;
		private System.Windows.Forms.GroupBox gbSignature;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RichTextBox txtSignatureName;
		private bool _hasSignature = false;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RichTextBox txtBinNum;
		private System.Windows.Forms.RichTextBox txtCassetteID;
		private System.Windows.Forms.RichTextBox txtDiskID;
		private System.Windows.Forms.Label lbCassetteID;
		private System.Windows.Forms.Label lbDiskID;
		private System.Windows.Forms.Label lbBinNum;
		private System.Windows.Forms.RichTextBox txtDiskTypeID;
		private System.Windows.Forms.Label lbDiskTypeID;
		private System.Windows.Forms.RichTextBox txtLotID;
		private System.Windows.Forms.Label lbLotID;
		private System.Windows.Forms.RichTextBox txtSlotNum;
		private System.Windows.Forms.Label lbSlotNum;
		private System.Windows.Forms.RichTextBox txtStation;
		private System.Windows.Forms.Label lbStation;
		private System.Windows.Forms.RichTextBox txtSurface;
		private System.Windows.Forms.Label lbSurface;
		private System.Windows.Forms.Label lbTestDate;
		private System.Windows.Forms.RichTextBox txtTestDate;
		private System.Windows.Forms.RichTextBox txtWordCellID;
		private System.Windows.Forms.Label lnWordCellID;
		private System.Windows.Forms.Label lbNumberOfDefect;
		private System.Windows.Forms.RichTextBox txtNumberOfDefect;
		private System.Windows.Forms.RichTextBox txtPercentOfSignatureDefect;
		private System.Windows.Forms.RichTextBox txtNumberOfSignatureDefect;
		private ViewMode _viewMode = ViewMode.Disk;
		private System.Windows.Forms.RichTextBox txtBinNo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RichTextBox txtLotIDCode;
		private System.Windows.Forms.Label label4;
		private DDAResultData _sharedData = null;
		#endregion
		
		#region Constructor & Destructor
		public DlgDetailView(SiGlaz.Common.DDA.Result.WaferResultItem item, DDAResultData sharedData, ViewMode viewMode)
		{
			InitializeComponent();
			_item = item;
			_sharedData = sharedData;
			_viewMode = viewMode;

			if (sharedData.DefectListRaw == null)
			{
				_hasSignature = false;
				gbSignature.Visible = false;
				tabDetail.TabPages.RemoveAt(1);
			}
			else
			{
				_hasSignature = true;
				gbSignature.Visible = true;
			}

			DisplayProperties();
			DisplayImage();
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgDetailView));
			this.tabDetail = new System.Windows.Forms.TabControl();
			this.pageSourceImage = new System.Windows.Forms.TabPage();
			this.picSourceImage = new System.Windows.Forms.PictureBox();
			this.pageResultImage = new System.Windows.Forms.TabPage();
			this.picResultImage = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtWordCellID = new System.Windows.Forms.RichTextBox();
			this.txtTestDate = new System.Windows.Forms.RichTextBox();
			this.txtSurface = new System.Windows.Forms.RichTextBox();
			this.txtStation = new System.Windows.Forms.RichTextBox();
			this.txtSlotNum = new System.Windows.Forms.RichTextBox();
			this.txtLotID = new System.Windows.Forms.RichTextBox();
			this.txtDiskTypeID = new System.Windows.Forms.RichTextBox();
			this.txtDiskID = new System.Windows.Forms.RichTextBox();
			this.txtCassetteID = new System.Windows.Forms.RichTextBox();
			this.txtBinNum = new System.Windows.Forms.RichTextBox();
			this.lbSlotNum = new System.Windows.Forms.Label();
			this.lbLotID = new System.Windows.Forms.Label();
			this.lbTestDate = new System.Windows.Forms.Label();
			this.lnWordCellID = new System.Windows.Forms.Label();
			this.lbCassetteID = new System.Windows.Forms.Label();
			this.lbSurface = new System.Windows.Forms.Label();
			this.lbDiskTypeID = new System.Windows.Forms.Label();
			this.lbDiskID = new System.Windows.Forms.Label();
			this.lbBinNum = new System.Windows.Forms.Label();
			this.lbStation = new System.Windows.Forms.Label();
			this.lbNumberOfDefect = new System.Windows.Forms.Label();
			this.txtNumberOfDefect = new System.Windows.Forms.RichTextBox();
			this.lbSignatureName = new System.Windows.Forms.Label();
			this.lbNotchOrientation = new System.Windows.Forms.Label();
			this.txtNotchOrientation = new System.Windows.Forms.TextBox();
			this.gbSignature = new System.Windows.Forms.GroupBox();
			this.txtPercentOfSignatureDefect = new System.Windows.Forms.RichTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtNumberOfSignatureDefect = new System.Windows.Forms.RichTextBox();
			this.txtSignatureName = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtBinNo = new System.Windows.Forms.RichTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtLotIDCode = new System.Windows.Forms.RichTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tabDetail.SuspendLayout();
			this.pageSourceImage.SuspendLayout();
			this.pageResultImage.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.gbSignature.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabDetail
			// 
			this.tabDetail.Controls.Add(this.pageSourceImage);
			this.tabDetail.Controls.Add(this.pageResultImage);
			this.tabDetail.Location = new System.Drawing.Point(0, 0);
			this.tabDetail.Name = "tabDetail";
			this.tabDetail.SelectedIndex = 0;
			this.tabDetail.Size = new System.Drawing.Size(632, 650);
			this.tabDetail.TabIndex = 0;
			// 
			// pageSourceImage
			// 
			this.pageSourceImage.Controls.Add(this.picSourceImage);
			this.pageSourceImage.Location = new System.Drawing.Point(4, 22);
			this.pageSourceImage.Name = "pageSourceImage";
			this.pageSourceImage.Size = new System.Drawing.Size(624, 624);
			this.pageSourceImage.TabIndex = 0;
			this.pageSourceImage.Text = "Source Map";
			// 
			// picSourceImage
			// 
			this.picSourceImage.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.picSourceImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picSourceImage.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picSourceImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picSourceImage.Location = new System.Drawing.Point(0, 0);
			this.picSourceImage.Name = "picSourceImage";
			this.picSourceImage.Size = new System.Drawing.Size(624, 624);
			this.picSourceImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.picSourceImage.TabIndex = 0;
			this.picSourceImage.TabStop = false;
			this.picSourceImage.DoubleClick += new System.EventHandler(this.picSourceImage_DoubleClick);
			// 
			// pageResultImage
			// 
			this.pageResultImage.Controls.Add(this.picResultImage);
			this.pageResultImage.Location = new System.Drawing.Point(4, 22);
			this.pageResultImage.Name = "pageResultImage";
			this.pageResultImage.Size = new System.Drawing.Size(624, 624);
			this.pageResultImage.TabIndex = 1;
			this.pageResultImage.Text = "Result Image";
			// 
			// picResultImage
			// 
			this.picResultImage.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.picResultImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picResultImage.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picResultImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picResultImage.Location = new System.Drawing.Point(0, 0);
			this.picResultImage.Name = "picResultImage";
			this.picResultImage.Size = new System.Drawing.Size(624, 624);
			this.picResultImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.picResultImage.TabIndex = 1;
			this.picResultImage.TabStop = false;
			this.picResultImage.DoubleClick += new System.EventHandler(this.picResultImage_DoubleClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtLotIDCode);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtBinNo);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtWordCellID);
			this.groupBox1.Controls.Add(this.txtTestDate);
			this.groupBox1.Controls.Add(this.txtSurface);
			this.groupBox1.Controls.Add(this.txtStation);
			this.groupBox1.Controls.Add(this.txtSlotNum);
			this.groupBox1.Controls.Add(this.txtLotID);
			this.groupBox1.Controls.Add(this.txtDiskTypeID);
			this.groupBox1.Controls.Add(this.txtDiskID);
			this.groupBox1.Controls.Add(this.txtCassetteID);
			this.groupBox1.Controls.Add(this.txtBinNum);
			this.groupBox1.Controls.Add(this.lbSlotNum);
			this.groupBox1.Controls.Add(this.lbLotID);
			this.groupBox1.Controls.Add(this.lbTestDate);
			this.groupBox1.Controls.Add(this.lnWordCellID);
			this.groupBox1.Controls.Add(this.lbCassetteID);
			this.groupBox1.Controls.Add(this.lbSurface);
			this.groupBox1.Controls.Add(this.lbDiskTypeID);
			this.groupBox1.Controls.Add(this.lbDiskID);
			this.groupBox1.Controls.Add(this.lbBinNum);
			this.groupBox1.Controls.Add(this.lbStation);
			this.groupBox1.Controls.Add(this.lbNumberOfDefect);
			this.groupBox1.Controls.Add(this.txtNumberOfDefect);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(640, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(296, 288);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Source";
			// 
			// txtWordCellID
			// 
			this.txtWordCellID.Location = new System.Drawing.Point(132, 236);
			this.txtWordCellID.Multiline = false;
			this.txtWordCellID.Name = "txtWordCellID";
			this.txtWordCellID.ReadOnly = true;
			this.txtWordCellID.Size = new System.Drawing.Size(156, 20);
			this.txtWordCellID.TabIndex = 43;
			this.txtWordCellID.Text = "";
			// 
			// txtTestDate
			// 
			this.txtTestDate.Location = new System.Drawing.Point(132, 216);
			this.txtTestDate.Multiline = false;
			this.txtTestDate.Name = "txtTestDate";
			this.txtTestDate.ReadOnly = true;
			this.txtTestDate.Size = new System.Drawing.Size(156, 20);
			this.txtTestDate.TabIndex = 42;
			this.txtTestDate.Text = "";
			// 
			// txtSurface
			// 
			this.txtSurface.Location = new System.Drawing.Point(132, 196);
			this.txtSurface.Multiline = false;
			this.txtSurface.Name = "txtSurface";
			this.txtSurface.ReadOnly = true;
			this.txtSurface.Size = new System.Drawing.Size(156, 20);
			this.txtSurface.TabIndex = 41;
			this.txtSurface.Text = "";
			// 
			// txtStation
			// 
			this.txtStation.Location = new System.Drawing.Point(132, 176);
			this.txtStation.Multiline = false;
			this.txtStation.Name = "txtStation";
			this.txtStation.ReadOnly = true;
			this.txtStation.Size = new System.Drawing.Size(156, 20);
			this.txtStation.TabIndex = 40;
			this.txtStation.Text = "";
			// 
			// txtSlotNum
			// 
			this.txtSlotNum.Location = new System.Drawing.Point(132, 156);
			this.txtSlotNum.Multiline = false;
			this.txtSlotNum.Name = "txtSlotNum";
			this.txtSlotNum.ReadOnly = true;
			this.txtSlotNum.Size = new System.Drawing.Size(156, 20);
			this.txtSlotNum.TabIndex = 39;
			this.txtSlotNum.Text = "";
			// 
			// txtLotID
			// 
			this.txtLotID.Location = new System.Drawing.Point(132, 116);
			this.txtLotID.Multiline = false;
			this.txtLotID.Name = "txtLotID";
			this.txtLotID.ReadOnly = true;
			this.txtLotID.Size = new System.Drawing.Size(156, 20);
			this.txtLotID.TabIndex = 38;
			this.txtLotID.Text = "";
			// 
			// txtDiskTypeID
			// 
			this.txtDiskTypeID.Location = new System.Drawing.Point(132, 96);
			this.txtDiskTypeID.Multiline = false;
			this.txtDiskTypeID.Name = "txtDiskTypeID";
			this.txtDiskTypeID.ReadOnly = true;
			this.txtDiskTypeID.Size = new System.Drawing.Size(156, 20);
			this.txtDiskTypeID.TabIndex = 37;
			this.txtDiskTypeID.Text = "";
			// 
			// txtDiskID
			// 
			this.txtDiskID.Location = new System.Drawing.Point(132, 76);
			this.txtDiskID.Multiline = false;
			this.txtDiskID.Name = "txtDiskID";
			this.txtDiskID.ReadOnly = true;
			this.txtDiskID.Size = new System.Drawing.Size(156, 20);
			this.txtDiskID.TabIndex = 36;
			this.txtDiskID.Text = "";
			// 
			// txtCassetteID
			// 
			this.txtCassetteID.Location = new System.Drawing.Point(132, 56);
			this.txtCassetteID.Multiline = false;
			this.txtCassetteID.Name = "txtCassetteID";
			this.txtCassetteID.ReadOnly = true;
			this.txtCassetteID.Size = new System.Drawing.Size(156, 20);
			this.txtCassetteID.TabIndex = 35;
			this.txtCassetteID.Text = "";
			// 
			// txtBinNum
			// 
			this.txtBinNum.Location = new System.Drawing.Point(132, 16);
			this.txtBinNum.Multiline = false;
			this.txtBinNum.Name = "txtBinNum";
			this.txtBinNum.ReadOnly = true;
			this.txtBinNum.Size = new System.Drawing.Size(156, 20);
			this.txtBinNum.TabIndex = 34;
			this.txtBinNum.Text = "";
			// 
			// lbSlotNum
			// 
			this.lbSlotNum.AutoSize = true;
			this.lbSlotNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbSlotNum.Location = new System.Drawing.Point(12, 160);
			this.lbSlotNum.Name = "lbSlotNum";
			this.lbSlotNum.Size = new System.Drawing.Size(73, 16);
			this.lbSlotNum.TabIndex = 33;
			this.lbSlotNum.Text = "Slot No Type:";
			// 
			// lbLotID
			// 
			this.lbLotID.AutoSize = true;
			this.lbLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbLotID.Location = new System.Drawing.Point(12, 120);
			this.lbLotID.Name = "lbLotID";
			this.lbLotID.Size = new System.Drawing.Size(38, 16);
			this.lbLotID.TabIndex = 31;
			this.lbLotID.Text = "LotNo:";
			// 
			// lbTestDate
			// 
			this.lbTestDate.AutoSize = true;
			this.lbTestDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbTestDate.Location = new System.Drawing.Point(12, 220);
			this.lbTestDate.Name = "lbTestDate";
			this.lbTestDate.Size = new System.Drawing.Size(53, 16);
			this.lbTestDate.TabIndex = 29;
			this.lbTestDate.Text = "TestDate:";
			// 
			// lnWordCellID
			// 
			this.lnWordCellID.AutoSize = true;
			this.lnWordCellID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lnWordCellID.Location = new System.Drawing.Point(12, 240);
			this.lnWordCellID.Name = "lnWordCellID";
			this.lnWordCellID.Size = new System.Drawing.Size(49, 16);
			this.lnWordCellID.TabIndex = 19;
			this.lnWordCellID.Text = "TestCell:";
			// 
			// lbCassetteID
			// 
			this.lbCassetteID.AutoSize = true;
			this.lbCassetteID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbCassetteID.Location = new System.Drawing.Point(12, 60);
			this.lbCassetteID.Name = "lbCassetteID";
			this.lbCassetteID.Size = new System.Drawing.Size(63, 16);
			this.lbCassetteID.TabIndex = 6;
			this.lbCassetteID.Text = "CassetteID:";
			// 
			// lbSurface
			// 
			this.lbSurface.AutoSize = true;
			this.lbSurface.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbSurface.Location = new System.Drawing.Point(12, 200);
			this.lbSurface.Name = "lbSurface";
			this.lbSurface.Size = new System.Drawing.Size(46, 16);
			this.lbSurface.TabIndex = 5;
			this.lbSurface.Text = "Surface:";
			// 
			// lbDiskTypeID
			// 
			this.lbDiskTypeID.AutoSize = true;
			this.lbDiskTypeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbDiskTypeID.Location = new System.Drawing.Point(12, 100);
			this.lbDiskTypeID.Name = "lbDiskTypeID";
			this.lbDiskTypeID.Size = new System.Drawing.Size(46, 16);
			this.lbDiskTypeID.TabIndex = 3;
			this.lbDiskTypeID.Text = "Product:";
			// 
			// lbDiskID
			// 
			this.lbDiskID.AutoSize = true;
			this.lbDiskID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbDiskID.Location = new System.Drawing.Point(12, 80);
			this.lbDiskID.Name = "lbDiskID";
			this.lbDiskID.Size = new System.Drawing.Size(41, 16);
			this.lbDiskID.TabIndex = 2;
			this.lbDiskID.Text = "DiskID:";
			// 
			// lbBinNum
			// 
			this.lbBinNum.AutoSize = true;
			this.lbBinNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbBinNum.Location = new System.Drawing.Point(12, 20);
			this.lbBinNum.Name = "lbBinNum";
			this.lbBinNum.Size = new System.Drawing.Size(74, 16);
			this.lbBinNum.TabIndex = 0;
			this.lbBinNum.Text = "Tester Grade:";
			// 
			// lbStation
			// 
			this.lbStation.AutoSize = true;
			this.lbStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbStation.Location = new System.Drawing.Point(12, 180);
			this.lbStation.Name = "lbStation";
			this.lbStation.Size = new System.Drawing.Size(39, 16);
			this.lbStation.TabIndex = 25;
			this.lbStation.Text = "Tester:";
			// 
			// lbNumberOfDefect
			// 
			this.lbNumberOfDefect.AutoSize = true;
			this.lbNumberOfDefect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbNumberOfDefect.Location = new System.Drawing.Point(12, 260);
			this.lbNumberOfDefect.Name = "lbNumberOfDefect";
			this.lbNumberOfDefect.Size = new System.Drawing.Size(92, 16);
			this.lbNumberOfDefect.TabIndex = 26;
			this.lbNumberOfDefect.Text = "NumberOfDefect:";
			// 
			// txtNumberOfDefect
			// 
			this.txtNumberOfDefect.Location = new System.Drawing.Point(132, 256);
			this.txtNumberOfDefect.Multiline = false;
			this.txtNumberOfDefect.Name = "txtNumberOfDefect";
			this.txtNumberOfDefect.ReadOnly = true;
			this.txtNumberOfDefect.Size = new System.Drawing.Size(156, 20);
			this.txtNumberOfDefect.TabIndex = 46;
			this.txtNumberOfDefect.Text = "";
			// 
			// lbSignatureName
			// 
			this.lbSignatureName.AutoSize = true;
			this.lbSignatureName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbSignatureName.Location = new System.Drawing.Point(12, 20);
			this.lbSignatureName.Name = "lbSignatureName";
			this.lbSignatureName.Size = new System.Drawing.Size(86, 16);
			this.lbSignatureName.TabIndex = 34;
			this.lbSignatureName.Text = "SignatureName:";
			// 
			// lbNotchOrientation
			// 
			this.lbNotchOrientation.Location = new System.Drawing.Point(0, 0);
			this.lbNotchOrientation.Name = "lbNotchOrientation";
			this.lbNotchOrientation.TabIndex = 0;
			// 
			// txtNotchOrientation
			// 
			this.txtNotchOrientation.Location = new System.Drawing.Point(0, 0);
			this.txtNotchOrientation.Name = "txtNotchOrientation";
			this.txtNotchOrientation.TabIndex = 0;
			this.txtNotchOrientation.Text = "";
			// 
			// gbSignature
			// 
			this.gbSignature.Controls.Add(this.txtPercentOfSignatureDefect);
			this.gbSignature.Controls.Add(this.label2);
			this.gbSignature.Controls.Add(this.txtNumberOfSignatureDefect);
			this.gbSignature.Controls.Add(this.txtSignatureName);
			this.gbSignature.Controls.Add(this.label1);
			this.gbSignature.Controls.Add(this.lbSignatureName);
			this.gbSignature.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbSignature.Location = new System.Drawing.Point(640, 296);
			this.gbSignature.Name = "gbSignature";
			this.gbSignature.Size = new System.Drawing.Size(296, 348);
			this.gbSignature.TabIndex = 5;
			this.gbSignature.TabStop = false;
			this.gbSignature.Text = "Signature";
			// 
			// txtPercentOfSignatureDefect
			// 
			this.txtPercentOfSignatureDefect.Location = new System.Drawing.Point(132, 56);
			this.txtPercentOfSignatureDefect.Multiline = false;
			this.txtPercentOfSignatureDefect.Name = "txtPercentOfSignatureDefect";
			this.txtPercentOfSignatureDefect.ReadOnly = true;
			this.txtPercentOfSignatureDefect.Size = new System.Drawing.Size(156, 20);
			this.txtPercentOfSignatureDefect.TabIndex = 40;
			this.txtPercentOfSignatureDefect.Text = "";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 16);
			this.label2.TabIndex = 39;
			this.label2.Text = "Percentage:";
			// 
			// txtNumberOfSignatureDefect
			// 
			this.txtNumberOfSignatureDefect.Location = new System.Drawing.Point(132, 36);
			this.txtNumberOfSignatureDefect.Multiline = false;
			this.txtNumberOfSignatureDefect.Name = "txtNumberOfSignatureDefect";
			this.txtNumberOfSignatureDefect.ReadOnly = true;
			this.txtNumberOfSignatureDefect.Size = new System.Drawing.Size(156, 20);
			this.txtNumberOfSignatureDefect.TabIndex = 38;
			this.txtNumberOfSignatureDefect.Text = "";
			// 
			// txtSignatureName
			// 
			this.txtSignatureName.Location = new System.Drawing.Point(132, 16);
			this.txtSignatureName.Multiline = false;
			this.txtSignatureName.Name = "txtSignatureName";
			this.txtSignatureName.ReadOnly = true;
			this.txtSignatureName.Size = new System.Drawing.Size(156, 20);
			this.txtSignatureName.TabIndex = 37;
			this.txtSignatureName.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 16);
			this.label1.TabIndex = 36;
			this.label1.Text = "NumberOfDefect:";
			// 
			// txtBinNo
			// 
			this.txtBinNo.Location = new System.Drawing.Point(132, 36);
			this.txtBinNo.Multiline = false;
			this.txtBinNo.Name = "txtBinNo";
			this.txtBinNo.ReadOnly = true;
			this.txtBinNo.Size = new System.Drawing.Size(156, 20);
			this.txtBinNo.TabIndex = 48;
			this.txtBinNo.Text = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 16);
			this.label3.TabIndex = 47;
			this.label3.Text = "Bin No:";
			// 
			// txtLotIDCode
			// 
			this.txtLotIDCode.Location = new System.Drawing.Point(132, 136);
			this.txtLotIDCode.Multiline = false;
			this.txtLotIDCode.Name = "txtLotIDCode";
			this.txtLotIDCode.ReadOnly = true;
			this.txtLotIDCode.Size = new System.Drawing.Size(156, 20);
			this.txtLotIDCode.TabIndex = 50;
			this.txtLotIDCode.Text = "";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(12, 140);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(61, 16);
			this.label4.TabIndex = 49;
			this.label4.Text = "LotIDCode:";
			// 
			// DlgDetailView
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(942, 648);
			this.Controls.Add(this.gbSignature);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.tabDetail);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DlgDetailView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Detail View";
			this.tabDetail.ResumeLayout(false);
			this.pageSourceImage.ResumeLayout(false);
			this.pageResultImage.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.gbSignature.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region UI Command
		private void DisplayImage()
		{
            KlarfParserFile klarf = BDConvert.ConvertFromBinaryToKlarfParserFile(_sharedData.DataSourceRaw);

			picSourceImage.Image = (Image)ConvertKlarf2Image(klarf);


			if (_hasSignature)
				picResultImage.Image = (Image)ConvertKlarf2Image(
                    BDConvert.ConvertFromBinaryToGetResult(klarf,_sharedData.DefectListRaw)
                    );
		}

		private Bitmap ConvertKlarf2Image(SSA.SystemFrameworks.KlarfParserFile klarfFile)
		{
			SSA.SystemFrameworks.KlarfFileView klarfView = new SSA.SystemFrameworks.KlarfFileView(klarfFile);
			klarfView.ShowCoordinate = true;
			klarfView.ShowCoordinateAxis = true;
			klarfView.ShowGird = true;
			klarfView.ShowOrientationMark = true;

			if (_viewMode == ViewMode.Disk)
			{
				klarfFile.TranPolarFromOrigin();
				klarfView.ViewMode = SSA.SystemFrameworks.MRSProcessingType.DiscMode;
				//SSA.SystemFrameworks.InMemmoryData.mrsProcessingMode = SSA.SystemFrameworks.MRSProcessingType.DiscMode;
			}
			else
			{
				klarfFile.TranCartesianFromOrigin(0,1f);
				klarfView.ViewMode = SSA.SystemFrameworks.MRSProcessingType.FlatMode;
				//SSA.SystemFrameworks.InMemmoryData.mrsProcessingMode = SSA.SystemFrameworks.MRSProcessingType.FlatMode;
			}
						
			return klarfView.Export2Image(new Size(600, 600));
		}

		private void DisplayProperties()
		{
			txtBinNum.Text = _item[WaferConst.TesterGrade].ToString();
			txtBinNo.Text = _item[WaferConst.IRISBinNo].ToString();
			txtCassetteID.Text = _item[WaferConst.CassetteID].ToString();
			txtDiskID.Text=_item[WaferConst.DiskID].ToString();
			txtDiskTypeID.Text=_item[WaferConst.Product].ToString();
			txtLotID.Text = _item[WaferConst.LotNo].ToString();
			txtLotIDCode.Text = _item[WaferConst.LotIDCode].ToString();
			txtSlotNum.Text = _item[WaferConst.SlotNoType].ToString();
			txtStation.Text = _item[WaferConst.Tester].ToString();

			if (Convert.ToInt32(_item[WaferConst.Surface]) == 0)
				txtSurface.Text = "Top";
			else
				txtSurface.Text = "Bottom";

			txtTestDate.Text = _item[WaferConst.TestDate].ToString();
			txtWordCellID.Text = _item[WaferConst.TestCell].ToString();
			txtNumberOfDefect.Text=_item[WaferConst.NumberOfDefect].ToString();
			
			if (_hasSignature)
			{
				txtSignatureName.Text = _item[WaferConst.SignatureName].ToString();
				txtNumberOfSignatureDefect.Text = _item[WaferConst.NumberOfSignatureDefect].ToString();
				txtPercentOfSignatureDefect.Text = string.Format("{0}%", Math.Round(Convert.ToDouble(_item[WaferConst.PercentOfSignatureDefect]), 2));
			}
		}

		private void RunDDA()
		{
			Cursor.Current = Cursors.WaitCursor;
			if (File.Exists(AppData.Data.DDAPath) == false)
			{
				MessageBox.Show(string.Format("File {0} does not exist. Please reset DDA path.", AppData.Data.DDAPath), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				Cursor.Current = Cursors.WaitCursor;

				//cha biet cho nay co chay khong cu copy vao dai :))
				string temppath = AppData.ApplicationDataPath;//Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Templates),"DDANavData");
				if(!Directory.Exists(temppath))
					Directory.CreateDirectory(temppath);
				temppath = Path.Combine(temppath,"memorydata.dat");

				DDAResultDataCollection results = new DDAResultDataCollection();
				results.Add(_sharedData);

				results.SerializeBinary(temppath);

				if(AppData.Data.DDAProcess==null)
				{
					if (File.Exists(temppath))
					{
						System.Diagnostics.ProcessStartInfo proInfo = new System.Diagnostics.ProcessStartInfo(AppData.Data.DDAPath,string.Format("\"{0}\" Memory", temppath));
						AppData.Data.DDAProcess = System.Diagnostics.Process.Start(proInfo);
					}
				}
				else
				{
					IntPtr pFoundWindow = AppData.Data.DDAProcess.MainWindowHandle; 
					SiGlaz.Utility.Win32.User32.SendMessage(pFoundWindow,(int)SiGlaz.Utility.Win32.Msgs.WM_USER + 1,0,0);
					SiGlaz.Utility.Win32.User32.SetWindowPos(pFoundWindow,IntPtr.Zero,0,0,0,0,
						(uint)(SiGlaz.Utility.Win32.SetWindowPosFlags.SWP_SHOWWINDOW |SiGlaz.Utility.Win32.SetWindowPosFlags.SWP_NOSIZE) );
				}
			}
		}
		#endregion

		#region Windows Events Handles
		private void picSourceImage_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				RunDDA();
			}
			catch (System.Exception ex)
			{
				
			}
		}

		private void picResultImage_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				RunDDA();		
			}
			catch (System.Exception ex)
			{
				
			}
		}
		#endregion
	}
}
