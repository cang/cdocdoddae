using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Const;
using SiGlaz.Utility;

namespace DDANavigator.Dialogs
{
	public class DlgConditionHint : FormBase
	{
		#region Members
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView lvHeaderField;
		private System.ComponentModel.Container components = null;
		private DateTime _from = DateTime.Now;
		private DateTime _to = DateTime.Now;
		private string _fieldName = string.Empty;
		private FunctionType _type = FunctionType.SingleLayer;
		private bool _isViewUnknownSignature = false;
		private string _fabID = string.Empty;
		private ListViewColumnSorter _lvwColumnSorter = new ListViewColumnSorter(true);
		#endregion

		#region Constructor & Destructor
		public DlgConditionHint(string fabID, DateTime from, DateTime to, string fieldName, FunctionType type,  bool hasMultiSelect, bool isViewUnknownSignature)
		{
			InitializeComponent();

			_fabID = fabID;
			_from = from;
			_to	= to;
			_fieldName = fieldName;
			_type = type;
			lvHeaderField.MultiSelect = hasMultiSelect;
			_isViewUnknownSignature = isViewUnknownSignature;
			 lvHeaderField.ListViewItemSorter = _lvwColumnSorter;

			DisplayFieldName();
			GetFieldValues();

			_lvwColumnSorter.Order = SortOrder.Ascending;
			lvHeaderField.Sort();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgConditionHint));
			this.lvHeaderField = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lvHeaderField
			// 
			this.lvHeaderField.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							this.columnHeader1});
			this.lvHeaderField.FullRowSelect = true;
			this.lvHeaderField.Location = new System.Drawing.Point(4, 4);
			this.lvHeaderField.MultiSelect = false;
			this.lvHeaderField.Name = "lvHeaderField";
			this.lvHeaderField.Size = new System.Drawing.Size(232, 216);
			this.lvHeaderField.TabIndex = 0;
			this.lvHeaderField.View = System.Windows.Forms.View.Details;
			this.lvHeaderField.DoubleClick += new System.EventHandler(this.lvHeaderField_DoubleClick);
			this.lvHeaderField.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvHeaderField_ColumnClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Disk Header Filed";
			this.columnHeader1.Width = 209;
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(0, 224);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(600, 8);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(123, 240);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 10;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(43, 240);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 9;
			this.btnOK.Text = "OK";
			// 
			// DlgConditionHint
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(240, 272);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lvHeaderField);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DlgConditionHint";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Condition Hint Properties";
			this.ResumeLayout(false);

		}
		#endregion

		#region Properties
		public string FieldValue
		{
			get{
				if(lvHeaderField.SelectedItems == null || lvHeaderField.SelectedItems.Count ==0)
					return string.Empty;
				return lvHeaderField.SelectedItems[0].Text;
			}
		}

		public string Condition
		{
			get
			{
				string condition = string.Empty;

				if (lvHeaderField.SelectedItems == null || lvHeaderField.SelectedItems.Count <= 0)
					return string.Empty;

				foreach (ListViewItem item in lvHeaderField.SelectedItems)
					condition += string.Format("{0}; ", item.Text);

				if (condition != string.Empty)
					condition = condition.Substring(0, condition.Length - 2);

				return condition;
			}
		}
		#endregion

		#region UI Command
		private void DisplayFieldName()
		{
			lvHeaderField.Columns[0].Text = _fieldName;
		}

		private void GetFieldValues()
		{
			try
			{
				DataTable dataTable = null;
				if (_fieldName.ToUpper() == WaferConst.SlotNoType.ToUpper())
					_fieldName = "SlotNum";
				else if (_fieldName.ToUpper() == WaferConst.TesterGrade.ToUpper())
					_fieldName = "TestGrade";
				else if (_fieldName.ToUpper() == WaferConst.IRISBinNo.ToUpper())
					_fieldName = "BinNo";
				else if (_fieldName.ToUpper() == WaferConst.DDAGrade.ToUpper())
					_fieldName = "Grade";

				switch (_type)
				{
					case FunctionType.DataSource:
					case FunctionType.SourceOfDisk:
						WebServiceProxy.SourceProxy.Source sourceService = WebServiceProxy.WebProxyFactory.CreateSource();
						if (sourceService == null) return;
						dataTable = sourceService.GetHintData(_fabID, _fieldName, _from, _to, string.Empty, (WebServiceProxy.SourceProxy.DDADBType)AppData.Data.DBType).Result.Tables[0];
						break;

					case FunctionType.SingleLayer:
					case FunctionType.SignatureOfSurface:
						WebServiceProxy.SingleLayerProxy.SingleLayer singleLayerService = WebServiceProxy.WebProxyFactory.CreateSingleLayer();
						if (singleLayerService == null) return;
						dataTable = singleLayerService.GetHintData(_fabID, _fieldName, _from, _to, string.Empty, (WebServiceProxy.SingleLayerProxy.DDADBType)AppData.Data.DBType).Result.Tables[0];
						break;
				}

				if(dataTable == null || dataTable.Rows.Count <= 0)
					return;

				if	(_fieldName.ToUpper() == "SlotNum".ToUpper())
				{
					ListViewItem item = new ListViewItem();
					item.Text = "Even";
					lvHeaderField.Items.Add(item);

					item = new ListViewItem();
					item.Text = "Odd";
					lvHeaderField.Items.Add(item);
				}

				foreach(DataRow row in dataTable.Rows)
				{
					if (row[0] != DBNull.Value && row[0] != null && row[0].ToString() != string.Empty)
					{
						ListViewItem item = new ListViewItem();
						item.Text = row[0].ToString();
						lvHeaderField.Items.Add(item);
					}
				}	
			}
			catch (System.Exception e)
			{
				MessageBox.Show(e.Message,ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error); 			 	
			}
		}

		private void lvHeaderField_DoubleClick(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void lvHeaderField_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			ListView listView = (ListView)sender;

			// Determine if clicked column is already the column that is being sorted.
			if ( e.Column == _lvwColumnSorter.SortColumn )
			{
				// Reverse the current sort direction for this column.
				if (_lvwColumnSorter.Order == SortOrder.Ascending)
					_lvwColumnSorter.Order = SortOrder.Descending;
				else
					_lvwColumnSorter.Order = SortOrder.Ascending;
			}
			else
			{
				// Set the column number that is to be sorted; default to ascending.
				_lvwColumnSorter.SortColumn = e.Column;
				_lvwColumnSorter.Order = SortOrder.Ascending;
			}

			// Perform the sort with these new sort options.
			lvHeaderField.Sort();
		}
		#endregion
	}
}
