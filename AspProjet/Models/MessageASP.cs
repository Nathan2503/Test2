using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProjet.Models
{
    public class MessageASP
    {
        public int messageAlertId { get; set; }
        public string messageContenu { get; set; }
        public DateTime messageDateDebut { get; set; }
        public DateTime messageDateFin { get; set; }
        public string nomBrasserie { get; set; }
    }
}