[![Build status](https://ci.appveyor.com/api/projects/status/yrlvk9bgoo8ib73b?svg=true)](https://ci.appveyor.com/project/antoinebidault/htmltoampconverter)

# HtmlToAmpConverter

This project is intended to provide a lightweight html to AMP converter for article html produced by WYSIWING editors like TinyMCE, CKEditor... It uses [HtmlAgilityPack](https://github.com/zzzprojects/html-agility-pack) for sanitizing html.

# Basic installation & Configuration

Install the nuget package

```NPM
	install-package HtmlToAmpConverter
```

In your startup.cs ConfigureServices void, register the HtmlToAmp service :

```C#
	services.AddHtmlToAmpConverter();
```

# List of sanitizers availables

amp-iframe
amp-img
script tag removing
