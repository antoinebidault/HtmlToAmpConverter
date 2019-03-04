using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using Microsoft.Extensions.Options;
using System;

namespace HtmlToAmpConverter
{
  public class ImgSanitizer : IHtmlToAmpSanitizer
  {
    private HtmlToAmpOptions _options;

    public ImgSanitizer(IOptions<HtmlToAmpOptions> options)
    {
      _options = options.Value;
    }
    public void ConvertToAmp(HtmlDocument html)
    {
      var imgs = html.DocumentNode.QuerySelectorAll("img");
      foreach (var img in imgs)
      {
        img.Name = "amp-img";

        string width = img.Attributes["width"]?.Value;
        string height = img.Attributes["height"]?.Value;
        string imgSrc = img.Attributes["src"]?.Value;
        string imgSrcSet = img.Attributes["srcset"]?.Value;

        img.Attributes.RemoveAll();

        img.SetAttributeValue("width", width ?? _options.DefaultImgWidth.ToString());
        img.SetAttributeValue("height", height ?? _options.DefaultImgHeight.ToString());
        img.SetAttributeValue("layout", "responsive");

        if (!string.IsNullOrEmpty(imgSrcSet))
          img.SetAttributeValue("srcset", imgSrcSet);

        if (!string.IsNullOrEmpty(imgSrc))
          img.SetAttributeValue("src", imgSrc.FixUrl());

        img.DisableAutoClosingTag();
      }
    }
  }

}
