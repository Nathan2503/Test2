using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace AspProjet.Tools
{
    public class IsEmailAttribute : ValidationAttribute
    {
        private readonly string _regexMail;
        public IsEmailAttribute():base("rentrez un email valide")
        {
            _regexMail = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        }
        public override bool IsValid(object value)
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
    }
}