using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Usuarios : Modes
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadGrid();

        }

        UsuarioLogic _logic;
        private UsuarioLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }

        PersonaLogic logic;
        public PersonaLogic LogicPersona
        {
            get
            {
                if (logic == null)
                    logic = new PersonaLogic();
                return logic;
            }
        }

        private Usuario Entity
        {
            get;
            set;
        }

        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                    return (int)this.ViewState["SelectedID"];
                else
                    return 0;
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        protected void gridView_SelectedIndexChanged (object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm (int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.habilitadoCheckBox.Checked = this.Entity.Habilitado;
            this.nombreUsuarioTextBox.Text = this.Entity.NombreUsuario;
            this.personaTextBox.Text = this.Entity.Persona.Apellido + " " + this.Entity.Persona.Nombre;
        }

        private void LoadPersonaForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.personaTextBox.Text = this.Entity.Persona.Apellido + " " + this.Entity.Persona.Nombre;
        }

        private void LoadEntity(Usuario usuario)
        {
            usuario.NombreUsuario = this.nombreUsuarioTextBox.Text;
            usuario.Clave = this.claveTextBox.Text;
            usuario.Habilitado = this.habilitadoCheckBox.Checked;


        }

        private void SaveEntity(Usuario usuario)
        {
            this.Logic.Save(usuario);
        }

        private void DeleteEntity (int id)
        {
            this.Logic.Delete(id);
        }

        private void EnableForm(bool enable)
        {
            this.nombreUsuarioTextBox.Enabled = enable;
            this.claveTextBox.Visible = enable;
            this.claveLabel.Visible = enable;
            this.repetirClaveLabel.Visible = enable;
            this.repetirClaveTextBox.Visible = enable;
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }

       

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                seleccionarPersonaLabel.Visible = false;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = Logic.GetOne(SelectedID);
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Usuario();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                default:
                    break;
            }
            this.formPanel.Visible = false;
        }

        protected void seleccionarPersonaLabel_Click(object sender, EventArgs e)
        {
            LoadGridPersonas();
            personasPanel.Visible = true;
            personasSelecPanel.Visible = true;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            seleccionarPersonaLabel.Visible = true;
            personaTextBox.Text = " Persona no Seleccionada ";
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        private void ClearForm()
        {
            this.nombreUsuarioTextBox.Text = string.Empty;
            this.habilitadoCheckBox.Checked = false;
        }

        protected void cancelarLinkbutton_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.formPanel.Visible = false;

        }

        private void LoadGridPersonas()
        {
            this.dgvPersonas.DataSource = this.Logic.GetAll();
            this.dgvPersonas.DataBind();
        }

        protected void dgvPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.dgvPersonas.SelectedValue;
        }

        protected void lbSeleccionar_Click(object sender, EventArgs e)
        {
            LoadPersonaForm(SelectedID);
            personasSelecPanel.Visible = personasPanel.Visible = false;
        }

        protected void lbCancelar_Click(object sender, EventArgs e)
        {
            personasSelecPanel.Visible = personasPanel.Visible = false;
        }
    }
}