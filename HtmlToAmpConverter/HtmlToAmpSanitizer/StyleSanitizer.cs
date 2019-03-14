using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace HtmlToAmpConverter
{
  public class StyleSanitizer : IHtmlToAmpSanitizer
  {
    private IOptions<HtmlToAmpOptions> _options;

    public StyleSanitizer(IOptions<HtmlToAmpOptions> options)
    {
      _options = options;
    }
    public void ConvertToAmp(HtmlDocument html)
    {
      var styles = html.DocumentNode.QuerySelectorAll("style");
      int line = 0;
      for (int i = 0; i < styles.Count; i++)
      {
        line = styles[i].Line;
        styles[i].Remove();
      }


      if (_options.Value.RemoveStyleAttribute)
      {
        var eltWithStyleAttributes = html.DocumentNode.QuerySelectorAll("[style]");
        foreach (var eltWithStyleAttribute in eltWithStyleAttributes)
        {
          eltWithStyleAttribute.Attributes.Remove("style");
        }
      }


      if (styles.Any())
      {
        throw new HtmlToAmpConvertException(MessageLevel.Warning, "<style> element striped. This element is not allowed in AMP", line);
      };
    }
  }

}
