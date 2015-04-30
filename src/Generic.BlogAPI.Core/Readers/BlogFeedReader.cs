using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Generic.BlogAPI.Core.Clients;
using Generic.BlogAPI.Core.Entities;
using Generic.BlogAPI.Core.Entities.FeedResponse;
using Generic.BlogAPI.Core.Exceptions;
using Generic.BlogAPI.Core.Parsers;

namespace Generic.BlogAPI.Core.Readers
{
    public interface IBlogFeedReader
    {
        IEnumerable<BlogFeedContent> Read(string sourceFeedUrl, IDictionary filters, Pagination pagination);
    }

    public class BlogFeedReader : IBlogFeedReader
    {
        private readonly IBlogFeedContentParser _blogFeedContentParser;
        private readonly IWebClient _webClient;
        private readonly IJsonParser _jsonParser;

        public BlogFeedReader(IBlogFeedContentParser blogFeedContentParser, IJsonParser jsonParser, IWebClient webClient)
        {
            _blogFeedContentParser = blogFeedContentParser;
            _jsonParser = jsonParser;
            _webClient = webClient;
        }

        public IEnumerable<BlogFeedContent> Read(string sourceFeedUrl, IDictionary filters, Pagination pagination)
        {
            var category = ExtractCategory(filters);
            var feedUrl = new FeedUrl(sourceFeedUrl, category, pagination);

            var feedResult = _webClient.GetContent(feedUrl.Url);
            
            ValidateFeedResult(feedResult);
            var feedResultAsJson = _jsonParser.Parse<FeedResponseRoot>(feedResult);

            var blogFeedContent = _blogFeedContentParser.Parse(feedResultAsJson.posts);
            return blogFeedContent;
        }

        private void ValidateFeedResult(string value)
        {
            if (string.IsNullOrEmpty(value)) 
                throw new CustomErrorException("failed to read value from blog feed url.");

            if (value.ToLower().Contains("not found"))
                throw new NotFoundException();
        }

        private string ExtractCategory(IEnumerable filters)
        {
            var dictionaryFilters = filters as Dictionary<string, string>;

            if (dictionaryFilters == null)
                throw new ArgumentException("failed to extract values from filters structure.");

            return dictionaryFilters
                    .Where(it => it.Key.ToLower().Equals("category"))
                    .Select(it => it.Value)
                    .FirstOrDefault();
        }
    }
}