using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamenPracticoMarioBros.Models;

namespace ExamenPracticoMarioBros.Controllers
{
    public class PersonajesController : Controller
    {
        private MarioBrosContext db = new MarioBrosContext();

        // GET: Personajes
        public ActionResult Index()
        {
            return View(db.Personajes.ToList());
        }

        // GET: Personajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personaje personaje = db.Personajes.Find(id);
            if (personaje == null)
            {
                return HttpNotFound();
            }
            return View(personaje);
        }

        // GET: Personajes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personajes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Reino,NivelPoder,HabilidadEspecial")] Personaje personaje)
        {
            if (ModelState.IsValid)
            {
                db.Personajes.Add(personaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personaje);
        }

        // GET: Personajes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personaje personaje = db.Personajes.Find(id);
            if (personaje == null)
            {
                return HttpNotFound();
            }
            return View(personaje);
        }

        // POST: Personajes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Reino,NivelPoder,HabilidadEspecial")] Personaje personaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personaje);
        }

        // GET: Personajes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personaje personaje = db.Personajes.Find(id);
            if (personaje == null)
            {
                return HttpNotFound();
            }
            return View(personaje);
        }

        // POST: Personajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personaje personaje = db.Personajes.Find(id);
            db.Personajes.Remove(personaje);
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
