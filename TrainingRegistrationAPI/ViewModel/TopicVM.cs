using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingRegistrationAPI.ViewModel
{
    public class TopicVM
    {
        [Required]
        public string TopicName { get; set; }
        [Required]
        public string TopicDesc{ get; set;}
    }
}
