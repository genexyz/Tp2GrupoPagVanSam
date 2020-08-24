using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class DocenteCursoDesktop : ApplicationForm
    {
        private Curso cursoActual;
        private DocenteCurso docenteCursoActual;

        public DocenteCursoDesktop()
        {
            InitializeComponent();
        }

        public DocenteCursoDesktop(ModoForm modo, Curso c) : this()
        {
            this.Modo = modo;
            cursoActual = c;
            docenteCursoActual = new DocenteCurso();
        }

        public DocenteCursoDesktop(int ID, ModoForm modo, Curso c) : this()
        {
            this.Modo = modo;
            try
            {
                cursoActual = c;
                DocenteCursoLogic DocCursNegocio = new DocenteCursoLogic();
                docenteCursoActual = DocCursNegocio.GetOne(ID);
                this.MapearDeDatos();
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = docenteCursoActual.ID.ToString();
            this.cbxCargo.SelectedItem = docenteCursoActual.Cargo;

            switch (this.Modo)
            {
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    this.btnSelecDocente.Visible = false;
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            switch (this.Modo)
            {
                case ModoForm.Baja:
                    docenteCursoActual.State = DocenteCurso.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    docenteCursoActual.State = DocenteCurso.States.Unmodified;
                    break;
                case ModoForm.Alta:
                    docenteCursoActual.State = Plan.States.New;
                    break;
                case ModoForm.Modificacion:
                    docenteCursoActual.State = DocenteCurso.States.Modified;
                    break;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Modificacion)
                    docenteCursoActual.ID = Convert.ToInt32(this.txtID.Text);
                docenteCursoActual.Curso.ID = cursoActual.ID;
                docenteCursoActual.Cargo = cbxCargo.SelectedItem.ToString();
            }
        }

        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                DocenteCursoLogic DCLogic = new DocenteCursoLogic();
                if (Modo != ModoForm.Alta || !DCLogic.Existe(docenteCursoActual.Curso.ID, docenteCursoActual.Docente.ID, docenteCursoActual.Cargo))
                    DCLogic.Save(docenteCursoActual);
                else this.Notificar("Este Docente ya se encuentra asignado a este Curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override bool Validar()
        {
            Boolean EsValido = true;
            if (this.cbxCargo.SelectedItem == null)
            {
                EsValido = false;
                this.Notificar("No se seleccionó un Cargo para el Docente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (this.docenteCursoActual.Docente.ID == 0)
            {
                this.Notificar("No se seleccionó un Docente para el Curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EsValido = false;
            }
            return EsValido;
        }

        private void btnSelecDocente_Click(object sender, EventArgs e)
        {
            SeleccionarDocentes doc = new SeleccionarDocentes(cursoActual);
            doc.ShowDialog();
            docenteCursoActual.Docente = doc.Docente;
            this.txtDocente.Text = docenteCursoActual.Docente.Apellido + " " + docenteCursoActual.Docente.Nombre;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

    }
}
