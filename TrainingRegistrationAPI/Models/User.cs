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
    [Table("Tb_M_User")]
    public class User
    {

        [Key]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public DateTime RegistDate { get; set; }
        public int AccountId { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }
        [JsonIgnore]
        public virtual Feedback Feedback { get; set; }
        [JsonIgnore]
        public virtual ICollection<RegisteredCourse> RegisteredCourses { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}

