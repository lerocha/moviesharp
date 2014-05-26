using System;
using System.Net;

namespace MovieSharp
{
    public class MovieSharpException : Exception
    {
        public HttpStatusCode HttpStatus { get; set; }
        public long StatusCode { get; set; }

        public MovieSharpException()
        {
        }

        public MovieSharpException(string message)
            : base(message)
        {
        }

        public MovieSharpException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public MovieSharpException(string message, HttpStatusCode httpStatus, long statusCode, Exception inner)
            : base(message, inner)
        {
            HttpStatus = httpStatus;
            StatusCode = statusCode;
        }
    }
}
