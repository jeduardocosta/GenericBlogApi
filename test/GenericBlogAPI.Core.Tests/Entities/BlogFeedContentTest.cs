using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GenericBlogAPI.Core.Entities;
using GenericBlogAPI.Core.Entities.FeedResponse.Images;
using GenericBlogAPI.Core.Entities.FeedResponse.Images.Medium;
using NUnit.Framework;

namespace GenericBlogAPI.Core.Tests.Entities
{
    [TestFixture]
    public class BlogFeedContentTest
    {
        private const int SampleId = 1243;

        private const string SampleTitle = "sample title";
        private const string SampleHtmlContent = "sample html content";
        private const string SampleSummary = "sample summary";
        private const string Url = "http://www.something.com/blog";
        
        private readonly DateTime _samplePublishDate = DateTime.Now;
        private readonly IEnumerable<string> _sampleCategories = new[] { "category 1", "category 2" };
        private readonly IEnumerable<string> _sampleTags = new[] { "tag 1", "tag 2" };
        private readonly ThumbnailImages _thumbnailImages = new ThumbnailImages
        {
            medium = new Medium2 {height = 100, width = 120, url = ""}
        };

        [Test]
        public void Should_CreateBlogFeedContentObject_AndCheckIdParameter()
        {
            var obtained = new BlogFeedContent
                .BlogFeedContentBuilder()
                .WithId(SampleId)
                .Build();

            obtained.Id.Should().Be(SampleId);
        }

        [Test]
        public void Should_CreateBlogFeedContentObject_AndCheckTitleParameter()
        {
            var obtained = new BlogFeedContent
                .BlogFeedContentBuilder()
                .WithTitle(SampleTitle)
                .Build();

            obtained.Title.Should().Be(SampleTitle);
        }

        [Test]
        public void Should_CreateBlogFeedContentObject_AndCheckCategoriesParameter()
        {
            var obtained = new BlogFeedContent
                .BlogFeedContentBuilder()
                .WithCategories(_sampleCategories)
                .Build();

            _sampleCategories.SequenceEqual(obtained.Categories).Should().BeTrue();
        }

        [Test]
        public void Should_CreateBlogFeedContentObject_AndCheckPublishDateParameter()
        {
            var obtained = new BlogFeedContent
                .BlogFeedContentBuilder()
                .WithPublishDate(_samplePublishDate)
                .Build();

            obtained.PublishDate.Should().Be(_samplePublishDate);
        }

        [Test]
        public void Should_CreateBlogFeedContentObject_AndCheckFullContentParameter()
        {
            var obtained = new BlogFeedContent
                .BlogFeedContentBuilder()
                .WithFullContent(SampleHtmlContent)
                .Build();

            obtained.FullContent.Should().Be(SampleHtmlContent);
        }

        [Test]
        public void Should_CreateBlogFeedContentObject_AndCheckUrlParameter()
        {
            var obtained = new BlogFeedContent
                .BlogFeedContentBuilder()
                .WithUrl(Url)
                .Build();

            obtained.Url.Should().Be(Url);
        }

        [Test]
        public void Should_CreateBlogFeedContentObject_AndCheckSummaryParameter()
        {
            var obtained = new BlogFeedContent
                .BlogFeedContentBuilder()
                .WithSummary(SampleSummary)
                .Build();

            obtained.Summary.Should().Be(SampleSummary);
        }

        [Test]
        public void Should_CreateBlogFeedContentObject_AndCheckThumbnailImagesParameter()
        {
            var obtained = new BlogFeedContent
                .BlogFeedContentBuilder()
                .WithThumbnailImages(_thumbnailImages)
                .Build();

            obtained.ThumbnailImages.Should().Be(_thumbnailImages);
        }

        [Test]
        public void Should_CreateBlogFeedContentObject_AndCheckTagsParameter()
        {
            var obtained = new BlogFeedContent
                .BlogFeedContentBuilder()
                .WithTags(_sampleTags)
                .Build();

            _sampleTags.SequenceEqual(obtained.Tags).Should().BeTrue();
        }
    }
}