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
    /*[Authorize]*/
    public class PaymentsController : BaseController<Payment, PaymentRepository, int>
    {
        private readonly PaymentRepository repository;
        public PaymentsController(PaymentRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        //AMBIL SEMUA DATA PAY SUDAH DI BAYAR/ TOLAK
        /*[HttpGet("GetEmployees/{NIK}")]*/
        public async Task<JsonResult> GetPayALL()
        {
            var result = await repository.GetPayALL();
            return Json(result);
        }
        //AMBIL SEMUA DATA PAY SUDAH DI BAYAR/ TOLAK BY ID
        public async Task<JsonResult> GetIdALLStatus(int UserId)
        {
            var result = await repository.GetIdALLStatus(UserId);
            return Json(result);
        }
        //AMBIL SEMUA DATA Lesson Course SUDAH DI BAYAR/ TOLAK BY ID
        public async Task<JsonResult> GetLessonCourse(int UserId)
        {
            var result = await repository.GetLessonCourse(UserId);
            return Json(result);
        }

        //AMBIL SEMUA DATA PAY BELUM DI BAYAR/ TOLAK

        /*[HttpGet("GetEmployees/{NIK}")]*/
        public async Task<JsonResult> GetPayStatus()
        {
            var result = await repository.GetPayStatus();
            return Json(result);
        }

        public async Task<JsonResult> GetPayStatusId(int id)
        {
            var result = await repository.GetPayStatusId(id);
            return Json(result);
        }

        //AMBIL SEMUA DATA PAY SUDAH DI BAYAR/ TOLAK BY ID
        public async Task<JsonResult> GetIdPayStatus(int paymentId)
        {
            var result = await repository.GetIdPayStatus(paymentId);
            return Json(result);
        }

        //REGISTER PAY
        public JsonResult RegisterPay(PaymentVM entity)
        {
            var result = repository.Post(entity);
            return Json(result);
        }
    }
}
