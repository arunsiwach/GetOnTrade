using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GetOnTrades.Helpers
{
    public interface IRestServiceData
    {
        /// <summary>
        /// Executes a request with the HTTP method given. This methods will not set any content in the request body.
        /// </summary>
        /// <typeparam name="T">The final object which will be deserialized into from the response</typeparam>
        /// <param name="httpMethod">The HTTP method to utilize for the request.</param>
        /// <param name="parser">The parser which should be used to transform the response to an object</param>
        /// <param name="headerValues">A collection of header values to be sent to the service</param>
        /// <param name="queryStringParameters">The names query string parameters to send in the request</param>
        /// <param name="urlPath">The relative url path to be executed on the root uri</param>
        /// <returns>A populated <typeparamref name="T"/> object as returned by the service</returns>
        Task<IRestServiceDataResponse<T>> GetValueFromService<T>(
            HttpMethod httpMethod,
            IWebResponseParser parser,
            IDictionary<string, string> headerValues,
            IDictionary<string, string> queryStringParameters,
            string urlPath)
            where T : class;
    }
}
