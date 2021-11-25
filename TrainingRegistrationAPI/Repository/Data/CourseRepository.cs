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
            course.TopicId= courseVM.TopicId;
            course.EmployeeId= courseVM.TrainerId;
            myContext.Courses.Add(course);
            var result = myContext.SaveChanges();
            return result;
        }
        public IEnumerable<CourseVM> GetIdCourse(int courseId)
        {
            var getTopic = (from c in myContext.Courses
                            select new CourseVM()
                            {
                                CourseId = c.CourseId,
                                CourseName = c.CourseName,
                                CourseDesc = c.CourseDesc,
                                CourseFee = c.CourseFee,
                                CourseImg = c.CourseImg,
                                TopicId = c.TopicId,
                                TrainerId = c.EmployeeId,

                            }).Where(u => u.CourseId == courseId).ToList();

            return getTopic;
        }

        public IEnumerable<CourseVM> GetCourse()
        {
            var result = from t in myContext.Topics
                         join c in myContext.Courses on t.TopicId equals c.TopicId
                         join e in myContext.Employees on c.EmployeeId equals e.EmployeeId
                         select new CourseVM()
                         {
                             CourseId = c.CourseId,
                             CourseName = c.CourseName,
                             CourseDesc = c.CourseDesc,
                             CourseFee = c.CourseFee,
                             CourseImg = c.CourseImg,
                             TopicId = c.TopicId,
                             TrainerId = c.EmployeeId,
                             TopicName = t.TopicName,
                             TrainerName = e.FirstName + ' ' + e.LastName,
                         };
            return result;
        }
        public IEnumerable<CourseVM> GetCourse(int key)
        {

            var result = from t in myContext.Topics
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
                             TopicId = c.TopicId,
                             TrainerId = c.EmployeeId,
                             TopicName = t.TopicName,
                             TrainerName = e.FirstName + ' ' + e.LastName,
                         };

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
