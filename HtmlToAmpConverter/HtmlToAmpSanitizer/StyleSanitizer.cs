using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace HtmlToAmpConverter
{
  public class StyleSanitizer : IHtmlToAmpSanitizer
  {
    public StyleSanitizer()
    {
    }
    public void ConvertToAmp(HtmlDocument html)
    {
      var styles = html.DocumentNode.QuerySelectorAll("style");
      int line = 0;
      foreach (var script in styles)
      {
        line = script.Line;
        script.Remove();
      }

      if (styles.Any())
      {
        throw new HtmlToAmpConvertException(MessageLevel.Warning, "<style> element striped. This element is not allowed in AMP", line);
      };
    }
  }

}
