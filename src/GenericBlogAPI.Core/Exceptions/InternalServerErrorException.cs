using System;

namespace GenericBlogAPI.Core.Exceptions
{
    [Serializable]
    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException() : base("Internal server error.") { }
    }
}