using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetOnTrades.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.IO;
using GetOnTrades.Models;
using GetOnTrades.Repository;

namespace GetOnTrades.Repository
{
    public class FavoriteRepository : IFavoriteRepository
    {

        public FavoriteRepository()
        {
           var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Data", "favorites.json");
            using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using var sr = new StreamReader(fs, System.Text.Encoding.UTF8);
            string content_data = sr.ReadToEnd();

            content_data = JToken.Parse(content_data).ToString();

            AllFavoritesStringdata = content_data;
            var bsg = JsonConvert.DeserializeObject<List<FavoriteModel>>(content_data);
            AllFavoritesData = bsg;

        }

        public string AllFavoritesStringdata;
        public IEnumerable<FavoriteModel> AllFavoritesData;
        public IEnumerable<FavoriteModel> AllFavorites => AllFavoritesData;


        public string AllFavoritesString => AllFavoritesStringdata;
    }   
}
