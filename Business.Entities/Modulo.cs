using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Modulo : BusinessEntity
    {
        private string descripcion;
        private string ejecuta;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Ejecuta
        {
            get { return ejecuta; }
            set { ejecuta = value; }
        }
    }
}
