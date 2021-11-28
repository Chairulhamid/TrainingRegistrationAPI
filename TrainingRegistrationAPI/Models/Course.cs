using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingRegistrationAPI.Models
{
    [Table("Tb_M_Course")]
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDesc { get; set; }
        public string CourseFee { get; set; }
        public string CourseImg { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public StatusCourse StatusCourse { get; set; }
        public int TopicId { get; set; }
        public int EmployeeId { get; set; }
        [JsonIgnore]
        public virtual Employee Employee { get; set; }
        [JsonIgnore]
        public virtual ICollection<Modul> Modul { get; set; }
        [JsonIgnore]
        public virtual ICollection<RegisteredCourse> RegisteredCourse { get; set; }
        [JsonIgnore]
        public virtual Topic Topic { get; set; }
    }

    public enum StatusCourse
    {
        WaitingForApproval,
        Approved,
        Declined
    }

}
