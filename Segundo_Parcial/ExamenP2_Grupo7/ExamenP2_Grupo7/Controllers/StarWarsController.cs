using StarWarsApiWebApp.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StarWarsApiWebApp.Controllers
{
    public class StarWarsController : Controller
    {
        private readonly StarWarsApiService _service = new StarWarsApiService();

        public async Task<ActionResult> Index()
        {
            var personajes = await _service.GetListAsync();
            return View(personajes.results);
        }

        public async Task<ActionResult> Details(string name)
        {
            var personaje = await _service.GetByNameAsync(name);
            return View(personaje);
        }
    }
}