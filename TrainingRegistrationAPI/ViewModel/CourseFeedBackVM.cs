using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingRegistrationAPI.ViewModel
{
    public class CourseFeedbackVM
    {
        [Required]
        public int CourseFeedbackId { get; set; }
        [Required]
        public string Testimony { get; set; }
        [Required]
        public int Rating { get; set; }
        //[Required]
        public int RegisteredCourseId { get; set; }
        //[Required]
        public int UserId { get; set; }
       /* [Required]*/
        public string Email { get; set; }
       /* [Required]*/
        public int CourseId { get; set; }
        //public string FirstName { get; set; }
        //[Required]
        //public string LastName { get; set; }
        //[Required]

        //public string CourseName { get; set; }
    }
}
