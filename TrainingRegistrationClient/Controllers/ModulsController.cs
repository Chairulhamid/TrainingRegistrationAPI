using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Models;
using TrainingRegistrationAPI.ViewModel;
using TrainingRegistrationClient.Base.Controllers;
using TrainingRegistrationClient.Repository.Data;

namespace TrainingRegistrationClient.Controllers
{
    /*[Authorize]*/
    public class ModulsController : BaseController<Modul, ModulRepository, int>
    {
        private readonly ModulRepository repository;
        public ModulsController(ModulRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        /*[HttpGet("GetTopics/{NIK}")]*/
        public async Task<JsonResult> GetModuls()
        {
            var result = await repository.GetModuls();
            return Json(result);
        }
        public async Task<JsonResult> GetIdModul(int id)
        {
            var result = await repository.GetIdModul(id);
            return Json(result);
        }
        public JsonResult RegisterModul(ModulVM entity)
        {
            var result = repository.Post(entity);
            return Json(result);
        }

        public async Task<JsonResult> GetModulCourse(int EmployeeId)
        {
            var result = await repository.GetModulCourse(EmployeeId);
            return Json(result);
        }

    }
}
