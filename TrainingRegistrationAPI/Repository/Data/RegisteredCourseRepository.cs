using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Context;
using TrainingRegistrationAPI.Models;

namespace TrainingRegistrationAPI.Repository.Data
{
    public class RegisteredCourseRepository : GeneralRepository<MyContext, RegisteredCourse, int>
    {
        public RegisteredCourseRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
