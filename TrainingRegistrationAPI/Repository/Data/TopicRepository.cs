using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Context;
using TrainingRegistrationAPI.Models;
using TrainingRegistrationAPI.ViewModel;

namespace TrainingRegistrationAPI.Repository.Data
{
    public class TopicRepository : GeneralRepository<MyContext, Topic, int>
    {
        private readonly MyContext myContext;
        public TopicRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public int RegisterTopic(TopicVM topicVM)
        {
            Topic topic = new Topic();
            var checkTopicName = myContext.Topics.Where(x => x.TopicName == topicVM.TopicName).FirstOrDefault();
            topic.TopicName = topicVM.TopicName;

            if (checkTopicName != null)
            {
                return 2;
            }
            topic.TopicName = topicVM.TopicName;
            topic.TopicDesc = topicVM.TopicDesc;
            myContext.Topics.Add(topic);
            var result = myContext.SaveChanges();
            return result;

        }

        public IEnumerable<TopicVM> GetTopic(int topicId)
        {
            var getTopic = (from t in myContext.Topics
                              select new TopicVM()
                              {
                                  TopicId = t.TopicId,
                                  TopicName = t.TopicName,
                                  TopicDesc = t.TopicDesc,
                                  
                              }).Where(u => u.TopicId == topicId).ToList();

            return getTopic;
        }
    }
}
