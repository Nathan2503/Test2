using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProjet.Models
{
    public class ContactASP
    {
        public int contactId { get; set; }
        public string adRue { get; set; }
        public string adNumero { get; set; }
        public string adVille { get; set; }
        public string adCodePostal { get; set; }
        public string telephone { get; set; }
        public string nomBrasserie { get; set; }
        public string mailInfon { get; set; }
    }
}