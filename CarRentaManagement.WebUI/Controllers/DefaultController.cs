using Microsoft.AspNetCore.Mvc;

namespace CarRentaManagement.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
