using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using System.Linq;

namespace HtmlToAmpConverter
{
  public class FormSanitizer : IHtmlToAmpSanitizer
  {
    public void ConvertToAmp(HtmlDocument html)
    {
      var forms = html.DocumentNode.QuerySelectorAll("form");
      int line = 0;
      foreach (var form in forms)
      {
        form.Name = "amp-form";
        if (!form.Attributes.Contains("action")) { 
          throw new HtmlToAmpConvertException(MessageLevel.Warning, "<form> element invalid. the action is not provided", form.Line);
        }
        else
        {
          form.SetAttributeValue("action-xhr", form.Attributes["action"].Value);
        }

      }
    }
  }
}
