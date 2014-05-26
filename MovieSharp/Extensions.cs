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
        /// Extends Type class with IsAnonymous method:
        /// http://www.liensberger.it/web/blog/?p=191
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   <c>true</c> if the specified type is anonymous; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAnonymous(this Type type)
        {
            if (type == null) return false;
            return Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute), false)
                   && type.IsGenericType && type.Name.Contains("AnonymousType")
                   && (type.Name.StartsWith("<>") || type.Name.StartsWith("VB$"))
                   && (type.Attributes & TypeAttributes.NotPublic) == TypeAttributes.NotPublic;
        }

        /// <summary>
        /// Serialize this object into JSON.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            if (obj == null) return null;

            var settings = new JsonSerializerSettings
                           {
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
            if (value == null) return default(T);

            try
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return default(T);
            }
        }
    }
}