using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingRegistrationAPI.ViewModel
{
    public class ModulVM
    {
        [Required]
        public int ModulId { get; set; }
        [Required]
        public string ModulTittle { get; set; }
        [Required]
        public string ModulDesc { get; set; }
        [Required]
        public string ModulContent { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
