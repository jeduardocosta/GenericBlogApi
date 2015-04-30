using FluentAssertions;
using Generic.BlogAPI.Core.Helpers;
using NUnit.Framework;

namespace Generic.BlogAPI.Core.Tests.Helpers
{
    [TestFixture]
    public class HtmlHelperTest
    {
        private IHtmlHelper _htmlHelper;

        [SetUp]
        public void Setup()
        {
            _htmlHelper = new HtmlHelper();
        }

        [Test]
        public void Should_ExtractHtmlTags_FromContent()
        {
            const string entry = @"<p><h3>Visando a interação da nova diretoria com o mercado de seguros</h3></p>";

            const string expected = "Visando a interação da nova diretoria com o mercado de seguros";

            var obtained = _htmlHelper.RemoveTags(entry);

            obtained.Should().Be(expected);
        }
    }
}