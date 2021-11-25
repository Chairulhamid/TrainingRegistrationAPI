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
    public class LoginUserController : BaseController<LoginUserVM, LoginUserRepository, int>
    {
        private readonly LoginUserRepository repository;
        public LoginUserController(LoginUserRepository repository) : base(repository)
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
        public async Task<IActionResult> Auth(LoginUserVM loginUser)
        {
            var jwtToken = await repository.Auth(loginUser);
            var token = jwtToken.Token;
            var pesan = jwtToken.Messages;


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
            /*HttpContext.Session.SetString("Name", jwtHandler.GetName(token));*/
            /*HttpContext.Session.SetString("ProfilePicture", "assets/img/theme/user.png");*/

            return RedirectToAction("Dashboard", "User");
        }

        /*[Authorize]*/
        /*[HttpPut("ResetPassword/")]*/
        /*public IActionResult ResetPassword(LoginUserVM entity)
        {
            var result = repository.Put(entity);
            if (result == 0)
            {
              return RedirectToAction("LoginPageError", "Home");
                
            }
            Json(result);
            return RedirectToAction("LoginPage", "Home");
        }*/

        public JsonResult ResetPassword(LoginUserVM entity)
        {
            var result = repository.Put(entity);
            return Json(result);
        }

        /*[Authorize]*/
        /*[HttpGet("Logout/")]*/
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "User");
        }

    }
}
