using System;
using System.Net;
using MovieSharp.Data;
using NUnit.Framework;

namespace MovieSharp.Test
{
    [TestFixture]
    public class MovieSharpClientTest : AbstractMovieSharpClientTest
    {
        [Test]
        public void MovieSharpClientQuery()
        {
            // Arrange
            var service = new MovieSharpClient(ApiKey);

            // Act
            MoviesResponse response = service.SearchMovies("Godfather");

            // Assert
            Assert.NotNull(response);
            Assert.NotNull(response.Results);
            Assert.True(response.Results.Count > 0);

            foreach (var movie in response.Results)
            {
                Console.WriteLine(movie.Title);
            }
        }

        [Test]
        public void MovieSharpClientQueryAsync()
        {
            // Arrange
            var service = new MovieSharpClient(ApiKey);

            // Act
            MoviesResponse response = service.SearchMoviesAsync("Godfather").Result;

            // Assert
            Assert.NotNull(response);
            Assert.NotNull(response.Results);
            Assert.True(response.Results.Count > 0);

            foreach (var movie in response.Results)
            {
                Console.WriteLine(movie.Title);
            }
        }

        [Test]
        public void MovieSharpClientQueryValidatesNull()
        {
            // Arrange
            var service = new MovieSharpClient(ApiKey);

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => service.SearchMovies(null));
        }

        [Test]
        public void MovieSharpClientQueryFails()
        {
            // Arrange
            var service = new MovieSharpClient(ApiKey);

            // Act
            // Assert
            var exception = Assert.Throws<MovieSharpException>(() => service.SearchMovies("#"));
            Assert.AreEqual(HttpStatusCode.NotFound, exception.HttpStatus);
            Assert.AreEqual(6, exception.StatusCode);
        }
    }
}

