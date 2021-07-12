/*
 * update 2004-07-27 by cang 
 * 
 * */

using System;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using System.IO;
//using SSA.MyCustomControls.InheritedCombo;


/*
 * HOW TO USE
 * ----------
 	1. On load form call
  			PersistenceDefault obj=new PersistenceDefault(this);
			obj.Load();
	2. On OK button call
			PersistenceDefault obj=new PersistenceDefault(this);
			obj.Save();
	3. Set All control which you want set default with TAG=DEFAULT			

 * */


namespace SiGlaz.Utility
{
	/// <summary>
	/// Summary description for PersistenceDefault.
	/// </summary>
	public class PersistenceDefaultForm
	{
		public 	bool	_persis;
		private	Form	_formpersis;
		private string	_filename;

		public bool loadEnableState = true;
		public bool loadVisibleState = true;

		public	static string	DefaultFolder
		{
			get
			{
				string  path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"DefaultData");
				if( !Directory.Exists(path) )
					Directory.CreateDirectory(path);
				return path;
			}
		}

		public PersistenceDefaultForm(Form formpersis): this(formpersis, string.Empty)
		{
		}
		public PersistenceDefaultForm(Form formpersis, string z_filename)
		{
			_persis=true;
			if(formpersis==null)	
			{
				_persis=false;
				return;
			}
			try
			{
				_formpersis=formpersis;
				if (z_filename == string.Empty)
					_filename= DefaultFolder + "\\" + _formpersis.Name + ".xml";
				else
				{
					_filename = z_filename;
					string _dir = Path.GetDirectoryName(_filename);
					if( !Directory.Exists(_dir))
						Directory.CreateDirectory(_dir);
				}
			}
			catch
			{
				_persis=false;
			}
		}


		public void	Load()
		{
			if(!_persis) return;

			if(!File.Exists(_filename))
				return;

			try
			{
				DataSet ds=new DataSet(_formpersis.Name);
				ds.ReadXml(_filename);
				ReadControlDefaul(_formpersis,ds);
			}
			catch
			{
			}
		}


		public void Save()
		{
			if(!_persis) return;

			if(File.Exists(_filename)) 
			{
				File.SetAttributes(_filename,FileAttributes.Normal);
				File.Delete(_filename);
			}

			try
			{
				DataSet ds=new DataSet(_formpersis.Name);
				ds.Tables.Add(new DataTable());
				ds.Tables[0].Columns.Add(new DataColumn("NAME"));
				ds.Tables[0].Columns.Add(new DataColumn("VALUE"));
				ds.Tables[0].Columns.Add(new DataColumn("ENABLE",typeof(bool)));
				ds.Tables[0].Columns.Add(new DataColumn("VISIBLE",typeof(bool)));

				WriteControlDefaul(_formpersis,ds);

				ds.WriteXml(_filename,XmlWriteMode.IgnoreSchema);
			}
			catch
			{

			}
		}


		public void ReadControlDefaul(Control  parent,DataSet ds)
		{
			foreach(Control ctrl in parent.Controls)
			{
				if(ctrl.Tag!=null && ctrl.Tag.ToString()=="DEFAULT")				
				{
					//Get Value 
					DataRow []row=ds.Tables[0].Select("NAME='" + ctrl.Name + "'");
					if(row!=null && row.Length ==1)
					{
						string svalue=row[0]["VALUE"].ToString();

						//Check type of control
						if( ctrl.GetType()== typeof(CheckBox) )
						{
							((CheckBox)ctrl).Checked = bool.Parse(svalue);
						}
						else if( ctrl.GetType()== typeof(RadioButton) )
						{
							((RadioButton)ctrl).Checked = bool.Parse(svalue);
						}
						else if(ctrl.GetType()== typeof(NumericUpDown ) )
						{
							Decimal xxx=Decimal.Parse(svalue);

							if( xxx<  ((NumericUpDown )ctrl).Minimum)
								xxx=((NumericUpDown )ctrl).Minimum;

							if( xxx>  ((NumericUpDown )ctrl).Maximum)
								xxx=((NumericUpDown )ctrl).Maximum;

							((NumericUpDown )ctrl).Value = xxx;

						}
						else if(ctrl.GetType()== typeof(TextBox) )
						{
							((TextBox)ctrl).Text = svalue;
						}
						else if(ctrl.GetType() == typeof(ComboBox))
						{
							((ComboBox)ctrl).SelectedIndex = Int32.Parse(svalue);
						}
//						else if(ctrl.GetType() == typeof(MultiColumnComboBox))
//						{
//							((MultiColumnComboBox)ctrl).Text = svalue;
//						}
						else if(ctrl.GetType()==typeof(ListBox))
						{
							(ctrl as ListBox).Items.Clear();
							string delimStr = "\n";
							string [] _items = svalue.Split(delimStr.ToCharArray());
							foreach (string _item in _items)
							{
								(ctrl as ListBox).Items.Add(_item);
							}
						}
						else  if(ctrl.GetType() == typeof(DateTimePicker))
						{
							((DateTimePicker)ctrl).Value = Convert.ToDateTime(svalue);
						}


						if (loadEnableState)
							ctrl.Enabled = bool.Parse(row[0]["ENABLE"].ToString());
						//						else
						//							ctrl.Enabled = true;

						if (loadVisibleState)
							ctrl.Visible = bool.Parse(row[0]["VISIBLE"].ToString());
						//						else
						//							ctrl.Visible = true;
					}
				}
				if( ctrl.Controls.Count >0)
					ReadControlDefaul(ctrl,ds);
			}
		}


		public void	WriteControlDefaul(Control parent,DataSet ds)
		{
			foreach(Control ctrl in parent.Controls)
			{
				if(ctrl.Tag!=null && ctrl.Tag.ToString()=="DEFAULT")				
				{
					//Get Value 
					DataRow row=ds.Tables[0].NewRow();
					row["NAME"]=ctrl.Name;

					string svalue="";

					//Check type of control
					if( ctrl.GetType()== typeof(CheckBox) )
					{
						svalue=((CheckBox)ctrl).Checked.ToString();
					}
					else if( ctrl.GetType()== typeof(RadioButton) )
					{
						svalue=((RadioButton)ctrl).Checked.ToString();
					}
					else if(ctrl.GetType()== typeof(NumericUpDown ) )
					{
						svalue=((NumericUpDown )ctrl).Value.ToString();
					}
					else if(ctrl.GetType() == typeof(TextBox) )
					{
						svalue=((TextBox)ctrl).Text;
					} 
					else if(ctrl.GetType() == typeof(ComboBox))
					{
						svalue=((ComboBox)ctrl).SelectedIndex.ToString();
					}
						
//					else if(ctrl.GetType()==typeof(MultiColumnComboBox))
//					{
//						svalue=((MultiColumnComboBox)ctrl).Text;
//					}

					else if(ctrl.GetType()==typeof(ListBox))
					{
						svalue="";
						for (int i=0;i<(ctrl as ListBox).Items.Count;i++)
						{
							svalue += string.Format("{0}\n",(ctrl as ListBox).Items[i].ToString());
						}
					}
					else if(ctrl.GetType()==typeof(DateTimePicker))
					{
						svalue=((DateTimePicker)ctrl).Text;
					}

					row["VALUE"]=svalue;
					row["ENABLE"]=ctrl.Enabled;
					row["VISIBLE"]=ctrl.Visible;

					ds.Tables[0].Rows.Add(row);
				}
				if( ctrl.Controls.Count >0)
					WriteControlDefaul(ctrl,ds);
			}

		}
	}
}
