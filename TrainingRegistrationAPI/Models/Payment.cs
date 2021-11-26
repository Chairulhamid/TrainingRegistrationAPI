using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TrainingRegistrationAPI.Models
{
    [Table("Tb_M_Payment")]
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string BankAccount { get; set; }
        public int TotalPayment { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }
        public int RegisteredCourseId { get; set; }
        [JsonIgnore]
        public virtual RegisteredCourse RegisteredCourse { get; set; }
        
    }
    public enum Status
    {
        NotPaid,
        Declined,
        Verified
    }
}
