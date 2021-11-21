using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingRegistrationAPI.ViewModel
{
    public class RegisterUserVM
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public DateTime RegistDate { get; set; }
        public int AccountId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Role_Id { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}

