using System.Collections.Generic;

namespace EscuelaAspNetCore.Models
{
    public class Alumno: ObjetoEscuelaBase
    {
        public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
    }
}