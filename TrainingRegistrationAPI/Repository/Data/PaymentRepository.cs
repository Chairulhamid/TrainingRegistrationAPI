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
        //GET PAY ALL
        public IEnumerable<PaymentStatusVM> GetPayALL()
        {
            var getPatment = (from us in myContext.Users
                              join rgt in myContext.RegisteredCourses on
                              us.UserId equals rgt.UserId
                              join cr in myContext.Courses on
                              rgt.CourseId equals cr.CourseId
                              join pt in myContext.Payments on
                              rgt.RegisteredCourseId equals pt.RegisteredCourseId
                              select new PaymentStatusVM
                              {
                                  RegisteredCourseId = rgt.RegisteredCourseId,
                                  PaymentId = pt.PaymentId,
                                  TotalPayment = pt.TotalPayment,
                                  UserId = us.UserId,
                                  CourseId = cr.CourseId,
                                  BankAccount = pt.BankAccount,
                                  FirstName = us.FirstName,
                                  LastName = us.LastName,
                                  Email = us.Email,
                                  CourseName = cr.CourseName,
                                  CourseFee = cr.CourseFee,
                                  PaymentDate = pt.PaymentDate,
                                  Status = pt.Status,
                              }).Where(p => p.Status != 0).ToList();
            return getPatment;
        }
        //GET ALL BY ID
        public IEnumerable<PaymentStatusVM> GetIdALLStatus( int UserId)
        {
            var getPatment = (from us in myContext.Users
                              join rgt in myContext.RegisteredCourses on
                              us.UserId equals rgt.UserId
                              join cr in myContext.Courses on
                              rgt.CourseId equals cr.CourseId
                              join pt in myContext.Payments on
                              rgt.RegisteredCourseId equals pt.RegisteredCourseId
                              select new PaymentStatusVM
                              {
                                  RegisteredCourseId = rgt.RegisteredCourseId,
                                  PaymentId = pt.PaymentId,
                                  TotalPayment = pt.TotalPayment,
                                  UserId = us.UserId,
                                  CourseId = cr.CourseId,
                                  BankAccount = pt.BankAccount,
                                  FirstName = us.FirstName,
                                  LastName = us.LastName,
                                  Email = us.Email,
                                  CourseName = cr.CourseName,
                                  CourseFee = cr.CourseFee,
                                  PaymentDate = pt.PaymentDate,
                                  Status = pt.Status,
                              }).Where(u => u.Status != 0).Where(p => p.UserId == UserId).ToList();
            return getPatment;
        }
        //GET PAY ALL STATUS NOT PAID
        public IEnumerable<PaymentStatusVM> GetPayStatus()
        {
            var getPatment = (from us in myContext.Users
                              join rgt in myContext.RegisteredCourses on
                              us.UserId equals rgt.UserId
                              join cr in myContext.Courses on
                              rgt.CourseId equals cr.CourseId
                              join pt in myContext.Payments on
                              rgt.RegisteredCourseId equals pt.RegisteredCourseId
                              select new PaymentStatusVM
                              {
                                  RegisteredCourseId = rgt.RegisteredCourseId,
                                  PaymentId = pt.PaymentId,
                                  TotalPayment = pt.TotalPayment,
                                  UserId = us.UserId,
                                  CourseId = cr.CourseId,
                                  BankAccount = pt.BankAccount,
                                  FirstName = us.FirstName,
                                  LastName = us.LastName,
                                  Email = us.Email,
                                  CourseName = cr.CourseName,
                                  CourseFee = cr.CourseFee,
                                  PaymentDate = pt.PaymentDate,
                                  Status = pt.Status,
                              }).Where(u => u.Status == 0  ).ToList();
            return getPatment;
        }
        //GET NOT PAID BY ID
        public IEnumerable<PaymentStatusVM> GetIdPayStatus(int UserId)
        {
        
          var getPatment = (from us in myContext.Users
                              join rgt in myContext.RegisteredCourses on
                              us.UserId equals rgt.UserId
                              join cr in myContext.Courses on
                              rgt.CourseId equals cr.CourseId
                              join pt in myContext.Payments on
                              rgt.RegisteredCourseId equals pt.RegisteredCourseId
                              select new PaymentStatusVM
                              {
                                  RegisteredCourseId = rgt.RegisteredCourseId,
                                  PaymentId = pt.PaymentId,
                                  TotalPayment = pt.TotalPayment,
                                  UserId = us.UserId,
                                  CourseId = cr.CourseId,
                                  BankAccount = pt.BankAccount,
                                  FirstName = us.FirstName,
                                  LastName = us.LastName,
                                  Email = us.Email,
                                  CourseName = cr.CourseName,
                                  CourseFee = cr.CourseFee,
                                  PaymentDate = pt.PaymentDate,
                                  Status = pt.Status,
                              }).Where(u => u.Status == 0).Where (p => p.UserId== UserId) .ToList();
            return getPatment;
        }
    }
}
