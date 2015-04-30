using System;
using System.Collections.Generic;
using Generic.BlogAPI.Core.Entities.FeedResponse.Images;

namespace Generic.BlogAPI.Core.Entities
{
    public class BlogFeedContent
    {
        public interface IBlogFeedContentBuilder
        {
            BlogFeedContentBuilder WithId(int id);
            BlogFeedContentBuilder WithTitle(string title);
            BlogFeedContentBuilder WithPublishDate(DateTime publishDate);
            BlogFeedContentBuilder WithCategories(IEnumerable<string> categories);
            BlogFeedContentBuilder WithFullContent(string fullContent);
            BlogFeedContentBuilder WithUrl(string url);
            BlogFeedContentBuilder WithSummary(string summary);
            BlogFeedContentBuilder WithThumbnailImages(ThumbnailImages thumbnailImages);
            BlogFeedContentBuilder WithTags(IEnumerable<string> tags);
            BlogFeedContent Build();
        }

        private BlogFeedContent() { }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime PublishDate { get; private set; }
        public IEnumerable<string> Categories { get; private set; }
        public string FullContent { get; private set; }
        public string Url { get; private set; }
        public string Summary { get; private set; }
        public ThumbnailImages ThumbnailImages { get; set; }
        public IEnumerable<string> Tags { get; private set; }

        public class BlogFeedContentBuilder : IBlogFeedContentBuilder
        {
            private int Id { get; set; }
            private string Title { get; set; }
            private DateTime PublishDate { get; set; }
            private IEnumerable<string> Categories { get; set; }
            private string FullContent { get; set; }
            private string Url { get; set; }
            private string Summary { get; set; }
            private ThumbnailImages ThumbnailImages { get; set; }
            public IEnumerable<string> Tags { get; set; }

            public BlogFeedContentBuilder WithId(int id)
            {
                Id = id;
                return this;
            }

            public BlogFeedContentBuilder WithTitle(string title)
            {
                Title = title;
                return this;
            }

            public BlogFeedContentBuilder WithPublishDate(DateTime publishDate)
            {
                PublishDate = publishDate;
                return this;
            }

            public BlogFeedContentBuilder WithCategories(IEnumerable<string> categories)
            {
                Categories = categories;
                return this;
            }

            public BlogFeedContentBuilder WithFullContent(string fullContent)
            {
                FullContent = fullContent;
                return this;
            }

            public BlogFeedContentBuilder WithUrl(string url)
            {
                Url = url;
                return this;
            }

            public BlogFeedContentBuilder WithSummary(string summary)
            {
                Summary = summary;
                return this;
            }

            public BlogFeedContentBuilder WithThumbnailImages(ThumbnailImages thumbnailImages)
            {
                ThumbnailImages = thumbnailImages;
                return this;
            }

            public BlogFeedContentBuilder WithTags(IEnumerable<string> tags)
            {
                Tags = tags;
                return this;
            }

            public BlogFeedContent Build()
            {
                return new BlogFeedContent
                {
                    Id = Id,
                    Categories = Categories,
                    FullContent = FullContent,
                    PublishDate = PublishDate,
                    ThumbnailImages = ThumbnailImages,
                    Title = Title,
                    Summary = Summary,
                    Url = Url,
                    Tags = Tags
                };
            }
        }
    }
}