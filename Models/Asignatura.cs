using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EscuelaAspNetCore.Models
{
    public class Asignatura : ObjetoEscuelaBase
    {
        [Required(ErrorMessage = "El nombre de la asignatura es requerido")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        [Display(Name = "Nombre de la asignatura")]
        public override string Nombre { get; set; }
        [Required]
        [Display(Name = "Curso")]
        public int CursoId { get; set; }
        public Curso Curso { get; set; }

        public List<Evaluacion> Evaluaciones { get; set; }
    }
}