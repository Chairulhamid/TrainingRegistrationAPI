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
    public class EmployeeRepository : GeneralRepository<Employee, int>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;

        public EmployeeRepository(Address address, string request = "Employees/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }

        public async Task<List<RegisterEmpVM>> GetEmployees()
        {

            List<RegisterEmpVM> entities = new List<RegisterEmpVM>();

            using (var response = await httpClient.GetAsync(request + "Profile/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<RegisterEmpVM>>(apiResponse);
            }
            return entities;
        }

        public async Task<List<RegisterEmpVM>> GetEmp(int id)
        {
            List<RegisterEmpVM> entities = new List<RegisterEmpVM>();

            using (var response = await httpClient.GetAsync(request + "Profile/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<RegisterEmpVM>>(apiResponse);
            }
            return entities;
        }

        public HttpStatusCode Post(RegisterEmpVM entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address.link + request + "Register", content).Result;
            return result.StatusCode;
        }



    }
}
