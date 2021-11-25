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
    public class PaymentRepository : GeneralRepository<Payment, int>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;

        public PaymentRepository(Address address, string request = "Payments/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }
        public HttpStatusCode Post(PaymentVM entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address.link + request + "RegisterPay", content).Result;
            return result.StatusCode;
        }
    }
}
