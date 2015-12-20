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

namespace Hotter.Utilities
{
    /// <summary>
    /// Example:
    /// enum GameState
    /// {
    ///     None,
    ///     StartGame,
    ///     Playing,
    ///     EndGame
    /// }
    /// 
    /// var FSM<GameState> m_state = new FSM<GameState>( GameState.None );
    /// m_state.Transit( GameState.StartGame );
    /// 
    /// void Update()
    /// {
    ///     switch ( m_state.Tick() )
    ///     {
    ///         case GameState.StartGame: break;
    ///         case GameState.Playing: break;
    ///         case GameState.EndGame: break;
    ///     }
    /// }
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FSM<T>
    {
        private T m_state;
        private T m_nextState;

        private bool m_isTransiting = false;
        private bool m_isEntering = false;
        private float m_time = 0;

        public FSM( T state )
        {
            m_state = state;
            m_nextState = state;

            m_isTransiting = true;
            m_isEntering = false;
        }

        public T Current
        {
            get
            {
                lock ( this )
                {
                    return m_state;
                }
            }
        }

        public bool IsEntering
        {
            get
            {
                lock ( this )
                {
                    return m_isEntering;
                }
            }
        }

        public float Elapsed
        {
            get
            {
                lock ( this )
                {
                    return Time.time - m_time;
                }
            }
        }

        public void Transit( T state )
        {
            lock ( this )
            {
                m_nextState = state;
                m_isTransiting = true;
            }
        }

        public T Tick()
        {
            lock ( this )
            {
                if ( m_isTransiting )
                {
                    m_state = m_nextState;
                    m_isTransiting = false;
                    m_isEntering = true;

                    m_time = Time.time;
                }
                else
                {
                    m_isEntering = false;
                }

                return m_state;
            }
        }
    }
}