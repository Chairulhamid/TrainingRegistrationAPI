using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using System.Threading.Tasks;

namespace TrainingRegistrationAPI.Models
{
    [Table("Tb_M_CourseFeedback")]
    public class CourseFeedback
    {
        [Key]
        public int CourseFeedbackId { get; set; }
        public string Testimony { get; set; }
        public int Rating { get; set; }
        [JsonIgnore]
        public virtual RegisteredCourse RegisteredCourse { get; set; }
    }
}
