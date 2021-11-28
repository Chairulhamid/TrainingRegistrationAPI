using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Context;
using TrainingRegistrationAPI.Models;
using TrainingRegistrationAPI.ViewModel;

namespace TrainingRegistrationAPI.Repository.Data
{
    public class CourseRepository : GeneralRepository<MyContext, Course, int>
    {
    private readonly MyContext myContext;
        public CourseRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        public int RegisterCourse(CourseVM courseVM)
        {
            Course course = new Course();
            var checkCourseName = myContext.Courses.Where(x => x.CourseName == courseVM.CourseName).FirstOrDefault();
            course.CourseName= courseVM.CourseName;
            if (checkCourseName  != null)
            {
                return 2;
            }
            course.CourseName= courseVM.CourseName;
            course.CourseDesc= courseVM.CourseDesc;
            course.CourseFee= courseVM.CourseFee;
            course.CourseImg= courseVM.CourseImg;
            course.StatusCourse= 0;
            course.TopicId= courseVM.TopicId;
            course.EmployeeId= courseVM.TrainerId;
            myContext.Courses.Add(course);
            var result = myContext.SaveChanges();
            return result;
        }
        /*        public IEnumerable<CourseVM> GetIdCourse(int courseId)
                {
                    var getTopic = (from c in myContext.Courses
                                    select new CourseVM()
                                    {
                                        CourseId = c.CourseId,
                                        CourseName = c.CourseName,
                                        CourseDesc = c.CourseDesc,
                                        CourseFee = c.CourseFee,
                                        CourseImg = c.CourseImg,
                                        StatusCourse = c.StatusCourse,
                                        TopicId = c.TopicId,
                                        TrainerId = c.EmployeeId,
                                    }).Where(u => u.CourseId == courseId).ToList();

                    return getTopic;
                }*/

        //GET ALL STATUS == APPROVED <<INI  UNTUK DI HALAMAN USER YANG BAGIAN AKAN DI JUAL>>
        public IEnumerable<CourseVM> GetAprovedCourse()
        {
            var result = (from t in myContext.Topics
                          join c in myContext.Courses on t.TopicId equals c.TopicId
                          join e in myContext.Employees on c.EmployeeId equals e.EmployeeId
                          select new CourseVM()
                          {
                              CourseId = c.CourseId,
                              CourseName = c.CourseName,
                              CourseDesc = c.CourseDesc,
                              CourseFee = c.CourseFee,
                              CourseImg = c.CourseImg,
                              StatusCourse = c.StatusCourse,
                              TopicId = c.TopicId,
                              TrainerId = c.EmployeeId,
                              TopicName = t.TopicName,
                              TrainerName = e.FirstName + ' ' + e.LastName,
                          }).Where(p => p.StatusCourse == StatusCourse.Approved).ToList();
            return result;
        }
        //GET STATUS == WAITING
        public IEnumerable<CourseVM> GetWaitingCourse()
        {
            var result = (from t in myContext.Topics
                         join c in myContext.Courses on t.TopicId equals c.TopicId
                         join e in myContext.Employees on c.EmployeeId equals e.EmployeeId
                         select new CourseVM()
                         {
                             CourseId = c.CourseId,
                             CourseName = c.CourseName,
                             CourseDesc = c.CourseDesc,
                             CourseFee = c.CourseFee,
                             CourseImg = c.CourseImg,
                             StatusCourse = c.StatusCourse,
                             TopicId = c.TopicId,
                             TrainerId = c.EmployeeId,
                             TopicName = t.TopicName,
                             TrainerName = e.FirstName + ' ' + e.LastName,
                         }).Where(p => p.StatusCourse == 0).ToList();
            return result;
        }
        //GET STATUS != WAITING
        public IEnumerable<CourseVM> GetActCourse()
        {
            var result = (from t in myContext.Topics
                          join c in myContext.Courses on t.TopicId equals c.TopicId
                          join e in myContext.Employees on c.EmployeeId equals e.EmployeeId
                          select new CourseVM()
                          {
                              CourseId = c.CourseId,
                              CourseName = c.CourseName,
                              CourseDesc = c.CourseDesc,
                              CourseFee = c.CourseFee,
                              CourseImg = c.CourseImg,
                              StatusCourse = c.StatusCourse,
                              TopicId = c.TopicId,
                              TrainerId = c.EmployeeId,
                              TopicName = t.TopicName,
                              TrainerName = e.FirstName + ' ' + e.LastName,
                          }).Where(p => p.StatusCourse != 0).ToList();
            return result;
        }
        //GET == WAITING BY ID
        public IEnumerable<CourseVM> GetWaitIdCourse(int key)
        {

            var result = (from t in myContext.Topics
                         join c in myContext.Courses on t.TopicId equals c.TopicId
                         join e in myContext.Employees on c.EmployeeId equals e.EmployeeId
                         where c.CourseId == key
                         select new CourseVM()
                         {
                             CourseId = c.CourseId,
                             CourseName = c.CourseName,
                             CourseDesc = c.CourseDesc,
                             CourseFee = c.CourseFee,
                             CourseImg = c.CourseImg,
                             StatusCourse = c.StatusCourse,
                             TopicId = c.TopicId,
                             TrainerId = c.EmployeeId,
                             TopicName = t.TopicName,
                             TrainerName = e.FirstName + ' ' + e.LastName,
                         }).Where(p => p.StatusCourse == 0).Where(u => u.CourseId == key).ToList();
            return result;
        }
        //GET != WAITING BY ID <<INI HANYA UNTUK TABEL DI ADMIN>>
        public IEnumerable<CourseVM> GetActIdCourse(int key)
        {
            var result = (from t in myContext.Topics
                          join c in myContext.Courses on t.TopicId equals c.TopicId
                          join e in myContext.Employees on c.EmployeeId equals e.EmployeeId
                          where c.CourseId == key
                          select new CourseVM()
                          {
                              CourseId = c.CourseId,
                              CourseName = c.CourseName,
                              CourseDesc = c.CourseDesc,
                              CourseFee = c.CourseFee,
                              CourseImg = c.CourseImg,
                              StatusCourse = c.StatusCourse,
                              TopicId = c.TopicId,
                              TrainerId = c.EmployeeId,
                              TopicName = t.TopicName,
                              TrainerName = e.FirstName + ' ' + e.LastName,
                          }).Where(p => p.StatusCourse != 0).Where(u => u.CourseId == key).ToList();
            return result;
        }
        //GET == APPROVED BY ID <<INI  UNTUK AKAN DITAMPILKAN DI HALAMAN USER>>
        public IEnumerable<CourseVM> GetApvdIdCourse(int key)
        {
            var result = (from t in myContext.Topics
                          join c in myContext.Courses on t.TopicId equals c.TopicId
                          join e in myContext.Employees on c.EmployeeId equals e.EmployeeId
                          where c.CourseId == key
                          select new CourseVM()
                          {
                              CourseId = c.CourseId,
                              CourseName = c.CourseName,
                              CourseDesc = c.CourseDesc,
                              CourseFee = c.CourseFee,
                              CourseImg = c.CourseImg,
                              StatusCourse = c.StatusCourse,
                              TopicId = c.TopicId,
                              TrainerId = c.EmployeeId,
                              TopicName = t.TopicName,
                              TrainerName = e.FirstName + ' ' + e.LastName,
                          }).Where(p => p.StatusCourse == StatusCourse.Approved).Where(u => u.CourseId == key).ToList();
            return result;
        }

        public int GetId(int id)
        {
            var data = myContext.Courses.Find(id);
            if (data != null)
            {
                return 1;
            }
            return 0;
        }


    }
}
//test
