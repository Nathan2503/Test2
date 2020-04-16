using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProjet.Models
{
    public class OffreEmploiASP
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