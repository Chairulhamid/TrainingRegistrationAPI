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
        public HttpStatusCode Post(CourseVM entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address.link + request + "RegisterCourse", content).Result;
            return result.StatusCode;
        }
        //GET ALL STATUS == APPROVED <<INI  UNTUK DI HALAMAN USER YANG BAGIAN AKAN DI JUAL>>
        public async Task<List<CourseVM>> GetAprovedCourse()
        {

            List<CourseVM> entities = new List<CourseVM>();

            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<CourseVM>>(apiResponse);
            }
            return entities;
        }
        //GET STATUS == WAITING
        public async Task<List<CourseVM>> GetWaitingCourse()
        {

            List<CourseVM> entities = new List<CourseVM>();

            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<CourseVM>>(apiResponse);
            }
            return entities;
        }
        //GET STATUS != WAITING
        public async Task<List<CourseVM>> GetActCourse()
        {

            List<CourseVM> entities = new List<CourseVM>();

            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<CourseVM>>(apiResponse);
            }
            return entities;
        }
        //GET STATUS == WAITING BY ID
        public async Task<List<CourseVM>> GetWaitIdCourse(int id)
        {
            List<CourseVM> entities = new List<CourseVM>();

            using (var response = await httpClient.GetAsync(request + "GetWaitIdCourse/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<CourseVM>>(apiResponse);
            }
            return entities;
        }
        //GET != WAITING BY ID <<INI HANYA UNTUK TABEL DI ADMIN>>
        public async Task<List<CourseVM>> GetActIdCourse(int id)
        {
            List<CourseVM> entities = new List<CourseVM>();

            using (var response = await httpClient.GetAsync(request + "GetActIdCourse/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<CourseVM>>(apiResponse);
            }
            return entities;
        }
        //GET == APPROVED BY ID <<INI  UNTUK AKAN DITAMPILKAN DI HALAMAN USER>>
        public async Task<List<CourseVM>> GetApvdIdCourse(int id)
        {
            List<CourseVM> entities = new List<CourseVM>();

            using (var response = await httpClient.GetAsync(request + "GetApvdIdCourse/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<CourseVM>>(apiResponse);
            }
            return entities;
        }
       /* public async Task<List<CourseVM>> GetCourse()
        {
            List<CourseVM> entities = new List<CourseVM>();

            using (var response = await httpClient.GetAsync(request + "GetCourse/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<CourseVM>>(apiResponse);
            }
            return entities;
        }*/

    


    }
}
