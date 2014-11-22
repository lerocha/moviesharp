using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
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

		public BaseResponse<Configuration> GetConfiguration()
		{
			return GetConfigurationAsync().Result;
		}

		public async Task<BaseResponse<Configuration>> GetConfigurationAsync()
		{
			var request = new HttpRequestMessage {
				RequestUri = createRequestUri("/configuration"),
				Method = HttpMethod.Get
			};
			var response = await ExecuteRequestAsync<Configuration>(request);
			return response;
		}

		public BaseResponse<Collection> GetCollection(int id)
		{
			return GetCollectionAsync(id).Result;
		}

		public async Task<BaseResponse<Collection>> GetCollectionAsync(int id)
		{
			var request = new HttpRequestMessage {
				RequestUri = createRequestUri("/collection/{0}", id),
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
				RequestUri = createRequestUri("/collection/{0}/images", id),
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
				RequestUri = createRequestUri("/movie/{0}", id),
				Method = HttpMethod.Get
			};
			var response = await ExecuteRequestAsync<Movie>(request);
			return response;
		}

		public BaseResponse<MoviesResult> GetSimilarMovies(int id, int page = 1)
		{
			return GetSimilarMoviesAsync(id, page).Result;
		}

		public async Task<BaseResponse<MoviesResult>> GetSimilarMoviesAsync(int id, int page = 1)
		{
			var request = new HttpRequestMessage {
				RequestUri = createRequestUri("/movie/{0}/similar?page={1}", id, page),
				Method = HttpMethod.Get
			};

			var response = await ExecuteRequestAsync<MoviesResult>(request);
			return response;
		}

		public BaseResponse<MoviesResult> GetUpcomingMovies(int page = 1)
		{
			return GetUpcomingMoviesAsync(page).Result;
		}

		public async Task<BaseResponse<MoviesResult>> GetUpcomingMoviesAsync(int page = 1)
		{
			var request = new HttpRequestMessage {
				RequestUri = createRequestUri("/movie/upcoming?page={0}", page),
				Method = HttpMethod.Get
			};

			var response = await ExecuteRequestAsync<MoviesResult>(request);
			return response;
		}

		public BaseResponse<MoviesResult> GetNowPlayingMovies(int page = 1)
		{
			return GetNowPlayingMoviesAsync(page).Result;
		}

		public async Task<BaseResponse<MoviesResult>> GetNowPlayingMoviesAsync(int page = 1)
		{
			var request = new HttpRequestMessage {
				RequestUri = createRequestUri("/movie/now_playing?page={0}", page),
				Method = HttpMethod.Get
			};

			var response = await ExecuteRequestAsync<MoviesResult>(request);
			return response;
		}

		public BaseResponse<MoviesResult> GetPopularMovies(int page = 1)
		{
			return GetPopularMoviesAsync(page).Result;
		}

		public async Task<BaseResponse<MoviesResult>> GetPopularMoviesAsync(int page = 1)
		{
			var request = new HttpRequestMessage {
				RequestUri = createRequestUri("/movie/popular?page={0}", page),
				Method = HttpMethod.Get
			};

			var response = await ExecuteRequestAsync<MoviesResult>(request);
			return response;
		}

		public BaseResponse<MoviesResult> GetTopRatedMovies(int page = 1)
		{
			return GetTopRatedMoviesAsync(page).Result;
		}

		public async Task<BaseResponse<MoviesResult>> GetTopRatedMoviesAsync(int page = 1)
		{
			var request = new HttpRequestMessage {
				RequestUri = createRequestUri("/movie/top_rated?page={0}", page),
				Method = HttpMethod.Get
			};

			var response = await ExecuteRequestAsync<MoviesResult>(request);
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
				RequestUri = createRequestUri("/search/movie?query={0}", query),
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
				RequestUri = createRequestUri("/search/collection?query={0}", query),
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

		private Uri createRequestUri(string resource, params Object[] args)
		{
			resource.AssertNotNull("resource");

			StringBuilder builder = new StringBuilder();
			builder.Append(DefaultBaseUrl);
			builder.Append("/3");

			if (args != null) {
				builder.AppendFormat(resource, args);
			} else {
				builder.Append(resource);
			}

			if (resource.Contains("?")) {
				builder.AppendFormat("&api_key={0}", ApiKey);
			} else {
				builder.AppendFormat("?api_key={0}", ApiKey);
			}

			string url = builder.ToString();
			return new Uri(url);
		}
	}
}
