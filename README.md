[![Build status](https://ci.appveyor.com/api/projects/status/yrlvk9bgoo8ib73b?svg=true)](https://ci.appveyor.com/project/antoinebidault/htmltoampconverter)

# HtmlToAmpConverter

This project is intended to provide a lightweight html to AMP converter for article html produced by WYSIWING editors like TinyMCE, CKEditor... It uses [HtmlAgilityPack](https://github.com/zzzprojects/html-agility-pack) for sanitizing html.

# Requirements

ASP.NET Core 2.1 or higher

# Basic installation & Configuration

Install the nuget package

```NPM
	install-package HtmlToAmpConverter
```

In your startup.cs ConfigureServices void, register the HtmlToAmp service :

```C#
	services.AddHtmlToAmpConverter();
```

And then in your controller MVC :
```C#
    private HtmlToAmp _htmlToAmp;

    public HomeController(HtmlToAmp htmlToAmp)
    {
      _htmlToAmp = htmlToAmp;
    }

		public IActionResult Index(){
			string htmlAMP = _htmlToAmp.ConvertToAmp(html);
			return Ok(htmlAMP);
		}
```



# List of sanitizers availables

.amp-iframe
.amp-img
.amp-youtube
.script & styles tag removing


# Customization

Create a custom Sanitizer
It is recommended to use HtmlAgilityPack for manipulating the html document
```C#
  // Example
	public class MyCustomSanitizer : IHtmlToAmpSanitizer
  {
    public void ConvertToAmp(HtmlDocument html)
    {
     // Manipulate the dom with HtmlAgilityPack here
		 // See the docs : https://html-agility-pack.net/documentation
    }
  }
```

You register the sanitizer as following :
```C#
  services.AddHtmlToAmpConverter(options=> {
    options.AddSanitizer<MyCustomSanitizer>();
  });
```
