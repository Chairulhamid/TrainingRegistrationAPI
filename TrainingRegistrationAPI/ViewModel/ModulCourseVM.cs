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
    public class ModulCourseVM
    {
        [Required]
        public int EmployeeId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public StatusCourse StatusCourse { get; set; }
        public string CourseName { get; set; }
        public string CourseDesc { get; set; }
        public string CourseImg { get; set; }
        public string ModulTittle { get; set; }
        public string ModulDesc { get; set; }
        public string ModulContent { get; set; }
        public int CourseId { get; set; }
        public int ModulId { get; set; }
    }
}
