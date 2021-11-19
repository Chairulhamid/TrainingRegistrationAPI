using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Controller.Base;
using TrainingRegistrationAPI.Models;
using TrainingRegistrationAPI.Repository.Data;

namespace TrainingRegistrationAPI.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulsController : BaseController<Modul, ModulRepository, int>
    {
        public ModulsController(ModulRepository modulRepository) : base(modulRepository)
        {

        }
    }
}
