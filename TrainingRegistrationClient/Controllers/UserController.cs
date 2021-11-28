using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationClient.Models;

namespace TrainingRegistrationClient.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public UserController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Course()
        {
            return View();
        } 
        public IActionResult Trainer()
        {
            return View();
        }
        public IActionResult Testimoni()
        {
            return View();
        }
        [Route("user/DetailCourse/{Id}")]
        public IActionResult DetailCourse(string Id)
        {
            ViewData["Id"] = Id;
            return View();
        }
        [Route("user/DetailCourse/PayCourse/{Id}")]
        public IActionResult PayCourse(string Id)
        {
            ViewData["Id"] = Id;
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
