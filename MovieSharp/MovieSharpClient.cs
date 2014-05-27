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
			return response.Data;
		}

		public async Task<Collection> GetCollectionAsync (int id)
		{
			var request = new HttpRequestMessage
			{
				RequestUri = new Uri(string.Format("{0}/3/collection/{1}?api_key={2}", DefaultBaseUrl, id, ApiKey)),
				Method = HttpMethod.Get
			};
			var response = await ExecuteRequestAsync<Collection>(request);
			return response.Data;
		}

        public MoviesResponse SearchMovies(string query)
        {
            if (query == null) throw new ArgumentNullException("query");
			var request = new HttpRequestMessage
			{
				RequestUri = new Uri(string.Format("{0}/3/search/movie?api_key={1}&query={2}", DefaultBaseUrl, ApiKey, query)),
				Method = HttpMethod.Get
			};
            var response = ExecuteRequest<MoviesResponse>(request);
            return response.Data;
        }

        public async Task<MoviesResponse> SearchMoviesAsync(string query)
        {
            if (query == null) throw new ArgumentNullException("query");
			var request = new HttpRequestMessage
			{
				RequestUri = new Uri(string.Format("{0}/3/search/movie?api_key={1}&query={2}", DefaultBaseUrl, ApiKey, query)),
				Method = HttpMethod.Get
			};
            var response = await ExecuteRequestAsync<MoviesResponse>(request);
            return response.Data;
        }

		public CollectionsResponse SearchCollections(string query)
		{
			if (query == null) throw new ArgumentNullException("query");
			var request = new HttpRequestMessage
			{
				RequestUri = new Uri(string.Format("{0}/3/search/collection?api_key={1}&query={2}", DefaultBaseUrl, ApiKey, query)),
				Method = HttpMethod.Get
			};
			var response = ExecuteRequest<CollectionsResponse>(request);
			return response.Data;
		}

		public async Task<CollectionsResponse> SearchCollectionsAsync(string query)
		{
			if (query == null) throw new ArgumentNullException("query");
			var request = new HttpRequestMessage
			{
				RequestUri = new Uri(string.Format("{0}/3/search/collection?api_key={1}&query={2}", DefaultBaseUrl, ApiKey, query)),
				Method = HttpMethod.Get
			};
			var response = await ExecuteRequestAsync<CollectionsResponse>(request);
			return response.Data;
		}

		public Movie GetMovie (int id)
		{
			var request = new HttpRequestMessage
			{
				RequestUri = new Uri(string.Format("{0}/3/movie/{1}?api_key={2}", DefaultBaseUrl, id, ApiKey)),
				Method = HttpMethod.Get
			};
			var response = ExecuteRequest<Movie>(request);
			return response.Data;
		}

		public async Task<Movie> GetMovieAsync (int id)
		{
			var request = new HttpRequestMessage
			{
				RequestUri = new Uri(string.Format("{0}/3/movie/{1}?api_key={2}", DefaultBaseUrl, id, ApiKey)),
				Method = HttpMethod.Get
			};
			var response = await ExecuteRequestAsync<Movie>(request);
			return response.Data;
		}

        private HttpResponse<T> ExecuteRequest<T>(HttpRequestMessage request) where T : new()
        {
            var response = ExecuteRequestAsync<T>(request).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new MovieSharpException(response.StatusMessage, response.HttpStatus, response.StatusCode, null);
            }
            return response;
        }

        private async Task<HttpResponse<T>> ExecuteRequestAsync<T>(HttpRequestMessage request) where T : new()
        {
            using (var httpClient = new HttpClient(new HttpClientHandler()))
            {
                var httpResponseMessage = await httpClient.SendAsync(request);

                var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
                Debug.WriteLine("HttpStatus={0}; StatusCode={1}; StatusMessage={2}; Data={3}", httpResponseMessage.StatusCode, string.Empty, httpResponseMessage.ReasonPhrase, responseContent);

                var response = new HttpResponse<T>
                                         {
                                             HttpStatus = httpResponseMessage.StatusCode,
                                             IsSuccessStatusCode = httpResponseMessage.IsSuccessStatusCode,
                                             StatusMessage = httpResponseMessage.ReasonPhrase
                                         };

                // Parse the response
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    // Parse the successful the response.
                    response.Data = responseContent.ToObject<T>();
                }
                else
                {
                    // Parse the error response.
                    var error = responseContent.ToObject<HttpResponse>();
                    response.StatusCode = error.StatusCode;
                    response.StatusMessage = error.StatusMessage;
                }

                Debug.WriteLine("HttpStatus={0}; StatusCode={1}; StatusMessage={2}; Data={3}", response.HttpStatus, string.Empty, response.StatusMessage, responseContent);
                return response;
            }
        }
    }
}
