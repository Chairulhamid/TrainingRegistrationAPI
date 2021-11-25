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
    public class PaymentsController : BaseController<Payment, PaymentRepository, int>
    {
        private readonly PaymentRepository paymentRepository;
        private readonly MyContext myContext;
        public IConfiguration _configuration;
        public PaymentsController(PaymentRepository paymentRepository, IConfiguration configuration, MyContext myContext) : base(paymentRepository)
        {
            this.paymentRepository = paymentRepository;
            this.myContext = myContext;
            this._configuration = configuration;
        }

        //REGISTER
        [Route("RegisterPay")]
        [HttpPost]
        public ActionResult RegisterPay(PaymentVM paymentVM)
        {
            var check = paymentRepository.RegisterPay(paymentVM);
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
