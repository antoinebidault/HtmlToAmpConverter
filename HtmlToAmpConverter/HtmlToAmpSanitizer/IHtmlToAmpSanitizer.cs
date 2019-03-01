using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using System;

namespace HtmlToAmpConverter
{
  public interface IHtmlToAmpSanitizer
  {
    void ConvertToAmp(HtmlDocument html);
  }
}
