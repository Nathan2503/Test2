using AspProjet.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspProjet.Models
{
    public class FormCreateClient 
    {
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (DateTime.Now.Year - clientDateNaissance.Year < 18)
        //    {
        //        yield return new ValidationResult("Vous devez être majeur pour vous inscrire",new[] {"clientDateNaissance" });
        //    }
        //    //throw new NotImplementedException();
        //}
        [Required]
        public string clientPrenom { get; set; }
        [Required]
        public string clientNom { get; set; }
        [IsMajeur(18,"Vous devez être majeur pour vous inscrire")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime clientDateNaissance { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [IsEmail]
        [IsPasPris]
        public string  clientLogin { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string clientPwd { get; set; } 
        [Required]
        [Compare("clientPwd")]
        [DataType(DataType.Password)]
        public string verifPwd { get; set; }

      
    }
}