using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using ExamenPracticoRoblox.Models;

namespace ExamenPracticoRoblox.Controllers
{
    public class HomeController : Controller
    {
        private RobloxContext db = new RobloxContext();

        public ActionResult Index()
        {
            ViewBag.Avatares = db.Avatares.ToList();
            
            ViewBag.Items = db.Items.Include(i => i.Avatar).ToList();

            return View();
        }
    }
}