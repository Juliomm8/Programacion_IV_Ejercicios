using ApiEscuela.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiEscuela.Controllers
{
    public class FacultadesController : ApiController
    {
        public EscuelaContext db = new EscuelaContext();

        // GET: api/Estudiantes
        public IHttpActionResult Get() => Ok(db.Estudiantes.ToList());

        // GET: api/Estudiantes/5
        public IHttpActionResult Get(int id)
        {
            var e = db.Estudiantes.Find(id);
            return e == null ? (IHttpActionResult)NotFound() : Ok(e);

        }

        // POST: api/estudiantes
        public IHttpActionResult Post(Estudiante est)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            db.Estudiantes.Add(est);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = est.EstudianteId }, est);
        }

        // PUT: api/estudiantes/5
        public IHttpActionResult Put(int id, Estudiante est)
        {
            var e = db.Estudiantes.Find(id);
            if (e == null) return NotFound();
            e.Nombre = est.Nombre;
            e.Edad = est.Edad;
            db.SaveChanges();
            return Ok(e);
        }

        // DELETE: api/estudiantes/5
        public IHttpActionResult Delete(int id)
        {
            var e = db.Estudiantes.Find(id);
            if (e == null) return NotFound();
            db.Estudiantes.Remove(e);
            db.SaveChanges();
            return Ok("Estudiante eliminado");
        }
    }
}