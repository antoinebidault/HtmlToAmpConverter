using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using Microsoft.Extensions.Options;

namespace HtmlToAmpConverter
{
  public class YoutubeSanitizer : IHtmlToAmpSanitizer
  {
    private HtmlToAmpOptions _options;

    public YoutubeSanitizer(IOptions<HtmlToAmpOptions> options)
    {
      _options = options.Value;
    }

    public void ConvertToAmp(HtmlDocument html)
    {
      var iframes = html.DocumentNode.QuerySelectorAll("iframe");
      foreach (var iframe in iframes)
      {
        string iframeSrc = iframe.Attributes["src"]?.Value.FixUrl();
        if (iframeSrc.StartsWith("https://www.youtube.com/embed/"))
        {
          iframe.Name = "amp-youtube";

          string width = iframe.Attributes["width"]?.Value;
          string height = iframe.Attributes["height"]?.Value;

          // Check querystring & remove it if not necessary
          if (iframeSrc.IndexOf("?") > -1)
            iframeSrc = iframeSrc.Split('?')[0];

          string idVideo = iframeSrc.Replace("https://www.youtube.com/embed/", "");

          iframe.Attributes.RemoveAll();

          iframe.SetAttributeValue("data-videoid", idVideo);
          iframe.SetAttributeValue("width", width ?? _options.DefaultIframeWidth.ToString());
          iframe.SetAttributeValue("height", height ?? _options.DefaultIframeHeight.ToString());
          iframe.SetAttributeValue("layout", "responsive");

          iframe.DisableAutoClosingTag();

        }
      }
    }
  }
}
