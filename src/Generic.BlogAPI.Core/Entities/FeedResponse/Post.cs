using System.Collections.Generic;
using Generic.BlogAPI.Core.Entities.FeedResponse.Images;
using Newtonsoft.Json;

namespace Generic.BlogAPI.Core.Entities.FeedResponse
{
    public class Post
    {
        public int id { get; set; }
        public string type { get; set; }
        public string slug { get; set; }
        public string url { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public string title_plain { get; set; }
        public string content { get; set; }
        public string excerpt { get; set; }
        public string date { get; set; }
        public string modified { get; set; }

        public List<Category> categories { get; set; }
        public List<Tag> tags { get; set; }

        [JsonIgnore]
        public Author author { get; set; }

        [JsonIgnore]
        public List<object> comments { get; set; }

        [JsonIgnore]
        public List<Attachment> attachments { get; set; }

        [JsonIgnore]
        public int comment_count { get; set; }

        [JsonIgnore]
        public string comment_status { get; set; }

        [JsonIgnore]
        public object thumbnail { get; set; }

        [JsonIgnore]
        public CustomFields custom_fields { get; set; }

        [JsonIgnore]
        public string thumbnail_size { get; set; }

        public ThumbnailImages thumbnail_images { get; set; }
    }
}