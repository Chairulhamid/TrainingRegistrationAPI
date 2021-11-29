using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.ViewModel;

namespace API.ViewModel
{
    public class JWTokenVM
    {
        public string Messages { get; set; } 
        public string Token { get; set; }
        public int UserId { get; set; }
    }
}
