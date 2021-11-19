using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingRegistrationAPI.Models
{
    [Table("Tb_M_Role")]
    public class Role
    {
        [Key]
        public int Account_Role_Id { get; set; }
        public int Role_Id { get; set; }
        public string Role_Name { get; set; }
       /* [JsonIgnore]*/
        public virtual ICollection<AccountRole> AccountRoles { get; set; }
    }
}
