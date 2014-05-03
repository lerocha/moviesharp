using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieSharp.Data
{
    public class MoviesResponse : HttpResponse
    {
        public int Page { get; set; }
        public List<Movie> Results { get; set; }
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
    }
}
