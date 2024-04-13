using Microsoft.AspNetCore.Mvc;

namespace CarRentaManagement.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController : Controller
    {
        [Route("Index/{id}")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
