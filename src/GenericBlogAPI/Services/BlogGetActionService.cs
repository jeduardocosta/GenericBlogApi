using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using GenericBlogAPI.Core.Entities;
using GenericBlogAPI.Core.Readers;
using GenericBlogAPI.Models;
using GenericBlogAPI.Parsers;

namespace GenericBlogAPI.Services
{
    public interface IBlogGetActionService
    {
        PostResponse Get(HttpRequestMessage request, string category);
    }

    public class BlogGetActionService : IBlogGetActionService
    {
        private readonly IRequestParametersParser _requestParametersParser;
        private readonly IBlogFeedReader _blogFeedReader;

        public BlogGetActionService(IRequestParametersParser requestParametersParser, IBlogFeedReader blogFeedReader)
        {
            _requestParametersParser = requestParametersParser;
            _blogFeedReader = blogFeedReader;
        }

        public PostResponse Get(HttpRequestMessage request, string category)
        {
            var requestParameters = _requestParametersParser.Parse(request, category);

            var filters = GetFilters(category);
            var pagination = GetPagination(requestParameters);

            var blogFeedContents = _blogFeedReader.Read(requestParameters.FeedUrl, filters, pagination);

            var postResponse = new PostResponse(requestParameters, blogFeedContents);
            return postResponse;
        }

        private IDictionary GetFilters(string category)
        {
            return new Dictionary<string, string> {{ "category", category }};
        }

        private Pagination GetPagination(RequestParameters requestParameters)
        {
            return new Pagination(requestParameters.Limit, requestParameters.Offset);
        }
    }
}