using CarShop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarShop.Web.Controllers
{
    public class HomeController : BaseController
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

        public IActionResult Error(int? statusCode = null)
        {
            if (!statusCode.HasValue)
            {
                return View();
            }
            if (statusCode == 404)
            {
                return this.View("Error404");
            }

            return this.View("Error500");
        }
        /* Uncomment this if you want to simulate a 500 error. 
         * Just run the app and navigate to https://localhost:7279/simulate-500-direct. !!Make sure to change the localhost to yours!!
        [Route("simulate-500-direct")]
        public IActionResult Simulate500Direct()
        {
            return this.View("Error500");
        }*/
    }
}
