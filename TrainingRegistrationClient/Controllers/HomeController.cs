﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationClient.Models;

namespace TrainingRegistrationClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LoginPage()
        {
            return View();
        }

        public IActionResult LoginEmp()
        {
            return View();
        }
        public IActionResult RegistEmp()
        {
            return View();
        }
        public IActionResult LoginAdmin()
        {
            return View();
        }
        public IActionResult LoginPageError()
        {
            return View();
        }
        public IActionResult ResetPassPage()
        {
            return View();
        }
        public IActionResult ResetPassEmp()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
