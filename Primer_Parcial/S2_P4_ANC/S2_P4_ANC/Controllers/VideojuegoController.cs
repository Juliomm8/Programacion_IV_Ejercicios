using Microsoft.AspNetCore.Mvc;
using S2_P4_ANC.Models;

namespace S2_P4_ANC.Controllers
{
    public class VideojuegoController : Controller
    {
        public static List<Videojuego> videojuegos = new List<Videojuego>
        {
            new Videojuego { id = 1, titulo = "The Legend of Zelda: Breath of the Wild", plataforma = "Nintendo Switch", precio = 59.99m },
            new Videojuego { id = 2, titulo = "God of War", plataforma = "PlayStation 4", precio = 39.99m },
            new Videojuego { id = 3, titulo = "Counter Strike", plataforma = "Mobile", precio = 10.5m }, 
            new Videojuego { id = 4, titulo = "Cyberpunk 2077", plataforma = "PC", precio = 29.99m }
        };
        public IActionResult Index()
        {
            return View(videojuegos);
        }
    }
}
