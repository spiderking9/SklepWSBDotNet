using Microsoft.AspNet.Identity;
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
    public class SampleData : DropCreateDatabaseIfModelChanges<SklepContext>
    {
        protected override void Seed(SklepContext context)
        {
            var aktualnosci = new List<Aktualnosc>
            {
                new Aktualnosc{Tytul="Marek Grechuta",TrescAktualnosci="sdfgdfgdfg dfgdgdd",PozycjeWyswietlania=1},
                new Aktualnosc{Tytul="Kucyk",TrescAktualnosci="sf sdfsd fgdfgdfg dfgdgdd",PozycjeWyswietlania=3},
                new Aktualnosc{Tytul="Kartofel",TrescAktualnosci="s a sdas  121 2 dfgdfgdfg dfgdgdd",PozycjeWyswietlania=4},
                new Aktualnosc{Tytul="Winda",TrescAktualnosci="sda  332 131 fgdfgdfg dfgdgdd",PozycjeWyswietlania=5},
                new Aktualnosc{Tytul="Bocian",TrescAktualnosci="sdfgd asas as231 31 fgdfg dfgdgdd",PozycjeWyswietlania=7}
            };
            foreach (var a in aktualnosci)
            {
                context.aktualnosci.Add(a);
            }

            var towar = new List<Towar>
            {
                new Towar{Nazwa="Buty",Cena=134,TowarPromocyjny=true,Opis="schodzone",VipTowar=false},
                new Towar{Nazwa="Rekawiczki",Cena=14,TowarPromocyjny=true,Opis="skora",VipTowar=false},
                new Towar{Nazwa="Spodnie",Cena=80,TowarPromocyjny=false,Opis="schodzone",VipTowar=false},
                new Towar{Nazwa="Myszka",Cena=50,TowarPromocyjny=false,Opis="komputerowy gadget",VipTowar=true},
                new Towar{Nazwa="Monitor",Cena=1500,TowarPromocyjny=false,Opis="komputerowy gadget",VipTowar=true},
                new Towar{Nazwa="Małpka",Cena=3000,TowarPromocyjny=true,Opis="pluszak",VipTowar=false},
                new Towar{Nazwa="Kot",Cena=100,TowarPromocyjny=true,Opis="plusz",VipTowar=false},
                new Towar{Nazwa="Pies",Cena=580,TowarPromocyjny=false,Opis="sama glowa",VipTowar=true},
                new Towar{Nazwa="Wiewiórka",Cena=10,TowarPromocyjny=false,Opis="obrazek",VipTowar=true},
                new Towar{Nazwa="Batman",Cena=1,TowarPromocyjny=true,Opis="uciekac",VipTowar=false}
            };

            foreach (var t in towar)
            {
                context.Towar.Add(t);
            }

            var zdjecia = new List<TowarZdjecia>
            {
                new TowarZdjecia{Url="/Content/Zdjecia/1.jpg",IdTowar=1},
                new TowarZdjecia{Url="/Content/Zdjecia/2.jpg",IdTowar=2},
                new TowarZdjecia{Url="/Content/Zdjecia/3.jpg",IdTowar=3},
                new TowarZdjecia{Url="/Content/Zdjecia/4.jpg",IdTowar=4},
                new TowarZdjecia{Url="/Content/Zdjecia/5.jpg",IdTowar=5},
                new TowarZdjecia{Url="/Content/Zdjecia/1.jpg",IdTowar=6},
                new TowarZdjecia{Url="/Content/Zdjecia/2.jpg",IdTowar=7},
                new TowarZdjecia{Url="/Content/Zdjecia/3.jpg",IdTowar=8},
                new TowarZdjecia{Url="/Content/Zdjecia/4.jpg",IdTowar=9},
                new TowarZdjecia{Url="/Content/Zdjecia/5.jpg",IdTowar=10},
                new TowarZdjecia{Url="/Content/Zdjecia/1.jpg",IdTowar=1},
                new TowarZdjecia{Url="/Content/Zdjecia/2.jpg",IdTowar=2},
                new TowarZdjecia{Url="/Content/Zdjecia/3.jpg",IdTowar=3},
                new TowarZdjecia{Url="/Content/Zdjecia/4.jpg",IdTowar=4},
                new TowarZdjecia{Url="/Content/Zdjecia/5.jpg",IdTowar=5},
                new TowarZdjecia{Url="/Content/Zdjecia/1.jpg",IdTowar=6},
                new TowarZdjecia{Url="/Content/Zdjecia/2.jpg",IdTowar=7},
                new TowarZdjecia{Url="/Content/Zdjecia/3.jpg",IdTowar=8},
                new TowarZdjecia{Url="/Content/Zdjecia/4.jpg",IdTowar=9},
                new TowarZdjecia{Url="/Content/Zdjecia/5.jpg",IdTowar=10},
            };
            context.TowarZdjecia.AddRange(zdjecia);
            var ogloszenia = new List<Ogloszenie>
            {
                new Ogloszenie{Tytul="Sprzedam czarny traktor", TrescOgloszenia="nieaktualne",},
                new Ogloszenie{Tytul="Wynajme ogrodzenie", TrescOgloszenia="bardzo drogi sprzet"},
                new Ogloszenie{Tytul="Oglaszam sie prezydentem", TrescOgloszenia="i premierem"},
                new Ogloszenie{Tytul="Kupie", TrescOgloszenia="kupie kupie kupie kupie kupie kupie sprzedam"},
                new Ogloszenie{Tytul="Skradziono czapke nike ma byc", TrescOgloszenia="jak nie bedzie dyskoteka bedzie, ale rozgoniona"},
            };
            context.Ogloszenia.AddRange(ogloszenia);
            var stanyMagazynowe = new List<TowarStan>
            {
                new TowarStan{Stan=23,DataDodania=DateTime.Now,IdTowar=1},
                new TowarStan{Stan=3,DataDodania=DateTime.Now,IdTowar=2},
                new TowarStan{Stan=5,DataDodania=DateTime.Now,IdTowar=3},
                new TowarStan{Stan=123,DataDodania=DateTime.Now,IdTowar=4},
                new TowarStan{Stan=33,DataDodania=DateTime.Now,IdTowar=5},
                new TowarStan{Stan=0,DataDodania=DateTime.Now,IdTowar=6},
                new TowarStan{Stan=55,DataDodania=DateTime.Now,IdTowar=7},
                new TowarStan{Stan=34343,DataDodania=DateTime.Now,IdTowar=8},
                new TowarStan{Stan=1,DataDodania=DateTime.Now,IdTowar=9},
                new TowarStan{Stan=100,DataDodania=DateTime.Now,IdTowar=10},
                new TowarStan{Stan=50,DataDodania=DateTime.Now,IdTowar=1},
                new TowarStan{Stan=30,DataDodania=DateTime.Now,IdTowar=2}
            };
            context.TowarStan.AddRange(stanyMagazynowe);

            #region Role
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleMenager = new RoleManager<IdentityRole>(roleStore);
            var rolaAdmin = new IdentityRole { Name = "admin" };
            roleMenager.Create(rolaAdmin);
            var rolaHandlowiec =new IdentityRole { Name = "handlowiec" };
            roleMenager.Create(rolaHandlowiec);

            context.SaveChanges();
            #endregion
            #region KontoAdmin
            var userStore = new UserStore<ApplicationUser>(context);
            var userMenager = new UserManager<ApplicationUser>(userStore);
            string haslo = "admin123";
            string email = "admin@op.pl";
            ApplicationUser uzytkownik = new ApplicationUser()
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };
            if (userMenager.Create(uzytkownik, haslo).Succeeded)
            {
                userMenager.AddToRole(uzytkownik.Id,"admin");
                Handlowiec handlowiec = new Handlowiec()
                {
                    Email = uzytkownik.Email,
                    Imie = "Admin",
                    Nazwisko = "NazwiskoAdmin",
                    UserId = uzytkownik.Id
                };
                context.Handlowcy.Add(handlowiec);
                context.SaveChanges();
            }

            #endregion
        }
    }
}