﻿using Newtonsoft.Json;
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
    public class UserRepository : GeneralRepository<User, int>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;

        public UserRepository(Address address, string request = "Users/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }

        public async Task<List<RegisterUserVM>> GetUsers()
        {

            List<RegisterUserVM> entities = new List<RegisterUserVM>();

            using (var response = await httpClient.GetAsync(request + "Profile/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<RegisterUserVM>>(apiResponse);
            }
            return entities;
        }

        public async Task<List<RegisterUserVM>> GetUser(int id)
        {
            List<RegisterUserVM> entities = new List<RegisterUserVM>();

            using (var response = await httpClient.GetAsync(request + "GetIdProfile/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<RegisterUserVM>>(apiResponse);
            }
            return entities;
        }

        public HttpStatusCode Post(RegisterUserVM entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address.link + request + "RegisterUser", content).Result;
            return result.StatusCode;
        }



    }
}
