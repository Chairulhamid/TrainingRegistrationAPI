using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using System.Threading.Tasks;

namespace TrainingRegistrationAPI.Models
{
    [Table("Tb_M_Feedback")]
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        public string Testimony { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User User{ get; set; }
    }
}
