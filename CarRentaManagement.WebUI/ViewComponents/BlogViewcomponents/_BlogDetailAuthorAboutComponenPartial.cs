using CarRentalManagement.Dto.AuthorDtos;
using CarRentalManagement.Dto.TagCloudDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarRentaManagement.WebUI.ViewComponents.BlogViewcomponents
{
    public class _BlogDetailAuthorAboutComponenPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _BlogDetailAuthorAboutComponenPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7056/api/Blogs/GetAuthorByBlogId?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetAuthorByBlogIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
