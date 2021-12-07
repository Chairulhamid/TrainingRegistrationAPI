﻿using Microsoft.AspNetCore.Mvc;
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
    public class CourseFeedbacksController : BaseController<CourseFeedback, CourseFeedbackRepository, int>
    {

        private readonly CourseFeedbackRepository repository;
        public CourseFeedbacksController(CourseFeedbackRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        /*[HttpGet("GetTopics/{NIK}")]*/
        public async Task<JsonResult> GetFeedback()
        {
            var result = await repository.GetFeedback();
            return Json(result);
        }

        public async Task<JsonResult> GetFeedback(int id)
        {
            var result = await repository.GetFeedback(id);
            return Json(result);
        }


        public JsonResult InputCourseFeedback(CourseFeedbackVM entity)
        {
            var result = repository.Post(entity);
            return Json(result);
        }


    }
}
