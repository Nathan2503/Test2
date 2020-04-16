using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalWebApiProjet.Models
{
    public class OffreEmploiDalAPI
    {
        public int offreEmploiId { get; set; }
        public string fonction { get; set; }
        public string jobDescription { get; set; }
        public string diplomeMin { get; set; }
        public int experienceMin { get; set; }
        public string nomBrasserie { get; set; }
        public string mailRecrutement { get; set; }
    }
}
