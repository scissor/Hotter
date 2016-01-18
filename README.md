# Hotter
Utilities for Unity

## How to Build
* 1. Open Visual Studio project & release build
* 2. mono-build.bat: Use mono compiler to build

[Blog: [Unity] How to build Dll?](http://blog.ctrlxctrlv.net/en/unity-build-dll/)

## How to Use
* 1. Hotter.dll: Add to Assets/Plugins
* 2. Download [Hotter-Unity-Example](https://github.com/scissor/Hotter-Unity-Example)

## Code Example

### Threader

```c#
// An example to get file size on web using thread
// Coroutine will cause obviously lag when you have big amount requests
m_thread = new HeaderThreader( url, OnGetHeader );
m_thread.Start();

private void Update()
{
    m_thread.Update();
}

private void OnGetHeader( HeaderThreader threader, WebResponse response )
{
    Debug.Log( "FileSize: " + response.ContentLength );
}
```
