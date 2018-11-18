using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace EscuelaAspNetCore.Models
{
    public class Evaluacion : ObjetoEscuelaBase
    {
        [Required(ErrorMessage = "El nombre de la evaluación es requerido")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        [Display(Name = "Nombre de la evaluación")]
        public override string Nombre { get; set; }

        [Required(ErrorMessage = "La nota es requerida"),DataType(DataType.Currency)]
        [Range(0f, 7f, ErrorMessage = "La nota de estar entre 0.00 y 7.00")]
        [RegularExpression(
            @"\d{9}|^\d+\.\d{0,2}$",
            ErrorMessage = "La nota debe ser decimal y tener el siguiente formato: X.YY"
        )]
        public string Nota { get; set; }

        [Required(ErrorMessage = "La asignatura es requerida")]
        [Display(Name = "Asignatura")]
        public int AsignaturaId { get; set; }
        public Asignatura Asignatura { get; set; }

        [Required(ErrorMessage = "El alumno es requerido")]
        [Display(Name = "Alumno")]
        public int AlumnoId { get; set; }
        public Alumno Alumno { get; set; }
    }
}