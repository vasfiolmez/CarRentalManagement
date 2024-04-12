using Microsoft.AspNetCore.Mvc;

namespace CarRentaManagement.WebUI.Controllers
{
    public class CarPricingController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Paketler";
            ViewBag.v1 = "Araç Fiyat Paketleri";
            return View();
        }
    }
}
