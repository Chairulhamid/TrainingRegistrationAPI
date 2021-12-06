using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Context;
using TrainingRegistrationAPI.Models;
using TrainingRegistrationAPI.ViewModel;

namespace TrainingRegistrationAPI.Repository.Data
{
    public class FeedbackRepository : GeneralRepository<MyContext, Feedback, int>
    {
        private readonly MyContext myContext;
        public FeedbackRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        public int InputFeedback(FeedbackVM feedbackVM)
        {
            var id = (from u in myContext.Users where u.Email == feedbackVM.Email select u.UserId).FirstOrDefault();
            Feedback feedback = new Feedback();
            feedback.Testimony = feedbackVM.Testimony;
            feedback.UserId = id;
            myContext.Feedback.Add(feedback);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
