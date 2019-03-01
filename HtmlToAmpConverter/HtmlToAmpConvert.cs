using HtmlAgilityPack;
using System.Collections.Generic;

namespace HtmlToAmpConverter
{
  public class HtmlToAmp
  {
    private HtmlDocument _doc;
    private readonly HashSet<IHtmlToAmpSanitizer> _converters;

    public HtmlToAmp(HashSet<IHtmlToAmpSanitizer> converters)
    {
      _converters = converters;
    }


    public HtmlToAmpConvertResult ConvertToAmp(string html)
    {
      var result = new HtmlToAmpConvertResult();

      // Préparation du document
      _doc = new HtmlDocument();
      _doc.LoadHtml(html);
      
      foreach (var converter in _converters)
      {
        try
        {
          converter.ConvertToAmp(_doc);
        }
        catch (HtmlToAmpConvertException exception)
        {
          result.Messages.Add(exception);
        }
      }

      result.Messages = _doc.DocumentNode.OuterHtml;

      return ;
    }


  }
}
