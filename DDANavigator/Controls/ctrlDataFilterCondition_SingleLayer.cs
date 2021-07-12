using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Basic;
using SiGlaz.Common.DDA.Const;
using DDANavigator.Dialogs;
using SiGlaz.Utility;
namespace DDANavigator.Controls
{
	public class ctrlDataFilterCondition_SingleLayer : ctrlBase
	{
		#region Members
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox gbBasicKlarfFilterCondition;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RadioButton raBasicFilter;
		private System.Windows.Forms.Button btnFilterByKlarfHeader;
		private System.Windows.Forms.RadioButton raAdvanceKlarfFilterCondition;
		private ctrlTextBoxFilter txtDiskID;
		private QueryCondition _queryCondition = new QueryCondition();
		private TimeFilter _timeFilter = null;
		private ctrlTextBoxFilter txtDiskTypeID;
		private ctrlTextBoxFilter txtCassetteID;
		private ctrlTextBoxFilter txtStation;
		private ctrlTextBoxFilter txtWordCellID;
		private ctrlTextBoxFilter txtSignatureName;
		private FunctionType _type = FunctionType.SingleLayer;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private DDANavigator.Controls.ctrlTextBoxFilter txtTesterType;
		private DDANavigator.Controls.ctrlTextBoxFilter txtTestGrade;
		private DDANavigator.Controls.ctrlTextBoxFilter txtSlotNoType;
		private DDANavigator.Controls.ctrlTextBoxFilter txtLotNo;
		private DDANavigator.Controls.ctrlTextBoxFilter txtLotIDCode;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label13;
		private DDANavigator.Controls.ctrlTextBoxFilter txtIRISBinNo;
		private DDANavigator.Controls.ctrlTextBoxFilter txtDDAGrade;
		private DDANavigator.Controls.ctrlTextBoxFilter txtResourceValue;
		private System.Windows.Forms.ComboBox cboResourceType;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private string _fabID = string.Empty;
		#endregion
		
