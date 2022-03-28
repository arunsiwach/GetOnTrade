using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using GetOnTrades.Models;
using System.Threading.Tasks;
using RestSharp;
using System.Net.Http;

namespace GetOnTrades.Controllers
{
    public class FileOpsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /*[Microsoft.AspNetCore.Mvc.HttpPost("UploadData")]
        public void UploadData([FromBody] string data)
        {
            long size = data.Length;

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Data", "newz.json");
            if (size > 0)
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
                    fileStream.Write(byteArray);
                }
            }
        }*/

        public async Task<IActionResult> TestApi()
        {
            
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://getontrade.azurewebsites.net/GetNewsData"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    
                }
            }
            return null;
        }

        /// <summary>
        /// test Method to upload News 
        /// via API calling
        /// https://getontrade.azurewebsites.net/UploadNewsData
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> UploadStringContentToStorageTest()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Data", "newz.json");
            using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using var sr = new StreamReader(fs, System.Text.Encoding.UTF8);
            //Yours final string of JSON DATa,
            //need to pass as parameter in method of GetONTrade API
            string content_data = sr.ReadToEnd();
            
            using (var httpClient = new HttpClient())
            {   
                StringContent _content = new StringContent(JsonConvert.SerializeObject(content_data), System.Text.Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://getontrade.azurewebsites.net/UploadNewsData", _content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (apiResponse == "Success")
                    {                        
                        return RedirectToAction("Index");
                    }
                }                 
            }
            return View();
        }



        [HttpPost("GetOnTradeNews")]
        public IActionResult AddNews([FromBody] string newsJson)
        {

            return Ok("Success");
        }



        [Microsoft.AspNetCore.Mvc.HttpPost("UploadNewsData")]       
        public IActionResult Post ([FromBody] string newsJson)
        //public IActionResult Index()
        {            

            //string newsJson = string.Empty;
            // Reference : https://stackoverflow.com/questions/55776406/httpcontext-does-not-contain-a-definition-for-current
            long newDataSize = newsJson.Length;

            //Get News.json
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Data", "newz.json");
            List<ProcessedMessage> processedMessages = JsonConvert.DeserializeObject<List<ProcessedMessage>>(newsJson);
            //ProcessedMessage newsDataList = processedMessages;

            //Get favorites.json ----- Starts
            var favoritePath = Path.Combine(Directory.GetCurrentDirectory(), @"Data", "favorites.json");

            using var fs = new FileStream(favoritePath, FileMode.Open, FileAccess.Read);
            using var sr = new StreamReader(fs, System.Text.Encoding.UTF8);
            string content_data = sr.ReadToEnd();

            content_data = JToken.Parse(content_data).ToString();

            var favoriteDataList = JsonConvert.DeserializeObject<List<FavoriteModel>>(content_data);
            
            foreach(var newsData in processedMessages)
            {
                for (int j = 0;j < favoriteDataList.Count; j++)
                {
                    Console.WriteLine(favoriteDataList[j].symbol);
                    Console.WriteLine(favoriteDataList[j].symbol == newsData.Symbol);
                    if (favoriteDataList[j].symbol == newsData.Symbol)
                    {
                        newsData.isFavorite = true;
                        Console.WriteLine("True");
                        break;
                    }                    
                }
            }

            if (newDataSize > 0)
            {
                newsJson = JsonConvert.SerializeObject(processedMessages);
                System.IO.File.WriteAllText(filePath, newsJson);
                //Console.WriteLine(newsJson);
            }

            return Ok("Success");
            
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("GetNewsData")]
        public IActionResult GetNewsData()
        {

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Data", "newz.json");
            using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using var sr = new StreamReader(fs, System.Text.Encoding.UTF8);
            string content_data = sr.ReadToEnd();
            
            return Ok(content_data);
        }

    }
}
