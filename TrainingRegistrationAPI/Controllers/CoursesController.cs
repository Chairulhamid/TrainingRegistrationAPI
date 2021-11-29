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
        public ActionResult RegisterCourse(CourseVM courseVM)
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
        }
        //GET ALL STATUS == APPROVED <<INI  UNTUK DI HALAMAN USER YANG BAGIAN AKAN DI JUAL>>
        [HttpGet("GetAprovedCourse")]
        public ActionResult GetAprovedCourse()
        {
            var result = courseRepository.GetAprovedCourse();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = "Data tidak ditemukan" });
        }
        //GET STATUS == WAITING
        [HttpGet("GetWaitingCourse")]
        public ActionResult GetWaitingCourse()
        {
            var result = courseRepository.GetWaitingCourse();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = "Data tidak ditemukan" });
        }
        //GET STATUS != WAITING
        [HttpGet("GetActCourse")]
        public ActionResult GetActCourse()
        {
            var result = courseRepository.GetActCourse();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = "Data tidak ditemukan" });
        }
        //GET STATUS == WAITING BY ID
        [HttpGet("GetWaitIdCourse/{CourseId}")]
            public ActionResult GetWaitIdCourse(int courseId)
            {
                var result = courseRepository.GetWaitIdCourse(courseId);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = "Data tidak ditemukan" });
            }
        //GET != WAITING BY ID <<INI HANYA UNTUK TABEL DI ADMIN>>
        [HttpGet("GetActIdCourse/{CourseId}")]
        public ActionResult GetActIdCourse(int courseId)
        {
            var result = courseRepository.GetActIdCourse(courseId);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = "Data tidak ditemukan" });
        }
        //GET == APPROVED BY ID <<INI  UNTUK AKAN DITAMPILKAN DI HALAMAN USER>>
        [HttpGet("GetApvdIdCourse/{CourseId}")]
        public ActionResult GetApvdIdCourse(int courseId)
        {
            var result = courseRepository.GetApvdIdCourse(courseId);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = "Data tidak ditemukan" });
        }
        //GET == COURSE BY ID <<INI  UNTUK AKAN DITAMPILKAN DI HALAMAN LEARN>>
        [HttpGet("GetLearnCourse/{CourseId}")]
        public ActionResult GetLearnCourse(int courseId)
        {
            var result = courseRepository.GetLearnCourse(courseId);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = "Data tidak ditemukan" });
        }

        /*    [Route("GetCourse/{key}")]
            [HttpGet]
            public ActionResult GetCourse(int key)
            {
                var check = courseRepository.GetId(key);
                if (check == 0)
                {
                    return NotFound(new { status = HttpStatusCode.NotFound, result = "", message = "Data Not Found " });
                }
                else
                {
                    var result = courseRepository.GetCourse(key);
                    return Ok(result);
                }
            }*/
        [Route("CountStatusCourse")]
        [HttpGet]
        public ActionResult<CourseVM> GetStatusCourse()
        {

            var getEmpRole = courseRepository.GetStatusCourse();
            if (getEmpRole != null)
            {
                return Ok(new { status = HttpStatusCode.OK, result = getEmpRole, message = "Data berhasil ditampilkan" });
            }
            else
            {
                return NotFound(new { status = HttpStatusCode.NotFound, result = getEmpRole, message = "Tidak ada data di sini" });
            }
        }
    }
}
//test
