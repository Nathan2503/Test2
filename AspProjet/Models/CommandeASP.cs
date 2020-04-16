using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProjet.Models
{
    public class CommandeASP
    {
        public int commandeId { get; set; }
        public DateTime commandeDate { get; set; }
        public int commandeQuantite { get; set; }
        public string clientLogin { get; set; }
        public string biereNom { get; set; }
        public decimal bierePrix { get; set; }
    }
}