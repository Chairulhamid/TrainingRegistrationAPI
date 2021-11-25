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
        /*[HttpGet("GetTopics/{NIK}")]*/
        public async Task<JsonResult> GetCourses()
        {
            var result = await repository.GetCourses();
            return Json(result);
        }

        public async Task<JsonResult> GetIdCourse(int id)
        {
            var result = await repository.GetIdCourse(id);
            return Json(result);
        }
        public async Task<JsonResult> GetCourse()
        {
            var result = await repository.GetCourse();
            return Json(result);
        }
        public JsonResult RegisterCourse(CourseVM entity)
        {
            var result = repository.Post(entity);
            return Json(result);
        }
    }
}
