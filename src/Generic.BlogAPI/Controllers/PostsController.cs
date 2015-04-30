using System;
using System.Web.Http;
using Generic.BlogAPI.Core.Exceptions;
using Generic.BlogAPI.Services;

namespace Generic.BlogAPI.Controllers
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