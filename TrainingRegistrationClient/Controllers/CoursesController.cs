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
    public class CoursesController : BaseController<Course, CourseRepository, int>
    {

        private readonly CourseRepository repository;
        public CoursesController(CourseRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult RegisterCourse(CourseVM entity)
        {
            var result = repository.Post(entity);
            return Json(result);
        }
        //GET ALL STATUS == APPROVED <<INI  UNTUK DI HALAMAN USER YANG BAGIAN AKAN DI JUAL>>
        /*[HttpGet("GetTopics/{NIK}")]*/
        public async Task<JsonResult> GetAprovedCourse()
        {
            var result = await repository.GetAprovedCourse();
            return Json(result);
        }
        //GET STATUS == WAITING
        public async Task<JsonResult> GetWaitingCourse()
        {
            var result = await repository.GetWaitingCourse();
            return Json(result);
        }
        //GET STATUS != WAITING
        public async Task<JsonResult> GetActCourse()
        {
            var result = await repository.GetActCourse();
            return Json(result);
        }
        //GET == WAITING BY ID
        public async Task<JsonResult> GetWaitIdCourse(int id)
        {
            var result = await repository.GetWaitIdCourse(id);
            return Json(result);
        }
        //GET != WAITING BY ID <<INI HANYA UNTUK TABEL DI ADMIN>>
        public async Task<JsonResult> GetActIdCourse(int id)
        {
            var result = await repository.GetActIdCourse(id);
            return Json(result);
        }
        //GET == APPROVED BY ID <<INI  UNTUK AKAN DITAMPILKAN DI HALAMAN USER>>
        public async Task<JsonResult> GetApvdIdCourse(int id)
        {
            var result = await repository.GetApvdIdCourse(id);
            return Json(result);
        }
     /*   public async Task<JsonResult> GetCourse()
        {
            var result = await repository.GetCourse();
            return Json(result);
        }*/
  
    }
}
