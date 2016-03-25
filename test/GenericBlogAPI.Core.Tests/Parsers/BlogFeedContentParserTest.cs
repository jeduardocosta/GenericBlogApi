using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FluentAssertions;
using GenericBlogAPI.Core.Entities;
using GenericBlogAPI.Core.Entities.FeedResponse;
using GenericBlogAPI.Core.Entities.FeedResponse.Images;
using GenericBlogAPI.Core.Entities.FeedResponse.Images.Full;
using GenericBlogAPI.Core.Helpers;
using GenericBlogAPI.Core.Parsers;
using Moq;
using NUnit.Framework;

namespace GenericBlogAPI.Core.Tests.Parsers
{
    [TestFixture]
    public class BlogFeedContentParserTest
    {
        private IBlogFeedContentParser _blogFeedContentParser;

        private const string SampleTitle = "sample title";
        private const string SampleCategory = "sample category";
        private const string SampleExcerpt = "sample excerpt";
        private const string SampleUrl = "http://www.domain.com/blog";

        private readonly IEnumerable<string> _sampleCategories = new List<string> {SampleCategory};
        private readonly DateTime _samplePublishDate = DateTime.Now;
        private readonly ThumbnailImages _sampleThumbnailImages = new ThumbnailImages {full = new Full2()};

        private Mock<IDatetimeParser> _datetimeParserMock;
        private Mock<IHtmlHelper> _htmlHelperMock;

        [SetUp]
        public void Init()
        {
            _datetimeParserMock = new Mock<IDatetimeParser>();
            _htmlHelperMock = new Mock<IHtmlHelper>();

            _datetimeParserMock
                .Setup(it => it.ParseFromStringValue(It.IsAny<string>()))
                .Returns(_samplePublishDate);

            _htmlHelperMock
                .Setup(it => it.RemoveTags(SampleExcerpt))
                .Returns(SampleExcerpt);

            _blogFeedContentParser = new BlogFeedContentParser(_datetimeParserMock.Object, _htmlHelperMock.Object);
        }

        [Test]
        public void Should_ParsePostList_UsingBlogFeedContentParser()
        {
            var posts = GivenAListOfPostObject();

            var expected = new List<BlogFeedContent> 
            { 
                new BlogFeedContent
                .BlogFeedContentBuilder()
                .WithTitle(SampleTitle)
                .WithCategories(_sampleCategories)
                .WithPublishDate(_samplePublishDate)
                .WithUrl(SampleUrl)
                .WithSummary(SampleExcerpt)
                .WithThumbnailImages(_sampleThumbnailImages)
                .Build()
            };

            var obtained = _blogFeedContentParser.Parse(posts).ToList();

            AreEqual(expected, obtained).Should().BeTrue();
        }

        private IEnumerable<Post> GivenAListOfPostObject()
        {
            return new List<Post>
            {
                new Post
                {
                    date = _samplePublishDate.ToString(CultureInfo.InvariantCulture),
                    title = SampleTitle,
                    categories = new List<Category>{new Category{title = SampleCategory}},
                    url = SampleUrl,
                    excerpt = SampleExcerpt,
                    thumbnail_images = _sampleThumbnailImages
                }
            };
        }

        private bool AreEqual(IEnumerable<BlogFeedContent> source, IEnumerable<BlogFeedContent> destination)
        {
            var sourceList = source.ToList();
            var destinationList = destination.ToList();

            if (sourceList.Count != destinationList.Count)
                return false;

            var counter = sourceList.Count;

            for (var index = 0; index < counter; index++)
            {
                if (!AreEqual(sourceList[index], destinationList[index]))
                    return false;
            }

            return true;
        }

        private bool AreEqual(BlogFeedContent source, BlogFeedContent destination)
        {
            return source.Categories.SequenceEqual(destination.Categories) &&
                   source.PublishDate.Equals(destination.PublishDate) &&
                   source.Title.Equals(destination.Title) &&
                   source.Summary.Equals(destination.Summary) &&
                   source.Url.Equals(destination.Url);
        }
    }
}