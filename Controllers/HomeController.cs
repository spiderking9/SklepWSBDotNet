using Sklep.Models;
using Sklep.Models.CMS;
using Sklep.Models.Sklep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sklep.Controllers
{
    public class HomeController : Controller
    {
        private SklepContext db = new SklepContext();
        public ActionResult _Aktualnosci() 
        {
            List<Aktualnosc> listAktualnosci = db.aktualnosci.OrderBy(x=>x.PozycjeWyswietlania).ToList();
            return PartialView(listAktualnosci);
        }
        public ActionResult _TowaryPromocyjne()
        {
            List<Towar> towaryPromocyjne = db.Towar.Where(x => x.TowarPromocyjny==true).Take(4).ToList();

            ViewBag.Message = "Your contact page.";

            return PartialView(towaryPromocyjne);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}