using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Generic.BlogAPI.Models;

namespace Generic.BlogAPI.Parsers
{
    public interface IRequestParametersParser
    {
        RequestParameters Parse(HttpRequestMessage request, string category);
    }

    public class RequestParametersParser : IRequestParametersParser
    {
        private const string FeedUrlKeyName = "feedurl";
        private const string LimitKeyName = "limit";
        private const string OffsetKeyName = "offset";

        public RequestParameters Parse(HttpRequestMessage request, string category)
        {
            var sourceParameters = ExtractParametersBy(request);

            var feedUrl = GetContentByKeyName(FeedUrlKeyName, sourceParameters);
            var limit = GetContentByKeyName(LimitKeyName, sourceParameters);
            var offset = GetContentByKeyName(OffsetKeyName, sourceParameters);

            var requestParameters = new RequestParameters(feedUrl, limit, offset, category);
            return requestParameters;
        }

        private string GetContentByKeyName(string keyName, Dictionary<string, string> sourceParameters)
        {
            var obtained = sourceParameters
                .Where(it => string.Equals(it.Key, keyName, StringComparison.OrdinalIgnoreCase))
                .Select(it => it.Value)
                .FirstOrDefault();

            return obtained;
        }

        private Dictionary<string, string> ExtractParametersBy(HttpRequestMessage request)
        {
            return request
                .GetQueryNameValuePairs()
                .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}