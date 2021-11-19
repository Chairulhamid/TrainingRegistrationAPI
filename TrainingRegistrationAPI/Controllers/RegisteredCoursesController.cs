using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Controller.Base;
using TrainingRegistrationAPI.Models;
using TrainingRegistrationAPI.Repository.Data;

namespace TrainingRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisteredCoursesController : BaseController<RegisteredCourse, RegisteredCourseRepository, int>
    {
        public RegisteredCoursesController(RegisteredCourseRepository registeredCourseRepository) : base(registeredCourseRepository)
        {

        }
    }
}
