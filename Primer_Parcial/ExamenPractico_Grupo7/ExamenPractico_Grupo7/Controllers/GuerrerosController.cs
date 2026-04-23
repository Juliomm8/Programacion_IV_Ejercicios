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
    public class GuerrerosController : Controller
    {
        private DragonBallContext db = new DragonBallContext();

        // GET: Guerreros
        public ActionResult Index()
        {
            return View(db.Guerreros.ToList());
        }

        // GET: Guerreros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guerrero guerrero = db.Guerreros.Find(id);
            if (guerrero == null)
            {
                return HttpNotFound();
            }
            return View(guerrero);
        }

        // GET: Guerreros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Guerreros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Raza,NivelPoder,Transformacion")] Guerrero guerrero)
        {
            if (ModelState.IsValid)
            {
                db.Guerreros.Add(guerrero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guerrero);
        }

        // GET: Guerreros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guerrero guerrero = db.Guerreros.Find(id);
            if (guerrero == null)
            {
                return HttpNotFound();
            }
            return View(guerrero);
        }

        // POST: Guerreros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Raza,NivelPoder,Transformacion")] Guerrero guerrero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guerrero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guerrero);
        }

        // GET: Guerreros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guerrero guerrero = db.Guerreros.Find(id);
            if (guerrero == null)
            {
                return HttpNotFound();
            }
            return View(guerrero);
        }

        // POST: Guerreros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Guerrero guerrero = db.Guerreros.Find(id);
            db.Guerreros.Remove(guerrero);
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
