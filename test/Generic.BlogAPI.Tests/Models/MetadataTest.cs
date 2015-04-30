using FluentAssertions;
using Generic.BlogAPI.Models;
using NUnit.Framework;

namespace Generic.BlogAPI.Tests.Models
{
    [TestFixture]
    public class MetadataTest
    {
        private const int Limit = 5;
        private const int Offset = 3;

        [Test]
        public void Should_CreateMetadataObject_AndValidateLimitValue()
        {
            var obtained = new Metadata(Limit, Offset);

            obtained.Limit.Should().Be(Limit);
        }

        [Test]
        public void Should_CreateMetadataObject_AndValidateOffsetValue()
        {
            var obtained = new Metadata(Limit, Offset);

            obtained.Offset.Should().Be(Offset);
        }
    }
}