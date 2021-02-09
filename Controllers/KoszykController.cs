using Microsoft.AspNet.Identity;
using Sklep.Models;
using Sklep.Models.Sklep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sklep.Controllers
{
    public class KoszykController : Controller
    {
        private SklepContext db=new SklepContext();
        private const string KoszykSesjaKlucz = "koszykSesja";
        public ActionResult Index()
        {
            List<KoszykPozycja> pozycjeKoszyka = new List<KoszykPozycja>();
            if (Session[KoszykSesjaKlucz]!=null)
            {
                pozycjeKoszyka = Session[KoszykSesjaKlucz] as List<KoszykPozycja>;
            }
            return View(pozycjeKoszyka);
        }
        [HttpPost]
        public ActionResult DodajPozycjeDoKoszyka(int idTowar,int iloscTowaru)
        {
            List<KoszykPozycja> pozycjeKoszyka = new List<KoszykPozycja>();
            if (Session[KoszykSesjaKlucz] != null)
            {
                pozycjeKoszyka = Session[KoszykSesjaKlucz] as List<KoszykPozycja>;
            }
            if (pozycjeKoszyka.Any(x => x.Towar.IdTowar == idTowar))
            {
                KoszykPozycja pozycjaWKoszyku = pozycjeKoszyka.Find(w => w.Towar.IdTowar == idTowar);
                int stanTowary = pozycjaWKoszyku.Towar.TowarStan.Sum(f => f.Stan);
                if (stanTowary >= (pozycjaWKoszyku.Ilosc+iloscTowaru))
                {
                    pozycjaWKoszyku.Ilosc += iloscTowaru;
                    pozycjaWKoszyku.KwotaRazem = pozycjaWKoszyku.Ilosc * pozycjaWKoszyku.Towar.Cena;
                }
            }
            else
            {
                Towar towar = db.Towar.FirstOrDefault(x => x.IdTowar == idTowar);
                if (towar == null) return HttpNotFound();
                int stanTowary = towar.TowarStan.Sum(x => x.Stan);
                if (stanTowary >= iloscTowaru)
                {
                    KoszykPozycja nowaPozycja = new KoszykPozycja()
                    {
                        Ilosc = iloscTowaru,
                        KwotaRazem = towar.Cena * iloscTowaru,
                        Towar = towar
                    };
                    pozycjeKoszyka.Add(nowaPozycja);
                }
            }
            Session[KoszykSesjaKlucz] = pozycjeKoszyka;
            return RedirectToAction("Index");
        }

        public ActionResult UsunPozycjeZKoszyka(int idTowar)
        {
            List<KoszykPozycja> pozycjeKoszyka = new List<KoszykPozycja>();
            if (Session[KoszykSesjaKlucz] != null)
            {
                pozycjeKoszyka = Session[KoszykSesjaKlucz] as List<KoszykPozycja>;
            }
            pozycjeKoszyka = pozycjeKoszyka.Where(x => x.Towar.IdTowar != idTowar).ToList();
            Session[KoszykSesjaKlucz] = pozycjeKoszyka;

            return RedirectToAction("Index");
        }
        public ActionResult DaneZamowienia()
        {
            string userId = User.Identity.GetUserId();
            Handlowiec handlowiec = (
                from h in db.Handlowcy
                where h.UserId == userId
                select h).FirstOrDefault();
            Zamowienie zamowienie = new Zamowienie();
            zamowienie.AdresEmail = handlowiec.Email;
            zamowienie.Imie = handlowiec.Imie;
            zamowienie.Nazwisko = handlowiec.Nazwisko;

            return View(zamowienie);
        }
        [HttpPost]
        public ActionResult DaneZamowienia(Zamowienie zamowienie)
        {
            List<KoszykPozycja> pozycjeKoszyka = new List<KoszykPozycja>();
            if (ModelState.IsValid)
            {
                pozycjeKoszyka = Session[KoszykSesjaKlucz] as List<KoszykPozycja>;
            }
            List<ZamowieniePozycja> pozycjeZamowienia = new List<ZamowieniePozycja>();

            foreach (var pozycja in pozycjeKoszyka)
            {
                pozycjeZamowienia.Add(new ZamowieniePozycja
                {
                    Cena = pozycja.Towar.Cena,
                    IdTowar = pozycja.Towar.IdTowar,
                    Ilosc = pozycja.Ilosc,
                    Wartosc = pozycja.Ilosc * pozycja.Towar.Cena
                });
            }
            string userId = User.Identity.GetUserId();
            Handlowiec handlowiec = (
                from h in db.Handlowcy
                where h.UserId == userId
                select h
                ).FirstOrDefault();
            zamowienie.DataZamowienia = DateTime.Now;
            zamowienie.Idhandlowiec = handlowiec.IdHandlowca;
            zamowienie.ZamowieniePozycja = pozycjeZamowienia;
            db.Zamowienia.Add(zamowienie);
            db.SaveChanges();
            Session[KoszykSesjaKlucz] = null;

            return RedirectToAction("PotwierdzenieZamowienia");
        }

        public ActionResult PotwierdzenieZamowienia()
        {
            return View();
        }

        public ActionResult _MiniKoszyk()
        {
            List<KoszykPozycja> pozycjeKoszyka = new List<KoszykPozycja>();
            if (ModelState.IsValid)
            {
                pozycjeKoszyka = Session[KoszykSesjaKlucz] as List<KoszykPozycja>;
            }
            decimal wartoscKoszyka = 0;
            if (pozycjeKoszyka!=null && pozycjeKoszyka.Count>0)
            {
                wartoscKoszyka = pozycjeKoszyka.Sum(x => x.KwotaRazem);
            }
            ViewBag.WartoscKoszyka = wartoscKoszyka;
            return PartialView();
        }
    }
}