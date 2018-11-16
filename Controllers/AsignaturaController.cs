using Microsoft.AspNetCore.Mvc;
using EscuelaAspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EscuelaAspNetCore.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            return View(_context.Asignaturas);
        }

        private EscuelaContext _context;
        public AsignaturaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}