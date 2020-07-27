using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Usuario : BusinessEntity
    {

        private string nombreUsuario;
        private string clave;
        private bool habilitado;
        private Persona persona;
        private List<ModuloUsuario> modulosUsuarios;

        public Usuario()
        {
            this.persona = new Persona();
            this.modulosUsuarios = new List<ModuloUsuario>();
        }

        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }
        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }

        public bool Habilitado
        {
            get { return habilitado; }
            set { habilitado = value; }
        }

        public Persona Persona
        {
            get { return persona; }
            set { persona = value; }
        }

        public List<ModuloUsuario> ModulosUsuarios
        {
            get { return this.modulosUsuarios; }
            set { this.modulosUsuarios = value; }
        }

        public string Nombre
        {
            get { return this.Persona.Nombre; }
        }

        public string Apellido
        {
            get { return this.Persona.Apellido; }
        }

        public string Email
        {
            get { return this.Persona.Email; }
        }

        public string TipoPersona
        {
            get { return this.Persona.TipoPersona; }
        }




    }
}
