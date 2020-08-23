using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {
        private string apellido;
        private string direccion;
        private string email;
        private DateTime fechaNacimiento;
        private int legajo;
        private string nombre;
        private string telefono;
        private string tipoPersona;
        private Plan plan;

        public Persona()
        {
            this.Plan = new Plan();
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public Plan Plan
        {
            get { return plan; }
            set { plan = value; }
        }

        public int Legajo
        {
            get { return legajo; }
            set { legajo = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string TipoPersona
        {
            get { return tipoPersona; }
            set { tipoPersona = value; }
        }

        public string DescPlan
        {
            get { return plan.Descripcion; }
        }

        public string DescEspecialidad
        {
            get { return plan.DescEspecialidad; }
        }
    }
}