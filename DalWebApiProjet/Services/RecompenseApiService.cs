using DalWebApiProjet.Models;
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
    public class RecompenseApiService : ServiceBase<RecompenseApiService>
    {
        private HttpClient _httpClient;
        public RecompenseApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:64807/api/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public List<RecompenseDalAPI> GetAll(int id)
        {
            HttpResponseMessage message = _httpClient.GetAsync("Recompense/" + id).Result;
            message.EnsureSuccessStatusCode();
            string json = message.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<RecompenseDalAPI>>(json);
        }
    }
}
