using Microsoft.AspNetCore.Mvc;
using EscuelaAspNetCore.Models;
using System;
using System.Collections.Generic;

namespace EscuelaAspNetCore.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            var listaAsignaturas = new List<Asignatura>(){
                new Asignatura{Nombre = "Matematicas"},
                new Asignatura{Nombre = "Lenguaje"},
                new Asignatura{Nombre = "Ciencias Naturales"},
                new Asignatura{Nombre = "Manualidades"},
                new Asignatura{Nombre = "Tecnología"}
            };

            return View(listaAsignaturas);
        }
    }
}