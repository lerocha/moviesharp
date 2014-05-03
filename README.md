## MovieSharp - The Movie Database REST client for .NET and Xamarin iOS & Android

It implements a simple client for the [The Movie Database][1] targeting multiple platforms (Portable Class Library).

### Features

* Supported Platforms: .NET 4 or later, Xamarin iOS, Xamarin Android, Windows Phone 8, Windows 8, and Silverlight 5
* Supported APIs: Query

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
