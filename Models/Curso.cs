using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EscuelaAspNetCore.Models
{
    public class Curso: ObjetoEscuelaBase
    {
        [Required]
        public override string Nombre { get; set; }
        public TiposJornadas Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }  
        public List<Alumno> Alumnos { get; set; }
        public string Direccion { get; set; }

        public int EscuelaId { get; set; }
        public Escuela Escuela { get; set; }
    }
}