using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetOnTrades.Helpers
{
    public class RestServiceDataResponse<T> : IRestServiceDataResponse<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RestServiceDataResponse{T}"/> class
        /// </summary>
        public RestServiceDataResponse()
        {
            this.ResponseHeaders = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets or sets the response headers
        /// </summary>
        public IDictionary<string, string> ResponseHeaders { get; set; }

        /// <summary>
        /// Gets or sets the status code returned from the server
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the RequestUrl
        /// </summary>
        public Uri RequestUri { get; set; }

        /// <summary>
        /// Gets or sets the response content
        /// </summary>
        public T ResponseContent { get; set; }

        /// <summary>
        /// Gets or sets the exception response generated from the service.
        /// </summary>
        public ExceptionResponse ExceptionResponse { get; set; }
    }
}
