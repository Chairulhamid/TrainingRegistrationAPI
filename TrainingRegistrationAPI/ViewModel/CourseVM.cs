using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Models;

namespace TrainingRegistrationAPI.ViewModel
{
    public class CourseVM
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string CourseDesc { get; set; }
        [Required]
        public string CourseFee { get; set; }
        [Required]
        public String CourseImg { get; set; }
        public int TopicId { get; set; }
        public int TrainerId { get; set; }
        public string TopicName { get; set; }
        public string TrainerName { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public StatusCourse StatusCourse { get; set; }

    }
}
