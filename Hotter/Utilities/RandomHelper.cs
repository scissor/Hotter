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

using System;
using System.Collections.Generic;
using System.Text;

namespace Hotter.Utilities
{
    public static class RandomHelper
    {
        private static Random m_random = new Random();

        public static IList<int> List( int count )
        {
            IList<int> numbers = new List<int>();
            for ( int i = 0; i < count; ++i )
            {
                numbers.Add( i );
            }

            Shuffle( numbers );
            return numbers;
        }

        public static List<int> List( int num1, int num2, int count )
        {
            List<int> numbers = new List<int>();

            bool isOrder = num1 <= num2;

            for ( int i = 0; i < count; ++i )
            {
                numbers.Add( Number( num1, num2 ) );
            }

            numbers.Sort();

            if ( isOrder == false )
            {
                numbers.Reverse();
            }

            return numbers;
        }

        public static void Shuffle<T>( IList<T> list )
        {
            int count = list.Count;

            for ( int i = 0; i < count; ++i )
            {
                int random = m_random.Next( 0, count );
                T temp = list[ i ];
                list[ i ] = list[ random ];
                list[ random ] = temp;
            }
        }

        public static string String( int size, bool lowerCase )
        {
            StringBuilder randString = new StringBuilder( size );

            int start = lowerCase ? 97 : 65;

            for ( int i = 0; i < size; i++ )
            {
                randString.Append( ( char ) ( ( 26 * m_random.NextDouble() ) + start ) );
            }

            return randString.ToString();
        }

        public static int Next( int minimal, int maximal )
        {
            return Number( minimal, maximal );
        }

        public static int Number( int num1, int num2 )
        {
            if ( num1 <= num2 )
            {
                return m_random.Next( num1, num2 );
            }
            else
            {
                return m_random.Next( num2, num1 );
            }
        }

        public static bool Bool()
        {
            return m_random.NextDouble() > 0.5;
        }

        public static long Long()
        {
            var buffer = new byte[ sizeof( long ) ];
            m_random.NextBytes( buffer );
            return BitConverter.ToInt64( buffer, 0 );
        }

        public static long Long( long minimal, long maximal )
        {
            var range = ( maximal > minimal ) ? maximal - minimal : minimal - maximal;
            if ( range == 0 )
            {
                return 0;
            }
            else if ( range == 1 )
            {
                return minimal;
            }

            long value = Math.Abs( Long() );
            return ( value % range ) + minimal;
        }
    }
}