using System.Configuration;

namespace MovieSharp.Test
{
    public abstract class AbstractMovieSharpClientTest
    {
        protected readonly string ApiKey = ConfigurationManager.AppSettings["ApiKey"];
        protected const string ContactId = "003i000000W2RMDAA3";
        protected const long MovieId = 238;
    }
}