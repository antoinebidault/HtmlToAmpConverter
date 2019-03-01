using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using System;

namespace HtmlToAmpConverter
{
  public class ScriptSanitizer : IHtmlToAmpSanitizer
  {
    public void ConvertToAmp(HtmlDocument html)
    {
      var imgs = html.DocumentNode.QuerySelectorAll("img");
      foreach (var img in imgs)
      {
        img.Name = "amp-img";
        img.Attributes.Add("layout", "responsive");
        img.DisableAutoClosingTag();
      }
    }
  }
}
