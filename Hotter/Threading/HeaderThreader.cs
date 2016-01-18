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
using System.Net;
using System;

namespace Hotter.Threading
{
	public class HeaderThreader : Threader 
	{
		private string m_url = string.Empty;
		private WebResponse m_response = null;
		private Action<HeaderThreader, WebResponse> m_callback = null;

		public HeaderThreader( string url, Action<HeaderThreader, WebResponse> callback = null )
		{
			m_url = url;
			m_callback = callback;
		}

		protected override void OnStart()
		{
			var req = HttpWebRequest.Create( m_url );
			req.Method = "HEAD";
			m_response = req.GetResponse();
		}

		protected override void OnFinished()
		{
			if ( null != m_callback )
			{
				m_callback( this, m_response );
			}
		}
	}
}
