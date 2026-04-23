using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using ExamenPractico_Grupo7.Models;

namespace ExamenPractico_Grupo7.Controllers
{
    public class HomeController : Controller
    {
        private DragonBallContext db = new DragonBallContext();

        public ActionResult Index()
        {
           
            ViewBag.Guerreros = db.Guerreros.ToList();

           
            ViewBag.Tecnicas = db.Tecnicas.Include(t => t.Guerrero).ToList();

            return View();
        }
    }
}