using CarRentalManagement.Domain.Entities;
using CarRentalManagement.Dto.RegisterDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarRentaManagement.WebUI.Controllers
{
    [AllowAnonymous]

    public class RegisterController : Controller
	{
		//private readonly IHttpClientFactory _httpClientFactory;
		//public RegisterController(IHttpClientFactory httpClientFactory)
		//{
		//	_httpClientFactory = httpClientFactory;
		//}


		private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
		public IActionResult CreateAppUser()
		{
			return View();
		}
        [HttpPost]
        public async Task< IActionResult> CreateAppUser(CreateRegisterDto createRegisterDto)
        {
            if(!ModelState.IsValid)
            {

                return View();

            }

            var appUser = new AppUser()
            {
                Name = createRegisterDto.Name,
                Surname = createRegisterDto.Surname,
                Email = createRegisterDto.Email,
                UserName = createRegisterDto.Username

            };
            var result= await _userManager.CreateAsync(appUser,createRegisterDto.Password);
            if (result.Succeeded) 
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateAppUser(CreateRegisterDto createRegisterDto)
        //{
        //	var client = _httpClientFactory.CreateClient();
        //	var jsonData = JsonConvert.SerializeObject(createRegisterDto);
        //	StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //	var responseMessage = await client.PostAsync("https://localhost:7056/api/Registers", stringContent);
        //	if (responseMessage.IsSuccessStatusCode)
        //	{
        //		return RedirectToAction("Index", "Login");
        //	}
        //	return View();
        //}
    }
}
