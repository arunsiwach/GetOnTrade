using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetOnTrades.Models
{
    public class FavoriteModel
    {
        public string symbol { get; set; }
        public string favoriteDate { get; set; }
        public string newsLink { get; set; }
        public decimal marketPrice { get; set; }

    }
}
