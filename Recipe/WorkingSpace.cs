using System;

namespace SiGlaz.Recipes
{
	/// <summary>
	/// Summary description for WorkingSpace.
	/// </summary>
	public class WorkingSpace
	{
		bool				_HaveResult;
		bool				_Selection;
		bool				_Stop;
		public				bool		IsWaiting = false;
		public				bool		SkipRun = false;
		public				bool		GotoEnd = false;
		public				bool		NoConnectToDatabase = false;

		public WorkingSpace()
		{
		}

		public virtual RecipeEventArgs	CreateEventArgs(string msg)
		{
			return new RecipeEventArgs(msg);
		}

		public virtual RecipeEventArgs	CreateEventArgs(string msg,Recipe recipe)
		{
			RecipeEventArgs e = new RecipeEventArgs(msg);
			e.RecipeID = recipe.ID;
			return e;
		}

		public virtual bool HaveResult
		{
			get
			{
				return _HaveResult;
			}
			set
			{
				_HaveResult	= value;
			}
		}

		public virtual bool Selection
		{
			get
			{
				return _Selection;
			}
			set
			{
				_Selection	= value;
			}
		}

		public virtual bool Stop
		{
			get
			{
				return _Stop;
			}
			set
			{
				_Stop	= value;
			}
		}

		public void SetWaiting()
		{
			this.IsWaiting = true;
		}

		public void ResetWaiting()
		{
			this.IsWaiting = false;
		}
	}
}
