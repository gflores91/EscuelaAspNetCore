using Microsoft.AspNetCore.Mvc;
using EscuelaAspNetCore.Models;
using System;

namespace EscuelaAspNetCore.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            var escuela = new Escuela()
            {
                Nombre = "Exodus Academy",
                Direccion = "Angol, Concepción, Chile",
                AnioFundacion = 2018
            };
            return View(escuela);
        }
    }
}