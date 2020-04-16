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
    public class EmploiApiService : ServiceBase<EmploiApiService>, IRepositories<int, OffreEmploiDalAPI>
    {
        private HttpClient _httpClient;
        public EmploiApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:64807/api/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public List<OffreEmploiDalAPI> GetAll()
        {
            HttpResponseMessage message = _httpClient.GetAsync("Emploi").Result;
            message.EnsureSuccessStatusCode();
            string json = message.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<OffreEmploiDalAPI>>(json);
        }
        public OffreEmploiDalAPI GetOne(int id)
        {
            HttpResponseMessage message = _httpClient.GetAsync("Emploi/" + id).Result;
            message.EnsureSuccessStatusCode();
            string json = message.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<OffreEmploiDalAPI>(json);
        }
    }
}
