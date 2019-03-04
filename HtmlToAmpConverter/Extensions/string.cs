namespace HtmlToAmpConverter
{
  internal static class StringExtensions
  {
    /// <summary>
    /// Fix bad formatted url
    /// </summary>
    /// <param name="node"></param>
    internal static string FixUrl(this string url)
    {
      if (url.StartsWith("https://"))
        return url;

      if (url.StartsWith("//"))
        return $"https:{url}";

      if (url.StartsWith("http://"))
        return $"https://{url.Substring(6, url.Length)}";

      return url;

    }
  }
}
