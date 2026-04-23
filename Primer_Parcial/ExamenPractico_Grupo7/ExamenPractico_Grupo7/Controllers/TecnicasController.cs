using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamenPractico_Grupo7.Models;

namespace ExamenPractico_Grupo7.Controllers
{
    public class TecnicasController : Controller
    {
        private DragonBallContext db = new DragonBallContext();

        // GET: Tecnicas
        public ActionResult Index()
        {
            var tecnicas = db.Tecnicas.Include(t => t.Guerrero);
            return View(tecnicas.ToList());
        }

        // GET: Tecnicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnica tecnica = db.Tecnicas.Find(id);
            if (tecnica == null)
            {
                return HttpNotFound();
            }
            return View(tecnica);
        }

        // GET: Tecnicas/Create
        public ActionResult Create()
        {
            ViewBag.GuerreroId = new SelectList(db.Guerreros, "Id", "Nombre");
            return View();
        }

        // POST: Tecnicas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreTecnica,Tipo,NivelDano,GuerreroId")] Tecnica tecnica)
        {
            if (ModelState.IsValid)
            {
                db.Tecnicas.Add(tecnica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GuerreroId = new SelectList(db.Guerreros, "Id", "Nombre", tecnica.GuerreroId);
            return View(tecnica);
        }

        // GET: Tecnicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnica tecnica = db.Tecnicas.Find(id);
            if (tecnica == null)
            {
                return HttpNotFound();
            }
            ViewBag.GuerreroId = new SelectList(db.Guerreros, "Id", "Nombre", tecnica.GuerreroId);
            return View(tecnica);
        }

        // POST: Tecnicas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreTecnica,Tipo,NivelDano,GuerreroId")] Tecnica tecnica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tecnica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GuerreroId = new SelectList(db.Guerreros, "Id", "Nombre", tecnica.GuerreroId);
            return View(tecnica);
        }

        // GET: Tecnicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnica tecnica = db.Tecnicas.Find(id);
            if (tecnica == null)
            {
                return HttpNotFound();
            }
            return View(tecnica);
        }

        // POST: Tecnicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tecnica tecnica = db.Tecnicas.Find(id);
            db.Tecnicas.Remove(tecnica);
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
