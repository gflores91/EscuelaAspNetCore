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

            modelBuilder.Entity<Escuela>().HasData(CargarEscuela());
            modelBuilder.Entity<Asignatura>().HasData(CargarAsignaturas().ToArray());
            modelBuilder.Entity<Alumno>().HasData(GenerarAlumnos().ToArray());
            //modelBuilder.Entity<Curso>().HasData(CargarCursos().ToArray());
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

        private List<Asignatura> CargarAsignaturas()
        {
            // foreach (var curso in CargarCursos())
            // {
                var ListaAsignaturas = new List<Asignatura>(){
                    new Asignatura{Nombre = "Matematicas"},
                    new Asignatura{Nombre = "Lenguaje"},
                    new Asignatura{Nombre = "Ciencias Naturales"},
                    new Asignatura{Nombre = "Manualidades"},
                    new Asignatura{Nombre = "Tecnología"}
                };

                return ListaAsignaturas;
                // curso.Asignaturas = ListaAsignaturas;
            // }
        }

         private List<Alumno> GenerarAlumnos()
        {
            string[] nombre1 = { "María", "Gabriel", "Alexis", "Pablo", "René" };
            string[] nombre2 = { "Alicia", "Flores", "Torres", "Alarcón", "Tapia" };
            string[] apellido = { "Cid", "Monsalve", "Torres", "Sepulveda", "Quezada" };

            var ListaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from ap in apellido
                               select new Alumno { Nombre = $"{n1} {n2} {ap}" };

            return ListaAlumnos.OrderBy((al) => al.Id).ToList();
        }

        private List<Curso> CargarCursos()
        {
            var cursos = new List<Curso>(){
                new Curso
                {
                    Nombre = "A-1",
                    Jornada = TiposJornadas.Diurna
                },
                new Curso
                {
                    Nombre = "B-1",
                    Jornada = TiposJornadas.Vespertina
                },
                new Curso
                {
                    Nombre = "C-3",
                    Jornada = TiposJornadas.Diurna
                }
            };

            Random rnd = new Random();

            foreach (var curso in cursos)
            {
                int cantidad = rnd.Next(5, 40);
                curso.Alumnos = GenerarAlumnos();
            }

            return cursos;
        }
    }
}