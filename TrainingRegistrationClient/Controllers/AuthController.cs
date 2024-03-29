﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingRegistrationClient.Controllers
{
    [Authorize(Roles="Admin")]
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Employee()
        {
            return View();
        }
        public IActionResult User()
        {
            return View();
        }
        public IActionResult Course()
        {
            return View();
        }
        public IActionResult Topic()
        {
            return View();
        }
        public IActionResult CourseNew()
        {
            return View();
        }
        public IActionResult Modul()
        {
            return View();
        }
        public IActionResult Payment()
        {
            return View();
        }
      
    }
}
