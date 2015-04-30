using FluentAssertions;
using Generic.BlogAPI.Controllers;
using Generic.BlogAPI.DI;
using NUnit.Framework;

namespace Generic.BlogAPI.Tests.DI
{
    [TestFixture]
    public class DIContainerTest
    {
        [Test]
        public void Should_ResolveDependencies_UsingDIContainerClass()
        {
            var controller = DIContainer.Resolve<PostsController>();

            controller.Should().NotBeNull();
        }
    }
}