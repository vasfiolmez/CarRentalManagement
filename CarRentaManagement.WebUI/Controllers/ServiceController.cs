﻿using Microsoft.AspNetCore.Mvc;

namespace CarRentaManagement.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}