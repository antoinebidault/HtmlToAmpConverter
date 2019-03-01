using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace HtmlToAmpConverter
{
  public class HtmlToAmpConvertResult
  {
    public HtmlToAmpConvertResult()
    {
      this.Messages = new List<HtmlToAmpMessage>();
    }
    public string Result { get; set; }
    public IList<HtmlToAmpMessage> Messages { get; set; }
  }


}
