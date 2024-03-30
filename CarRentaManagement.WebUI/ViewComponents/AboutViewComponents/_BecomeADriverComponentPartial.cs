using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace CarRentaManagement.WebUI.ViewComponents.AboutViewComponents
{
    public class _BecomeADriverComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
