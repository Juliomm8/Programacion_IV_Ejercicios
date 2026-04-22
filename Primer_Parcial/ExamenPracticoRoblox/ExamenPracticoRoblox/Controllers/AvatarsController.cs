using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamenPracticoRoblox.Models;

namespace ExamenPracticoRoblox.Controllers
{
    public class AvatarsController : Controller
    {
        private RobloxContext db = new RobloxContext();

        // GET: Avatars
        public ActionResult Index()
        {
            return View(db.Avatares.ToList());
        }

        // GET: Avatars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avatar avatar = db.Avatares.Find(id);
            if (avatar == null)
            {
                return HttpNotFound();
            }
            return View(avatar);
        }

        // GET: Avatars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Avatars/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreUsuario,Juego,NivelExperiencia,HabilidadEspecial")] Avatar avatar)
        {
            if (ModelState.IsValid)
            {
                db.Avatares.Add(avatar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(avatar);
        }

        // GET: Avatars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avatar avatar = db.Avatares.Find(id);
            if (avatar == null)
            {
                return HttpNotFound();
            }
            return View(avatar);
        }

        // POST: Avatars/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreUsuario,Juego,NivelExperiencia,HabilidadEspecial")] Avatar avatar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avatar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(avatar);
        }

        // GET: Avatars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Avatar avatar = db.Avatares.Find(id);
            if (avatar == null)
            {
                return HttpNotFound();
            }
            return View(avatar);
        }

        // POST: Avatars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Avatar avatar = db.Avatares.Find(id);
            db.Avatares.Remove(avatar);
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
