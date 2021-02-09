using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sklep.Models.Sklep
{
    public class Towar
    {
        [Key]
        public int IdTowar { get; set; }
        [Required(ErrorMessage ="Nazwa towaru jest wymagana")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Opis towaru jest wymagany")]

        public string Opis { get; set; }
        [Required(ErrorMessage = "Cena towaru jest wymagana")]
        [DataType(DataType.Currency, ErrorMessage = "Wartość w polu cena jest nieprawidlowa, musi byc liczba")]
        public decimal Cena { get; set; }
        [Display(Name ="Vip Towar")]
        public bool VipTowar { get; set; }
        [Display(Name = "Towar Promocyjny")]
        public bool TowarPromocyjny { get; set; }
        public virtual ICollection<TowarZdjecia> TowarZdjecia { get; set; }
        public virtual ICollection<TowarStan> TowarStan { get; set; }



    }
}