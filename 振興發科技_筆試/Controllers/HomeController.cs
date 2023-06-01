using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml;
using 振興發科技_筆試.Models;

namespace 振興發科技_筆試.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //計算BMI
        [HttpPost]
        public IActionResult Index(double height,double weight)
        {
            try
            {
            double bmi = 0;
            double heightmm = height / 100;
            bmi = weight / (Math.Pow(heightmm,2));
            
            string bmiText = bmi.ToString() ;
            ViewData["bmiValue"] = bmiText;
            return View();
            }
            catch(Exception ex)
            {                
                return View("Error");
            }
            
        }
    }
}