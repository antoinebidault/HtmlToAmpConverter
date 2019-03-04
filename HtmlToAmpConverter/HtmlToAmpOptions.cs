using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace HtmlToAmpConverter
{
  public class HtmlToAmpOptions 
  {
    /// <summary>
    /// Default img height in px 
    /// if not procided in height attribute on html <img> tag provided
    /// </summary>
    public int DefaultImgHeight { get; set; } = 388;

    /// <summary>
    /// Default img width 
    /// if not provided in width attribute on html <img> tag provided
    /// </summary>
    public int DefaultImgWidth { get; set; } = 690;

    internal HashSet<Type> SanitizerTypes { get; set; }
   
    public HtmlToAmpOptions()
    {
      SanitizerTypes = new HashSet<Type>();

      // Default sanitizer
      AddSanitizer<IframeSanitizer>();
      AddSanitizer<ImgSanitizer>();
      AddSanitizer<ScriptSanitizer>();
    }
    public void AddSanitizer<T>() where T : IHtmlToAmpSanitizer
    {
      SanitizerTypes.Add(typeof(T));
    }
  }


}
