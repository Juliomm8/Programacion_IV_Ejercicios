using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamenPracticoSailorMoon.Models;

namespace ExamenPracticoSailorMoon.Controllers
{
    public class SailorSenshisController : Controller
    {
        private SailorMoonContext db = new SailorMoonContext();

        // GET: SailorSenshis
        public ActionResult Index()
        {
            return View(db.SailorSenshis.ToList());
        }

        // GET: SailorSenshis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SailorSenshi sailorSenshi = db.SailorSenshis.Find(id);
            if (sailorSenshi == null)
            {
                return HttpNotFound();
            }
            return View(sailorSenshi);
        }

        // GET: SailorSenshis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SailorSenshis/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Planeta,NivelPoder,HabilidadEspecial")] SailorSenshi sailorSenshi)
        {
            if (ModelState.IsValid)
            {
                db.SailorSenshis.Add(sailorSenshi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sailorSenshi);
        }

        // GET: SailorSenshis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SailorSenshi sailorSenshi = db.SailorSenshis.Find(id);
            if (sailorSenshi == null)
            {
                return HttpNotFound();
            }
            return View(sailorSenshi);
        }

        // POST: SailorSenshis/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Planeta,NivelPoder,HabilidadEspecial")] SailorSenshi sailorSenshi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sailorSenshi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sailorSenshi);
        }

        // GET: SailorSenshis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SailorSenshi sailorSenshi = db.SailorSenshis.Find(id);
            if (sailorSenshi == null)
            {
                return HttpNotFound();
            }
            return View(sailorSenshi);
        }

        // POST: SailorSenshis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SailorSenshi sailorSenshi = db.SailorSenshis.Find(id);
            db.SailorSenshis.Remove(sailorSenshi);
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
