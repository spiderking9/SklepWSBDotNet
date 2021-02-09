using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sklep.Models.Sklep
{
    public class ZamowieniePozycja
    {
        [Key]
        public int IdZamowieniePozycja { get; set; }
        public int IdTowar { get; set; }

        public virtual Towar Towar { get; set; }
        public int Ilosc { get; set; }
        public decimal Cena { get; set; }
        public decimal Wartosc { get; set; }
        public int IdZamowienie { get; set; }
        public Zamowienie Zamowienie { get; set; }

    }
}