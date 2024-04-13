using CarRentalManagement.Dto.CommentDtos;
using CarRentalManagement.Dto.TagCloudDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarRentaManagement.WebUI.ViewComponents.CommenViewComponents
{
    public class _CommentListByBlogComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CommentListByBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.blogid = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7056/api/Comments/GetCommentByBlogId?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
