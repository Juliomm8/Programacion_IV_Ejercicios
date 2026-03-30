using S1_P4_LAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S1_P4_LAB.Controllers
{
    public class ProductoController : Controller
    {
        public ActionResult Index()
        {
            var productos = new List<Producto>
            {
                new Producto { Id = 1, Nombre = "Celular", Precio = 125 },
                new Producto { Id = 2, Nombre = "Laptop", Precio = 1200 },
                new Producto { Id = 3, Nombre = "Tablet", Precio = 800 }
            };
            return View(productos);
        }
    }
}