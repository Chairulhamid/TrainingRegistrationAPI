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
            payment.BankAccount = paymentVM.BankAccount ;
            payment.TotalPayment = paymentVM.TotalPayment ;
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
        public IEnumerable<PaymentStatusVM> GetIdALLStatus(int UserId)
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
                              }).Where(u => u.Status == 0 ).ToList();
            return getPatment;
        }

        public IEnumerable<PaymentStatusVM> GetPayStatusId(int id)
        {
            var getPatment = (from u in myContext.Users
                              join rc in myContext.RegisteredCourses on
                              u.UserId equals rc.UserId
                              join c in myContext.Courses on
                              rc.CourseId equals c.CourseId
                              join p in myContext.Payments on
                              rc.RegisteredCourseId equals p.RegisteredCourseId
                              where p.PaymentId == id
                              select new PaymentStatusVM
                              {
                                  RegisteredCourseId = rc.RegisteredCourseId,
                                  PaymentId = p.PaymentId,
                                  TotalPayment = p.TotalPayment,
                                  UserId = u.UserId,
                                  CourseId = c.CourseId,
                                  BankAccount = p.BankAccount,
                                  FirstName = u.FirstName,
                                  LastName = u.LastName,
                                  Email = u.Email,
                                  CourseName = c.CourseName,
                                  CourseFee = c.CourseFee,
                                  PaymentDate = p.PaymentDate,
                                  Status = p.Status
                              }).ToArray();
            return getPatment;
        }
        //GET NOT PAID BY ID
        public IEnumerable<PaymentStatusVM> GetIdPayStatus(int paymentId)
        {
        
          var getPayment = (from us in myContext.Users
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
                              }).Where(p => p.PaymentId == paymentId).Where(u => u.Status == 0).ToList();
            return getPayment;
        }

        //MATERI COURSE FOR USER
        public IEnumerable<TrainingCourseVM> GetLessonCourse(int UserId)
        {
            var getLessonCourse = (from us in myContext.Users
                              join rgt in myContext.RegisteredCourses on
                              us.UserId equals rgt.UserId
                              join pt in myContext.Payments on
                              rgt.RegisteredCourseId equals pt.RegisteredCourseId
                              join cr in myContext.Courses on
                              rgt.CourseId equals cr.CourseId
                              join ml in myContext.Moduls on
                               cr.CourseId equals ml.CourseId
                                   select new TrainingCourseVM
                              {
                                  FirstName = us.FirstName,
                                  LastName = us.LastName,
                                  Status = pt.Status,
                                  CourseName = cr.CourseName,
                                  CourseDesc = cr.CourseDesc,
                                  CourseImg = cr.CourseImg,
                                  ModulTittle = ml.ModulTittle,
                                  ModulDesc = ml.ModulDesc,
                                  ModulContent = ml.ModulContent,
                                  RegisteredCourseId = rgt.RegisteredCourseId,
                                  PaymentId = pt.PaymentId,
                                  UserId = us.UserId,
                                  CourseId = cr.CourseId,
                               /*   ModulId = ml.ModulId,*/
                              }).Where(u => u.Status ==Status.Verified).Where(p => p.UserId == UserId).ToList();
            return getLessonCourse;
        }
      
    }
}
