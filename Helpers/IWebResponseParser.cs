using System.IO;

namespace GetOnTrades.Helpers
{
    public interface IWebResponseParser
    {
        /// <summary>
        /// Takes the web response stream and converts it to the type specified
        /// </summary>
        /// <typeparam name="T">The type to convert the response to</typeparam>
        /// <param name="webResponseStream">The stream received from the web request</param>
        /// <returns>A transformed and populated object from the stream</returns>
        T ParseWebResponse<T>(Stream webResponseStream)
            where T : class;
    }
}
