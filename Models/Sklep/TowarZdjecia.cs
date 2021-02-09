using System.ComponentModel.DataAnnotations;

namespace Sklep.Models.Sklep
{
    public class TowarZdjecia
    {
        [Key]
        public int IdTowarZdjecie { get; set; }
        public string Url { get; set; }
        public int IdTowar { get; set; }
        public virtual Towar Towar { get; set; }
    }
}