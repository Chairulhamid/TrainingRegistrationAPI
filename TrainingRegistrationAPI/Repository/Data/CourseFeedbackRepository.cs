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

            var registered = (from rc in myContext.RegisteredCourses
                            where rc.UserId == courseFeedbackVM.UserId && rc.CourseId == courseFeedbackVM.CourseId
                            select rc.RegisteredCourseId).Single();

            //SAVE COURSE FEEDBACK
            courseFeedback.RegisteredCourseId = registered;
            courseFeedback.Testimony = courseFeedbackVM.Testimony;
            courseFeedback.Rating = courseFeedbackVM.Rating;
            myContext.CourseFeedback.Add(courseFeedback);
            var result = myContext.SaveChanges();
            return result;
        }

    }
}
