using System.Collections.Generic;
using FluentAssertions;
using Generic.BlogAPI.Core.Entities;
using Generic.BlogAPI.Models;
using NUnit.Framework;

namespace Generic.BlogAPI.Tests.Models
{
    [TestFixture]
    public class PostResponseTest
    {
        [Test]
        public void Should_CreatePostResponseObject()
        {
            var requestParameters = new RequestParameters("feedUrl", "10", "0", "category");
            var blogFeedContent = GivenAnSetOfBlogFeedContent();

            var obtained = new PostResponse(requestParameters, blogFeedContent);

            obtained.Should().NotBeNull();
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