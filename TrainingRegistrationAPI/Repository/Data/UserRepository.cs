using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Context;
using TrainingRegistrationAPI.Models;

namespace TrainingRegistrationAPI.Repository.Data
{
    public class UserRepository : GeneralRepository<MyContext, User, int>
    {
     /*   private readonly MyContext myContext;*/
        public UserRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
