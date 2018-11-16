namespace EscuelaAspNetCore.Models
{
    public class Evaluacion: ObjetoEscuelaBase
    {
        public float Nota { get; set; }

        public string AsignaturaId { get; set; }
        public Asignatura Asignatura { get; set; }

        public string AlumnoId { get; set; }
        public Alumno Alumno { get; set; }


        public override string ToString()
        {
            return $"{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}";
        }
    }
}