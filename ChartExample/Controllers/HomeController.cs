using ChartExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChartExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Districts()
        {
            var rnd = new Random();
            var chart = new ChartDataModel<CharItem>()
            {
                Title = "Districts",
                ChartDataList = new List<CharItem>
            {
                new CharItem
                {
                    Name = "Жалал-Абад",
                    Value = rnd.Next(100,10000)
                },
                new CharItem
                {
                    Name = "Бишкек",
                    Value = rnd.Next(100,10000)
                },
                new CharItem
                {
                    Name = "Ош",
                    Value = rnd.Next(100,10000)
                },
            }
            };
            return Ok(chart);
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
