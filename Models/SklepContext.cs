using Microsoft.AspNet.Identity.EntityFramework;
using Sklep.Models.CMS;
using Sklep.Models.Sklep;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sklep.Models
{
    public class SklepContext : IdentityDbContext<ApplicationUser>
    {
        public SklepContext() : base("name=SklepContext") { }
        public static SklepContext Create()
        {
            return new SklepContext();
        }
        public DbSet<Aktualnosc> aktualnosci { get; set; }
        public DbSet<Ogloszenie> Ogloszenia { get; set; }
        public DbSet<Pozycja> Pozycje { get; set; }
        public DbSet<Towar> Towar { get; set; }
        public DbSet<TowarStan> TowarStan { get; set; }
        public DbSet<TowarZdjecia> TowarZdjecia { get; set; }
        public DbSet<Handlowiec> Handlowcy { get; set; }

        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<ZamowieniePozycja> ZamowieniePozycje { get; set; }




    }
}