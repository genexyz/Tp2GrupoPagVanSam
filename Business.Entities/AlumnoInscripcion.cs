using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class AlumnoInscripcion : BusinessEntity
    {
        private string condicion;
        private int nota;
        private Persona alumno;
        private Curso curso;

        public AlumnoInscripcion()
        {
            this.alumno = new Persona();
            this.curso = new Curso();
        }

        public string Condicion
        {
            get { return condicion; }
            set { condicion = value; }
        }

        public Persona Alumno
        {
            get { return Alumno; }
            set { Alumno = value; }
            
        }

        public Curso Curso
        {
            get { return curso; }
            set { curso = value; }
        }

        public int Nota
        {
            get { return nota; }
            set { nota = value; }
        }

        public string DescComision
        {
            get { return Curso.Comision.Descripcion; }
        }

        public string DescMateria
        {
            get { return Curso.Materia.Descripcion; }
        }

        public int AnioCurso
        {
            get { return Curso.AnioCalendario; }
        }

        public string Apellido
        {
            get { return this.Alumno.Apellido; }
        }

        public string Nombre
        {
            get { return this.Alumno.Nombre; }
        }
    }
}