using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TrainingRegistrationAPI.Models
{
    [Table("Tb_M_Moduls")]
    public class Modul
    {
        [Key]
        public int ModulId { get; set; }
        public string ModulTittle { get; set; }
        public string ModulDesc { get; set; }
        public string ModulContent { get; set; }
        [JsonIgnore]
        public virtual Topic Topic { get; set; }

    }
}
