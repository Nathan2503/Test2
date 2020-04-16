using AspProjet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProjet.Tools
{
    public class Utils
    {
        public static ClientASP Client
        {
            get
            {
                return (ClientASP)HttpContext.Current.Session["Client"];
            }
            set
            {
                HttpContext.Current.Session["Client"] = value;
            }
        }
    }
}