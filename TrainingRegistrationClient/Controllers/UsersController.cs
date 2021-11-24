using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Models;
using TrainingRegistrationAPI.ViewModel;
using TrainingRegistrationClient.Base.Controllers;
using TrainingRegistrationClient.Models;
using TrainingRegistrationClient.Repository.Data;

namespace TrainingRegistrationClient.Controllers
{
    public class UsersController :  BaseController<User, UserRepository, int>
    {
       /* private readonly ILogger<HomeController> _logger;*/
        private readonly UserRepository repository;
        public UsersController(UserRepository repository) : base(repository)
        {
            this.repository = repository;
        }
       /* public UsersController(ILogger<HomeController> logger) 
        {
            _logger = logger;
        }*/

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
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /*[HttpGet("GetEmployees/{NIK}")]*/
        public async Task<JsonResult> GetUsers()
        {
            var result = await repository.GetUsers();
            return Json(result);
        }

        public async Task<JsonResult> GetUser(int id)
        {
            var result = await repository.GetUser(id);
            return Json(result);
        }


        public JsonResult RegisterUser(RegisterUserVM entity)
        {
            var result = repository.Post(entity);
            return Json(result);
        }

    }
}
