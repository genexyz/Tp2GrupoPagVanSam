using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {
            if (usuarioActual.Persona.TipoPersona == "No docente")
                this.dgvPermisos.Visible = true;
            else
                this.dgvPermisos.Visible = false;
        }

        Usuario usuarioActual;

        public UsuarioDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
            usuarioActual = new Usuario();

        }

        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            UsuarioLogic UsuarioNegocio = new UsuarioLogic();
            try
            {
                usuarioActual = UsuarioNegocio.GetOne(ID);
                if (usuarioActual.Persona.TipoPersona == "No docente")
                {
                    this.dgvPermisos.AutoGenerateColumns = false;
                    ModuloUsuarioLogic logic = new ModuloUsuarioLogic();
                    dgvPermisos.DataSource = logic.GetAll(ID);
                }
                this.MapearDeDatos();
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Usuario UsuarioActual
        {
            get { return usuarioActual; }
            set { usuarioActual = value; }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = usuarioActual.ID.ToString();
            this.txtUsuario.Text = usuarioActual.NombreUsuario;
            this.txtClave.Text = usuarioActual.Clave;
            this.txtConfirmarClave.Text = usuarioActual.Clave;
            this.chkHabilitado.Checked = usuarioActual.Habilitado;
            this.txtPersona.Text = usuarioActual.Apellido + " " + usuarioActual.Nombre;

            switch (this.Modo)
            {
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
                default:
                    this.btnAceptar.Text = "Guardar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            switch (this.Modo)
            {
                case ModoForm.Baja:
                    usuarioActual.State = Usuario.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    usuarioActual.State = Usuario.States.Unmodified;
                    break;
                case ModoForm.Alta:
                    usuarioActual.State = Usuario.States.New;
                    break;
                case ModoForm.Modificacion:
                    usuarioActual.State = Usuario.States.Modified;
                    break;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Modificacion)
                    usuarioActual.ID = Convert.ToInt32(this.txtID.Text);
                usuarioActual.NombreUsuario = this.txtUsuario.Text;
                usuarioActual.Clave = this.txtClave.Text;
                usuarioActual.Habilitado = this.chkHabilitado.Checked;
                foreach (DataGridViewRow row in this.dgvPermisos.Rows)
                {
                    usuarioActual.ModulosUsuarios.Add((ModuloUsuario)row.DataBoundItem);
                }
                
            }

        }

        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                UsuarioLogic userlogic = new UsuarioLogic();
                if (Modo != ModoForm.Alta || !userlogic.Existe(usuarioActual.NombreUsuario))
                    userlogic.Save(usuarioActual);
                else this.Notificar("Ya existe un Usuario con ese Nombre de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override bool Validar()
        {
            Boolean EsValido = true;
            foreach (Control oControls in this.Controls)
            {
                if (oControls is TextBox && oControls.Text == String.Empty && oControls != this.txtID)
                {
                    EsValido = false;
                    break;
                }
            }
            if (EsValido == false)
                this.Notificar("Todos los campos son obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (this.txtClave.Text != this.txtConfirmarClave.Text)
            {
                EsValido = false;
                this.Notificar("La clave no coincide con la confirmacion de la misma", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (this.txtClave.Text.Length < 8)
            {
                EsValido = false;
                this.Notificar("La clave debe tener al menos 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (this.usuarioActual.Persona.ID == 0)
            {
                EsValido = false;
                this.Notificar("No se le asignó una Persona al Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return EsValido;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeleccionarPersona_Click(object sender, EventArgs e)
        {
            SeleccionarPersona select = new SeleccionarPersona(usuarioActual);
            select.ShowDialog();
            this.usuarioActual = select.UsuarioActual;
            this.txtPersona.Text = usuarioActual.Apellido + " " + usuarioActual.Nombre;
            if (usuarioActual.Persona.TipoPersona == "No docente")
            {
                try
                {
                    this.dgvPermisos.AutoGenerateColumns = false;
                    ModuloUsuarioLogic logic = new ModuloUsuarioLogic();
                    dgvPermisos.DataSource = logic.GetAll(UsuarioActual.ID);
                    dgvPermisos.Visible = true;
                }
                catch (Exception ex)
                {
                    this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                this.dgvPermisos.Visible = false;
        }
    }
}
