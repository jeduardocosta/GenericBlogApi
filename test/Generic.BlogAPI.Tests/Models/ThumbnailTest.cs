using FluentAssertions;
using Generic.BlogAPI.Core.Entities.FeedResponse.Images;
using Generic.BlogAPI.Models;
using NUnit.Framework;

namespace Generic.BlogAPI.Tests.Models
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