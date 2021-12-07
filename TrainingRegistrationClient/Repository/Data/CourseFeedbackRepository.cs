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
    public class CourseFeedbackRepository : GeneralRepository<CourseFeedback, int>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;

        public CourseFeedbackRepository(Address address, string request = "CourseFeedbacks/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }

        public async Task<List<CourseFeedbackVM>> GetFeedback()
        {

            List<CourseFeedbackVM> entities = new List<CourseFeedbackVM>();

            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<CourseFeedbackVM>>(apiResponse);
            }
            return entities;
        }

        public async Task<List<CourseFeedbackVM>> GetFeedback(int id)
        {
            List<CourseFeedbackVM> entities = new List<CourseFeedbackVM>();

            using (var response = await httpClient.GetAsync(request + "GetFeedback/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<CourseFeedbackVM>>(apiResponse);
            }
            return entities;
        }

        public HttpStatusCode Post(CourseFeedbackVM entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address.link + request + "InputCourseFeedback", content).Result;
            return result.StatusCode;
        }


    }
}
