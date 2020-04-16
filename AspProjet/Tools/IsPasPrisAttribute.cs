using DalWebApiProjet.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspProjet.Tools
{
    public class IsPasPrisAttribute : ValidationAttribute
    {
        private readonly List<string> _listeLogin;
        public IsPasPrisAttribute(): base("login déjà utilsé")
        {
            ClientApiService clientApi =  ClientApiService.GetLoadBalancer();
            _listeLogin=clientApi.GetAll().Select(p => p.clientLogin).ToList();
        }
        public override bool IsValid(object value)
        {
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
    }
}