		#region Constructor & Destructor
		public ctrlDataFilterCondition_SingleLayer()
		{
			InitializeComponent();

			txtDiskID.FieldName = WaferConst.DiskID;
			txtDiskTypeID.FieldName = WaferConst.Product;
			txtLotNo.FieldName = WaferConst.LotNo;
			txtLotIDCode.FieldName = WaferConst.LotIDCode;
			txtCassetteID.FieldName = WaferConst.CassetteID;
			txtStation.FieldName = WaferConst.Tester;
			txtWordCellID.FieldName = WaferConst.TestCell;
			txtSignatureName.FieldName = WaferConst.SignatureName;
			txtSlotNoType.FieldName = WaferConst.SlotNoType;
			txtTestGrade.FieldName = WaferConst.TesterGrade;
			txtDDAGrade.FieldName = WaferConst.DDAGrade;
			txtIRISBinNo.FieldName = WaferConst.IRISBinNo;
			txtTesterType.FieldName = WaferConst.TesterType;
			cboResourceType.SelectedIndex = 0;
			txtResourceValue.FieldName = "(All)";
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
			this.gbBasicKlarfFilterCondition = new System.Windows.Forms.GroupBox();
			this.txtResourceValue = new DDANavigator.Controls.ctrlTextBoxFilter();
			this.cboResourceType = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.txtIRISBinNo = new DDANavigator.Controls.ctrlTextBoxFilter();
			this.label13 = new System.Windows.Forms.Label();
			this.txtDDAGrade = new DDANavigator.Controls.ctrlTextBoxFilter();
			this.label11 = new System.Windows.Forms.Label();
			this.txtLotIDCode = new DDANavigator.Controls.ctrlTextBoxFilter();
			this.label5 = new System.Windows.Forms.Label();
			this.txtTesterType = new DDANavigator.Controls.ctrlTextBoxFilter();
			this.label4 = new System.Windows.Forms.Label();
			this.txtTestGrade = new DDANavigator.Controls.ctrlTextBoxFilter();
			this.label3 = new System.Windows.Forms.Label();
			this.txtSlotNoType = new DDANavigator.Controls.ctrlTextBoxFilter();
			this.label2 = new System.Windows.Forms.Label();
			this.txtSignatureName = new DDANavigator.Controls.ctrlTextBoxFilter();
			this.txtWordCellID = new DDANavigator.Controls.ctrlTextBoxFilter();
			this.txtStation = new DDANavigator.Controls.ctrlTextBoxFilter();
			this.txtCassetteID = new DDANavigator.Controls.ctrlTextBoxFilter();
			this.txtLotNo = new DDANavigator.Controls.ctrlTextBoxFilter();
			this.txtDiskTypeID = new DDANavigator.Controls.ctrlTextBoxFilter();
			this.txtDiskID = new DDANavigator.Controls.ctrlTextBoxFilter();
			this.label1 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.raBasicFilter = new System.Windows.Forms.RadioButton();
			this.btnFilterByKlarfHeader = new System.Windows.Forms.Button();
			this.raAdvanceKlarfFilterCondition = new System.Windows.Forms.RadioButton();
			this.gbBasicKlarfFilterCondition.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbBasicKlarfFilterCondition
			// 
			this.gbBasicKlarfFilterCondition.Controls.Add(this.txtResourceValue);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.cboResourceType);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.label14);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.label15);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.txtIRISBinNo);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.label13);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.txtDDAGrade);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.label11);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.txtLotIDCode);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.label5);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.txtTesterType);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.label4);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.txtTestGrade);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.label3);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.txtSlotNoType);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.label2);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.txtSignatureName);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.txtWordCellID);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.txtStation);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.txtCassetteID);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.txtLotNo);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.txtDiskTypeID);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.txtDiskID);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.label1);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.label12);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.label10);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.label9);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.label8);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.label7);
			this.gbBasicKlarfFilterCondition.Controls.Add(this.label6);
			this.gbBasicKlarfFilterCondition.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbBasicKlarfFilterCondition.Location = new System.Drawing.Point(0, 4);
			this.gbBasicKlarfFilterCondition.Name = "gbBasicKlarfFilterCondition";
			this.gbBasicKlarfFilterCondition.Size = new System.Drawing.Size(392, 336);
			this.gbBasicKlarfFilterCondition.TabIndex = 1;
			this.gbBasicKlarfFilterCondition.TabStop = false;
			// 
			// txtResourceValue
			// 
			this.txtResourceValue.FabID = "";
			this.txtResourceValue.FieldName = "DiskID";
			this.txtResourceValue.FromDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtResourceValue.IsViewUnknownSignature = false;
			this.txtResourceValue.Location = new System.Drawing.Point(104, 304);
			this.txtResourceValue.Name = "txtResourceValue";
			this.txtResourceValue.Size = new System.Drawing.Size(268, 20);
			this.txtResourceValue.TabIndex = 42;
			this.txtResourceValue.ToDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtResourceValue.Type = SiGlaz.Common.DDA.FunctionType.SingleLayer;
			this.txtResourceValue.Value = "";
			// 
			// cboResourceType
			// 
			this.cboResourceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboResourceType.Items.AddRange(new object[] {
																 "(All)",
																 "Rsc725",
																 "Rsc769",
																 "Rsc771",
																 "Rsc764",
																 "Rsc575",
																 "Rsc450",
																 "Rsc453",
																 "Rsc600",
																 "Rsc766",
																 "Rsc0806",
																 "Rsc3806"});
			this.cboResourceType.Location = new System.Drawing.Point(104, 280);
			this.cboResourceType.Name = "cboResourceType";
			this.cboResourceType.Size = new System.Drawing.Size(268, 21);
			this.cboResourceType.TabIndex = 41;
			this.cboResourceType.SelectedIndexChanged += new System.EventHandler(this.cboResourceType_SelectedIndexChanged);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(16, 308);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(70, 16);
			this.label14.TabIndex = 40;
			this.label14.Text = "Resource ID:";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(16, 284);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(84, 16);
			this.label15.TabIndex = 39;
			this.label15.Text = "Resource Type:";
			// 
			// txtIRISBinNo
			// 
			this.txtIRISBinNo.FabID = "";
			this.txtIRISBinNo.FieldName = "DiskID";
			this.txtIRISBinNo.FromDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtIRISBinNo.IsViewUnknownSignature = false;
			this.txtIRISBinNo.Location = new System.Drawing.Point(104, 156);
			this.txtIRISBinNo.Name = "txtIRISBinNo";
			this.txtIRISBinNo.Size = new System.Drawing.Size(268, 20);
			this.txtIRISBinNo.TabIndex = 9;
			this.txtIRISBinNo.ToDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtIRISBinNo.Type = SiGlaz.Common.DDA.FunctionType.SingleLayer;
			this.txtIRISBinNo.Value = "";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(16, 160);
			this.label13.Name = "label13";
			this.label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label13.Size = new System.Drawing.Size(66, 16);
			this.label13.TabIndex = 36;
			this.label13.Text = "IRIS Bin No:";
			// 
			// txtDDAGrade
			// 
			this.txtDDAGrade.FabID = "";
			this.txtDDAGrade.FieldName = "DiskID";
			this.txtDDAGrade.FromDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtDDAGrade.IsViewUnknownSignature = false;
			this.txtDDAGrade.Location = new System.Drawing.Point(104, 136);
			this.txtDDAGrade.Name = "txtDDAGrade";
			this.txtDDAGrade.Size = new System.Drawing.Size(268, 20);
			this.txtDDAGrade.TabIndex = 8;
			this.txtDDAGrade.ToDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtDDAGrade.Type = SiGlaz.Common.DDA.FunctionType.SingleLayer;
			this.txtDDAGrade.Value = "";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(16, 140);
			this.label11.Name = "label11";
			this.label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label11.Size = new System.Drawing.Size(66, 16);
			this.label11.TabIndex = 34;
			this.label11.Text = "DDA Grade:";
			// 
			// txtLotIDCode
			// 
			this.txtLotIDCode.FabID = "";
			this.txtLotIDCode.FieldName = "DiskID";
			this.txtLotIDCode.FromDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtLotIDCode.IsViewUnknownSignature = false;
			this.txtLotIDCode.Location = new System.Drawing.Point(104, 76);
			this.txtLotIDCode.Name = "txtLotIDCode";
			this.txtLotIDCode.Size = new System.Drawing.Size(268, 20);
			this.txtLotIDCode.TabIndex = 5;
			this.txtLotIDCode.ToDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtLotIDCode.Type = SiGlaz.Common.DDA.FunctionType.SingleLayer;
			this.txtLotIDCode.Value = "";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 80);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(67, 16);
			this.label5.TabIndex = 31;
			this.label5.Text = "Lot ID Code:";
			// 
			// txtTesterType
			// 
			this.txtTesterType.FabID = "";
			this.txtTesterType.FieldName = "DiskID";
			this.txtTesterType.FromDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtTesterType.IsViewUnknownSignature = false;
			this.txtTesterType.Location = new System.Drawing.Point(104, 16);
			this.txtTesterType.Name = "txtTesterType";
			this.txtTesterType.Size = new System.Drawing.Size(268, 20);
			this.txtTesterType.TabIndex = 2;
			this.txtTesterType.ToDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtTesterType.Type = SiGlaz.Common.DDA.FunctionType.SingleLayer;
			this.txtTesterType.Value = "";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 20);
			this.label4.Name = "label4";
			this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label4.Size = new System.Drawing.Size(65, 16);
			this.label4.TabIndex = 30;
			this.label4.Text = "TesterType:";
			// 
			// txtTestGrade
			// 
			this.txtTestGrade.FabID = "";
			this.txtTestGrade.FieldName = "DiskID";
			this.txtTestGrade.FromDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtTestGrade.IsViewUnknownSignature = false;
			this.txtTestGrade.Location = new System.Drawing.Point(104, 116);
			this.txtTestGrade.Name = "txtTestGrade";
			this.txtTestGrade.Size = new System.Drawing.Size(268, 20);
			this.txtTestGrade.TabIndex = 7;
			this.txtTestGrade.ToDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtTestGrade.Type = SiGlaz.Common.DDA.FunctionType.SingleLayer;
			this.txtTestGrade.Value = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 120);
			this.label3.Name = "label3";
			this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label3.Size = new System.Drawing.Size(74, 16);
			this.label3.TabIndex = 28;
			this.label3.Text = "Tester Grade:";
			// 
			// txtSlotNoType
			// 
			this.txtSlotNoType.FabID = "";
			this.txtSlotNoType.FieldName = "DiskID";
			this.txtSlotNoType.FromDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtSlotNoType.IsViewUnknownSignature = false;
			this.txtSlotNoType.Location = new System.Drawing.Point(104, 96);
			this.txtSlotNoType.Name = "txtSlotNoType";
			this.txtSlotNoType.Size = new System.Drawing.Size(268, 20);
			this.txtSlotNoType.TabIndex = 6;
			this.txtSlotNoType.ToDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtSlotNoType.Type = SiGlaz.Common.DDA.FunctionType.SingleLayer;
			this.txtSlotNoType.Value = "";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 100);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 16);
			this.label2.TabIndex = 24;
			this.label2.Text = "Slot No Type:";
			// 
			// txtSignatureName
			// 
			this.txtSignatureName.FabID = "";
			this.txtSignatureName.FieldName = "DiskID";
			this.txtSignatureName.FromDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtSignatureName.IsViewUnknownSignature = false;
			this.txtSignatureName.Location = new System.Drawing.Point(104, 216);
			this.txtSignatureName.Name = "txtSignatureName";
			this.txtSignatureName.Size = new System.Drawing.Size(268, 20);
			this.txtSignatureName.TabIndex = 12;
			this.txtSignatureName.ToDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtSignatureName.Type = SiGlaz.Common.DDA.FunctionType.SingleLayer;
			this.txtSignatureName.Value = "";
			// 
			// txtWordCellID
			// 
			this.txtWordCellID.FabID = "";
			this.txtWordCellID.FieldName = "DiskID";
			this.txtWordCellID.FromDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtWordCellID.IsViewUnknownSignature = false;
			this.txtWordCellID.Location = new System.Drawing.Point(104, 196);
			this.txtWordCellID.Name = "txtWordCellID";
			this.txtWordCellID.Size = new System.Drawing.Size(268, 20);
			this.txtWordCellID.TabIndex = 11;
			this.txtWordCellID.ToDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtWordCellID.Type = SiGlaz.Common.DDA.FunctionType.SingleLayer;
			this.txtWordCellID.Value = "";
			// 
			// txtStation
			// 
			this.txtStation.FabID = "";
			this.txtStation.FieldName = "DiskID";
			this.txtStation.FromDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtStation.IsViewUnknownSignature = false;
			this.txtStation.Location = new System.Drawing.Point(104, 176);
			this.txtStation.Name = "txtStation";
			this.txtStation.Size = new System.Drawing.Size(268, 20);
			this.txtStation.TabIndex = 10;
			this.txtStation.ToDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtStation.Type = SiGlaz.Common.DDA.FunctionType.SingleLayer;
			this.txtStation.Value = "";
			// 
			// txtCassetteID
			// 
			this.txtCassetteID.FabID = "";
			this.txtCassetteID.FieldName = "DiskID";
			this.txtCassetteID.FromDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtCassetteID.IsViewUnknownSignature = false;
			this.txtCassetteID.Location = new System.Drawing.Point(104, 256);
			this.txtCassetteID.Name = "txtCassetteID";
			this.txtCassetteID.Size = new System.Drawing.Size(268, 20);
			this.txtCassetteID.TabIndex = 14;
			this.txtCassetteID.ToDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtCassetteID.Type = SiGlaz.Common.DDA.FunctionType.SingleLayer;
			this.txtCassetteID.Value = "";
			// 
			// txtLotNo
			// 
			this.txtLotNo.FabID = "";
			this.txtLotNo.FieldName = "DiskID";
			this.txtLotNo.FromDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtLotNo.IsViewUnknownSignature = false;
			this.txtLotNo.Location = new System.Drawing.Point(104, 56);
			this.txtLotNo.Name = "txtLotNo";
			this.txtLotNo.Size = new System.Drawing.Size(268, 20);
			this.txtLotNo.TabIndex = 4;
			this.txtLotNo.ToDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtLotNo.Type = SiGlaz.Common.DDA.FunctionType.SingleLayer;
			this.txtLotNo.Value = "";
			// 
			// txtDiskTypeID
			// 
			this.txtDiskTypeID.FabID = "";
			this.txtDiskTypeID.FieldName = "DiskID";
			this.txtDiskTypeID.FromDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtDiskTypeID.IsViewUnknownSignature = false;
			this.txtDiskTypeID.Location = new System.Drawing.Point(104, 36);
			this.txtDiskTypeID.Name = "txtDiskTypeID";
			this.txtDiskTypeID.Size = new System.Drawing.Size(268, 20);
			this.txtDiskTypeID.TabIndex = 3;
			this.txtDiskTypeID.ToDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtDiskTypeID.Type = SiGlaz.Common.DDA.FunctionType.SingleLayer;
			this.txtDiskTypeID.Value = "";
			// 
			// txtDiskID
			// 
			this.txtDiskID.FabID = "";
			this.txtDiskID.FieldName = "DiskID";
			this.txtDiskID.FromDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtDiskID.IsViewUnknownSignature = false;
			this.txtDiskID.Location = new System.Drawing.Point(104, 236);
			this.txtDiskID.Name = "txtDiskID";
			this.txtDiskID.Size = new System.Drawing.Size(268, 20);
			this.txtDiskID.TabIndex = 13;
			this.txtDiskID.ToDate = new System.DateTime(2008, 4, 7, 14, 26, 11, 15);
			this.txtDiskID.Type = SiGlaz.Common.DDA.FunctionType.SingleLayer;
			this.txtDiskID.Value = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 260);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 16);
			this.label1.TabIndex = 23;
			this.label1.Text = "Cassette ID:";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(16, 220);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(89, 16);
			this.label12.TabIndex = 7;
			this.label12.Text = "Signature Name:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(16, 200);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(52, 16);
			this.label10.TabIndex = 5;
			this.label10.Text = "Test Cell:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(16, 180);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(39, 16);
			this.label9.TabIndex = 4;
			this.label9.Text = "Tester:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(16, 60);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(41, 16);
			this.label8.TabIndex = 3;
			this.label8.Text = "Lot No:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(16, 40);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(46, 16);
			this.label7.TabIndex = 2;
			this.label7.Text = "Product:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(16, 240);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 16);
			this.label6.TabIndex = 1;
			this.label6.Text = "Disk ID:";
			// 
			// raBasicFilter
			// 
			this.raBasicFilter.Checked = true;
			this.raBasicFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raBasicFilter.Location = new System.Drawing.Point(4, 0);
			this.raBasicFilter.Name = "raBasicFilter";
			this.raBasicFilter.Size = new System.Drawing.Size(52, 20);
			this.raBasicFilter.TabIndex = 0;
			this.raBasicFilter.TabStop = true;
			this.raBasicFilter.Text = "Basic";
			this.raBasicFilter.CheckedChanged += new System.EventHandler(this.raBasicFilter_CheckedChanged);
			// 
			// btnFilterByKlarfHeader
			// 
			this.btnFilterByKlarfHeader.Enabled = false;
			this.btnFilterByKlarfHeader.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnFilterByKlarfHeader.Location = new System.Drawing.Point(288, 344);
			this.btnFilterByKlarfHeader.Name = "btnFilterByKlarfHeader";
			this.btnFilterByKlarfHeader.Size = new System.Drawing.Size(84, 23);
			this.btnFilterByKlarfHeader.TabIndex = 16;
			this.btnFilterByKlarfHeader.Text = "Condition...";
			this.btnFilterByKlarfHeader.Click += new System.EventHandler(this.btnFilterByKlarfHeader_Click);
			// 
			// raAdvanceKlarfFilterCondition
			// 
			this.raAdvanceKlarfFilterCondition.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.raAdvanceKlarfFilterCondition.Location = new System.Drawing.Point(4, 344);
			this.raAdvanceKlarfFilterCondition.Name = "raAdvanceKlarfFilterCondition";
			this.raAdvanceKlarfFilterCondition.Size = new System.Drawing.Size(76, 24);
			this.raAdvanceKlarfFilterCondition.TabIndex = 15;
			this.raAdvanceKlarfFilterCondition.Text = "Advanced";
			this.raAdvanceKlarfFilterCondition.CheckedChanged += new System.EventHandler(this.raAdvanceKlarfFilterCondition_CheckedChanged);
			// 
			// ctrlDataFilterCondition_SingleLayer
			// 
			this.Controls.Add(this.btnFilterByKlarfHeader);
			this.Controls.Add(this.raAdvanceKlarfFilterCondition);
			this.Controls.Add(this.raBasicFilter);
			this.Controls.Add(this.gbBasicKlarfFilterCondition);
			this.Name = "ctrlDataFilterCondition_SingleLayer";
			this.Size = new System.Drawing.Size(392, 368);
			this.gbBasicKlarfFilterCondition.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Properties
		public TimeFilter TimeFilter
		{
			get { return _timeFilter; }
			set 
			{ 
				_timeFilter = value ;

				if (_timeFilter != null)
				{
					txtDiskID.FromDate = _timeFilter.From;
					txtDiskTypeID.FromDate = _timeFilter.From;
					txtLotNo.FromDate = _timeFilter.From;
					txtLotIDCode.FromDate = _timeFilter.From;
					txtCassetteID.FromDate = _timeFilter.From;
					txtStation.FromDate = _timeFilter.From;
					txtWordCellID.FromDate = _timeFilter.From;
					txtSignatureName.FromDate = _timeFilter.From;
					txtSlotNoType.FromDate = _timeFilter.From;
					txtTestGrade.FromDate = _timeFilter.From;
					txtDDAGrade.FromDate = _timeFilter.From;
					txtIRISBinNo.FromDate = _timeFilter.From;
					txtTesterType.FromDate = _timeFilter.From;
					txtResourceValue.FromDate = _timeFilter.From;

					txtDiskID.ToDate = _timeFilter.To;
					txtDiskTypeID.ToDate = _timeFilter.To;
					txtLotNo.ToDate = _timeFilter.To;
					txtLotIDCode.ToDate = _timeFilter.To;
					txtCassetteID.ToDate = _timeFilter.To;
					txtStation.ToDate = _timeFilter.To;
					txtWordCellID.ToDate = _timeFilter.To;
					txtSignatureName.ToDate = _timeFilter.To;
					txtSlotNoType.ToDate = _timeFilter.To;
					txtTestGrade.ToDate = _timeFilter.To;
					txtDDAGrade.ToDate = _timeFilter.To;
					txtIRISBinNo.ToDate = _timeFilter.To;
					txtTesterType.ToDate = _timeFilter.To;
					txtResourceValue.ToDate = _timeFilter.To;
				}
			}
		}

		public FunctionType Type
		{
			get { return _type; }
			set 
			{ 
				_type = value; 

				txtDiskID.Type = _type;
				txtDiskTypeID.Type = _type;
				txtLotNo.Type = _type;
				txtLotIDCode.Type = _type;
				txtCassetteID.Type = _type;
				txtStation.Type = _type;
				txtWordCellID.Type = _type;
				txtSignatureName.Type = _type;
				txtSlotNoType.Type = _type;
				txtTestGrade.Type = _type;
				txtDDAGrade.Type = _type;
				txtIRISBinNo.Type = _type;
				txtTesterType.Type = _type;
				txtResourceValue.Type = _type;
			}
		}

		public string FabID
		{
			get { return _fabID; }
			set
			{
				_fabID = value;
				txtDiskID.FabID = _fabID;
				txtDiskTypeID.FabID = _fabID;
				txtLotNo.FabID = _fabID;
				txtLotIDCode.FabID = _fabID;
				txtCassetteID.FabID = _fabID;
				txtStation.FabID = _fabID;
				txtWordCellID.FabID = _fabID;
				txtSignatureName.FabID = _fabID;
				txtSlotNoType.FabID = _fabID;
				txtTestGrade.FabID = _fabID;
				txtDDAGrade.FabID = _fabID;
				txtIRISBinNo.FabID = _fabID;
				txtTesterType.FabID = _fabID;
				txtResourceValue.FabID = _fabID;
			}
		}

		public string DiskID
		{
			get { return txtDiskID.Value; }
			set { txtDiskID.Value = value; }
		}

		public string DiskTypeID
		{
			get { return txtDiskTypeID.Value; }
			set { txtDiskTypeID.Value = value; }
		}

		public string LotNo
		{
			get { return txtLotNo.Value; }
			set { txtLotNo.Value = value; }
		}

		public string LotIDCode
		{
			get { return txtLotIDCode.Value; }
			set { txtLotIDCode.Value = value; }
		}

		public string CassetteID
		{
			get { return txtCassetteID.Value; }
			set { txtCassetteID.Value = value; }
		}

		public string Station
		{
			get { return txtStation.Value; }
			set { txtStation.Value = value; }
		}

		public string WordCellID
		{
			get { return txtWordCellID.Value; }
			set { txtWordCellID.Value = value; }
		}

		public string SlotNoType
		{
			get { return txtSlotNoType.Value; }
			set { txtSlotNoType.Value = value; }
		}

		public string TestGrade
		{
			get { return txtTestGrade.Value; }
			set { txtTestGrade.Value = value; }
		}

		public string IRISBinNo
		{
			get { return txtIRISBinNo.Value; }
			set { txtIRISBinNo.Value = value; }
		}

		public string TesterType
		{
			get { return txtTesterType.Value; }
			set { txtTesterType.Value = value; }
		}

		public string SignatureName
		{
			get { return txtSignatureName.Value; }
			set { txtSignatureName.Value = value; }
		}

		public string DDAGrade
		{
			get { return txtDDAGrade.Value; }
			set { txtDDAGrade.Value = value; }
		}

		public string ResourceType
		{
			get { return cboResourceType.Text; }
			set { cboResourceType.Text = value; }
		}

		public string ResourceID
		{
			get { return txtResourceValue.Value; }
			set { txtResourceValue.Value = value; }
		}
		#endregion

		#region UI Command
		private void AdvanceFilterByKlarfHeader()
		{
			Cursor.Current = Cursors.WaitCursor;

			DlgAdvancedCondition dlg = new DlgAdvancedCondition(_queryCondition.GetConditionArrayList(), _queryCondition.IsOrAnd);

			dlg.FabID = _fabID;
			dlg.From = _timeFilter.From;
			dlg.To = _timeFilter.To;

			dlg.InitData(_queryCondition.GetConditionArrayList(), _type);
			
			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				_queryCondition = new QueryCondition();
				_queryCondition.IsOrAnd = dlg.UseOrAnd;
				_queryCondition.ConditionList = (string[])dlg.Condition.ToArray(typeof(string));
			}
		
			Cursor.Current = Cursors.Default;
		}

		public void DisplayInfo(QueryCondition queryCondition)
		{
			ClearAllBasicDataQuery();

			if (queryCondition != null)
			{
				if (queryCondition.ConditionType == ConditionType.Basic)
				{
					raBasicFilter.Checked = true;
					raAdvanceKlarfFilterCondition.Checked = false;
					DisplayBasicQuery(queryCondition);
				}
				else
				{
					raBasicFilter.Checked = false;
					raAdvanceKlarfFilterCondition.Checked = true;
					_queryCondition = queryCondition;
				}
			}
			else
				_queryCondition = new QueryCondition();
		}

		private void DisplayBasicQuery(QueryCondition queyCondition)
		{
			if (queyCondition.IsFilter && queyCondition.ConditionList.Length > 0)
			{
				txtDiskTypeID.Value = Utility.GetValueByFieldName(WaferConst.Product, queyCondition.GetConditionArrayList());
				txtDiskID.Value = Utility.GetValueByFieldName(WaferConst.DiskID, queyCondition.GetConditionArrayList());
				txtLotNo.Value = Utility.GetValueByFieldName(WaferConst.LotNo, queyCondition.GetConditionArrayList());
				txtLotIDCode.Value = Utility.GetValueByFieldName(WaferConst.LotIDCode, queyCondition.GetConditionArrayList());
				txtCassetteID.Value = Utility.GetValueByFieldName(WaferConst.CassetteID, queyCondition.GetConditionArrayList());
				txtStation.Value = Utility.GetValueByFieldName(WaferConst.Tester, queyCondition.GetConditionArrayList());
				txtWordCellID.Value = Utility.GetValueByFieldName(WaferConst.TestCell, queyCondition.GetConditionArrayList());
				txtSignatureName.Value = Utility.GetValueByFieldName(WaferConst.SignatureName, queyCondition.GetConditionArrayList());
				txtSlotNoType.Value = Utility.GetValueByFieldName(WaferConst.SlotNoType, queyCondition.GetConditionArrayList());
				txtTestGrade.Value = Utility.GetValueByFieldName(WaferConst.TesterGrade, queyCondition.GetConditionArrayList());
				txtDDAGrade.Value = Utility.GetValueByFieldName(WaferConst.DDAGrade, queyCondition.GetConditionArrayList());
				txtIRISBinNo.Value = Utility.GetValueByFieldName(WaferConst.IRISBinNo, queyCondition.GetConditionArrayList());
				txtTesterType.Value = Utility.GetValueByFieldName(WaferConst.TesterType, queyCondition.GetConditionArrayList());
				string resourceType = GetResourceType(queyCondition.GetConditionArrayList());
				cboResourceType.Text = resourceType;
				txtResourceValue.Value = Utility.GetValueByFieldName(resourceType, queyCondition.GetConditionArrayList());
			}
		}

		private string GetResourceType(ArrayList conditions)
		{
			foreach (string condition in conditions)
			{
				if (condition.IndexOf(WaferConst.Rsc450) >= 0)
					return WaferConst.Rsc450;

				if (condition.IndexOf(WaferConst.Rsc453) >= 0)
					return WaferConst.Rsc453;

				if (condition.IndexOf(WaferConst.Rsc575) >= 0)
					return WaferConst.Rsc575;

				if (condition.IndexOf(WaferConst.Rsc600) >= 0)
					return WaferConst.Rsc600;

				if (condition.IndexOf(WaferConst.Rsc725) >= 0)
					return WaferConst.Rsc725;

				if (condition.IndexOf(WaferConst.Rsc764) >= 0)
					return WaferConst.Rsc764;

				if (condition.IndexOf(WaferConst.Rsc766) >= 0)
					return WaferConst.Rsc766;

				if (condition.IndexOf(WaferConst.Rsc769) >= 0)
					return WaferConst.Rsc769;

				if (condition.IndexOf(WaferConst.Rsc771) >= 0)
					return WaferConst.Rsc771;

				if (condition.IndexOf(WaferConst.Rsc0806) >= 0)
					return WaferConst.Rsc0806;

				if (condition.IndexOf(WaferConst.Rsc3806) >= 0)
					return WaferConst.Rsc3806;
			}

			return "(All)";
		}

		public void ClearAllBasicDataQuery()
		{
			txtDiskID.Value = string.Empty;
			txtDiskTypeID.Value = string.Empty;
			txtLotNo.Value = string.Empty;
			txtLotIDCode.Value = string.Empty;
			txtCassetteID.Value = string.Empty;
			txtStation.Value = string.Empty;
			txtWordCellID.Value = string.Empty;
			txtSignatureName.Value = string.Empty;
			txtSlotNoType.Value = string.Empty;
			txtTestGrade.Value = string.Empty;
			txtDDAGrade.Value = string.Empty;
			txtIRISBinNo.Value = string.Empty;
			txtTesterType.Value = string.Empty;
			cboResourceType.SelectedIndex = 0;
		}

		public bool CheckInfo()
		{
			bool result = true;
			
			if (raBasicFilter.Checked)
			{
				if (txtSlotNoType.Value.ToUpper() != "EVEN" && txtSlotNoType.Value.ToUpper() != "ODD" && !Utility.CheckFieldNumeric(txtSlotNoType.Value))
				{
					result = false;
					MessageBox.Show("The SlotNoType must be one of three types (Even, Odd, any positive integers).", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else if (_queryCondition.ConditionList.Length <= 0 && raAdvanceKlarfFilterCondition.Checked)
			{
				result = false;
				MessageBox.Show("Please select filter by Disk data condition.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			return result;
		}

		private ArrayList GetBasicQueryConditionList()
		{
			ArrayList conditions = new ArrayList();
			string condition = string.Empty;

			condition = Utility.GetBasicQueryCondition(WaferConst.Product, txtDiskTypeID.Value);
			if (condition != string.Empty) conditions.Add(condition);

			condition = Utility.GetBasicQueryCondition(WaferConst.DiskID, txtDiskID.Value);
			if (condition != string.Empty) conditions.Add(condition);

			condition = Utility.GetBasicQueryCondition(WaferConst.LotNo, txtLotNo.Value);
			if (condition != string.Empty) conditions.Add(condition);

			condition = Utility.GetBasicQueryCondition(WaferConst.LotIDCode, txtLotIDCode.Value);
			if (condition != string.Empty) conditions.Add(condition);

			condition = Utility.GetBasicQueryCondition(WaferConst.CassetteID, txtCassetteID.Value);
			if (condition != string.Empty) conditions.Add(condition);

			condition = Utility.GetBasicQueryCondition(WaferConst.Tester, txtStation.Value);
			if (condition != string.Empty) conditions.Add(condition);

			condition = Utility.GetBasicQueryCondition(WaferConst.TestCell, txtWordCellID.Value);
			if (condition != string.Empty) conditions.Add(condition);

			condition = Utility.GetBasicQueryCondition(WaferConst.SignatureName, txtSignatureName.Value);
			if (condition != string.Empty) conditions.Add(condition);

			condition = Utility.GetBasicQueryCondition(WaferConst.SlotNoType, txtSlotNoType.Value);
			if (condition != string.Empty) conditions.Add(condition);

			condition = Utility.GetBasicQueryCondition(WaferConst.TesterGrade, txtTestGrade.Value);
			if (condition != string.Empty) conditions.Add(condition);

			condition = Utility.GetBasicQueryCondition(WaferConst.DDAGrade, txtDDAGrade.Value);
			if (condition != string.Empty) conditions.Add(condition);

			condition = Utility.GetBasicQueryCondition(WaferConst.IRISBinNo, txtIRISBinNo.Value);
			if (condition != string.Empty) conditions.Add(condition);

			condition = Utility.GetBasicQueryCondition(WaferConst.TesterType, txtTesterType.Value);
			if (condition != string.Empty) conditions.Add(condition);

			condition = Utility.GetBasicQueryCondition(txtResourceValue.FieldName, txtResourceValue.Value);
			if (condition != string.Empty) conditions.Add(condition);
			
			return conditions;
		}

		public QueryCondition GetQueryCondition()
		{
			QueryCondition queryCondition = null;

			if (raBasicFilter.Checked)
			{
				queryCondition = new QueryCondition();
				queryCondition.ConditionType = ConditionType.Basic;
				queryCondition.ConditionList = (string[])GetBasicQueryConditionList().ToArray(typeof(string));
				queryCondition.IsOrAnd = false;
				
				if (queryCondition.ConditionList.Length > 0)
					queryCondition.IsFilter = true;
				else
					queryCondition.IsFilter = false;
			}
			else
			{
				queryCondition = _queryCondition;
				queryCondition.ConditionType = ConditionType.Advanced;

				if (queryCondition.ConditionList.Length > 0)
					queryCondition.IsFilter = true;
				else
					queryCondition.IsFilter = false;
			}

			return queryCondition;
		}
		#endregion

		#region Windows Events Handles
		private void raBasicFilter_CheckedChanged(object sender, System.EventArgs e)
		{
			gbBasicKlarfFilterCondition.Enabled = raBasicFilter.Checked;
			btnFilterByKlarfHeader.Enabled = !raBasicFilter.Checked;
		}

		private void raAdvanceKlarfFilterCondition_CheckedChanged(object sender, System.EventArgs e)
		{
			btnFilterByKlarfHeader.Enabled = raAdvanceKlarfFilterCondition.Checked;
			gbBasicKlarfFilterCondition.Enabled = !raAdvanceKlarfFilterCondition.Checked;
		}

		private void btnFilterByKlarfHeader_Click(object sender, System.EventArgs e)
		{
			AdvanceFilterByKlarfHeader();
		}

		private void cboResourceType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cboResourceType.Text == "(All)")
			{
				txtResourceValue.Enabled = false;
				txtResourceValue.Value = string.Empty;
			}
			else
			{
				txtResourceValue.Enabled = true;
				txtResourceValue.FieldName = cboResourceType.Text;
			}

			base.RaiseResourceTypeChanged(cboResourceType.Text);
		}
		#endregion
	}
}
