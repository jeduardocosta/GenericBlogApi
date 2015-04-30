using Generic.BlogAPI.Core.Entities.FeedResponse.Images.Full;
using Generic.BlogAPI.Core.Entities.FeedResponse.Images.Large;
using Generic.BlogAPI.Core.Entities.FeedResponse.Images.Medium;
using Generic.BlogAPI.Core.Entities.FeedResponse.Images.WatsonFeatured;
using Generic.BlogAPI.Core.Entities.FeedResponse.Images.WatsonRecentPostsWidget;

namespace Generic.BlogAPI.Core.Entities.FeedResponse.Images
{
    public class ThumbnailImages
    {
        public Full2 full { get; set; }
        public Medium2 medium { get; set; }
        public Large2 large { get; set; }
        public WatsonFeatured2 watson_featured { get; set; }
        public WatsonFeaturedIndex2 watson_featured_index { get; set; }
        public WatsonRecentPostsWidget2 watson_recent_posts_widget { get; set; }
        public WatsonFeaturedThumbnail2 watson_featured_thumbnail { get; set; }
    }
}