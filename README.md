## MovieSharp - The Movie Database REST client for .NET, Xamarin.iOS and Xamarin.Android

It implements a simple client for the [The Movie Database][1] targeting multiple platforms (Portable Class Library).

### Features

* Supported Platforms: .NET 4 or later, Xamarin iOS, Xamarin Android, Windows Phone 8, Windows 8, and Silverlight 5
* Supported APIs:
 * /3/movie/{id}
 * /3/movie/upcoming
 * /3/movie/now_playing
 * /3/movie/latest
 * /3/movie/top_rated
 * /3/collection/{id}
 * /3/collection/{id}/images
 * /3/search/movie
 * /3/search/collection

### Usage

```csharp
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
```
  [1]: http://www.themoviedb.org/
