using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        private int anioCalendario;
        private int cupo;
        private string descripcion;
        private Materia materia;
        private Comision comision;

        public Curso()
        {
            this.materia = new Materia();
            this.comision = new Comision();
        }

        public int AnioCalendario
        {
            get { return anioCalendario;}
            set { anioCalendario = value;}
        }

        public int Cupo
        {
            get { return cupo;}
            set { cupo = value;}
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value;}
        }

        public Comision Comision
        {
            get { return comision; }
            set { comision = value; }
        }

        public Materia Materia
        {
            get { return materia; }
            set { materia = value; }
        }

        public string DescMateria
        {
            get { return materia.Descripcion; }
        }

        public string DescComision
        {
            get { return comision.Descripcion; }
        }
    }
}