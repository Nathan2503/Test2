using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProjet.Tools
{
    public class Temps
    {
        private int _Heure;
        private int _Min;

        public int Heure
        {
            get
            {
                return _Heure;
            }

            set
            {
                _Heure = value;
            }
        }

        public int Min
        {
            get
            {
                return _Min;
            }

            set
            {
                _Min = value;
            }
        }
        public string AfficherHeureMin
        {
            get
            {
                
                if (Min == 0)
                {
                    return Heure.ToString();
                }
                else
                {
                    string temps;
                    temps = Heure + " : " + Min;
                    return temps;
                }
                
            }
        }
        public void GetHeureMin(string temps)
        {
            string h;
            string m;
            h = temps.Substring(0, 2);
            m = temps.Substring(3, 2);
            bool test = int.TryParse(m, out _Min);
            bool test2 = int.TryParse(h, out _Heure);
        }
        public Temps(string temps)
        {
            GetHeureMin(temps);
        }
    }
}