using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace SiGlaz.Common.DDA
{


	// This example shows how to create your own column style that
	// hosts a control, in this case, a DateTimePicker.
	public class DataGridStringTimePickerColumn : DataGridColumnStyle 
	{
		public DateTimePicker myDateTimePicker = new DateTimePicker();
		// The isEditing field tracks whether or not the user is
		// editing data with the hosted control.
		private bool isEditing;

		public DataGridStringTimePickerColumn() : base() 
		{
			myDateTimePicker.Visible = false;
		}

		protected override void Abort(int rowNum)
		{
			isEditing = false;
			myDateTimePicker.ValueChanged -= 
				new EventHandler(TimePickerValueChanged);
			Invalidate();

		}

		protected override bool Commit
			(CurrencyManager dataSource, int rowNum) 
		{
			myDateTimePicker.Bounds = Rectangle.Empty;
         
			myDateTimePicker.ValueChanged -= 
				new EventHandler(TimePickerValueChanged);

			if (!isEditing)
				return true;

			isEditing = false;

			try 
			{
				DateTime value = myDateTimePicker.Value;
				SetColumnValueAtRow(dataSource, rowNum, value);
			} 
			catch (Exception) 
			{
				Abort(rowNum);
				return false;
			}

			Invalidate();
			return true;
		}


		protected override void Edit(
			CurrencyManager source, 
			int rowNum,
			Rectangle bounds, 
			bool readOnly,
			string instantText, 
			bool cellIsVisible) 
		{
			foreach(DataGridColumnStyle col in DataGridTableStyle.GridColumnStyles)
			{
				if( col.GetType()==typeof( DataGridStringTimePickerColumn) )
					((DataGridStringTimePickerColumn)col).myDateTimePicker.Visible=false;
			}
			//DataGridTableStyle.DataGrid.Invalidate(true);

			if ( GetColumnValueAtRow(source, rowNum)is DBNull )
				return;
			string  date = (string) GetColumnValueAtRow(source, rowNum);
			try
			{
				DateTime.Parse ( date );
			}
			catch { return ; }

			DateTime  value = Convert.ToDateTime( date );//(DateTime)GetColumnValueAtRow(source, rowNum);

			if (cellIsVisible) 
			{
				myDateTimePicker.Bounds = new Rectangle
					(bounds.X , bounds.Y , 
					bounds.Width , bounds.Height );
				myDateTimePicker.Value = value;
				myDateTimePicker.Visible = true;
				myDateTimePicker.ValueChanged += 
					new EventHandler(TimePickerValueChanged);
			} 
			else 
			{
				myDateTimePicker.Value = value;
				myDateTimePicker.Visible = false;
			}

			if (myDateTimePicker.Visible)
				DataGridTableStyle.DataGrid.Invalidate(bounds);
				
		}

		protected override Size GetPreferredSize(
			Graphics g, 
			object value) 
		{
			return new Size(100, myDateTimePicker.PreferredHeight + 4);
		}

		protected override int GetMinimumHeight() 
		{
			return myDateTimePicker.PreferredHeight + 4;
		}

		protected override int GetPreferredHeight(Graphics g, 
			object value) 
		{
			return myDateTimePicker.PreferredHeight + 4;
		}

		protected override void Paint(Graphics g, 
			Rectangle bounds, 
			CurrencyManager source, 
			int rowNum) 
		{
			Paint(g, bounds, source, rowNum, false);
		}
		protected override void Paint(
			Graphics g, 
			Rectangle bounds,
			CurrencyManager source, 
			int rowNum,
			bool alignToRight) 
		{
			Paint(
				g,bounds, 
				source, 
				rowNum, 
				Brushes.Red, 
				Brushes.Blue, 
				alignToRight);
		}
		protected override void Paint(
			Graphics g, 
			Rectangle bounds,
			CurrencyManager source, 
			int rowNum,
			Brush backBrush, 
			Brush foreBrush,
			bool alignToRight) 
		{
			if ( GetColumnValueAtRow(source, rowNum)is DBNull )
				return;
			string strDate = (string) 
				GetColumnValueAtRow(source, rowNum);			

			try
			{
				DateTime.Parse ( strDate );
			}
			catch { return ;}

			
			DateTime date = DateTime.Parse ( strDate );
			
			

			Rectangle rect = bounds;
			g.FillRectangle(backBrush,rect);
			rect.Offset(0, 2);
			rect.Height -= 2;

			if( Format==DateTimePickerFormat.Time )
				g.DrawString(date.ToString("hh:mm:ss"), 
					this.DataGridTableStyle.DataGrid.Font, 
					foreBrush, rect);
			else if(Format==DateTimePickerFormat.Short )
				g.DrawString(date.ToString("MM-dd-yyyy"), 
					this.DataGridTableStyle.DataGrid.Font, 
					foreBrush, rect);
			else if ( strDate.IndexOf ( ":") >= 0)
				{
					g.DrawString(date.ToString("HH:mm:ss"), 
						this.DataGridTableStyle.DataGrid.Font, 
						foreBrush, rect);
				}
				else
				{
					g.DrawString(date.ToString("MM-dd-yyyy"), 
						this.DataGridTableStyle.DataGrid.Font, 
						foreBrush, rect);
				}
//				g.DrawString(date.ToString(CustomFormat), 
//					this.DataGridTableStyle.DataGrid.Font, 
//					foreBrush, rect);
		}

		protected override void SetDataGridInColumn(DataGrid value) 
		{
			base.SetDataGridInColumn(value);
			if (myDateTimePicker.Parent != null) 
			{
				myDateTimePicker.Parent.Controls.Remove 
					(myDateTimePicker);
			}
			if (value != null) 
			{
				value.Controls.Add(myDateTimePicker);
			}
		}

		private void TimePickerValueChanged(object sender, EventArgs e) 
		{
			this.isEditing = true;
			base.ColumnStartedEditing(myDateTimePicker);
		}

		public DateTimePickerFormat  Format
		{
			get
			{
				return myDateTimePicker.Format;

			}
			set
			{
				myDateTimePicker.Format=value;
			}
		}

		public string CustomFormat
		{
			get
			{
				return myDateTimePicker.CustomFormat;

			}
			set
			{
				myDateTimePicker.CustomFormat=value;
			}
		}
		public bool	ShowTime
		{
			get
			{
				return myDateTimePicker.ShowUpDown;
			}
			set
			{
				myDateTimePicker.ShowUpDown=value;
			}
		}
	}

	public class DataTimePickerColumn : DataGridColumnStyle 
	{
		public DateTimePicker myDateTimePicker = new DateTimePicker();
		// The isEditing field tracks whether or not the user is
		// editing data with the hosted control.
		private bool isEditing;

		public DataTimePickerColumn() : base() 
		{
			myDateTimePicker.Visible = false;
		}

		protected override void Abort(int rowNum)
		{
			isEditing = false;
			myDateTimePicker.ValueChanged -= 
				new EventHandler(TimePickerValueChanged);
			Invalidate();

		}

		protected override bool Commit
			(CurrencyManager dataSource, int rowNum) 
		{
			myDateTimePicker.Bounds = Rectangle.Empty;
         
			myDateTimePicker.ValueChanged -= 
				new EventHandler(TimePickerValueChanged);

			if (!isEditing)
				return true;

			isEditing = false;

			try 
			{
				DateTime value = myDateTimePicker.Value;
				SetColumnValueAtRow(dataSource, rowNum, value);
			} 
			catch (Exception) 
			{
				Abort(rowNum);
				return false;
			}

			Invalidate();
			return true;
		}


		protected override void Edit(
			CurrencyManager source, 
			int rowNum,
			Rectangle bounds, 
			bool readOnly,
			string instantText, 
			bool cellIsVisible) 
		{
			foreach(DataGridColumnStyle col in DataGridTableStyle.GridColumnStyles)
			{
				if( col.GetType()==typeof( DataTimePickerColumn) )
					((DataTimePickerColumn)col).myDateTimePicker.Visible=false;
			}
			//DataGridTableStyle.DataGrid.Invalidate(true);

			if ( GetColumnValueAtRow(source, rowNum)is DBNull )
				return;
			string  date = (string) GetColumnValueAtRow(source, rowNum);
			try
			{
				DateTime.Parse ( date );
			}
			catch { return ; }

			DateTime  value = Convert.ToDateTime( date );//(DateTime)GetColumnValueAtRow(source, rowNum);

			if (cellIsVisible) 
			{
				myDateTimePicker.Bounds = new Rectangle
					(bounds.X , bounds.Y , 
					bounds.Width , bounds.Height );
				myDateTimePicker.Value = value;
				myDateTimePicker.Visible = true;
				myDateTimePicker.ValueChanged += 
					new EventHandler(TimePickerValueChanged);
			} 
			else 
			{
				myDateTimePicker.Value = value;
				myDateTimePicker.Visible = false;
			}

			if (myDateTimePicker.Visible)
				DataGridTableStyle.DataGrid.Invalidate(bounds);
				
		}

		protected override Size GetPreferredSize(
			Graphics g, 
			object value) 
		{
			return new Size(100, myDateTimePicker.PreferredHeight + 4);
		}

		protected override int GetMinimumHeight() 
		{
			return myDateTimePicker.PreferredHeight + 4;
		}

		protected override int GetPreferredHeight(Graphics g, 
			object value) 
		{
			return myDateTimePicker.PreferredHeight + 4;
		}

		protected override void Paint(Graphics g, 
			Rectangle bounds, 
			CurrencyManager source, 
			int rowNum) 
		{
			Paint(g, bounds, source, rowNum, false);
		}
		protected override void Paint(
			Graphics g, 
			Rectangle bounds,
			CurrencyManager source, 
			int rowNum,
			bool alignToRight) 
		{
			Paint(
				g,bounds, 
				source, 
				rowNum, 
				Brushes.Red, 
				Brushes.Blue, 
				alignToRight);
		}
		protected override void Paint(
			Graphics g, 
			Rectangle bounds,
			CurrencyManager source, 
			int rowNum,
			Brush backBrush, 
			Brush foreBrush,
			bool alignToRight) 
		{
			if ( GetColumnValueAtRow(source, rowNum)is DBNull )
				return;
			string strDate = (string) 
				GetColumnValueAtRow(source, rowNum);
			
			try
			{
				DateTime.Parse ( strDate );
			}
			catch { return ;}

			
			DateTime date = DateTime.Parse ( strDate );

			Rectangle rect = bounds;
			g.FillRectangle(backBrush,rect);
			rect.Offset(0, 2);
			rect.Height -= 2;

			if( Format==DateTimePickerFormat.Time )
				g.DrawString(date.ToString("hh:mm:ss"), 
					this.DataGridTableStyle.DataGrid.Font, 
					foreBrush, rect);
			else if(Format==DateTimePickerFormat.Short )
				g.DrawString(date.ToString("MM-dd-yyyy"), 
					this.DataGridTableStyle.DataGrid.Font, 
					foreBrush, rect);
			else
			{
				if ( strDate.IndexOf ( ":") >= 0)
				{
					g.DrawString(date.ToString("hh:mm:ss"), 
						this.DataGridTableStyle.DataGrid.Font, 
						foreBrush, rect);
				}
				else
				{
					g.DrawString(date.ToString("MM-dd-yyyy"), 
						this.DataGridTableStyle.DataGrid.Font, 
						foreBrush, rect);
				}
				//				g.DrawString(date.ToString(CustomFormat), 
				//					this.DataGridTableStyle.DataGrid.Font, 
				//					foreBrush, rect);
			}
		}

		protected override void SetDataGridInColumn(DataGrid value) 
		{
			base.SetDataGridInColumn(value);
			if (myDateTimePicker.Parent != null) 
			{
				myDateTimePicker.Parent.Controls.Remove 
					(myDateTimePicker);
			}
			if (value != null) 
			{
				value.Controls.Add(myDateTimePicker);
			}
		}

		private void TimePickerValueChanged(object sender, EventArgs e) 
		{
			this.isEditing = true;
			base.ColumnStartedEditing(myDateTimePicker);
		}

		public DateTimePickerFormat  Format
		{
			get
			{
				return myDateTimePicker.Format;

			}
			set
			{
				myDateTimePicker.Format=value;
			}
		}

		public string CustomFormat
		{
			get
			{
				return myDateTimePicker.CustomFormat;

			}
			set
			{
				myDateTimePicker.CustomFormat=value;
			}
		}
		public bool	ShowTime
		{
			get
			{
				return myDateTimePicker.ShowUpDown;
			}
			set
			{
				myDateTimePicker.ShowUpDown=value;
			}
		}
	}
}
