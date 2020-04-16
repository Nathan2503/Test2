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
    public class AccueilApiService : ServiceBase<AccueilApiService>, IRepositories<int,AccueilDalAPI>
    {
        private HttpClient _httpClient;
        public AccueilApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:64807/api/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public  List<AccueilDalAPI> GetAll()
        {
            HttpResponseMessage message = _httpClient.GetAsync("Accueil").Result;
            message.EnsureSuccessStatusCode();
            string json = message.Content.ReadAsStringAsync().Result;
            List<AccueilDalAPI> la = JsonConvert.DeserializeObject<List<AccueilDalAPI>>(json);
            if (la.Count()>0)
            {
                return JsonConvert.DeserializeObject<List<AccueilDalAPI>>(json);
            }
            else
            {
                AccueilDalAPI accueilASP = new AccueilDalAPI();
                accueilASP.brasserieId = 1;
                accueilASP.brasseriePresentation = "Bienvenu sur notre site web";
                accueilASP.heureOuverture ="09:30";
                accueilASP.heureFermeture = "17:00";
                accueilASP.horraireDateDebut = DateTime.Now;
                accueilASP.horraireDateFin = DateTime.Now;
                accueilASP.nomBrasserie = "Brouwerij Technofutur";
                List<AccueilDalAPI> test = new List<AccueilDalAPI>();
                test.Add(accueilASP);
                return test;
            }
           
        }
    }
}
