using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;

namespace MovieSharp
{
	public class Configuration
	{
		public Images Images { get; set; }

		[JsonProperty("change_keys")]
		public List<string> ChangeKeys { get; set; }
	}
}

