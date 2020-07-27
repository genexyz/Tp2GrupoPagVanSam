using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        Usuario _usuarioActual;

        public Usuario UsuarioActual
        {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
        }
        public UsuarioDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }
        public UsuarioDesktop(int id, ModoForm modo) : this() 
        {
            this.Modo = modo;
            UsuarioLogic usuarioLogic = new UsuarioLogic();
            this.UsuarioActual = usuarioLogic.GetOne(id);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;

            switch (Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
            


        }
        public override void MapearADatos() 
        {
            if (Modo == ModoForm.Alta)
            {
                var usuario = new Usuario();
                UsuarioActual = usuario;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Modificacion) { this.UsuarioActual.ID = int.Parse(this.txtID.Text); }
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.Persona.Nombre = this.txtNombre.Text;
                this.UsuarioActual.Persona.Apellido = this.txtApellido.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;
                this.UsuarioActual.Persona.Email = this.txtEmail.Text;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
            }
            switch (Modo)
            {
                case ModoForm.Alta:
                    UsuarioActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    UsuarioActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    UsuarioActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    UsuarioActual.State = BusinessEntity.States.Unmodified;
                    break;
            }

        }
        public override void GuardarCambios() 
        {
            MapearADatos();
            var usuariologic = new UsuarioLogic();
            usuariologic.Save(UsuarioActual);
        }
        public override bool Validar()
        {
            bool valido = true;
            if (
            this.txtNombre.TextLength == 0 ||
            this.txtApellido.TextLength == 0 ||
            this.txtClave.TextLength == 0 ||
            this.txtConfirmarClave.TextLength == 0 ||
            this.txtEmail.TextLength == 0 ||
            this.txtUsuario.TextLength == 0)
            {
                Notificar("Alguno de los campos esta vacio",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                valido = false;
            }
            if (this.txtClave.TextLength < 8)
            {
                Notificar("La clave tiene menos de 8 caracteres",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                valido = false;
            }
            if (this.txtClave.Text != this.txtConfirmarClave.Text)
            {
                Notificar("Las claves no coinciden",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                valido = false;
            }
            if (!IsEmailValid(this.txtEmail.ToString())) 
            {
                Notificar("El email no es valido",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                valido = false;
            }
            return valido;
        
        }
        public void Notificar(string titulo, string mensaje, MessageBoxButtons
        botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public void Notificar(string mensaje, MessageBoxButtons botones,
        MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        public bool IsEmailValid(string emailaddress)
        {
            try
            {
                System.Net.Mail.MailAddress m = new System.Net.Mail.MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
