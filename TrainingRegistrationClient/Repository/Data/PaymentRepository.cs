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
        ///AMBIL DATA PAY YANG SUDAH DI BAYAR/ TOLAK
        public async Task<List<PaymentStatusVM>> GetPayALL()
        {

            List<PaymentStatusVM> entities = new List<PaymentStatusVM>();

            using (var response = await httpClient.GetAsync(request + "GetPayALL/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<PaymentStatusVM>>(apiResponse);
            }
            return entities;
        }
        ///AMBIL DATA PAY YANG SUDAH DI BAYAR/ TOLAK BERDASARKAN ID
        public async Task<List<PaymentStatusVM>> GetIdALLStatus(int UserId)
        {
            List<PaymentStatusVM> entities = new List<PaymentStatusVM>();

            using (var response = await httpClient.GetAsync(request + "GetIdALLStatus/" + UserId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<PaymentStatusVM>>(apiResponse);
            }
            return entities;
        }
        ///AMBIL Lesson course YANG SUDAH DI BAYAR/ TOLAK BERDASARKAN ID
        public async Task<List<TrainingCourseVM>> GetLessonCourse(int UserId)
        {
            List<TrainingCourseVM> entities = new List<TrainingCourseVM>();

            using (var response = await httpClient.GetAsync(request + "GetLessonCourse/" + UserId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<TrainingCourseVM>>(apiResponse);
            }
            return entities;
        }
        ///AMBIL DATA PAY YANG BELLUM DI BAYAR/ TOLAK 
        public async Task<List<PaymentStatusVM>> GetPayStatus()
        {

            List<PaymentStatusVM> entities = new List<PaymentStatusVM>();

            using (var response = await httpClient.GetAsync(request + "GetPayStatus/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<PaymentStatusVM>>(apiResponse);
            }
            return entities;
        }
        ///AMBIL DATA PAY YANG BELUM DI BAYAR/ TOLAK BERDASARKAN ID
        public async Task<List<PaymentStatusVM>> GetIdPayStatus(int paymentId)
        {
            List<PaymentStatusVM> entities = new List<PaymentStatusVM>();

            using (var response = await httpClient.GetAsync(request + "GetIdPayStatus/" + paymentId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<PaymentStatusVM>>(apiResponse);
            }
            return entities;
        }

        public async Task<List<PaymentStatusVM>> GetPayStatusId(int id)
        {
            List<PaymentStatusVM> entities = new List<PaymentStatusVM>();

            using (var response = await httpClient.GetAsync(request + "GetPayStatusId/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<PaymentStatusVM>>(apiResponse);
            }
            return entities;
        }
    }
}
