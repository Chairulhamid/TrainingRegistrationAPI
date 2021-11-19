using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Context;
using TrainingRegistrationAPI.Models;

namespace TrainingRegistrationAPI.Repository.Data
{
    public class TopicRepository : GeneralRepository<MyContext, Topic, int>
    {
        public TopicRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
