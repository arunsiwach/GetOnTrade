using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GetOnTrades.Helpers
{
    public class RestWebServiceData : IRestServiceData
    {

        /// <summary>
        /// The base uri of the service // https://news.google.com/rss/search?q=wkhs%20stock%20news&hl=en-US&gl=US&ceid=US:en
        /// </summary>
        protected Uri baseServiceUri { get; private set; } // new Uri("https://news.google.com/rss/search");
        protected HttpClient HttpClient { get; private set; }


        public RestWebServiceData(Uri baseRestWebServiceUrl)
        {
            this.baseServiceUri = baseRestWebServiceUrl;

            this.HttpClient = new HttpClient() { BaseAddress = this.baseServiceUri };
        }

        private HttpRequestMessage CreateRequestMessage(
          HttpMethod httpMethod,
          IDictionary<string, string> queryStringParameters,
          string urlPath)
        {
            Uri serviceUrl = BuildUrl(new Uri(this.baseServiceUri, urlPath), queryStringParameters);

            return new HttpRequestMessage
            {
                RequestUri = serviceUrl,
                Method = httpMethod,
            };
        }



        protected static Uri BuildUrl(Uri serviceUri, IDictionary<string, string> queryStringParameters)
        {
            UriBuilder serviceCallBuilder = new UriBuilder(serviceUri);

            // break out any query string values to append all additional values
            NameValueCollection query = HttpUtility.ParseQueryString(serviceCallBuilder.Query);
            serviceCallBuilder.Query = query.ToString();

            if (queryStringParameters != null)
            {
                foreach (KeyValuePair<string, string> parameter in queryStringParameters)
                {
                    query[parameter.Key] = parameter.Value;
                }
            }

            // reaassign the query string to the Uri with the updated elements
            serviceCallBuilder.Query = query.ToString();
            return serviceCallBuilder.Uri;
        }

        public async Task<IRestServiceDataResponse<T>> GetValueFromService<T>(HttpMethod httpMethod, IWebResponseParser parser, IDictionary<string, string> headerValues, IDictionary<string, string> queryStringParameters, string urlPath) where T : class
        {
            HttpRequestMessage requestMessage =
                this.CreateRequestMessage(httpMethod, queryStringParameters, urlPath);

            return await this.ExecuteRequest<T>(parser, requestMessage);
        }
        private async Task<IRestServiceDataResponse<T>> ExecuteRequest<T>(
           IWebResponseParser parser,
           HttpRequestMessage requestMessage)
               where T : class
        {
            IRestServiceDataResponse<T> restServiceResponse = new RestServiceDataResponse<T>
            {
                ResponseContent = default(T),
                RequestUri = requestMessage.RequestUri
            };

            try
            {
                this.HttpClient.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
                {
                    NoCache = true,
                    Private = true,
                    NoStore = true,
                };
                // get the response
                HttpResponseMessage response = await this.HttpClient.SendAsync(requestMessage).ConfigureAwait(false);


                StringBuilder sb = new StringBuilder();
                foreach (KeyValuePair<string, IEnumerable<string>> header in response.Headers)
                {
                    foreach (string headerValue in header.Value)
                    {
                        sb.Append(headerValue);
                    }

                    string value = sb.ToString();
                    restServiceResponse.ResponseHeaders[header.Key] = value;
                    sb.Clear();
                }

                restServiceResponse.StatusCode = (int)response.StatusCode;

                requestMessage.Dispose();

                using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                {
                    if (responseStream != null)
                    {
                        restServiceResponse.ResponseContent = parser.ParseWebResponse<T>(responseStream);
                    }
                }

                // Throw an exception if the status code is not in range 200 - 299
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                restServiceResponse.ExceptionResponse = new ExceptionResponse(ex);
                restServiceResponse.StatusCode = restServiceResponse.StatusCode;
            }

            return restServiceResponse;
        }


    }
}
