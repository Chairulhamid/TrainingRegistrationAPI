﻿using Microsoft.AspNetCore.Http;
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
        //GET STATUS ALL
        /*[Authorize(Roles = "Admin")]*/
        //[EnableCors("AllowOrigin")]
        [Route("GetPayALL")]
        [HttpGet]
        public ActionResult<PaymentStatusVM> GetPayALL()
        {
            var result = paymentRepository.GetPayALL();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = " Data tidak ada data di tabel" });

        }
        //GET PAY PAID BY ID
        /*[Authorize(Roles = "Admin")]*/
        //[EnableCors("AllowOrigin")]
        [Route("GetIdALLStatus/{UserId}")]
        [HttpGet]
        public ActionResult<PaymentVM> GetIdALLStatus(int UserId)
        {
            var result = paymentRepository.GetIdALLStatus(UserId);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = " Data tidak ada data di tabel" });
        }
        //GET STATUS ALL NOT PAID
        /*[Authorize(Roles = "Admin")]*/
        //[EnableCors("AllowOrigin")]
        [Route("GetPayStatus")]
        [HttpGet]
        public ActionResult<PaymentStatusVM> GetPayStatus()
        {
            var result = paymentRepository.GetPayStatus();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = " Data tidak ada data di tabel" });

        }

        [Route("GetPayStatusId/{id}")]
        [HttpGet]
        public ActionResult<PaymentStatusVM> GetPayStatusId(int id)
        {
            var result = paymentRepository.GetPayStatusId(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = " Data tidak ada data di tabel" });

        }

        //get payment status for a user where status is unpaid
        [Route("GetPayStatusUserId/{id}")]
        [HttpGet]
        public ActionResult<PaymentStatusVM> GetPayStatusUserId(int id)
        {
            var result = paymentRepository.GetPayStatusUserId(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = " Data tidak ada data di tabel" });

        }

        //get payment status for a user where status is verified
        [Route("GetPayStatusUserIdVerified/{id}")]
        [HttpGet]
        public ActionResult<PaymentStatusVM> GetPayStatusUserIdVerified(int id)
        {
            var result = paymentRepository.GetPayStatusUserIdVerified(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = " Data tidak ada data di tabel" });

        }

        //GET STATUS NOT PAID BY ID
        /*[Authorize(Roles = "Admin")]*/
        //[EnableCors("AllowOrigin")]
        [Route("GetIdPayStatus/{UserId}")]
        [HttpGet]
        public ActionResult<PaymentStatusVM> GetIdPayStatus(int UserId)
        {
            var result = paymentRepository.GetIdPayStatus(UserId);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = " Data tidak ada data di tabel" });
        }
        //GET LessonCOurse BY ID
        /*[Authorize(Roles = "Admin")]*/
        //[EnableCors("AllowOrigin")]
        [Route("GetLessonCourse/{UserId}")]
        [HttpGet]
        public ActionResult<PaymentVM> GetLessonCourse(int UserId)
        {
            var result = paymentRepository.GetLessonCourse(UserId);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = result, message = " Data tidak ada data di tabel" });
        }
        [Route("CountStatusPayment")]
        [HttpGet]
        public ActionResult<PaymentVM> GetStatusPayment()
        {

            var getStatusPayment = paymentRepository.GetStatusPayment();
            if (getStatusPayment != null)
            {
                return Ok(new { status = HttpStatusCode.OK, result = getStatusPayment, message = "Data berhasil ditampilkan" });
            }
            else
            {
                return NotFound(new { status = HttpStatusCode.NotFound, result = getStatusPayment, message = "Tidak ada data di sini" });
            }
        }
    }
}
