using GenericBlogAPI.Core.Entities.FeedResponse.Images;
using Newtonsoft.Json;

namespace GenericBlogAPI.Models
{
    public class Thumbnail
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int  Height { get; set; }

        public Thumbnail(ThumbnailImages thumbnailImages)
        {
            if (thumbnailImages == null) 
                return;

            var validThumbnailImage = GetValidThumbnailImage(thumbnailImages);

            Width = validThumbnailImage.width;
            Height = validThumbnailImage.height;
            Url = validThumbnailImage.url;
        }

        private BaseImage GetValidThumbnailImage(ThumbnailImages thumbnailImages)
        {
            if (thumbnailImages.full != null && thumbnailImages.full.IsValid())
                return thumbnailImages.full;
            if (thumbnailImages.large != null && thumbnailImages.large.IsValid())
                return thumbnailImages.large;
            if (thumbnailImages.medium != null && thumbnailImages.medium.IsValid())
                return thumbnailImages.medium;

            return new BaseImage();
        }

        protected bool Equals(Thumbnail other)
        {
            return string.Equals(Url, other.Url) && Width == other.Width && Height == other.Height;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Thumbnail)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Url != null ? Url.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Width;
                hashCode = (hashCode * 397) ^ Height;
                return hashCode;
            }
        }
    }
}