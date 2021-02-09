using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep.Models.ViewModels
{
    public class TowarViewModel
    {
        public int IdTowar { get; set; }
        public string NazwaTowaru { get; set; }
        public string Opis { get; set; }
        public decimal Cena { get; set; }
        public bool VipTowar { get; set; }
        public bool TowarPromocyjny { get; set; }
        public IEnumerable<string> Zdjecia { get; set; }
        public decimal AktualnyStan { get; set; }
    }
}