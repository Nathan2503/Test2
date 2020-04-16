using DalWebApiProjet.Models;
using DalWebApiProjet.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DalWebApiProjet.Services
{
    public class BiereApiService : ServiceBase<BiereApiService>, IBiere<int, BiereDalAPI>
    {
        private HttpClient _httpClient;
        public BiereApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:64807/api/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public List<BiereDalAPI> GetAll()
        {
            HttpResponseMessage message = _httpClient.GetAsync("Biere").Result;
            message.EnsureSuccessStatusCode();
            string json = message.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<BiereDalAPI>>(json);
        }

        public BiereDalAPI GetByName(string name)
        {
            HttpResponseMessage message = _httpClient.GetAsync("Biere?name=" + name).Result;
            message.EnsureSuccessStatusCode();
            string json = message.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<BiereDalAPI>(json);
        }

        public BiereDalAPI GetOne(int id)
        {
            HttpResponseMessage message = _httpClient.GetAsync("Biere/"+id).Result;
            message.EnsureSuccessStatusCode();
            string json = message.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<BiereDalAPI>(json);
        }
    }
}
