using Microsoft.AspNetCore.Mvc;
using EscuelaAspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EscuelaAspNetCore.Controllers
{
    public class AlumnoController : Controller
    {
        public IActionResult Index()
        {
            return View(_context.Alumnos);
        }
        [Route("/Alumno/DetalleAlumno/{alumnoId}")]
        public IActionResult DetalleAlumno(string alumnoId)
        {
            if (!string.IsNullOrEmpty(alumnoId))
            {
                var alumno = from al in _context.Alumnos
                                 where al.Id == alumnoId
                                 select al;
                return View(alumno.SingleOrDefault());
            }
            else
            {
                return View("Index", _context.Alumnos);
            }
        }

        private EscuelaContext _context;
        public AlumnoController(EscuelaContext context)
        {
            _context = context;
        }
    }
}