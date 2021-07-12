using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Const;

namespace DDANavigator.Dialogs
{
	public class DlgAdvancedCondition : FormBase
	{
		#region Members
		private System.Windows.Forms.DataGrid dgData;
		private System.Windows.Forms.Button btnChangeCondition;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnRemoveAll;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.ComponentModel.Container components = null;
		private DataTable _dtCondition = new DataTable("dtCondition");
		private bool _isOrAnd = true;
		private System.Windows.Forms.DataGridTableStyle tableStyle;
		private FunctionType _type = FunctionType.SingleLayer;
		private DateTime _from = DateTime.Now;
		private DateTime _to = DateTime.Now;
		private bool _isViewUnknownSignature = false;
		private string _fabID = string.Empty;
		#endregion
		
		#region Constructor & Destructor
		public DlgAdvancedCondition()
		{
			InitializeComponent();

		}

		public DlgAdvancedCondition(ArrayList conditionFields, bool isOrAnd)
		{
			InitializeComponent();
			InitData (conditionFields, _type);
			_isOrAnd = isOrAnd;
			dgData.CaptionText = _isOrAnd ? "Or Condition":"And Condition";
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgAdvancedCondition));
			this.dgData = new System.Windows.Forms.DataGrid();
			this.tableStyle = new System.Windows.Forms.DataGridTableStyle();
			this.btnChangeCondition = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnRemoveAll = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
			this.SuspendLayout();
			// 
			// dgData
			// 
			this.dgData.CaptionText = "Or Condition";
			this.dgData.DataMember = "";
			this.dgData.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgData.Location = new System.Drawing.Point(4, 4);
			this.dgData.Name = "dgData";
			this.dgData.Size = new System.Drawing.Size(420, 316);
			this.dgData.TabIndex = 1;
			this.dgData.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																							   this.tableStyle});
			this.dgData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgData_KeyDown);
			this.dgData.Click += new System.EventHandler(this.dgData_Click);
			this.dgData.Enter += new System.EventHandler(this.dgData_Enter);
			// 
			// tableStyle
			// 
			this.tableStyle.DataGrid = this.dgData;
			this.tableStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.tableStyle.MappingName = "dtCondition";
			// 
			// btnChangeCondition
			// 
			this.btnChangeCondition.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnChangeCondition.Location = new System.Drawing.Point(428, 136);
			this.btnChangeCondition.Name = "btnChangeCondition";
			this.btnChangeCondition.Size = new System.Drawing.Size(104, 23);
			this.btnChangeCondition.TabIndex = 20;
			this.btnChangeCondition.Tag = "10";
			this.btnChangeCondition.Text = "Change Condition";
			this.btnChangeCondition.Click += new System.EventHandler(this.btnChangeCondition_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Enabled = false;
			this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnRemove.Location = new System.Drawing.Point(428, 72);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(104, 24);
			this.btnRemove.TabIndex = 18;
			this.btnRemove.Tag = "3";
			this.btnRemove.Text = "Remove";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnRemoveAll
			// 
			this.btnRemoveAll.Enabled = false;
			this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnRemoveAll.Location = new System.Drawing.Point(428, 104);
			this.btnRemoveAll.Name = "btnRemoveAll";
			this.btnRemoveAll.Size = new System.Drawing.Size(104, 24);
			this.btnRemoveAll.TabIndex = 19;
			this.btnRemoveAll.Tag = "4";
			this.btnRemoveAll.Text = "Remove All";
			this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnAdd.Location = new System.Drawing.Point(428, 8);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(104, 24);
			this.btnAdd.TabIndex = 16;
			this.btnAdd.Tag = "1";
			this.btnAdd.Text = "Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Enabled = false;
			this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnEdit.Location = new System.Drawing.Point(428, 40);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(104, 24);
			this.btnEdit.TabIndex = 17;
			this.btnEdit.Tag = "2";
			this.btnEdit.Text = "Edit";
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(-8, 320);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(584, 8);
			this.groupBox1.TabIndex = 21;
			this.groupBox1.TabStop = false;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(280, 336);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 23;
			this.btnCancel.Text = "&Cancel";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(200, 336);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 22;
			this.btnOK.Text = "&OK";
			// 
			// DlgAdvancedCondition
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(538, 368);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnChangeCondition);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnRemoveAll);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.dgData);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DlgAdvancedCondition";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Filter Condition";
			((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Properties
		public string FabID
		{
			get { return _fabID; }
			set { _fabID = value; }
		}

		public bool IsViewUnknownSignature
		{
			get { return _isViewUnknownSignature; }
			set { _isViewUnknownSignature = value; }
		}

		public DateTime From
		{
			set
			{
				_from = value;
			}
		}

		public DateTime To
		{
			set
			{
				_to = value;
			}
		}

		public bool UseOrAnd
		{
			get
			{
				return _isOrAnd;
			}
			set
			{
				if(_isOrAnd != value)
				{
					_dtCondition.Rows.Clear();
					dgData_Click(null,EventArgs.Empty);
				}

				_isOrAnd = value;
				if(_isOrAnd)
					dgData.CaptionText = "OR Condition";
				else
					dgData.CaptionText = "AND Condition";
			}
		}

		public ArrayList Condition
		{
			get 
			{
				ArrayList alData = new ArrayList ();

				foreach ( DataRow dr in _dtCondition.Rows )
				{
					if ( dr[0] is DBNull)
					{
						continue;
					}
					alData.Add (Convert.ToString(dr[0]));

				}
				return alData;
			}
		}
		#endregion

		#region UI Command
		
		public  void InitData( ArrayList conditionData, FunctionType type) 
		{           
			_type = type;
			tableStyle.GridColumnStyles.Clear();

			_dtCondition = new DataTable("dtCondition");

			DataGridTextBoxColumn coltextbox=new DataGridTextBoxColumn();
			coltextbox.Width= 350;
			coltextbox.ReadOnly = true;
			coltextbox.MappingName="Condition";
			coltextbox.HeaderText="Condition";
			tableStyle.GridColumnStyles.Add(coltextbox);         

			tableStyle.AllowSorting = false;  

			DataColumn dcColumn=new DataColumn("Condition");
		
			_dtCondition.Columns.Add(dcColumn);

			dgData.DataSource = _dtCondition;

			foreach ( string  strCondition in conditionData )
			{
				DataRow row  = _dtCondition.NewRow();
				row["Condition"] = strCondition;
				_dtCondition.Rows.Add ( row );
			}
		}

		private void RemoveData()
		{
			try
			{
				if( dgData.CurrentRowIndex < 0 || dgData.CurrentRowIndex >= _dtCondition.Rows.Count)
					return;
				int rowIndex = dgData.CurrentRowIndex;
				_dtCondition.Rows.RemoveAt(dgData.CurrentRowIndex);

				//operation
				dgData_Click(null,EventArgs.Empty);
			}
			catch {};
		}

		private bool ValidateData()
		{
			bool result = true;

			int index = 0;

			string errorMsg = string.Empty;

			foreach ( DataRow dr in _dtCondition.Rows )
			{
				if ( dr[0] is DBNull)
				{
					result = false;
					break;
				}
			}

			if ( !result )
			{
				dgData.Focus();
				dgData.Select( index );
				MessageBox.Show("Input value cannot be null.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);		
			}
			else if ( _dtCondition.Rows.Count <= 0)
			{
				MessageBox.Show("Input value cannot be null.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);		
				result = false;
			}

			return result;
		}
		#endregion

		#region Windows Events Handles
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			DlgConditions dlg = new DlgConditions(_type);
			dlg.FabID = _fabID;
			dlg.From = _from;
			dlg.To = _to;
			dlg.IsViewUnknownSignature = _isViewUnknownSignature;
			dlg.bOrAnd = _isOrAnd;
			if( dlg.ShowDialog(this) == DialogResult.OK)
			{
				dlg.UpdateDatatable();
				DataRow dr  = _dtCondition.NewRow();
				dr[0]       = dlg.Condition;
				_dtCondition.Rows.Add(dr);

				dgData.Focus();		
                
				dgData_Click(null,EventArgs.Empty);
			}

			dgData.Focus();
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			if( dgData.CurrentRowIndex < 0 || dgData.CurrentRowIndex >= _dtCondition.Rows.Count)
				return;
			string ssss = _dtCondition.Rows[dgData.CurrentRowIndex][0].ToString();

			DlgConditions dlg = new DlgConditions(_type);
			dlg.FabID = _fabID;
			dlg.From = _from;
			dlg.To = _to;
			dlg.bOrAnd = _isOrAnd;
			dlg.IsViewUnknownSignature = _isViewUnknownSignature;
            
			try
			{
				dlg.Condition = ssss;
			}
			catch{};

			if( dlg.ShowDialog(this) == DialogResult.OK)
			{
				dlg.UpdateDatatable();
				DataRow dr = _dtCondition.Rows[dgData.CurrentRowIndex];
				dr[0] = dlg.Condition;                						
			}

			dgData.Focus();
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			if(MessageBox.Show("Do you really want to delete the selected condition ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				RemoveData();
		}

		private void btnRemoveAll_Click(object sender, System.EventArgs e)
		{
			if(MessageBox.Show("Do you really want to delete all conditions ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				_dtCondition.Rows.Clear();
				dgData_Click(null, EventArgs.Empty);
			}
		}

		private void btnChangeCondition_Click(object sender, System.EventArgs e)
		{
			DlgChangeCondition dlg = new  DlgChangeCondition();
			dlg.UseOrAnd =  _isOrAnd;

			if( dlg.ShowDialog(this) == DialogResult.OK )
			{
				if( _isOrAnd != dlg.UseOrAnd )
				{
					_isOrAnd = dlg.UseOrAnd;

					dgData.CaptionText = _isOrAnd ? "Or Condition":"And Condition";

					foreach ( DataRow row in _dtCondition.Rows )
					{
						if ( !( row[0] is DBNull ) )
						{
							if ( _isOrAnd )
								row[0] = Convert.ToString( row[0] ).Replace(" OR " , " AND " );
							else
								row[0] = Convert.ToString( row[0] ).Replace(" AND " , " OR " );
						}
					}
				}
			}
		}

		private void dgData_Click(object sender, System.EventArgs e)
		{
			btnRemoveAll.Enabled = _dtCondition.Rows.Count>0;
			btnEdit.Enabled = btnRemove.Enabled = ( dgData.CurrentRowIndex >= 0 && dgData.CurrentRowIndex < _dtCondition.Rows.Count);
		}

		private void dgData_Enter(object sender, System.EventArgs e)
		{
			btnRemoveAll.Enabled = _dtCondition.Rows.Count>0;
			btnEdit.Enabled = btnRemove.Enabled = ( dgData.CurrentRowIndex >= 0 && dgData.CurrentRowIndex < _dtCondition.Rows.Count);
		}

		private void dgData_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			dgData_Click(null,EventArgs.Empty);	
		}
		#endregion
	}
}
