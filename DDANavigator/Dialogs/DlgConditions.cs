using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Const;

namespace DDANavigator.Dialogs
{
	public class DlgConditions : FormBase
	{
		#region Members
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGridTableStyle dgTable1;
		private System.Windows.Forms.DataGrid dgData;
		private System.ComponentModel.Container components = null;
		DataTable dtCondition =new DataTable("dtCondition");
		ArrayList ConditionFields = new ArrayList();
		public bool bOrAnd = true;
		public  bool isNormal = true;
		private System.Windows.Forms.Button btnHint;
		private FunctionType _type = FunctionType.SingleLayer;
		private DateTime _from = DateTime.Now;
		private DateTime _to = DateTime.Now;
		private string fieldName = string.Empty;
		private bool _isViewUnknownSignature = false;
		private string _fabID = string.Empty;
		#endregion       

		#region Properties
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

		public string FieldName
		{
			set
			{
				fieldName = value;
			}
		}

		public string Condition
		{
			get
			{
				string sOperation;
				string	sResult = "";
				foreach(DataRow dr in dtCondition.Rows)
				{
					if( dr[0] is DBNull || dr[1]is DBNull || dr[2]is DBNull )
						return null;
                    
					sOperation  = dr[1].ToString().ToUpper();
					
					if(sResult=="")
					{
						if(dr[0].ToString() != WaferConst.SlotNoType && dr[0].ToString() != WaferConst.NumberOfDefect && dr[0].ToString() != WaferConst.NumberOfSignatureDefect && dr[0].ToString() != WaferConst.PercentOfSignatureDefect)
							sResult= dr[0].ToString() + " " + sOperation+ " '" + dr[2].ToString().Replace("'","")+"'";
						else
							sResult= dr[0].ToString() + " " + sOperation+ " " + dr[2].ToString().Replace("'","");
					}
					else
					{
						if(bOrAnd )
						{
							if(dr[0].ToString() != WaferConst.SlotNoType && dr[0].ToString() != WaferConst.NumberOfDefect && dr[0].ToString() != WaferConst.NumberOfSignatureDefect && dr[0].ToString() != WaferConst.PercentOfSignatureDefect)
								sResult+= " AND " + dr[0].ToString() + " " + sOperation + " '" + dr[2].ToString().Replace("'","")+"'";
							else
								sResult+= " AND " + dr[0].ToString() + " " + sOperation + " " + dr[2].ToString().Replace("'","");

						}
						else
						{
							if(dr[0].ToString() != WaferConst.SlotNoType && dr[0].ToString() != WaferConst.NumberOfDefect && dr[0].ToString() != WaferConst.NumberOfSignatureDefect && dr[0].ToString() != WaferConst.PercentOfSignatureDefect)
								sResult+= " OR " + dr[0].ToString() + " " + sOperation + " '" + dr[2].ToString().Replace("'","")+"'";
							else
								sResult+= " OR " + dr[0].ToString() + " " + sOperation + " " + dr[2].ToString().Replace("'","");

						}
					}

					sOperation=null;
				}
				return sResult;
			}
			set
			{
				string query=value.ToString() + " ";

				query = query.Replace ( " NOT LIKE ", " !~ " );

				query = query.Replace ( " LIKE ", " ~ " );

				query = query.Replace ( " <> ", " != " );

				query = query.Replace ( " AND ", " & " );

				query = query.Replace ( " OR ", " | " );  
				
				string []sAnd;
				if(bOrAnd)
					sAnd=query .Split("&".ToCharArray());
				else
					sAnd=query .Split("|".ToCharArray());

				

				foreach(string sExp in sAnd)
				{  
					string fieldname="";
					string operation="";
					object obj=null;					
					GetExpressOfEndQuery(sExp,ref fieldname,ref operation,ref obj);
					DataRow dr=dtCondition.NewRow();
					dr[0]=Convert.ToString(fieldname.Trim());
					dr[1]=Convert.ToString(operation.Trim());
					dr[2]=Convert.ToString(obj.ToString().Replace("'",""));
					dtCondition.Rows.Add(dr);
				}

				query=null;
				for(int i=0;i>sAnd.Length;i++)
					sAnd[i]=null;
				sAnd=null;
			}
		}

