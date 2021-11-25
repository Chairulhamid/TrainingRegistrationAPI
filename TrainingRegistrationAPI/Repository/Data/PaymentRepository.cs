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
            Random rnd = new Random();
            int rPertama = rnd.Next(1, 99);   
            int rKedua = rnd.Next(100);  
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
            payment.BankAccount = paymentVM.BankAccount ;
            payment.TotalPayment = paymentVM.TotalPayment + rPertama + rKedua;
            payment.Status = 0 ;
            myContext.Payments.Add(payment);
            var result = myContext.SaveChanges();
            return result;
        }
/*        public static string GetRandomPassword(int length)
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }*/
        /* public int DataPayment(Payment payment)
         {

         }*/
    }
}
