using System.Collections.Generic;
using System.Threading.Tasks;
using MovieSharp.Data;

namespace MovieSharp
{
    public interface IMovieSharpClient
    {
        MoviesResponse SearchMovies(string query);
        Task<MoviesResponse> SearchMoviesAsync(string query);
    }
}