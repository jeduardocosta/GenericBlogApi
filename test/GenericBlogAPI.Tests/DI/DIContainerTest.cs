using FluentAssertions;
using GenericBlogAPI.Controllers;
using GenericBlogAPI.DI;
using NUnit.Framework;

namespace GenericBlogAPI.Tests.DI
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