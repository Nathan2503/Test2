﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProjet.Models
{
    public class EvenementASP
    {
        public int eventId { get; set; }
        public DateTime eventDateDebut { get; set; }
        public DateTime eventDateFin { get; set; }
        public string eventDescription { get; set; }
        public int brasserieId { get; set; }
    }
}