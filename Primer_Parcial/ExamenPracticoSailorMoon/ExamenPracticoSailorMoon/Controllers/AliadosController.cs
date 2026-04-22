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
    public class AliadosController : Controller
    {
        private SailorMoonContext db = new SailorMoonContext();

        // GET: Aliados
        public ActionResult Index()
        {
            var aliados = db.Aliados.Include(a => a.SailorSenshi);
            return View(aliados.ToList());
        }

        // GET: Aliados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aliado aliado = db.Aliados.Find(id);
            if (aliado == null)
            {
                return HttpNotFound();
            }
            return View(aliado);
        }

        // GET: Aliados/Create
        public ActionResult Create()
        {
            ViewBag.SailorSenshiId = new SelectList(db.SailorSenshis, "Id", "Nombre");
            return View();
        }

        // POST: Aliados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreAliado,Tipo,Edad,SailorSenshiId")] Aliado aliado)
        {
            if (ModelState.IsValid)
            {
                db.Aliados.Add(aliado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SailorSenshiId = new SelectList(db.SailorSenshis, "Id", "Nombre", aliado.SailorSenshiId);
            return View(aliado);
        }

        // GET: Aliados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aliado aliado = db.Aliados.Find(id);
            if (aliado == null)
            {
                return HttpNotFound();
            }
            ViewBag.SailorSenshiId = new SelectList(db.SailorSenshis, "Id", "Nombre", aliado.SailorSenshiId);
            return View(aliado);
        }

        // POST: Aliados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreAliado,Tipo,Edad,SailorSenshiId")] Aliado aliado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aliado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SailorSenshiId = new SelectList(db.SailorSenshis, "Id", "Nombre", aliado.SailorSenshiId);
            return View(aliado);
        }

        // GET: Aliados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aliado aliado = db.Aliados.Find(id);
            if (aliado == null)
            {
                return HttpNotFound();
            }
            return View(aliado);
        }

        // POST: Aliados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aliado aliado = db.Aliados.Find(id);
            db.Aliados.Remove(aliado);
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
