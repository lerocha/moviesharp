using MovieSharp.Data;
using NUnit.Framework;

namespace MovieSharp.Test
{
	[TestFixture]
	public class SerializationTest
	{
		[Test]
		public void Serialize()
		{
			var contact = new Movie {
				IsAdult = true, // not an adult movie, but I just need to test this condition :)
				OriginalTitle = "Godfather",
				Title = "Godfather",
			};

			var jsonRequest = contact.ToJson();
			Assert.AreEqual("{\n  \"adult\": true,\n  \"original_title\": \"Godfather\",\n  \"Title\": \"Godfather\"\n}", jsonRequest.Replace("\r", ""));
		}

		[Test]
		public void Deserialize()
		{
			const string json = @"{
	            ""id"": ""123"",
	            ""title"": ""Godfather"",
	            ""original_title"": ""Godfather"",
	            ""adult"": ""false""
            }";

			var movie = json.ToObject<Movie>();
			Assert.NotNull(movie);
			Assert.AreEqual(123, movie.Id);
			Assert.AreEqual("Godfather", movie.Title);
			Assert.AreEqual("Godfather", movie.OriginalTitle);
			Assert.AreEqual(false, movie.IsAdult);
		}
	}
}
