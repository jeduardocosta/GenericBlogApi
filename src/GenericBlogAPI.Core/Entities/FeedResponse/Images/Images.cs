using GenericBlogAPI.Core.Entities.FeedResponse.Images.WatsonFeatured;

namespace GenericBlogAPI.Core.Entities.FeedResponse.Images
{
    public class Images
    {
        public Full.Full full { get; set; }
        public Medium.Medium medium { get; set; }
        public Large.Large large { get; set; }
        public WatsonFeatured.WatsonFeatured watson_featured { get; set; }
        public WatsonFeaturedIndex watson_featured_index { get; set; }
        public WatsonRecentPostsWidget.WatsonRecentPostsWidget watson_recent_posts_widget { get; set; }
        public WatsonFeaturedThumbnail watson_featured_thumbnail { get; set; }
    }
}