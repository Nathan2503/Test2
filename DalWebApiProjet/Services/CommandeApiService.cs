using DalWebApiProjet.Helper;
using DalWebApiProjet.Models;
using DalWebApiProjet.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DalWebApiProjet.Services
{
    public class CommandeApiService : ServiceBase<CommandeApiService>, IRepositories<int, CommandeDalAPI>
    {
        private HttpClient _httpClient;
        public CommandeApiService() 
        {
            var credentials = new NetworkCredential(outils.Part1, outils.Parts2);
            var handler = new HttpClientHandler { Credentials = credentials };
            _httpClient = new HttpClient(handler);
            if (HttpContext.Current != null)
            {
                string hostport = HttpContext.Current.Request.Url.Authority;
                _httpClient.DefaultRequestHeaders.Add("Host", hostport);
            }
            _httpClient.BaseAddress = new Uri("http://localhost:64807/api/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public List<CommandeDalAPI> GetAll()
        {
            HttpResponseMessage message = _httpClient.GetAsync("Command").Result;
            message.EnsureSuccessStatusCode();
            string json = message.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<CommandeDalAPI>>(json);
        }
        public CommandeDalAPI GetOne(int id)
        {
            HttpResponseMessage message = _httpClient.GetAsync("Command/" + id).Result;
            message.EnsureSuccessStatusCode();
            string json = message.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<CommandeDalAPI>(json);
        }
        public List<CommandeDalAPI> GetByLogin(string login)
        {
            HttpResponseMessage message = _httpClient.GetAsync("Command?login=" + login).Result;
            message.EnsureSuccessStatusCode();
            string json = message.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<CommandeDalAPI>>(json);
        }
        public void Create(CommandeDalAPI commande)
        {
            string jsonContent = JsonConvert.SerializeObject(commande);
            HttpContent httpcontent = new StringContent(jsonContent);
            httpcontent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
            HttpResponseMessage message = _httpClient.PostAsync("Command", httpcontent).Result;
            message.EnsureSuccessStatusCode();
        }
    }
}
