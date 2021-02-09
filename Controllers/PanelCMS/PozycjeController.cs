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
    public class PozycjeController : Controller
    {
        private SklepContext db = new SklepContext();

        // GET: Pozycje
        public ActionResult Index()
        {
            return View(db.Pozycje.ToList());
        }

        // GET: Pozycje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pozycja pozycja = db.Pozycje.Find(id);
            if (pozycja == null)
            {
                return HttpNotFound();
            }
            return View(pozycja);
        }

        // GET: Pozycje/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pozycje/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPozycja,Nazwa")] Pozycja pozycja)
        {
            if (ModelState.IsValid)
            {
                db.Pozycje.Add(pozycja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pozycja);
        }

        // GET: Pozycje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pozycja pozycja = db.Pozycje.Find(id);
            if (pozycja == null)
            {
                return HttpNotFound();
            }
            return View(pozycja);
        }

        // POST: Pozycje/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPozycja,Nazwa")] Pozycja pozycja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pozycja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pozycja);
        }

        // GET: Pozycje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pozycja pozycja = db.Pozycje.Find(id);
            if (pozycja == null)
            {
                return HttpNotFound();
            }
            return View(pozycja);
        }

        // POST: Pozycje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pozycja pozycja = db.Pozycje.Find(id);
            db.Pozycje.Remove(pozycja);
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
