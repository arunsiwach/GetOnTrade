using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using GetOnTrades.Models;
using GetOnTrades.Repository;


namespace GetOnTrades.Controllers
{
    public class HomeController : Controller
    {
        private  HomeRepository objHomeRepo;

        //public ViewResult Index()
        //{
        //    return View();
        //}

        public ViewResult Index(string key,string value)
        {
            var msg = FilterMessage(key, value);
            
            return View(msg);
        }


        public IEnumerable<HomeModel> FilterMessage(string key, string value)
        {
            objHomeRepo = new HomeRepository();
            var msg = objHomeRepo.ParseMessage();

            //Default
            if (key == null && value == null)
            {
                return msg;
            }
            switch (key.ToUpper())
            {
                case "SEARCH":
                    if(value != null)
                    {                        
                       msg = msg.Where(s => s.Symbol.Contains(value.ToUpper()));
                    }
                    break;

            }                        
            return msg;
        }    

    }
}   
