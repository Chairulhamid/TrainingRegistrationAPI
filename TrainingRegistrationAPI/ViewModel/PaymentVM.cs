﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Models;

namespace TrainingRegistrationAPI.ViewModel
{
    public class PaymentVM
    {
           [Required]
        public int RegisteredCourseId { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public string CourseFee { get; set; }
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string BankAccount { get; set; }
        public int TotalPayment { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }
    }
  /*  public enum Status
    {

         NotPaid,
        Declined,
        Verified
    }*/
  }

