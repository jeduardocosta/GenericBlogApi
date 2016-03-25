using System;

namespace GenericBlogAPI.Core.Parsers
{
    public interface IDatetimeParser
    {
        DateTime ParseFromStringValue(string date);
    }

    public class DatetimeParser : IDatetimeParser
    {
        public DateTime ParseFromStringValue(string datetime)
        {
            if (string.IsNullOrWhiteSpace(datetime))
                throw new ArgumentException("failed to extract datetime from string value");

            var formatedDate = String.Format("{0:yyyy-MM--dd HH:mm:ss}", datetime);
            return Convert.ToDateTime(formatedDate);
        }
    }
}