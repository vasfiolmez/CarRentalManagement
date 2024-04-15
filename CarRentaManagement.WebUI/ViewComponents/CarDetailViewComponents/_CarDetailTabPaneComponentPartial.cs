using Microsoft.AspNetCore.Mvc;

namespace CarRentaManagement.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailTabPaneComponentPartial:ViewComponent
	{
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
