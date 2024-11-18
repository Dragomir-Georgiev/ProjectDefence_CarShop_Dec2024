using Microsoft.AspNetCore.Mvc;

namespace CarShop.Web.Controllers
{
    public class FeedbackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
