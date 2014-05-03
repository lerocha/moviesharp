using System.Collections.Generic;
using System.Diagnostics;

namespace MovieSharp.Data
{
    [DebuggerDisplay("Done={Done}; TotalSize={TotalSize}")]
    public class QueryResponse<T> : HttpResponse
    {
        public int TotalSize { get; set; }
        public bool Done { get; set; }
        public List<T> Records { get; set; }
    }
}
