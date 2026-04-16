using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionEscolarMVC.Models;

namespace GestionEscolarMVC.Controllers
{
    public class UniversidadesController : Controller
    {
        private EscuelaDbContext db = new EscuelaDbContext();

        // GET: Universidades
        public ActionResult Index()
        {
            return View(db.Universidades.ToList());
        }

        // GET: Universidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universidad universidad = db.Universidades.Find(id);
            if (universidad == null)
            {
                return HttpNotFound();
            }
            return View(universidad);
        }

        // GET: Universidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Universidades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UniversidadId,Nombre,Ubicacion,Rector,AñoFundacion")] Universidad universidad)
        {
            if (ModelState.IsValid)
            {
                db.Universidades.Add(universidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(universidad);
        }

        // GET: Universidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universidad universidad = db.Universidades.Find(id);
            if (universidad == null)
            {
                return HttpNotFound();
            }
            return View(universidad);
        }

        // POST: Universidades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UniversidadId,Nombre,Ubicacion,Rector,AñoFundacion")] Universidad universidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(universidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(universidad);
        }

        // GET: Universidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universidad universidad = db.Universidades.Find(id);
            if (universidad == null)
            {
                return HttpNotFound();
            }
            return View(universidad);
        }

        // POST: Universidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Universidad universidad = db.Universidades.Find(id);
            db.Universidades.Remove(universidad);
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
