using System;
using FluentAssertions;
using GenericBlogAPI.Core.Exceptions;
using NUnit.Framework;

namespace GenericBlogAPI.Core.Tests.Exceptions
{
    [TestFixture]
    public class InternalServerErrorExceptionTest
    {
        [Test]
        public void Should_ReturnAnExactErrorMessage_InInternalServerErrorException()
        {
            const string expected = "Internal server error.";

            try
            {
                throw new InternalServerErrorException();
            }
            catch (InternalServerErrorException exception)
            {
                string.Equals(expected, exception.Message, StringComparison.OrdinalIgnoreCase)
                    .Should()
                    .BeTrue();
            }
        }
    }
}