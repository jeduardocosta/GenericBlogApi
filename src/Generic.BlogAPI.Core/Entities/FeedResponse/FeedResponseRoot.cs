using System.Collections.Generic;

namespace Generic.BlogAPI.Core.Entities.FeedResponse
{
    public class FeedResponseRoot
    {
        public string status { get; set; }
        public int count { get; set; }
        public int count_total { get; set; }
        public int pages { get; set; }
        public List<Post> posts { get; set; }
    }
}