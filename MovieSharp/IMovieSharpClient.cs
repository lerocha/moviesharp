using System.Collections.Generic;
using System.Threading.Tasks;
using MovieSharp.Data;

namespace MovieSharp
{
	public interface IMovieSharpClient
	{
		BaseResponse<Configuration> GetConfiguration();

		Task<BaseResponse<Configuration>> GetConfigurationAsync();

		BaseResponse<Collection> GetCollection(int id);

		Task<BaseResponse<Collection>> GetCollectionAsync(int id);

		BaseResponse<CollectionImages> GetCollectionImages(int id);

		Task<BaseResponse<CollectionImages>> GetCollectionImagesAsync(int id);

		BaseResponse<Movie> GetMovie(int id);

		Task<BaseResponse<Movie>> GetMovieAsync(int id);

		BaseResponse<MoviesResult> GetSimilarMovies(int id, int page = 1);

		Task<BaseResponse<MoviesResult>> GetSimilarMoviesAsync(int id, int page = 1);

		BaseResponse<MoviesResult> GetUpcomingMovies(int page = 1);

		Task<BaseResponse<MoviesResult>> GetUpcomingMoviesAsync(int page = 1);

		BaseResponse<MoviesResult> GetNowPlayingMovies(int page = 1);

		Task<BaseResponse<MoviesResult>> GetNowPlayingMoviesAsync(int page = 1);

		BaseResponse<MoviesResult> GetPopularMovies(int page = 1);

		Task<BaseResponse<MoviesResult>> GetPopularMoviesAsync(int page = 1);

		BaseResponse<MoviesResult> GetTopRatedMovies(int page = 1);

		Task<BaseResponse<MoviesResult>> GetTopRatedMoviesAsync(int page = 1);

		BaseResponse<MoviesResult> SearchMovies(string query);

		Task<BaseResponse<MoviesResult>> SearchMoviesAsync(string query);

		BaseResponse<CollectionsResult> SearchCollections(string query);

		Task<BaseResponse<CollectionsResult>> SearchCollectionsAsync(string query);
	}
}