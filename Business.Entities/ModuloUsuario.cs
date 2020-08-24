using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class ModuloUsuario : BusinessEntity
    {
        private int idUsuario;
        private Modulo modulo;
        private bool permiteAlta;
        private bool permiteBaja;
        private bool permiteModificacion;
        private bool permiteConsulta;

        public ModuloUsuario()
        {
            this.Modulo = new Modulo();
        }

        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        public int IDModulo
        {
            get { return this.Modulo.ID; }
        }

        public Modulo Modulo
        {
            get { return modulo; }
            set { modulo = value; }
        }
        public bool PermiteAlta
        {
            get { return permiteAlta; }
            set { permiteAlta = value; }
        }
        public bool PermiteBaja
        {
            get { return permiteBaja; }
            set { permiteBaja = value; }
        }
        public bool PermiteModificacion
        {
            get { return permiteModificacion; }
            set { permiteModificacion = value; }
        }
        public bool PermiteConsulta
        {
            get { return permiteConsulta; }
            set { permiteConsulta = value; }
        }
        public string DescModulo
        {
            get { return this.Modulo.Descripcion; }
        }
        


    }
}
