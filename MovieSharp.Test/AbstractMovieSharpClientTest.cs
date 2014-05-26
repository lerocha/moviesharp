using System.Configuration;

namespace MovieSharp.Test
{
    public abstract class AbstractMovieSharpClientTest
    {
        protected readonly string ApiKey = ConfigurationManager.AppSettings["ApiKey"];
        protected readonly string ConsumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
        protected readonly string ConsumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
        protected readonly string RefreshToken = ConfigurationManager.AppSettings["RefreshToken"];
        protected const string ContactId = "003i000000W2RMDAA3";
        protected const long MovieId = 238;
    }
}