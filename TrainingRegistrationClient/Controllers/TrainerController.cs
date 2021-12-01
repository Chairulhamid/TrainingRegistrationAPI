using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingRegistrationClient.Controllers
{
    [Authorize(Roles = "Employee, Trainer, Admin")]
    public class TrainerController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Topic()
        {
            return View();
        }
        public IActionResult Modul()
        {
            return View();
        }
        public IActionResult Course()
        {
            return View();
        }
    }
}
