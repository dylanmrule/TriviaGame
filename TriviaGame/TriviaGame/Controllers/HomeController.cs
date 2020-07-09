using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TriviaGame.Models;
using TriviaGame.Models.APIModels;

namespace TriviaGame.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://opentdb.com/");
            //client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; GrandCircus/1.0)");
            var modifiedEndPoint = "api_category.php";
            var response = await client.GetStringAsync(modifiedEndPoint);
            CategoryList result = new CategoryList(response);
            return View(result);
        }

        public async Task<IActionResult> QuestionView(string Id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://opentdb.com/");
            //client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; GrandCircus/1.0)");
            var modifiedEndPoint = "api.php?amount=1&category=" + Id;
            var response = await client.GetStringAsync(modifiedEndPoint);
            Questions result = new Questions(response);
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
