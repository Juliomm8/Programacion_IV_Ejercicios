using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using ExamenPracticoSailorMoon.Models;

namespace ExamenPracticoSailorMoon.Controllers
{
    public class HomeController : Controller
    {
        private SailorMoonContext db = new SailorMoonContext();

        public ActionResult Index()
        {
            // Guardamos las listas en la "mochila" del ViewBag
            ViewBag.Senshis = db.SailorSenshis.ToList();
            ViewBag.Aliados = db.Aliados.Include(a => a.SailorSenshi).ToList();

            // Mandamos la vista vacía, el ViewBag viaja solo
            return View();
        }
    }
}