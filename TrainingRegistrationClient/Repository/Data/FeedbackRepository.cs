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
    public class FeedbackRepository : GeneralRepository<Feedback, int>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;

        public FeedbackRepository(Address address, string request = "Feedbacks/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }

        public async Task<List<FeedbackVM>> GetFeedback()
        {

            List<FeedbackVM> entities = new List<FeedbackVM>();

            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<FeedbackVM>>(apiResponse);
            }
            return entities;
        }

        public async Task<List<FeedbackVM>> GetFeedback(int id)
        {
            List<FeedbackVM> entities = new List<FeedbackVM>();

            using (var response = await httpClient.GetAsync(request + "GetFeedback/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<FeedbackVM>>(apiResponse);
            }
            return entities;
        }

        public HttpStatusCode Post(FeedbackVM entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address.link + request + "InputFeedback", content).Result;
            return result.StatusCode;
        }


    }
}
