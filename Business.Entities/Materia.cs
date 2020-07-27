using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Materia : BusinessEntity
    {
        private string descripcion;
        private int hSSemanales;
        private int hSTotales;
        private Plan plan;

        public Materia()
        {
            this.plan = new Plan();
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int HSSemanales
        {
            get { return hSSemanales; }
            set { hSSemanales = value; }
        }

        public int HSTotales
        {
            get { return hSTotales; }
            set { hSTotales = value; }
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