using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
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
        private readonly MyContext myContext;
        public IConfiguration _configuration;
        public UsersController(UserRepository userRepository, IConfiguration configuration, MyContext myContext) : base(userRepository)
        {
            this.userRepository = userRepository;
            this.myContext = myContext; 
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
        [Route("LoginUser")]
        [HttpPost]
        public ActionResult LoginUser(LoginUserVM loginUserVM)
        {
            var result = userRepository.LoginUser(loginUserVM);
            if (result == 2)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data gagal dimasukkan: Email yang Anda masukkan belum sudah terdaftar!" });
            }
            else if (result == 3)
            {
                var getDataUser = (from e in myContext.Users
                                   join a in myContext.Accounts on e.AccountId equals a.AccountId
                                   join ar in myContext.AccountRoles on a.AccountId equals ar.AccountId
                                   join r in myContext.Roles on ar.RoleId equals r.RoleId
                                   orderby e.AccountId
                                   select new
                                   {
                                       AccountId = e.AccountId,
                                       Email = e.Email,
                                       Role = r.RoleName
                                   }).Where(e => e.Email == loginUserVM.Email).ToList();
                List<string> listRole = new List<string>();
                foreach (var item in getDataUser)
                {
                    listRole.Add(item.Role);
                }
                var data = new LoginUserVM()
                {
                    Email = loginUserVM.Email,
                    Role = listRole.ToArray()
                };
                var claims = new List<Claim>
                 {
                new Claim("email", data.Email),
                };
                foreach (var item in data.Role)
                {
                    claims.Add(new Claim("roles", item.ToString()));
                }
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn
                    );
                var idToken = new JwtSecurityTokenHandler().WriteToken(token);
                claims.Add(new Claim("TokenSecurity", idToken.ToString()));
                return Ok(new JWTokenVM
                {
                    Token = idToken,
                    Messages = "Login Berhasil!!"
                });
            }
            return Ok(new { status = HttpStatusCode.OK, result = result, message = "Login Gagal, Password yang anda masukan Salah" });
        }

    }
}
