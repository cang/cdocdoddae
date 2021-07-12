using System;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SiGlaz.Recipes
{
	/// <summary>
	/// Summary description for Recipe
	/// </summary>
	public class Recipe
	{
		public const int		VERSION = 6;

		#region fields
		public int				VersionNumber = VERSION;
		public int				ID;
		public string			Name = string.Empty;
		public string			Description = string.Empty;
		

		public Node				Root;
		public ShapeCollection	Shapes = new ShapeCollection();

		//Temp fields
		public	Point			ptDown = Point.Empty;
		public	Point			ptPrev = Point.Empty;
		private Control			_ParentControl;
		private ToolTip			_Tooltip;
		private eTracker		tracker;
		private bool			_ViewTooltip = true;
		public	Type			DrawLinkType = null;
		private Link			DrawLink = null;
		public	bool			DrawLineOne = false;
		public  bool			IsRunning = false;

		public	bool			ReadOnly = false;

		public	bool			WaitingToRun = false;
		public	bool			WaitingToStop = false;

		public	bool			ShowProcessStep = true;

		#endregion fields

		#region events
		public delegate			void				NodeEventHandler(Node node,RecipeEventArgs e);
		public delegate			void				RecipeEventHandler(RecipeEventArgs e);

		public event			EventHandler		OnDrawLinkFinish;

		public event			NodeEventHandler	OnBeginNode;
		public event			NodeEventHandler	OnCompleteNode;
		public event			NodeEventHandler	OnExceptionNode;
		public event			NodeEventHandler	OnWaitingForData;
		public event			NodeEventHandler	OnMessage;

		public event			RecipeEventHandler	OnStart;
		public event			RecipeEventHandler	OnBegin;
		public event			RecipeEventHandler	OnStop;
		public event			RecipeEventHandler	OnComplete;
		public event			RecipeEventHandler	OnException;

		#endregion events

		#region constructor
		
		public Recipe() 
		{
		}

		public Recipe(int id,string name) : this()
		{
			this.ID = id;
			this.Name = name;
		}

		#endregion constructor

		#region handler events
		public void MouseMove(System.Windows.Forms.MouseEventArgs e)
		{
			//if( this.ReadOnly) return;

			Point pt = new Point(e.X,e.Y);

			if( e.Button == MouseButtons.None)
			{
				#region Select hover shape
				Shapes.Hover = null;
				foreach(Shape obj in Shapes.Links )
				{
					if( obj.CursorCheck(pt,ref Shapes.ptCurrent) )
					{
						Shapes.Hover = obj;
						break;
					}
				}
				if(Shapes.Hover==null)
				{
					foreach(Shape obj in Shapes.Nodes )
					{
						if( obj.CursorCheck(pt,ref Shapes.ptCurrent) )
						{
							Shapes.Hover = obj;
							break;
						}
					}
				}
				#endregion Select hover shape

				#region Set cursor for resize
				//if(Shapes.Hover==null)
			{
				foreach(Shape obj in Shapes.Nodes)
				{
					if( obj is Node && obj.Selected && obj.CanResize)
					{
						this.SetCursor( (obj as Node).CursorCheck(pt,ref tracker));
						if( tracker!=eTracker.Default)
							break;
					}
				}
			}
				#endregion Set cursor for resize

				if(Shapes.Hover!=null)
					this.SetTooltip(Shapes.Hover.Name);
				else
					this.SetTooltip(string.Empty);

			}
			else if( (e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				Size delta = new Size(pt.X - ptPrev.X, pt.Y - ptPrev.Y);
				if(tracker== eTracker.Default)
				{
					//Move 
					if(Shapes.Hover!=null)//move 
					{
						Shapes.IsMove = true;
						Shapes.Move(delta);

						//Move link Point
						if(!Shapes.ptCurrent.IsEmpty && Shapes.Hover is Link)
						{
							(Shapes.Hover as Link).Move(Shapes.ptCurrent,pt);
							Shapes.ptCurrent = pt;
						}
						
						if(DrawLink==null && DrawLinkType!=null && Shapes.Hover is Node)
						{
							Shapes.Select(false);
							DrawLink = Activator.CreateInstance(DrawLinkType) as Link;
							DrawLink.Begin = Shapes.Hover as Node;
							DrawLink.End = Shapes.Hover as Node;
							DrawLink.Parent = this;

							Shapes.Add(DrawLink);

							Shapes.ptCurrent = DrawLink.PointPath[0];
							Shapes.idxDownPoint = 1;
							DrawLink.Selected = true;
							Shapes.Hover = DrawLink;
							Shapes.Selected = null;
						}
					}
				}
				else
				{
					Shapes.Resize(tracker,delta);
				}

				//Canvas change
				RefreshBound();

				ptPrev = pt;
			}
			else if( (e.Button & MouseButtons.Right) == MouseButtons.Right)
			{
			}

		}

		protected void RefreshBound()
		{
			Rectangle rcBound = Shapes.Bound;

			int w = rcBound.Width + rcBound.X;
			int h = rcBound.Height + rcBound.Y;

			w = w<1024?1024:w;
			h = h<768?768:h;

			if(this.Size.Width < w || this.Size.Height < h)
				this.Size = new Size(w + 100,h + 100);
		}

		public void MouseDown(System.Windows.Forms.MouseEventArgs e)
		{
			//if( this.ReadOnly) return;

			Point pt = new Point(e.X,e.Y);

			SetCursor(Cursors.Default);
			if( (e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				ptDown = ptPrev = pt;
				bool selectone=(Control.ModifierKeys & Keys.Control) != Keys.Control 
					&&
					(Control.ModifierKeys & Keys.Shift) != Keys.Shift;

				if(tracker == eTracker.Default)
				{
					if(selectone)
					{
						if(Shapes.Hover!=null && Shapes.Hover is Node && Shapes.Hover.Selected)
							return;
						Shapes.Select(false);
					}

					if(Shapes.Hover!=null)
					{
						//select shape when clicking
						Shapes.Hover.Selected = !Shapes.Hover.Selected;
						if(Shapes.Hover.Selected && !selectone)
							Shapes.Selected = Shapes.Hover;
						else
							Shapes.Selected = null;

						//select point of link when clicking
						if(!Shapes.ptCurrent.IsEmpty)
						{
							Shapes.idxDownPoint = (Shapes.Hover as Link).AddPoint(Shapes.ptCurrent);
						}
					}
					else
						Shapes.Selected = null;
				}
				
			}
			else if( (e.Button & MouseButtons.Right) == MouseButtons.Right)
			{
			}

		}

		public void MouseUp(System.Windows.Forms.MouseEventArgs e)
		{
			//if( this.ReadOnly) return;

			Point pt = new Point(e.X,e.Y);
			if( e.Button == MouseButtons.None)
			{
			}
			else if( (e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				if(Shapes.Hover!=null)
				{
					foreach(Link link in Shapes.Links)
					{
						link.RemovePoint();
					}

					if(!Shapes.ptCurrent.IsEmpty && Shapes.idxDownPoint>-1 
						&&  !SiGlaz.Utility.MathUtils.CircleIntersectCircle(ptDown,ObjectConst.RPOINT,Shapes.ptCurrent,ObjectConst.RPOINT ) )
					{
						//Re-Connect to other Node
						string sresult = (Shapes.Hover as Link).ConnectNode(Shapes.idxDownPoint,Shapes.ptCurrent,Shapes.Nodes);
						if(sresult!=string.Empty)
						{
							MessageBox.Show(sresult,Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);
							//Shapes.ResetSelection();
						}
						Shapes.ptCurrent = Point.Empty;
					}

					if(DrawLink != null)
					{
						if(DrawLink.Begin==DrawLink.End)
						{
							Shapes.Remove(DrawLink);
							Shapes.Selected = null;
							Shapes.Hover = null;
						}
						else
						{
							if(DrawLineOne)
							{
								DrawLinkType = null;
								if(OnDrawLinkFinish!=null)
									OnDrawLinkFinish(DrawLink,EventArgs.Empty);
							}
						}
						DrawLink = null;
					}

				}
				if(!Shapes.IsMove)//select object
				{
					Shapes.SelectAtRectangle( SiGlaz.Utility.MathUtils.Rectanglize(ptDown,ptPrev));
				}

				Shapes.IsMove = false;
				ptDown =  ptPrev = Point.Empty;

				if(tracker == eTracker.Default)
				{
					if(Shapes.Hover!=null && Shapes.Hover.Selected)
					{
						Shapes.Hover.LeftClick();
					}
				}
			}
			else if( (e.Button & MouseButtons.Right) == MouseButtons.Right)
			{
				if(tracker == eTracker.Default)
				{
					if(Shapes.Hover!=null && Shapes.Hover.Selected)
					{
						Shapes.Hover.RightClick();
					}
				}
			}
		}

		public void DoubleClick()
		{
			if(Shapes.Hover!=null)
			{
				Shapes.Hover.DoubleClick();
			}
		}

		public void KeyDown(System.Windows.Forms.KeyEventArgs e)
		{
			//if( this.ReadOnly) return;

			if(e.KeyCode == Keys.A)
			{
				if((Control.ModifierKeys & Keys.Control) == Keys.Control)
					Shapes.Select(true);
			}
			else if(e.KeyCode == Keys.Delete)
			{
				Shapes.Delete();
			}
		}

		private void _ParentControl_MouseDown(object sender, MouseEventArgs e)
		{
			this.MouseDown(e);
			_ParentControl.Invalidate();
		}

		private void _ParentControl_MouseMove(object sender, MouseEventArgs e)
		{
			this.MouseMove(e);
			_ParentControl.Invalidate();
		}

		private void _ParentControl_MouseUp(object sender, MouseEventArgs e)
		{
			this.MouseUp(e);
			_ParentControl.Invalidate();
		}

		private void _ParentControl_KeyDown(object sender, KeyEventArgs e)
		{
			this.KeyDown(e);
			_ParentControl.Invalidate();
		}

		private void _ParentControl_DoubleClick(object sender, EventArgs e)
		{
			SetTooltip(null);
			this.DoubleClick();
		}

		#endregion handler events

		#region draw
		public void Draw(Graphics g)
		{
			Shapes.Draw(g);
			Pen pen = new Pen(Color.Black);
			pen.DashStyle = DashStyle.Dash;
			if(!ptDown.IsEmpty && !Shapes.IsMove && tracker==eTracker.Default)
				g.DrawRectangle(pen, SiGlaz.Utility.MathUtils.Rectanglize(ptDown,ptPrev));
			pen.Dispose();
		}

		private void _ParentControl_Paint(object sender, PaintEventArgs e)
		{
			//memgraphics.g.Clear(Color.White);
			//x.Draw(memgraphics.g);
			//memgraphics.Render(e.Graphics);
			Graphics g = e.Graphics;
			if(g.SmoothingMode != SmoothingMode.AntiAlias)
				g.SmoothingMode = SmoothingMode.AntiAlias;
			g.Clear(Color.White);
			this.Draw(g);
		}

		private void SetCursor(Cursor cursor)
		{
			if(_ParentControl==null) return ;
			if(_ParentControl.Cursor!=cursor)
				_ParentControl.Cursor=cursor;
		}

		private Cursor	CurrentCursor
		{
			get
			{
				if(_ParentControl==null) return Cursors.Default;
				return _ParentControl.Cursor;
			}
		}

		private void SetTooltip(string text)
		{
			if(_ParentControl==null) return;
			if(!_ViewTooltip) return;
			_Tooltip.SetToolTip(_ParentControl,text);
		}

		#endregion draw

		#region property
		private Size	Size
		{
			get
			{
				if(_ParentControl!=null)
					return _ParentControl.Size;
				else
					return Size.Empty;
			}
			set
			{
				if(_ParentControl!=null)
					_ParentControl.Size = value;
			}
		}

		public Control			ParentControl
		{
			get
			{
				return _ParentControl;
			}
			set
			{
				if(_ParentControl!=null)
				{
					_ParentControl.Paint-=new PaintEventHandler(_ParentControl_Paint);
					_ParentControl.MouseDown-=new MouseEventHandler(_ParentControl_MouseDown);
					_ParentControl.MouseMove-=new MouseEventHandler(_ParentControl_MouseMove);
					_ParentControl.MouseUp-=new MouseEventHandler(_ParentControl_MouseUp);

					//Handle keydown
					Control ctrl1 = _ParentControl;
					while(ctrl1!=null)
					{
						ctrl1.KeyDown-=new KeyEventHandler(_ParentControl_KeyDown);
						if(ctrl1 is Form)
						{
							(ctrl1 as Form).KeyPreview = true;
							break;
						}
						ctrl1 = ctrl1.Parent;
					}

					_ParentControl.DoubleClick-=new EventHandler(_ParentControl_DoubleClick);

				}

				_ParentControl = value;
				if(_ParentControl==null) return;
				_ParentControl.Paint+=new PaintEventHandler(_ParentControl_Paint);
				_ParentControl.MouseDown+=new MouseEventHandler(_ParentControl_MouseDown);
				_ParentControl.MouseMove+=new MouseEventHandler(_ParentControl_MouseMove);
				_ParentControl.MouseUp+=new MouseEventHandler(_ParentControl_MouseUp);

				//Handle keydown
				Control ctrl = _ParentControl;
				while(ctrl!=null)
				{
					ctrl.KeyDown+=new KeyEventHandler(_ParentControl_KeyDown);
					if(ctrl is Form)
					{
						(ctrl as Form).KeyPreview = true;
						break;
					}
					ctrl = ctrl.Parent;
				}

				_ParentControl.DoubleClick+=new EventHandler(_ParentControl_DoubleClick);
				if(_Tooltip==null)
					_Tooltip = new ToolTip();

				this.RefreshBound();
				_ParentControl.Invalidate();
			}
		}


		#endregion property
		
		#region archive


		public virtual void Clear()
		{
			Shapes.Clear();
			Root = null;
		}

		public virtual void Serialize(BinaryWriter stream)
		{
			this.VersionNumber = VERSION;

			//Write header
			stream.Write(this.GetType().FullName);
			stream.Write(this.VersionNumber);

			//Write Nodes first
			NodeCollection nodes = Shapes.Nodes;
			stream.Write(nodes.Count);//Number of nodes
			for(int i=0;i<nodes.Count;i++)
			{
				stream.Write( nodes[i].GetType().FullName );//Name
				nodes[i].Serialize(stream);
			}

			//Write link
			LinkCollection links = Shapes.Links;
			stream.Write(links.Count);//Number of links
			for(int i=0;i<links.Count;i++)
			{
				stream.Write( links[i].GetType().FullName );//Name
				links[i].Serialize(stream);
			}

			//Write Root Node
			if(this.Root!=null)
				stream.Write(this.Root.ID);
			else
				stream.Write((int)-1);


			stream.Write(this.ID);
			stream.Write(this.Name);
			stream.Write(this.Description);
		}

		public virtual void SerializeBinary(string filepath)
		{
			SiGlaz.Utility.FileUtils.DeleteFile(filepath);
			FileStream stream = null;
			BinaryWriter bw  = null;
			try
			{
				stream = File.Create(filepath);
				bw = new BinaryWriter(stream);
				this.Serialize(bw);
			}
			catch
			{
				throw;
			}
			finally
			{
				if(bw!=null)
				{
					bw.Close();
					bw = null;
				}
				if(stream!=null)
				{
					stream.Close();
					stream = null;
				}
			}
		}

		public virtual byte[] SerializeBinary()
		{
			MemoryStream stream = null;
			BinaryWriter bw  = null;
			try
			{
				stream = new MemoryStream();
				bw = new BinaryWriter(stream);
				this.Serialize(bw);
				bw.Flush();
				return stream.ToArray();
			}
			catch
			{
				throw;
			}
			finally
			{
				if(bw!=null)
				{
					bw.Close();
					bw = null;
				}
				if(stream!=null)
				{
					stream.Close();
					stream = null;
				}
			}
		}

		public virtual Shape	CreateInstanceOfShape(string objectname)
		{
			Shape obj = typeof(Recipe).Assembly.CreateInstance(objectname) as Shape;
			return obj;
		}

		public virtual void Deserialize(BinaryReader stream)
		{
			try
			{
				string filetype = stream.ReadString();
				if(filetype!= this.GetType().FullName) 
					throw new Exception("Invalid Format");

				this.Clear();
				
				this.VersionNumber = stream.ReadInt32();

				//Read nodes
				int nodesnumber  = stream.ReadInt32();
				for(int i = 0;i < nodesnumber;i++)
				{
					string objectname = stream.ReadString();
					Shape obj = this.CreateInstanceOfShape(objectname);

					obj.Deserialize(stream,this.VersionNumber);
					obj.Parent = this;

					this.Shapes.Add(obj);
				}

				//Read links
				int linksnumber  = stream.ReadInt32();
				for(int i = 0;i < linksnumber;i++)
				{
					string objectname = stream.ReadString();
					Shape obj = this.CreateInstanceOfShape(objectname);

					int beginid = 0, endid = 0;
					(obj as Link).Deserialize(stream,this.VersionNumber,ref beginid,ref endid);
					(obj as Link).Begin = this.Shapes.SearchById(beginid) as Node;
					(obj as Link).End = this.Shapes.SearchById(endid) as Node;
					(obj as Link).Parent = this;

					this.Shapes.Add(obj);
				}

				int rootid = stream.ReadInt32();
				if( rootid!=-1)
					this.Root = this.Shapes.SearchById(rootid) as Node;

				this.ID = stream.ReadInt32();
				this.Name = stream.ReadString();
				this.Description = stream.ReadString();
			}
			catch
			{
				throw;
			}
		}
	
		public virtual void DeserializeBinary(string filepath)
		{
			if( !SiGlaz.Utility.FileUtils.ExistsFile(filepath) ) return;
			FileStream stream = null;
			BinaryReader br  = null;
			try
			{
				stream = File.Open(filepath,FileMode.Open);
				br = new BinaryReader(stream);
				this.Deserialize(br);
			}
			catch
			{
				throw;
			}
			finally
			{
				if(br!=null)
				{
					br.Close();
					br = null;
				}
				if(stream!=null)
				{
					stream.Close();
					stream = null;
				}
			}
		}

		public virtual void DeserializeBinary(byte []lpbyte)
		{
			if( lpbyte==null || lpbyte.Length<=0 ) return;

			MemoryStream stream = null;
			BinaryReader br  = null;
			try
			{
				stream = new MemoryStream(lpbyte);
				br = new BinaryReader(stream);
				this.Deserialize(br);
			}
			catch
			{
				throw;
			}
			finally
			{
				if(br!=null)
				{
					br.Close();
					br = null;
				}
				if(stream!=null)
				{
					stream.Close();
					stream = null;
				}
			}
		}


		#endregion archive

		#region public method

		public Shape AddNode(Type nodetype,int x,int y)
		{
			Shapes.Select(false);
			Node  node = Activator.CreateInstance(nodetype) as Node;
			node.Location = new Point(x,y);
			node.Parent = this;
			Shapes.Add(node);
			node.Selected = true;
			RefreshBound();

			return node;
		}


		public Shape AddNode(Node node,int x,int y)
		{
			Shapes.Select(false);
			node.Location = new Point(x,y);
			node.Parent = this;
			Shapes.Add(node);
			node.Selected = true;
			RefreshBound();

			return node;
		}

		public void AddLink(Type linkType, Node beginNode, Node endNode)
		{
			Link link = Activator.CreateInstance(linkType) as Link;
			this.Shapes.Add(link);
			link.Begin = beginNode;
			link.End = endNode;
			link.Parent = this;
		}

		#endregion public method

		#region raise event

		public void RaiseBeginNode(Node node,RecipeEventArgs e)
		{
			if(!ShowProcessStep) return;
			if(OnBeginNode!=null)
			{
				OnBeginNode(node,e);
			}
		}

		public void RaiseCompleteNode(Node node,RecipeEventArgs e)
		{
			if(!ShowProcessStep) return;
			if(OnCompleteNode!=null)
			{
				OnCompleteNode(node,e);
			}
		}

		public void RaiseExceptionNode(Node node,RecipeEventArgs e)
		{
			if(OnExceptionNode!=null)
			{
				OnExceptionNode(node,e);
			}
		}

		public void RaiseException(RecipeEventArgs e)
		{
			if(OnException!=null)
			{
				OnException(e);
			}
		}

		public void RaiseWaitingForData(Node node,RecipeEventArgs e)
		{
			if(OnWaitingForData!=null)
			{
				OnWaitingForData(node,e);
			}
		}

		public void RaiseMessage(Node node,RecipeEventArgs e)
		{
			if(OnMessage!=null)
			{
				OnMessage(node,e);
			}
		}

		public void RaiseBegin(RecipeEventArgs e)
		{
			this.IsRunning = true;
			if(OnBegin!=null)
				OnBegin(e);
		}

		public void RaiseStart(RecipeEventArgs e)
		{
			this.IsRunning = true;
			if(OnStart!=null)
				OnStart(e);
		}

		public void RaiseStop(RecipeEventArgs e)
		{
			this.IsRunning = false;
			if(OnStop!=null)
				OnStop(e);
		}

		public void RaiseComplete(RecipeEventArgs e)
		{
			if(OnComplete!=null)
			{
				OnComplete(e);
			}
		}

		#endregion raise event

		#region Check Syntax

		public virtual bool	ValidateSyntax(ref string msg)
		{
			#region root node
			Root = null;
			foreach(Node node in Shapes.Nodes)
			{
				if(node is NodeBegin)
				{
					if(Root == null)
						Root = node;
					else
					{
						msg = "The recipe only contains one Begin node considered as Root node";
						return false;
					}
				}
			}
			#endregion root node

			if(this.Root==null)
			{
				msg = "The recipe must contain Begin node";
				return false;
			}

			foreach(Node node in Shapes.Nodes)
			{
				if(!node.ValidateSyntax(ref msg)) return false;
			}

			bool result = GoToEnd(this.Root,ref msg);

			if(result)
				result = CheckFlow(ref msg);

			if(result)
				result = CheckAlone(ref msg);

			return result;
		}

		public virtual bool GoToEnd(Node node,ref string msg)
		{
			if(node is NodeEnd)
				return true;
			else
			{
				if( node == null)
				{
					msg = "Must goto end node";
					return false;
				}
				if(node.Nexts.Count>0)
				{
					if(node is NodeDecision)
						return GoToEnd( (node as NodeDecision).TrueNode , ref msg) && GoToEnd( (node as NodeDecision).FalseNode , ref msg);
					else
						return GoToEnd(node.NextFirstNode,ref msg);
				}
				else
				{
					msg = node.Name + " Node must goto End node";
					return false;
				}
			}
		}

		public virtual bool CheckAlone(ref string msg)
		{
			foreach(Node node in Shapes.Nodes)
			{
				if(node is NodeEnd) continue;//skip End Node
				if(node.NextFirstNode==null)
				{
					msg = "Node " + node.Name + " is alone, please check again";
					return false;
				}
			}
			return true;
		}

		public virtual bool CheckFlow(ref string msg)
		{
			#region re-check source node
			if( !(Root.NextFirstNode is NodeSource) )
			{
				msg = "Begin node must be linked to Source node";
				return false;
			}
			#endregion re-check source node

			#region check only one source
//			int number = 0;
//			foreach(Node node in Shapes.Nodes)
//			{
//				if(node is NodeSource)
//					number++;
//			}
//			if(number>1)
//			{
//				msg = "The recipe does not contain more than one Source node";
//				return false;
//			}
			#endregion check only one source

			return true;
		}

		public virtual bool	Validate(ref string msg)
		{
			if( !this.ValidateSyntax(ref msg) )
				return false;

			foreach(Node node in Shapes.Nodes)
			{
				if(!node.Validate(ref msg)) return false;
			}
			return true;
		}

		#endregion Check Syntax

		public virtual bool ProcessNoteExceptionAndSkipRunToEnd(WorkingSpace workingspace,Node node,Exception ex)
		{
			RaiseExceptionNode(node,workingspace.CreateEventArgs(ex.ToString()));

			//SiGlaz.Utility.DebugLog.Write(ex);

			System.Threading.Thread.Sleep(1000*SiGlaz.Common.DDA.AppData.Data.WaitingToRetryError);//Sleep 5 seconds when error happend

			return true;
		}

		public virtual void ProcessOnStop(WorkingSpace workingspace,Node node)
		{
		}


		public virtual void Execute(WorkingSpace workingspace)
		{
			Node node = this.Root;

			Node processedNode = null;
			workingspace.SkipRun = false;
			workingspace.GotoEnd = false;

            //Console.ReadLine();

			RaiseBegin(workingspace.CreateEventArgs(string.Empty,this));

			while( node!=null )
			{
				if(workingspace.Stop) 
				{
					ProcessOnStop(workingspace,processedNode);
					return;
				}

				if(!workingspace.SkipRun)
				{
					RaiseBeginNode(node,workingspace.CreateEventArgs(string.Empty));

					try
					{
						if(!workingspace.GotoEnd || node is NodeEnd)
							node.Execute(workingspace);

						processedNode = node;
					}
					catch(System.Threading.ThreadAbortException)
					{
						ProcessOnStop(workingspace,processedNode);
						return;
					}
					catch(System.Threading.ThreadInterruptedException)
					{
						ProcessOnStop(workingspace,processedNode);
						return;
					}
					catch(Exception ex)
					{
						if(workingspace.Stop)
						{
							ProcessOnStop(workingspace,processedNode);
							return;
						}
						else
						{
							//goto end without Execute next nodes
							workingspace.SkipRun = ProcessNoteExceptionAndSkipRunToEnd(workingspace,node,ex);
							if(workingspace.SkipRun)
							{
								ProcessOnStop(workingspace,processedNode);
							}
						}
					}

					if(workingspace.Stop) 
					{
						ProcessOnStop(workingspace,processedNode);
						return;
					}

					RaiseCompleteNode(node,workingspace.CreateEventArgs(string.Empty));
				}

				if(node is NodeDecision)
				{
					if(workingspace.HaveResult || workingspace.Selection)
						node = (node as NodeDecision).TrueNode;
					else
						node = (node as NodeDecision).FalseNode;
				}
				else
					node = node.NextFirstNode;
			}

			RaiseComplete(workingspace.CreateEventArgs(string.Empty,this));
		}

		public virtual bool ExecutePrepare(WorkingSpace workingspace)
		{
			string msg = string.Empty;
			if( !this.Validate(ref msg))
			{
				RaiseMessage(this.Root,workingspace.CreateEventArgs(msg,this) );
				workingspace.Stop = true;
				RaiseStop(workingspace.CreateEventArgs(string.Empty,this));
				return false;
			}

			if(!ExecuteBefore(workingspace))
			{
				workingspace.Stop = true;
				RaiseStop(workingspace.CreateEventArgs(string.Empty,this));
				return false;
			}

			RaiseStart(workingspace.CreateEventArgs(string.Empty,this));
			return true;
		}

		public virtual bool ExecuteBefore(WorkingSpace workingspace)
		{
			return true;
		}

		public virtual bool ExecuteAfter(WorkingSpace workingspace)
		{
			return true;
		}

		public virtual void ExecuteMonitor(WorkingSpace workingspace,int limitloop)
		{
			if(!ExecutePrepare(workingspace)) return;

			if( limitloop==0)
			{
				while(!workingspace.Stop)
				{
					Execute(workingspace);
				}
				RaiseStop(workingspace.CreateEventArgs(string.Empty,this));
			}
			else
			{
				int i = 0;
				for(;i<limitloop;i++)
				{
					if(workingspace.Stop) break;
					Execute(workingspace);
					if(workingspace.Stop) break;
				}

				if(i<limitloop)
				{
					RaiseStop(workingspace.CreateEventArgs(string.Empty,this));
				}
			}

			ExecuteAfter(workingspace);
		}

		public virtual void CopyTo(Recipe recipe)
		{
			byte []lpbyte = this.SerializeBinary();
			recipe.Shapes = new ShapeCollection();
			recipe.Root = null;
			recipe.DeserializeBinary(lpbyte);
		}

		public virtual Recipe	Copy()
		{
			Recipe result = MemberwiseClone() as Recipe;
			this.CopyTo(result);
			return result;
		}

	}

}
