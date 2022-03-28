using System;
using System.Collections.Generic;

namespace GetOnTrades.Helpers
{
    public interface IRestServiceDataResponse<T>
         where T : class
    {
        /// <summary>
        /// Gets the response headers from the service response
        /// </summary>
        IDictionary<string, string> ResponseHeaders { get; }

        /// <summary>
        /// Gets the status code returned from the server
        /// </summary>
        int StatusCode { get; set; }


        Uri RequestUri { get; set; }
        /// <summary>
        /// Gets the content returned by the service
        /// </summary>
        T ResponseContent { get; set; }

        /// <summary>
        /// Gets or sets the exception response generated from the service.
        /// </summary>
        ExceptionResponse ExceptionResponse { get; set; }
    }
}
