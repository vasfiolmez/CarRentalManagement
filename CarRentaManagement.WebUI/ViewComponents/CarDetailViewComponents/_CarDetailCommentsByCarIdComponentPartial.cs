using Microsoft.AspNetCore.Mvc;

namespace CarRentaManagement.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailCommentsByCarIdComponentPartial:ViewComponent
	{
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
