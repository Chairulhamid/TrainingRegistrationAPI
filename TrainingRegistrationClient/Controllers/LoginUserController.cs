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
                    return RedirectToAction("LoginPage", "Home");
                }
                else
                {
                    return RedirectToAction("LoginPage", "Home");
                }
            }

            HttpContext.Session.SetString("JWToken", token);
            /*HttpContext.Session.SetString("Name", jwtHandler.GetName(token));*/
            /*HttpContext.Session.SetString("ProfilePicture", "assets/img/theme/user.png");*/

            return RedirectToAction("Dashboard", "User");
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
