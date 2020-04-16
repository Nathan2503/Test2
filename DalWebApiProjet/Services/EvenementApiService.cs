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
    public class EvenementApiService : ServiceBase<EvenementApiService>, IRepositories<int, EvenementDalAPI>
    {
        private HttpClient _httpClient;
        public EvenementApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:64807/api/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public List<EvenementDalAPI> GetAll()
        {
            HttpResponseMessage message = _httpClient.GetAsync("Evenement").Result;
            message.EnsureSuccessStatusCode();
            string json = message.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<EvenementDalAPI>>(json);
        }
    }
}
