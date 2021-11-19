using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Context;
using TrainingRegistrationAPI.Models;

namespace TrainingRegistrationAPI.Repository.Data
{
    public class ModulRepository : GeneralRepository<MyContext, Modul, int>
    {
        public ModulRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
