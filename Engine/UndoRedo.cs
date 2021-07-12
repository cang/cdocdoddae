//using System;
//using System.Collections;
//
//namespace SiGlaz.DDA.Engine
//{
//	/// <summary>
//	/// Summary description for UndoRedo.
//	/// </summary>
//	/// 
//	[Serializable]
//	public class UndoRedo
//	{
//		private			Stack		redoStack,undoStack;
//		private			int			iMaxSize=0;
//		private			Action		acCurrent;
//
//		public			bool		boverload=false;
//
//		/// <summary>
//		/// object is Action
//		/// </summary>
//		public event	EventHandler DataChanged;
//		
//		public Action Current
//		{
//			get
//			{
//				return acCurrent;
//			}
//			set
//			{
//				acCurrent=value;
//			}
//		}
//
//		public UndoRedo()
//		{
//			iMaxSize=0;
//			redoStack=new Stack();
//			undoStack=new Stack();
//		}
//
//		public UndoRedo(int maxhalfsize)
//		{
//			if(maxhalfsize<2)
//				maxhalfsize=2;
//
//			iMaxSize=maxhalfsize;
//			redoStack=new Stack();
//			undoStack=new Stack();
//		}
//
//		public void Store(string name,Map map)
//		{
//			this.StoreInternal(this.Current);
//			this.Current = new Action(name,ActionType.All,map);
//		}
//
//		public void Store(Action action)
//		{
//			this.StoreInternal(this.Current);
//			this.Current = action;
//		}
//
//		private void StoreInternal (Action action)
//		{
//			if(iMaxSize==0 || (iMaxSize>0 && undoStack.Count<iMaxSize) )//no limit
//			{
//				undoStack.Push(action);
//			}
//			else 
//			{
//				//Get first 
//				object []a0= undoStack.ToArray();
//
//				Map x0=(Map)((Action)a0[a0.Length-1]).oData;
//				Action ac=(Action)a0[a0.Length-2];
//				if(ac.eType==ActionType.All)
//					x0=(Map)ac.oData;
//				else
//				{
//					if(ac.eType == ActionType.Add)
//					{
//						x0.AddChips(ac.oData as ArrayList);
//					}
//					else if(ac.eType == ActionType.Remove)
//					{
//						x0.RemoveChips(ac.oData as ArrayList);
//					}
//				}
//
//				ac.eType=ActionType.All;
//				ac.oData=x0;
//
//				undoStack.Clear();
//			
//				for(int i=a0.Length-2;i>=0;i--)
//					undoStack.Push(a0[i]);
//
//				undoStack.Push(action);
//				boverload=true;
//			}
//			redoStack.Clear();
//		}
//		
//		public bool CanUndo
//		{
//			get
//			{
//				return (undoStack.Count>0?true:false);
//			}
//		}
//
//		public bool CanRedo
//		{
//			get
//			{
//				return (redoStack.Count>0?true:false);
//			}
//		}
//
//		public void Undo()
//		{
//			if (undoStack.Count>0)
//			{
//				redoStack.Push(acCurrent);
//				acCurrent= (Action)undoStack.Pop();
//				if( DataChanged!=null)
//					DataChanged(acCurrent,EventArgs.Empty);
//			}
//		}
//
//		public void Redo()
//		{
//			if (redoStack.Count>0)
//			{
//				undoStack.Push(acCurrent);
//				acCurrent=(Action)redoStack.Pop();
//				if( DataChanged!=null)
//					DataChanged(acCurrent,EventArgs.Empty);
//			}
//		}
//
//		private void EmptyHistory()
//		{
//			undoStack.Clear();
//			redoStack.Clear();
//		}
//
//		public void EmptyHistory(Map map)
//		{
//			this.EmptyHistory();
//			Action action=new Action();
//			action.oData = map.Copy();
//			this.Current=action;
//		}
//
//		private	Object[]	aHistory=null;
//		private int			iPos=-1;
//
//		public Map GetData(Action action)
//		{
//			if(action==null) return null;
//
//			if( action.eType == ActionType.All)
//			{
//				aHistory=null;
//				return ((Map)action.oData).Copy();
//			}
//
//			if(aHistory==null) 
//			{
//				aHistory=undoStack.ToArray();
//				iPos=-1;
//			}
//
//			iPos++;
//
//			if( action.eType == ActionType.Add)
//			{
//				Map result=GetData( (Action)aHistory[iPos]);
//				if(result!=null)
//				{
//					result.AddChips(action.oData as ArrayList);
//					return result;
//				}
//			}
//
//			if( action.eType == ActionType.Remove)
//			{
//				Map result= GetData( (Action)aHistory[iPos]);
//				if(result!=null)
//				{
//					result.RemoveChips(action.oData as ArrayList);
//					return result;
//				}
//			}
//
//			return null;
//		}
//
//	}
//
//	[Serializable]
//	public class Action
//	{
//		public string sName;
//		public ActionType eType;
//		public object oData;
//
//		public Action()
//		{
//			sName="";
//			eType=ActionType.All;
//			oData=null;
//		}
//
//		public Action(string name,ActionType type,object data)
//		{
//			sName=name;
//			eType=type;
//			oData=data;
//		}
//
//	}
//
//	public enum ActionType : byte
//	{
//		All,
//		Add,
//		Remove,
//	}
//
//}
