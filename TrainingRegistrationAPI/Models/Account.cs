using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TrainingRegistrationAPI.Models
{
    [Table("Tb_M_Account")]
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        /*[JsonIgnore]*/
        public virtual User User{ get; set; } 
        /*[JsonIgnore]*/
        public virtual Employee Employee{ get; set; }
      /*  [JsonIgnore]*/
        public virtual ICollection<AccountRole> AccountRoles { get; set; }
    }
}
