using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TrainingRegistrationAPI.Models
{
    [Table("Tb_M_Topic")]
    public class Topic
    {
        [Key]
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public string TopicDesc { get; set; }
        [JsonIgnore]
        public virtual ICollection<Course> Course { get; set; }
    }

}
