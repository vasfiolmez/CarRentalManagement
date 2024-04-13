using CarRentalManagement.Dto.BlogDtos;
using CarRentalManagement.Dto.TagCloudDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarRentaManagement.WebUI.ViewComponents.BlogViewcomponents
{
    public class _BlogDetailsTagCloudComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsTagCloudComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.blogid = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7056/api/TagClouds/GetTagCloudByBlogId?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List< GetByBlogIdTagCloudDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
