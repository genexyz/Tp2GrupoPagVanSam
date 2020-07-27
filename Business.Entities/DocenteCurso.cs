using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
        private string cargo;
        private Persona docente;
        private Curso curso;

        public DocenteCurso()
        {
            this.docente = new Persona();
            this.curso = new Curso();
        }

        public string Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        public Persona Docente
        {
            get { return docente; }
            set { docente = value; }
        }

        public Curso Curso
        {
            get { return curso; }
            set { curso = value; }
        }

        public string ApellidoDocente
        {
            get { return this.Docente.Apellido; }
        }

        public string NombreDocente
        {
            get { return this.Docente.Nombre; }
        }
    }
}