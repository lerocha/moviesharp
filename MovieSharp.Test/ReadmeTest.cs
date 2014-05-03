using System;
using MovieSharp.Data;
using NUnit.Framework;

namespace MovieSharp.Test
{
    [TestFixture]
    public class ReadmeTest : AbstractMovieSharpClientTest
    {
        [Test]
        public void Readme()
        {
            // Instantiate the client using an API key.
            var service = new MovieSharpClient(ApiKey);

            //-----------------------------------------------------------------------------
            // Queries
            //-----------------------------------------------------------------------------

            // Execute a movie search synchronously
            MoviesResponse response = service.SearchMovies("Godfather");

            // Iterate through the records returned.
            foreach (Movie movie in response.Results)
            {
                Console.WriteLine("id={0}; title={1}; voteCount={2}", movie.Id, movie.Title, movie.VoteCount);
            }
        }
    }
}