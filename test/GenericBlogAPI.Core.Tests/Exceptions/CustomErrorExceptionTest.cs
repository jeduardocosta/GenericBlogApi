using FluentAssertions;
using GenericBlogAPI.Core.Exceptions;
using NUnit.Framework;

namespace GenericBlogAPI.Core.Tests.Exceptions
{
    [TestFixture]
    public class CustomErrorExceptionTest
    {
        [Test]
        public void Should_ReturnTheEntryMessage_InCustomErrorException()
        {
            const string expected = "sample error message";
            const string entry = "sample error message";

            try
            {
                throw new CustomErrorException(entry);
            }
            catch (CustomErrorException exception)
            {
                exception.Message.Should().Be(expected);
            }
        }
    }
}