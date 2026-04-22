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
    public class EnemigosController : Controller
    {
        private MarioBrosContext db = new MarioBrosContext();

        // GET: Enemigos
        public ActionResult Index()
        {
            var enemigos = db.Enemigos.Include(e => e.Personaje);
            return View(enemigos.ToList());
        }

        // GET: Enemigos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enemigo enemigo = db.Enemigos.Find(id);
            if (enemigo == null)
            {
                return HttpNotFound();
            }
            return View(enemigo);
        }

        // GET: Enemigos/Create
        public ActionResult Create()
        {
            ViewBag.PersonajeId = new SelectList(db.Personajes, "Id", "Nombre");
            return View();
        }

        // POST: Enemigos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreEnemigo,Tipo,NivelDificultad,PersonajeId")] Enemigo enemigo)
        {
            if (ModelState.IsValid)
            {
                db.Enemigos.Add(enemigo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonajeId = new SelectList(db.Personajes, "Id", "Nombre", enemigo.PersonajeId);
            return View(enemigo);
        }

        // GET: Enemigos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enemigo enemigo = db.Enemigos.Find(id);
            if (enemigo == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonajeId = new SelectList(db.Personajes, "Id", "Nombre", enemigo.PersonajeId);
            return View(enemigo);
        }

        // POST: Enemigos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreEnemigo,Tipo,NivelDificultad,PersonajeId")] Enemigo enemigo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enemigo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonajeId = new SelectList(db.Personajes, "Id", "Nombre", enemigo.PersonajeId);
            return View(enemigo);
        }

        // GET: Enemigos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enemigo enemigo = db.Enemigos.Find(id);
            if (enemigo == null)
            {
                return HttpNotFound();
            }
            return View(enemigo);
        }

        // POST: Enemigos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enemigo enemigo = db.Enemigos.Find(id);
            db.Enemigos.Remove(enemigo);
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
