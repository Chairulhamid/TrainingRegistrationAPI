using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Models;
using TrainingRegistrationAPI.ViewModel;
using TrainingRegistrationClient.Base.Controllers;
using TrainingRegistrationClient.Models;
using TrainingRegistrationClient.Repository.Data;

namespace TrainingRegistrationClient.Controllers
{
    /*[Authorize]*/
    public class TopicsController : BaseController<Topic, TopicRepository, int>
    {

        private readonly TopicRepository repository;
        public TopicsController(TopicRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
     

        /*[HttpGet("GetTopics/{NIK}")]*/
        public async Task<JsonResult> GetTopics()
        {
            var result = await repository.GetTopics();
            return Json(result);
        }

        public async Task<JsonResult> GetTopic(int id)
        {
            var result = await repository.GetTopic(id);
            return Json(result);
        }


        public JsonResult RegisterTopic(Topic entity)
        {
            var result = repository.Post(entity);
            return Json(result);
        }


    }
}
