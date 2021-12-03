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
    public class CourseFeedbacksController : BaseController<CourseFeedback, CourseFeedbackRepository, int>
    {
        private readonly CourseFeedbackRepository courseFeedbackRepository;
        private readonly MyContext myContext;
        public IConfiguration _configuration;
        public CourseFeedbacksController(CourseFeedbackRepository courseFeedbackRepository, IConfiguration configuration, MyContext myContext) : base(courseFeedbackRepository)
        {
            this.courseFeedbackRepository = courseFeedbackRepository;
            this.myContext = myContext;
            this._configuration = configuration;
        }

        //REGISTER
        [Route("InputCourseFeedback")]
        [HttpPost]
        public ActionResult InputCourseFeedback(CourseFeedbackVM courseFeedbackVM)
        {
            var check = courseFeedbackRepository.InputCourseFeedback(courseFeedbackVM);
            if (check == 1)
            {
                return Ok(new { status = HttpStatusCode.OK, message = "Data berhasil ditambahkan" });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data gagal ditambahkan!!" });
            }
        }
    }
}
