using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;

namespace MovieSharp.Data
{
    [DebuggerDisplay("StatusCode={StatusCode}; ErrorCode={ErrorCode}; Message={Message}")]
    public class HttpResponse
    {
        [JsonProperty("status_code")]
        public long StatusCode { get; set; }
        [JsonProperty("status_message")]
        public string StatusMessage { get; set; }
        public HttpStatusCode HttpStatus { get; set; }
        public bool IsSuccessStatusCode { get; set; }
    }

    public class HttpResponse<T> : HttpResponse
    {
        public T Data { get; set; }

        public HttpResponse()
        {
        }

        public HttpResponse(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return string.Format("HttpStatus={0}; StatusCode={1}; StatusMessage={2}; Data={3}", HttpStatus, StatusCode, StatusMessage, Data);
        }
    }
}