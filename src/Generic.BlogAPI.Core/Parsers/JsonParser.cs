using Newtonsoft.Json;

namespace Generic.BlogAPI.Core.Parsers
{
    public interface IJsonParser
    {
        T Parse<T>(string data);
        string Parse<T>(T data);
    }

    public class JsonParser : IJsonParser
    {
        public T Parse<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public string Parse<T>(T data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}