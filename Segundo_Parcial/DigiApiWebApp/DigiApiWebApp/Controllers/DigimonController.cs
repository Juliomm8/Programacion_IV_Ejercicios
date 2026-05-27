using DigiApiWebApp.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DigiApiWebApp.Controllers
{
    public class DigimonController : Controller
    {
        private readonly DigiApiService _service = new DigiApiService();

        public async Task<ActionResult> Index()
        {
            var digimons = await _service.GetListAsync();
            return View(digimons.content);
        }

        public async Task<ActionResult> Details(string name)
        {
            var digimon = await _service.GetByNameAsync(name);
            return View(digimon);
        }
    }
}