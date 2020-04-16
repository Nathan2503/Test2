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
    public class ClientApiService : ServiceBase<ClientApiService>, IClient<int, ClientDalAPI>
    {
        private HttpClient _httpClient;
        public ClientApiService()
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
        public void Create(ClientDalAPI parametre)
        {
            string jsonContent = JsonConvert.SerializeObject(parametre);
            HttpContent httpContent = new StringContent(jsonContent);
            httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
            HttpResponseMessage message = _httpClient.PostAsync("Client", httpContent).Result;
            message.EnsureSuccessStatusCode();
        }

        public void Delete(int id)
        {
            HttpResponseMessage message = _httpClient.DeleteAsync("Client/" + id).Result;
            message.EnsureSuccessStatusCode();
        }

        public List<ClientDalAPI> GetAll()
        {
            HttpResponseMessage message = _httpClient.GetAsync("Client").Result;
            message.EnsureSuccessStatusCode();
            string json = message.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<ClientDalAPI>>(json);
        }

        public ClientDalAPI GetOne(int id)
        {
            HttpResponseMessage message = _httpClient.GetAsync("Client/" + id).Result;
            message.EnsureSuccessStatusCode();
            string json = message.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<ClientDalAPI>(json);
        }

        public void Update(ClientDalAPI parametre)
        {
            string jsonContent = JsonConvert.SerializeObject(parametre);
            HttpContent httpContent = new StringContent(jsonContent);
            httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
            HttpResponseMessage message = _httpClient.PutAsync("Client", httpContent).Result;
            message.EnsureSuccessStatusCode();
        }
        public int? Connection(string login, string pwd)
        {
            HttpResponseMessage message = _httpClient.GetAsync("Client?login=" + login + "&pwd=" + pwd).Result;
            message.EnsureSuccessStatusCode();
            string json = message.Content.ReadAsStringAsync().Result;
            int id;
            bool test;
            test = int.TryParse(json, out id);
            if (test == true)
            {
                return id;
            }
            else
            {
                return null;
            }
        }
    }
}
