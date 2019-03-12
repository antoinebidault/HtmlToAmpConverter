using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using Microsoft.Extensions.Options;
using System;

namespace HtmlToAmpConverter
{
  public class IframeSanitizer : IHtmlToAmpSanitizer
  {
    private HtmlToAmpOptions _options;

    public IframeSanitizer(IOptions<HtmlToAmpOptions> options)
    {
      _options = options.Value;
    }
    public void ConvertToAmp(HtmlDocument html)
    {
      var iframes = html.DocumentNode.QuerySelectorAll("iframe");
      foreach (var iframe in iframes)
      {
        iframe.Name = "amp-iframe";

        string width = iframe.Attributes["width"]?.Value;
        string height = iframe.Attributes["height"]?.Value;
        string iframeSrc = iframe.Attributes["src"]?.Value;

        iframe.Attributes.RemoveAll();

        iframe.SetAttributeValue("width", width ?? _options.DefaultIframeWidth.ToString());
        iframe.SetAttributeValue("height", height ?? _options.DefaultIframeHeight.ToString());
        iframe.SetAttributeValue("layout", "responsive");
        iframe.SetAttributeValue("sandbox", "allow-scripts allow-same-origin");
        iframe.SetAttributeValue("frameborder", "0");

        // Throw error if no imgSrc
        if (iframeSrc == null)
          throw new HtmlToAmpConvertException(MessageLevel.Error, "The iframe contains no src", iframe.Line);

        if (!string.IsNullOrEmpty(iframeSrc))
          iframe.SetAttributeValue("src", iframeSrc.FixUrl());

        iframe.DisableAutoClosingTag();
      }
    }
  }
}
