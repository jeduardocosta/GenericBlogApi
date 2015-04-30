using System;
using System.Collections.Generic;
using Generic.BlogAPI.Core.Entities;
using Generic.BlogAPI.Core.Entities.FeedResponse.Images;
using Newtonsoft.Json;

namespace Generic.BlogAPI.Models
{
    public class Post
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "publishDate")]
        public DateTime PublishDate { get; set; }

        [JsonProperty(PropertyName = "categories")]
        public IEnumerable<string> Categories { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "thumbnails")]
        public IEnumerable<Thumbnail> Thumbnails { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public IEnumerable<string> Tags { get; set; }

        public Post(int id, string title, DateTime publishDate, IEnumerable<string> categories, string url, string summary, IEnumerable<string> tags)
        {
            Id = id;
            Title = title;
            PublishDate = publishDate;
            Categories = categories ?? new List<string>();
            Url = url;
            Summary = summary;
            Tags = tags ?? new List<string>();
        }

        public Post(int id, string title, DateTime publishDate, IEnumerable<string> categories, string url, 
            string summary, IEnumerable<Thumbnail> thumbnails, IEnumerable<string> tags)
            : this(id, title, publishDate, categories, url, summary, tags)
        {
            Thumbnails = thumbnails;
        }

        public Post(int id, string title, DateTime publishDate, IEnumerable<string> categories, string url, 
            string summary, ThumbnailImages thumbnailImages, IEnumerable<string> tags)
            : this(id, title, publishDate, categories, url, summary, tags)
        {
            Thumbnails = new List<Thumbnail> {new Thumbnail(thumbnailImages)};
        }

        public Post(BlogFeedContent blogFeedContent)
            : this(
                blogFeedContent.Id,
                blogFeedContent.Title, 
                blogFeedContent.PublishDate, 
                blogFeedContent.Categories, 
                blogFeedContent.Url,
                blogFeedContent.Summary,   
                blogFeedContent.ThumbnailImages,
                blogFeedContent.Tags
                )
        { }
    }
}