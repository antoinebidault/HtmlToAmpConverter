using NUnit.Framework;

namespace HtmlToAmpConverter.Test
{
    public class HtmlToAmpConverter
    {
        [SetUp]
        public void Setup()
        {
          _service = new HtmlToAmp(new System.Collections.Generic.HashSet<IHtmlToAmpConverter> {

          })
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}