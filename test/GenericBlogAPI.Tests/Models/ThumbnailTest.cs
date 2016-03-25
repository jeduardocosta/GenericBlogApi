using FluentAssertions;
using GenericBlogAPI.Core.Entities.FeedResponse.Images;
using GenericBlogAPI.Models;
using NUnit.Framework;

namespace GenericBlogAPI.Tests.Models
{
    [TestFixture]
    public class ThumbnailTest
    {
        [Test]
        public void ShouldNot_ThrowAnException_AndShoudlCreateThumbnailObject_WhenTheThumbnailImagesValueIsNull()
        {
            ThumbnailImages thumbnailImages = null;

            var thumbnail = new Thumbnail(thumbnailImages);

            thumbnail.Should().NotBeNull();
        }
    }
}