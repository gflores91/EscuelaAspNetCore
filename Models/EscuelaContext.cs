using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EscuelaAspNetCore.Models
{
    public class EscuelaContext : DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var cursos = CargarCursos(CargarEscuela());
            var asignaturas = CargarAsignaturas(cursos);
            var alumnos = CargarAlumnos(cursos);

            modelBuilder.Entity<Escuela>().HasData(CargarEscuela());
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());
        }

        private Escuela CargarEscuela()
        {
            var escuela = new Escuela()
            {
                Nombre = "Exodus Academy",
                Direccion = "Angol, Concepción, Chile",
                AnioFundacion = 2018,
                TipoEscuela = TiposEscuelas.Universitaria
            };

            return escuela;
        }

        private List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            var ListaAsignaturas = new List<Asignatura>();
            foreach (var curso in cursos)
            {
                var LTmpAsignaturas = new List<Asignatura>(){
                    new Asignatura{Nombre = "Matematicas", CursoId = curso.Id},
                    new Asignatura{Nombre = "Lenguaje", CursoId = curso.Id},
                    new Asignatura{Nombre = "Ciencias Naturales", CursoId = curso.Id},
                    new Asignatura{Nombre = "Manualidades", CursoId = curso.Id},
                    new Asignatura{Nombre = "Tecnología", CursoId = curso.Id}
                };
                ListaAsignaturas.AddRange(LTmpAsignaturas);
                //curso.Asignaturas = LTmpAsignaturas;
            }

            return ListaAsignaturas;
        }

        private List<Alumno> GenerarAlumnos(Curso curso, int cantidad)
        {
            string[] nombre1 = { "María", "Gabriel", "Alexis", "Pablo", "René" };
            string[] nombre2 = { "Alicia", "Flores", "Torres", "Alarcón", "Tapia" };
            string[] apellido = { "Cid", "Monsalve", "Torres", "Sepulveda", "Quezada" };

            var ListaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from ap in apellido
                               select new Alumno
                               {
                                   Nombre = $"{n1} {n2} {ap}",
                                   CursoId = curso.Id
                               };

            return ListaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }

        private List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            var listaAlumnos = new List<Alumno>();

            Random rnd = new Random();
            foreach (var curso in cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                var tmplist = GenerarAlumnos(curso, cantRandom);
                listaAlumnos.AddRange(tmplist);
            }
            return listaAlumnos;
        }

        private List<Curso> CargarCursos(Escuela escuela)
        {
            var cursos = new List<Curso>(){
                new Curso
                {
                    Nombre = "A-1",
                    Jornada = TiposJornadas.Diurna,
                    EscuelaId = escuela.Id
                },
                new Curso
                {
                    Nombre = "B-1",
                    Jornada = TiposJornadas.Vespertina,
                    EscuelaId = escuela.Id
                },
                new Curso
                {
                    Nombre = "C-3",
                    Jornada = TiposJornadas.Diurna,
                    EscuelaId = escuela.Id
                }
            };
            return cursos;
        }
    }
}