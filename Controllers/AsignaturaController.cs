using Microsoft.AspNetCore.Mvc;
using EscuelaAspNetCore.Models;
using System;

namespace EscuelaAspNetCore.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            var asignatura = new Asignatura()
            {
                Nombre = "Programación"
            };

            return View(asignatura);
        }
    }
}