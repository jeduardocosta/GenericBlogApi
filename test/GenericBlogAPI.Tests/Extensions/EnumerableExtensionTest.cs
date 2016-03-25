using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GenericBlogAPI.Core.Extensions;
using NUnit.Framework;

namespace GenericBlogAPI.Tests.Extensions
{
    [TestFixture]
    public class EnumerableExtensionTest
    {
        [Test]
        public void Should_DoPagination_InListStructure()
        {
            const int limit = 3;
            const int offset = 1;

            var records = Enumerable.Range(1, 10);

            var expected = new List<int> { 4, 5, 6 };

            var obtained = records.Pagination(limit, offset);

            expected.SequenceEqual(obtained).Should().BeTrue();
        }
    }
}