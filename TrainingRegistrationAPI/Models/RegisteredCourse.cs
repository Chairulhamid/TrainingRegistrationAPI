using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TrainingRegistrationAPI.Models
{
    [Table("Tb_M_RegisteredCourse")]
    public class RegisteredCourse
    {

        [Key]
        public int RegisteredCourseId { get; set; }
        [JsonIgnore]
        public virtual ICollection<User> User { get; set; }
        [JsonIgnore]
        public virtual Course Course { get; set; }
        [JsonIgnore]
        public virtual Payment Payment { get; set; }
    }
}
