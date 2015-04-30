using System;
using System.Web;
using Generic.BlogAPI.Core.Exceptions;
using HtmlAgilityPack;

namespace Generic.BlogAPI.Core.Helpers
{
    public interface IHtmlHelper
    {
        string RemoveTags(string source);
    }

    public class HtmlHelper : IHtmlHelper
    {
        public string RemoveTags(string htmlContent)
        {
            try
            {
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(htmlContent);

                var htmlInnerText = htmlDocument.DocumentNode.InnerText;

                var uncodedContent = Encode(htmlInnerText);
                return uncodedContent;
            }
            catch (Exception exception)
            {
                const string errorMessage = "failed to remove tags from html content.";

                throw new CustomErrorException(errorMessage);
            }
        }

        private string Encode(string source)
        {
            return HttpUtility.HtmlDecode(source);
        }
    }
}