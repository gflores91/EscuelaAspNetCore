using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EscuelaAspNetCore.Models
{
    public class Alumno : ObjetoEscuelaBase
    {
        [Required(ErrorMessage = "El nombre del alumno es requerido")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        [Display(Name = "Nombre del alumno")]
        public override string Nombre { get; set; }
        public List<Evaluacion> Evaluaciones { get; set; }
        [Required]
        [Display(Name = "Curso")]
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}