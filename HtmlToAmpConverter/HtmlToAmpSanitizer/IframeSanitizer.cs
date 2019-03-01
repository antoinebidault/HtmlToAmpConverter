﻿using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using System;

namespace HtmlToAmpConverter
{
  public class ImgSanitizer : IHtmlToAmpSanitizer
  {
    public void ConvertToAmp(HtmlDocument html)
    {
      var iframes = html.DocumentNode.QuerySelectorAll("iframe");
      foreach (var iframe in iframes)
      {
        iframe.Name = "amp-iframe";
        iframe.DisableAutoClosingTag();
      }
    }
    
  }
}
