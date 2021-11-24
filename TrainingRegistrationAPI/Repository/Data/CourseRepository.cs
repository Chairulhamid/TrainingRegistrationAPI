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
            course.CourseId= courseVM.CourseId;
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
    }
}
