using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sklep.Models;
using Sklep.Models.CMS;

namespace Sklep.Controllers.PanelCMS
{
    public class AktualnoscsController : Controller
    {
        private SklepContext db = new SklepContext();

        // GET: Aktualnoscs
        public ActionResult Index()
        {
            return View(db.aktualnosci.ToList());
        }

        // GET: Aktualnoscs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aktualnosc aktualnosc = db.aktualnosci.Find(id);
            if (aktualnosc == null)
            {
                return HttpNotFound();
            }
            return View(aktualnosc);
        }

        // GET: Aktualnoscs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aktualnoscs/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAktualnosc,Tytul,TrescAktualnosci,PozycjeWyswietlania")] Aktualnosc aktualnosc)
        {
            if (ModelState.IsValid)
            {
                db.aktualnosci.Add(aktualnosc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aktualnosc);
        }

        // GET: Aktualnoscs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aktualnosc aktualnosc = db.aktualnosci.Find(id);
            if (aktualnosc == null)
            {
                return HttpNotFound();
            }
            return View(aktualnosc);
        }

        // POST: Aktualnoscs/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAktualnosc,Tytul,TrescAktualnosci,PozycjeWyswietlania")] Aktualnosc aktualnosc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aktualnosc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aktualnosc);
        }

        // GET: Aktualnoscs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aktualnosc aktualnosc = db.aktualnosci.Find(id);
            if (aktualnosc == null)
            {
                return HttpNotFound();
            }
            return View(aktualnosc);
        }

        // POST: Aktualnoscs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aktualnosc aktualnosc = db.aktualnosci.Find(id);
            db.aktualnosci.Remove(aktualnosc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
