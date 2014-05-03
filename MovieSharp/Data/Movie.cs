using System.Diagnostics;
using Newtonsoft.Json;

namespace MovieSharp.Data
{
    [DebuggerDisplay("Id={Id}; Title={Title}")]
    public class Movie
    {
        [JsonProperty("adult")]
        public bool IsAdult { get; set; }
        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }
        public int Id { get; set; }
        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }
        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }
        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }
        public double Popularity { get; set; }
        public string Title { get; set; }
        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }
        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }
    }
}
