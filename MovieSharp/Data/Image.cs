using System.Diagnostics;
using Newtonsoft.Json;

namespace MovieSharp
{
	[DebuggerDisplay("FilePath={FilePath}")]
	public class Image
	{
		[JsonProperty("aspect_ratio")]
		public double AspectRatio { get; set; }
		[JsonProperty("file_path")]
		public string FilePath { get; set; }
		public int Height { get; set; }
		[JsonProperty("iso_639_1")]
		public string Iso_639_1 { get; set; }
		public int Width { get; set; }
	}
}

