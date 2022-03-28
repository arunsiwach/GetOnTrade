using System;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Newtonsoft.Json;
using GetOnTrades.Models;
using System.Collections.Generic;

namespace GetOnTrades.Controllers
{
    public class FavoriteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost("SaveFavorite")]
        public IActionResult Post([FromBody] FavoriteModel favoriteModel)
        {
            DateTime time = DateTime.Now;
            string format = "MM/dd/yyyy";
            string formattedDate = time.ToString(format);
            
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Data", "favorites.json");
            var jsonData = System.IO.File.ReadAllText(filePath);
            
            var favoriteList = JsonConvert.DeserializeObject<List<FavoriteModel>>(jsonData);

            Console.WriteLine(favoriteModel.marketPrice);
            Console.WriteLine(favoriteModel.symbol);
            Console.WriteLine(favoriteModel.newsLink);

            favoriteList.Add(new FavoriteModel()
            {
                symbol = favoriteModel.symbol,
                favoriteDate = formattedDate,
                newsLink = favoriteModel.newsLink,
                marketPrice = favoriteModel.marketPrice

            });

            jsonData = JsonConvert.SerializeObject(favoriteList);
            Console.WriteLine(jsonData);
            System.IO.File.WriteAllText(filePath, jsonData);

            var newsJsonPath = Path.Combine(Directory.GetCurrentDirectory(), @"Data", "newz.json");
            var newsJsonData = System.IO.File.ReadAllText(newsJsonPath);
            List<ProcessedMessage> processedMessages = JsonConvert.DeserializeObject<List<ProcessedMessage>>(newsJsonData);

            foreach (var newsData in processedMessages)
            {
                if (newsData.Symbol == favoriteModel.symbol)
                {
                    newsData.isFavorite = true;
                    break;
                }
            }

            newsJsonData = JsonConvert.SerializeObject(processedMessages);
            //Console.WriteLine(newsJsonData);
            System.IO.File.WriteAllText(newsJsonPath, newsJsonData);

            return Ok("Success");
        }

        [Microsoft.AspNetCore.Mvc.HttpPost("RemoveFavorite")]
        public void RemoveFavorite([FromBody] FavoriteModel favoriteModel)
        {
            if (favoriteModel.symbol == null)
            {
                Console.WriteLine("Stock Symbol is null");
            }
            else
            {
                Console.WriteLine("Stock Symbol is " + favoriteModel.symbol);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Data", "favorites.json");
                var jsonData = System.IO.File.ReadAllText(filePath);

                var favoriteList = JsonConvert.DeserializeObject<List<FavoriteModel>>(jsonData);

                foreach (var item in favoriteList)
                {
                    if (item.symbol == favoriteModel.symbol)
                    {
                        favoriteList.Remove(item);
                        break;
                    }
                }
                jsonData = JsonConvert.SerializeObject(favoriteList);
                System.IO.File.WriteAllText(filePath, jsonData);

                var newsJsonPath = Path.Combine(Directory.GetCurrentDirectory(), @"Data", "newz.json");
                var newsJsonData = System.IO.File.ReadAllText(newsJsonPath);
                List<ProcessedMessage> processedMessages = JsonConvert.DeserializeObject<List<ProcessedMessage>>(newsJsonData);

                foreach (var newsData in processedMessages)
                {
                    if (newsData.Symbol == favoriteModel.symbol)
                    {
                        newsData.isFavorite = false;
                        break;
                    }
                }

                newsJsonData = JsonConvert.SerializeObject(processedMessages);
                //
                //Console.WriteLine(newsJsonData);
                System.IO.File.WriteAllText(newsJsonPath, newsJsonData);
            }
        }

        public ViewResult GetFavorites()
        {            
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Data", "favorites.json");
            var jsonData = System.IO.File.ReadAllText(filePath);

            var favoriteList = JsonConvert.DeserializeObject<List<FavoriteModel>>(jsonData);
            return View(favoriteList);
        }
    }
}