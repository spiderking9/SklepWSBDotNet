using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sklep.Models.Sklep
{
    public class Handlowiec
    {
        [Key]
        public int IdHandlowca { get; set; }
        [Required(ErrorMessage ="Imie jest wymagane")]
        [Display(Name ="Imię")]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string Nazwisko { get; set; }
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage ="Zły format adresu email")]
        public string Email { get; set; }
        public string UserId { get; set; }
        public bool HandlowiecVip { get; set; }


    }
}