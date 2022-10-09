# url-scheme-manager
## Description
Makes adding/removing and managing custom URL Protocols for Windows easier.

## How To Use
This code example is made automatically referencing ***`url-scheme-manager.dll`***.
```csharp
// create custom uri-scheme info for example
var schemeInfo = new URLSchemeInfo
{
    FriendlyName = "Example Scheme",
    ProtocolPrefix = "example-scheme",
    ProgramPath = "example-program.exe
};
bool hasScheme = SchemeManager.CheckForSchemeInfo(schemeInfo);

// add scheme info to Registry if not already added
if (!hasInstall) SchemeManager.AddSchemeInfo(schemeInfo);

// remove scheme info from Registry if already added
if (hasInstall) SchemeManager.RemoveSchemeInfo(schemeInfo);
```

## Documentation
  * `URLSchemeInfo`: Uri-scheme info for your program
  * `SchemeManager`
    * `CheckForSchemeInfo`
      * Returns `true` or `false` depending on whether or not the specified uri-scheme info was added to the Registry
    * `AddSchemeInfo`
      * Adds the provided uri-scheme info to the Registry
    * `RemoveSchemeInfo`
      * Removes the specified uri-scheme info from the Registry

## Download
[Standalone (x86/x32)](https://github.com/Lexz-08/url-scheme-manager/releases/latest/download/url-scheme-manager-x86.dll)<br/>
[Standalone (x64)](https://github.com/Lexz-08/url-scheme-manager/releases/latest/download/url-scheme-manager-x64.dll)
