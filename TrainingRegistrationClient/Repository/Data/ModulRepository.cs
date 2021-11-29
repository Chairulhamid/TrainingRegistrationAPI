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
    public class ModulRepository : GeneralRepository<Modul, int>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;

        public ModulRepository(Address address, string request = "Moduls/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }
        public async Task<List<ModulVM>> GetModuls()
        {

            List<ModulVM> entities = new List<ModulVM>();

            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<ModulVM>>(apiResponse);
            }
            return entities;
        }

        public async Task<List<ModulVM>> GetIdModul(int id)
        {
            List<ModulVM> entities = new List<ModulVM>();

            using (var response = await httpClient.GetAsync(request + "GetModul/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<ModulVM>>(apiResponse);
            }
            return entities;
        }

        public HttpStatusCode Post(ModulVM entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address.link + request + "RegisterModul", content).Result;
            return result.StatusCode;
        }

        public async Task<List<ModulCourseVM>> GetModulCourse(int EmployeeId)
        {
            List<ModulCourseVM> entities = new List<ModulCourseVM>();

            using (var response = await httpClient.GetAsync(request + "GetModulCourse/" + EmployeeId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<ModulCourseVM>>(apiResponse);
            }
            return entities;
        }
    }
}
