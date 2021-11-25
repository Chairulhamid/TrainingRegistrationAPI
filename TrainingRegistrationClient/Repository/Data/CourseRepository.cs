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
    public class CourseRepository : GeneralRepository<Course, int>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;

        public CourseRepository(Address address, string request = "Courses/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }
        public async Task<List<CourseVM>> GetCourses()
        {

            List<CourseVM> entities = new List<CourseVM>();

            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<CourseVM>>(apiResponse);
            }
            return entities;
        }

        public async Task<List<CourseVM>> GetIdCourse(int id)
        {
            List<CourseVM> entities = new List<CourseVM>();

            using (var response = await httpClient.GetAsync(request + "GetCourse/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<CourseVM>>(apiResponse);
            }
            return entities;
        }
        public async Task<List<CourseVM>> GetCourse()
        {
            List<CourseVM> entities = new List<CourseVM>();

            using (var response = await httpClient.GetAsync(request + "GetCourse/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<CourseVM>>(apiResponse);
            }
            return entities;
        }

        public HttpStatusCode Post(CourseVM entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address.link + request + "RegisterCourse", content).Result;
            return result.StatusCode;
        }


    }
}
