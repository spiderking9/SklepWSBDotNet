using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep.Models.Sklep
{
    public class KoszykPozycja
    {
        public Towar Towar { get; set; }
        public int Ilosc { get; set; }
        public decimal KwotaRazem { get; set; }
    }
}