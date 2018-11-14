using System;
using System.Collections.Generic;

namespace EscuelaAspNetCore.Models
{
    public class Asignatura: ObjetoEscuelaBase
    {
        public List<Asignatura> Asignaturas { get; set; }
    }
}