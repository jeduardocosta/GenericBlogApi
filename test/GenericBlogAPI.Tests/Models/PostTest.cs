using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GenericBlogAPI.Core.Entities;
using GenericBlogAPI.Core.Entities.FeedResponse.Images;
using GenericBlogAPI.Models;
using NUnit.Framework;

namespace GenericBlogAPI.Tests.Models
{
    [TestFixture]
    public class PostTest
    {
        private readonly DateTime _publishDate = DateTime.Now;
        private readonly IEnumerable<string> _categories = new[] { "category 1", "category 2" };
        private readonly IEnumerable<string> _tags = new[] { "tag 1", "tag 2" };
        private readonly IEnumerable<Thumbnail> _thumbnails = new[] {new Thumbnail(new ThumbnailImages())};

        private const int Id = 1234;
        private const string Title = "sample-title";
        private const string Summary = "sample-summary";
        private const string Content = "sample-content";
        private const string Url = "http://www.something.com/blog";

        [Test]
        public void Should_CreatePostsObject()
        {
            var obtained = new Post(Id, Title, _publishDate, _categories, Url, Summary, _thumbnails, _tags);

            AreEqualWithSourceParameters(obtained).Should().BeTrue();
        }

        [Test]
        public void Should_CreatePostsObject_FromBlogFeedContentObject()
        {
            var blogFeedContent = new BlogFeedContent
                .BlogFeedContentBuilder()
                .WithTitle(Title)
                .WithCategories(_categories)
                .WithPublishDate(_publishDate)
                .WithFullContent(Content)
                .WithUrl(Url)
                .WithThumbnailImages(new ThumbnailImages())
                .WithTags(_tags)
                .Build();

            var obtained = new Post(blogFeedContent);

            AreEqualWithSourceParameters(obtained).Should().BeTrue();
        }

        private bool AreEqualWithSourceParameters(Post destinationPost)
        {
            return Title == destinationPost.Title &&
                   _publishDate == destinationPost.PublishDate &&
                   _categories.SequenceEqual(destinationPost.Categories) &&
                   Url == destinationPost.Url &&
                   _tags.SequenceEqual(destinationPost.Tags);
        }
    }
}