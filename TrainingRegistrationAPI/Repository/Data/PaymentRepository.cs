using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Context;
using TrainingRegistrationAPI.Models;
using TrainingRegistrationAPI.ViewModel;

namespace TrainingRegistrationAPI.Repository.Data
{
    public class PaymentRepository : GeneralRepository<MyContext, Payment, int>
    {
        private readonly MyContext myContext;
        public PaymentRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        //REGISTER
        public int RegisterPay(PaymentVM paymentVM)
        {
            Payment payment= new Payment();
        //REGISTERED COURSE
            RegisteredCourse registeredCourse= new RegisteredCourse();
            registeredCourse.UserId= paymentVM.UserId;
            registeredCourse.CourseId= paymentVM.CourseId;
            myContext.RegisteredCourses.Add(registeredCourse);
            myContext.SaveChanges();
            
            //SAVE PAYMENT
            payment.RegisteredCourseId = registeredCourse.RegisteredCourseId;
            payment.PaymentDate = paymentVM.PaymentDate;
            payment.BankAccount = paymentVM.BankAccount;
            payment.TotalPayment = paymentVM.TotalPayment;
            payment.Status = 0 ;
            myContext.Payments.Add(payment);
            var result = myContext.SaveChanges();
            return result;
        }
        /* public int DataPayment(Payment payment)
         {

         }*/
    }
}
