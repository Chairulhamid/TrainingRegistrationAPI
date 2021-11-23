using API.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TrainingRegistrationAPI.ViewModel;
using TrainingRegistrationClient.Base.Urls;

namespace TrainingRegistrationClient.Repository.Data
{
    public class LoginUserRepository : GeneralRepository<LoginUserVM, int>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        public LoginUserRepository(Address address, string request = "Users/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }

        public async Task<JWTokenVM> Auth(LoginUserVM loginUser)
        {
            JWTokenVM token = null;

            StringContent content = new StringContent(JsonConvert.SerializeObject(loginUser), Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(request + "LoginUser", content);

            string apiResponse = await result.Content.ReadAsStringAsync();
            token = JsonConvert.DeserializeObject<JWTokenVM>(apiResponse);

            return token;
        }

    }
}
