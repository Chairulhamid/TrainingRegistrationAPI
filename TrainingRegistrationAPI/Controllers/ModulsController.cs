
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

namespace TrainingRegistrationAPI.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulsController : BaseController<Modul, ModulRepository, int>
    {
        private readonly ModulRepository modulRepository;
        private readonly MyContext myContext;
        public IConfiguration _configuration;
        public ModulsController(ModulRepository modulRepository, IConfiguration configuration, MyContext myContext) : base(modulRepository)
        {
            this.modulRepository = modulRepository;
            this.myContext = myContext;
            this._configuration = configuration;
        }
        [Route("RegisterModul")]
        [HttpPost]
        public ActionResult RegisterModul(ModulVM modulVM)
        {
            var check = modulRepository.RegisterModul(modulVM);
            if (check == 1)
            {
                return Ok(new { status = HttpStatusCode.OK, message = "Data berhasil ditambahkan" });
            }
            if (check == 2)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data gagal ditambahkan. Modul sudah terdaftar" });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data gagal ditambahkan." });
            }
        }
        [HttpGet("GetIdModul/{ModulId}")]
        public ActionResult GetIdModul(int modulId)
        {
            var result = modulRepository.GetIdModul(modulId);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = "Data tidak ditemukan" });
        }

        [HttpGet("GetModul")]
        public ActionResult GetModul()
        {
            var result = modulRepository.GetModul();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = "Data tidak ditemukan" });
        }


        [Route("GetModul/{key}")]
        [HttpGet]
        public ActionResult GetModul(int key)
        {
            var check = modulRepository.GetId(key);
            if (check == 0)
            {
                return NotFound(new { status = HttpStatusCode.NotFound, result = "", message = "Data Not Found " });
            }
            else
            {
                var result = modulRepository.GetModul(key);
                return Ok(result);
            }
        }

        //GET ModulCourse BY ID
        /*[Authorize(Roles = "Admin")]*/
        //[EnableCors("AllowOrigin")]
        [Route("GetModulCourse/{EmployeeId}")]
        [HttpGet]
        public ActionResult<ModulCourseVM> GetModulCourse(int EmployeeId)
        {
            var result = modulRepository.GetModulCourse(EmployeeId);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = " Data tidak ada data di tabel" });
        }

    }
}
