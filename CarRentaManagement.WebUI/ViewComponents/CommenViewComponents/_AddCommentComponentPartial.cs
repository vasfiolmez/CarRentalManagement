using Microsoft.AspNetCore.Mvc;

namespace CarRentaManagement.WebUI.ViewComponents.CommenViewComponents
{
    public class _AddCommentComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
