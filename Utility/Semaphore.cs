using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;
using System.Threading;
namespace SiGlaz.Utility
{
	public class Semaphore
	{
		private Mutex[] m_mutex;
		private Thread[] m_threadIds;
		private int m_threadLimit;
		private string _name;

		public Semaphore(int threadLimit, string name)
		{
			_name = name;
			m_threadLimit = threadLimit;
			m_mutex = new Mutex[m_threadLimit];
			m_threadIds = new Thread[m_threadLimit];
			for (int i=0; i<m_threadLimit; i++)
			{
				string mutexName = string.Format("{0}_{1}", _name, i);
				m_mutex[i] = new Mutex(false, mutexName);
				m_threadIds[i] = null;
			}
		}

		// if there is a timeout then WaitHandle.WaitTimeout is returned
		// calling thread should check for this
		public int Wait()
		{
			int index = WaitHandle.WaitAny(m_mutex);
			// Fix bug of WaitHandle.WaitAny
			if (index >= 128) 
				index -= 128;
			if (index != WaitHandle.WaitTimeout)
				m_threadIds[index] = Thread.CurrentThread;
			return index;
		}

		// if there is a timeout then WaitHandle.WaitTimeout is returned
		// calling thread should check for this
		public int Wait(int timeOut)
		{
			int index = WaitHandle.WaitAny(m_mutex, timeOut, true);
			if (index != WaitHandle.WaitTimeout)
				m_threadIds[index] = Thread.CurrentThread;
			return index;
		}

		// release the mutex locked by the thread
		public void Release()
		{
			for (int i=0; i<m_threadLimit; i++)
			{
				if (m_threadIds[i] == Thread.CurrentThread)
				{
					m_mutex[i].ReleaseMutex();
				}
			}
		}
	}
}
