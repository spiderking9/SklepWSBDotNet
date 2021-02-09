using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sklep.Models.CMS
{
    public class Aktualnosc
    {
        [Key]
        public int IdAktualnosc { get; set; }

        [MaxLength(30,ErrorMessage ="Maksymalna ilosc znakow to 30")]
        [Display(Name ="Tytuł")]
        [Required(ErrorMessage ="Prosze wpisac tytuł aktualności")]
        public string Tytul { get; set; }

        [Display(Name = "Treść Aktualności")]
        [Column(TypeName ="nvarchar(MAX)")]
        public string TrescAktualnosci { get; set; }

        [Display(Name ="Pozycje")]
        [Required(ErrorMessage ="Wpisz pozycję wyświetlania")]
        public int PozycjeWyswietlania { get; set; }

    }
}