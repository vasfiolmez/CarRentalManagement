using Microsoft.AspNetCore.Mvc;

namespace CarRentaManagement.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _HeadUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
