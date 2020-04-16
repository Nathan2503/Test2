using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalWebApiProjet.Models
{
    public class BiereDalAPI
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
    }
}
