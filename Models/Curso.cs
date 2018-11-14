using System;
using System.Collections.Generic;

namespace EscuelaAspNetCore.Models
{
    public class Curso: ObjetoEscuelaBase
    {
        public TiposJornadas Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }  
        public List<Alumno> Alumnos { get; set; }
        public string Direccion { get; set; }
    }
}