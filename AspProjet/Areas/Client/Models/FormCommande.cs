using AspProjet.Models;
using AspProjet.Tools;
using DalWebApiProjet.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspProjet.Areas.Client.Models
{
    public class FormCommande
    {
        private List<BiereASP> listBiere = new List<BiereASP>();
        [Required]
        public int commandeQuantite { get; set; }
        [Required]
        public string biereNom { get; set; }
        public string clientLogin { get; set; } 
        public List<BiereASP> ListBiere
        {
            get
            {
                return listBiere;
            }

            set
            {
                listBiere = value;
            }
        }
        public FormCommande()
        {
            BiereApiService biereApiService =  BiereApiService.GetLoadBalancer();
            listBiere = biereApiService.GetAll().Select(p => p.GetBiereASP()).ToList();
        }
        
    }
}