using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetOnTrades.Models
{
    public class NewsDataModel
    {
        public string Symbol { get; set; }
        public string Title { get; set; }
        public string NewsLink { get; set; }
        public string NewsSourceLink { get; set; }

        public string PubDate { get; set; }
        public bool IsTweeted { get; set; }

        public NewsDataModel(string symbol)
        {
            this.Symbol = symbol;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="title"></param>
        /// <param name="newsSourceLink"></param>
        /// <param name="newsSource"></param>
        /// <param name="isNewsTweeted"></param>
        public NewsDataModel(string symbol, string title, string newsLink, string newsSourceLink, bool isNewsTweeted)
        {
            this.Symbol = symbol;
            this.Title = title;
            this.NewsLink = newsLink;
            this.NewsSourceLink = newsSourceLink;
            this.IsTweeted = isNewsTweeted;

        }

        public NewsDataModel()
        {
        }
    }

    public class TweetDataModel
    {
        public string Title { get; set; }
        public string User { get; set; }

    }
}
