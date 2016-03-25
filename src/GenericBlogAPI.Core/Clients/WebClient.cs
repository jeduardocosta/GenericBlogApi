using System;

namespace GenericBlogAPI.Core.Clients
{
    public interface IWebClient
    {
        string GetContent(string url);
    }

    public class WebClient : IWebClient
    {
        public string GetContent(string url)
        {
            using (var client = new System.Net.WebClient())
            {
                var uri = new Uri(url);
                return client.DownloadString(uri);
            }
        }
    }
}