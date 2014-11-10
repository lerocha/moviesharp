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
			BaseResponse<MoviesResult> response = service.SearchMovies("Godfather");

			// Assert
			Assert.NotNull(response);
			Assert.NotNull(response.Body);
			Assert.NotNull(response.Body.Results);
			Assert.True(response.Body.Results.Count > 0);

			foreach (var movie in response.Body.Results) {
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
		public void MovieSharpClientGetMovieFails()
		{
			// Arrange
			var service = new MovieSharpClient(ApiKey);

			// Act
			BaseResponse<Movie> response = service.GetMovie(66666666);

			// Assert
			Assert.NotNull(response);
			Assert.AreEqual(response.HttpStatus, HttpStatusCode.NotFound);
			Assert.AreEqual(response.StatusCode, 6);
		}
	}
}

