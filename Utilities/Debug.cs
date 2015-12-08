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

using System.Collections.Generic;
using UnityEngine;

public static class Debug
{
    private static readonly int DEFAULT_SIZE = 12;

    public static bool IsEnabled = true;

    public static int FontSize = 12;

    #region LogFilter

    private static IList<string> m_objects = new List<string>();

    public static void Add( object obj )
    {
        var name = obj.GetType().FullName;
        if ( !m_objects.Contains( name ) )
        {
            m_objects.Add( name );
        }
    }

    public static void Remove( object obj )
    {
        var name = obj.GetType().FullName;
        if ( m_objects.Contains( name ) )
        {
            m_objects.Remove( name );
        }
    }

    public static void Log( object obj, object message )
    {
        var name = obj.GetType().FullName;
        if ( m_objects.Contains( name ) )
        {
            Log( "[" + name + "]: " + message );
        }
    }

    public static void LogWarning( object obj, object message )
    {
        var name = obj.GetType().FullName;
        if ( m_objects.Contains( name ) )
        {
            LogWarning( "[" + name + "]: " + message );
        }
    }

    public static void LogError( object obj, object message )
    {
        var name = obj.GetType().FullName;
        if ( m_objects.Contains( name ) )
        {
            LogError( "[" + name + "]: " + message );
        }
    }

    public static void LogBold( object obj, object message )
    {
        var name = obj.GetType().FullName;
        if ( m_objects.Contains( name ) )
        {
            Log( ApplyStyle( "[" + name + "]: " + "<b>" + message + "</b>" ) );
        }
    }

    public static void LogItalic( object obj, object message )
    {
        var name = obj.GetType().FullName;
        if ( m_objects.Contains( name ) )
        {
            Log( ApplyStyle( "[" + name + "]: " + "<i>" + message + "</i>" ) );
        }
    }

    public static void LogColor( object obj, object message, string color )
    {
        var name = obj.GetType().FullName;
        if ( m_objects.Contains( name ) )
        {
            Log( ApplyStyle( "[" + name + "]: " + "<color=" + color + ">" + message + "</color>" ) );
        }
    }

    #endregion

    #region Log RichText

    public static void LogBold( object message )
    {
        Log( ApplyStyle( "<b>" + message + "</b>" ) );
    }

    public static void LogItalic( object message )
    {
        Log( ApplyStyle( "<i>" + message + "</i>" ) );
    }

    public static void LogColor( object message, string color )
    {
        Log( ApplyStyle( "<color=" + color + ">" + message + "</color>" ) );
    }

    #endregion

    #region Log

    public static void Log( object message )
    {
        if ( IsEnabled )
        {
            UnityEngine.Debug.Log( ApplyStyle( message ) );
        }
    }
    public static void Log( object message, UnityEngine.Object context )
    {
        if ( IsEnabled )
        {
            UnityEngine.Debug.Log( ApplyStyle( message ), context );
        }
    }
    public static void LogFormat( string format, params object[] args )
    {
        if ( IsEnabled )
        {
            UnityEngine.Debug.LogFormat( format, args );
        }
    }
    public static void LogFormat( Object context, string format, params object[] args )
    {
        if ( IsEnabled )
        {
            UnityEngine.Debug.LogFormat( context, format, args );
        }
    }

    #endregion

    #region Error

    public static void LogError( object message )
    {
        if ( IsEnabled )
        {
            UnityEngine.Debug.LogError( ApplyStyle( message ) );
        }
    }
    public static void LogError( object message, UnityEngine.Object context )
    {
        if ( IsEnabled )
        {
            UnityEngine.Debug.LogError( ApplyStyle( message ), context );
        }
    }
    public static void LogErrorFormat( string format, params object[] args )
    {
        if ( IsEnabled )
        {
            UnityEngine.Debug.LogErrorFormat( format, args );
        }
    }
    public static void LogErrorFormat( Object context, string format, params object[] args )
    {
        if ( IsEnabled )
        {
            UnityEngine.Debug.LogErrorFormat( context, format, args );
        }
    }

    #endregion

    #region Warning

    public static void LogWarning( object message )
    {
        if ( IsEnabled )
        {
            UnityEngine.Debug.LogWarning( ApplyStyle( message ) );
        }
    }
    public static void LogWarning( object message, Object context )
    {
        if ( IsEnabled )
        {
            UnityEngine.Debug.LogWarning( ApplyStyle( message ), context );
        }
    }
    public static void LogWarningFormat( string format, params object[] args )
    {
        if ( IsEnabled )
        {
            UnityEngine.Debug.LogWarningFormat( format, args );
        }
    }
    public static void LogWarningFormat( Object context, string format, params object[] args )
    {
        if ( IsEnabled )
        {
            UnityEngine.Debug.LogWarningFormat( context, format, args );
        }
    }

    #endregion

    #region Exception

    public static void LogException( System.Exception exception )
    {
        if ( IsEnabled )
        {
            UnityEngine.Debug.LogException( exception );
        }
    }
    public static void LogException( System.Exception exception, UnityEngine.Object context )
    {
        if ( IsEnabled )
        {
            UnityEngine.Debug.LogException( exception, context );
        }
    }

    #endregion

    private static object ApplyStyle( object message )
    {
        object log = message;
        if ( DEFAULT_SIZE != FontSize )
        {
            log = "<size=" + FontSize.ToString() + ">" + message + "</size>";
        }
        log += "\n";

        return log;
    }
}

