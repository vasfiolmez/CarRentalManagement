using CarRentalManagement.Dto.BlogDtos;
using CarRentalManagement.Dto.PricingDtos;
using CarRentalManagement.Dto.ReservationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarRentaManagement.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminReservation")]
    public class AdminReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7056/api/Reservations");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultReservationDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("ReservationDetail/{id}")]
        [HttpGet]
        public async Task<IActionResult> ReservationDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7056/api/Reservations/GetReservationById?id="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultReservationDto>(jsonData);
                return View(values);
            }
            return View();
        }

       
        [Route("ReservationStatusChangeApproved/{id}")]
        public async Task<IActionResult> ReservationStatusChangeApproved(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var resposenMessage = await client.GetAsync($"https://localhost:7056/api/Reservations/ReservationStatusChangeApproved?id={id}");
            if (resposenMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminReservation", new { area = "Admin" });

            }
            return View();
        }
        [Route("ReservationStatusChangeCancel/{id}")]
        public async Task<IActionResult> ReservationStatusChangeCancel(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var resposenMessage = await client.GetAsync($"https://localhost:7056/api/Reservations/ReservationStatusChangeCancel?id={id}");
            if (resposenMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminReservation", new { area = "Admin" });

            }
            return View();
        }
        [Route("ReservationStatusChangeWait/{id}")]
        public async Task<IActionResult> ReservationStatusChangeWait(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var resposenMessage = await client.GetAsync($"https://localhost:7056/api/Reservations/ReservationStatusChangeWait?id={id}");
            if (resposenMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminReservation", new { area = "Admin" });

            }
            return View();
        }

        //[Route("ReservationStatusChangeApproved/{id}")]
        //public async Task<IActionResult> ReservationStatusChangeApproved(ApprovedReservationDto updateReservationDto)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(updateReservationDto);
        //    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PutAsync("https://localhost:7056/api/Reservations/", stringContent);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index", "AdminReservation", new { area = "Admin" });
        //    }
        //    return View();
        //}

    }
}
