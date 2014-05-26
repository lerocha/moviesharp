using System.Diagnostics;
using Newtonsoft.Json;

namespace MovieSharp
{
	[DebuggerDisplay("CountryCode={CountryCode}; Name={Name}")]
	public class Country
	{
		[JsonProperty("iso_3166_1")]
		public int CountryCode { get; set; }
		public string Name { get; set; }
	}
}

