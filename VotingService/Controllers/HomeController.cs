using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace VotingService.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            HomeViewModel votes = await GetVotesHTTPData();

            return View(votes);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        private async Task<HomeViewModel> GetVotesHTTPData()
        {

            var MyHttpClient = new HttpClient();


            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("hello", 3);
            dict.Add("bye", 2);

            return new HomeViewModel {Votes =  dict};

        }
    }

    public class HomeViewModel
    {
        public Dictionary<string, int> Votes { get; set; }
      
    }
}
