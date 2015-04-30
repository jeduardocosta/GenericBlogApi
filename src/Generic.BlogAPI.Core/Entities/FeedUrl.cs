using System;
using System.Text;
using Generic.BlogAPI.Core.Exceptions;
using Generic.BlogAPI.Core.Helpers;

namespace Generic.BlogAPI.Core.Entities
{
    public class FeedUrl
    {
        public string Url { get; private set; }

        public IUrlHelper UrlHelper { get; private set; }

        public FeedUrl(string sourceUrl, string category, Pagination pagination)
            : this(sourceUrl, category, pagination, new UrlHelper())
        { }

        public FeedUrl(string sourceUrl, string category, Pagination pagination, IUrlHelper urlHelper)
        {
            UrlHelper = urlHelper;
            
            ValidateUrl(sourceUrl);
            Url = FormatUrl(sourceUrl, category, pagination);
        }

        private void ValidateUrl(string feedUrl)
        {
            var isValidUrl = UrlHelper.IsValidAbsoluteUrl(feedUrl);

            if (!isValidUrl)
                throw new CustomErrorException(string.Format("invalid entry blog feed absolute url. value: {0}.", feedUrl));
        }

        private string FormatUrl(string feedUrl, string category, Pagination pagination)
        {
            var parameters = new StringBuilder();
            var baseUri = new Uri(feedUrl);

            var baseParameters = string.Format("?json=true&count={0}&page={1}", pagination.Limit, pagination.Offset + 1);

            if (HasValue(category))
                parameters.Append(string.Format("/{0}/", category));

            parameters.Append(baseParameters);

            return new Uri(baseUri, parameters.ToString()).ToString();
        }

        private bool HasValue(string category)
        {
            return !string.IsNullOrWhiteSpace(category);
        }
    }
}