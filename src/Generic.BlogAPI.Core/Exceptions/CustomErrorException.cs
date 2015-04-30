using System;

namespace Generic.BlogAPI.Core.Exceptions
{
    [Serializable]
    public class CustomErrorException : Exception
    {
        public CustomErrorException(string message) : base(message) { }
    }
}