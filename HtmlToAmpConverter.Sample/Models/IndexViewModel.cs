using System.Collections.Generic;

namespace HtmlToAmpConverter.Sample.Models
{
  public class IndexViewModel
  {
    public IList<HtmlToAmpMessage> Messages { get; set; }
    public string Content { get; set; }
    public int Timer { get; internal set; }
  }
}