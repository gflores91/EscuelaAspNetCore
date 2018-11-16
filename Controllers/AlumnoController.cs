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
        private EscuelaContext _context;
        public AlumnoController(EscuelaContext context)
        {
            _context = context;
        }
    }
}