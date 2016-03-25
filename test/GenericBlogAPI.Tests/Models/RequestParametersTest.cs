using FluentAssertions;
using GenericBlogAPI.Models;
using Moq;
using NUnit.Framework;

namespace GenericBlogAPI.Tests.Models
{
    [TestFixture]
    public class RequestParametersTest
    {
        [Test]
        public void Should_CreateRequestParametersObject_AndCheckFeedUrlValue()
        {
            const string feedUrl = "http://www.feedurl.com/blog/api/sample";

            var requestParameters = new RequestParameters(feedUrl, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            requestParameters.FeedUrl.Should().Be(feedUrl);
        }

        [Test]
        public void Should_CreateRequestParametersObject_AndCheckLimitValue()
        {
            const string limit = "5";

            var requestParameters = new RequestParameters(It.IsAny<string>(), limit, It.IsAny<string>(), It.IsAny<string>());

            requestParameters.Limit.ToString().Should().Be(limit);
        }

        [Test]
        public void Should_CreateRequestParametersObject_AndCheckOffsetValue()
        {
            const string offset = "1";

            var requestParameters = new RequestParameters(It.IsAny<string>(), It.IsAny<string>(), offset, It.IsAny<string>());

            requestParameters.Offset.ToString().Should().Be(offset);
        }

        [Test]
        public void Should_CreateRequestParametersObject_AndCheckCategoryValue()
        {
            const string category = "sample-category";

            var requestParameters = new RequestParameters(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), category);

            requestParameters.Category.Should().Be(category);
        }

        [Test]
        public void Should_CreateRequestParametersObject_AndGetLimitMaximumAllowedValue()
        {
            const int expected = 10;
            const string limitValue = "20";

            var requestParameters = new RequestParameters(It.IsAny<string>(), limitValue, It.IsAny<string>(), It.IsAny<string>());

            requestParameters.Limit.Should().Be(expected);
        }

        [Test]
        public void Should_CreateRequestParametersObject_AndGetLimitDefaultValue()
        {
            const int expected = 10;
            const string withoutLimitValue = null;

            var requestParameters = new RequestParameters(It.IsAny<string>(), withoutLimitValue, It.IsAny<string>(), It.IsAny<string>());

            requestParameters.Limit.Should().Be(expected);
        }

        [Test]
        public void Should_CreateRequestParametersObject_AndGetOffsetDefaultValue()
        {
            const int expected = 0;
            const string withoutOffsetValue = null;

            var requestParameters = new RequestParameters(It.IsAny<string>(), It.IsAny<string>(), withoutOffsetValue, It.IsAny<string>());

            requestParameters.Offset.Should().Be(expected);
        }

        [Test]
        public void ShouldNot_ThrowAnException_WhenCreatingRequestParametersObject_WithNullValueCategory()
        {
            var requestParameters = new RequestParameters(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), null);

            requestParameters.Category.Should().BeNull();
        }
    }
}