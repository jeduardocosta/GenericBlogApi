namespace GenericBlogAPI.Core.Entities.FeedResponse
{
    public class Attachment
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Caption { get; set; }
        public int Parent { get; set; }
        public string MimeType { get; set; }
        public Images.Images Images { get; set; }
    }
}