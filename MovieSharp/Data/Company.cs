using System.Diagnostics;

namespace MovieSharp
{
	[DebuggerDisplay("Id={Id}; Name={Name}")]
	public class Company
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}

