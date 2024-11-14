using Microsoft.AspNetCore.Mvc;

namespace CarShop.Web.Controllers
{
    public class BaseController : Controller
    {
        protected bool IsGuidValid(string id, Guid parsedGuid)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            bool isGuidValid = Guid.TryParse(id, out parsedGuid);
            if (!isGuidValid)
            {
                return false;
            }

            return true;
        }
    }
}
