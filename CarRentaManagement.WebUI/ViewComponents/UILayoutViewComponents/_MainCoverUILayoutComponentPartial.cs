using Microsoft.AspNetCore.Mvc;

namespace CarRentaManagement.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _MainCoverUILayoutComponentPartial:ViewComponent
    {
       public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
