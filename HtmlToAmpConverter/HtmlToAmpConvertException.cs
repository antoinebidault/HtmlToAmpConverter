using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace HtmlToAmpConverter
{
  [Serializable]
  public class HtmlToAmpConvertException: Exception
  {
    public HtmlToAmpConvertException(MessageLevel level,string message, int lineNumberError) : base(message)
    {
      this.LineNumber = LineNumber;
      this.Level = level;
    }

    public int LineNumber { get; }
    public MessageLevel Level { get; }
  }
}
