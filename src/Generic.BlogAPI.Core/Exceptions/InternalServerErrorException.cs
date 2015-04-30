using System;

namespace Generic.BlogAPI.Core.Exceptions
{
    [Serializable]
    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException() : base("Internal server error.") { }
    }
}