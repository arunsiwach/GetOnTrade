using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using GetOnTrades.Models;

namespace GetOnTrades.Models
{
    public class HomeModel
    {
        [JsonPropertyName("PercentChange")]
        public double PercentChange { get; set; }
            
        [JsonPropertyName("WatchUri")]
        public string WatchUri { get; set; }

        [JsonPropertyName("PercentChangeSinceLast")]
        public double PercentChangeSinceLast { get; set; }

        [JsonPropertyName("MarketPrice")]
        public double MarketPrice { get; set; }

        [JsonPropertyName("CompanyName")]
        public string CompanyName { get; set; }

        [JsonPropertyName("Symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("OutStandingShares")]
        public double OutStandingShares { get; set; }

        [JsonPropertyName("AverageVolume")]
        public double AverageVolume { get; set; }

        [JsonPropertyName("AverageVolumeChangeSinceLast")]
        public double AverageVolumeChangeSinceLast { get; set; }

        [JsonPropertyName("MarketCap")]
        public double MarketCap { get; set; }

        [JsonPropertyName("AllNews")]
        public List<AllNews> AllNews { get; set; }

        [JsonPropertyName("AllTweets")]        
        public List<AllTweet> AllTweets { get; set; }


    }

    public class AllNews
    {
        [JsonPropertyName("Symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [JsonPropertyName("NewsLink")]
        public string NewsLink { get; set; }

        [JsonPropertyName("NewsSourceLink")]
        public string NewsSourceLink { get; set; }

        [JsonPropertyName("PubDate")]
        public object PubDate { get; set; }

        [JsonPropertyName("IsTweeted")]
        public bool IsTweeted { get; set; }
    }

    public class AllTweet
    {
        [JsonPropertyName("Symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [JsonPropertyName("NewsLink")]
        public string NewsLink { get; set; }

        [JsonPropertyName("NewsSourceLink")]
        public string NewsSourceLink { get; set; }

        [JsonPropertyName("PubDate")]
        public object PubDate { get; set; }

        [JsonPropertyName("IsTweeted")]
        public bool IsTweeted { get; set; }
    }
}
