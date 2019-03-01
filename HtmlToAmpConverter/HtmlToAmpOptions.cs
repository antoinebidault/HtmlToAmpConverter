using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace HtmlToAmpConverter
{
  public class HtmlToAmpOptions
  {

    internal HashSet<Type> SanitizerTypes { get; set; }
   
    public HtmlToAmpOptions()
    {
      SanitizerTypes = new HashSet<Type>();
    }

    public void AddSanitizer<T>() where T : IHtmlToAmpSanitizer
    {
      SanitizerTypes.Add(typeof(T));
    }
  }
}
