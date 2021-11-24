
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
    }
}
