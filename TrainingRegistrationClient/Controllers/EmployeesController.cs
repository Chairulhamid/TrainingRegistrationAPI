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
    /*[Authorize]*/
    public class EmployeesController : BaseController<Employee, EmployeeRepository, int>
    {

        private readonly EmployeeRepository repository;
        public EmployeesController(EmployeeRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
     

        /*[HttpGet("GetEmployees/{NIK}")]*/
        public async Task<JsonResult> GetEmployees()
        {
            var result = await repository.GetEmployees();
            return Json(result);
        }

        public async Task<JsonResult> GetEmp(int id)
        {
            var result = await repository.GetEmp(id);
            return Json(result);
        }


        public JsonResult Register(RegisterEmpVM entity)
        {
            var result = repository.Post(entity);
            return Json(result);
        }


    }
}
