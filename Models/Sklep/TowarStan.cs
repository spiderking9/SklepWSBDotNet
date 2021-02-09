using System;
using System.ComponentModel.DataAnnotations;

namespace Sklep.Models.Sklep
{
    public class TowarStan
    {
        [Key]
        public int IdStanMagazynowy { get; set; }
        public int Stan { get; set; }
        [Display(Name ="Data Dodania")]
        public DateTime DataDodania { get; set; }
        public int IdTowar { get; set; }
        public virtual Towar Towar { get; set; }

    }
}