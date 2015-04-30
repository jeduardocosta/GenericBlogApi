using System;
using System.Net.Http;
using FluentAssertions;
using Generic.BlogAPI.Parsers;
using NUnit.Framework;

namespace Generic.BlogAPI.Tests.Parsers
{
    [TestFixture]
    public class RequestParametersParserTest
    {
        private IRequestParametersParser _requestParametersParser;

        private const string FeedUrl = "http://www.blog.com/feed";
        private const string Limit = "8";
        private const string Offset = "2";

        private const string Category = "sample-category";

        [SetUp]
        public void Init()
        {
            _requestParametersParser = new RequestParametersParser();
        }

        [Test]
        public void Should_GetFeedUrlValue_FromConfigurationFile_UsingParser()
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(string.Format("http://www.something.com/api/resource?feedurl={0}", FeedUrl))
            };

            var obtained = _requestParametersParser.Parse(httpRequestMessage, Category);

            obtained.FeedUrl.Should().Be(FeedUrl);
        }

        [Test]
        public void Should_GetLimitValue_FromHttpRequestParameters_UsingParser()
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(string.Format("http://www.something.com/api/resource?limit={0}", Limit))
            };

            var obtained = _requestParametersParser.Parse(httpRequestMessage, Category);

            obtained.Limit.ToString().Should().Be(Limit);
        }

        [Test]
        public void Should_GetOffsetValue_FromHttpRequestParameters_UsingParser()
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(string.Format("http://www.something.com/api/resource?offset={0}", Offset))
            };

            var obtained = _requestParametersParser.Parse(httpRequestMessage, Category);

            obtained.Offset.ToString().Should().Be(Offset);
        }

        [Test]
        public void Should_GetFeedUrl_AndIgnoreCase_FromHttpRequestParameters_UsingParser()
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(string.Format("http://www.something.com/api/resource?FEedUrL={0}&LIMIT={1}&offSET={2}", FeedUrl, Limit, Offset))
            };

            var obtained = _requestParametersParser.Parse(httpRequestMessage, Category);

            obtained.FeedUrl.Should().Be(FeedUrl);
        }

        [Test]
        public void Should_GetLimit_AndIgnoreCase_FromHttpRequestParameters_UsingParser()
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(string.Format("http://www.something.com/api/resource?FEedUrL={0}&LIMIT={1}&offSET={2}", FeedUrl, Limit, Offset))
            };

            var obtained = _requestParametersParser.Parse(httpRequestMessage, Category);

            obtained.Limit.ToString().Should().Be(Limit);
        }

        [Test]
        public void Should_GetOffset_AndIgnoreCase_FromHttpRequestParameters_UsingParser()
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(string.Format("http://www.something.com/api/resource?FEedUrL={0}&LIMIT={1}&offSET={2}", FeedUrl, Limit, Offset))
            };

            var obtained = _requestParametersParser.Parse(httpRequestMessage, Category);

            obtained.Offset.ToString().Should().Be(Offset);
        }
    }
}