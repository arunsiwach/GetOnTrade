using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetOnTrades.Models;
using System.IO;
using Newtonsoft.Json;

namespace GetOnTrades.Repository
{
    public class HomeRepository : IHomeRepository
    {      
        public IEnumerable<HomeModel> ParseMessage()
        {

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Data", "crunch_munch.json");
            using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using var sr = new StreamReader(fs, System.Text.Encoding.UTF8);
            string content_data = sr.ReadToEnd();            


            var bsg = JsonConvert.DeserializeObject<List<HomeModel>>(content_data);


            return bsg;
        }
    }
}
