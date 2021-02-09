using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sklep.Models.CMS
{
    public class Ogloszenie
    {
        [Key]
        public int IdOgloszenia { get; set; }

        [MaxLength(30, ErrorMessage = "Maksymalna ilosc znakow to 30")]
        [Display(Name = "Tytuł Ogłoszzenia")]
        [Required(ErrorMessage = "Prosze wpisac tytuł aktualności")]
        public string Tytul { get; set; }

        [Display(Name = "Treść Ogloszenia")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string TrescOgloszenia { get; set; }
    }
}