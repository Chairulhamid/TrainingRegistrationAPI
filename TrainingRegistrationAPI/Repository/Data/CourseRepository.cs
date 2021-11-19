﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Context;
using TrainingRegistrationAPI.Models;

namespace TrainingRegistrationAPI.Repository.Data
{
    public class CourseRepository : GeneralRepository<MyContext, Course, int>
    {
        public CourseRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
