using FluentAssertions;
using GenericBlogAPI.Core.Helpers;
using NUnit.Framework;

namespace GenericBlogAPI.Core.Tests.Helpers
{
    [TestFixture]
    public class UrlHelperTest
    {
        private const string InvalidUrl = "blogfeedurl/sample";

        private IUrlHelper _urlHelper;

        [SetUp]
        public void Init()
        {
            _urlHelper = new UrlHelper();
        }

        [Test]
        public void Should_ReturnTrue_ToAValidUrl()
        {
            const string validBlogFeedUrl = "http://www.domain.com/blog/feed/";

            var obtained = _urlHelper.IsValidUrl(validBlogFeedUrl);

            obtained.Should().BeTrue();
        }

        [Test]
        public void Should_ReturnTrue_ToAValidRelativeUrl()
        {
            var obtained = _urlHelper.IsValidUrl(InvalidUrl);

            obtained.Should().BeTrue();
        }

        [Test]
        public void Should_ReturnFalse_ToAInvalidAbsoluteUrl()
        {
            var obtained = _urlHelper.IsValidAbsoluteUrl(InvalidUrl);

            obtained.Should().BeFalse();
        }
    }
}