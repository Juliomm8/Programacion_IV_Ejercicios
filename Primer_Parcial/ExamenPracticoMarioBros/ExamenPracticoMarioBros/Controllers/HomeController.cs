using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using ExamenPracticoMarioBros.Models;

namespace ExamenPracticoMarioBros.Controllers
{
    public class HomeController : Controller
    {
        private MarioBrosContext db = new MarioBrosContext();

        public ActionResult Index()
        {
            ViewBag.Personajes = db.Personajes.ToList();
            ViewBag.Enemigos = db.Enemigos.Include(e => e.Personaje).ToList();

            return View();
        }
    }
}