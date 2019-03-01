namespace HtmlToAmpConverter
{
  public class HtmlToAmpMessage
  {
    public MessageLevel Level { get; set; }
    public string Message { get; set; }
    public int LineNumber { get; set; }
  }

  public enum MessageLevel
  {
    Warning,
    Error
  }
}
