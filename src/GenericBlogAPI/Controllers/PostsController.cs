using System;
using System.Web.Http;
using GenericBlogAPI.Core.Exceptions;
using GenericBlogAPI.Services;

namespace GenericBlogAPI.Controllers
{
    public class PostsController : ApiController
    {
        private readonly IBlogGetActionService _blogGetActionService;

        public PostsController(IBlogGetActionService blogGetActionService)
        {
            _blogGetActionService = blogGetActionService;
        }

        [Route("posts")]
        public IHttpActionResult Get()
        {
            string category = null;
            return Get(category);
        }

        [Route("posts/{category}")]
        public IHttpActionResult Get(string category)
        {
            try
            {
                var postResponse = _blogGetActionService.Get(Request, category);
                return Ok(postResponse);
            }
            catch (CustomErrorException customErrorException)
            {
                return InternalServerError(customErrorException);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception exception)
            {
                return InternalServerError(new InternalServerErrorException());
            }
        }
    }
}