using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Context;
using TrainingRegistrationAPI.Controller.Base;
using TrainingRegistrationAPI.Models;
using TrainingRegistrationAPI.Repository.Data;
using TrainingRegistrationAPI.ViewModel;

namespace TrainingRegistrationAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController<User, UserRepository, int>
    {
        private readonly UserRepository userRepository;
        //private readonly MyContext myContext;
        public IConfiguration _configuration;
        public UsersController(UserRepository userRepository, IConfiguration configuration, MyContext myContext) : base(userRepository)
        {
            this.userRepository = userRepository;
            //this.myContext = myContext; 
            this._configuration = configuration;
        }

        /*[Authorize(Roles = "Admin")]*/
        //[EnableCors("AllowOrigin")]
        [Route("Profile")]
        [HttpGet]
        public ActionResult<RegisterUserVM> GetProfile()
        {
            var result = userRepository.GetProfile();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = "Tidak ada data di tabel" });

        }

        /*[Authorize(Roles = "User, Admin")]*/
        //[Route("CariProfile/{nik}")]
        [HttpGet("Profile/{nik}")]
        public ActionResult GetProfile(string Email)
        {

            var result = userRepository.GetProfile(Email);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = "Data dengan Email tersebut tidak ditemukan" });

        }

        [Route("RegisterUser")]
        [HttpPost]
        public ActionResult RegisterUser(RegisterUserVM registerUserVM)
        {
            var check = userRepository.RegisterUser(registerUserVM);
            if (check == 1)
            {
                return Ok(new { status = HttpStatusCode.OK, message = "Data berhasil ditambahkan" });
            }
            if (check == 2)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data gagal ditambahkan. Email sudah terdaftar" });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data gagal ditambahkan. Phone sudah terdaftar" });

            }

        }

    }
}
