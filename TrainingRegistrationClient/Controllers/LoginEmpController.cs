using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.ViewModel;
using TrainingRegistrationClient.Base.Controllers;
using TrainingRegistrationClient.Repository.Data;

namespace TrainingRegistrationClient.Controllers
{
    public class LoginEmpController : BaseController<LoginEmpVM, LoginEmpRepository, int>
    {
        private readonly LoginEmpRepository repository;
        public LoginEmpController(LoginEmpRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ErrorEmail()
        {
            return View();
        }

        public IActionResult ErrorPassword()
        {
            return View();
        }

        public IActionResult Error401()
        {
            return View();
        }

        public IActionResult ErrorNotFound()
        {
            return View();
        }

        /*[ValidateAntiForgeryToken]*/
        /*[HttpPost("Auth/")]*/
        public async Task<IActionResult> Auth(LoginEmpVM loginEmp)
        {
            var jwtToken = await repository.Auth(loginEmp);
            var token = jwtToken.Token;
            var pesan = jwtToken.Messages;
            var empId = jwtToken.EmpId;

     
            if (token == "")
            {
                if (pesan == "0")
                {
                    return RedirectToAction("LoginPageError", "Home");
                }
                else
                {
                    return RedirectToAction("LoginPageError", "Home");
                }
            }

            HttpContext.Session.SetString("JWToken", token);
            HttpContext.Session.SetInt32("SessionId", empId);
            /*HttpContext.Session.SetString("Name", jwtHandler.GetName(token));*/
            /*HttpContext.Session.SetString("ProfilePicture", "assets/img/theme/user.png");*/

            return RedirectToAction("Index", "Trainer");

        }
        //ADMIN
        public async Task<IActionResult> LoginAdmin(LoginEmpVM loginEmp)
        {
            var jwtToken = await repository.Auth(loginEmp);
            var token = jwtToken.Token;
            var pesan = jwtToken.Messages;
            var empId = jwtToken.EmpId;


            if (token == "")
            {
                if (pesan == "0")
                {
                    return RedirectToAction("LoginPageError", "Home");
                }
                else
                {
                    return RedirectToAction("LoginPageError", "Home");
                }
            }

            HttpContext.Session.SetString("JWToken", token);
            HttpContext.Session.SetInt32("SessionId", empId);
            /*HttpContext.Session.SetString("Name", jwtHandler.GetName(token));*/
            /*HttpContext.Session.SetString("ProfilePicture", "assets/img/theme/user.png");*/

            return RedirectToAction("Topic", "Auth");

        }

        [Authorize]
        /*[HttpGet("Logout/")]*/
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginEmp", "Home");
        }

    }
}
