using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace MovieSharp
{
	public static class Extensions
	{
		/// <summary>
		/// Serialize this object into JSON.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string ToJson(this object obj)
		{
			if (obj == null)
				return null;

			var settings = new JsonSerializerSettings {
				NullValueHandling = NullValueHandling.Ignore,
				DefaultValueHandling = DefaultValueHandling.Ignore
			};
			string json = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);
			Debug.WriteLine("Serialization; type={0}; json={1}", obj.GetType(), json);
			return json;
		}

		/// <summary>
		/// Deserialize the string into an object.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		public static T ToObject<T>(this string value) where T : new()
		{
			if (value == null)
				return default(T);

			try {
				return JsonConvert.DeserializeObject<T>(value);
			} catch (Exception e) {
				Debug.WriteLine(e);
				return default(T);
			}
		}

		/// <summary>
		/// Asserts the not null.
		/// </summary>
		/// <returns>The not null.</returns>
		/// <param name="obj">Object.</param>
		/// <param name="name">Name.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static object AssertNotNull(this object obj, string name)
		{
			if (obj == null)
				throw new ArgumentNullException(name);
			return obj;
		}
	}
}