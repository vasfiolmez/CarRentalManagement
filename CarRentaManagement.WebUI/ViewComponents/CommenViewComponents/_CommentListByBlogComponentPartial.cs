using Microsoft.AspNetCore.Mvc;

namespace CarRentaManagement.WebUI.ViewComponents.CommenViewComponents
{
    public class _CommentListByBlogComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
