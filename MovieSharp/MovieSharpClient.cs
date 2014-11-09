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

		public BaseResponse<Collection> GetCollection(int id)
		{
			return GetCollectionAsync(id).Result;
		}

		public async Task<BaseResponse<Collection>> GetCollectionAsync(int id)
		{
			var request = new HttpRequestMessage {
				RequestUri = new Uri(string.Format("{0}/3/collection/{1}?api_key={2}", DefaultBaseUrl, id, ApiKey)),
				Method = HttpMethod.Get
			};
			var response = await ExecuteRequestAsync<Collection>(request);
			return response;
		}

		public BaseResponse<CollectionImages> GetCollectionImages(int id)
		{
			return GetCollectionImagesAsync(id).Result;
		}

		public async Task<BaseResponse<CollectionImages>> GetCollectionImagesAsync(int id)
		{
			var request = new HttpRequestMessage {
				RequestUri = new Uri(string.Format("{0}/3/collection/{1}/images?api_key={2}", DefaultBaseUrl, id, ApiKey)),
				Method = HttpMethod.Get
			};
			var response = await ExecuteRequestAsync<CollectionImages>(request);
			return response;
		}

		public BaseResponse<Movie> GetMovie(int id)
		{
			return GetMovieAsync(id).Result;
		}

		public async Task<BaseResponse<Movie>> GetMovieAsync(int id)
		{
			var request = new HttpRequestMessage {
				RequestUri = new Uri(string.Format("{0}/3/movie/{1}?api_key={2}", DefaultBaseUrl, id, ApiKey)),
				Method = HttpMethod.Get
			};
			var response = await ExecuteRequestAsync<Movie>(request);
			return response;
		}

		public BaseResponse<MoviesResult> SearchMovies(string query)
		{
			query.AssertNotNull("query");
			return SearchMoviesAsync(query).Result;
		}

		public async Task<BaseResponse<MoviesResult>> SearchMoviesAsync(string query)
		{
			query.AssertNotNull("query");
			var request = new HttpRequestMessage {
				RequestUri = new Uri(string.Format("{0}/3/search/movie?api_key={1}&query={2}", DefaultBaseUrl, ApiKey, query)),
				Method = HttpMethod.Get
			};
			var response = await ExecuteRequestAsync<MoviesResult>(request);
			return response;
		}

		public BaseResponse<CollectionsResult> SearchCollections(string query)
		{
			query.AssertNotNull("query");
			return SearchCollectionsAsync(query).Result;
		}

		public async Task<BaseResponse<CollectionsResult>> SearchCollectionsAsync(string query)
		{
			query.AssertNotNull("query");
			var request = new HttpRequestMessage {
				RequestUri = new Uri(string.Format("{0}/3/search/collection?api_key={1}&query={2}", DefaultBaseUrl, ApiKey, query)),
				Method = HttpMethod.Get
			};
			var response = await ExecuteRequestAsync<CollectionsResult>(request);
			return response;
		}

		private BaseResponse<T> ExecuteRequest<T>(HttpRequestMessage request) where T : new()
		{
			return ExecuteRequestAsync<T>(request).Result;
		}

		private async Task<BaseResponse<T>> ExecuteRequestAsync<T>(HttpRequestMessage request) where T : new()
		{
			using (var httpClient = new HttpClient(new HttpClientHandler())) {
				// Send the request.
				var httpResponseMessage = await httpClient.SendAsync(request);

				// Read the content as string.
				var content = await httpResponseMessage.Content.ReadAsStringAsync();

				var response = new BaseResponse<T> {
					HttpStatus = httpResponseMessage.StatusCode,
					IsOk = httpResponseMessage.IsSuccessStatusCode,
					ReasonPhrase = httpResponseMessage.ReasonPhrase
				};

				// Parse the content.
				if (content != null) {
					if (httpResponseMessage.IsSuccessStatusCode) {
						// Parse the successful the response.
						response.Body = content.ToObject<T>();
					} else {
						// Parse the error response.
						var error = content.ToObject<BaseResponse>();
						if (error != null) {
							response.StatusCode = error.StatusCode;
							response.StatusMessage = error.StatusMessage;
						}
					}
				}

				Debug.WriteLine(response);
				return response;
			}
		}
	}
}
