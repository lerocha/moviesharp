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
		public void MovieSharpClientConfiguration()
		{
			// Arrange
			var service = new MovieSharpClient(ApiKey);

			// Act
			BaseResponse<Configuration> response = service.GetConfiguration();

			// Assert
			Assert.NotNull(response);
			Assert.NotNull(response.Body);
			Assert.NotNull(response.Body.ChangeKeys);
			Assert.IsTrue(response.Body.ChangeKeys.Count > 0);
			Assert.NotNull(response.Body.Images);
		}

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

		[Test]
		public void MovieSharpClientGetSimilarMovies()
		{
			// Arrange
			var service = new MovieSharpClient(ApiKey);

			// Act
			BaseResponse<MoviesResult> response = service.GetSimilarMovies(238, 2);

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
		public void MovieSharpClientGetUpcomingMovies()
		{
			// Arrange
			var service = new MovieSharpClient(ApiKey);

			// Act
			BaseResponse<MoviesResult> response = service.GetUpcomingMovies();

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
		public void MovieSharpClientGetNowPlayingMovies()
		{
			// Arrange
			var service = new MovieSharpClient(ApiKey);

			// Act
			BaseResponse<MoviesResult> response = service.GetNowPlayingMovies();

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
		public void MovieSharpClientGetPopularMovies()
		{
			// Arrange
			var service = new MovieSharpClient(ApiKey);

			// Act
			BaseResponse<MoviesResult> response = service.GetPopularMovies();

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
		public void MovieSharpClientGetTopRatedMovies()
		{
			// Arrange
			var service = new MovieSharpClient(ApiKey);

			// Act
			BaseResponse<MoviesResult> response = service.GetTopRatedMovies();

			// Assert
			Assert.NotNull(response);
			Assert.NotNull(response.Body);
			Assert.NotNull(response.Body.Results);
			Assert.True(response.Body.Results.Count > 0);

			foreach (var movie in response.Body.Results) {
				Console.WriteLine(movie.Title);
			}
		}
	}
}

