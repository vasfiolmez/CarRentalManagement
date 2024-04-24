using CarRentalManagement.Domain.Entities;
using CarRentalManagement.Dto.LoginDtos;
using CarRentaManagement.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;


namespace CarRentaManagement.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(createLoginDto.Username, createLoginDto.Password, false, false);
                if (result.Succeeded) 
                {
                    return RedirectToAction("Index", "AdminCar");
                }
            }
            return View();
        }
        public async Task<IActionResult> LogOut(CreateLoginDto createLoginDto)
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

        //[HttpPost]
        //public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var content = new StringContent(JsonSerializer.Serialize(createLoginDto), Encoding.UTF8, "application/json");
        //    var response = await client.PostAsync("https://localhost:7056/api/Login", content);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var jsonData = await response.Content.ReadAsStringAsync();
        //        var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
        //        {
        //            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        //        });

        //        if (tokenModel != null)
        //        {
        //            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        //            var token = handler.ReadJwtToken(tokenModel.Token);
        //            var claims = token.Claims.ToList();

        //            if (tokenModel.Token != null)
        //            {
        //                claims.Add(new Claim("carrentaltoken", tokenModel.Token));
        //                var claimsIdentity = new ClaimsIdentity(claims,JwtBearerDefaults.AuthenticationScheme);
        //                var authProps = new AuthenticationProperties
        //                {
        //                    ExpiresUtc = tokenModel.ExpireDate,
        //                    IsPersistent = true
        //                };

        //                await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
        //                return RedirectToAction("Index", "Default");
        //            }
        //        }
        //    }

        //    return View();
        //}
    }
}
