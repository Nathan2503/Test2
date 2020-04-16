using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspProjet.Tools
{
    public class IsMajeurAttribute : ValidationAttribute
    {
        private readonly int  _majeur;
        public IsMajeurAttribute(int test1,string test) : base(test)
        {
            _majeur = test1;
        }
        public  override bool IsValid(object value)
        {
            //bool age=false;
            if (value != null)
            {
                DateTime test = (DateTime)value;
                if (DateTime.Now.Year - test.Year >= _majeur)
                {

                    return true;
                }
            }
            //var errorMessage = FormatErrorMessage(validationContext.DisplayName);
            return false;
        }

    }
}