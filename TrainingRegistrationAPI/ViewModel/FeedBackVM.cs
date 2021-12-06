using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingRegistrationAPI.ViewModel
{
    public class FeedbackVM
    {
        [Required]
        public int FeedbackId { get; set; }
        [Required]
        public string Testimony { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Email { get; set; }
       public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
