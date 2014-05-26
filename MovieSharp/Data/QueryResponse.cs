using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;

namespace MovieSharp.Data
{
	[DebuggerDisplay("Page={Page}; TotalPages={TotalPages}; TotalResults={TotalResults}")]
    public class QueryResponse<T> : HttpResponse
    {
		public int Page { get; set; }
		public List<T> Results { get; set; }
		[JsonProperty("total_pages")]
		public int TotalPages { get; set; }
		[JsonProperty("total_results")]
		public int TotalResults { get; set; }
    }
}
