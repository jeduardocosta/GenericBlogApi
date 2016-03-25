using System.Collections.Generic;
using System.Linq;
using GenericBlogAPI.Core.Entities;
using GenericBlogAPI.Core.Entities.FeedResponse;
using GenericBlogAPI.Core.Helpers;

namespace GenericBlogAPI.Core.Parsers
{
    public interface IBlogFeedContentParser
    {
        IEnumerable<BlogFeedContent> Parse(IEnumerable<Post> posts);
    }

    public class BlogFeedContentParser : IBlogFeedContentParser
    {
        private readonly IDatetimeParser _datetimeParser;
        private readonly IHtmlHelper _htmlHelper;

        public BlogFeedContentParser(IDatetimeParser datetimeParser, IHtmlHelper htmlHelper)
        {
            _datetimeParser = datetimeParser;
            _htmlHelper = htmlHelper;
        }

        public IEnumerable<BlogFeedContent> Parse(IEnumerable<Post> posts)
        {
            return posts.Select(post => new BlogFeedContent
                .BlogFeedContentBuilder()
                .WithId(post.id)
                .WithTitle(post.title)
                .WithCategories(post.categories != null ?post.categories.Select(it => it.title) : new List<string>())
                .WithPublishDate(_datetimeParser.ParseFromStringValue(post.date))
                .WithUrl(post.url)
                .WithSummary(_htmlHelper.RemoveTags(post.excerpt))
                .WithThumbnailImages(post.thumbnail_images)
                .WithTags(post.tags != null ? post.tags.Select(it => it.title) : new List<string>())
                .Build());
        }
    }
}