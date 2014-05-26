using System.Diagnostics;
using Newtonsoft.Json;

namespace MovieSharp
{
	[DebuggerDisplay("Code={Code}; Name={Name}")]
	public class Language
	{
		[JsonProperty("iso_639_1")]
		public string Code { get; set; }
		public string Name { get; set; }
	}
}

