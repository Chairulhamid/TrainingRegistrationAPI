using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Context;
using TrainingRegistrationAPI.Models;

namespace TrainingRegistrationAPI.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, int>
    {
        public AccountRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
