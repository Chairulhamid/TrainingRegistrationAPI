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

namespace TrainingRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<Employee, EmployeeRepository, int>
    {
        private readonly EmployeeRepository employeeRepository;
        private readonly MyContext myContext;
        public IConfiguration _configuration;
        public EmployeesController(EmployeeRepository employeeRepository, IConfiguration configuration, MyContext myContext) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
            this.myContext = myContext; 
            this._configuration = configuration;
        }

        /*[Authorize(Roles = "Admin")]*/
        //[EnableCors("AllowOrigin")]
        [Route("Profile")]
        [HttpGet]
        public ActionResult<RegisterEmpVM> GetProfile()
        {
            var result = employeeRepository.GetProfile();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = "Tidak ada data di tabel" });

        }

        /*[Authorize(Roles = "employee, Admin")]*/
        //[Route("CariProfile/{nik}")]
        [HttpGet("GetIdProfile/{EmployeeId}")]
        public ActionResult GetIdProfile(int EmployeeId)
        {

            var result = employeeRepository.GetIdProfile(EmployeeId);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = "Data dengan Email tersebut tidak ditemukan" });
        }

        [Route("RegisterEmp")]
        [HttpPost]
        public ActionResult RegisterEmp(RegisterEmpVM registerEmpVM)
        {
            var check = employeeRepository.RegisterEmp(registerEmpVM);
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
        [Route("LoginEmp")]
        [HttpPost]
        public ActionResult LoginEmp(LoginEmpVM loginEmpVM)
        {
            var result = employeeRepository.LoginEmp(loginEmpVM);
            if (result == 2)
            {
                return NotFound(new JWTokenVM { Token = "", Messages = "0" });
            }
            else if (result == 3)
            {
                var getDataUser = (from e in myContext.Employees
                                   join a in myContext.Accounts on e.AccountId equals a.AccountId
                                   join ar in myContext.AccountRoles on a.AccountId equals ar.AccountId
                                   join r in myContext.Roles on ar.RoleId equals r.RoleId
                                   orderby e.AccountId
                                   select new
                                   {
                                       AccountId = e.AccountId,
                                       Email = e.Email,
                                       Role = r.RoleName
                                   }).Where(e => e.Email == loginEmpVM.Email).ToList();
                List<string> listRole = new List<string>();
                foreach (var item in getDataUser)
                {
                    listRole.Add(item.Role);
                }
                var data = new LoginEmpVM()
                {
                    Email = loginEmpVM.Email,
                    Role = listRole.ToArray()
                };
                var claims = new List<Claim>
                 {
                new Claim("email", data.Email),
                };
                foreach (var item in data.Role)
                {
                    claims.Add(new Claim("roles", item.ToString())); 
                    claims.Add(new Claim(ClaimTypes.Name, employeeRepository.GetName(loginEmpVM.Email)));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, employeeRepository.GetId(loginEmpVM.Email)));
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
                    Messages = "Login Berhasil!!",
                     EmpId = employeeRepository.GetEmpId(loginEmpVM)
                });
            }
            return NotFound(new JWTokenVM { Token = "", Messages = "1" });
        }

        [HttpPut("ResetPassword")]
        public ActionResult ResetPassword(LoginEmpVM loginEmpVM)
        {
            var result = employeeRepository.ResetPassword(loginEmpVM);
            if (result == 0)
            {
                return NotFound(new { status = HttpStatusCode.NotFound, message = "Email tidak terdaftar" });
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
