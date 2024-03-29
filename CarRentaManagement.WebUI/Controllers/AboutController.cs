using Microsoft.AspNetCore.Mvc;

namespace CarRentaManagement.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
