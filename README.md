## MovieSharp - The Movie Database REST client for .NET, Xamarin.iOS and Xamarin.Android

It implements a simple client for the [The Movie Database][1] targeting multiple platforms (Portable Class Library).

### Features

* Supported Platforms: .NET 4 or later, Xamarin iOS, Xamarin Android, Windows Phone 8, Windows 8, and Silverlight 5
* Supported APIs:
 * /3/movie/{id}
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
MoviesResponse response = service.SearchMovies("Godfather");

// Iterate through the records returned.
foreach (Movie movie in response.Results)
{
    Console.WriteLine("id={0}; title={1}; voteCount={2}", movie.Id, movie.Title, movie.VoteCount);
}

// Get a movie by id
Movie movie2 = service.GetMovie(122);
Console.WriteLine("id={0}; title={1}; voteCount={2}", movie2.Id, movie2.Title, movie2.VoteCount);

// Get collection by collection id
Collection collection = service.GetCollection (230);
Console.WriteLine("id={0}; name={1}; posterPath={2}", collection.Id, collection.Name, collection.PosterPath);

// Get collection images
CollectionImages collectionImages = service.GetCollectionImages (230);
Console.WriteLine("id={0}", collectionImages.Id);

//-----------------------------------------------------------------------------
// Error Handling
//-----------------------------------------------------------------------------
try
{
    service.SearchMovies("#");
}
catch (MovieSharpException e)
{
    Console.WriteLine("HttpStatus={0}; StatusCode={1}; Message={2}",
                        e.HttpStatus, e.StatusCode, e.Message);
    // Output:
    // HttpStatus=NotFound;
    // StatusCode=6; 
    // Message=Invalid id: The pre-requisite id is invalid or not found.

    // TODO: handle the exception
}
```
  [1]: http://www.themoviedb.org/
