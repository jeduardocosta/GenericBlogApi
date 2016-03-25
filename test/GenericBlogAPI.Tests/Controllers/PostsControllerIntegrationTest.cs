using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Results;
using FluentAssertions;
using GenericBlogAPI.Controllers;
using GenericBlogAPI.DI;
using GenericBlogAPI.Models;
using NUnit.Framework;

namespace GenericBlogAPI.Tests.Controllers
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
                RequestUri = new Uri(@"http://www.localhost.com/blog?feedurl=https://www.minutoseguros.com.br/blog")
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