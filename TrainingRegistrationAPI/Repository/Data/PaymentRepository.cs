using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Context;
using TrainingRegistrationAPI.Models;

namespace TrainingRegistrationAPI.Repository.Data
{
    public class PaymentRepository : GeneralRepository<MyContext, Payment, int>
    {
        private readonly MyContext myContext;
        public PaymentRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

       /* public int DataPayment(Payment payment)
        {

        }*/
    }
}
