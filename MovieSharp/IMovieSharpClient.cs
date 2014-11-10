using System.Collections.Generic;
using System.Threading.Tasks;
using MovieSharp.Data;

namespace MovieSharp
{
	public interface IMovieSharpClient
	{
		BaseResponse<Collection> GetCollection(int id);

		Task<BaseResponse<Collection>> GetCollectionAsync(int id);

		BaseResponse<CollectionImages> GetCollectionImages(int id);

		Task<BaseResponse<CollectionImages>> GetCollectionImagesAsync(int id);

		BaseResponse<Movie> GetMovie(int id);

		Task<BaseResponse<Movie>> GetMovieAsync(int id);

		BaseResponse<MoviesResult> GetSimilarMovies(int id, int page = 1);

		Task<BaseResponse<MoviesResult>> GetSimilarMoviesAsync(int id, int page = 1);

		BaseResponse<MoviesResult> GetUpcomingMovies();

		Task<BaseResponse<MoviesResult>> GetUpcomingMoviesAsync();

		BaseResponse<MoviesResult> GetNowPlayingMovies();

		Task<BaseResponse<MoviesResult>> GetNowPlayingMoviesAsync();

		BaseResponse<MoviesResult> GetPopularMovies();

		Task<BaseResponse<MoviesResult>> GetPopularMoviesAsync();

		BaseResponse<MoviesResult> GetTopRatedMovies();

		Task<BaseResponse<MoviesResult>> GetTopRatedMoviesAsync();

		BaseResponse<MoviesResult> SearchMovies(string query);

		Task<BaseResponse<MoviesResult>> SearchMoviesAsync(string query);

		BaseResponse<CollectionsResult> SearchCollections(string query);

		Task<BaseResponse<CollectionsResult>> SearchCollectionsAsync(string query);
	}
}