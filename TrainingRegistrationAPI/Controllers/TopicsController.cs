using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
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
    public class TopicsController : BaseController<Topic, TopicRepository, int>
    {
        private readonly TopicRepository topicRepository;
        private readonly MyContext myContext;
        public IConfiguration _configuration;
        public TopicsController(TopicRepository topicRepository, IConfiguration configuration, MyContext myContext) : base(topicRepository)
        {
            this.topicRepository = topicRepository;
            this.myContext = myContext;
            this._configuration = configuration;
        }

        [Route("RegisterTopic")]
        [HttpPost]
        public ActionResult RegisterTopic(TopicVM topicVM)
        {
            var check = topicRepository.RegisterTopic(topicVM);
            if (check == 1)
            {
                return Ok(new { status = HttpStatusCode.OK, message = "Data berhasil ditambahkan" });
            }
            if (check == 2)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data gagal ditambahkan. Topic sudah terdaftar" });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data gagal ditambahkan. Topic sudah terdaftar" });

            }

        }
    }
}
