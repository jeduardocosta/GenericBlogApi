using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using Generic.BlogAPI.Core.Clients;
using Generic.BlogAPI.Core.Entities;
using Generic.BlogAPI.Core.Entities.FeedResponse;
using Generic.BlogAPI.Core.Exceptions;
using Generic.BlogAPI.Core.Parsers;
using Generic.BlogAPI.Core.Readers;
using Moq;
using NUnit.Framework;

namespace Generic.BlogAPI.Core.Tests.Readers
{
    [TestFixture]
    public class BlogFeedReaderTest
    {
        private Mock<IBlogFeedContentParser> _mockBlogFeedContentParser;
        private Mock<IWebClient> _mockWebClient;
        private Mock<IJsonParser> _mockJsonParser;

        private IBlogFeedReader _blogFeedReader;

        private const string SampleCategoryName = "seguros";
        private IDictionary _filters;
        private Pagination _pagination;
        
        private const string ValidFeedUrl = "http://www.feedforall.com/sample.xml";
        private const string InvalidFeedUrl = "domain.com/blog/feed";

        [SetUp]
        public void Init()
        {
            _filters = new Dictionary<string, string> {{"category", SampleCategoryName}};
            _pagination = new Pagination(5, 0);

            _mockBlogFeedContentParser = new Mock<IBlogFeedContentParser>();
            _mockWebClient = new Mock<IWebClient>();
            _mockJsonParser = new Mock<IJsonParser>();

            _mockBlogFeedContentParser
                .Setup(it => it.Parse(It.IsAny<IEnumerable<Post>>()))
                .Returns(GivenAnSetOfBlogFeedContent());

            _mockWebClient
                .Setup(it => it.GetContent(It.IsAny<string>()))
                .Returns("json-value");

            _mockJsonParser
                .Setup(it => it.Parse<FeedResponseRoot>(It.IsAny<string>()))
                .Returns(new FeedResponseRoot());

            _blogFeedReader = new BlogFeedReader(_mockBlogFeedContentParser.Object,
                _mockJsonParser.Object,
                _mockWebClient.Object);
        }

        [Test]
        public void Should_ReadBlogFeedContent_UsingBlogFeedReader()
        {
            var obtained = _blogFeedReader.Read(ValidFeedUrl, _filters, _pagination);

            _mockWebClient.Verify(it => it.GetContent(It.IsAny<string>()), Times.Once);
            _mockJsonParser.Verify(it => it.Parse<FeedResponseRoot>(It.IsAny<string>()), Times.Once);
            _mockBlogFeedContentParser.Verify(it => it.Parse(It.IsAny<IEnumerable<Post>>()), Times.Once);

            obtained.Should().NotBeNull();
        }

        [Test]
        [ExpectedException(typeof(CustomErrorException))]
        public void Should_ThrowException_WhenReadFeedUrl_WithInvalidEntryUrl()
        {
            _blogFeedReader.Read(InvalidFeedUrl, _filters, _pagination);
        }

        [Test]
        [ExpectedException(typeof(CustomErrorException))]
        public void Should_ThrowException_WhenReadFeedUrl_AndGetNullOrEmptyValue_FromWebClientProcess()
        {
            _mockWebClient
                .Setup(it => it.GetContent(It.IsAny<string>()))
                .Returns(string.Empty);

            _blogFeedReader.Read(ValidFeedUrl, _filters, _pagination);
        }

        [Test]
        [ExpectedException(typeof(NotFoundException))]
        public void Should_ThrowException_WhenReadFeedUrl_AndGetNotFoundResult_FromWebClientProcess()
        {
            _mockWebClient
                .Setup(it => it.GetContent(It.IsAny<string>()))
                .Returns("Not found");

            _blogFeedReader.Read(ValidFeedUrl, _filters, _pagination);
        }

        private IEnumerable<BlogFeedContent> GivenAnSetOfBlogFeedContent()
        {
            return new List<BlogFeedContent>
            {
                new BlogFeedContent.BlogFeedContentBuilder()
                    .WithTitle("title")
                    .Build()
            };
        }
    }
}