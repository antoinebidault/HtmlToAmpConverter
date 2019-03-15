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

      if (string.IsNullOrEmpty(html))
      {
        result.Result = html;
        result.Messages = new List<HtmlToAmpMessage> {
           new HtmlToAmpMessage() {
            Level = MessageLevel.Warning,
            Message = "No html input"
          }
        };
        return result;
      }

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
          // Fill the error & warning viewbag
          result.Messages.Add(new HtmlToAmpMessage
          {
            Level = exception.Level,
            LineNumber = exception.LineNumber,
            Message = exception.Message
          });
        }
      }

      result.Result = _doc.DocumentNode.OuterHtml;

      return result;
    }


  }
}
