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
			BaseResponse<MoviesResult> searchMoviesResponse = service.SearchMovies("Godfather");

			if (searchMoviesResponse.IsOk) {
				// Iterate through the records returned.
				var movies = searchMoviesResponse.Body.Results;
				foreach (Movie movie in movies) {
					Console.WriteLine("id={0}; title={1}; voteCount={2}", 
						movie.Id, movie.Title, movie.VoteCount);
				}
			}

			// Get a movie by id
			BaseResponse<Movie> getMovieResponse = service.GetMovie(122);
			if (getMovieResponse.IsOk) {
				Movie movie = getMovieResponse.Body;
				Console.WriteLine("id={0}; title={1}; voteCount={2}", 
					movie.Id, movie.Title, movie.VoteCount);
			}

			// Get collection by id
			BaseResponse<Collection> getCollectionResponse = service.GetCollection(230);
			if (getCollectionResponse.IsOk) {
				Collection collection = getCollectionResponse.Body;
				Console.WriteLine("id={0}; name={1}; posterPath={2}", 
					collection.Id, collection.Name, collection.PosterPath);
			}

			// Get collection images by id
			BaseResponse<CollectionImages> getCollectionImagesResponse = service.GetCollectionImages(230);
			if (getCollectionImagesResponse.IsOk) {
				CollectionImages collectionImages = getCollectionImagesResponse.Body;
				Console.WriteLine("id={0}", collectionImages.Id);
			}

			//-----------------------------------------------------------------------------
			// Error Handling
			//-----------------------------------------------------------------------------
			var response = service.GetMovie(66666666);

			// If the response IsOk is false, we got an error back from TMDB API and we need to handle it.
			if (!response.IsOk) {

				Console.WriteLine("StatusCode={0}; StatusMessage={1}; HttpStatus={2}; ReasonPhrase={3}",
					// TMDB status code: 6
					// For TMDB status codes see: https://www.themoviedb.org/documentation/api/status-codes
					response.StatusCode,
					// TMDB status message: Invalid id: The pre-requisite id is invalid or not found.
					response.StatusMessage,
					// HTTP status: NotFound (404)
					response.HttpStatus,
					// HTTP reason phrase: Not Found
					response.ReasonPhrase
				);

			}
		}
	}
}