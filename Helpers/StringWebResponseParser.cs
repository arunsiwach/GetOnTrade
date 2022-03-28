using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetOnTrades.Helpers
{
    public class StringWebResponseParser : IWebResponseParser
    {
        /// <inheritdoc/>
        public T ParseWebResponse<T>(Stream webResponseStream)
            where T : class
        {
            string response = string.Empty;

            if (webResponseStream != null)
            {
                StreamReader reader = new StreamReader(webResponseStream, Encoding.UTF8);
                response = reader.ReadToEnd();

            }

            return (T)Convert.ChangeType(response, typeof(T));
        }
    }
}
