using Microsoft.AspNet.Identity;
using PagedList;
using Sklep.Models;
using Sklep.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sklep.Controllers
{
    public class SklepController : Controller
    {
        private SklepContext db = new SklepContext();
        [Authorize(Roles = "Admin, Handlowcy")]
        public ActionResult Index(int page=1,int sortowanie=1)
        {
            int pageSize = 3;
            var towary = (
                from t in db.Towar
                select new TowarViewModel
                {
                    IdTowar=t.IdTowar,
                    NazwaTowaru=t.Nazwa,
                    Cena=t.Cena,
                    Opis=t.Opis,
                    VipTowar=t.VipTowar,
                    TowarPromocyjny=t.TowarPromocyjny,
                    Zdjecia=t.TowarZdjecia.Select(x=>x.Url),
                    AktualnyStan=t.TowarStan.Sum(z=>z.Stan)
                }
            ).ToList();
            int liczbaZamowionych = 0;
            foreach (var t in towary)
            {
                if (db.ZamowieniePozycje.Any(x=>x.IdTowar==t.IdTowar))
                {
                    liczbaZamowionych =
                        (
                        from z in db.ZamowieniePozycje
                        where z.IdTowar == t.IdTowar
                        select z.Ilosc
                        ).Sum();
                    t.AktualnyStan = t.AktualnyStan - liczbaZamowionych;
                }
            }
            string userId = User.Identity.GetUserId();

            bool handlowiecVip = (from h in db.Handlowcy
                                  where h.UserId == userId
                                  select h.HandlowiecVip).FirstOrDefault();

            if (!handlowiecVip)
                towary = towary.Where(x => x.VipTowar == false).ToList();

            List<SelectListItem> sortowanieLista = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text="Nazwa od A do Z",
                    Value="1",
                    Selected=(sortowanie==1?true:false)
                },
                new SelectListItem
                {
                    Text="Nazwa od Z do A",
                    Value="2",
                    Selected=(sortowanie==2?true:false)
                },
                new SelectListItem
                {
                    Text="Ceny rosnace",
                    Value="3",
                    Selected=(sortowanie==3?true:false)
                },
                new SelectListItem
                {
                    Text="Ceny malejace",
                    Value="4",
                    Selected=(sortowanie==4?true:false)
                }
            };
            ViewBag.Sortowanie = sortowanie;
            ViewBag.SortowanieLista = sortowanieLista;
            switch (sortowanie)
            {
                case 1:
                    towary = towary.OrderBy(x=>x.NazwaTowaru).ToList();
                    break;
                case 2:
                    towary = towary.OrderByDescending(x => x.NazwaTowaru).ToList();
                    break;
                case 3:
                    towary = towary.OrderBy(x => x.Cena).ToList();
                    break;
                case 4:
                    towary = towary.OrderByDescending(x => x.Cena).ToList();
                    break;
                default:
                    break;
            }
            return View(towary.ToPagedList(page,pageSize));
        }
        public ActionResult Szczegoly(int id)
        {
            TowarViewModel towar = (
                from t in db.Towar
                where t.IdTowar == id
                select new TowarViewModel
                {
                    IdTowar = t.IdTowar,
                    NazwaTowaru = t.Nazwa,
                    Cena = t.Cena,
                    Opis = t.Opis,
                    VipTowar = t.VipTowar,
                    TowarPromocyjny = t.TowarPromocyjny,
                    Zdjecia = t.TowarZdjecia.Select(x => x.Url),
                    AktualnyStan = t.TowarStan.Sum(z => z.Stan)
                }
                ).FirstOrDefault();
            if (towar == null) HttpNotFound();

            int liczbaZamowionych = 0;

            if (db.ZamowieniePozycje.Any(x => x.IdTowar == towar.IdTowar))
            {
                liczbaZamowionych =
                    (
                    from z in db.ZamowieniePozycje
                    where z.IdTowar == towar.IdTowar
                    select z.Ilosc
                    ).Sum();
                towar.AktualnyStan = towar.AktualnyStan - liczbaZamowionych;
            }
            return View(towar);
        }
    }
}