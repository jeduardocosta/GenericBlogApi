using System.Collections.Generic;
using System.Linq;
using Generic.BlogAPI.Core.Entities;
using Newtonsoft.Json;

namespace Generic.BlogAPI.Models
{
    public class PostResponse
    {
        [JsonProperty(PropertyName = "metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty(PropertyName = "posts")]
        public IEnumerable<Post> Posts { get; set; }

        public PostResponse(RequestParameters requestParameters, IEnumerable<BlogFeedContent> blogFeedContent)
        {
            LoadMetadaAttribute(requestParameters);
            LoadPostsAttribute(blogFeedContent);
        }

        private void LoadMetadaAttribute(RequestParameters requestParameters)
        {
            Metadata = new Metadata(requestParameters.Limit, requestParameters.Offset);
        }

        private void LoadPostsAttribute(IEnumerable<BlogFeedContent> blogFeedContent)
        {
            Posts = blogFeedContent.Select(item => new Post(item));
        }
    }
}