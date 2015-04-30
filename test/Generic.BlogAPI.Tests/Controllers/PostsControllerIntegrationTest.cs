using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Results;
using FluentAssertions;
using Generic.BlogAPI.Controllers;
using Generic.BlogAPI.DI;
using Generic.BlogAPI.Models;
using NUnit.Framework;

namespace Generic.BlogAPI.Tests.Controllers
{
    [TestFixture]
    public class PostsControllerIntegrationTest
    {
        private PostsController _controller;

        [SetUp]
        public void Init()
        {
            _controller = DIContainer.Resolve<PostsController>();
            _controller.Request = new HttpRequestMessage
            {
                RequestUri = new Uri(@"http://www.localhost.com/blog?feedurl=http://blogminuto.azurewebsites.net/")
            };
        }

        [Test]
        public void Should_GetMetadataLimit_InPostsController_WithIntegration()
        {
            var obtained = _controller.Get();

            var postResponseResult = obtained as OkNegotiatedContentResult<PostResponse>;

            postResponseResult
                .Content
                .Metadata
                .Limit
                .Should()
                .BeGreaterThan(0);
        }

        [Test]
        public void Should_GetPosts_InPostsController_WithIntegration()
        {
            var obtained = _controller.Get();

            var postResponseResult = obtained as OkNegotiatedContentResult<PostResponse>;

            postResponseResult
                .Content
                .Posts
                .Any()
                .Should()
                .BeTrue();
        }
    }
}