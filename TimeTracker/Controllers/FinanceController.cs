﻿using Microsoft.AspNetCore.Mvc;

namespace TimeTracker.Controllers
{
    public class FinanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
