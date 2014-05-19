using System.Diagnostics;
using Newtonsoft.Json;

namespace MovieSharp.Data
{
	[DebuggerDisplay("Id={Id}; Name={Name}")]
	public class Collection
	{
		public int Id { get; set; }
		public double Name { get; set; }
		[JsonProperty("backdrop_path")]
		public string BackdropPath { get; set; }
		[JsonProperty("poster_path")]
		public string PosterPath { get; set; }
	}
}

