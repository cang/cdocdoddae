using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections;
using SiGlaz.Common.DDA.Const;

namespace SiGlaz.Common.DDA.Basic
{
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://siglaz.com")]
	public class TableLayout
	{
		private int _pageindex=0;//changed
		private int _pageSize=10;//default

		private ArrayList _displayColumns;
		private string _orderBy;

		public int PageIndex
		{
			get { return _pageindex + 1; }
			set { _pageindex = value - 1; }
		}

		public int PagePosition
		{
			get { return _pageindex*PageSize; }
		}

		public int PageSize
		{
			get { return _pageSize; }
			set { _pageSize = value; }
		}

		public void Clear()
		{
			_displayColumns.Clear();
		}

		public void AddColumnName(string column)
		{
			_displayColumns.Add(column);
		}

		public string[] DisplayColumns
		{
			get 
			{ 
				return (string[])_displayColumns.ToArray(typeof(string));
			}
			set 
			{
				_displayColumns.Clear();
				if (value != null)
					_displayColumns.AddRange(value);
			}
		}


		public string OrderBy
		{
			get { return _orderBy; }
			set { _orderBy = value; }
		}


		public TableLayout(bool isSignature)
		{
			_displayColumns = new ArrayList();

			this.PageSize = 10;
			this.OrderBy =  string.Empty;

			if (!isSignature)
				this._displayColumns.AddRange(Const.WaferConst.DataSource);
			else
				this._displayColumns.AddRange(Const.WaferConst.SingleLayer);
		}

		public TableLayout()
		{
			_displayColumns = new ArrayList();

			this.PageSize = 10;
			this.OrderBy =  string.Empty;
		}

		public void GetDefault_SourceOfSurface()
		{
			this._displayColumns.AddRange(Const.WaferConst.DataSource);
		}

		public void GetDefault_SourceOfDisk()
		{
			this._displayColumns.AddRange(Const.WaferConst.SourceOfDisk);
		}

		public static int GetTotalages(int total,int size)
		{
			return (int)Math.Ceiling( (double)total/size);
		}


		public TableLayout Copy()
		{
			TableLayout tableLayout = new TableLayout();
			tableLayout.DisplayColumns = (string[])this._displayColumns.ToArray(typeof(string));
			tableLayout.PageSize = this.PageSize;
			return tableLayout;
		}

		#region Serialize & Deserialize
		public bool Serialize(string fileName)
		{
			FileStream  fs = null;
			try
			{
				fs = new FileStream( fileName, FileMode.Create,FileAccess.Write, FileShare.ReadWrite );
				XmlSerializer s = new XmlSerializer( typeof(TableLayout) );

				s.Serialize( fs, this );	
                
				return true;
			}
			catch
			{
				return false;
			}
			finally
			{
				if(fs != null)
					fs.Close();
			}
		}

		public bool Deserialze(string fileName)
		{
			FileStream      fs      = null;
			XmlSerializer   s       = null;

			try
			{
				fs  = new FileStream( fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite );
				s   = new XmlSerializer(typeof(TableLayout));
				TableLayout tableLayout = (TableLayout) s.Deserialize( fs );

				//Set data
				DisplayColumns = tableLayout.DisplayColumns;
				PageSize = tableLayout.PageSize;
				//End set data

				return true;
			}
			catch
			{
				return false;
			}
			finally
			{
				if(s != null)
					s = null;

				if(fs != null)
					fs.Close();
			}

			
		}

		#endregion

		#region Static Methods
		public static TableLayout GetTableLayoutConfig(FunctionType type)
		{
			TableLayout tableLayout = null;

			if (AppData.CommonTableLayout != null)
				tableLayout = AppData.CommonTableLayout.Copy();

			if (tableLayout == null) return null;

			ArrayList columnNames = null;
			switch (type)
			{
				case FunctionType.DataSource:
				case FunctionType.SignatureOfSurface:
					columnNames = new ArrayList();
					foreach (string name in tableLayout.DisplayColumns)
					{
						if (name != WaferConst.DDAGrade && name != WaferConst.SignatureName && name != WaferConst.NumberOfSignatureDefect && name != WaferConst.PercentOfSignatureDefect)
							columnNames.Add(name);
					}

					tableLayout.DisplayColumns = (string[])columnNames.ToArray(typeof(string));
					return tableLayout;

				case FunctionType.SourceOfDisk:
					columnNames = new ArrayList();
					foreach (string name in tableLayout.DisplayColumns)
					{
						if (name != WaferConst.DDAGrade && name != WaferConst.SignatureName && name != WaferConst.NumberOfSignatureDefect && name != WaferConst.PercentOfSignatureDefect && name != WaferConst.Surface && name != WaferConst.TestDate && name != WaferConst.NumberOfDefect)
							columnNames.Add(name);
					}

					tableLayout.DisplayColumns = (string[])columnNames.ToArray(typeof(string));
					return tableLayout;

				default:
					return tableLayout;
			}
		}

		public static void SetTableLayoutConfig(TableLayout tableLayoutNew, FunctionType type)
		{
			ArrayList columnNames = null;

			switch (type)
			{
				case FunctionType.DataSource:
				case FunctionType.SignatureOfSurface:
					if (AppData.CommonTableLayout != null)
					{
						columnNames = new ArrayList();
						columnNames.AddRange(tableLayoutNew.DisplayColumns);

						for (int i = 0; i < AppData.CommonTableLayout.DisplayColumns.Length; i++)
						{
							string name = AppData.CommonTableLayout.DisplayColumns[i];
							if ((name == WaferConst.DDAGrade || name == WaferConst.SignatureName || name == WaferConst.NumberOfSignatureDefect || name == WaferConst.PercentOfSignatureDefect) && !columnNames.Contains(name))
							{
								if (i <= columnNames.Count)
									columnNames.Insert(i, name);
								else
									columnNames.Add(name);
							}
						}

						AppData.CommonTableLayout.DisplayColumns = (string[])columnNames.ToArray(typeof(string));
						AppData.CommonTableLayout.PageSize = tableLayoutNew.PageSize;
					}
					else
						AppData.CommonTableLayout = tableLayoutNew;
					
					break;

				case FunctionType.SourceOfDisk:
					if (AppData.CommonTableLayout != null)
					{
						columnNames = new ArrayList();
						columnNames.AddRange(tableLayoutNew.DisplayColumns);

						for (int i = 0; i < AppData.CommonTableLayout.DisplayColumns.Length; i++)
						{
							string name = AppData.CommonTableLayout.DisplayColumns[i];
							if ((name == WaferConst.Surface || name == WaferConst.TestDate || name == WaferConst.NumberOfDefect || name == WaferConst.DDAGrade || name == WaferConst.SignatureName || name == WaferConst.NumberOfSignatureDefect || name == WaferConst.PercentOfSignatureDefect) && !columnNames.Contains(name))
								columnNames.Add(name);
						}

						AppData.CommonTableLayout.DisplayColumns = (string[])columnNames.ToArray(typeof(string));
						AppData.CommonTableLayout.PageSize = tableLayoutNew.PageSize;
					}
					else
						AppData.CommonTableLayout = tableLayoutNew;

					break;

				default:
					AppData.CommonTableLayout = tableLayoutNew;
					break;
			}
		}
		#endregion
	}
}
