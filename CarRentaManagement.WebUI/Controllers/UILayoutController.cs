﻿using Microsoft.AspNetCore.Mvc;

namespace CarRentaManagement.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
