using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using MovieSharp.Data;

namespace MovieSharp
{
    public class MovieSharpRequestFactory
    {

        public static HttpRequestMessage CreateQueryMoviesRequest(string apiKey, string baseUrl, string query)
        {
            return new HttpRequestMessage
            {
                RequestUri = new Uri(string.Format("{0}/3/search/movie?api_key={1}&query={2}", baseUrl, apiKey, query)),
                Method = HttpMethod.Get
            };
        }

        public static HttpRequestMessage CreateRequest()
        {
            var request = new HttpRequestMessage();
//            request.Content = new StringContent(Body.ToJson(), Encoding.UTF8, "application/json");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return request;
        }
    }
}