using System;

namespace DDADBRObjects
{

	public interface IObserver
	{
		void Notify(string text);
	}

}
