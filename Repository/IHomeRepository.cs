using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetOnTrades.Models;

namespace GetOnTrades.Repository
{
    interface IHomeRepository
    {
         IEnumerable<HomeModel> ParseMessage();
    }
}
