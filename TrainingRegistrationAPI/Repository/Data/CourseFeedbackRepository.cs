using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Context;
using TrainingRegistrationAPI.Models;
using TrainingRegistrationAPI.ViewModel;

namespace TrainingRegistrationAPI.Repository.Data
{
    public class CourseFeedbackRepository : GeneralRepository<MyContext, CourseFeedback, int>
    {
        private readonly MyContext myContext;
        public CourseFeedbackRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public int InputCourseFeedback(CourseFeedbackVM courseFeedbackVM)
        {

            CourseFeedback courseFeedback = new CourseFeedback();
            //REGISTERED COURSE
            RegisteredCourse registeredCourse = new RegisteredCourse();
            registeredCourse.UserId = courseFeedbackVM.UserId;
            registeredCourse.CourseId = courseFeedbackVM.CourseId;
            myContext.RegisteredCourses.Add(registeredCourse);
            myContext.SaveChanges();

            //SAVE COURSE FEEDBACK
            courseFeedback.Testimony = courseFeedbackVM.Testimony;
            courseFeedback.Rating = courseFeedbackVM.Rating;
            myContext.CourseFeedback.Add(courseFeedback);
            var result = myContext.SaveChanges();
            return result;
        }

    }
}
