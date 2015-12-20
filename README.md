# Hotter
Utilities for Unity

## How to Build
* 1. Open Visual Studio project & release build
* 2. mono-build.bat: Use mono compiler to build

[Blog: [Unity] How to build Dll?](http://blog.ctrlxctrlv.net/en/unity-build-dll/)

## How to Use
* 1. Hotter.dll: Add to Assets/Plugins
* 2. Download [Hotter-Unity-Example](https://github.com/scissor/Hotter-Unity-Example)


### Debug
Custom Debug that overrides UnityEngine.Debug.

```c#
// Mute
Debug.IsEnabled = false;

// Filter
Debug.Add( this );
Debug.Log( this, "Message" );

// FontSize
Debug.FontSize = 14;

// RichText
Debug.LogBold( "LogBold" );
Debug.LogItalic( "LogItalic" );
Debug.LogColor( "LogRed", "red" );
```
