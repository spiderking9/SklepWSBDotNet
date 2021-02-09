using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sklep.Models.CMS
{
    public class Pozycja
    {
        [Key]
        public int IdPozycja { get; set; }
        public string Nazwa { get; set; }
    }
}