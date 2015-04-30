using Newtonsoft.Json;

namespace Generic.BlogAPI.Models
{
    public class Metadata
    {
        [JsonProperty(PropertyName = "limit")]
        public int Limit { get; set; }

        [JsonProperty(PropertyName = "offset")]
        public int Offset { get; set; }

        public Metadata(int limit, int offset)
        {
            Limit = limit;
            Offset = offset;
        }
    }
}