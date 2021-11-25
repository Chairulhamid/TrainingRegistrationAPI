using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Models;
using TrainingRegistrationAPI.ViewModel;
using TrainingRegistrationClient.Base.Controllers;
using TrainingRegistrationClient.Repository.Data;

namespace TrainingRegistrationClient.Controllers
{
    public class PaymentsController : BaseController<Payment, PaymentRepository, int>
    {
        private readonly PaymentRepository repository;
        public PaymentsController(PaymentRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public JsonResult RegisterPay(PaymentVM entity)
        {
            var result = repository.Post(entity);
            return Json(result);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
