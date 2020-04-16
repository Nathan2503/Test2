using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProjet.Models
{
    public class BiereASP
    {
        public int biereId { get; set; }
        public string biereNom { get; set; }
        public decimal pourcentageAlcool { get; set; }
        public string biereImage { get; set; }
        public string biereDescription { get; set; }
        public string biereRobe { get; set; }
        public decimal bierePrix { get; set; }
        public string nomBrasserie { get; set; }
        public string typeBiereNom { get; set; }
        public List<string> recompenseNom { get; set; }
    }
}