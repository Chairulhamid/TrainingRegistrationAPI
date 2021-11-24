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

namespace TrainingRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : BaseController<Course, CourseRepository, int>
    {
        private readonly CourseRepository courseRepository;
        private readonly MyContext myContext;
        public IConfiguration _configuration;
        public CoursesController(CourseRepository courseRepository, IConfiguration configuration, MyContext myContext) : base(courseRepository)
        {
            this.courseRepository = courseRepository;
            this.myContext = myContext;
            this._configuration = configuration;

        }
        [Route("RegisterCourse")]
        [HttpPost]
        public ActionResult RegisterTopic(CourseVM courseVM)
        {
            var check = courseRepository.RegisterCourse(courseVM);
            if (check == 1)
            {
                return Ok(new { status = HttpStatusCode.OK, message = "Data berhasil ditambahkan" });
            }
            if (check == 2)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data gagal ditambahkan. Course sudah terdaftar" });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data gagal ditambahkan. Course sudah terdaftar" });

            }
            [HttpGet("GetIdCourse/{CourseId}")]
            public ActionResult GetIdCourse(int courseId)
            {
                var result = courseRepository.GetIdCourse(courseId);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = "Data tidak ditemukan" });
            }

        }
    }
}
