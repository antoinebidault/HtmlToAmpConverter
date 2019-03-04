using NUnit.Framework;
using System.Collections.Generic;

namespace HtmlToAmpConverter.Test
{
  public class HtmlToAmpConverter
  {
    private HtmlToAmp _service;

    [SetUp]
    public void Setup()
    {
      _service = new Img();
    }

    [Test]
    public void Test1()
    {
     string outputHtml = _service.ConvertToAmp("<img src=\"https://test.jpg\" width=\"540\" height=\"480\">").Result;
     Assert.AreEqual(outputHtml, "<amp-img src=\"https://test.jpg\" width=\"540\" height=\"480\"></amp-img>");
    }
  }
}