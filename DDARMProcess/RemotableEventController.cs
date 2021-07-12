using System;
using DDARecipeRObjects;

namespace DDARMProcess
{
	/// <summary>
	/// Summary description for RemotableEventController.
	/// </summary>
	public class RemotableEventController
	{
		public static RemotableEventController Controler = new RemotableEventController();

		RRecipeList			_RemoteRecipeList = null;
		RRecipeListEvent	_RemoteEvent = new RRecipeListEvent();	
				

		public RemotableEventController()
		{
		}

		public RRecipeList			RemoteRecipeList
		{
			get
			{
				return _RemoteRecipeList;
			}
		}

		public void InitRemotingObjects()
		{
			_RemoteRecipeList = new RRecipeList();

			_RemoteRecipeList.OnStartCmd+=new RecipeEventHandler(_RemoteEvent.HandlerOnStartCmd);
			_RemoteRecipeList.OnStopCmd+=new RecipeEventHandler(_RemoteEvent.HandlerOnStopCmd);

			_RemoteEvent.OnStartCmd+=new RecipeEventHandler(DDAWCmdLine._RemoteEvent_OnStartCmd);
			_RemoteEvent.OnStopCmd+=new RecipeEventHandler(DDAWCmdLine._RemoteEvent_OnStopCmd);
		}

		public void FreeRemotingObject()
		{
			if(_RemoteRecipeList==null) return;

			try
			{
				_RemoteRecipeList.OnStartCmd-=new RecipeEventHandler(_RemoteEvent.HandlerOnStartCmd);
				_RemoteRecipeList.OnStopCmd-=new RecipeEventHandler(_RemoteEvent.HandlerOnStopCmd);

				_RemoteEvent.OnStartCmd-=new RecipeEventHandler(DDAWCmdLine._RemoteEvent_OnStartCmd);
				_RemoteEvent.OnStopCmd-=new RecipeEventHandler(DDAWCmdLine._RemoteEvent_OnStopCmd);
			}
			catch
			{
			}
		}
	
	}
}
