using GetOnTrades.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

namespace GetOnTrades.Models
{
    public class MessagesRepository : IMessageRepository
    {
        public MessagesRepository()
        {
            string urlService = @"https://getontrades.azurewebsites.net/File";
            Uri uriServce = new Uri(urlService);
            string content_data = GetWebResponse(uriServce).Result;

            /*var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Data", "newz.json");
            using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using var sr = new StreamReader(fs, System.Text.Encoding.UTF8);
            string content_data = sr.ReadToEnd();*/

            content_data = JToken.Parse(content_data).ToString();

            AllMessagesStringdata = content_data;
            var bsg = JsonConvert.DeserializeObject<List<ProcessedMessage>>(content_data);
            AllMessagesdata = bsg;
        }

        public string AllMessagesStringdata;
        public IEnumerable<ProcessedMessage> AllMessagesdata;
        public IEnumerable<ProcessedMessage> AllMessages => AllMessagesdata;
        public string AllMessagesString => AllMessagesStringdata;

        private static async Task<string> GetWebResponse(Uri baseServiceUri)
        {
            HttpMethod httpMethod = new HttpMethod(HttpMethod.Get.ToString());
            IRestServiceData testService = new RestWebServiceData(baseServiceUri);
            IDictionary<string, string> queryStringParameters = new Dictionary<string, string>();


            IRestServiceDataResponse<string> result = await testService.GetValueFromService<string>(
                httpMethod,
                new StringWebResponseParser(),
                null,
                queryStringParameters,
                string.Empty).ConfigureAwait(true); ;

            //"averageVolume":{ "raw":34679039,"fmt":"34.68M","longFmt":"34,679,039"}
            return result.ResponseContent;
        }
    }
}
