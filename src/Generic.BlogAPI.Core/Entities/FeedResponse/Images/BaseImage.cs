namespace Generic.BlogAPI.Core.Entities.FeedResponse.Images
{
    public class BaseImage
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(url) && width > 0 && height > 0;
        }
    }
}
