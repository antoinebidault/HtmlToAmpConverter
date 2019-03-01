using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace HtmlToAmpConverter
{
  internal static class HtmlNodeExtensions
  {
    /// <summary>
    /// Transform <img /> to <img></img>
    /// </summary>
    /// <param name="node"></param>
    internal static void DisableAutoClosingTag(this HtmlNode node)
    {
      node.InnerHtml = " ";
      node.InnerHtml = "";
    }
  }
}
