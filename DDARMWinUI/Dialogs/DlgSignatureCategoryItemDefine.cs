//using System;
//using System.Drawing;
//using System.Collections;
//using System.ComponentModel;
//using System.Windows.Forms;
//
//namespace DDARMWinUI.Dialogs
//{
//	/// <summary>
//	/// Summary description for DlgSignatureCategoryItemDefine.
//	/// </summary>
//	public class DlgSignatureCategoryItemDefine : System.Windows.Forms.Form
//	{
//		/// <summary>
//		/// Required designer variable.
//		/// </summary>
//		private System.ComponentModel.Container components = null;
//
//		public DlgSignatureCategoryItemDefine()
//		{
//			//
//			// Required for Windows Form Designer support
//			//
//			InitializeComponent();
//
//			//
//			// TODO: Add any constructor code after InitializeComponent call
//			//
//		}
//
//		/// <summary>
//		/// Clean up any resources being used.
//		/// </summary>
//		protected override void Dispose( bool disposing )
//		{
//			if( disposing )
//			{
//				if(components != null)
//				{
//					components.Dispose();
//				}
//			}
//			base.Dispose( disposing );
//		}
//
//		private System.Windows.Forms.GroupBox groupBox1;
//		private System.Windows.Forms.Label label1;
//		private System.Windows.Forms.TextBox txtSignatureName;
//		private System.Windows.Forms.Label label2;
//		private System.Windows.Forms.RichTextBox rtbDescription;
//		private System.Windows.Forms.Button btnCancel;
//		private System.Windows.Forms.Button btnOK;
//
//		#region "Member"
//		private WebServiceProxy.CategoryProxy.Signature _sig=null;
//		#endregion
//
//		#region Windows Form Designer generated code
//		/// <summary>
//		/// Required method for Designer support - do not modify
//		/// the contents of this method with the code editor.
//		/// </summary>
//		private void InitializeComponent()
//		{
//			this.groupBox1 = new System.Windows.Forms.GroupBox();
//			this.rtbDescription = new System.Windows.Forms.RichTextBox();
//			this.label2 = new System.Windows.Forms.Label();
//			this.txtSignatureName = new System.Windows.Forms.TextBox();
//			this.label1 = new System.Windows.Forms.Label();
//			this.btnCancel = new System.Windows.Forms.Button();
//			this.btnOK = new System.Windows.Forms.Button();
//			this.groupBox1.SuspendLayout();
//			this.SuspendLayout();
//			// 
//			// groupBox1
//			// 
//			this.groupBox1.Controls.Add(this.rtbDescription);
//			this.groupBox1.Controls.Add(this.label2);
//			this.groupBox1.Controls.Add(this.txtSignatureName);
//			this.groupBox1.Controls.Add(this.label1);
//			this.groupBox1.Location = new System.Drawing.Point(0, 0);
//			this.groupBox1.Name = "groupBox1";
//			this.groupBox1.Size = new System.Drawing.Size(376, 128);
//			this.groupBox1.TabIndex = 0;
//			this.groupBox1.TabStop = false;
//			// 
//			// rtbDescription
//			// 
//			this.rtbDescription.Location = new System.Drawing.Point(104, 44);
//			this.rtbDescription.Name = "rtbDescription";
//			this.rtbDescription.Size = new System.Drawing.Size(264, 64);
//			this.rtbDescription.TabIndex = 3;
//			this.rtbDescription.Text = "";
//			// 
//			// label2
//			// 
//			this.label2.Location = new System.Drawing.Point(8, 40);
//			this.label2.Name = "label2";
//			this.label2.Size = new System.Drawing.Size(96, 23);
//			this.label2.TabIndex = 2;
//			this.label2.Text = "Description:";
//			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
//			// 
//			// txtSignatureName
//			// 
//			this.txtSignatureName.Location = new System.Drawing.Point(104, 16);
//			this.txtSignatureName.Name = "txtSignatureName";
//			this.txtSignatureName.Size = new System.Drawing.Size(136, 20);
//			this.txtSignatureName.TabIndex = 1;
//			this.txtSignatureName.Text = "";
//			// 
//			// label1
//			// 
//			this.label1.Location = new System.Drawing.Point(8, 16);
//			this.label1.Name = "label1";
//			this.label1.Size = new System.Drawing.Size(96, 23);
//			this.label1.TabIndex = 0;
//			this.label1.Text = "Signature Name:";
//			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
//			// 
//			// btnCancel
//			// 
//			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
//			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
//			this.btnCancel.Location = new System.Drawing.Point(194, 140);
//			this.btnCancel.Name = "btnCancel";
//			this.btnCancel.TabIndex = 10;
//			this.btnCancel.Text = "Cancel";
//			// 
//			// btnOK
//			// 
//			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
//			this.btnOK.Location = new System.Drawing.Point(110, 140);
//			this.btnOK.Name = "btnOK";
//			this.btnOK.TabIndex = 9;
//			this.btnOK.Text = "OK";
//			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
//			// 
//			// DlgSignatureCategoryItemDefine
//			// 
//			this.AcceptButton = this.btnOK;
//			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
//			this.ClientSize = new System.Drawing.Size(378, 175);
//			this.Controls.Add(this.btnCancel);
//			this.Controls.Add(this.btnOK);
//			this.Controls.Add(this.groupBox1);
//			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
//			this.MaximizeBox = false;
//			this.MinimizeBox = false;
//			this.Name = "DlgSignatureCategoryItemDefine";
//			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
//			this.Text = "Define Signature Category";
//			this.groupBox1.ResumeLayout(false);
//			this.ResumeLayout(false);
//
//		}
//		#endregion
//
//		#region Constructor & Destructor
//
//		public DlgSignatureCategoryItemDefine(WebServiceProxy.CategoryProxy.Signature Sig) : this()
//		{
//			this._sig =Sig;		
//			this.Sig = Sig;
//		}	
//	
//		public WebServiceProxy.CategoryProxy.Signature Sig
//		{
//			get
//			{
//				return _sig;
//			}
//			set
//			{
//
//				_sig = value;
//				if (_sig == null)
//					_sig = new WebServiceProxy.CategoryProxy.Signature();
//				UpdateData(false);
//			}
//		}
//
//		
//		#endregion
//
//		#region UI Command
//
//		public bool ValidateSyntax()
//		{			
//			if(txtSignatureName.Text == "")
//			{
//				MessageBox.Show("Signature Name : ",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Warning);
//				return false;
//			}
////			if(rtbDescription.Text == "")
////			{
////				MessageBox.Show("Desc  : ",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Warning);
////				return false;
////			}
//			return true;
//		}
//
//		private void UpdateData(bool update)
//		{
//			if(update)
//			{	
//				this.Sig.SignatureName= txtSignatureName.Text;
//				this.Sig.SignatureDescription= rtbDescription.Text;
//			}
//			else
//			{			
//				txtSignatureName.Text = this.Sig.SignatureName;
//				rtbDescription.Text = this.Sig.SignatureDescription;				
//			}
//		}
//		#endregion
//
//		private void btnOK_Click(object sender, System.EventArgs e)
//		{
//			if( this.ValidateSyntax() )
//			{
//				this.UpdateData(true);
//				DialogResult = DialogResult.OK;
//				Close();
//			}
//		}
//	}
//}
