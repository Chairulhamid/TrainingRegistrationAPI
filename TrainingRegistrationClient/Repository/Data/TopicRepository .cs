using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Models;
using TrainingRegistrationAPI.ViewModel;
using TrainingRegistrationClient.Base.Urls;

namespace TrainingRegistrationClient.Repository.Data
{
    public class TopicRepository : GeneralRepository<Topic, int>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;

        public TopicRepository(Address address, string request = "Topics/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }

        public async Task<List<Topic>> GetTopics()
        {

            List<Topic> entities = new List<Topic>();

            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<Topic>>(apiResponse);
            }
            return entities;
        }

        public async Task<List<Topic>> GetTopic(int id)
        {
            List<Topic> entities = new List<Topic>();

            using (var response = await httpClient.GetAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<Topic>>(apiResponse);
            }
            return entities;
        }

        public new HttpStatusCode Post(Topic entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address.link + request + "RegisterTopic", content).Result;
            return result.StatusCode;
        }



    }
}
