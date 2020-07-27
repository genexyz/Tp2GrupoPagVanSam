using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Comision : BusinessEntity
    {
        private int anioEspecialidad;
        private string descripcion;
        private Plan plan;

        public Comision()
        {
            this.plan = new Plan();
        }
        public int AnioEspecialidad
        {
            get { return anioEspecialidad; }
            set { anioEspecialidad = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public Plan Plan
        {
            get { return plan; }
            set { plan = value; }
        }

        public string DescPlan
        {
            get { return this.Plan.Descripcion; }
        }

        public string DescEspecialidad
        {
            get { return this.Plan.Especialidad.Descripcion; }
        }
    }
}