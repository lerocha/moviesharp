using System.Collections.Generic;
using System.Threading.Tasks;
using MovieSharp.Data;

namespace MovieSharp
{
    public interface IMovieSharpClient
    {
		Collection GetCollection (int id);
		Task<Collection> GetCollectionAsync (int id);
		CollectionImages GetCollectionImages (int id);
		Task<CollectionImages> GetCollectionImagesAsync (int id);
		Movie GetMovie (int id);
		Task<Movie> GetMovieAsync (int id);
        MoviesResult SearchMovies(string query);
        Task<MoviesResult> SearchMoviesAsync(string query);
		CollectionsResult SearchCollections(string query);
		Task<CollectionsResult> SearchCollectionsAsync(string query);
    }
}