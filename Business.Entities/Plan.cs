using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Plan : BusinessEntity
    {
        private string descripcion;
        private Especialidad especialidad;

        public Plan()
        {
            this.Especialidad = new Especialidad();
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public Especialidad Especialidad
        {
            get { return especialidad; }
            set { especialidad = value; }
        }
        public string DescEspecialidad
        {
            get { return this.Especialidad.Descripcion; }
        }
    }
}