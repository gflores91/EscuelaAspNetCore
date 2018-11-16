using Microsoft.AspNetCore.Mvc;
using EscuelaAspNetCore.Models;
using System;
using System.Linq;

namespace EscuelaAspNetCore.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            var escuela = _context.Escuelas.FirstOrDefault();
            return View(escuela);
        }

        private EscuelaContext _context;
        public EscuelaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}