using Microsoft.AspNetCore.Mvc;

namespace CarShop.Web.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
