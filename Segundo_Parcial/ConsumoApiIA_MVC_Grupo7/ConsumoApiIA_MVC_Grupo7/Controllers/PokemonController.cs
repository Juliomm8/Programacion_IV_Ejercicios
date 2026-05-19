using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using ConsumoApiIA_MVC.Models;

namespace ConsumoApiIA_MVC.Controllers
{
    public class PokemonController : Controller
    {
        // GET: Cuando entras por primera vez a la página
        public ActionResult Index()
        {
            return View(); // Retorna la vista sin datos
        }

        // POST: Cuando el usuario escribe el nombre y le da al botón
        [HttpPost]
        public async Task<ActionResult> Index(string nombrePokemon)
        {
            // Si el usuario no escribió nada, le devolvemos a la misma página
            if (string.IsNullOrWhiteSpace(nombrePokemon))
            {
                ViewBag.Error = "Por favor, ingresa un nombre o número.";
                return View();
            }

            PokemonInfo pokemon = null;

            // La PokeAPI requiere que todo esté en minúsculas y sin espacios
            string busqueda = nombrePokemon.ToLower().Trim();
            string url = $"https://pokeapi.co/api/v2/pokemon/{busqueda}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    pokemon = JsonConvert.DeserializeObject<PokemonInfo>(jsonString);
                }
                else
                {
                    // Si el Pokémon no existe (error 404)
                    ViewBag.Error = "No se encontró el Pokémon. Verifica el nombre o número.";
                }
            }

            // Enviamos el pokemon a la vista (si no se encontró, será null)
            return View(pokemon);
        }
    }
}