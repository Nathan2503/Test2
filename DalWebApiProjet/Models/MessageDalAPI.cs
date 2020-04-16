using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalWebApiProjet.Models
{
    public class MessageDalAPI
    {
        public int messageAlertId { get; set; }
        public string messageContenu { get; set; }
        public DateTime messageDateDebut { get; set; }
        public DateTime messageDateFin { get; set; }
        public string nomBrasserie { get; set; }
    }
}
