using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

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


                // Throw error if no imgSrc
                if (imgSrc == null && imgSrcSet == null)
                    throw new HtmlToAmpConvertException(MessageLevel.Error, "The image contains no src", img.Line);

                img.Attributes.RemoveAll();

                img.SetAttributeValue("layout", _options.DefaultObjectLayout.ToString());

                if (_options.DefaultObjectLayout == AmpObjectLayout.responsive)
                {
                    img.SetAttributeValue("width", width ?? _options.DefaultImgWidth.ToString());
                    img.SetAttributeValue("height", height ?? _options.DefaultImgHeight.ToString());
                }

                if (!string.IsNullOrEmpty(imgSrcSet))
                    img.SetAttributeValue("srcset", imgSrcSet);

                if (!string.IsNullOrEmpty(imgSrc))
                    img.SetAttributeValue("src", imgSrc.FixUrl());

                img.DisableAutoClosingTag();
            }


        }
    }

}
