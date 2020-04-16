using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalWebApiProjet.Models
{
    public class AccueilDalAPI
    {
        public int brasserieId { get; set; }
        public string nomBrasserie { get; set; }
        public string brasseriePresentation { get; set; }
        public DateTime horraireDateDebut { get; set; }
        public DateTime horraireDateFin { get; set; }
        public string heureOuverture { get; set; }
        public string heureFermeture { get; set; }
    }
}
