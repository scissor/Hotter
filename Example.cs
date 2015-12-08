using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Hotter
{
    public class Example : MonoBehaviour
    {
        void Start()
        {
            
        }

        void OnGUI()
        {
            if ( GUI.Button( new Rect( 0, 0, 100, 50 ), "Debug" ) )
            {
                DebugTest();
            }
        }

        private void DebugTest()
        {
            Debug.Log( "Log" );
            Debug.LogError( "LogError" );
            Debug.LogWarning( "LogWarning" );
            Debug.LogBold( "LogBold" );
            Debug.LogItalic( "LogItalic" );
            Debug.LogColor( "LogRed", "red" );
            Debug.LogColor( "LogYellow", "yellow" );
            Debug.LogColor( "LogGreen", "green" );

            Debug.FontSize = 14;
            Debug.Log( "FontSize: " + Debug.FontSize );

            // Filter
            Debug.Log( this, "Before adding" );
            Debug.Add( this );

            Debug.Log( this, "Filter Log" );
            Debug.LogWarning( this, "Filter LogWarning" );
            Debug.LogError( this, "Filter LogError" );

            Debug.Remove( this );
            Debug.Log( this, "After removing" );
        }
    }
}
