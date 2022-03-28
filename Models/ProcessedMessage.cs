using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetOnTrades.Models
{
    public class ProcessedMessage
    {
        public string Title { get; set; } = string.Empty;
        public string NewsLink { get; set; } = string.Empty;
        public string TwitterLink { get; set; } = string.Empty;

        public string StockTwitsLink { get; set; } = string.Empty;

        public string ListedExchange { get; set; } = "NASDAQ";

        [JsonProperty("Tweet")]
        public string Tweets { get; set; } = string.Empty;

        [JsonIgnore]
        public string TweetTitle { get; set; } = string.Empty;

        [JsonIgnore]
        public string TweetResponse { get; set; } = string.Empty;

        public bool isTweeted { get; set; } = false;

        public bool isFavorite { get; set; } = false;

        public string PubDate { get; set; } //= (new DateTime(2011, 6, 10)).ToString();

        public string StockAdditionDate { get; set; } //= (new DateTime(2011, 6, 10)).ToString();

        [JsonProperty("CompanyName")]
        public string CompanyName { get; set; } = string.Empty;

        public string CompanyFirstName { get; set; } = string.Empty;

        [JsonProperty("Symbol")]
        public string Symbol { get; set; } = string.Empty;
        [JsonProperty("WatchUri")]
        public string WatchUri { get; set; } = string.Empty;
        [JsonProperty("Sector")]
        public string Sector { get; set; } = string.Empty;
        [JsonProperty("Source")]
        public string Source { get; set; } = string.Empty;

        public decimal MinimumSpikePercent { get; set; }

        public decimal RecomendedPercentThreshold { get; set; } = 15;


        public decimal MaximumSpikePercent { get; set; }
        public decimal AlertSpikePercent { get; set; }

        [JsonProperty("MarketCap")]
        public decimal MarketCap { get; set; }

        [JsonProperty("OutStandingShares")]
        public decimal OutStandingShares { get; set; }


        [JsonProperty("MarketPrice")]
        public decimal MarketPrice { get; set; }

        [JsonProperty("PercentChangePrevious")]
        public decimal PercentChangePrevious { get; set; }

        [JsonProperty("PercentChange")]
        public decimal PercentChange { get; set; }

        [JsonProperty("PercentChange_Final_AfterHours")]
        public decimal PercentChange_Final_AfterHours { get; set; }

        [JsonProperty("PercentChange_Final_PreHours")]
        public decimal PercentChange_Final_PreHours { get; set; }

        [JsonProperty("PercentChange_Final_InHours")]
        public decimal PercentChange_Final_InHours { get; set; }

        [JsonProperty("BarronsPercentChange")]
        public decimal BarronsPercentChange { get; set; }

        [JsonProperty("PercentChangeInTradingHours")]
        public decimal PercentChangeInTradingHours { get; set; }

        [JsonProperty("PercentChangeAfterTradingHours")]
        public decimal PercentChangeAfterTradingHours { get; set; }

        [JsonProperty("PercentChangePreTradingHours")]
        public decimal PercentChangePreTradingHours { get; set; }

        [JsonProperty("PercentChangePreviousInTradingHours")]
        public decimal PercentChangePreviousInTradingHours { get; set; }

        [JsonProperty("PercentChangePreviousAfterTradingHours")]
        public decimal PercentChangePreviousAfterTradingHours { get; set; }

        [JsonProperty("PercentChangePreviousPreTradingHours")]
        public decimal PercentChangePreviousPreTradingHours { get; set; }

        [JsonProperty("AverageVolume")]
        public decimal AverageVolume { get; set; }

        [JsonProperty("Industry")]
        public string Industry { get; set; }

        [JsonProperty("CurrentTradingSession")]
        public string CurrentTradingSession { get; set; }

        [JsonProperty("isLowFloat")]
        public bool isLowFloat { get; set; } = false;

        public string Error { get; set; }
        public string NewsSourceLink { get; set; }

        public string NewsSourceGoogleLink { get; set; }

        public string NewsSourceBenzingLink { get; set; }

        public string NewsSourceBarronsLink { get; set; }

        public string NewsSourceWeBullLink { get; set; }

        public string NewsSourceMarketBeatLink { get; set; }

        public string NewsSourceMarketWatchLink { get; set; }

        public string RobinNews { get; set; }


        public string HotKeyword { get; set; }
        public string HotIndustry { get; set; }
        public decimal PercentChangeSinceLast { get; set; }
        public decimal AverageVolumeChangeSinceLast { get; set; }

        public bool isIPO { get; set; } = false;

        public bool isNewlyAdded { get; set; } = false;

        public bool isRecomended { get; set; } = false;

        public bool isLowOutstandingShares { get; set; } = false;

        public bool isTradingViewResult { get; set; } = false;

        public bool isWeBullResult { get; set; } = false;

        public bool isWSB { get; set; } = false;

        public bool hasTodayNews { get; set; } = false;

        public bool isNoNews { get; set; } = false;

        public bool isGlobelNewsWire { get; set; } = false;

        public bool isLastOnehourNews { get; set; } = false;

        public string IPODate { get; set; } = string.Empty;

        public string SearchRequestTypes { get; set; }

        [JsonIgnore]
        public bool isChangeInTradingSession { get; set; }
        // ignored
        [JsonIgnore]
        public string SearchString { get; set; }

        [JsonIgnore]
        public string Language { get; set; } = "en-US";

        [JsonIgnore]
        public string Country { get; set; } = "US";

        [JsonIgnore]
        public string Ceid { get; set; } = "US:en";

        public string MarketIdentifierCode { get; set; }//= "XNAS";
        public int TradingHour { get; set; }
        public bool isGainer { get; internal set; }

        [JsonIgnore]
        public string TwitterAccessTokenSecret { get; set; }

        [JsonIgnore]
        public string TwitterConsumerKey { get; set; }

        [JsonIgnore]
        public string TwitterConsumerKeySecret { get; set; }

        [JsonIgnore]
        public string TwitterAccessToken { get; set; }

        //public string TwitterLink = @"https://twitter.com/search?q=${0}&src=cashtag_click&f=live";

        public string NewsSourceStockHouseLink { get; set; } = @"https://stockhouse.com/companies/news?symbol={0}:{1}";

        public string NewsSourceGoogleFinanceLink { get; set; } = @"https://www.google.com/finance/quote/{0}:{1}";

        public string NewsSourceMarketChameleonLink { get; set; } = @"https://marketchameleon.com/Overview/{0}/DailyCharts/";

        public decimal FiftyDayMin { get; set; }
        public decimal FiftyDayMax { get; set; }
        public decimal FiftyWeekMin { get; set; }
        public decimal FiftyWeekMax { get; set; }
        public decimal TodayMin { get; set; }
        public decimal TodayMax { get; set; }
        public int Grade { get; set; }

        public bool hasRelevantNews { get; set; } = true;
        public bool isTop3RecentChange { get; set; } = false;

        public bool isNewsRefreshNeeded { get; set; } = false;

        public bool isBioNews { get; set; } = false;

        public List<NewsDataModel> AllNews { get; set; } = new List<NewsDataModel>();

        public List<TweetDataModel> AllTweets { get; set; } = new List<TweetDataModel>();

        public string TweetDateTimeTopMover { get; set; } //= (new DateTime(2011, 6, 10)).ToString();

        public bool isMostActive { get; set; } = false;

        public bool isTopMover { get; set; } = false;
        public bool isToploser { get; set; } = false;
        public bool hasOptions { get; set; } = false;

        public bool RunForAustrlia { get; set; } = false;

        public string StockNewsRefreshDateTime { get; set; }

        public bool isRecentTopMover { get; set; } = false;

        public static implicit operator ProcessedMessage(List<ProcessedMessage> v)
        {
            throw new NotImplementedException();
        }
    }
}
