using System;

namespace GenericBlogAPI.Core.Exceptions
{
    [Serializable]
    public class CustomErrorException : Exception
    {
        public CustomErrorException(string message) : base(message) { }
    }
}