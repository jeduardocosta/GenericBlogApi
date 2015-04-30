using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Results;
using FluentAssertions;
using Generic.BlogAPI.Controllers;
using Generic.BlogAPI.Core.Entities;
using Generic.BlogAPI.Core.Exceptions;
using Generic.BlogAPI.Models;
using Generic.BlogAPI.Services;
using Moq;
using NUnit.Framework;

namespace Generic.BlogAPI.Tests.Controllers
{
    [TestFixture]
    public class PostsControllerTest
    {
        private PostsController _controller;

        private Mock<IBlogGetActionService> _blogGetActionServiceMock;

        private const string Limit = "10";
        private const string Offset = "0";

        private HttpRequestMessage _httpRequestMessage;
        private RequestParameters _requestParameters;

        [SetUp]
        public void Init()
        {
            _requestParameters = new RequestParameters(It.IsAny<string>(), Limit, Offset, It.IsAny<string>());

            _blogGetActionServiceMock = new Mock<IBlogGetActionService>();

            _httpRequestMessage = new HttpRequestMessage();
            var blogFeedContents = new List<BlogFeedContent>();

            _blogGetActionServiceMock
                .Setup(it => it.Get(_httpRequestMessage, It.IsAny<string>()))
                .Returns(new PostResponse(_requestParameters, blogFeedContents));

            _controller = new PostsController(_blogGetActionServiceMock.Object) {Request = _httpRequestMessage};
        }

        [Test]
        public void Should_GetPosts_InPostsController()
        {
            var obtained = _controller.Get();

            _blogGetActionServiceMock.Verify(it => it.Get(_httpRequestMessage, It.IsAny<string>()), Times.Once);

            obtained.Should().BeOfType(typeof (OkNegotiatedContentResult<PostResponse>));
        }

        [Test]
        public void Should_GetPosts_WithCategoryParameter_InPostsController()
        {
            const string category = "category-1";

            var obtained = _controller.Get(category);

            _blogGetActionServiceMock.Verify(it => it.Get(_httpRequestMessage, category), Times.Once);

            obtained.Should().BeOfType(typeof(OkNegotiatedContentResult<PostResponse>));
        }

        [Test]
        public void Should_ReturnInternalServerError_WhenCustomErrorExceptionIsThrow_InPostsController()
        {
            const string errorMessage = "sample error message";

            _blogGetActionServiceMock
                .Setup(it => it.Get(_httpRequestMessage, It.IsAny<string>()))
                .Throws(new CustomErrorException(errorMessage));

            var obtained = _controller.Get();

            obtained.Should().BeOfType(typeof(ExceptionResult));
        }

        [Test]
        public void Should_ReturnInternalServerError_WhenExceptionIsThrow_InPostsController()
        {
            _blogGetActionServiceMock
                .Setup(it => it.Get(_httpRequestMessage, It.IsAny<string>()))
                .Throws(new Exception());

            var obtained = _controller.Get();

            obtained.Should().BeOfType(typeof(ExceptionResult));
        }
    }
}
