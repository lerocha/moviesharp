using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using MovieSharp.Data;

namespace MovieSharp
{
    public class MovieSharpClient : IMovieSharpClient
    {
        protected const string DefaultBaseUrl = "http://api.themoviedb.org";

        public string ApiKey { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieSharpClient" /> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public MovieSharpClient(string apiKey)
        {
            ApiKey = apiKey;
        }

		public Collection GetCollection (int id)
		{
			var request = new HttpRequestMessage
			{
				RequestUri = new Uri(string.Format("{0}/3/collection/{1}?api_key={2}", DefaultBaseUrl, id, ApiKey)),
				Method = HttpMethod.Get
			};
			var response = ExecuteRequest<Collection>(request);
			return response.Body;
		}

		public async Task<Collection> GetCollectionAsync (int id)
		{
			var request = new HttpRequestMessage
			{
				RequestUri = new Uri(string.Format("{0}/3/collection/{1}?api_key={2}", DefaultBaseUrl, id, ApiKey)),
				Method = HttpMethod.Get
			};
			var response = await ExecuteRequestAsync<Collection>(request);
			return response.Body;
		}

		public CollectionImages GetCollectionImages (int id)
		{
			var request = new HttpRequestMessage
			{
				RequestUri = new Uri(string.Format("{0}/3/collection/{1}/images?api_key={2}", DefaultBaseUrl, id, ApiKey)),
				Method = HttpMethod.Get
			};
			var response = ExecuteRequest<CollectionImages>(request);
			return response.Body;
		}

		public async Task<CollectionImages> GetCollectionImagesAsync (int id)
		{
			var request = new HttpRequestMessage
			{
				RequestUri = new Uri(string.Format("{0}/3/collection/{1}/images?api_key={2}", DefaultBaseUrl, id, ApiKey)),
				Method = HttpMethod.Get
			};
			var response = await ExecuteRequestAsync<CollectionImages>(request);
			return response.Body;
		}

		public Movie GetMovie (int id)
		{
			var request = new HttpRequestMessage
			{
				RequestUri = new Uri(string.Format("{0}/3/movie/{1}?api_key={2}", DefaultBaseUrl, id, ApiKey)),
				Method = HttpMethod.Get
			};
			var response = ExecuteRequest<Movie>(request);
			return response.Body;
		}

		public async Task<Movie> GetMovieAsync (int id)
		{
			var request = new HttpRequestMessage
			{
				RequestUri = new Uri(string.Format("{0}/3/movie/{1}?api_key={2}", DefaultBaseUrl, id, ApiKey)),
				Method = HttpMethod.Get
			};
			var response = await ExecuteRequestAsync<Movie>(request);
			return response.Body;
		}

        public MoviesResult SearchMovies(string query)
        {
            if (query == null) throw new ArgumentNullException("query");
			var request = new HttpRequestMessage
			{
				RequestUri = new Uri(string.Format("{0}/3/search/movie?api_key={1}&query={2}", DefaultBaseUrl, ApiKey, query)),
				Method = HttpMethod.Get
			};
            var response = ExecuteRequest<MoviesResult>(request);
            return response.Body;
        }

        public async Task<MoviesResult> SearchMoviesAsync(string query)
        {
            if (query == null) throw new ArgumentNullException("query");
			var request = new HttpRequestMessage
			{
				RequestUri = new Uri(string.Format("{0}/3/search/movie?api_key={1}&query={2}", DefaultBaseUrl, ApiKey, query)),
				Method = HttpMethod.Get
			};
            var response = await ExecuteRequestAsync<MoviesResult>(request);
            return response.Body;
        }

		public CollectionsResult SearchCollections(string query)
		{
			if (query == null) throw new ArgumentNullException("query");
			var request = new HttpRequestMessage
			{
				RequestUri = new Uri(string.Format("{0}/3/search/collection?api_key={1}&query={2}", DefaultBaseUrl, ApiKey, query)),
				Method = HttpMethod.Get
			};
			var response = ExecuteRequest<CollectionsResult>(request);
			return response.Body;
		}

		public async Task<CollectionsResult> SearchCollectionsAsync(string query)
		{
			if (query == null) throw new ArgumentNullException("query");
			var request = new HttpRequestMessage
			{
				RequestUri = new Uri(string.Format("{0}/3/search/collection?api_key={1}&query={2}", DefaultBaseUrl, ApiKey, query)),
				Method = HttpMethod.Get
			};
			var response = await ExecuteRequestAsync<CollectionsResult>(request);
			return response.Body;
		}

        private BaseResponse<T> ExecuteRequest<T>(HttpRequestMessage request) where T : new()
        {
            var response = ExecuteRequestAsync<T>(request).Result;
            if (!response.IsOk)
            {
                throw new MovieSharpException(response.StatusMessage, response.HttpStatus, response.StatusCode, null);
            }
            return response;
        }

        private async Task<BaseResponse<T>> ExecuteRequestAsync<T>(HttpRequestMessage request) where T : new()
		{
			using (var httpClient = new HttpClient (new HttpClientHandler ())) {
				// Send the request.
				var httpResponseMessage = await httpClient.SendAsync (request);

				// Read the content as string.
				var content = await httpResponseMessage.Content.ReadAsStringAsync ();

				var response = new BaseResponse<T> {
					HttpStatus = httpResponseMessage.StatusCode,
					IsOk = httpResponseMessage.IsSuccessStatusCode,
					ReasonPhrase = httpResponseMessage.ReasonPhrase
				};

				// Parse the content.
				if (content != null) {
					if (httpResponseMessage.IsSuccessStatusCode) {
						// Parse the successful the response.
						response.Body = content.ToObject<T> ();
					} else {
						// Parse the error response.
						var error = content.ToObject<BaseResponse> ();
						if (error != null) {
							response.StatusCode = error.StatusCode;
							response.StatusMessage = error.StatusMessage;
						}
					}
				}

				Debug.WriteLine (response);
				return response;
			}
		}
	}
}
