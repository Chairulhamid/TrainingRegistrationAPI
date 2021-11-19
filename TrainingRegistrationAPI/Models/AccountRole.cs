using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingRegistrationAPI.Models
{
    [Table("Tb_M_AccountRole")]
    public class AccountRole
    {
        [Key]
        public int AccountRoleId { get; set; }
        public int RoleId { get; set; }
        public string AccountId { get; set; }
      /*  [JsonIgnore]*/
        public virtual Account Account { get; set; }
 /*       [JsonIgnore]*/
        public virtual Role Role { get; set; }

    }
}