		public string FabID
		{
			get { return _fabID; }
			set { _fabID = value; }
		}
		#endregion

        #region Constructor & Dispose
		public DlgConditions(FunctionType type)
		{
			InitializeComponent();
			_type = type;
            InitData() ;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DlgConditions));
			this.dgData = new System.Windows.Forms.DataGrid();
			this.dgTable1 = new System.Windows.Forms.DataGridTableStyle();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnHint = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
			this.SuspendLayout();
			// 
			// dgData
			// 
			this.dgData.CaptionVisible = false;
			this.dgData.DataMember = "";
			this.dgData.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgData.Location = new System.Drawing.Point(8, 8);
			this.dgData.Name = "dgData";
			this.dgData.Size = new System.Drawing.Size(568, 296);
			this.dgData.TabIndex = 2;
			this.dgData.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																							   this.dgTable1});
			this.dgData.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
			// 
			// dgTable1
			// 
			this.dgTable1.DataGrid = this.dgData;
			this.dgTable1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgTable1.MappingName = "dtCondition";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(253, 320);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(173, 320);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 7;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(-16, 304);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(624, 8);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			// 
			// btnHint
			// 
			this.btnHint.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnHint.Location = new System.Drawing.Point(335, 320);
			this.btnHint.Name = "btnHint";
			this.btnHint.TabIndex = 9;
			this.btnHint.Text = "Hint";
			this.btnHint.Click += new System.EventHandler(this.btnHint_Click);
			// 
			// DlgConditions
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(582, 353);
			this.Controls.Add(this.btnHint);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.dgData);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DlgConditions";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Condition Properties";
			((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region UI Command
		private void GetExpressOfEndQuery(string expr, ref string fieldname, ref string operation, ref object value)
		{
			if(expr.IndexOf(">=") >= 0 )
			{
				string []sss = expr.Split(">=".ToCharArray());
				fieldname = sss[0];
				operation = ">=";
				value = Convert.ToString(sss[sss.Length - 1]);
			}
			else if(expr.IndexOf("<=") >= 0 )
			{
				string []sss = expr.Split("<=".ToCharArray());
				fieldname = sss[0];
				operation = "<=";
				value = Convert.ToString(sss[sss.Length - 1]);
			}
			else if(expr.IndexOf("!=") >= 0 )
			{
				string []sss = expr.Split("!=".ToCharArray());
				fieldname = sss[0];
				operation = "<>";
				value = Convert.ToString(sss[sss.Length - 1]);
			}
			else if( expr.IndexOf("=") >= 0 )
			{
				string []sss = expr.Split("=".ToCharArray());
				fieldname = sss[0];
				operation = "=";
				value = Convert.ToString(sss[sss.Length - 1]);
			}
			else if(expr.IndexOf(">") >= 0 )
			{
				string []sss = expr.Split(">".ToCharArray());
				fieldname = sss[0];
				operation = ">";
				value = Convert.ToString(sss[sss.Length - 1]);
			}
			else if(expr.IndexOf("<") >= 0 )
			{
				string []sss = expr.Split("<".ToCharArray());
				fieldname = sss[0];
				operation = "<";
				value = Convert.ToString(sss[sss.Length - 1]);
			}
			else if(expr.IndexOf("!~") >= 0 )
			{
				string []sss = expr.Split("!~".ToCharArray());
				fieldname = sss[0];
				operation = "NOT LIKE";
				value = Convert.ToString(sss[sss.Length - 1]);
			}
			else if(expr.IndexOf("~") >= 0 )
			{
				string []sss = expr.Split("~".ToCharArray());
				fieldname = sss[0];
				operation = "LIKE";
				value = Convert.ToString(sss[sss.Length - 1]);
			}
			
			value = ((string)value).Substring(1, ((string)value).Length - 2);
		}

		public string GetCurentFieldName()
		{
			int curRowIndex = dgData.CurrentRowIndex;

			if(curRowIndex < 0 ) 
				return string.Empty;
			
			if(dgData[curRowIndex,0]== null)
				return string.Empty;
			
			return dgData[curRowIndex,0].ToString();
		}

		public void SetFieldValue(string fieldValue)
		{
			int curRowIndex = dgData.CurrentRowIndex;

			if(curRowIndex < 0 ) 
				return ;
			
			dgData[curRowIndex,2] = fieldValue;
		}

        private void SetData()
        {          
			if (_type == FunctionType.SingleLayer)
			{
				ConditionFields.Add ( new ConditionField( WaferConst.TesterType, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Product, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.SlotNoType, ConditionFieldType.Number) ); 
				ConditionFields.Add ( new ConditionField( WaferConst.LotNo, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.LotIDCode, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.TesterGrade, ConditionFieldType.String));
				ConditionFields.Add ( new ConditionField( WaferConst.DDAGrade, ConditionFieldType.String));
				ConditionFields.Add ( new ConditionField( WaferConst.IRISBinNo, ConditionFieldType.String));
				ConditionFields.Add ( new ConditionField( WaferConst.Tester, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.TestCell, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.SignatureName, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.DiskID, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.CassetteID, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.NumberOfDefect, ConditionFieldType.Number ) ); 
				ConditionFields.Add ( new ConditionField( WaferConst.NumberOfSignatureDefect, ConditionFieldType.Number ) );
				ConditionFields.Add ( new ConditionField( WaferConst.PercentOfSignatureDefect, ConditionFieldType.Number ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc725, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc769, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc771, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc764, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc575, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc450, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc453, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc600, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc766, ConditionFieldType.String ) );
			}
			else if (_type == FunctionType.DataSource || _type == FunctionType.SignatureOfSurface)
			{
				ConditionFields.Add ( new ConditionField( WaferConst.TesterType, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Product, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.SlotNoType, ConditionFieldType.Number) ); 
				ConditionFields.Add ( new ConditionField( WaferConst.LotNo, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.LotIDCode, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.TesterGrade, ConditionFieldType.String));
				ConditionFields.Add ( new ConditionField( WaferConst.IRISBinNo, ConditionFieldType.String));
				ConditionFields.Add ( new ConditionField( WaferConst.Tester, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.TestCell, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.DiskID, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.CassetteID, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.NumberOfDefect, ConditionFieldType.Number ) ); 
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc725, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc769, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc771, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc764, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc575, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc450, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc453, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc600, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc766, ConditionFieldType.String ) );
			}
			else if (_type == FunctionType.SourceOfDisk)
			{
				ConditionFields.Add ( new ConditionField( WaferConst.TesterType, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Product, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.SlotNoType, ConditionFieldType.Number) ); 
				ConditionFields.Add ( new ConditionField( WaferConst.LotNo, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.LotIDCode, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.TesterGrade, ConditionFieldType.String));
				ConditionFields.Add ( new ConditionField( WaferConst.IRISBinNo, ConditionFieldType.String));
				ConditionFields.Add ( new ConditionField( WaferConst.Tester, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.TestCell, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.DiskID, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.CassetteID, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc725, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc769, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc771, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc764, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc575, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc450, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc453, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc600, ConditionFieldType.String ) );
				ConditionFields.Add ( new ConditionField( WaferConst.Rsc766, ConditionFieldType.String ) );
			}
        }

		public  void InitData()
		{
			SetData();
		
			dgTable1.GridColumnStyles.Clear();

			DataGriComboColumn colTemplate=new DataGriComboColumn();
			colTemplate.myCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			DataTable dtField=new DataTable();
			dtField.Columns.Add(new DataColumn("FieldName"));  
          

			DataRow dr = dtField.NewRow();

			foreach ( ConditionField item  in ConditionFields )
			{
				dr = dtField.NewRow();
				dr[0]      = item.Name;
				dtField.Rows.Add(dr);
			}

			colTemplate.Setdata(dtField,"FieldName");
			colTemplate.Width=250;
			colTemplate.MappingName="Name";
			colTemplate.HeaderText="Selected Field";
			dgTable1.GridColumnStyles.Add(colTemplate);

			dtField=new DataTable();
			colTemplate=new DataGriComboColumn();
			colTemplate.myCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			dtField=new DataTable();
			dtField.Columns.Add(new DataColumn("Criteria"));
			
			string []sss={"LIKE","=",">",">=","<="};
			for(int i = 0; i < sss.Length; i++)
			{
				dr=dtField.NewRow();
				dr[0]=sss[i];
				dtField.Rows.Add(dr);
			}
			colTemplate.Setdata(dtField,"Criteria");
			colTemplate.Width= 80;
			colTemplate.MappingName="Criteria";
			colTemplate.HeaderText="Criteria";
			dgTable1.GridColumnStyles.Add(colTemplate);

			DataGridTextBoxColumn coltextbox=new DataGridTextBoxColumn();
			coltextbox.Width=180;
			coltextbox.MappingName="Value";
			coltextbox.HeaderText="Value";
			dgTable1.GridColumnStyles.Add(coltextbox);

			dgTable1.AllowSorting = false;

			DataColumn dcColumn=new DataColumn("Name");
			
			dtCondition.Columns.Add(dcColumn);

			dcColumn=new DataColumn("Criteria");			
			dtCondition.Columns.Add(dcColumn);

			dcColumn=new DataColumn("Value",Type.GetType("System.String"));			
			dtCondition.Columns.Add(dcColumn);

			dgData.DataSource=dtCondition;

            
		}

        private void ResetDataGridTableStyle( ArrayList alCriteria , string fieldName)
        {
            DataTable dtField=new DataTable();
            dtField.Columns.Add(new DataColumn("FieldName"));			
            dtField=new DataTable();			
            dtField=new DataTable();
            dtField.Columns.Add(new DataColumn("Criteria"));
			
            for(int i = 0; i < alCriteria.Count; i++)
            {
                DataRow dr=dtField.NewRow();
                dr[0]=alCriteria[i];
                dtField.Rows.Add(dr);
            }
            ((DataGriComboColumn)dgTable1.GridColumnStyles[1]).Setdata(dtField,"Criteria");	
			
            dgTable1.GridColumnStyles.RemoveAt(2);

            ConditionFieldType type = GetFieldType ( fieldName );
            
			

            if ( type == ConditionFieldType.Date  )
            {
                DataGridStringTimePickerColumn colTemplate=new DataGridStringTimePickerColumn();
                colTemplate.MappingName="Value";
                colTemplate.HeaderText="Value";
                colTemplate.Format=DateTimePickerFormat.Custom ;
                colTemplate.CustomFormat="MM-dd-yyyy";
                colTemplate.Width=180;								
                dgTable1.GridColumnStyles.Add(colTemplate);
            }
            else if (  type == ConditionFieldType.Time  )
            {
                DataGridStringTimePickerColumn colTemplate=new DataGridStringTimePickerColumn();
                colTemplate.MappingName="Value";
                colTemplate.HeaderText="Value";
                colTemplate.Format=DateTimePickerFormat.Custom ;
                colTemplate.CustomFormat="HH:mm:ss";
                colTemplate.ShowTime=true;
                colTemplate.Width=180;				
                dgTable1.GridColumnStyles.Add(colTemplate);
            }
            else if ( type == ConditionFieldType.Boolean )
            {
                DataGriComboColumn colTemplate=new DataGriComboColumn();
                colTemplate.myCombo.DropDownStyle = ComboBoxStyle.DropDownList;
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("FieldValue"));          
               
                DataRow dr = dt.NewRow();
                dr[0]      = "TRUE";
                dt.Rows.Add(dr);

                dr      = dt.NewRow();
                dr[0]   = "FALSE";
                dt.Rows.Add(dr);     
           
                colTemplate.Setdata(dt,"FieldValue");
                colTemplate.Width=180;
                colTemplate.MappingName="Value";
                colTemplate.HeaderText="Value";
				
                dgTable1.GridColumnStyles.Add( colTemplate );
				
            }
            else
            {
                DataGridTextBoxColumn coltextbox=new DataGridTextBoxColumn();
                coltextbox.Width =180;
                coltextbox.MappingName="Value";
                coltextbox.HeaderText="Value";
				
                dgTable1.GridColumnStyles.Add(coltextbox);				
				
            }
        }

        public void ShowCondition(string strCondition)
        {
            dtCondition.Rows.Clear();
            DataRow DR=dtCondition.NewRow();
            DR[0]=strCondition;
            dtCondition.Rows.Add(DR);
        }

        private ConditionFieldType GetFieldType ( string name )
        {
            foreach ( ConditionField item in ConditionFields )
            {
                if ( name.ToUpper() == item.Name.ToUpper() ) return item.FieldType;
            }

            return ConditionFieldType.String;
        }

        private bool IsDateTime( string text )
        {
            try
            {
                DateTime.Parse (  text );					
            }
            catch { return false ; }
            return true;
        }

        public void UpdateDatatable()
        {
            try
            {
                foreach ( DataRow row in dtCondition.Rows )
                {
                    ConditionFieldType type = GetFieldType( (string)row[0] );
                    if ( type  == ConditionFieldType.Date )
                    {
                        DateTime s = Convert.ToDateTime( row[2]);
                        row[2] =s.ToString("MM-dd-yyyy");
                    }
                    else if ( type  == ConditionFieldType.Time )
                    {
                        DateTime s = Convert.ToDateTime( row[2]);
                        row[2] =s.ToString("HH:mm:ss");
                    }
                }
            }
            catch{};
        }
		               
        private bool CriteriaValidation(ConditionFieldType type , string Criteria)
        {	
            Criteria = Criteria.ToUpper();
            switch ( type )
            {
                case ConditionFieldType.Date:						
                case ConditionFieldType.Time:						
                    return !( Criteria == "LIKE" || Criteria == ">" || Criteria == "<" || Criteria == "<>" || Criteria == "NOT LIKE"  ); 						
                case ConditionFieldType.String:				
                    return !( Criteria != "LIKE" && Criteria != "="  && Criteria != "NOT LIKE"  && Criteria != "<>");						                
                case ConditionFieldType.Number:
                    return !( Criteria == "LIKE" || Criteria == "NOT LIKE" );	
            }	
            return true;
        }

        private bool Validation(ref string errmess )
        {
            int  index=-1;
            foreach ( DataRow row in dtCondition.Rows )
            {
                index++;
                try
                {
                    if( row[0] is DBNull || row[1]is DBNull || row[2]is DBNull )
                    {
                        dgData.Select(index);
                        errmess = " Value cannot be 'null'";
                        return false;
                    }

                    ConditionFieldType type = GetFieldType( (string)row[0] );
					
                    if ( !CriteriaValidation(type,(string)row[1]))
                    {
                        dgData.Select(index);
                        errmess = "The selected criteria must be compatible with the selected field.";
                        return false;
                    }

                    if ( ((string)row[2]).IndexOf("=")>=0 ||
                        ((string)row[2]).IndexOf(">=")>=0 ||	
                        ((string)row[2]).IndexOf("<=")>=0 ||
                        ((string)row[2]).IndexOf(">")>=0 ||
                        ((string)row[2]).IndexOf("<")>=0 ||
                        ((string)row[2]).IndexOf("~")>=0 
                        )
                    {
                        dgData.Select(index);
                        errmess = " Value cannot contain: =,>,<,>=,<=,~.";
                        return false;
                    }

                    if ( type == ConditionFieldType.Date )
                    {
                        errmess = "Date value must be in correct format(MM-DD-YYYY)."; 
                        row[0] = ((string)row[0]).Trim();
                        Convert.ToDateTime ( row[2] );
                    }
                    else if ( type == ConditionFieldType.Time  )
                    {
                        errmess = "Time value must be in correct format(HH:MM:SS)."; 
                        row[0] = ((string)row[0]).Trim();
                        Convert.ToDateTime ( row[2] );
                    }
                    else if ( type == ConditionFieldType.Number )
                    {
                        errmess = (string)row[0]+ " must be a number.";
                        row[0] = ((string)row[0]).Trim();
                        Convert.ToSingle ( row[2]);
                    }   

                }
                catch 
                { 
                    dgData.Select(index);
                    return false;
                }
            }

            if ( dtCondition.Rows.Count <= 0 ) 
            {
                errmess = "Please input condition parameters.";
                dgData.Focus();
                dgData.Select(0);
                return false;
            }
            return true;
        }
        
        #endregion

		#region Windows Event Handle
        private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            int colIdex = dgData.CurrentCell.ColumnNumber;	
				
            UpdateDatatable();
            ArrayList al = new ArrayList();
		
            if (colIdex  == 0 || colIdex  == 1 || colIdex == 2)
            {	
                string fieldName = "";				
                try
                {
                    fieldName =  dgData[dgData.CurrentCell.RowNumber,0].ToString().ToUpper();
                }
                catch {} ;

                ConditionFieldType type = GetFieldType( fieldName );
                switch ( type )
                {
                    case ConditionFieldType.Date:
                        al.Add("=");						
                        al.Add(">=");
                        al.Add("<=");
                        if  (dgData[dgData.CurrentCell.RowNumber,2] is DBNull || !IsDateTime((string)dgData[dgData.CurrentCell.RowNumber,2] ) )
                            dgData[dgData.CurrentCell.RowNumber,2] = DateTime.Now.ToString("MM-dd-yyyy");
                        break;
                    case ConditionFieldType.Time:
                        al.Add("=");						
                        al.Add(">=");
                        al.Add("<=");						
                        if  (dgData[dgData.CurrentCell.RowNumber,2] is DBNull || !IsDateTime((string)dgData[dgData.CurrentCell.RowNumber,2] ) )
                            dgData[dgData.CurrentCell.RowNumber,2] = DateTime.Now.ToString("00:00:00");
                        break;
                    case ConditionFieldType.String:                    					
                        al.Add("LIKE");	
                        al.Add("NOT LIKE");						
                        al.Add("=");
                        al.Add("<>");						
                        break;
                    case ConditionFieldType.Number:                    				
                        al.Add("=");
                        al.Add("<>");
                        al.Add(">");					
                        al.Add("<");					
                        al.Add(">=");
                        al.Add("<=");												
                        break;	
				   case ConditionFieldType.Boolean: 
                        al.Add("IS");
                        break;
                }

                if ( al.Count <=0 ) 
                {
                    al.Add("LIKE");												
                    al.Add("=");						
                }
                ResetDataGridTableStyle(al,fieldName);
            }
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            string errMesage = string.Empty;

            if ( !Validation( ref errMesage ) )
            {
                MessageBox.Show(errMesage, Application.ProductName, MessageBoxButtons.OK,MessageBoxIcon.Error);		
                DialogResult = DialogResult.None;
                return;
            }

            UpdateDatatable();

        }

		private void btnHint_Click(object sender, System.EventArgs e)
		{	
			Cursor.Current = Cursors.WaitCursor;
			string fieldName = GetCurentFieldName();

			if(fieldName == string.Empty)
			{
				MessageBox.Show("Please select a field.", ProductName);
				return;
			}
//			else if(fieldName == WaferConst.TestGrade)
//			{
//				MessageBox.Show("There is no hint information for bin num.", ProductName);
//				return;
//			}
			else if(fieldName == WaferConst.SlotNoType)
			{
				MessageBox.Show("There is no hint information for slot num.", ProductName);
				return;
			}
			else if(fieldName == WaferConst.NumberOfDefect)
			{
				MessageBox.Show("There is no hint information for number of defect.", ProductName);
				return;
			}
			else if(fieldName == WaferConst.NumberOfSignatureDefect)
			{
				MessageBox.Show("There is no hint information for number of signature defect.", ProductName);
				return;
			}
			else if(fieldName == WaferConst.PercentOfSignatureDefect)
			{
				MessageBox.Show("There is no hint information for percent of signature defect.", ProductName);
				return;
			}

			DlgConditionHint dlg = new DlgConditionHint(_fabID, _from, _to, GetCurentFieldName(), _type, false, _isViewUnknownSignature);

			if(dlg.ShowDialog()== DialogResult.OK)
			{
				SetFieldValue(dlg.FieldValue);
			}
		}
        #endregion
	}
}
