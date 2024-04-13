using CarRentalManagement.Dto.BlogDtos;
using CarRentalManagement.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Newtonsoft.Json;
using System.Text;

namespace CarRentaManagement.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IActionResult> Index()
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Yazarlarımızın Blogları";
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7056/api/Blogs/GetAllBlogsWithAuthorsList");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Blog Detayı ve yorumlar";
            ViewBag.blogid = id;

            var client = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync($"https://localhost:7056/api/Comments/GetCountCommentByBlog?id=" + id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();

            ViewBag.commentCount = jsonData2.ToString();

            return View();
        }
        [HttpGet]
        public PartialViewResult AddComment(int id)
        {

            @ViewBag.blogid = id;
            return PartialView(); 
        }

        [HttpPost]
        public async Task< IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7056/api/Comments/CreateCommentMediator", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BlogDetail", "Blog", new {id = createCommentDto.BlogId});
            }
            return View();
        }
       
    }
}
