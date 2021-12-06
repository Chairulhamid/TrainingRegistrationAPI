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
    public class FeedbacksController : BaseController<Feedback, FeedbackRepository, int>
    {
        private readonly FeedbackRepository feedbackRepository;
        private readonly MyContext myContext;
        public IConfiguration _configuration;
        public FeedbacksController(FeedbackRepository feedbackRepository, IConfiguration configuration, MyContext myContext) : base(feedbackRepository)
        {
            this.feedbackRepository = feedbackRepository;
            this.myContext = myContext;
            this._configuration = configuration;
        }

        //REGISTER
        [Route("InputFeedback")]
        [HttpPost]
        public ActionResult InputFeedback(FeedbackVM feedbackVM)
        {
            var check = feedbackRepository.InputFeedback(feedbackVM);
            if (check == 1)
            {
                return Ok(new { status = HttpStatusCode.OK, message = "Data berhasil ditambahkan" });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data gagal ditambahkan!!" });
            }
        }
        /*[Authorize(Roles = "Admin")]*/
        //[EnableCors("AllowOrigin")]
        [Route("GetTestimoni")]
        [HttpGet]
        public ActionResult<FeedbackVM> GetTestimoni()
        {
            var result = feedbackRepository.GetTestimoni();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = "Tidak ada data di tabel" });

        }

    }
}
