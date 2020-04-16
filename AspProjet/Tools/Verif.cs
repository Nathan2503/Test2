using AspProjet.Models;
using DalWebApiProjet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace AspProjet.Tools
{
    public static  class Verif
    {
        private  static   string _regexMail = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public static bool IsEmail(string value)
        {
            if (value != null)
            {
                string mail = value.ToString();
                return Regex.IsMatch(mail, _regexMail);
            }
            else
            {
                return false;
            }
        }
        public static bool IsLoginLibre(string value)
        {
            List<string> _listeLogin = new List<string>();
            ClientApiService clientApi =  ClientApiService.GetLoadBalancer();
            _listeLogin = clientApi.GetAll().Select(p => p.clientLogin).ToList();
            bool test = true;
            if (value != null)
            {
                string login = value.ToString();
                if (_listeLogin.Count() > 0)
                {
                    for (int i = 0; i < _listeLogin.Count(); i++)
                    {
                        if (_listeLogin[i].ToLower() == login.ToLower())
                        {
                            test = false;
                            i = _listeLogin.Count() + 1;
                        }
                    }
                }
                else
                {
                    test = true;
                }

            }
            else
            {
                test = false;
            }
            return test;
        }
        public static bool IsMajeur(DateTime value)
        {
            bool age = false;
            if (value != null)
            {
                DateTime test = (DateTime)value;
                if (DateTime.Now.Year - test.Year >= 18)
                {
                    age = true;
                }
            }
            return age;
        }
        public static bool IsLoginValid(string value)
        {
            if (value != null)
            {
                if (IsEmail(value) && IsLoginLibre(value))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }
        public static bool IsNumber(string commande)
        {
            if (commande != null)
            {
                int n;
                bool test = int.TryParse(commande, out n);
                if ( test == true && n>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
           
        }
        public static bool IsBiereValid(string nom)
        {
            if (nom != null)
            {
                List<string> lb = new List<string>();
                BiereApiService biereApi =  BiereApiService.GetLoadBalancer();
                lb = biereApi.GetAll().Select(p => p.biereNom).ToList();
                if(lb!=null && lb.Count > 0)
                {
                    if (lb.Contains(nom))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
               
            }
            else
            {
                return false;
            }
           
        }
        public static string GetFrDate(this DateTime dateTime)
        {
            IFormatProvider culture4 = new System.Globalization.CultureInfo("fr-FR", true);
            string[] tabdates = dateTime.GetDateTimeFormats(culture4);
            return tabdates[5];
        }
        //public static List<Boulette> rattraperBoulette(List<BiereASP> bieres)
        //{
        //    List<int> listeId = new List<int>();
        //    List<Boulette> lb = new List<Boulette>();
        //    foreach (BiereASP item in bieres)
        //    {
        //        if (listeId.Count > 0)
        //        {
        //            if (listeId.Contains(item.biereId))
        //            {
        //                lb.Where(p => p.biereId == item.biereId).FirstOrDefault().recompenseNom.Add(item.recompenseNom);
        //            }
        //            else
        //            {
        //                listeId.Add(item.biereId);
        //                lb.Add(item.GetBoulette());
        //            }
        //        }
        //        else
        //        {
        //            listeId.Add(item.biereId);
        //            lb.Add(item.GetBoulette());
        //        }
        //    }
        //    return lb;


        //}
        public static string GetPLusCourt(this string st)
        {
            if (st.Length > 50)
            {
                string test = st.Substring(0,50);
                test = test + "...";
                return test;
            }
            else
            {
                return st;
            }
        }
    }
}