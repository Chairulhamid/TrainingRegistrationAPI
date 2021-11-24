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

        public async Task<List<TopicVM>> GetTopics()
        {

            List<TopicVM> entities = new List<TopicVM>();

            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<TopicVM>>(apiResponse);
            }
            return entities;
        }

        public async Task<List<TopicVM>> GetTopic(int id)
        {
            List<TopicVM> entities = new List<TopicVM>();

            using (var response = await httpClient.GetAsync(request + "GetTopic/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<TopicVM>>(apiResponse);
            }
            return entities;
        }

        public HttpStatusCode Post(TopicVM entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address.link + request + "RegisterTopic", content).Result;
            return result.StatusCode;
        }



    }
}
