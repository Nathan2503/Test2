using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspProjet.Areas.Client.Models
{
    public class EditClient
    {
        public int clientId { get; set; }
        [Required]
        public string clientLogin { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string clientPwd { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("clientPwd")]
        public string verifPwd { get; set; }

    }
}