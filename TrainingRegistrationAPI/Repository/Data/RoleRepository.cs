﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Context;
using TrainingRegistrationAPI.Models;

namespace TrainingRegistrationAPI.Repository.Data
{
    public class RoleRepository : GeneralRepository<MyContext, Role, int>
    {
        public RoleRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
