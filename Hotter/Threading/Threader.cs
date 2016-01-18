/*
The MIT License (MIT)
Copyright (c) 2015 Scissor Lee
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using UnityEngine;
using System.Collections;
using System.Threading;

namespace Hotter.Threading
{
	public class Threader 
	{
		public bool IsDone
		{
			get
			{
				var isDone = false;
				lock ( m_lock )
				{
					isDone = m_isDone;
				}
				return isDone;
			}
			set
			{
				lock ( m_lock )
				{
					m_isDone = value;
				}
			}
		}

		private object m_lock = new object();
		private bool m_isDone = false;
		private Thread m_thread = null;

		protected virtual void OnStart()
		{
		}
		protected virtual void OnFinished()
		{
		}

		public void Update()
		{
			if ( IsDone )
			{
				OnFinished();
				IsDone = false;
			}
		}

		public void Start()
		{
			m_thread = new Thread( Run );
			m_thread.Start();
		}

		private void Run()
		{
			OnStart();
			IsDone = true;
		}
	}
}
