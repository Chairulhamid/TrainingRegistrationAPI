using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Context;
using TrainingRegistrationAPI.Models;
using TrainingRegistrationAPI.ViewModel;

namespace TrainingRegistrationAPI.Repository.Data
{
    public class RegisteredCourseRepository : GeneralRepository<MyContext, RegisteredCourse, int>
    {
        private readonly MyContext myContext;
        public RegisteredCourseRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

       
    }
}
