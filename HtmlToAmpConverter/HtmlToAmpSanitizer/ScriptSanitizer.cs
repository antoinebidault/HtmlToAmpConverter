using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using System.Linq;

namespace HtmlToAmpConverter
{
  public class ScriptSanitizer : IHtmlToAmpSanitizer
  {
    public void ConvertToAmp(HtmlDocument html)
    {
      var scripts = html.DocumentNode.QuerySelectorAll("script");
      int line = 0;
      foreach (var script in scripts)
      {
        line = script.Line;
        script.Remove();
      }

      if (scripts.Any())
      {
        throw new HtmlToAmpConvertException(MessageLevel.Warning, "<script> element striped. This element is not allowed in AMP", line);
      };
    }


  }
}
