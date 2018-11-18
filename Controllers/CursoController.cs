using Microsoft.AspNetCore.Mvc;
using EscuelaAspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EscuelaAspNetCore.Controllers
{
    public class CursoController : Controller
    {
        public IActionResult Index()
        {
            return View(_context.Cursos);
        }
        [Route("/Curso/DetalleCurso/{cursoId}")]
        public IActionResult DetalleCurso(int cursoId)
        {
            if (cursoId >= 0)
            {
                var cursos = from cur in _context.Cursos
                             where cur.Id == cursoId
                             select cur;
                return View(cursos.SingleOrDefault());
            }
            else
            {
                return View("Index", _context.Cursos);
            }
        }

        public IActionResult CrearCurso()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearCurso(Curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(curso);
            }

        }

        private EscuelaContext _context;
        public CursoController(EscuelaContext context)
        {
            _context = context;
        }
    }
}