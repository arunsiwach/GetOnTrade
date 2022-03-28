using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;


namespace GetOnTrades.Helpers
{
    public class ExceptionResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionResponse"/> class.
        /// </summary>
        public ExceptionResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionResponse"/> class.
        /// </summary>
        /// <param name="message">The message of the exception</param>
        /// <param name="statusCode">The status code of the exception response</param>
        public ExceptionResponse(string message, int statusCode)
        {
            this.ExceptionMessage = message;
            this.StatusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionResponse"/> class.
        /// </summary>
        /// <param name="e">The exception</param>
        public ExceptionResponse(Exception e)
        {
            this.ExceptionMessage = this.GetErrorMessage(e);
            this.Type = e.GetType().ToString();
            this.StatusCode = this.ExceptionToStatusCode(e);

            if (e is AggregateException)
            {
                this.Exceptions = this.GetAggregateExceptions((AggregateException)e).Select(exception => new ExceptionResponse(exception));
            }
            else if (e.InnerException != null)
            {
                this.InnerException = new ExceptionResponse(e.InnerException);
            }
        }

        /// <summary>
        /// Gets or sets the status code of this exception
        /// </summary>
        [JsonIgnore]
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the message from the exception
        /// </summary>
        [JsonProperty(PropertyName = "message", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ExceptionMessage { get; set; }

        /// <summary>
        /// Gets or sets he type of the exception occurred
        /// </summary>
        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the list of aggregate exceptions
        /// </summary>
        [JsonProperty(PropertyName = "aggregateExceptions", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<ExceptionResponse> Exceptions { get; set; }

        /// <summary>
        /// Gets or sets the innerException
        /// </summary>
        [JsonProperty(PropertyName = "innerException", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ExceptionResponse InnerException { get; set; }

        /// <summary>
        /// Gets the error message of an exception
        /// </summary>
        /// <param name="ex">The exception</param>
        /// <returns>The string containing the error message</returns>
        private string GetErrorMessage(Exception ex)
        {
            string errorMessage = ex.Message;

            if (ex is WebException)
            {
                Stream responseStream = ((WebException)ex).Response?.GetResponseStream();

                if (responseStream != null)
                {
                    // Pipes the stream to a higher level stream reader with the required encoding format.
                    StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);
                    string webExceptionContent = readStream.ReadToEnd();

                    if (!string.IsNullOrWhiteSpace(webExceptionContent))
                    {
                        errorMessage = $"ErrorMessage:{errorMessage} WebExceptionContent:{webExceptionContent}";
                    }
                }
            }

            return errorMessage;
        }

        /// <summary>
        /// Gets all the aggregate exceptions from a given exception
        /// </summary>
        /// <param name="ex">The main exception</param>
        /// <returns>An enumerable of aggregate exceptions</returns>
        private IEnumerable<Exception> GetAggregateExceptions(Exception ex)
        {
            // AggregateExceptions, if any
            AggregateException aggregateException = ex as AggregateException;
            if (aggregateException != null)
            {
                foreach (Exception exception in aggregateException.InnerExceptions)
                {
                    yield return exception;
                }
            }
        }

        /// <summary>
        /// Converts an exception to the defined status code for such exceptions
        /// </summary>
        /// <param name="ex">The exception to analyze</param>
        /// <returns>The statusCode to use for this exception response</returns>
        private int ExceptionToStatusCode(Exception ex)
        {
            int statusCode = (int)HttpStatusCode.InternalServerError;
            if (ex is WebException webException)
            {
                HttpWebResponse httpWebResponse = webException.Response as HttpWebResponse;

                if (httpWebResponse != null)
                {
                    statusCode = (int)httpWebResponse.StatusCode;
                }
            }
            else if (ex is ArgumentNullException || ex is ArgumentException)
            {
                // All other Exceptions will be considered internal server error
                statusCode = (int)HttpStatusCode.BadRequest;
            }

            return statusCode;
        }
    }
}
