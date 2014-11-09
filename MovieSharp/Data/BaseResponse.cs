using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;

namespace MovieSharp.Data
{
	[DebuggerDisplay("HttpStatus={HttpStatus}; StatusCode={StatusCode}; StatusMessage={StatusMessage}")]
    public class BaseResponse
    {
        [JsonProperty("status_code")]
        public long StatusCode { get; set; }
        [JsonProperty("status_message")]
        public string StatusMessage { get; set; }
        public HttpStatusCode HttpStatus { get; set; }
        public bool IsOk { get; set; }
		public string ReasonPhrase { get; set; }
    }

    public class BaseResponse<T> : BaseResponse
    {
        public T Body { get; set; }

        public BaseResponse()
        {
        }

        public BaseResponse(T body)
        {
            Body = body;
        }

        public override string ToString()
        {
            return string.Format("HttpStatus={0}; StatusCode={1}; StatusMessage={2}; Body={3}", HttpStatus, StatusCode, StatusMessage, Body);
        }
    }
}