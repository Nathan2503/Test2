using AspProjet.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProjet.Models
{
    public class AccueilASP
    {
        public int brasserieId { get; set; }
        public string nomBrasserie { get; set; }
        public string brasseriePresentation { get; set; }
        public DateTime horraireDateDebut { get; set; }
        public DateTime horraireDateFin { get; set; }
        public Temps heureOuverture { get; set; }
        public Temps heureFermeture { get; set; }
    }
}